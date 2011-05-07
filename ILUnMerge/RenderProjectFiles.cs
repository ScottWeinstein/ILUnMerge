using System;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Xml;
using System.IO;
using Mono.Cecil;
using System.Diagnostics;
using ACATool.Tasks;
using Microsoft.Build.Utilities;

namespace ACATool
{
	public class RenderProjectFiles
	{
		#region Props

		public RenderProjectFiles()
		{ }
		CondensedTypeGraph _graph;
		public CondensedTypeGraph Graph
		{
			get
			{
				return _graph;
			}
		}

		private string _pDBDataFile;
		public string PDBDataFile
		{
			get
			{
				return _pDBDataFile;
			}
		}
		private string _outputDirectory;
		public string OutputDirectory
		{
			get
			{
				return _outputDirectory;
			}
			set
			{
				_outputDirectory = value;
			}
		}

		private string _nameHint;
		public string NameHint
		{
			get
			{
				return _nameHint;
			}
			set
			{
				_nameHint = value;
			}
		}

		private string _solutionName;
		public string SolutionName
		{
			get
			{
				return _solutionName;
			}
			set
			{
				_solutionName = value;
			}
		}

		private bool _useRelativeFilePaths;
		public bool UseRelativeFilePaths
		{
			get
			{
				return _useRelativeFilePaths;
			}
			set
			{
				_useRelativeFilePaths = value;
			}
		}

        private string _AssemblyName;
        public string AssemblyFileName
        {
            get
            {
                return _AssemblyName;
            }
            set
            {
                _AssemblyName = value;
            }
        }

        private string _SourceDirectory;
        public string SourceDirectory
        {
            get
            {
                return _SourceDirectory;
            }
            set
            {
                _SourceDirectory = value;
            }
        }

		#endregion

		XPathDocument pdbXPathDoc;
		XPathNavigator pdbNav;
		Dictionary<string,int> nameHintCountMap = new Dictionary<string,int>();
		Dictionary<string,CondensedVertex> fileProjectMap = new Dictionary<string,CondensedVertex>();
		public void Execute()
		{

            DetermineClassDeps dcd = new DetermineClassDeps();
            TypeDependencyGraph tdg = new TypeDependencyGraph(false);
            dcd.AssemblyFile = AssemblyFileName;
            dcd.IgnoreOutsideRefs = false;
            dcd.Execute();
            tdg.LoadClassDependencies(dcd, true);
            this._graph = tdg.CondenseGraph();

            WritePDBasXML pdbxmlWritterTask = new WritePDBasXML();
            pdbxmlWritterTask.AssemblyName = new TaskItem(this.AssemblyFileName);

            if (pdbxmlWritterTask.Execute())
            {
                this._pDBDataFile = pdbxmlWritterTask.PDBAsXmlFile.ItemSpec;
                pdbXPathDoc = new XPathDocument(PDBDataFile);
                pdbNav = pdbXPathDoc.CreateNavigator();
            }



			Directory.CreateDirectory(OutputDirectory);
			foreach (CondensedVertex va in Graph.Vertices)
			{
				if (va.ImutableExternalType) continue;
				va.AssemblyName =  GetAssemblyName(va);
				if (va.AssemblyName.StartsWith("<"))
					continue;

				va.AssemblyGUID = Guid.NewGuid();
                va.ProjectFile = va.AssemblyName + ".csproj"; // );//Path.Combine(OutputDirectory,
			}

			foreach (CondensedVertex vassem in Graph.Vertices)
			{
				CreateProjectFile(vassem);	
			}

			CreateSolutionFile();
			
		}

		private void CreateSolutionFile()
		{
			StreamWriter sln = new StreamWriter(Path.Combine(OutputDirectory,NameHint + ".sln"), false, System.Text.Encoding.UTF8);
			
			string slnHeader = @"
Microsoft Visual Studio Solution File, Format Version 9.00
# Visual Studio 2005
";

			string slnStartGlobalSection = @"Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
";

			string slnEndGlobalSection = @"	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
";
			
			Guid csProjG = new Guid("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}");
			Guid slnItemsG = new Guid("{2150E333-8FDC-42A3-9474-1A3956D46DE8}");

			sln.Write(slnHeader);

			foreach (CondensedVertex va in Graph.Vertices)
			{
				if (va.AssemblyGUID == Guid.Empty)
					continue;

				sln.WriteLine("Project(\"{0:B}\") = \"{1}\", \"{2}\", \"{3:B}\"", csProjG,va.AssemblyName, va.ProjectFile,va.AssemblyGUID);
				sln.WriteLine("EndProject");
			}
			sln.Write(slnStartGlobalSection);
			foreach(CondensedVertex va in Graph.Vertices)
			{
				if (va.AssemblyGUID == Guid.Empty)
					continue;
				sln.WriteLine("{0:B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU",va.AssemblyGUID);
				sln.WriteLine("{0:B}.Debug|Any CPU.Build.0 = Debug|Any CPU",va.AssemblyGUID);
				sln.WriteLine("{0:B}.Release|Any CPU.ActiveCfg = Release|Any CPU", va.AssemblyGUID);
				sln.WriteLine("{0:B}.Release|Any CPU.Build.0 = Release|Any CPU", va.AssemblyGUID);
			}
			sln.Write(slnEndGlobalSection);

			sln.Close();
		}

		private void CreateProjectFile(CondensedVertex va)
		{
			if (va.ImutableExternalType || va.AssemblyName.StartsWith("<"))
				return;

			XmlTextWriter xproj = new XmlTextWriter(Path.Combine(OutputDirectory, va.ProjectFile), null);
			xproj.Formatting = Formatting.Indented;
			xproj.WriteStartDocument();
			xproj.WriteStartElement("Project");
			xproj.WriteAttributeString("DefaultTargets", "Build");
			xproj.WriteAttributeString("xmlns", "http://schemas.microsoft.com/developer/msbuild/2003");

			xproj.WriteStartElement("PropertyGroup");
			/*     <Configuration Condition=" ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
 */
			xproj.WriteStartElement("Configuration");
			xproj.WriteAttributeString("Condition", "'$(Configuration)'==''");
			xproj.WriteString("Debug");
			xproj.WriteEndElement();

			xproj.WriteStartElement("Platform");
			xproj.WriteAttributeString("Condition", "'$(Platform)'==''");
			xproj.WriteString("AnyCPU");
			xproj.WriteEndElement();


			xproj.WriteElementString("OutputType", "Library");
			xproj.WriteElementString("OutputPath", @"bin\Debug");
			xproj.WriteElementString("AssemblyName", va.AssemblyName);
//			xproj.WriteElementString("NoWarn", "1570,1571,1572,1573,1574,1584,1587,1591");

			xproj.WriteEndElement();//PropGroup

			WriteProjectImport(xproj, @"$(MSBuildBinPath)\Microsoft.CSharp.targets");
			
			WriteAssemRefsItemGroup(xproj,va);
			WriteProjectRefsItemGroup(xproj,va);
			WriteCompileItemGroup(xproj,va);
			WriteEmbeddedResourceItemGroup(xproj,va);

			xproj.WriteEndElement();//Project
			xproj.WriteEndDocument();
			xproj.Close();



		}

		private void WriteEmbeddedResourceItemGroup(XmlTextWriter xproj, CondensedVertex va)
		{
			//throw new Exception("The method or operation is not implemented.");
		}

		private void WriteCompileItemGroup(XmlTextWriter xproj, CondensedVertex va)
		{
            Dictionary<string, int> ListedFiles = new Dictionary<string, int>();
		
            xproj.WriteComment("Source files");
            xproj.WriteStartElement("ItemGroup");
			foreach (TypeReference tref in va.ContainedTypes)
			{
				foreach (string fullPath in GetFilesForType(tref.FullName))
				{
					if (ListedFiles.ContainsKey(fullPath))
						continue;

					CondensedVertex belongsToVetex = va;
					if (fileProjectMap.TryGetValue(fullPath,out belongsToVetex))
					{
                        //TODO: replace with exception or Log.Error
						Debug.WriteLine("Warning, file belong to another project");
					}
					else
					{
						fileProjectMap[fullPath] = va;
					}

					ListedFiles[fullPath] = 1;
					CheckNameMatchesFile(fullPath, tref);
					xproj.WriteStartElement("Compile");
                    xproj.WriteAttributeString("Include", fullPath);
					xproj.WriteEndElement();
				}
			}
			xproj.WriteEndElement();
		}

		private void CheckNameMatchesFile(string fullPath, TypeReference tref)
		{
			string namespaceAsPath = tref.Namespace.Replace('.','\\');
			if (fullPath.IndexOf(namespaceAsPath) < 0 && fullPath.IndexOf(namespaceAsPathShort) < 0)
			{
				Debug.WriteLine("Namespace doesn't match type");
			}

		}

        private void WriteProjectRefsItemGroup(XmlTextWriter xproj, CondensedVertex va)
        {
            xproj.WriteComment("Project Refs");
            xproj.WriteStartElement("ItemGroup");
            QuickGraph.Concepts.Collections.IVertexEnumerable projectRefs = Graph.AdjacentVertices(va);
            foreach (CondensedVertex projRef in projectRefs)
            {
                if (!projRef.ImutableExternalType)
                {
                    xproj.WriteStartElement("ProjectReference");
                    xproj.WriteAttributeString("Include", Path.GetFileName(projRef.ProjectFile));
                    xproj.WriteElementString("Project", projRef.AssemblyGUID.ToString("B"));
                    xproj.WriteElementString("Name", projRef.AssemblyName);
                    xproj.WriteEndElement();
                }
            }
            xproj.WriteEndElement();
        }

        private void WriteAssemRefsItemGroup(XmlTextWriter xproj, CondensedVertex va)
        {
            xproj.WriteComment("Assembly Refs");
            xproj.WriteStartElement("ItemGroup");
            foreach (CondensedVertex projRef in Graph.AdjacentVertices(va))
            {
                if (projRef.ImutableExternalType)
                {
                    xproj.WriteStartElement("Reference");
                    string aRefShortName = "";

                    string aRefFQN = DetermineClassDeps.AssemblyNameofType(projRef.ContainedTypes[0]);
                    

                    if (aRefFQN.StartsWith("mscorlib"))
                        aRefFQN = "System,";

                    int idx = aRefFQN.IndexOf(",");
                    if (idx > 0)
                        aRefShortName = aRefFQN.Substring(0, idx);

                    if (aRefFQN.StartsWith("System"))
                    {
                        xproj.WriteAttributeString("Include", aRefShortName);
                    }
                    else
                    {
                        xproj.WriteAttributeString("Include", aRefFQN);
                        string[] exts = new string[2] { ".dll", ".exe" };
                        foreach (string ext in exts)
                        {
                            string hintPath = Path.Combine(Path.GetDirectoryName(AssemblyFileName), aRefShortName) + ext;
                            if (File.Exists(hintPath))
                            {
                                xproj.WriteElementString("SpecificVersion", false.ToString());
                                //todo - manage directories better
                                xproj.WriteElementString("HintPath", Path.Combine("..",hintPath));
                                break;
                            }    
                        }
                        
                    }
                    xproj.WriteEndElement();
                }
            }
            xproj.WriteEndElement();
        }

		private void WriteProjectImport(XmlTextWriter xproj, string project)
		{
			xproj.WriteStartElement("Import");
			xproj.WriteAttributeString("Project", project);
			xproj.WriteEndElement();
		}
		public string GetAssemblyName(CondensedVertex vassem)
		{
			int count = 0;
			string baseName = NameHint;
			if (vassem.NameSpaces.Count == 1)
				baseName = TypeVertex.GetNamespace(vassem);

			nameHintCountMap.TryGetValue(baseName,out count);
			nameHintCountMap[baseName] = count+1;

			return String.Format("{0}.{1}", baseName, count);
			
		}
	

		List<string> GetFilesForType(string typeName)
		{
                                        
            string query = String.Format(@"/Types/Type[@Name=""{0}""]/File/@Name",typeName);
			XPathNodeIterator res = pdbNav.Select(query);
			List<string> files = new List<string>();
			while(res.MoveNext())
				files.Add(res.Current.Value);

            if (files.Count==0) //have an interface
            {
                int idx =typeName.LastIndexOf('.');
                if (idx>0)
                    typeName = typeName.Substring(idx+1);
                string[] foundfiles =Directory.GetFiles(SourceDirectory, typeName + ".cs", SearchOption.AllDirectories);
                files.AddRange(foundfiles);

            }

			return files;
		}

	}
}
