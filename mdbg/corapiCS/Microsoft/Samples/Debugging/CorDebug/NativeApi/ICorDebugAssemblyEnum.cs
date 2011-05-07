namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ComConversionLoss, Guid("4A2A1EC9-85EC-4BFB-9F15-A89FDFE0FE83"), InterfaceType((short) 1)]
    public interface ICorDebugAssemblyEnum : ICorDebugEnum
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
        int Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray)] ICorDebugAssembly[] values, out uint pceltFetched);
    }
}
