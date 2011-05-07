namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("CC726F2F-1DB7-459B-B0EC-05F01D841B42")]
    public interface ICorDebugMDA
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.LPArray)] char[] szName);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetDescription([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.LPArray)] char[] szName);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetXML([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.LPArray)] char[] szName);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetFlags(out CorDebugMDAFlags pFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetOSThreadId(out uint pOsTid);
    }
}
