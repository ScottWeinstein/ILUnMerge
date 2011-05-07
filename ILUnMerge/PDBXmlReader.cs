// Sample to load PDB and dump as XML.
// Author: Mike Stall  (http://blogs.msdn.com/jmstall)
// UPDATED on 1/26/05, uses PDB wrappers from MDBG sample.
// must include reference to Mdbg (such as MdbgCore.dll)
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;

using System.Runtime.InteropServices;

// For symbol store
using System.Diagnostics.SymbolStore;
using Microsoft.Samples.Debugging.CorSymbolStore;


namespace XmlPdbReader
{
    // Random utility methods.
    static class Util
    {
        // Format a token to a string. Tokens are in hex.
        public static string AsToken(int i)
        {
            return String.Format(System.Globalization.CultureInfo.InvariantCulture, "0x{0:x}", i);
        }

        // Since we're spewing this to XML, spew as a decimal number.
        public static string AsIlOffset(int i)
        {
            return i.ToString();
        }
    }

    /// <summary>
    /// Class to write out XML for a PDB.
    /// </summary>
    class Pdb2XmlConverter
    {
        /// <summary>
        /// Initialize the Pdb to Xml converter. Actual conversion happens in ReadPdbAndWriteToXml.
        /// Passing a filename also makes it easy for us to use reflection to get some information 
        /// (such as enumeration)
        /// </summary>
        /// <param name="writer">XmlWriter to spew to.</param>
        /// <param name="fileName">Filename for exe/dll. This class will find the pdb to match.</param>
        public Pdb2XmlConverter(XmlWriter writer, string fileName)
        {
            m_writer = writer;
            m_fileName = fileName;
        }

        // The filename that the pdb is for.
        string m_fileName;
        XmlWriter m_writer;

        // Keep assembly so we can query metadata on it.
        System.Reflection.Assembly m_assembly;

        // Maps files to ids. 
        Dictionary<string, int> m_fileMapping = new Dictionary<string, int>();

        /// <summary>
        /// Load the PDB given the parameters at the ctor and spew it out to the XmlWriter specified
        /// at the ctor.
        /// </summary>
        public void ReadPdbAndWriteToXml()
        {
            // Actually load the files
            ISymbolReader reader = SymUtil.GetSymbolReaderForFile(m_fileName, null);
            m_assembly = System.Reflection.Assembly.ReflectionOnlyLoadFrom(m_fileName);

            // Begin writing XML.
            m_writer.WriteStartDocument();
            m_writer.WriteComment("This is an XML file representing the PDB for '" + m_fileName + "'");
            m_writer.WriteStartElement("symbols");


            // Record what input file these symbols are for.
            m_writer.WriteAttributeString("file", m_fileName);

            WriteDocList(reader);
            WriteEntryPoint(reader);
            WriteAllMethods(reader);

            m_writer.WriteEndElement(); // "Symbols";
            
        }

        // Dump all of the methods in the given ISymbolReader to the XmlWriter provided in the ctor.
        void WriteAllMethods(ISymbolReader reader)
        {
            m_writer.WriteComment("This is a list of all methods in the assembly that matches this PDB.");
            m_writer.WriteComment("For each method, we provide the sequence tables that map from IL offsets back to source.");

            m_writer.WriteStartElement("methods");

            // Use reflection to enumerate all methods            
            foreach (Type t in m_assembly.GetTypes())
            {
                foreach (MethodInfo methodReflection in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    int token = methodReflection.MetadataToken;
                    ISymbolMethod methodSymbol = null;
                    
                    
                    m_writer.WriteStartElement("method");
                    {
                        m_writer.WriteAttributeString("name", t.FullName + "." + methodReflection.Name);
                        m_writer.WriteAttributeString("token", Util.AsToken(token));
                        try
                        {
                            methodSymbol = reader.GetMethod(new SymbolToken(token));                            
                            WriteSequencePoints(methodSymbol);
                            WriteLocals(methodSymbol);
                        }
                        catch (COMException )
                        {
                            m_writer.WriteComment("No symbol info");
                        }
                    }
                    m_writer.WriteEndElement(); // method                    
                }
            }
            m_writer.WriteEndElement();
        }

        // Write all the locals in the given method out to an XML file.
        // Since the symbol store represents the locals in a recursive scope structure, we need to walk a tree.
        // Although the locals are technically a hierarchy (based off nested scopes), it's easiest for clients
        // if we present them as a linear list. We will provide the range for each local's scope so that somebody
        // could reconstruct an approximation of the scope tree. The reconstruction may not be exact.
        // (Note this would still break down if you had an empty scope nested in another scope.
        void WriteLocals(ISymbolMethod method)
        {
            m_writer.WriteStartElement("locals");
            {
                // If there are no locals, then this element will just be empty.
                WriteLocalsHelper(method.RootScope);
            }
            m_writer.WriteEndElement();
        }

        // Helper method to write the local variables in the given scope.
        // Scopes match an IL range, and also have child scopes.
        void WriteLocalsHelper(ISymbolScope scope)
        {
            foreach (ISymbolVariable l in scope.GetLocals())
            {
                m_writer.WriteStartElement("local");
                {
                    m_writer.WriteAttributeString("name", l.Name);

                    // Each local maps to a unique "IL Index" or "slot" number.
                    // This index is what you pass to ICorDebugILFrame::GetLocalVariable() to get
                    // a specific local variable. 
                    Debug.Assert(l.AddressKind == SymAddressKind.ILOffset);
                    int slot = l.AddressField1;
                    m_writer.WriteAttributeString("il_index", slot.ToString());

                    // Provide scope range
                    m_writer.WriteAttributeString("il_start", Util.AsIlOffset(scope.StartOffset));
                    m_writer.WriteAttributeString("il_end", Util.AsIlOffset(scope.EndOffset));
                }
                m_writer.WriteEndElement(); // local
            }

            foreach (ISymbolScope childScope in scope.GetChildren())
            {
                WriteLocalsHelper(childScope);
            }
        }

        // Write the sequence points for the given method
        // Sequence points are the map between IL offsets and source lines.
        // A single method could span multiple files (use C#'s #line directive to see for yourself).        
        void WriteSequencePoints(ISymbolMethod method)
        {
            m_writer.WriteStartElement("sequencepoints");

            int count = method.SequencePointCount;
            m_writer.WriteAttributeString("total", count.ToString());

            // Get the sequence points from the symbol store. 
            // We could cache these arrays and reuse them.
            int[] offsets = new int[count];
            ISymbolDocument[] docs = new ISymbolDocument[count];
            int[] startColumn = new int[count];
            int[] endColumn = new int[count];
            int[] startRow = new int[count];
            int[] endRow = new int[count];
            method.GetSequencePoints(offsets, docs, startRow, startColumn, endRow, endColumn);

            // Write out sequence points
            for (int i = 0; i < count; i++)
            {
                m_writer.WriteStartElement("entry");
                m_writer.WriteAttributeString("il_offset", Util.AsIlOffset(offsets[i]));

                // If it's a special 0xFeeFee sequence point (eg, "hidden"), 
                // place an attribute on it to make it very easy for tools to recognize.
                // See http://blogs.msdn.com/jmstall/archive/2005/06/19/FeeFee_SequencePoints.aspx
                if (startRow[i] == 0xFeeFee)
                {
                    m_writer.WriteAttributeString("hidden", XmlConvert.ToString(true));
                }
                else
                {
                    m_writer.WriteAttributeString("start_row", startRow[i].ToString());
                    m_writer.WriteAttributeString("start_column", startColumn[i].ToString());
                    m_writer.WriteAttributeString("end_row", endRow[i].ToString());
                    m_writer.WriteAttributeString("end_column", endColumn[i].ToString());
                    m_writer.WriteAttributeString("file_ref", this.m_fileMapping[docs[i].URL].ToString());
                }
                m_writer.WriteEndElement();
            }

            m_writer.WriteEndElement(); // sequencepoints
        }

        // Write all docs, and add to the m_fileMapping list.
        // Other references to docs will then just refer to this list.
        void WriteDocList(ISymbolReader reader)
        {
            m_writer.WriteComment("This is a list of all source files referred by the PDB.");

            int id = 0;
            // Write doc list
            m_writer.WriteStartElement("files");
            {
                ISymbolDocument[] docs = reader.GetDocuments();
                foreach (ISymbolDocument doc in docs)
                {
                    string url = doc.URL;

                    // Symbol store may give out duplicate documents. We'll fold them here
                    if (m_fileMapping.ContainsKey(url))
                    {
                        m_writer.WriteComment("There is a duplicate entry for: " + url);
                        continue;
                    }
                    id++;
                    m_fileMapping.Add(doc.URL, id);

                    m_writer.WriteStartElement("file");
                    {
                        m_writer.WriteAttributeString("id", id.ToString());
                        m_writer.WriteAttributeString("name", doc.URL);
                    }
                    m_writer.WriteEndElement(); // file
                }
            }
            m_writer.WriteEndElement(); // files
        }

        // Write out a reference to the entry point method (if one exists)
        void WriteEntryPoint(ISymbolReader reader)
        {
            try
            {
                // If there is no entry point token (such as in a dll), this will throw.
                SymbolToken token = reader.UserEntryPoint;
                ISymbolMethod m = reader.GetMethod(token);

                Debug.Assert(m != null); // would have thrown by now.

                // Should not throw past this point
                m_writer.WriteComment(
                    "This is the token for the 'entry point' method, which is the method that will be called when the assembly is loaded." +
                    " This usually corresponds to 'Main'");

                m_writer.WriteStartElement("EntryPoint");
                WriteMethod(m);
                m_writer.WriteEndElement();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                // If the Symbol APIs fail when looking for an entry point token, there is no entry point.
                m_writer.WriteComment(
                    "There is no entry point token such as a 'Main' method. This module is probably a '.dll'");
            }
        }

        // Write out XML snippet to refer to the given method.
        void WriteMethod(ISymbolMethod method)
        {
            m_writer.WriteElementString("methodref", Util.AsToken(method.Token.GetToken()));
        }
    }

    // Harness to drive PDB to XML rea
    class Program
    {
         void SampleMain(string[] args)
        {
            Console.WriteLine("Test harness for PDB2XML.");

            if (args.Length < 2)
            {
                Console.WriteLine("Usage: Pdb2Xml <input managed exe> <output xml>");
                Console.WriteLine("This will load the pdb for the managed exe, and then spew the pdb contents to an XML file.");
                return;
            }
            string stInputExe = args[0];
            string stOutputXml = args[1];

            // Get a Text Writer to spew the PDB to.
            XmlDocument doc = new XmlDocument();
            XmlWriter xw = doc.CreateNavigator().AppendChild();

            // Do the pdb for the exe into an xml stream. 
            Pdb2XmlConverter p = new Pdb2XmlConverter(xw, stInputExe);
            p.ReadPdbAndWriteToXml();
            xw.Close();

            // Print the XML we just generated and save it to a file for more convenient viewing.
            Console.WriteLine(doc.OuterXml);

            doc.Save(stOutputXml);
            {
                // Proove that it's valid XML by reading it back in...
                XmlDocument d2 = new XmlDocument();
                d2.Load(stOutputXml);
            }

            // Now demonstrate some different queries.
            XmlNode root = doc.DocumentElement;

            DoQuery(QueryForStartRow("Foo.Main", 3), root);
            DoQuery(QueryForEntryName(), root);
            DoQuery(QueryForAllLocalsInMethod("Foo.Main"), root);
        } // end Main

        #region Sample Queries
        // Some sample queries
        static string QueryForEntryName()
        {
            return @"/symbols/methods/method[@token=/symbols/EntryPoint/methodref]/@name";
        }
        static string QueryForAllLocalsInMethod(string stMethod)
        {
            return "/symbols/methods/method[@name=\"" + stMethod + "\"]/locals/local/@name";
        }
        static string QueryForStartRow(string stMethod, int exactILOffset)
        {
            return "/symbols/methods/method[@name=\"" + stMethod + "\"]/sequencepoints/entry[@il_offset=\"" + exactILOffset + "\"]/@start_row";
        }

#if false            
            // Here are more sample queries:
            // Get all locals that are active at a given line?
            @"/symbols/methods/method/locals/local[@il_start<=""2"" and @il_end>=""2""]/@name";

            @"/symbols/files/file/@name"; // get all filenames referenced from PDB.

            // ** All methods that have code in a given filename.            
            @"/symbols/methods/method[sequencepoints/entry/@file_ref=/symbols/files/file[@name=""c:\temp\t.cs""]/@id]/@name";
                        
            @"/symbols/files/file[@name=""c:\temp\t.cs""]/@id"; // File ID for a given filename:
            
            @"/symbols/EntryPoint/methodref"; // entry point token.
            @"/symbols/methods/method/@name";  // ** select all names of all methods
            @"/symbols/methods/method[@token=""0x6000001""]";  // entire XML snippet for method with specified token value
            @"/symbols/methods/method[@token=""0x6000001""]/@name"; // ** just the name of method with the given token value
            @"/symbols/methods/method[@token=/symbols/EntryPoint/methodref]/@name";   // *** method name of the entry point token!!
            @"/symbols/methods/method[@name=""Foo.Main""]/locals/local/@name"; // name of all locals in method Foo.Main
            @"/symbols/methods/method/sequencepoints/entry[@il_offset=""0x12""]"; // sp entry for IL offset 12 (in all methods)
            @"/symbols/methods/method[@name=""Foo.Main""]/sequencepoints/entry/@start_row"; // get all source rows for method Foo.Main
            @"/symbols/methods/method[@name=""Foo.Main""]/sequencepoints/entry[@il_offset=""0x4""]/@start_row"; // get start row for for IL offset 4 in method Foo.Main

            // Lookup method name + IL offset given source file + line 
            // Queries only return 1 result, so there's not a good way to get the (name, IL offset) pair back with a single query.
            @"/symbols/methods/method/sequencepoints/entry[@start_row<=""26"" and @end_row>=""26"" and @file_ref=/symbols/files/file[@name=""c:\temp\t.cs""]/@id]/@il_offset";
            @"/symbols/methods/method[sequencepoints/entry[@start_row<=""26"" and @end_row>=""26"" and @file_ref=/symbols/files/file[@name=""c:\temp\t.cs""]/@id]]/@name";
#endif

        #endregion


        // Helper to execute a query and print out to console.
        static void DoQuery(string stQuery, XmlNode root)
        {
            Console.WriteLine("Query:{0}", stQuery);

            XmlNodeList nodeList = root.SelectNodes(stQuery);
            Console.WriteLine("Found {0} item(s) in query.", nodeList.Count);
            Console.WriteLine("(outer)-----------");
            foreach (XmlNode x in nodeList)
            {
                Console.WriteLine(x.OuterXml);
            }
            Console.WriteLine("(inner)-----------");
            foreach (XmlNode x in nodeList)
            {
                Console.WriteLine(x.InnerText);
            }
            Console.WriteLine("------------------");
        }
    }


    #region Get a symbol reader for the given module
    // Encapsulate a set of helper classes to get a symbol reader from a file.
    // The symbol interfaces require an unmanaged metadata interface.
    static class SymUtil
    {
        static class NativeMethods
        {
            [DllImport("ole32.dll")]
            public static extern int CoCreateInstance([In] ref Guid rclsid,
                                                       [In, MarshalAs(UnmanagedType.IUnknown)] Object pUnkOuter,
                                                       [In] uint dwClsContext,
                                                       [In] ref Guid riid,
                                                       [Out, MarshalAs(UnmanagedType.Interface)] out Object ppv);
        }

        // Wrapper.
        public static ISymbolReader GetSymbolReaderForFile(string pathModule, string searchPath)
        {
            return SymUtil.GetSymbolReaderForFile(new SymbolBinder(), pathModule, searchPath);
        }

        // We demand Unmanaged code permissions because we're reading from the file system and calling out to the Symbol Reader
        // @TODO - make this more specific.
        [System.Security.Permissions.SecurityPermission(
            System.Security.Permissions.SecurityAction.Demand,
            Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
        public static ISymbolReader GetSymbolReaderForFile(SymbolBinder binder, string pathModule, string searchPath)
        {
            // Guids for imported metadata interfaces.
            Guid dispenserClassID = new Guid(0xe5cb7a31, 0x7512, 0x11d2, 0x89, 0xce, 0x00, 0x80, 0xc7, 0x92, 0xe5, 0xd8); // CLSID_CorMetaDataDispenser
            Guid dispenserIID = new Guid(0x809c652e, 0x7396, 0x11d2, 0x97, 0x71, 0x00, 0xa0, 0xc9, 0xb4, 0xd5, 0x0c); // IID_IMetaDataDispenser
            Guid importerIID = new Guid(0x7dac8207, 0xd3ae, 0x4c75, 0x9b, 0x67, 0x92, 0x80, 0x1a, 0x49, 0x7d, 0x44); // IID_IMetaDataImport

            // First create the Metadata dispenser.
            object objDispenser;
            NativeMethods.CoCreateInstance(ref dispenserClassID, null, 1, ref dispenserIID, out objDispenser);

            // Now open an Importer on the given filename. We'll end up passing this importer straight
            // through to the Binder.
            object objImporter;
            IMetaDataDispenser dispenser = (IMetaDataDispenser)objDispenser;
            dispenser.OpenScope(pathModule, 0, ref importerIID, out objImporter);

            IntPtr importerPtr = IntPtr.Zero;
            ISymbolReader reader;
            try
            {
                // This will manually AddRef the underlying object, so we need to be very careful to Release it.
                importerPtr = Marshal.GetComInterfaceForObject(objImporter, typeof(IMetadataImport));

                reader = binder.GetReader(importerPtr, pathModule, searchPath);
            }
            finally
            {
                if (importerPtr != IntPtr.Zero)
                {
                    Marshal.Release(importerPtr);
                }
            }
            return reader;
        }
    }
    #region Metadata Imports

    // We can use reflection-only load context to use reflection to query for metadata information rather
    // than painfully import the com-classic metadata interfaces.
    [Guid("809c652e-7396-11d2-9771-00a0c9b4d50c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    interface IMetaDataDispenser
    {
        // We need to be able to call OpenScope, which is the 2nd vtable slot.
        // Thus we need this one placeholder here to occupy the first slot..
        void DefineScope_Placeholder();

        //STDMETHOD(OpenScope)(                   // Return code.
        //LPCWSTR     szScope,                // [in] The scope to open.
        //  DWORD       dwOpenFlags,            // [in] Open mode flags.
        //  REFIID      riid,                   // [in] The interface desired.
        //  IUnknown    **ppIUnk) PURE;         // [out] Return interface on success.
        void OpenScope([In, MarshalAs(UnmanagedType.LPWStr)] String szScope, [In] Int32 dwOpenFlags, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out Object punk);

        // Don't need any other methods.
    }

    // Since we're just blindly passing this interface through managed code to the Symbinder, we don't care about actually
    // importing the specific methods.
    // This needs to be public so that we can call Marshal.GetComInterfaceForObject() on it to get the
    // underlying metadata pointer.
    [Guid("7DAC8207-D3AE-4c75-9B67-92801A497D44"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
   // [CLSCompliant(true)]
    public interface IMetadataImport
    {
        // Just need a single placeholder method so that it doesn't complain about an empty interface.
        void Placeholder();
    }
    #endregion

    #endregion Get a symbol reader for the given module

} // XmlPdbReader
