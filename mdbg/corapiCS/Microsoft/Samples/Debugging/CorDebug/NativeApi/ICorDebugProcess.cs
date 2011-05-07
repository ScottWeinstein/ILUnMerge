namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), ComConversionLoss, Guid("3D6F5F64-7538-11D3-8D5B-00104B35E7EF")]
    public interface ICorDebugProcess : ICorDebugController
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Stop([In] uint dwTimeout);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Continue([In] int fIsOutOfBand);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void IsRunning(out int pbRunning);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void HasQueuedCallbacks([In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, out int pbQueued);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EnumerateThreads([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreads);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetAllThreadsDebugState([In] CorDebugThreadState state, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pExceptThisThread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Detach();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Terminate([In] uint exitCode);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CanCommitChanges([In] uint cSnapshots, [In, MarshalAs(UnmanagedType.Interface)] ref ICorDebugEditAndContinueSnapshot pSnapshots, [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CommitChanges([In] uint cSnapshots, [In, MarshalAs(UnmanagedType.Interface)] ref ICorDebugEditAndContinueSnapshot pSnapshots, [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetID(out uint pdwProcessId);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetHandle([ComAliasName("HPROCESS*")] out IntPtr phProcessHandle);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetThread([In] uint dwThreadId, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EnumerateObjects([MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectEnum ppObjects);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void IsTransitionStub([In] ulong address, out int pbTransitionStub);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void IsOSSuspended([In] uint threadID, out int pbSuspended);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetThreadContext([In] uint threadID, [In] uint contextSize, [In, ComAliasName("BYTE*")] IntPtr context);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void SetThreadContext([In] uint threadID, [In] uint contextSize, [In, ComAliasName("BYTE*")] IntPtr context);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ReadMemory([In] ulong address, [In] uint size, [Out, MarshalAs(UnmanagedType.LPArray)] byte[] buffer, [ComAliasName("SIZE_T*")] out IntPtr read);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void WriteMemory([In] ulong address, [In] uint size, [In, MarshalAs(UnmanagedType.LPArray)] byte[] buffer, [ComAliasName("SIZE_T*")] out IntPtr written);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ClearCurrentException([In] uint threadID);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EnableLogMessages([In] int fOnOff);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ModifyLogSwitch([In, MarshalAs(UnmanagedType.LPWStr)] string pLogSwitchName, [In] int lLevel);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EnumerateAppDomains([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomainEnum ppAppDomains);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ThreadForFiberCookie([In] uint fiberCookie, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetHelperThreadID(out uint pThreadID);
    }
}
