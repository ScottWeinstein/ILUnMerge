namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8), ComVisible(false)]
    public class SECURITY_ATTRIBUTES
    {
        public int nLength = 12;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }
}
