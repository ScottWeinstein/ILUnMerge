namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), ComConversionLoss, Guid("2BD956D9-7B07-4BEF-8A98-12AA862417C5")]
    public interface ICorDebugThread2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetActiveFunctions([In] uint cFunctions, out uint pcFunctions, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] COR_ACTIVE_FUNCTION[] pFunctions);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetConnectionID(out uint pdwConnectionId);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetTaskID(out ulong pTaskId);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetVolatileOSThreadID(out uint pdwTid);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void InterceptCurrentException([In, MarshalAs(UnmanagedType.Interface)] ICorDebugFrame pFrame);
    }
}
