using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("4A976298-8C0D-11D3-B389-00C04F68574B")]
public interface IWMPStringCollection
{
	[DispId(401)]
	int count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(401)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(402)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string Item([In] int lIndex);
}
