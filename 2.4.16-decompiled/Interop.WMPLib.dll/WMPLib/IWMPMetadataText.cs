using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("769A72DB-13D2-45E2-9C48-53CA9D5B7450")]
public interface IWMPMetadataText
{
	[DispId(1056)]
	string Description
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1056)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(1055)]
	string text
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1055)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}
}
