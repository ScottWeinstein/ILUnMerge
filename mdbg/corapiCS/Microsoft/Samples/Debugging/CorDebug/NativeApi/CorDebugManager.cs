namespace Microsoft.Samples.Debugging.CorDebug.NativeApi
{
    using System.Runtime.InteropServices;

    [ComImport, CoClass(typeof(CorDebugManagerClass)), Guid("3D6F5F61-7538-11D3-8D5B-00104B35E7EF")]
    public interface CorDebugManager : ICorDebug
    {
    }
}
