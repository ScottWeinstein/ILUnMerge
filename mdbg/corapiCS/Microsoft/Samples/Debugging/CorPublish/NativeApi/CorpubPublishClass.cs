namespace Microsoft.Samples.Debugging.CorPublish.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, ClassInterface((short) 0), Guid("047a9a40-657e-11d3-8d5b-00104b35e7ef"), TypeLibType((short) 2)]
    public class CorpubPublishClass : ICorPublish, CorpubPublish
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void EnumProcesses([In, ComAliasName("CorpubProcessLib.COR_PUB_ENUMPROCESS")] COR_PUB_ENUMPROCESS Type, [MarshalAs(UnmanagedType.Interface)] out ICorPublishProcessEnum ppIEnum);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void GetProcess([In] uint pid, [MarshalAs(UnmanagedType.Interface)] out ICorPublishProcess ppProcess);
    }
}
