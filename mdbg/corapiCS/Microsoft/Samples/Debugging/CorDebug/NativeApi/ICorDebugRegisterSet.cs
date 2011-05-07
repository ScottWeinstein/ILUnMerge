namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("CC7BCB0B-8A68-11D2-983C-0000F808342D"), ComConversionLoss]
    public interface ICorDebugRegisterSet
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetRegistersAvailable(out ulong pAvailable);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetRegisters([In] ulong mask, [In] uint regCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=2)] ulong[] regBuffer);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetRegisters([In] ulong mask, [In] uint regCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=2)] ulong[] regBuffer);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetThreadContext([In] uint contextSize, [In, ComAliasName("BYTE*")] IntPtr context);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetThreadContext([In] uint contextSize, [In, ComAliasName("BYTE*")] IntPtr context);
    }
}
