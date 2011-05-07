namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("B008EA8D-7AB1-43F7-BB20-FBB5A04038AE"), InterfaceType((short) 1)]
    public interface ICorDebugClass2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetParameterizedType([In] CorElementType elementType, [In] uint nTypeArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] ICorDebugType[] ppTypeArgs, [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetJMCStatus([In] int bIsJustMyCode);
    }
}
