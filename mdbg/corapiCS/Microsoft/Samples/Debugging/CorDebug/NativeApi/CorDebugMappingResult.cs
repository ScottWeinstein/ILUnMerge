namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;

    public enum CorDebugMappingResult
    {
        MAPPING_APPROXIMATE = 0x20,
        MAPPING_EPILOG = 2,
        MAPPING_EXACT = 0x10,
        MAPPING_NO_INFO = 4,
        MAPPING_PROLOG = 1,
        MAPPING_UNMAPPED_ADDRESS = 8
    }
}
