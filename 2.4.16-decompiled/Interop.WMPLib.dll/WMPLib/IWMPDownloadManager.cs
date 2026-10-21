using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("E15E9AD1-8F20-4CC4-9EC7-1A328CA86A0D")]
public interface IWMPDownloadManager
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1151)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPDownloadCollection getDownloadCollection([In] int lCollectionId);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1152)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPDownloadCollection createDownloadCollection();
}
