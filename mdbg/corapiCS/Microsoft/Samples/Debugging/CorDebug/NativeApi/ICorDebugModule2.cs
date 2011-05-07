namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("7FCC5FB5-49C0-41DE-9938-3B88B5B9ADD7")]
    public interface ICorDebugModule2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetJMCStatus([In] int bIsJustMyCode, [In] uint cTokens, [In] ref uint pTokens);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ApplyChanges([In] uint cbMetadata, [In, MarshalAs(UnmanagedType.LPArray)] byte[] pbMetadata, [In] uint cbIL, [In, MarshalAs(UnmanagedType.LPArray)] byte[] pbIL);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        int SetJITCompilerFlags([In] uint dwFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetJITCompilerFlags(out uint pdwFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ResolveAssembly([In] uint tkAssemblyRef, [MarshalAs(UnmanagedType.Interface)] out ICorDebugAssembly ppAssembly);
    }
}
