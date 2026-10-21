using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("CFAB6E98-8730-11D3-B388-00C04F68574B")]
[TypeLibType(4160)]
public interface IWMPCdrom
{
	[DispId(251)]
	string driveSpecifier
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(251)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(252)]
	IWMPPlaylist Playlist
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(252)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(253)]
	void eject();
}
