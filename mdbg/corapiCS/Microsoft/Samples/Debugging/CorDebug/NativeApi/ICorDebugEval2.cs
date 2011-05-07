namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("FB0D9CE7-BE66-4683-9D32-A42A04E2FD91")]
    public interface ICorDebugEval2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CallParameterizedFunction([In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pFunction, [In] uint nTypeArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] ICorDebugType[] ppTypeArgs, [In] uint nArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=3)] ICorDebugValue[] ppArgs);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateValueForType([In, MarshalAs(UnmanagedType.Interface)] ICorDebugType pType, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewParameterizedObject([In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pConstructor, [In] uint nTypeArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] ICorDebugType[] ppTypeArgs, [In] uint nArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=3)] ICorDebugValue[] ppArgs);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewParameterizedObjectNoConstructor([In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass pClass, [In] uint nTypeArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] ICorDebugType[] ppTypeArgs);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewParameterizedArray([In, MarshalAs(UnmanagedType.Interface)] ICorDebugType pElementType, [In] uint rank, [In] ref uint dims, [In] ref uint lowBounds);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewStringWithLength([In, MarshalAs(UnmanagedType.LPWStr)] string @string, [In] uint uiLength);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void RudeAbort();
    }
}
