namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8), ComVisible(false)]
    public class PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public int dwProcessId;
        public int dwThreadId;
    }
}
