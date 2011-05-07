namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct COR_IL_MAP
    {
        public uint oldOffset;
        public uint newOffset;
        public int fAccurate;
    }
}
