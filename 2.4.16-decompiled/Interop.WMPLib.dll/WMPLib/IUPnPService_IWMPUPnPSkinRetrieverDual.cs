using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("AC743628-971D-4C1E-B019-50543EFE2BAD")]
public interface IUPnPService_IWMPUPnPSkinRetrieverDual
{
	[DispId(1)]
	string SkinURL
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(2)]
	void GetSkinURL([In][Out][MarshalAs(UnmanagedType.BStr)] ref string ppbstrSkinURL);
}
