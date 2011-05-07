namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct UNLOAD_DLL_DEBUG_INFO
    {
        public IntPtr lpBaseOfDll;
    }
}
