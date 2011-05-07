using System;
using System.Collections.Generic;
using System.Diagnostics;
using Mono.Cecil;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Search;
using QuickGraph.Collections;
using QuickGraph.Concepts;
using QuickGraph.Predicates;
using QuickGraph.Providers;
using QuickGraph.Representations;

namespace ACATool
{
	public class CondensedTypeGraph : AdjacencyGraph
	{

		private StrongComponentsAlgorithm _sccCountalg;

		public CondensedTypeGraph()
			: base(new CondensedVertexProvider(), new EdgeProvider(), false)
		{
			_sccCountalg = new StrongComponentsAlgorithm(this);
		}
		public CondensedTypeGraph(bool allowParallel)
			: base(new CondensedVertexProvider(), new EdgeProvider(), allowParallel)
		{
			_sccCountalg = new StrongComponentsAlgorithm(this);
		}

		

		Dictionary<string, List<CondensedVertex>> NamespaceAssignmentMap = new  Dictionary<string,List<CondensedVertex>>();
		
        public void CompactNS(bool agressive)
		{
			List<CondensedVertex> allvertex = new List<CondensedVertex>();
			foreach (CondensedVertex v in this.Vertices)
				allvertex.Add(v);

			foreach (CondensedVertex v in allvertex)
			{
				if (v.NameSpaces.Count > 1 || v.ImutableExternalType)
				{
					continue;
					//throw new NotImplementedException();
				}

				int numVertex = this.VerticesCount;
				Debug.Assert(numVertex == SCCCount);

				string ns = TypeVertex.GetNamespace(v);
				
				List<CondensedVertex> candidateDestVertexs;
				if (!NamespaceAssignmentMap.TryGetValue(ns, out candidateDestVertexs))
				{
					candidateDestVertexs =new List<CondensedVertex>();
					NamespaceAssignmentMap[ns] = candidateDestVertexs;
				}

				bool vertexReasigned = false;
				
				foreach(CondensedVertex destV in candidateDestVertexs)
				{
					vertexReasigned = TryMergeVertex(v, destV, ref numVertex);
					if (vertexReasigned) break;
				}

				if (!vertexReasigned && agressive)
				{
					foreach (List<CondensedVertex> listC in NamespaceAssignmentMap.Values)
					{
						if (listC != candidateDestVertexs && !vertexReasigned)
							foreach (CondensedVertex destV in listC)
							{
								vertexReasigned = TryMergeVertex(v, destV, ref numVertex);
								if (vertexReasigned) break;
							}
					}
				}

				if (!vertexReasigned)
				{
					numVertex++;
					CondensedVertex destV= this.AddVertex() as CondensedVertex;
					NamespaceAssignmentMap[ns].Add(destV);
					vertexReasigned = TryMergeVertex(v, destV, ref numVertex);
					Debug.Assert(vertexReasigned);
				}
			}
			Debug.Assert(this.VerticesCount == SCCCount);
			Debug.WriteLine(VerticesCount.ToString());
		}

		private bool TryMergeVertex(CondensedVertex v, CondensedVertex destV, ref int numVertex)
		{
			List<KeyValuePair<IVertex, IVertex>> oldEdges = SaveExistingEdges(v);
			this.RemoveVertex(v);
			numVertex--;
			List<IEdge> pendingEdges = MergeOldEdges(v, destV, oldEdges);
			if (numVertex > SCCCount)
			{
				UndoMerge(v, destV, oldEdges, pendingEdges);
				numVertex++;
				Debug.Assert(numVertex == this.VerticesCount);
				Debug.Assert(numVertex == SCCCount);
				return false;
			}
			else
			{
				foreach (TypeReference tref in v.ContainedTypes)
				{
					destV.ContainedTypes.Add(tref);
				}
				destV.Condense();
				return true;
			}
		}
		private void UndoMerge(CondensedVertex v, CondensedVertex destV, List<KeyValuePair<IVertex, IVertex>> oldEdges, List<IEdge> pendingEdges)
		{
			foreach (IEdge e in pendingEdges)
				this.RemoveEdge(e);
			this.AddVertex(v);
			foreach (KeyValuePair<IVertex, IVertex> e in oldEdges)
			{
				this.AddEdge(e.Key, e.Value);
			}
		}

		
		private List<IEdge> MergeOldEdges(CondensedVertex v, CondensedVertex destV,
			List<KeyValuePair<IVertex, IVertex>> oldEdges)
		{
			List<IEdge> pendingEdges = new List<IEdge>();
			foreach (KeyValuePair<IVertex, IVertex> kvp in oldEdges)
			{
				IVertex srcV, targetV, nsrcV, ntargetV;
				nsrcV = srcV = kvp.Key;
				ntargetV = targetV = kvp.Value;

				if (srcV == v)
					nsrcV = destV;

				if (targetV == v)
					ntargetV = destV;

				if (srcV == destV)
					nsrcV = destV;

				if (targetV == destV)
					ntargetV = destV;

				if (!this.ContainsEdge(nsrcV, ntargetV) && (nsrcV != ntargetV))
				{
					pendingEdges.Add(this.AddEdge(nsrcV, ntargetV));
				}
			}
			return pendingEdges;
		}

		public int SCCCount
		{
			get
			{
				return _sccCountalg.Compute();
			}
		}


		private List<KeyValuePair<IVertex, IVertex>> SaveExistingEdges(CondensedVertex v)
		{

			List<KeyValuePair<IVertex, IVertex>> edgeTbl = new List<KeyValuePair<IVertex, IVertex>>();
			//				Dictionary<IVertex, IVertex> edgeTbl = new Dictionary<IVertex,IVertex>();

			EdgeCollection outboundEdges = this.OutEdges(v);
			foreach (IEdge e in outboundEdges)
			{
				edgeTbl.Add(new KeyValuePair<IVertex, IVertex>(e.Source, e.Target));
				//CondensedVertex srcV = (CondensedVertex)e.Source;
				//CondensedVertex targetV = (CondensedVertex)e.Target;
				//Trace.WriteLine("E: " + srcV.Name + " -> " + targetV.Name);
			}

			FilteredEdgeEnumerable inboundEdges = this.SelectEdges(new IsInEdgePredicate(v));

			//Debug.WriteLine("inboundEdges");
			foreach (IEdge e in inboundEdges)
			{
				edgeTbl.Add(new KeyValuePair<IVertex, IVertex>(e.Source, e.Target));
				//CondensedVertex srcV = (CondensedVertex)e.Source;
				//CondensedVertex targetV = (CondensedVertex)e.Target;
				//Trace.WriteLine("E: " + srcV.Name + " -> " + targetV.Name);
			}
			return edgeTbl;
		}

	}//class
}
