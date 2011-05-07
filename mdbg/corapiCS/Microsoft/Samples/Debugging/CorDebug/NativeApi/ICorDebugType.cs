namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("D613F0BB-ACE1-4C19-BD72-E4C08D5DA7F5")]
    public interface ICorDebugType
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetType(out CorElementType ty);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EnumerateTypeParameters([MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetFirstTypeParameter([MarshalAs(UnmanagedType.Interface)] out ICorDebugType value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetBase([MarshalAs(UnmanagedType.Interface)] out ICorDebugType pBase);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetStaticFieldValue([In] uint fieldDef, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFrame pFrame, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetRank(out uint pnRank);
    }
}
