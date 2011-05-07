namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("10F27499-9DF2-43CE-8333-A321D7C99CB4"), InterfaceType((short) 1), ComConversionLoss]
    public interface ICorDebugTypeEnum : ICorDebugEnum
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
        int Next([In] uint celt, [Out, MarshalAs(UnmanagedType.LPArray)] ICorDebugType[] values, out uint pceltFetched);
    }
}
