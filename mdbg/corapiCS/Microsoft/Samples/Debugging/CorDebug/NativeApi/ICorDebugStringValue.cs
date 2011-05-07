namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    [ComImport, ComConversionLoss, Guid("CC7BCAFD-8A68-11D2-983C-0000F808342D"), InterfaceType((short) 1)]
    public interface ICorDebugStringValue : ICorDebugHeapValue
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetType(out CorElementType pType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetSize(out uint pSize);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetAddress(out ulong pAddress);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void IsValid(out int pbValid);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateRelocBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetLength(out uint pcchString);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetString([In] uint cchString, out uint pcchString, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szString);
    }
}
