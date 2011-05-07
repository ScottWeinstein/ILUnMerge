namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=8)]
    public struct _ULARGE_INTEGER
    {
        public ulong QuadPart;
    }
}
