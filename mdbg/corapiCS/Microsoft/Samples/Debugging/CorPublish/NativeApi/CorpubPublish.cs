namespace Microsoft.Samples.Debugging.CorPublish.NativeApi
{
    using System.Runtime.InteropServices;

    [ComImport, Guid("9613A0E7-5A68-11D3-8F84-00A0C9B4D50C"), CoClass(typeof(CorpubPublishClass))]
    public interface CorpubPublish : ICorPublish
    {
    }
}
