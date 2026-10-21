using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("FF4B1BDA-19F0-42CF-8DDA-19162950C543")]
[TypeLibType(4160)]
public interface IWMPDMRRenderingControlService
{
	[DispId(1)]
	string LastChange
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2)]
	string PresetNameList
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3)]
	bool mute
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		get;
	}

	[DispId(4)]
	ushort volume
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		get;
	}

	[DispId(5)]
	string A_ARG_TYPE_Channel
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(6)]
	uint A_ARG_TYPE_InstanceID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		get;
	}

	[DispId(7)]
	string A_ARG_TYPE_PresetName
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(8)]
	void ListPresets([In] uint ulInstanceID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrCurrentPresetList);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(9)]
	void SelectPreset([In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrPresetName);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(10)]
	void GetMute([In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrChannel, [In][Out] ref bool pbCurrentMute);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(11)]
	void SetMute([In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrChannel, [In] bool bDesiredMute);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(12)]
	void GetVolume([In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrChannel, [In][Out] ref ushort puiCurrentVolume);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(13)]
	void SetVolume([In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrChannel, [In] ushort uiDesiredVolume);
}
