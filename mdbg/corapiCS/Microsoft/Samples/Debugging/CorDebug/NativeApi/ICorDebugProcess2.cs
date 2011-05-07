namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ComConversionLoss, InterfaceType((short) 1), Guid("AD1B3588-0EF0-4744-A496-AA09A9F80371")]
    public interface ICorDebugProcess2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetThreadForTaskID([In] ulong taskid, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread2 ppThread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetVersion(out _COR_VERSION version);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetUnmanagedBreakpoint([In] ulong address, [In] uint bufsize, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer, out uint bufLen);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ClearUnmanagedBreakpoint([In] ulong address);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetDesiredNGENCompilerFlags([In] uint pdwFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetDesiredNGENCompilerFlags(out uint pdwFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetReferenceValueFromGCHandle([In] IntPtr handle, [MarshalAs(UnmanagedType.Interface)] out ICorDebugReferenceValue pOutValue);
    }
}
