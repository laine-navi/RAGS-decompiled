using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[InterfaceType(1)]
[Guid("1F504270-A66B-4223-8E96-26A06C63D69F")]
public interface IWMPEvents3 : IWMPEvents2
{
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void OpenStateChange([In] int NewState);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlayStateChange([In] int NewState);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void AudioLanguageChange([In] int LangID);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void StatusChange();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void ScriptCommand([In][MarshalAs(UnmanagedType.BStr)] string scType, [In][MarshalAs(UnmanagedType.BStr)] string Param);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void NewStream();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Disconnect([In] int Result);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Buffering([In] bool Start);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Error();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Warning([In] int WarningType, [In] int Param, [In][MarshalAs(UnmanagedType.BStr)] string Description);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void EndOfStream([In] int Result);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PositionChange([In] double oldPosition, [In] double newPosition);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MarkerHit([In] int MarkerNum);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DurationUnitChange([In] int NewDurationUnit);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CdromMediaChange([In] int CdromNum);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlaylistChange([In][MarshalAs(UnmanagedType.IDispatch)] object Playlist, [In] WMPPlaylistChangeEventType change);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CurrentPlaylistChange([In] WMPPlaylistChangeEventType change);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CurrentPlaylistItemAvailable([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MediaChange([In][MarshalAs(UnmanagedType.IDispatch)] object Item);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CurrentMediaItemAvailable([In][MarshalAs(UnmanagedType.BStr)] string bstrItemName);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CurrentItemChange([In][MarshalAs(UnmanagedType.IDispatch)] object pdispMedia);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MediaCollectionChange();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MediaCollectionAttributeStringAdded([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribName, [In][MarshalAs(UnmanagedType.BStr)] string bstrAttribVal);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MediaCollectionAttributeStringRemoved([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribName, [In][MarshalAs(UnmanagedType.BStr)] string bstrAttribVal);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MediaCollectionAttributeStringChanged([In][MarshalAs(UnmanagedType.BStr)] string bstrAttribName, [In][MarshalAs(UnmanagedType.BStr)] string bstrOldAttribVal, [In][MarshalAs(UnmanagedType.BStr)] string bstrNewAttribVal);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlaylistCollectionChange();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlaylistCollectionPlaylistAdded([In][MarshalAs(UnmanagedType.BStr)] string bstrPlaylistName);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlaylistCollectionPlaylistRemoved([In][MarshalAs(UnmanagedType.BStr)] string bstrPlaylistName);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlaylistCollectionPlaylistSetAsDeleted([In][MarshalAs(UnmanagedType.BStr)] string bstrPlaylistName, [In] bool varfIsDeleted);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void ModeChange([In][MarshalAs(UnmanagedType.BStr)] string ModeName, [In] bool NewValue);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MediaError([In][MarshalAs(UnmanagedType.IDispatch)] object pMediaObject);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void OpenPlaylistSwitch([In][MarshalAs(UnmanagedType.IDispatch)] object pItem);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DomainChange([In][MarshalAs(UnmanagedType.BStr)] string strDomain);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void SwitchedToPlayerApplication();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void SwitchedToControl();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlayerDockedStateChange();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void PlayerReconnect();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void Click([In] short nButton, [In] short nShiftState, [In] int fX, [In] int fY);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DoubleClick([In] short nButton, [In] short nShiftState, [In] int fX, [In] int fY);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void KeyDown([In] short nKeyCode, [In] short nShiftState);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void KeyPress([In] short nKeyAscii);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void KeyUp([In] short nKeyCode, [In] short nShiftState);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MouseDown([In] short nButton, [In] short nShiftState, [In] int fX, [In] int fY);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MouseMove([In] short nButton, [In] short nShiftState, [In] int fX, [In] int fY);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void MouseUp([In] short nButton, [In] short nShiftState, [In] int fX, [In] int fY);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DeviceConnect([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DeviceDisconnect([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DeviceStatusChange([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice, [In] WMPDeviceStatus NewStatus);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DeviceSyncStateChange([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice, [In] WMPSyncState NewState);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void DeviceSyncError([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice, [In][MarshalAs(UnmanagedType.IDispatch)] object pMedia);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	new void CreatePartnershipComplete([In][MarshalAs(UnmanagedType.Interface)] IWMPSyncDevice pDevice, [In][MarshalAs(UnmanagedType.Error)] int hrResult);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CdromRipStateChange([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromRip pCdromRip, [In] WMPRipState wmprs);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CdromRipMediaError([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromRip pCdromRip, [In][MarshalAs(UnmanagedType.IDispatch)] object pMedia);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CdromBurnStateChange([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromBurn pCdromBurn, [In] WMPBurnState wmpbs);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CdromBurnMediaError([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromBurn pCdromBurn, [In][MarshalAs(UnmanagedType.IDispatch)] object pMedia);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void CdromBurnError([In][MarshalAs(UnmanagedType.Interface)] IWMPCdromBurn pCdromBurn, [In][MarshalAs(UnmanagedType.Error)] int hrError);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LibraryConnect([In][MarshalAs(UnmanagedType.Interface)] IWMPLibrary pLibrary);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void LibraryDisconnect([In][MarshalAs(UnmanagedType.Interface)] IWMPLibrary pLibrary);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void FolderScanStateChange([In] WMPFolderScanState wmpfss);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void StringCollectionChange([In][MarshalAs(UnmanagedType.IDispatch)] object pdispStringCollection, [In] WMPStringCollectionChangeEventType change, [In] int lCollectionIndex);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void MediaCollectionMediaAdded([In][MarshalAs(UnmanagedType.IDispatch)] object pdispMedia);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void MediaCollectionMediaRemoved([In][MarshalAs(UnmanagedType.IDispatch)] object pdispMedia);
}
