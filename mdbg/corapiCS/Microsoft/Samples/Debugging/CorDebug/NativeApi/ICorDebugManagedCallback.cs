namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    [ComImport, InterfaceType((short) 1), Guid("3D6F5F60-7538-11D3-8D5B-00104B35E7EF")]
    public interface ICorDebugManagedCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Breakpoint([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugBreakpoint pBreakpoint);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void StepComplete([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugStepper pStepper, [In] CorDebugStepReason reason);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Break([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Exception([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In] int unhandled);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EvalComplete([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugEval pEval);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EvalException([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugEval pEval);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateProcess([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ExitProcess([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateThread([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ExitThread([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread thread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void LoadModule([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugModule pModule);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void UnloadModule([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugModule pModule);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void LoadClass([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass c);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void UnloadClass([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass c);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void DebuggerError([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess, [In, MarshalAs(UnmanagedType.Error)] int errorHR, [In] uint errorCode);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void LogMessage([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In] int lLevel, [In, MarshalAs(UnmanagedType.LPWStr)] string pLogSwitchName, [In, MarshalAs(UnmanagedType.LPWStr)] string pMessage);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void LogSwitch([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In] int lLevel, [In] uint ulReason, [In, MarshalAs(UnmanagedType.LPWStr)] string pLogSwitchName, [In, MarshalAs(UnmanagedType.LPWStr)] string pParentName);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateAppDomain([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ExitAppDomain([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void LoadAssembly([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAssembly pAssembly);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void UnloadAssembly([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugAssembly pAssembly);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void ControlCTrap([In, MarshalAs(UnmanagedType.Interface)] ICorDebugProcess pProcess);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NameChange([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void UpdateModuleSymbols([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugModule pModule, [In, MarshalAs(UnmanagedType.Interface)] IStream pSymbolStream);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void EditAndContinueRemap([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pFunction, [In] int fAccurate);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void BreakpointSetError([In, MarshalAs(UnmanagedType.Interface)] ICorDebugAppDomain pAppDomain, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugThread pThread, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugBreakpoint pBreakpoint, [In] uint dwError);
    }
}
