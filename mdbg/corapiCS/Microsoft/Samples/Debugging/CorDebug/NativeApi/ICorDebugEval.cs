namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, InterfaceType((short) 1), Guid("CC7BCAF6-8A68-11D2-983C-0000F808342D")]
    public interface ICorDebugEval
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CallFunction([In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pFunction, [In] uint nArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] ICorDebugValue[] ppArgs);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewObject([In, MarshalAs(UnmanagedType.Interface)] ICorDebugFunction pConstructor, [In] uint nArgs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] ICorDebugValue[] ppArgs);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewObjectNoConstructor([In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass pClass);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewString([In, MarshalAs(UnmanagedType.LPWStr)] string @string);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void NewArray([In] CorElementType elementType, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass pElementClass, [In] uint rank, [In] ref uint dims, [In] ref uint lowBounds);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void IsActive(out int pbActive);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void Abort();
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetResult([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppResult);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void CreateValue([In] CorElementType elementType, [In, MarshalAs(UnmanagedType.Interface)] ICorDebugClass pElementClass, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}
