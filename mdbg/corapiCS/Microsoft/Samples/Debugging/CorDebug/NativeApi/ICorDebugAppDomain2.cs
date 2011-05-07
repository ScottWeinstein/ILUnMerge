namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("096E81D5-ECDA-4202-83F5-C65980A9EF75")]
    public interface ICorDebugAppDomain2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetArrayOrPointerType([In] CorElementType elementType, [In] uint nRank, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugType pTypeArg, [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetFunctionPointerType([In] uint nTypeArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] ICorDebugType[] ppTypeArgs, [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
    }
}
