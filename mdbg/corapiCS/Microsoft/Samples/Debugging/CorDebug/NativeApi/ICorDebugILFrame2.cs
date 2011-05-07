namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("5D88A994-6C30-479B-890F-BCEF88B129A5")]
    public interface ICorDebugILFrame2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void RemapFunction([In] uint newILOffset);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EnumerateTypeParameters([MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);
    }
}
