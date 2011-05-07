using System;
using System.Collections.Generic;
using Mono.Cecil;
using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.Search;
using QuickGraph.Concepts;
using QuickGraph.Providers;
using QuickGraph.Representations;

namespace ACATool
{
	public class TypeDependencyGraph : AdjacencyGraph
	{

		Dictionary<string, TypeVertex> classMap = new Dictionary<string, TypeVertex>();

		#region Props
		private bool _allowParallel;
		public bool AllowParallel
		{
			get
			{
				return _allowParallel;
			}
			set
			{
				_allowParallel = value;
			}
		}
		#endregion

		#region ctors
		/// <summary>
		/// Initializes a new instance of the TypeDependencyGraph class.
		/// </summary>
		/// <param name="classMap"></param>
		public TypeDependencyGraph() : base(new TypeVertexProvider(), new NamedEdgeProvider(), false) { }
		public TypeDependencyGraph(bool allowParallel)
			: base(new TypeVertexProvider(), new NamedEdgeProvider(), allowParallel)
		{
			AllowParallel = allowParallel;
		}
		#endregion

		public void LoadClassDependencies(DetermineClassDeps dcd,bool treatExternalTypesAsSingleImutable)
		{
			foreach (TypeDefinition tdef in dcd.ClassDependencies.Keys)
			{
				string className = tdef.FullName;
				foreach (UsedClass uc in dcd.ClassDependencies[tdef])
				{
					string refclassName = uc.Type.FullName;
					if (!String.IsNullOrEmpty(_examininationNSN))
					{
						if (!
							(
							(tdef.FullName.StartsWith(_examininationNSP) || tdef.FullName.StartsWith(_examininationNSN)) &&
							(uc.Type.FullName.StartsWith(_examininationNSN) || uc.Type.FullName.StartsWith(_examininationNSP))
							))
							continue;
					}
					
					TypeVertex usingVertex = GetVertex(tdef, className,dcd);
					TypeVertex refVertex = GetVertex(uc.Type, refclassName,dcd);
					
					if (AllowParallel || !this.ContainsEdge(usingVertex, refVertex))
					{
						NamedEdge edge = (NamedEdge)this.AddEdge(usingVertex, refVertex);
						edge.Name = uc.Use.ToString();
					}
				}
			}
		}

		private TypeVertex GetVertex(TypeReference tref, string className,DetermineClassDeps dcd)
		{
			TypeVertex V;
			if (dcd.IsExternalType(tref))
				className = DetermineClassDeps.AssemblyNameofType(tref);
			if (classMap.ContainsKey(className))
			{
				V = classMap[className];
			}
			else
			{
				V = (TypeVertex)this.AddVertex();
				V.Name = className;
				V.TypeRef = tref;
				if (dcd.IsExternalType(tref))
					V.ImutableExternalType = true;
				classMap[className] = V;
			}
			return V;
		}

		public CondensedTypeGraph CondenseGraph()
		{
			CondensationGraphAlgorithm cgalgo = new CondensationGraphAlgorithm(this);
			cgalgo.InitCondensationGraphVertex += new CondensationGraphVertexEventHandler(CGVertexHandler);
			CondensedTypeGraph cg = new CondensedTypeGraph();
			cgalgo.Create(cg);
			return cg;
		}



        public TypeDependencyGraph TypeDepAnalysis(List<TypeReference> typesToExamine)
        {
            TypeDependencyGraph tdg = new TypeDependencyGraph();

            StrongComponentsAlgorithm scgo = new StrongComponentsAlgorithm(this);
            scgo.Compute();
            Dictionary<int, List<IVertex>> sccMap = new Dictionary<int, List<IVertex>>();
            foreach (System.Collections.DictionaryEntry de in scgo.Components)
            {
                IVertex v = (IVertex)de.Key;
                int scc_id = (int)de.Value;
                if (!sccMap.ContainsKey(scc_id))
                {
                    sccMap[scc_id] = new List<IVertex>();
                }
                sccMap[scc_id].Add(v);
            }

            Stack<List<TypeVertex>> PendingEdges = new Stack<List<TypeVertex>>();
            List<TypeVertex> VertexToRemove = new List<TypeVertex>();
            VertexEventHandler discV = delegate(Object s, VertexEventArgs e)
            {
                PendingEdges.Push(new List<TypeVertex>());
                TypeVertex tv = (TypeVertex)e.Vertex;
                if (scgo.Components.Contains(tv) && sccMap[scgo.Components[tv]].Count > 1)
                {
                    tv.SCCNum = scgo.Components[tv];
                    tdg.AddVertex(tv);
                }
                else if (typesToExamine.Contains(tv.TypeRef))
                {
                    tdg.AddVertex(tv);
                }
                else
                {
                    VertexToRemove.Add(tv);
                }
            };

            VertexEventHandler finishV = delegate(Object s, VertexEventArgs e)
            {
                TypeVertex tv = (TypeVertex)e.Vertex;
                List<TypeVertex> pes = PendingEdges.Pop();
                if (tdg.ContainsVertex(tv))
                {
                    foreach (TypeVertex target in pes)
                    {
                        if (tdg.ContainsVertex(target) && !tdg.ContainsEdge(tv, target))
                            tdg.AddEdge(tv, target);
                    }
                }

            };

            EdgeEventHandler treeedge = delegate(Object o, EdgeEventArgs e)
            {
                PendingEdges.Peek().Add((TypeVertex)e.Edge.Target);
            };


            DepthFirstSearchAlgorithm dfs = new DepthFirstSearchAlgorithm(this);
            dfs.DiscoverVertex += discV;
            dfs.FinishVertex += finishV;
            dfs.TreeEdge += treeedge;
            dfs.Compute();


            foreach (TypeVertex v in VertexToRemove)
            {
                this.RemoveVertex(v);
            }

            return tdg;

        }


		public CondensedTypeGraph CompressNamespaces()
		{
			CompressTypesByNamespaceAlg cgalgo = new CompressTypesByNamespaceAlg(this);
			CondensedTypeGraph cg = new CondensedTypeGraph();
			cgalgo.Create(cg);
			return cg;
		}


		public void CGVertexHandler(object sender, CondensationGraphVertexEventArgs arg)
		{
			CondensedVertex cgv = arg.CondensationGraphVertex as CondensedVertex;
			cgv.IsSCC = true;
			foreach(TypeVertex tv in arg.StronglyConnectedVertices)
				if (tv.ImutableExternalType)
				{
					cgv.ImutableExternalType = true;
				}

			cgv.Condense(arg.StronglyConnectedVertices);



		}




		private string _examininationNSP,_examininationNSN;
		internal void ExamineNamespace(string p,string n)
		{
			_examininationNSP = p;
			_examininationNSN = n;
		}
	}//class
}//ns



