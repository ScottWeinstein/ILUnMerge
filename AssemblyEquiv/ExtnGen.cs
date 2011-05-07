using System;
using Reflector;
using Reflector.CodeModel.Memory;
using Reflector.CodeModel;
using System.Windows.Forms;
namespace ACATool.Tasks
{
    internal static partial class ReflectorExtentionMethods
    {
		public static bool Compare(this ICommandBarCollection source, ICommandBarCollection n)
		{
			return Compare<ICommandBar>(source,n);
		}
		public static bool Compare(this ICommandBarCollection source, ICommandBarCollection n, Func<ICommandBar, ICommandBar, bool> checkitem)
		{
			return Compare<ICommandBar>(source,n,checkitem);
		}
		public static bool Compare(this ICommandBarCollection source, ICommandBarCollection n, Func<ICommandBar, ICommandBar, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ICommandBar>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ICommandBarItemCollection source, ICommandBarItemCollection n)
		{
			return Compare<ICommandBarItem>(source,n);
		}
		public static bool Compare(this ICommandBarItemCollection source, ICommandBarItemCollection n, Func<ICommandBarItem, ICommandBarItem, bool> checkitem)
		{
			return Compare<ICommandBarItem>(source,n,checkitem);
		}
		public static bool Compare(this ICommandBarItemCollection source, ICommandBarItemCollection n, Func<ICommandBarItem, ICommandBarItem, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ICommandBarItem>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IControlCollection source, IControlCollection n)
		{
			return Compare<Control>(source,n);
		}
		public static bool Compare(this IControlCollection source, IControlCollection n, Func<Control, Control, bool> checkitem)
		{
			return Compare<Control>(source,n,checkitem);
		}
		public static bool Compare(this IControlCollection source, IControlCollection n, Func<Control, Control, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<Control>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ILanguageCollection source, ILanguageCollection n)
		{
			return Compare<ILanguage>(source,n);
		}
		public static bool Compare(this ILanguageCollection source, ILanguageCollection n, Func<ILanguage, ILanguage, bool> checkitem)
		{
			return Compare<ILanguage>(source,n,checkitem);
		}
		public static bool Compare(this ILanguageCollection source, ILanguageCollection n, Func<ILanguage, ILanguage, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ILanguage>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IPropertyPageCollection source, IPropertyPageCollection n)
		{
			return Compare<IPropertyPage>(source,n);
		}
		public static bool Compare(this IPropertyPageCollection source, IPropertyPageCollection n, Func<IPropertyPage, IPropertyPage, bool> checkitem)
		{
			return Compare<IPropertyPage>(source,n,checkitem);
		}
		public static bool Compare(this IPropertyPageCollection source, IPropertyPageCollection n, Func<IPropertyPage, IPropertyPage, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IPropertyPage>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IWindowCollection source, IWindowCollection n)
		{
			return Compare<IWindow>(source,n);
		}
		public static bool Compare(this IWindowCollection source, IWindowCollection n, Func<IWindow, IWindow, bool> checkitem)
		{
			return Compare<IWindow>(source,n,checkitem);
		}
		public static bool Compare(this IWindowCollection source, IWindowCollection n, Func<IWindow, IWindow, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IWindow>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ArrayDimensionCollection source, ArrayDimensionCollection n)
		{
			return Compare<ArrayDimension>(source,n);
		}
		public static bool Compare(this ArrayDimensionCollection source, ArrayDimensionCollection n, Func<ArrayDimension, ArrayDimension, bool> checkitem)
		{
			return Compare<ArrayDimension>(source,n,checkitem);
		}
		public static bool Compare(this ArrayDimensionCollection source, ArrayDimensionCollection n, Func<ArrayDimension, ArrayDimension, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ArrayDimension>(source,n,checkitem,errAct);
		}
		public static bool Compare(this AssemblyCollection source, AssemblyCollection n)
		{
			return Compare<Assembly>(source,n);
		}
		public static bool Compare(this AssemblyCollection source, AssemblyCollection n, Func<Assembly, Assembly, bool> checkitem)
		{
			return Compare<Assembly>(source,n,checkitem);
		}
		public static bool Compare(this AssemblyCollection source, AssemblyCollection n, Func<Assembly, Assembly, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<Assembly>(source,n,checkitem,errAct);
		}
		public static bool Compare(this AssemblyReferenceCollection source, AssemblyReferenceCollection n)
		{
			return Compare<AssemblyReference>(source,n);
		}
		public static bool Compare(this AssemblyReferenceCollection source, AssemblyReferenceCollection n, Func<AssemblyReference, AssemblyReference, bool> checkitem)
		{
			return Compare<AssemblyReference>(source,n,checkitem);
		}
		public static bool Compare(this AssemblyReferenceCollection source, AssemblyReferenceCollection n, Func<AssemblyReference, AssemblyReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<AssemblyReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this CatchClauseCollection source, CatchClauseCollection n)
		{
			return Compare<CatchClause>(source,n);
		}
		public static bool Compare(this CatchClauseCollection source, CatchClauseCollection n, Func<CatchClause, CatchClause, bool> checkitem)
		{
			return Compare<CatchClause>(source,n,checkitem);
		}
		public static bool Compare(this CatchClauseCollection source, CatchClauseCollection n, Func<CatchClause, CatchClause, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<CatchClause>(source,n,checkitem,errAct);
		}
		public static bool Compare(this CustomAttributeCollection source, CustomAttributeCollection n)
		{
			return Compare<CustomAttribute>(source,n);
		}
		public static bool Compare(this CustomAttributeCollection source, CustomAttributeCollection n, Func<CustomAttribute, CustomAttribute, bool> checkitem)
		{
			return Compare<CustomAttribute>(source,n,checkitem);
		}
		public static bool Compare(this CustomAttributeCollection source, CustomAttributeCollection n, Func<CustomAttribute, CustomAttribute, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<CustomAttribute>(source,n,checkitem,errAct);
		}
		public static bool Compare(this EventDeclarationCollection source, EventDeclarationCollection n)
		{
			return Compare<EventDeclaration>(source,n);
		}
		public static bool Compare(this EventDeclarationCollection source, EventDeclarationCollection n, Func<EventDeclaration, EventDeclaration, bool> checkitem)
		{
			return Compare<EventDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this EventDeclarationCollection source, EventDeclarationCollection n, Func<EventDeclaration, EventDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<EventDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ExceptionHandlerCollection source, ExceptionHandlerCollection n)
		{
			return Compare<ExceptionHandler>(source,n);
		}
		public static bool Compare(this ExceptionHandlerCollection source, ExceptionHandlerCollection n, Func<ExceptionHandler, ExceptionHandler, bool> checkitem)
		{
			return Compare<ExceptionHandler>(source,n,checkitem);
		}
		public static bool Compare(this ExceptionHandlerCollection source, ExceptionHandlerCollection n, Func<ExceptionHandler, ExceptionHandler, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ExceptionHandler>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ExpressionCollection source, ExpressionCollection n)
		{
			return Compare<Expression>(source,n);
		}
		public static bool Compare(this ExpressionCollection source, ExpressionCollection n, Func<Expression, Expression, bool> checkitem)
		{
			return Compare<Expression>(source,n,checkitem);
		}
		public static bool Compare(this ExpressionCollection source, ExpressionCollection n, Func<Expression, Expression, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<Expression>(source,n,checkitem,errAct);
		}
		public static bool Compare(this FieldDeclarationCollection source, FieldDeclarationCollection n)
		{
			return Compare<FieldDeclaration>(source,n);
		}
		public static bool Compare(this FieldDeclarationCollection source, FieldDeclarationCollection n, Func<FieldDeclaration, FieldDeclaration, bool> checkitem)
		{
			return Compare<FieldDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this FieldDeclarationCollection source, FieldDeclarationCollection n, Func<FieldDeclaration, FieldDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<FieldDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this InstructionCollection source, InstructionCollection n)
		{
			return Compare<Instruction>(source,n);
		}
		public static bool Compare(this InstructionCollection source, InstructionCollection n, Func<Instruction, Instruction, bool> checkitem)
		{
			return Compare<Instruction>(source,n,checkitem);
		}
		public static bool Compare(this InstructionCollection source, InstructionCollection n, Func<Instruction, Instruction, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<Instruction>(source,n,checkitem,errAct);
		}
		public static bool Compare(this MethodDeclarationCollection source, MethodDeclarationCollection n)
		{
			return Compare<MethodDeclaration>(source,n);
		}
		public static bool Compare(this MethodDeclarationCollection source, MethodDeclarationCollection n, Func<MethodDeclaration, MethodDeclaration, bool> checkitem)
		{
			return Compare<MethodDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this MethodDeclarationCollection source, MethodDeclarationCollection n, Func<MethodDeclaration, MethodDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<MethodDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this MethodReferenceCollection source, MethodReferenceCollection n)
		{
			return Compare<MethodReference>(source,n);
		}
		public static bool Compare(this MethodReferenceCollection source, MethodReferenceCollection n, Func<MethodReference, MethodReference, bool> checkitem)
		{
			return Compare<MethodReference>(source,n,checkitem);
		}
		public static bool Compare(this MethodReferenceCollection source, MethodReferenceCollection n, Func<MethodReference, MethodReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<MethodReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ModuleCollection source, ModuleCollection n)
		{
			return Compare<Module>(source,n);
		}
		public static bool Compare(this ModuleCollection source, ModuleCollection n, Func<Module, Module, bool> checkitem)
		{
			return Compare<Module>(source,n,checkitem);
		}
		public static bool Compare(this ModuleCollection source, ModuleCollection n, Func<Module, Module, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<Module>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ModuleReferenceCollection source, ModuleReferenceCollection n)
		{
			return Compare<ModuleReference>(source,n);
		}
		public static bool Compare(this ModuleReferenceCollection source, ModuleReferenceCollection n, Func<ModuleReference, ModuleReference, bool> checkitem)
		{
			return Compare<ModuleReference>(source,n,checkitem);
		}
		public static bool Compare(this ModuleReferenceCollection source, ModuleReferenceCollection n, Func<ModuleReference, ModuleReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ModuleReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ParameterDeclarationCollection source, ParameterDeclarationCollection n)
		{
			return Compare<ParameterDeclaration>(source,n);
		}
		public static bool Compare(this ParameterDeclarationCollection source, ParameterDeclarationCollection n, Func<ParameterDeclaration, ParameterDeclaration, bool> checkitem)
		{
			return Compare<ParameterDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this ParameterDeclarationCollection source, ParameterDeclarationCollection n, Func<ParameterDeclaration, ParameterDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ParameterDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this PropertyDeclarationCollection source, PropertyDeclarationCollection n)
		{
			return Compare<PropertyDeclaration>(source,n);
		}
		public static bool Compare(this PropertyDeclarationCollection source, PropertyDeclarationCollection n, Func<PropertyDeclaration, PropertyDeclaration, bool> checkitem)
		{
			return Compare<PropertyDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this PropertyDeclarationCollection source, PropertyDeclarationCollection n, Func<PropertyDeclaration, PropertyDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<PropertyDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this QueryClauseCollection source, QueryClauseCollection n)
		{
			return Compare<IQueryClause>(source,n);
		}
		public static bool Compare(this QueryClauseCollection source, QueryClauseCollection n, Func<IQueryClause, IQueryClause, bool> checkitem)
		{
			return Compare<IQueryClause>(source,n,checkitem);
		}
		public static bool Compare(this QueryClauseCollection source, QueryClauseCollection n, Func<IQueryClause, IQueryClause, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IQueryClause>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ResourceCollection source, ResourceCollection n)
		{
			return Compare<IResource>(source,n);
		}
		public static bool Compare(this ResourceCollection source, ResourceCollection n, Func<IResource, IResource, bool> checkitem)
		{
			return Compare<IResource>(source,n,checkitem);
		}
		public static bool Compare(this ResourceCollection source, ResourceCollection n, Func<IResource, IResource, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IResource>(source,n,checkitem,errAct);
		}
		public static bool Compare(this StatementCollection source, StatementCollection n)
		{
			return Compare<Statement>(source,n);
		}
		public static bool Compare(this StatementCollection source, StatementCollection n, Func<Statement, Statement, bool> checkitem)
		{
			return Compare<Statement>(source,n,checkitem);
		}
		public static bool Compare(this StatementCollection source, StatementCollection n, Func<Statement, Statement, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<Statement>(source,n,checkitem,errAct);
		}
		public static bool Compare(this SwitchCaseCollection source, SwitchCaseCollection n)
		{
			return Compare<ISwitchCase>(source,n);
		}
		public static bool Compare(this SwitchCaseCollection source, SwitchCaseCollection n, Func<ISwitchCase, ISwitchCase, bool> checkitem)
		{
			return Compare<ISwitchCase>(source,n,checkitem);
		}
		public static bool Compare(this SwitchCaseCollection source, SwitchCaseCollection n, Func<ISwitchCase, ISwitchCase, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ISwitchCase>(source,n,checkitem,errAct);
		}
		public static bool Compare(this TypeCollection source, TypeCollection n)
		{
			return Compare<Type>(source,n);
		}
		public static bool Compare(this TypeCollection source, TypeCollection n, Func<Type, Type, bool> checkitem)
		{
			return Compare<Type>(source,n,checkitem);
		}
		public static bool Compare(this TypeCollection source, TypeCollection n, Func<Type, Type, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<Type>(source,n,checkitem,errAct);
		}
		public static bool Compare(this TypeDeclarationCollection source, TypeDeclarationCollection n)
		{
			return Compare<TypeDeclaration>(source,n);
		}
		public static bool Compare(this TypeDeclarationCollection source, TypeDeclarationCollection n, Func<TypeDeclaration, TypeDeclaration, bool> checkitem)
		{
			return Compare<TypeDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this TypeDeclarationCollection source, TypeDeclarationCollection n, Func<TypeDeclaration, TypeDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<TypeDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this TypeReferenceCollection source, TypeReferenceCollection n)
		{
			return Compare<TypeReference>(source,n);
		}
		public static bool Compare(this TypeReferenceCollection source, TypeReferenceCollection n, Func<TypeReference, TypeReference, bool> checkitem)
		{
			return Compare<TypeReference>(source,n,checkitem);
		}
		public static bool Compare(this TypeReferenceCollection source, TypeReferenceCollection n, Func<TypeReference, TypeReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<TypeReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this UnmanagedResourceCollection source, UnmanagedResourceCollection n)
		{
			return Compare<UnmanagedResource>(source,n);
		}
		public static bool Compare(this UnmanagedResourceCollection source, UnmanagedResourceCollection n, Func<UnmanagedResource, UnmanagedResource, bool> checkitem)
		{
			return Compare<UnmanagedResource>(source,n,checkitem);
		}
		public static bool Compare(this UnmanagedResourceCollection source, UnmanagedResourceCollection n, Func<UnmanagedResource, UnmanagedResource, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<UnmanagedResource>(source,n,checkitem,errAct);
		}
		public static bool Compare(this VariableDeclarationCollection source, VariableDeclarationCollection n)
		{
			return Compare<VariableDeclaration>(source,n);
		}
		public static bool Compare(this VariableDeclarationCollection source, VariableDeclarationCollection n, Func<VariableDeclaration, VariableDeclaration, bool> checkitem)
		{
			return Compare<VariableDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this VariableDeclarationCollection source, VariableDeclarationCollection n, Func<VariableDeclaration, VariableDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<VariableDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IArrayDimensionCollection source, IArrayDimensionCollection n)
		{
			return Compare<IArrayDimension>(source,n);
		}
		public static bool Compare(this IArrayDimensionCollection source, IArrayDimensionCollection n, Func<IArrayDimension, IArrayDimension, bool> checkitem)
		{
			return Compare<IArrayDimension>(source,n,checkitem);
		}
		public static bool Compare(this IArrayDimensionCollection source, IArrayDimensionCollection n, Func<IArrayDimension, IArrayDimension, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IArrayDimension>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IAssemblyCollection source, IAssemblyCollection n)
		{
			return Compare<IAssembly>(source,n);
		}
		public static bool Compare(this IAssemblyCollection source, IAssemblyCollection n, Func<IAssembly, IAssembly, bool> checkitem)
		{
			return Compare<IAssembly>(source,n,checkitem);
		}
		public static bool Compare(this IAssemblyCollection source, IAssemblyCollection n, Func<IAssembly, IAssembly, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IAssembly>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IAssemblyLocationCollection source, IAssemblyLocationCollection n)
		{
			return Compare<IAssemblyLocation>(source,n);
		}
		public static bool Compare(this IAssemblyLocationCollection source, IAssemblyLocationCollection n, Func<IAssemblyLocation, IAssemblyLocation, bool> checkitem)
		{
			return Compare<IAssemblyLocation>(source,n,checkitem);
		}
		public static bool Compare(this IAssemblyLocationCollection source, IAssemblyLocationCollection n, Func<IAssemblyLocation, IAssemblyLocation, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IAssemblyLocation>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IAssemblyReferenceCollection source, IAssemblyReferenceCollection n)
		{
			return Compare<IAssemblyReference>(source,n);
		}
		public static bool Compare(this IAssemblyReferenceCollection source, IAssemblyReferenceCollection n, Func<IAssemblyReference, IAssemblyReference, bool> checkitem)
		{
			return Compare<IAssemblyReference>(source,n,checkitem);
		}
		public static bool Compare(this IAssemblyReferenceCollection source, IAssemblyReferenceCollection n, Func<IAssemblyReference, IAssemblyReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IAssemblyReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ICatchClauseCollection source, ICatchClauseCollection n)
		{
			return Compare<ICatchClause>(source,n);
		}
		public static bool Compare(this ICatchClauseCollection source, ICatchClauseCollection n, Func<ICatchClause, ICatchClause, bool> checkitem)
		{
			return Compare<ICatchClause>(source,n,checkitem);
		}
		public static bool Compare(this ICatchClauseCollection source, ICatchClauseCollection n, Func<ICatchClause, ICatchClause, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ICatchClause>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ICustomAttributeCollection source, ICustomAttributeCollection n)
		{
			return Compare<ICustomAttribute>(source,n);
		}
		public static bool Compare(this ICustomAttributeCollection source, ICustomAttributeCollection n, Func<ICustomAttribute, ICustomAttribute, bool> checkitem)
		{
			return Compare<ICustomAttribute>(source,n,checkitem);
		}
		public static bool Compare(this ICustomAttributeCollection source, ICustomAttributeCollection n, Func<ICustomAttribute, ICustomAttribute, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ICustomAttribute>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IEventDeclarationCollection source, IEventDeclarationCollection n)
		{
			return Compare<IEventDeclaration>(source,n);
		}
		public static bool Compare(this IEventDeclarationCollection source, IEventDeclarationCollection n, Func<IEventDeclaration, IEventDeclaration, bool> checkitem)
		{
			return Compare<IEventDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this IEventDeclarationCollection source, IEventDeclarationCollection n, Func<IEventDeclaration, IEventDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IEventDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IExceptionHandlerCollection source, IExceptionHandlerCollection n)
		{
			return Compare<IExceptionHandler>(source,n);
		}
		public static bool Compare(this IExceptionHandlerCollection source, IExceptionHandlerCollection n, Func<IExceptionHandler, IExceptionHandler, bool> checkitem)
		{
			return Compare<IExceptionHandler>(source,n,checkitem);
		}
		public static bool Compare(this IExceptionHandlerCollection source, IExceptionHandlerCollection n, Func<IExceptionHandler, IExceptionHandler, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IExceptionHandler>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IExpressionCollection source, IExpressionCollection n)
		{
			return Compare<IExpression>(source,n);
		}
		public static bool Compare(this IExpressionCollection source, IExpressionCollection n, Func<IExpression, IExpression, bool> checkitem)
		{
			return Compare<IExpression>(source,n,checkitem);
		}
		public static bool Compare(this IExpressionCollection source, IExpressionCollection n, Func<IExpression, IExpression, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IExpression>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IFieldDeclarationCollection source, IFieldDeclarationCollection n)
		{
			return Compare<IFieldDeclaration>(source,n);
		}
		public static bool Compare(this IFieldDeclarationCollection source, IFieldDeclarationCollection n, Func<IFieldDeclaration, IFieldDeclaration, bool> checkitem)
		{
			return Compare<IFieldDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this IFieldDeclarationCollection source, IFieldDeclarationCollection n, Func<IFieldDeclaration, IFieldDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IFieldDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IInstructionCollection source, IInstructionCollection n)
		{
			return Compare<IInstruction>(source,n);
		}
		public static bool Compare(this IInstructionCollection source, IInstructionCollection n, Func<IInstruction, IInstruction, bool> checkitem)
		{
			return Compare<IInstruction>(source,n,checkitem);
		}
		public static bool Compare(this IInstructionCollection source, IInstructionCollection n, Func<IInstruction, IInstruction, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IInstruction>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IMethodReferenceCollection source, IMethodReferenceCollection n)
		{
			return Compare<IMethodReference>(source,n);
		}
		public static bool Compare(this IMethodReferenceCollection source, IMethodReferenceCollection n, Func<IMethodReference, IMethodReference, bool> checkitem)
		{
			return Compare<IMethodReference>(source,n,checkitem);
		}
		public static bool Compare(this IMethodReferenceCollection source, IMethodReferenceCollection n, Func<IMethodReference, IMethodReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IMethodReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IMethodDeclarationCollection source, IMethodDeclarationCollection n)
		{
			return Compare<IMethodDeclaration>(source,n);
		}
		public static bool Compare(this IMethodDeclarationCollection source, IMethodDeclarationCollection n, Func<IMethodDeclaration, IMethodDeclaration, bool> checkitem)
		{
			return Compare<IMethodDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this IMethodDeclarationCollection source, IMethodDeclarationCollection n, Func<IMethodDeclaration, IMethodDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IMethodDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IModuleCollection source, IModuleCollection n)
		{
			return Compare<IModule>(source,n);
		}
		public static bool Compare(this IModuleCollection source, IModuleCollection n, Func<IModule, IModule, bool> checkitem)
		{
			return Compare<IModule>(source,n,checkitem);
		}
		public static bool Compare(this IModuleCollection source, IModuleCollection n, Func<IModule, IModule, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IModule>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IModuleReferenceCollection source, IModuleReferenceCollection n)
		{
			return Compare<IModuleReference>(source,n);
		}
		public static bool Compare(this IModuleReferenceCollection source, IModuleReferenceCollection n, Func<IModuleReference, IModuleReference, bool> checkitem)
		{
			return Compare<IModuleReference>(source,n,checkitem);
		}
		public static bool Compare(this IModuleReferenceCollection source, IModuleReferenceCollection n, Func<IModuleReference, IModuleReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IModuleReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IParameterDeclarationCollection source, IParameterDeclarationCollection n)
		{
			return Compare<IParameterDeclaration>(source,n);
		}
		public static bool Compare(this IParameterDeclarationCollection source, IParameterDeclarationCollection n, Func<IParameterDeclaration, IParameterDeclaration, bool> checkitem)
		{
			return Compare<IParameterDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this IParameterDeclarationCollection source, IParameterDeclarationCollection n, Func<IParameterDeclaration, IParameterDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IParameterDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IPropertyDeclarationCollection source, IPropertyDeclarationCollection n)
		{
			return Compare<IPropertyDeclaration>(source,n);
		}
		public static bool Compare(this IPropertyDeclarationCollection source, IPropertyDeclarationCollection n, Func<IPropertyDeclaration, IPropertyDeclaration, bool> checkitem)
		{
			return Compare<IPropertyDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this IPropertyDeclarationCollection source, IPropertyDeclarationCollection n, Func<IPropertyDeclaration, IPropertyDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IPropertyDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IQueryClauseCollection source, IQueryClauseCollection n)
		{
			return Compare<IQueryClause>(source,n);
		}
		public static bool Compare(this IQueryClauseCollection source, IQueryClauseCollection n, Func<IQueryClause, IQueryClause, bool> checkitem)
		{
			return Compare<IQueryClause>(source,n,checkitem);
		}
		public static bool Compare(this IQueryClauseCollection source, IQueryClauseCollection n, Func<IQueryClause, IQueryClause, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IQueryClause>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IResourceCollection source, IResourceCollection n)
		{
			return Compare<IResource>(source,n);
		}
		public static bool Compare(this IResourceCollection source, IResourceCollection n, Func<IResource, IResource, bool> checkitem)
		{
			return Compare<IResource>(source,n,checkitem);
		}
		public static bool Compare(this IResourceCollection source, IResourceCollection n, Func<IResource, IResource, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IResource>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IStatementCollection source, IStatementCollection n)
		{
			return Compare<IStatement>(source,n);
		}
		public static bool Compare(this IStatementCollection source, IStatementCollection n, Func<IStatement, IStatement, bool> checkitem)
		{
			return Compare<IStatement>(source,n,checkitem);
		}
		public static bool Compare(this IStatementCollection source, IStatementCollection n, Func<IStatement, IStatement, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IStatement>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IStringCollection source, IStringCollection n)
		{
			return Compare<string>(source,n);
		}
		public static bool Compare(this IStringCollection source, IStringCollection n, Func<string, string, bool> checkitem)
		{
			return Compare<string>(source,n,checkitem);
		}
		public static bool Compare(this IStringCollection source, IStringCollection n, Func<string, string, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<string>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ISwitchCaseCollection source, ISwitchCaseCollection n)
		{
			return Compare<ISwitchCase>(source,n);
		}
		public static bool Compare(this ISwitchCaseCollection source, ISwitchCaseCollection n, Func<ISwitchCase, ISwitchCase, bool> checkitem)
		{
			return Compare<ISwitchCase>(source,n,checkitem);
		}
		public static bool Compare(this ISwitchCaseCollection source, ISwitchCaseCollection n, Func<ISwitchCase, ISwitchCase, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ISwitchCase>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ITypeCollection source, ITypeCollection n)
		{
			return Compare<IType>(source,n);
		}
		public static bool Compare(this ITypeCollection source, ITypeCollection n, Func<IType, IType, bool> checkitem)
		{
			return Compare<IType>(source,n,checkitem);
		}
		public static bool Compare(this ITypeCollection source, ITypeCollection n, Func<IType, IType, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IType>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ITypeDeclarationCollection source, ITypeDeclarationCollection n)
		{
			return Compare<ITypeDeclaration>(source,n);
		}
		public static bool Compare(this ITypeDeclarationCollection source, ITypeDeclarationCollection n, Func<ITypeDeclaration, ITypeDeclaration, bool> checkitem)
		{
			return Compare<ITypeDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this ITypeDeclarationCollection source, ITypeDeclarationCollection n, Func<ITypeDeclaration, ITypeDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ITypeDeclaration>(source,n,checkitem,errAct);
		}
		public static bool Compare(this ITypeReferenceCollection source, ITypeReferenceCollection n)
		{
			return Compare<ITypeReference>(source,n);
		}
		public static bool Compare(this ITypeReferenceCollection source, ITypeReferenceCollection n, Func<ITypeReference, ITypeReference, bool> checkitem)
		{
			return Compare<ITypeReference>(source,n,checkitem);
		}
		public static bool Compare(this ITypeReferenceCollection source, ITypeReferenceCollection n, Func<ITypeReference, ITypeReference, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<ITypeReference>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IUnmanagedResourceCollection source, IUnmanagedResourceCollection n)
		{
			return Compare<IUnmanagedResource>(source,n);
		}
		public static bool Compare(this IUnmanagedResourceCollection source, IUnmanagedResourceCollection n, Func<IUnmanagedResource, IUnmanagedResource, bool> checkitem)
		{
			return Compare<IUnmanagedResource>(source,n,checkitem);
		}
		public static bool Compare(this IUnmanagedResourceCollection source, IUnmanagedResourceCollection n, Func<IUnmanagedResource, IUnmanagedResource, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IUnmanagedResource>(source,n,checkitem,errAct);
		}
		public static bool Compare(this IVariableDeclarationCollection source, IVariableDeclarationCollection n)
		{
			return Compare<IVariableDeclaration>(source,n);
		}
		public static bool Compare(this IVariableDeclarationCollection source, IVariableDeclarationCollection n, Func<IVariableDeclaration, IVariableDeclaration, bool> checkitem)
		{
			return Compare<IVariableDeclaration>(source,n,checkitem);
		}
		public static bool Compare(this IVariableDeclarationCollection source, IVariableDeclarationCollection n, Func<IVariableDeclaration, IVariableDeclaration, Action<string, string>, bool> checkitem, Action<string, string> errAct)
		{
			return Compare<IVariableDeclaration>(source,n,checkitem,errAct);
		}
	}
}