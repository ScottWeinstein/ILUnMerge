namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;

    public enum CorDebugUnmappedStop
    {
        STOP_ALL = 0xffff,
        STOP_EPILOG = 2,
        STOP_NO_MAPPING_INFO = 4,
        STOP_NONE = 0,
        STOP_ONLYJUSTMYCODE = 0x10000,
        STOP_OTHER_UNMAPPED = 8,
        STOP_PROLOG = 1,
        STOP_UNMANAGED = 0x10
    }
}
