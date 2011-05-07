using System;
using QuickGraph;
using Mono.Cecil;

namespace ACATool
{

	internal class TypeVertex : NamedVertex
	{
		public TypeVertex(int id)
			: base(id)
		{
		}

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


		private int _sCCNum = -1;
		public int SCCNum
		{
			get
			{
				return _sCCNum;
			}
			set
			{
				_sCCNum = value;
			}
		}

		private TypeReference _TypeRef;
		public TypeReference TypeRef
		{
			get
			{
				return _TypeRef;
			}
			set
			{
				_TypeRef = value;
			}
		}



		public string Namespace
		{
			get
			{
				return GetNamespace(TypeRef);
			}
		}


		public static string GetNamespace(CondensedVertex v)
		{
			if (v.NameSpaces.Count > 1)
			{
				throw new ArgumentOutOfRangeException("Too many namespaces");
			}
			return GetNamespace(v.ContainedTypes[0]);
		}

		public static string GetNamespace(TypeReference typeReference)
		{
			if (String.IsNullOrEmpty(typeReference.Namespace))
			{
				int idx = typeReference.FullName.LastIndexOf(".");
				if (idx < 0)
				{
					idx = typeReference.FullName.LastIndexOf("/");
				}
				if (idx < 0)
				{
					return "<EmptyNamespace>";
				}

				return typeReference.FullName.Substring(0, idx);
			}
			return typeReference.Namespace;
		}


	}//class
}
