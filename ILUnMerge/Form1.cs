using System;
using System.Collections.Generic;
using QuickGraph.Algorithms.Graphviz;
using System.Diagnostics;
using NGraphviz.Helpers;
using QuickGraph;
using Microsoft.Build.Utilities;

namespace ACATool {


	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		DetermineClassDeps dcd = new DetermineClassDeps();


		private string RenderCondGraph(CondensedTypeGraph g, GraphvizImageType imageType, string outputFile)
		{
			string output;
			GraphvizAlgorithm renderer;
			
			renderer = new GraphvizAlgorithm( g);
			renderer.ImageType = imageType;
			renderer.FormatCluster += new FormatClusterEventHandler(renderer_FormatCluster);
			renderer.GraphFormat.IsCentered = true;
			renderer.GraphFormat.RankDirection = GraphvizRankDirection.TB;
			renderer.FormatVertex += new FormatVertexEventHandler(FormatCCCVertex);
			renderer.FormatEdge += new FormatEdgeEventHandler(graphvis_edgeFormatterNN);
			output = renderer.Write(outputFile);
			return output;
		}

		void renderer_FormatCluster(object sender, FormatClusterEventArgs e)
		{
			
			throw new Exception("The method or operation is not implemented.");
		}
			GraphvizImageType imageType = GraphvizImageType.Png;
		
		private void Form1_Load(object sender, EventArgs e)
		{

			
			string output;

			dcd.AssemblyFile = @"..\..\..\MBUnitTests\bin\Debug\MBUnitTests.exe";
			dcd.IgnoreOutsideRefs = false;
			dcd.Execute();
			TypeDependencyGraph tdg = new TypeDependencyGraph(false);
			tdg.LoadClassDependencies(dcd, true);
            output = RenderAnalysisGraph(tdg, imageType, "tdg");

//			output = RenderAnalysisGraph(tdg, imageType, "NamespaceOutboundG");


			////CondensedTypeGraph cond_CompNS_CondG = tdg.
			//TypeDependencyGraph Analysistdg;
			//Analysistdg = tdg.TypeDepAnalysis(new List<TypeReference>());
			//RenderAnalysisGraph(Analysistdg, imageType, "Analysistdg");
			//return;
			////output = RenderCondGraph(cond_CompNS_CondG, imageType, "analysistNew");

			//return;
			CondensedTypeGraph condG = tdg.CondenseGraph();
            output = RenderCondGraph(condG, imageType, "condensedGraph");
			condG.CompactNS(true);
            output = RenderCondGraph(condG, imageType, "compactNS");

			foreach (CondensedVertex v in condG.Vertices)
			{
				Debug.WriteLine(v.ContainedTypes.Count.ToString());
			}

			RenderProjectFiles rpf = new RenderProjectFiles();
			//rpf.PDBDataFile = @"..\..\..\MBUnitTests\bin\Debug\MBUnitTests.pdb.xml";
            GeneratePDBXml(rpf);
            rpf.Graph = condG;
			rpf.OutputDirectory = "Projects";
			rpf.NameHint = "mbuTests";
            rpf.Execute();


			




			
			//CondensedTypeGraph NScompressed = condG.CompressNamespaces();
			//CondensedTypeGraph NScompressedandCondensed = NScompressed.CondenseGraph();

			
			//List<TypeReference> analysisList = cond_CompNS_CondG.FindBigestAssembly().ContainedTypes;
//			Analysistdg =  tdg.TypeDepAnalysis(analysisList);
			

			


			//output = RenderAnalysisGraph(tdg, imageType, "analisisRemoved");

			
			//output = RenderCondGraph(NScompressedandCondensed, imageType, "NS2");
			//output = RenderCondGraph(condG, imageType, "Cond");
			return;



			//CondensedTypeGraph ccc = tdg.CompressGraph();
			//CondensedTypeGraph cccNS = ccc.CompressNamespaces();
			//= cccNS.CompressGraph();




			//Debug.WriteLine(ccc.VerticesCount.ToString());
			//Debug.WriteLine(tdg.VerticesCount.ToString());
			//Debug.WriteLine(ccc.EdgesCount.ToString());



			//pictureBox1.Load(output);

			
			////            return;
			//Debug.WriteLine("Render full graph");
			//return;
			//output = RenderFullGraph(tdg, imageType);
			//pictureBox3.Load(output);






		}



        private void GeneratePDBXml(RenderProjectFiles rpf)
        {
            ACATool.Tasks.WritePDBasXML pdbxmlWritterTask = new ACATool.Tasks.WritePDBasXML();
            pdbxmlWritterTask.AssemblyName = new TaskItem(@"..\..\..\MBUnitTests\bin\Debug\MBUnitTests.exe");
            if (pdbxmlWritterTask.Execute())
            {
                rpf.PDBDataFile = pdbxmlWritterTask.PDBAsXmlFile.ItemSpec;
            }
        }
        private void RenderProjectFiles(CondensedTypeGraph condG)
		{
			throw new Exception("The method or operation is not implemented.");
		}


		public void FormatCCCVertex(object sender, FormatVertexEventArgs args)
		{
			CondensedVertex o = (CondensedVertex)args.Vertex;
			args.VertexFormatter.Label = o.Name;
			
			if (o.IsSCC)
			{
				args.VertexFormatter.Group = "sdfsdf";
				args.VertexFormatter.FillColor = Color.AliceBlue;
				args.VertexFormatter.Style = GraphvizVertexStyle.Filled;
				args.VertexFormatter.Shape = NGraphviz.Helpers.GraphvizVertexShape.Box;
			}
			if (o.ImutableExternalType)
			{
				args.VertexFormatter.FillColor = Color.LightSalmon;
				args.VertexFormatter.Style = GraphvizVertexStyle.Filled;
				args.VertexFormatter.Shape = NGraphviz.Helpers.GraphvizVertexShape.MSquare;
			
			}
		}


		private string RenderAnalysisGraph(TypeDependencyGraph tdg, GraphvizImageType imageType,string fileName)
		{
			string output;
			GraphvizAlgorithm renderer;
			renderer = new GraphvizAlgorithm(tdg);
			renderer.ImageType = imageType;
			renderer.GraphFormat.RankDirection = GraphvizRankDirection.LR;
			Color[] colors = { 
				Color.Beige, 
				Color.Cornsilk, 
				Color.DimGray, 
				Color.Khaki,
				Color.PeachPuff,
				Color.Wheat,
				Color.Olive,
				Color.Moccasin,
				Color.LightCoral,
				Color.LightGoldenrodYellow,
				Color.LightGray,
				Color.LightGreen,
				Color.LightPink,
				Color.LightSalmon,
				Color.LightSeaGreen,
				Color.LightSkyBlue,
				Color.LightSlateGray,
				Color.LightSteelBlue,
				Color.LightYellow,
				Color.Lime,
				Color.MediumAquamarine,
				Color.MediumBlue,
				Color.MediumOrchid,
				Color.MediumPurple,
				Color.MediumSeaGreen,
				Color.MediumSlateBlue,
				Color.MediumSpringGreen,
				Color.MediumTurquoise,
				Color.MediumVioletRed,
				Color.MintCream,

			};
			int nextColorInd = 0;
			Dictionary<int,Color> colormap = new Dictionary<int,Color>();
			FormatVertexEventHandler fvertex = delegate(Object s, FormatVertexEventArgs args)
			{
				TypeVertex v = (TypeVertex)args.Vertex;
				args.VertexFormatter.Label = v.Name;
				args.VertexFormatter.Font = new Font(FontFamily.GenericSerif, 8);
				if (v.SCCNum>=0)
				{
					Color c;
					if (!colormap.TryGetValue(v.SCCNum,out c))
					{
						if (nextColorInd > colors.GetUpperBound(0)) nextColorInd = 0; 
						c = colors[nextColorInd++];
						colormap[v.SCCNum] = c;
					}
					args.VertexFormatter.FillColor = c;
					args.VertexFormatter.Style = GraphvizVertexStyle.Filled;
				}
			};

			FormatEdgeEventHandler Fedge = delegate(Object s, FormatEdgeEventArgs args)
				{
					args.EdgeFormatter.Head = new GraphvizEdgeExtremity(true);
					args.EdgeFormatter.HeadArrow = new GraphvizArrow(GraphvizArrowShape.Dot);
				};

			renderer.FormatVertex += fvertex;

			renderer.FormatEdge += Fedge;
			output = renderer.Write(fileName);
			return output;
		}


		void graphvis_edgeFormatter(object sender, FormatEdgeEventArgs e)
		{
			e.EdgeFormatter.Label.Value = ((NamedEdge)e.Edge).Name;
			e.EdgeFormatter.Font = new Font(FontFamily.GenericSerif, 6);
			e.EdgeFormatter.Head = new GraphvizEdgeExtremity(true);
			//e.EdgeFormatter.Weight = ((TypeVertex)e.Edge.Target).IncomingLinks;
			//                Arrow.Shape = NGraphviz.Helpers.GraphvizArrowShape.Normal;

		}
		void graphvis_edgeFormatterNN(object sender, FormatEdgeEventArgs e)
		{
			e.EdgeFormatter.Head = new GraphvizEdgeExtremity(true);
			e.EdgeFormatter.Weight = ((CondensedVertex)e.Edge.Target).ContainedTypes.Count;
			//                Arrow.Shape = NGraphviz.Helpers.GraphvizArrowShape.Normal;

		}
		void graphviz_FormatVertex(object sender, FormatVertexEventArgs e)
		{
			TypeVertex v = (TypeVertex)e.Vertex;
			e.VertexFormatter.Label = v.Name;
			e.VertexFormatter.Font = new Font(FontFamily.GenericSerif, 8);

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}




	}//class
}