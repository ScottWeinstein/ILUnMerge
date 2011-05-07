namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct OUTPUT_DEBUG_STRING_INFO
    {
        public IntPtr lpDebugStringData;
        public ushort fUnicode;
        public ushort nDebugStringLenght;
    }
}
