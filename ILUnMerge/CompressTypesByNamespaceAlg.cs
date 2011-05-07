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
	internal class CompressTypesByNamespaceAlg : IAlgorithm
	{
		private IVertexListGraph visitedGraph;
		CondensedTypeGraph destcg;
		DepthFirstSearchAlgorithm dfs;
		
		public CompressTypesByNamespaceAlg(TypeDependencyGraph inputGraph) 
		{
			this.visitedGraph = inputGraph;

			dfs = new DepthFirstSearchAlgorithm(inputGraph);
			dfs.FinishVertex += new VertexEventHandler(dfs_FinishVertex);
			dfs.DiscoverVertex += new VertexEventHandler(dfs_DiscoverVertex);
			dfs.TreeEdge += new EdgeEventHandler(dfs_TreeEdge);
		}

		
		Dictionary<String, List<CondensedVertex>> NamespaceVertexMap = new Dictionary<string, List<CondensedVertex>>();
		Dictionary<IVertex, IVertex> VertexReassignmentMap = new Dictionary<IVertex, IVertex>();
		Stack<List<TypeVertex>> PendingEdges = new Stack<List<TypeVertex>>();

		void dfs_DiscoverVertex(object sender, VertexEventArgs e)
		{
			TypeVertex v = (TypeVertex)e.Vertex;
			Trace.WriteLine("S: " + v.Name);
			Trace.Indent();
			PendingEdges.Push(new List<TypeVertex>());


			if (!destcg.ContainsVertex(v))
			{
				CondensedVertex nv;

				TypeReference tref = v.TypeRef;

				string trefNamespace = v.Namespace;

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
				nv.ContainedTypes.Add(tref);
				VertexReassignmentMap[v] = nv;
				return;

			}
		}

		void dfs_TreeEdge(object sender, EdgeEventArgs e) 
		{
			TypeVertex srcV = (TypeVertex)e.Edge.Source;
			TypeVertex targetV = (TypeVertex)e.Edge.Target;
			Trace.WriteLine("E: " + srcV.Name + " -> " + targetV.Name);
			PendingEdges.Peek().Add(targetV);
		}

		void dfs_FinishVertex(object sender, VertexEventArgs e) 
		{
			TypeVertex v = (TypeVertex)e.Vertex;

			List<TypeVertex> pes = PendingEdges.Pop();

			foreach (TypeVertex target in pes)
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

		#region IAlgorithm Members

		public IVertexListGraph VisitedGraph {
			get {
				return this.visitedGraph;
			}
		}

		object IAlgorithm.VisitedGraph {
			get { return VisitedGraph; }
		}

		#endregion
		public void Create(CondensedTypeGraph cg) 
		{
			if (cg == null) throw new ArgumentNullException("cg");
			destcg = cg;
			dfs.Compute();
		}

	}
}
