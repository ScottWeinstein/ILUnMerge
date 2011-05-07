namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("CC7BCB03-8A68-11D2-983C-0000F808342D"), ComConversionLoss, InterfaceType((short) 1)]
    public interface ICorDebugBreakpointEnum : ICorDebugEnum
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Skip([In] uint celt);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Reset();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Clone([MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetCount(out uint pcelt);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        int Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray)] ICorDebugBreakpoint[] breakpoints, out uint pceltFetched);
    }
}
