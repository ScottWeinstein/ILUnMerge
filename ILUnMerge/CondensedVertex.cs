using System;
using QuickGraph;
using System.Collections.Generic;
using Mono.Cecil;
using QuickGraph.Concepts.Collections;

namespace ACATool
{
	public class CondensedVertex : Vertex
	{

		public CondensedVertex(int id) : base(id) { }

		#region Basic Props

		private bool _imutableExternalType;
		public bool ImutableExternalType
		{
			get
			{
				return _imutableExternalType;
			}
			set
			{
				_imutableExternalType = value;
			}
		}


		private string _assemblyName;
		public string AssemblyName
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

		private Guid _assemblyGUID;
		public Guid AssemblyGUID
		{
			get
			{
				return _assemblyGUID;
			}
			set
			{
				_assemblyGUID = value;
			}
		}

		private string _projectFile;
		public string ProjectFile
		{
			get
			{
				return _projectFile;
			}
			set
			{
				_projectFile = value;
			}
		}

		private List<TypeReference> _ContainedTypes = new List<TypeReference>();
		public List<TypeReference> ContainedTypes
		{
			get { return _ContainedTypes; }
		}

		Dictionary<String, int> _NameSpaces = new Dictionary<string, int>();

		public Dictionary<String, int> NameSpaces
		{
			get { return _NameSpaces; }
		}

		private bool _IsSCC;
		public bool IsSCC
		{
			get
			{
				return _IsSCC;
			}
			set
			{
				_IsSCC = value;
			}
		}
		#endregion

		public string Name
		{
			get
			{
				if (NameSpaces.Count > 1 || ContainedTypes.Count > 1)
				{
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					foreach (KeyValuePair<String, int> kvp in NameSpaces)
					{
						sb.Append(kvp.Key);
						sb.Append("=");
						sb.Append(kvp.Value);
					}
					return sb.ToString();
				}
				return ContainedTypes[0].FullName;
			}
		}

		public void Condense()
		{
			NameSpaces.Clear();
			foreach (TypeReference tref in ContainedTypes)
			{
				string nmspace = TypeVertex.GetNamespace(tref);

				if (this.NameSpaces.ContainsKey(nmspace))
				{
					this.NameSpaces[nmspace]++;
				}
				else
				{
					this.NameSpaces[nmspace] = 1;
				}

			}
		}


		internal void Condense(IVertexCollection iVertexCollection)
		{
			foreach (TypeVertex v in iVertexCollection)
			{
				if (!this.ContainedTypes.Contains(v.TypeRef))
				{
					this.ContainedTypes.Add(v.TypeRef);
				}
				string nmspace = TypeVertex.GetNamespace(v.TypeRef);

				if (this.NameSpaces.ContainsKey(nmspace))
				{
					this.NameSpaces[nmspace]++;
				}
				else
				{
					this.NameSpaces[nmspace] = 1;
				}
			}

		}
	}
}
