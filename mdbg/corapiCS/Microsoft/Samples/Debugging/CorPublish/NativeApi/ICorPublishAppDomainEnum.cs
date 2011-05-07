namespace Microsoft.Samples.Debugging.CorPublish.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("9F0C98F5-5A6A-11D3-8F84-00A0C9B4D50C")]
    public interface ICorPublishAppDomainEnum : ICorPublishEnum
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Skip([In] uint celt);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Reset();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Clone([MarshalAs(UnmanagedType.Interface)] out ICorPublishEnum ppEnum);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetCount(out uint pcelt);
        [PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        int Next([In] uint celt, [MarshalAs(UnmanagedType.Interface)] out ICorPublishAppDomain objects, out uint pceltFetched);
    }
}
