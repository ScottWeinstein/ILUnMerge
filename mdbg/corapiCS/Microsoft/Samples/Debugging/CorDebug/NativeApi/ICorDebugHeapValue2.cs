namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("E3AC4D6C-9CB7-43E6-96CC-B21540E5083C")]
    public interface ICorDebugHeapValue2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateHandle([In] CorDebugHandleType type, [MarshalAs(UnmanagedType.Interface)] out ICorDebugHandleValue ppHandle);
    }
}
