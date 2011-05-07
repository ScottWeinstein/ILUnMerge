namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;

    public enum CorDebugInternalFrameType
    {
        STUBFRAME_NONE,
        STUBFRAME_M2U,
        STUBFRAME_U2M,
        STUBFRAME_APPDOMAIN_TRANSITION,
        STUBFRAME_LIGHTWEIGHT_FUNCTION,
        STUBFRAME_FUNC_EVAL
    }
}
