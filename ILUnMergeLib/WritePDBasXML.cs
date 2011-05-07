// Sample to load PDB and dump as XML.
// Author: Mike Stall  (http://blogs.msdn.com/jmstall)
// UPDATED on 1/26/05, uses PDB wrappers from MDBG sample.
// must include reference to Mdbg (such as MdbgCore.dll)
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Diagnostics;

namespace ACATool.Tasks
{

	public class WritePDBasXML : Task
	{
		#region Props
		private ITaskItem _assemblyName;
		[Required]
		public ITaskItem AssemblyName
		{
			get
			{
				return _assemblyName;
			}
			set
			{
				_assemblyName = value;
			}
		}

        private ITaskItem _pddxmlFile;
        [Output]
        public ITaskItem PDBAsXmlFile
        {
            get
            {
                return _pddxmlFile;
            }
        }

		#endregion

		System.Reflection.Assembly m_assembly;
		Dictionary<string, int> m_fileMapping = new Dictionary<string, int>();

		XmlTextWriter xwriter;

		public override bool Execute()
		{
			string pdbxmlFile = Path.ChangeExtension(AssemblyName.ItemSpec, ".pdb.xml");
            _pddxmlFile = new TaskItem(pdbxmlFile);
			xwriter = new XmlTextWriter(pdbxmlFile, null);
			xwriter.Formatting = Formatting.Indented;


            
			//Log.LogMessage("Get symbol reader for file {0}", Path.ChangeExtension(AssemblyName.ItemSpec, ".pdb"));
			ISymbolReader reader = SymUtil.GetSymbolReaderForFile(AssemblyName.ItemSpec, null);
			//Log.LogMessage("Load assembly");
			m_assembly = System.Reflection.Assembly.LoadFrom(AssemblyName.ItemSpec);

			// Begin writing XML.
			xwriter.WriteStartDocument();
			xwriter.WriteComment("This is an XML file representing the PDB for '" + AssemblyName.ItemSpec + "'");
			xwriter.WriteStartElement("Types");


			// Record what input file these symbols are for.
			xwriter.WriteAttributeString("file", AssemblyName.ItemSpec);

			//WriteDocList(reader);
			WriteTypesAndDocs(reader);

			xwriter.WriteEndElement(); // "Symbols";
			xwriter.Close();

			return !Log.HasLoggedErrors;
		}

		// Dump all of the methods in the given ISymbolReader to the XmlWriter provided in the ctor.
		void WriteTypesAndDocs(ISymbolReader reader)
		{
			//Log.LogMessage("Write Types and Docs");

	
			// Use reflection to enumerate all methods            
			foreach (Type t in m_assembly.GetTypes())
			{
				Dictionary<string, int> uniqDocs = GetUniqDocs(reader, t);
				if (uniqDocs.Count == 0)
                {
                    Debug.WriteLine(string.Format("Type {0} does not have any methods. Unable to determine which file defines this type", t.Name));
                    //Log.LogWarning("Type {0} does not have any methods. Unable to determine which file defines this type",t.Name);
                    continue;

                }
				xwriter.WriteStartElement("Type");
				xwriter.WriteAttributeString("Name", t.FullName);
				foreach (string doc in uniqDocs.Keys)
				{
					xwriter.WriteStartElement("File");
					xwriter.WriteAttributeString("Name",doc);
					xwriter.WriteEndElement();
				}
				xwriter.WriteEndElement(); // type
			}
		}


		private Dictionary<string, int> GetUniqDocs(ISymbolReader reader, Type t)
		{
			Dictionary<string, int> uniqDocs = new Dictionary<string, int>();
           
			foreach (MethodInfo methodReflection in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
			{
                GetUniqDocsForMethod(reader, uniqDocs, methodReflection.MetadataToken);
            }

			return uniqDocs;
		}

        private void GetUniqDocsForMethod(ISymbolReader reader, Dictionary<string, int> uniqDocs,int metadataToken)
        {
            ISymbolMethod methodSymbol = null;
            try
            {           
                methodSymbol = reader.GetMethod(new SymbolToken(metadataToken));
                ISymbolDocument[] docs = GetDocumentList(methodSymbol);

                foreach (ISymbolDocument d in docs)
                {
                    if (!uniqDocs.ContainsKey(d.URL))
                        uniqDocs[d.URL] = 1;
                }
            }
            catch (COMException) { }
        }
        ISymbolDocument[] GetDocumentList(ISymbolMethod method)
		{
			int count = method.SequencePointCount;

			// Get the sequence points from the symbol store. 
			// We could cache these arrays and reuse them.
			int[] offsets = new int[count];
			ISymbolDocument[] docs = new ISymbolDocument[count];
			int[] startColumn = new int[count];
			int[] endColumn = new int[count];
			int[] startRow = new int[count];
			int[] endRow = new int[count];

			method.GetSequencePoints(offsets, docs, startRow, startColumn, endRow, endColumn);
			return docs;
		}


		void WriteDocList(ISymbolReader reader)
		{
			xwriter.WriteComment("This is a list of all source files referred by the PDB.");

			int id = 0;
			// Write doc list
			xwriter.WriteStartElement("files");
			{
				ISymbolDocument[] docs = reader.GetDocuments();
				foreach (ISymbolDocument doc in docs)
				{
					string url = doc.URL;

					// Symbol store may give out duplicate documents. We'll fold them here
					if (m_fileMapping.ContainsKey(url))
					{
						xwriter.WriteComment("There is a duplicate entry for: " + url);
						continue;
					}
					id++;
					m_fileMapping.Add(doc.URL, id);

					xwriter.WriteStartElement("file");
					{
						xwriter.WriteAttributeString("id", id.ToString());
						xwriter.WriteAttributeString("name", doc.URL);
					}
					xwriter.WriteEndElement(); // file
				}
			}
			xwriter.WriteEndElement(); // files
		}


	}//class
}//ns