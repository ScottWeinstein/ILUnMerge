namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("5263E909-8CB5-11D3-BD2F-0000F80849BD")]
    public interface ICorDebugUnmanagedCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void DebugEvent([In] DEBUG_EVENT pDebugEvent, [In] int fOutOfBand);
    }
}
