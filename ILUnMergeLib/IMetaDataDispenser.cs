using System;
using System.Runtime.InteropServices;

namespace ACATool.Internal
{
	// We can use reflection-only load context to use reflection to query for metadata information rather
	// than painfully import the com-classic metadata interfaces.
	[Guid("809c652e-7396-11d2-9771-00a0c9b4d50c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IMetaDataDispenser
	{
		// We need to be able to call OpenScope, which is the 2nd vtable slot.
		// Thus we need this one placeholder here to occupy the first slot..
		void DefineScope_Placeholder();

		//STDMETHOD(OpenScope)(                   // Return code.
		//LPCWSTR     szScope,                // [in] The scope to open.
		//  DWORD       dwOpenFlags,            // [in] Open mode flags.
		//  REFIID      riid,                   // [in] The interface desired.
		//  IUnknown    **ppIUnk) PURE;         // [out] Return interface on success.
		void OpenScope([In, MarshalAs(UnmanagedType.LPWStr)] String szScope, [In] Int32 dwOpenFlags, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out Object punk);

		// Don't need any other methods.
	}

	// Since we're just blindly passing this interface through managed code to the Symbinder, we don't care about actually
	// importing the specific methods.
	// This needs to be public so that we can call Marshal.GetComInterfaceForObject() on it to get the
	// underlying metadata pointer.
	[Guid("7DAC8207-D3AE-4c75-9B67-92801A497D44"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	// [CLSCompliant(true)]
    [Obsolete()]
    public interface IMetadataImport
    {
        // Just need a single placeholder method so that it doesn't complain about an empty interface.
        void Placeholder();
    }

}
	