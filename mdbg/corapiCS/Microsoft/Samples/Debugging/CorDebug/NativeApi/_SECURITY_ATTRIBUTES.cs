namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct _SECURITY_ATTRIBUTES
    {
        public uint nLength;
        public IntPtr lpSecurityDescriptor;
        public int bInheritHandle;
    }
}
