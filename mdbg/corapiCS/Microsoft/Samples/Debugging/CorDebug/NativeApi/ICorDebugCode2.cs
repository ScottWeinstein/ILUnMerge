namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("5F696509-452F-4436-A3FE-4D11FE7E2347"), ComConversionLoss, InterfaceType((short) 1)]
    public interface ICorDebugCode2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetCodeChunks([In] uint cbufSize, out uint pcnumChunks, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] _CodeChunkInfo[] chunks);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void GetCompilerFlags(out uint pdwFlags);
    }
}
