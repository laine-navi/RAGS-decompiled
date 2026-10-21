using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[TypeLibType(4160)]
[Guid("2A2E0DA3-19FA-4F82-BE18-CD7D7A3B977F")]
public interface IWMPNowDoingDispatch
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3217)]
	void buyContent();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3218)]
	void hideBasket();

	[DispId(3219)]
	int DPI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3219)]
		get;
	}

	[DispId(3200)]
	string mode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3200)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3206)]
	int burn_selectedDrive
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3206)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3206)]
		[param: In]
		set;
	}

	[DispId(3214)]
	int sync_selectedDevice
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3214)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3214)]
		[param: In]
		set;
	}

	[DispId(3208)]
	int burn_numDiscsSpanned
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3208)]
		get;
	}

	[DispId(3221)]
	object editPlaylist
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3221)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(3201)]
	string burn_mediaType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3201)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3202)]
	string burn_contentType
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3202)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3203)]
	int burn_freeSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3203)]
		get;
	}

	[DispId(3204)]
	int burn_totalSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3204)]
		get;
	}

	[DispId(3205)]
	string burn_driveName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3205)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3207)]
	int burn_numDevices
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3207)]
		get;
	}

	[DispId(3209)]
	int burn_spaceToUse
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3209)]
		get;
	}

	[DispId(3210)]
	int sync_spaceToUse
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3210)]
		get;
	}

	[DispId(3211)]
	int sync_spaceUsed
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3211)]
		get;
	}

	[DispId(3212)]
	int sync_totalSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3212)]
		get;
	}

	[DispId(3213)]
	string sync_deviceName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3213)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3215)]
	int sync_numDevices
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3215)]
		get;
	}

	[DispId(3216)]
	string sync_oemName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3216)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3220)]
	void logData([In][MarshalAs(UnmanagedType.BStr)] string ID, [In][MarshalAs(UnmanagedType.BStr)] string data);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3222)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string formatTime([In] int value);
}
