using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("0A319C7F-85F9-436C-B88E-82FD88000E1C")]
public interface IWMPDownloadCollection
{
	[DispId(1201)]
	int ID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1201)]
		get;
	}

	[DispId(1202)]
	int count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1202)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1203)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPDownloadItem2 Item([In] int lItem);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1204)]
	[return: MarshalAs(UnmanagedType.Interface)]
	IWMPDownloadItem2 startDownload([In][MarshalAs(UnmanagedType.BStr)] string bstrSourceURL, [In][MarshalAs(UnmanagedType.BStr)] string bstrType);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1205)]
	void removeItem([In] int lItem);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1206)]
	void clear();
}
