using System;
using System.Collections;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using IO = System.IO;
//using Mono.Cecil;
using Reflector.CodeModel;
using Reflector.CodeModel.Memory;
using Reflector;

namespace ACATool.Tasks
{
    public class AreAssembliesEquivalent : Task
    {
        private IAssembly Oassm, Nassm = null;
       
        [Output]
        public string ReasonCode { get; private set; }
        [Required]
        public ITaskItem OriginalAssembly { get; set; }
        [Required]
        public ITaskItem NewAssembly { get; set; }
        [Output]
        public bool AreEquivalent { get; private set; }

        public override bool Execute()
        {
                if (!CheckScalars())
                {
                    AreEquivalent = false;
                    return true;
                }

                if (!CheckCollection<ICustomAttributeCollection, ICustomAttribute>(CheckCustomAttribute, Oassm.Attributes, Nassm.Attributes))
                {
                    AreEquivalent = false;
                    return true;
                }

                if (!CheckCollection<IResourceCollection, EmbeddedResource>(CheckResource, Oassm.Resources, Nassm.Resources))
                {
                    AreEquivalent = false;
                    return true;
                }

                if (!CheckCollection<IModuleCollection, IModule>(CheckModule, Oassm.Modules, Nassm.Modules))
                {
                    AreEquivalent = false;
                    return true;
                }

                AreEquivalent = true;
                return true;
        }

        
        
        #region CheckDecl
        private bool CheckMethodDecl(IMethodDeclaration ometh, IMethodDeclaration nmeth)
        {
            if (
                (ometh.Abstract != nmeth.Abstract) ||
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
                (!CheckCollection<ICustomAttributeCollection, ICustomAttribute>(CheckCustomAttribute,
                ometh.Attributes, nmeth.Attributes)) ||

                (!CheckCollection<ITypeCollection, IType>(ometh.GenericArguments, nmeth.GenericArguments)) ||

                (!CheckMethodReference(ometh.GenericMethod, nmeth.GenericMethod)) ||

                (!CheckCollection<IMethodReferenceCollection, IMethodReference>(CheckMethodReference,
                ometh.Overrides, nmeth.Overrides)) ||


                (!CheckCollection<IParameterDeclarationCollection, IParameterDeclaration>(
                CheckParameterDecl, ometh.Parameters, nmeth.Parameters)) ||

                (!CheckBody(ometh, nmeth)) ||

                (!CheckMethodReturnType(ometh.ReturnType, nmeth.ReturnType)))
            {
                return false;
            }

            return true;
        }


        private bool CheckParameterDecl(IParameterDeclaration o, IParameterDeclaration n)
        {
            if (
                !CheckCollection<ICustomAttributeCollection, ICustomAttribute>(
                CheckCustomAttribute, o.Attributes, n.Attributes) ||
                //!CheckExp(o.DefaultValue, n.DefaultValue) ||
                o.Name != n.Name ||
                o.ParameterType.ToString() != n.ParameterType.ToString())
            {
                ReasonCode += "Parameter decl";
                return false;
            }
            return true;
        }


        private bool CheckVariableDecl(IVariableDeclaration o, IVariableDeclaration n)
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

            if (
                !CheckCollection<ICustomAttributeCollection, ICustomAttribute>(
                CheckCustomAttribute, o.Attributes, n.Attributes) ||

                !CheckCollection<IParameterDeclarationCollection, IParameterDeclaration>(
                CheckParameterDecl, o.Parameters, n.Parameters)
            )
            {
                return false;
            }

            if (
                !CheckMethodReference(o.GetMethod, n.GetMethod) ||
                !CheckMethodReference(o.SetMethod, n.SetMethod))
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
                ReasonCode = "Type decl props";
                return false;
            }
            if (!CheckCollection<ICustomAttributeCollection, ICustomAttribute>(CheckCustomAttribute,
                otype.Attributes, ntype.Attributes))
                return false;

            if (!CheckTypeReference(otype.BaseType, ntype.BaseType))
                return false;

            if (otype.BeforeFieldInit != ntype.BeforeFieldInit)
                return false;

            if (!CheckCollection<IEventDeclarationCollection, IEventDeclaration>(CheckEventDecl,
                otype.Events, ntype.Events))
                return false;

            if (!CheckCollection<IFieldDeclarationCollection, IFieldDeclaration>(CheckFieldDecl,
                otype.Fields, ntype.Fields))
                return false;

            if (!CheckCollection<ITypeCollection, IType>(otype.GenericArguments, ntype.GenericArguments))
                return false;

            if (!CheckTypeReference(otype.GenericType, ntype.GenericType))
                return false;

            if (!CheckCollection<ITypeReferenceCollection, ITypeReference>(CheckTypeReference,
                otype.Interfaces, ntype.Interfaces))
                return false;

            if (
                !CheckCollection<IMethodDeclarationCollection, IMethodDeclaration>(CheckMethodDecl,
                otype.Methods, ntype.Methods) ||

                 !CheckCollection<ITypeDeclarationCollection, ITypeDeclaration>(CheckTypeDecl,
                    otype.NestedTypes, ntype.NestedTypes) ||

                !CheckCollection<IPropertyDeclarationCollection, IPropertyDeclaration>(CheckPropertyDecl,
                otype.Properties, ntype.Properties)
                )
            {
                return false;
            }

            return true;
        }

        private bool CheckEventDecl(IEventDeclaration o, IEventDeclaration n)
        {
            throw new NotImplementedException();
            //Log.LogMessage(o.ToString());
            //return true;
        }

        private bool CheckFieldDecl(IFieldDeclaration o, IFieldDeclaration n)
        {
            if (!CheckCollection<ICustomAttributeCollection, ICustomAttribute>(CheckCustomAttribute,
                o.Attributes, n.Attributes))
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
        private bool CheckTypeReference(ITypeReference oTypeRef, ITypeReference nTypeRef)
        {
            if (oTypeRef == null && nTypeRef == null)
                return true;
            if ((oTypeRef.Name == nTypeRef.Name) &&
                (oTypeRef.Namespace == nTypeRef.Namespace) &&
                (oTypeRef.Owner.ToString() == nTypeRef.Owner.ToString()))
                return true;

            return false;
        }

        private bool CheckMethodReference(IMethodReference o, IMethodReference n)
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

                (!CheckCollection<ITypeCollection, IType>(o.GenericArguments, n.GenericArguments)) ||

                (!CheckMethodReference(o.GenericMethod, n.GenericMethod)) ||

                (!CheckCollection<IParameterDeclarationCollection, IParameterDeclaration>(
                CheckParameterDecl, o.Parameters, n.Parameters)) ||

                (!CheckMethodReturnType(o.ReturnType, n.ReturnType)))
            {
                return false;
            }

            return true;
        }
        
        #endregion

        #region CheckOthers
        private bool CheckModule(IModule omod, IModule nmod)
        {

            if (!CheckCollection<IAssemblyReferenceCollection, IAssemblyReference>(
                omod.AssemblyReferences, nmod.AssemblyReferences)) //CheckAssemblyReference
            {
                ReasonCode = "Mod assm refs";
                return false;
            }

            if (!CheckCollection<ICustomAttributeCollection, ICustomAttribute>(CheckCustomAttribute, omod.Attributes, nmod.Attributes))
            {
                ReasonCode = "Mod attributes";
                return false;
            }
            if (!CheckCollection<IModuleReferenceCollection, IModuleReference>(omod.ModuleReferences, nmod.ModuleReferences))
            {
                ReasonCode = "Mod refs";
                return false;
            }
            if (omod.Name != nmod.Name)
            {
                ReasonCode = "Mod name";
                return false;
            }
            if (!CheckCollection<ITypeDeclarationCollection, ITypeDeclaration>(CheckTypeDecl,
                omod.Types, nmod.Types))
            {
                return false;
            }

            if (!CheckCollection<IUnmanagedResourceCollection, IUnmanagedResource>(CheckUnmanagedResource,
                omod.UnmanagedResources, nmod.UnmanagedResources))
            {
                ReasonCode = "Mod unmanaged res";
                return false;
            }

            return true;
        }

        private bool CheckCustomAttribute(ICustomAttribute oattr, ICustomAttribute nattr)
        {
            if (nattr.ToString() != oattr.ToString())
            {
                ReasonCode = "Attribute type";
                return false;
            }
            if (nattr.Constructor.Name != oattr.Constructor.Name)
            {
                ReasonCode = "Attribute ctor";
                return false;
            }

            if (!CheckCollection<IExpressionCollection, IExpression>(oattr.Arguments, nattr.Arguments))
            {
                ReasonCode = "Attribute argument";
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
                !CheckCollection<IExceptionHandlerCollection, IExceptionHandler>(CheckExceptionHandler,
                ob.ExceptionHandlers, nb.ExceptionHandlers) ||
                !CheckCollection<IInstructionCollection, IInstruction>(ob.Instructions, nb.Instructions) ||
                !CheckCollection<IVariableDeclarationCollection, IVariableDeclaration>(CheckVariableDecl,
                ob.LocalVariables, nb.LocalVariables)
                )
            {
                ReasonCode += "Method body";
                return false;
            }
            return true;
        }

        private bool CheckExceptionHandler(IExceptionHandler o, IExceptionHandler n)
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


        private bool CheckExp(IExpression o, IExpression n)
        {
            if (o == null && n == null)
                return true;
            try
            {
                return (o.ToString() == n.ToString());

            } catch (NullReferenceException)
            {
                return false;
            }
        }

        private bool CheckMethodReturnType(IMethodReturnType o, IMethodReturnType n)
        {
            if (
                !CheckCollection<ICustomAttributeCollection, ICustomAttribute>(
                CheckCustomAttribute, o.Attributes, n.Attributes) ||
                (o.Type.ToString() != n.Type.ToString())
                )
            {
                ReasonCode += "Method return type";
                return false;
            }
            return true;
        }
       
        #endregion
        
        #region CheckResources
        private bool CheckUnmanagedResource(IUnmanagedResource o, IUnmanagedResource n)
        {
            if (
                o.Type != n.Type ||
                //o.Culture != n.Culture ||
                o.Name != n.Name ||
                !CompareByteArray(o.Value, n.Value)
                )
            {
                ReasonCode = "UnmanagedResource " + o.Name;
                return false;
            }

            return true;
        }

        private bool CheckResource(EmbeddedResource ores, EmbeddedResource nres)
        {
            if (
                ores.Name != nres.Name ||
                ores.Visibility != nres.Visibility ||
                !CompareByteArray(ores.Value, nres.Value)
                )
            {
                ReasonCode = "EmbeddedResource " + ores.Name;
                return false;
            }

            return true;
        }
        
        #endregion

        #region Generic Methods

        private delegate bool CheckItemDel<Titem>(Titem o, Titem n);
        private bool CheckCollection<Tcol, Titem>(CheckItemDel<Titem> checkitem, Tcol o, Tcol n)
            where Tcol : ICollection
        {
            if (o == null && n == null)
                return true;
            int ocount = o.Count;
            if (ocount != n.Count)
                return false;

            // have to do this b/c reflector collections don't implement IList
            Titem[] oarr = new Titem[ocount];
            Titem[] narr = new Titem[ocount];
            o.CopyTo(oarr, 0);
            n.CopyTo(narr, 0);
            for (int ii = 0; ii < ocount; ii++) {
                if (checkitem == null) {
                    if (oarr[ii].ToString() != narr[ii].ToString())
                        return false;
                } else {
                    if (!checkitem(oarr[ii], narr[ii]))
                        return false;
                }
            }

            return true;
        }
        private bool CheckCollection<Tcol, Titem>(Tcol o, Tcol n) where Tcol : ICollection
        {
            return CheckCollection<Tcol, Titem>(null, o, n);
        }
        #endregion
        
        #region CheckScalars
        private bool CheckScalars()
        {
            if (!CheckFileSize())
            {
                ReasonCode = "file size";
                return false;
            }

            LoadAssembies();

            if (Nassm.Culture != Oassm.Culture)
            {
                ReasonCode = "culture";
                return false;
            }

            if (!CheckMethodDecl(Nassm.EntryPoint, Oassm.EntryPoint))
            {
                ReasonCode = "entry point";
                return false;
            }
            if (Nassm.HashAlgorithm != Oassm.HashAlgorithm)
            {
                ReasonCode = "HashAlgorithm";
                return false;
            }

            if (!CompareByteArray(Nassm.HashValue, Oassm.HashValue))
            {
                ReasonCode = "HashValue";
                return false;
            }
            if (Nassm.Name != Oassm.Name)
            {
                ReasonCode = "Name";
                return false;
            }
            if (!CompareByteArray(Nassm.PublicKey, Oassm.PublicKey))
            {
                ReasonCode = "PublicKey";
                return false;
            }
            if (!CompareByteArray(Nassm.PublicKeyToken, Oassm.PublicKeyToken))
            {
                ReasonCode = "PublicKeyToken";
                return false;
            }
            if (Nassm.Status != Oassm.Status)
            {
                ReasonCode = "Status";
                return false;
            }
            if (Nassm.Type != Oassm.Type)
            {
                ReasonCode = "Type";
                return false;
            }

            if (Nassm.Version != Oassm.Version)
            {
                ReasonCode = "Version";
                return false;
            }

            return true;
        }
        #endregion

        #region Support Methods
        private void LoadAssembies()
        {
            IServiceProvider serviceProvider = new Reflector.ApplicationManager(new FakeReflectorWindowManager());
            IServiceProvider serviceProvider2 = new Reflector.ApplicationManager(new FakeReflectorWindowManager());
            IAssemblyManager assemblyManager = (IAssemblyManager)serviceProvider.GetService(typeof(IAssemblyManager));
            IAssemblyManager assemblyManager2 = (IAssemblyManager)serviceProvider2.GetService(typeof(IAssemblyManager));
            Oassm = assemblyManager.LoadFile(OriginalAssembly.ItemSpec);
            Nassm = assemblyManager2.LoadFile(NewAssembly.ItemSpec);
            if (Oassm == Nassm)
                throw new ArgumentException();
        }

        private bool CheckFileSize()
        {
            IO.FileInfo ofi = new System.IO.FileInfo(OriginalAssembly.ItemSpec);
            IO.FileInfo nfi = new System.IO.FileInfo(NewAssembly.ItemSpec);
            return (nfi.Length == ofi.Length);
        }

        private bool CompareByteArray(byte[] o, byte[] n)
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

            #endregion
    }

    public class FakeReflectorWindowManager : IWindowManager
    {
        public FakeReflectorWindowManager()
        {
        }
        public void Activate()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public event EventHandler Closed;

        public System.Windows.Forms.Control CommandBarManager
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Windows.Forms.Control Content
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler Load;

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public IStatusBar StatusBar
        {
            get { throw new NotImplementedException(); }
        }

        public bool Visible
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IWindowCollection Windows
        {
            get { throw new NotImplementedException(); }
        }
    }


}
