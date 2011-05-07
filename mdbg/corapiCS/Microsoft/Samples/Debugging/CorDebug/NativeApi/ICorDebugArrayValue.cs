namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("0405B0DF-A660-11D2-BD02-0000F80849BD"), InterfaceType((short) 1), ComConversionLoss]
    public interface ICorDebugArrayValue : ICorDebugHeapValue
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
        void GetElementType(out CorElementType pType);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetRank(out uint pnRank);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetCount(out uint pnCount);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetDimensions([In] uint cdim, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] uint[] dims);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void HasBaseIndicies(out int pbHasBaseIndicies);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetBaseIndicies([In] uint cdim, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] uint[] indicies);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetElement([In] uint cdim, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=0)] int[] indices, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetElementAtPosition([In] uint nPosition, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}
