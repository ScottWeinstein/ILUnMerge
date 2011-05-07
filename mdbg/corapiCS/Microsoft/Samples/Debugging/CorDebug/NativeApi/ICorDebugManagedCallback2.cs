namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("250E5EEA-DB5C-4C76-B6F3-8C46F12E3203")]
    public interface ICorDebugManagedCallback2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void FunctionRemapOpportunity([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pOldFunction, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pNewFunction, [In] uint oldILOffset);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateConnection([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess, [In] uint dwConnectionId, [In] ref ushort pConnName);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ChangeConnection([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess, [In] uint dwConnectionId);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void DestroyConnection([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess, [In] uint dwConnectionId);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Exception([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFrame pFrame, [In] uint nOffset, [In] CorDebugExceptionCallbackType dwEventType, [In] uint dwFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ExceptionUnwind([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In] CorDebugExceptionUnwindCallbackType dwEventType, [In] uint dwFlags);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void FunctionRemapComplete([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pFunction);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void MDANotification([In, MarshalAs(UnmanagedType.Interface)] ICorDebugController pController, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugMDA pMDA);
    }
}
