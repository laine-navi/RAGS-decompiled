using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("76F13F00-6E17-4D98-BE2D-D2A84CFF5BFD")]
public interface IWMPRemoteUPnPDevice
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10131)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string friendlyName();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10132)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object FindService([In][MarshalAs(UnmanagedType.BStr)] string bstrService);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10133)]
	void getDevice([MarshalAs(UnmanagedType.IUnknown)] ref object ppDevice);
}
