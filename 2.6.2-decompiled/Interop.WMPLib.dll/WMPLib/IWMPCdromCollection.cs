using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("EE4C8FE2-34B2-11D3-A3BF-006097C9B344")]
public interface IWMPCdromCollection
{
	[DispId(301)]
	int count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(301)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(302)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPCdrom Item([In] int lIndex);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(303)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPCdrom getByDriveSpecifier([In][MarshalAs(UnmanagedType.BStr)] string bstrDriveSpecifier);
}
