namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, TypeLibType((short) 2), ClassInterface((short) 0), Guid("6fef44d0-39e7-4c77-be8e-c9f8cf988630")]
    public class CorDebugClass : ICorDebug, CorDebug
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void CanLaunchOrAttach([In] uint dwProcessId, [In] int win32DebuggingEnabled);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void CreateProcess([In, MarshalAs(UnmanagedType.LPWStr)] string lpApplicationName, [In, MarshalAs(UnmanagedType.LPWStr)] string lpCommandLine, [In] SECURITY_ATTRIBUTES lpProcessAttributes, [In] SECURITY_ATTRIBUTES lpThreadAttributes, [In] int bInheritHandles, [In] uint dwCreationFlags, [In] IntPtr lpEnvironment, [In, MarshalAs(UnmanagedType.LPWStr)] string lpCurrentDirectory, [In] STARTUPINFO lpStartupInfo, [In] PROCESS_INFORMATION lpProcessInformation, [In] CorDebugCreateProcessFlags debuggingFlags, [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void DebugActiveProcess([In] uint id, [In] int win32Attach, [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void EnumerateProcesses([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcessEnum ppProcess);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void GetProcess([In] uint dwProcessId, [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void Initialize();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void SetManagedHandler([In, MarshalAs(UnmanagedType.Interface)] ICorDebugManagedCallback pCallback);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void SetUnmanagedHandler([In, MarshalAs(UnmanagedType.Interface)] ICorDebugUnmanagedCallback pCallback);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        public virtual extern void Terminate();
    }
}
