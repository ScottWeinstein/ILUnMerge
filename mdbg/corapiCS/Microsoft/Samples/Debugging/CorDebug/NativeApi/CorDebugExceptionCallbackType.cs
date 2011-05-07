namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;

    public enum CorDebugExceptionCallbackType
    {
        DEBUG_EXCEPTION_CATCH_HANDLER_FOUND = 3,
        DEBUG_EXCEPTION_FIRST_CHANCE = 1,
        DEBUG_EXCEPTION_UNHANDLED = 4,
        DEBUG_EXCEPTION_USER_FIRST_CHANCE = 2
    }
}
