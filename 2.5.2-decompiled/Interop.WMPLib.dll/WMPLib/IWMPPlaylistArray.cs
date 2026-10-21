using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("679409C0-99F7-11D3-9FB7-00105AA620BB")]
[TypeLibType(4160)]
public interface IWMPPlaylistArray
{
	[DispId(501)]
	int count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(501)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(502)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPPlaylist Item([In] int lIndex);
}
