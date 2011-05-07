namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [ComImport, Guid("426D1F9E-6DD4-44C8-AEC7-26CDBAF4E398"), InterfaceType((short) 1)]
    public interface ICorDebugAssembly2
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType=MethodCodeType.Runtime)]
        void IsFullyTrusted(out int pbFullyTrusted);
    }
}
