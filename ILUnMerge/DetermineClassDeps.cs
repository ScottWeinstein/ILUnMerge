using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace ACATool
{
	public class DetermineClassDeps
	{
		#region Props
		private string _AssemblyFile;
		public string AssemblyFile
		{
			get
			{
				return _AssemblyFile;
			}
			set
			{
				_AssemblyFile = value;
			}
		}



		private List<TypeDefinition> _TypeList = new List<TypeDefinition>();
		public List<TypeDefinition> TypeList
		{
			get
			{
				return _TypeList;
			}
		}
		Dictionary<TypeDefinition, List<UsedClass>> classDeps = new Dictionary<TypeDefinition, List<UsedClass>>();

		internal Dictionary<TypeDefinition, List<UsedClass>> ClassDependencies
		{
			get
			{
				return classDeps;
			}
		}

		private bool _IgnoreOutsideRefs = false;
		public bool IgnoreOutsideRefs
		{
			get
			{
				return _IgnoreOutsideRefs;
			}
			set
			{
				_IgnoreOutsideRefs = value;
			}
		}

		#endregion

		private List<string> SkipTypesInAssembies;
		AssemblyDefinition assemblyDef;
		private Dictionary<string, int> ReffedAssems;

		public DetermineClassDeps()
		{
			SkipTypesInAssembies = new List<string>();
			ReffedAssems = new Dictionary<string, int>();
		}

        public void Execute()
        {
            GetAllTypes();
            foreach (TypeDefinition itd in TypeList)
            {
                classDeps.Add(itd, FindClassDeps(itd));
            }
        }


		public void GetAllTypes()
		{
			assemblyDef = AssemblyFactory.GetAssembly(AssemblyFile);
			foreach (ModuleDefinition module in assemblyDef.Modules)
			{
				TypeList.AddRange(GetAllTypes(module.Types));
			}
		}

        private bool IsTypeCompilerGenerated(TypeDefinition itd)
        {
            foreach (CustomAttribute custAttrOfType in itd.CustomAttributes)
            {
                if (custAttrOfType.Constructor.DeclaringType.FullName == "System.Runtime.CompilerServices.CompilerGeneratedAttribute")
                    return true;
            }
            return false;
        }

        private List<TypeDefinition> GetAllTypes(IEnumerable types)
		{
			List<TypeDefinition> list = new List<TypeDefinition>();

			foreach (TypeDefinition itd in types)
			{
                if (IsTypeCompilerGenerated(itd))
                    continue;

                if (!list.Contains(itd))
					list.Add(itd);
				foreach (TypeDefinition tdef in GetAllTypes(itd.NestedTypes))
				{
					if (!list.Contains(tdef))
						list.Add(tdef);
				}
			}
			return list;
		}

		public List<UsedClass> FindClassDeps(TypeDefinition itd)
		{
			List<UsedClass> usedT = new List<UsedClass>();
			if (itd == null) return usedT;

			AddTypeToList(itd.BaseType, ClassUse.Inherits, usedT, false);

			foreach (TypeReference itr in itd.Interfaces)
			{
				AddTypeToList(itr, ClassUse.Implements, usedT);
			}

			AddUsedTypesFromFields(itd.Fields, usedT);
			AddUsedTypesFromAttributes(itd.CustomAttributes, usedT);
			AddUsedTypesFromMethods(itd.Methods, usedT);

			return usedT;
		}

		private void AddUsedTypesFromMethods(MethodDefinitionCollection Methods, List<UsedClass> usedT)
		{
			foreach (MethodDefinition method in Methods)
			{
				AddUsedTypesFromParameters(method.Parameters, usedT);
				AddTypeToList(method.ReturnType.ReturnType, ClassUse.Returns, usedT);
				AddUsedTypesFromAttributes(method.CustomAttributes, usedT);
				AddTypesFromMethodBody(method.Body as IMethodBody, usedT);
			}

		}

		private void AddTypesFromMethodBody(IMethodBody body, List<UsedClass> usedT)
		{
			if (body == null) return;

			foreach (VariableDefinition var in body.Variables)
			{
                //.Variable
				 AddTypeToList(var.VariableType , ClassUse.Contains, usedT);
			}

			foreach (Instruction inst in body.Instructions)
			{
				switch (inst.OpCode.Name)
				{
					case "call":
					case "callvirt":
					case "calli":
					case "newobj":
						MethodReference mr = inst.Operand as MethodReference;
						AddTypeToList(mr.DeclaringType, ClassUse.Calls, usedT);
						break;
				}
			}
		}

		private void AddUsedTypesFromParameters(ParameterDefinitionCollection Parameters, List<UsedClass> usedT)
		{
			foreach (ParameterDefinition param in Parameters)
			{
				AddTypeToList(param.ParameterType, ClassUse.Parameter, usedT);
			}
		}

		private void AddTypeToList(TypeReference tref, ClassUse use, List<UsedClass> usedT)
		{
			AddTypeToList(tref, use, usedT, true);
		}

		private void AddTypeToList(TypeReference tref, ClassUse use, List<UsedClass> usedT, bool getAdditionTypeInfo)
		{
			if (tref != null)
			{
				UsedClass uc = new UsedClass(tref, use);

				if (!SkipType(tref) && !usedT.Contains(uc))
				{
					usedT.Add(uc);
				}
				if (getAdditionTypeInfo)
				{
					AddUsedTypesFromAttributes(tref.CustomAttributes, usedT);
					GenericInstanceType git = tref as GenericInstanceType;
					AddUsedTypesFromGenericArgs(git, usedT);
				}
			}
		}

		private void AddUsedTypesFromGenericArgs(IGenericInstance git, List<UsedClass> usedT)
		{
			if (git == null) return;
			foreach (TypeReference tref in git.GenericArguments)
			{
				AddTypeToList(tref, ClassUse.Parameter, usedT);
			}
		}

		private void AddUsedTypesFromAttributes(CustomAttributeCollection attrs, List<UsedClass> usedT)
		{
			foreach (CustomAttribute attr in attrs)
			{
				AddTypeToList(attr.Constructor.DeclaringType, ClassUse.Attribute, usedT);
			}
		}

		private void AddUsedTypesFromFields(FieldDefinitionCollection fields, List<UsedClass> usedT)
		{
			foreach (FieldDefinition ifd in fields)
			{
				AddTypeToList(ifd.FieldType, ClassUse.Contains, usedT);
			}
		}
		
		public bool SkipType(string owner)
		{
			if (IgnoreOutsideRefs)
				return (assemblyDef.Name.FullName != owner);

			if (!ReffedAssems.ContainsKey(owner))
			{
				Debug.WriteLine(owner);
				ReffedAssems.Add(owner, 0);
			}
			return SkipTypesInAssembies.Contains(owner);
		}

		public bool IsExternalType(TypeReference tref)
		{
			string asmName = AssemblyNameofType(tref);
			return (asmName != assemblyDef.Name.FullName);
		}

		public bool SkipType(TypeReference tref)
		{
			string lOwner = AssemblyNameofType(tref);
			return SkipType(lOwner);
		}

		internal static string AssemblyNameofType(TypeReference tref)
		{
			string lOwner;
			Mono.Cecil.IMetadataScope imds = (IMetadataScope)tref.Scope;
			AssemblyNameReference asr = imds as AssemblyNameReference;
			if (asr == null)
			{
				ModuleDefinition md = imds as ModuleDefinition;
				lOwner = md.Assembly.Name.FullName;
			}
			else
			{
				lOwner = asr.FullName;
			}
			return lOwner;
		}
		public bool SkipType(object owner)
		{
			return SkipType(owner.ToString());
		}

	}//class
}//ns
