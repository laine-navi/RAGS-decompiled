using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("2A2E0DA3-19FA-4F82-BE18-CD7D7A3B977F")]
[TypeLibType(4160)]
public interface IWMPNowDoingDispatch
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3221)]
	void buyContent();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3222)]
	void hideBasket();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3211)]
	void burnNavigateToStatus();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3220)]
	void syncNavigateToStatus();

	[DispId(3223)]
	int DPI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3223)]
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

	[DispId(3216)]
	int sync_selectedDevice
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3216)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3216)]
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

	[DispId(3225)]
	object editPlaylist
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3225)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}

	[DispId(3227)]
	string basketPlaylistName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3227)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3228)]
	bool isHighContrastMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3228)]
		get;
	}

	[DispId(3229)]
	bool allowRating
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3229)]
		get;
	}

	[DispId(3230)]
	bool allowShop
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3230)]
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
	int burn_percentComplete
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3210)]
		get;
	}

	[DispId(3212)]
	int sync_spaceToUse
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3212)]
		get;
	}

	[DispId(3213)]
	int sync_spaceUsed
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3213)]
		get;
	}

	[DispId(3214)]
	int sync_totalSpace
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3214)]
		get;
	}

	[DispId(3215)]
	string sync_deviceName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3215)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3217)]
	int sync_numDevices
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3217)]
		get;
	}

	[DispId(3218)]
	string sync_oemName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3218)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3219)]
	int sync_percentComplete
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3219)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3224)]
	void logData([In][MarshalAs(UnmanagedType.BStr)] string ID, [In][MarshalAs(UnmanagedType.BStr)] string data);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(3226)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string formatTime([In] int value);
}
