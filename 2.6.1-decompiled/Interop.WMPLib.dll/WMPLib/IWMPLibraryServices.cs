using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[InterfaceType(1)]
[TypeLibType(256)]
[Guid("39C2F8D5-1CF2-4D5E-AE09-D73492CF9EAA")]
public interface IWMPLibraryServices
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int getCountByType([In] WMPLibraryType wmplt);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPLibrary getLibraryByType([In] WMPLibraryType wmplt, [In] int lIndex);
}
