namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct EXIT_PROCESS_DEBUG_INFO
    {
        public uint dwExitCode;
    }
}
