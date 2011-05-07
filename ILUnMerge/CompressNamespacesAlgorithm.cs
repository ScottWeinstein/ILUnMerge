using System;
using System.Collections.Generic;
using System.Diagnostics;
using Mono.Cecil;
using QuickGraph.Algorithms.Search;
using QuickGraph.Concepts;
using QuickGraph.Concepts.Algorithms;
using QuickGraph.Concepts.Traversals;

namespace ACATool
{

	internal class CompressNamespacesAlgorithm : IAlgorithm
	{
		private IVertexListGraph visitedGraph;
		DepthFirstSearchAlgorithm dfs;

		//private VertexIntDictionary components;

		///// <summary>
		/// Initializes a new instance of the CompressNamespacesAlgorithm class.
		/// </summary>
		/// <param name="inputGraph"></param>
		public CompressNamespacesAlgorithm(IVertexListGraph inputGraph)
		{
			this.visitedGraph = inputGraph;
			dfs = new DepthFirstSearchAlgorithm(inputGraph);
			dfs.FinishVertex += new VertexEventHandler(dfs_FinishVertex);
			dfs.DiscoverVertex += new VertexEventHandler(dfs_DiscoverVertex);
			dfs.TreeEdge += new EdgeEventHandler(dfs_TreeEdge);
		}


		void dfs_TreeEdge(object sender, EdgeEventArgs e)
		{
			CondensedVertex srcV = (CondensedVertex)e.Edge.Source;
			CondensedVertex targetV = (CondensedVertex)e.Edge.Target;
			Trace.WriteLine("E: " + srcV.Name + " -> " + targetV.Name);
			PendingEdges.Peek().Add(targetV);
		}

		void dfs_FinishVertex(object sender, VertexEventArgs e)
		{
			CondensedVertex v = (CondensedVertex)e.Vertex;

			List<CondensedVertex> pes = PendingEdges.Pop();

			foreach (CondensedVertex target in pes)
			{
				IVertex srcv = VertexReassignmentMap[v];
				IVertex targetv = VertexReassignmentMap[target];
				if (srcv != targetv && !destcg.ContainsEdge(srcv, targetv))
				{
					destcg.AddEdge(srcv, targetv);
				}
			}

			Trace.Unindent();
			Trace.WriteLine("F: " + v.Name);
		}

		Dictionary<String, List<CondensedVertex>> NamespaceVertexMap = new Dictionary<string, List<CondensedVertex>>();
		Dictionary<IVertex, IVertex> VertexReassignmentMap = new Dictionary<IVertex, IVertex>();
		Stack<List<CondensedVertex>> PendingEdges = new Stack<List<CondensedVertex>>();

		void dfs_DiscoverVertex(object sender, VertexEventArgs e)
		{
			CondensedVertex v = (CondensedVertex)e.Vertex;
			Trace.WriteLine("S: " + v.Name);
			Trace.Indent();
			PendingEdges.Push(new List<CondensedVertex>());

			Debug.Assert(!destcg.ContainsVertex(v));
			
			CondensedVertex nv;

			if (v.NameSpaces.Count > 1) // scc with mult NS
			{
				destcg.AddVertex(v);
				VertexReassignmentMap[v] = v;
				return;
			}
			string trefNamespace = TypeVertex.GetNamespace(v);

			if (!NamespaceVertexMap.ContainsKey(trefNamespace))
			{
				nv = (CondensedVertex)destcg.AddVertex();
				nv.NameSpaces[trefNamespace] = 0;
				NamespaceVertexMap[trefNamespace] = new List<CondensedVertex>();
				NamespaceVertexMap[trefNamespace].Add(nv);
			}
			else
			{
				nv = NamespaceVertexMap[trefNamespace][0];
			}

			nv.NameSpaces[trefNamespace]++;
			foreach (TypeReference tref in v.ContainedTypes)
			{
				nv.ContainedTypes.Add(tref);
			}
			VertexReassignmentMap[v] = nv;
			return;
		}

		#region IAlgorithm Members

		public IVertexListGraph VisitedGraph
		{
			get
			{
				return this.visitedGraph;
			}
		}

		object IAlgorithm.VisitedGraph
		{
			get { return VisitedGraph; }
		}

		#endregion



		CondensedTypeGraph destcg;
		


	}//class
}
