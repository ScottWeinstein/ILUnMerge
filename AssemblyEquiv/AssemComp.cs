using System;
using System.Collections;
using IO = System.IO;
using Reflector.CodeModel;
using Reflector.CodeModel.Memory;
using System.Linq;
using System.Diagnostics;

namespace ACATool.Tasks
{
    internal class AssemComp
    {
        private IAssembly _assmB;

        private Action<string, string> _errorCollector; 
        private IAssembly _assmA;
        public bool AreEquivalent { get; private set; }
        public string Reason { get; private set; }
        public AssemComp(string fileSpecA, string fileSpecB)
        {
            _errorCollector = (a, b) => { Reason += a + b + "\n"; };
            if (AssemComp.CheckFileSize(fileSpecA,fileSpecB))
            {
                IServiceProvider serviceProvider = new Reflector.ApplicationManager(new FakeReflectorWindowManager());
                IServiceProvider serviceProvider2 = new Reflector.ApplicationManager(new FakeReflectorWindowManager());
                IAssemblyManager assemblyManager = (IAssemblyManager)serviceProvider.GetService(typeof(IAssemblyManager));
                IAssemblyManager assemblyManager2 = (IAssemblyManager)serviceProvider2.GetService(typeof(IAssemblyManager));
                _assmA = assemblyManager.LoadFile(fileSpecA);
                _assmB = assemblyManager2.LoadFile(fileSpecB);
                if (_assmA == _assmB)
                    throw new ArgumentException();
                AreEquivalent = Compare();
            }
            else
            {
                AreEquivalent = false;
                Reason = "FileSize";
            }
        }

        private bool Compare()
        {
            if (!CheckScalars())
            {
                return false;
            }

            if (!_assmA.Attributes.Compare(_assmB.Attributes, CheckCustomAttribute))
            {
                return false;
            }

            if (!_assmA.Resources.Compare(_assmB.Resources, CheckResource, _errorCollector))
            {
                return false;
            }

            if (!_assmA.Modules.Compare(_assmB.Modules,CheckModule,_errorCollector))
            {
                return false;
            }

            return true;
        }


        #region CheckDecl
        private bool CheckMethodDecl(IMethodDeclaration ometh, IMethodDeclaration nmeth)
        {
            if ((ometh == null && nmeth == null))
                return true;
            if ((ometh.Abstract != nmeth.Abstract) ||
                (ometh.CallingConvention != nmeth.CallingConvention) ||
                (ometh.ExplicitThis != nmeth.ExplicitThis) ||
                (ometh.Final != nmeth.Final) ||
                (ometh.HasThis != nmeth.HasThis) ||
                (ometh.HideBySignature != nmeth.HideBySignature) ||
                (ometh.Name != nmeth.Name) ||
                (ometh.NewSlot != nmeth.NewSlot) ||
                (ometh.RuntimeSpecialName != nmeth.RuntimeSpecialName) ||
                (ometh.SpecialName != nmeth.SpecialName) ||
                (ometh.Static != nmeth.Static) ||
                (ometh.Virtual != nmeth.Virtual) ||
                (ometh.Visibility != nmeth.Visibility) ||
                (ometh.DeclaringType.ToString() != nmeth.DeclaringType.ToString())
                )
            {
                return false;
            }


            if (
                (!ometh.Attributes.Compare(nmeth.Attributes, CheckCustomAttribute)) ||
                (!ometh.GenericArguments.Compare(nmeth.GenericArguments)) ||
                (!CompareIMethodReference(ometh.GenericMethod, nmeth.GenericMethod)) ||
                (!ometh.Overrides.Compare(nmeth.Overrides, CompareIMethodReference)) ||
                (!ometh.Parameters.Compare(nmeth.Parameters, CheckParameterDecl)) ||
                (!CheckBody(ometh, nmeth)) ||
                (!CheckMethodReturnType(ometh.ReturnType, nmeth.ReturnType)))
            {
                return false;
            }

            return true;
        }

        private bool CheckParameterDecl(IParameterDeclaration o, IParameterDeclaration n)
        {
            return CheckParameterDecl(o, n, _errorCollector);
        }

        private bool CheckParameterDecl(IParameterDeclaration o, IParameterDeclaration n, Action<string,string> errorHander)
        {
            if (!o.Attributes.Compare( n.Attributes,CheckCustomAttribute) ||
                //!CheckExp(o.DefaultValue, n.DefaultValue) ||
                o.Name != n.Name ||
                o.ParameterType.ToString() != n.ParameterType.ToString())
            {
                errorHander(o.Name, "Parameter decl");
                return false;
            }
            return true;
        }


        private static bool CheckVariableDecl(IVariableDeclaration o, IVariableDeclaration n)
        {
            if (o.Name != n.Name ||
                o.Pinned != n.Pinned ||
                o.VariableType.ToString() != n.VariableType.ToString()
                //||!CheckVariableDecl(o.Variable, n.Variable)
                )
            { return false; }
            return true;
        }

        private bool CheckPropertyDecl(IPropertyDeclaration o, IPropertyDeclaration n)
        {
            if (o.DeclaringType.ToString() != n.DeclaringType.ToString() ||
                !CheckExp(o.Initializer, n.Initializer) ||
                o.Name != n.Name ||
                o.PropertyType.ToString() != n.PropertyType.ToString() ||
                o.RuntimeSpecialName != n.RuntimeSpecialName)
            {
                return false;
            }

            if (!o.Attributes.Compare(n.Attributes, CheckCustomAttribute) ||
                !o.Parameters.Compare(n.Parameters,CheckParameterDecl))
            {
                return false;
            }

            if (
                !CompareIMethodReference(o.GetMethod, n.GetMethod) ||
                !CompareIMethodReference(o.SetMethod, n.SetMethod))
            {
                return false;
            }

            return true;
        }

        private bool CheckTypeDecl(ITypeDeclaration otype, ITypeDeclaration ntype)
        {
            if (
                (otype.Abstract != ntype.Abstract) ||
                (otype.Interface != ntype.Interface) ||
                (otype.Name != ntype.Name) ||
                (otype.Namespace != ntype.Namespace) ||
                (otype.RuntimeSpecialName != ntype.RuntimeSpecialName) ||
                (otype.Sealed != ntype.Sealed) ||
                (otype.SpecialName != ntype.SpecialName) ||
                (otype.Visibility != ntype.Visibility) ||
                (otype.Owner.ToString() != ntype.Owner.ToString())
                )
            {
                Reason = "Type decl props";
                return false;
            }
            if (!otype.Attributes.Compare(ntype.Attributes, CheckCustomAttribute))
                return false;

            if (!otype.BaseType.CompareITypeReference(ntype.BaseType))
                return false;

            if (otype.BeforeFieldInit != ntype.BeforeFieldInit)
                return false;

            if (!otype.Events.Compare( ntype.Events,CheckEventDecl))
                return false;

            if (!otype.Fields.Compare(ntype.Fields,CheckFieldDecl))
                return false;

            if (!otype.GenericArguments.Compare(ntype.GenericArguments))
                return false;

            if (!otype.GenericType.CompareITypeReference(ntype.GenericType))
                return false;

            if (!otype.Interfaces.Compare(ntype.Interfaces,ReflectorExtentionMethods.CompareITypeReference))
                return false;
            if (! otype.Methods.Compare(ntype.Methods,CheckMethodDecl) ||
                ! otype.NestedTypes.Compare(ntype.NestedTypes,CheckTypeDecl) ||
                ! otype.Properties.Compare(ntype.Properties, CheckPropertyDecl)
                )
            {
                return false;
            }

            return true;
        }

        private bool CheckEventDecl(IEventDeclaration o, IEventDeclaration n)
        {
            //TODO
            if (!o.Attributes.Compare(n.Attributes, CheckCustomAttribute))
                return false;
            return (o.DeclaringType.ToString() == n.DeclaringType.ToString() &&
                o.EventType.CompareITypeReference(n.EventType) &&
                o.Documentation == n.Documentation &&

                CompareIMethodReference(o.InvokeMethod, n.InvokeMethod) &&
                o.Name == n.Name &&
                CompareIMethodReference(o.RemoveMethod, n.RemoveMethod) &&
                o.RuntimeSpecialName == n.RuntimeSpecialName &&
                o.SpecialName == n.SpecialName


                );
//            return false;

            //     ComareIEventReference(o.GenericEvent, n.GenericEvent) &&
        }

        //private bool ComareIEventReference(IEventReference o, IEventReference n)
        //{
        //    if (o == null && n== null)
        //        return true;
        //    if (o == null || n== null)
        //        return false;
        //    return (o.DeclaringType.ToString() == n.DeclaringType.ToString() &&
        //        o.EventType.Compare(n.EventType) &&
        //        o.GenericEvent.
        //}
        private bool CheckFieldDecl(IFieldDeclaration o, IFieldDeclaration n)
        {
            if (!o.Attributes.Compare(n.Attributes, CheckCustomAttribute))
                return false;
            if (o.DeclaringType.ToString() != n.DeclaringType.ToString())
                return false;
            if (o.FieldType.ToString() != n.FieldType.ToString())
                return false;
            if (o.Initializer != null && n.Initializer != null)
            {
                if (o.Initializer.ToString() != n.Initializer.ToString())
                    return false;
            }
            if (o.Literal != n.Literal)
                return false;
            if (o.Name != n.Name)
                return false;
            if (o.ReadOnly != n.ReadOnly)
                return false;
            if (o.RuntimeSpecialName != n.RuntimeSpecialName)
                return false;
            if (o.SpecialName != n.SpecialName)
                return false;
            if (o.Static != n.Static)
                return false;
            if (o.Visibility != n.Visibility)
                return false;
            return true;
        }

        #endregion

        #region CheckRefs
        
        private bool CompareIMethodReference(IMethodReference o, IMethodReference n)
        {
            if (o == null && n == null)
                return true;

            if (
                (o.CallingConvention != n.CallingConvention) ||
                (o.ExplicitThis != n.ExplicitThis) ||
                (o.HasThis != n.HasThis) ||
                (o.Name != n.Name) ||
                (o.DeclaringType.ToString() != n.DeclaringType.ToString())
                )
            {
                return false;
            }

            if (
                (!(o.GenericArguments.Compare(n.GenericArguments)) ||
                (!CompareIMethodReference(o.GenericMethod, n.GenericMethod)) ||
                (!o.Parameters.Compare(n.Parameters,CheckParameterDecl)) ||
                (!CheckMethodReturnType(o.ReturnType, n.ReturnType))))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region CheckOthers
        private bool CheckModule(IModule omod, IModule nmod,Action<string,string> errCol)
        {

            if (!omod.AssemblyReferences.Compare(nmod.AssemblyReferences)) //CheckAssemblyReference
            {
                errCol("Mod assm refs", omod.Name);
                return false;
            }

            if (!omod.Attributes.Compare(nmod.Attributes, CheckCustomAttribute))
            {
                errCol("Mod attributes",omod.Name);
                return false;
            }

            if (!omod.ModuleReferences.Compare(nmod.ModuleReferences))
            {
                errCol("Mod refs", omod.Name);
                return false;
            }
            if (omod.Name != nmod.Name)
            {
                errCol("Mod Name", omod.Name);
                return false;
            }
            if (!omod.Types.Compare(nmod.Types, CheckTypeDecl))
            {
                return false;
            }

            if (!omod.UnmanagedResources.Compare(nmod.UnmanagedResources,CheckUnmanagedResource))
            {
                errCol("Mod unmanaged res", omod.Name);
                return false;
            }
            return true;
        }

        private bool CheckCustomAttribute(ICustomAttribute oattr, ICustomAttribute nattr)
        {
            if (nattr.ToString() != oattr.ToString())
            {
//                errorHandler(oattr.ToString(),"Attribute type");
                return false;
            }
            if (nattr.Constructor.Name != oattr.Constructor.Name)
            {
  //              errorHandler(oattr.ToString(), "Attribute constructor");
                return false;
            }

            if (!oattr.Arguments.Compare(nattr.Arguments))
            {
    //            errorHandler(oattr.ToString(), "Attribute ");
                
                return false;
            }
            return true;

        }


        private bool CheckBody(IMethodDeclaration ometh, IMethodDeclaration nmeth)
        {
            IMethodBody ob = ometh.Body as IMethodBody;
            IMethodBody nb = nmeth.Body as IMethodBody;
            if (ob == null && nb == null)
                return true;

            if (ob.InitializeLocalVariables != nb.InitializeLocalVariables ||
                ob.MaxStack != nb.MaxStack ||
                !ob.ExceptionHandlers.Compare(nb.ExceptionHandlers,CheckExceptionHandler) ||
                !ob.Instructions.Compare(nb.Instructions) ||
                !ob.LocalVariables.Compare(nb.LocalVariables,CheckVariableDecl)
                )
            {
                Reason += "Method body";
                return false;
            }
            return true;
        }

        private static bool CheckExceptionHandler(IExceptionHandler o, IExceptionHandler n)
        {
            if (o.CatchType.ToString() != n.CatchType.ToString() ||
                o.FilterOffset != n.FilterOffset ||
                o.HandlerLength != n.HandlerLength ||
                o.HandlerOffset != n.HandlerOffset ||
                o.TryLength != n.TryLength ||
                o.TryOffset != n.TryOffset ||
                o.Type != n.Type
                )
            { return false; }
            return true;
        }


        private static bool CheckExp(IExpression o, IExpression n)
        {
            if (o == null && n == null)
                return true;
            try
            {
                return (o.ToString() == n.ToString());

            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        private bool CheckMethodReturnType(IMethodReturnType o, IMethodReturnType n)
        {
            if (
                !o.Attributes.Compare(n.Attributes, CheckCustomAttribute) ||
                (o.Type.ToString() != n.Type.ToString())
                )
            {
                Reason += "Method return type";
                return false;
            }
            return true;
        }

        #endregion

        private bool CheckUnmanagedResource(IUnmanagedResource o, IUnmanagedResource n)
        {
            if (!(
                (int)o.Type == (int)n.Type &&
                o.CodePage == n.CodePage &&
                o.Language == n.Language &&
                (int)o.Name == (int)n.Name &&
                CompareByteArray(o.Value, n.Value)
                ))
            {
                Reason = "UnmanagedResource " + o.Name;
                return false;
            }
            return true;
        }

        private static bool CheckResource(IResource ores, IResource nres,Action<string, string> errCollector)
        {

            if (
                ores.Name != nres.Name ||
                ores.Visibility != nres.Visibility ||
                !CompareByteArray(((EmbeddedResource)ores).Value, ((EmbeddedResource)nres).Value)
                )
            {
                errCollector("EmbeddedResource ",ores.Name);
                return false;
            }

            return true;
        }


        private bool CheckScalars()
        {
            if (_assmB.Culture != _assmA.Culture)
            {
                Reason = "culture";
                return false;
            }

            if (!CheckMethodDecl(_assmB.EntryPoint, _assmA.EntryPoint))
            {
                Reason = "entry point";
                return false;
            }
            if (_assmB.HashAlgorithm != _assmA.HashAlgorithm)
            {
                Reason = "HashAlgorithm";
                return false;
            }

            if (!CompareByteArray(_assmB.HashValue, _assmA.HashValue))
            {
                Reason = "HashValue";
                return false;
            }
            if (_assmB.Name != _assmA.Name)
            {
                Reason = "Name";
                return false;
            }
            if (!CompareByteArray(_assmB.PublicKey, _assmA.PublicKey))
            {
                Reason = "PublicKey";
                return false;
            }
            if (!CompareByteArray(_assmB.PublicKeyToken, _assmA.PublicKeyToken))
            {
                Reason = "PublicKeyToken";
                return false;
            }
            if (_assmB.Status != _assmA.Status)
            {
                Reason = "Status";
                return false;
            }
            if (_assmB.Type != _assmA.Type)
            {
                Reason = "Type";
                return false;
            }

            if (_assmB.Version != _assmA.Version)
            {
                Reason = "Version";
                return false;
            }

            return true;
        }

        private static bool CheckFileSize(string fileSpecA, string fileSpecB)
        {
            Debug.Assert(!string.IsNullOrEmpty(fileSpecA));
            Debug.Assert(!string.IsNullOrEmpty(fileSpecB));
            IO.FileInfo ofi = new System.IO.FileInfo(fileSpecA);
            IO.FileInfo nfi = new System.IO.FileInfo(fileSpecB);
            return (nfi.Length == ofi.Length);
        }

        private static bool CompareByteArray(byte[] o, byte[] n)
        {
            if (o.Length != n.Length)
                return false;

            for (int ii = 0; ii < o.Length; ii++)
            {
                if (o[ii] != n[ii])
                    return false;
            }
            return true;

        }
    }
}
