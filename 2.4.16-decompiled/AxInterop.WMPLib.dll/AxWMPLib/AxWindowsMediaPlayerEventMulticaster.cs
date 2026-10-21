using System;
using System.Runtime.InteropServices;
using WMPLib;

namespace AxWMPLib;

[ClassInterface(ClassInterfaceType.None)]
public class AxWindowsMediaPlayerEventMulticaster : _WMPOCXEvents
{
	private AxWindowsMediaPlayer parent;

	public AxWindowsMediaPlayerEventMulticaster(AxWindowsMediaPlayer parent)
	{
		this.parent = parent;
	}

	public virtual void CdromBurnError(IWMPCdromBurn pCdromBurn, int hrError)
	{
		_WMPOCXEvents_CdromBurnErrorEvent e = new _WMPOCXEvents_CdromBurnErrorEvent(pCdromBurn, hrError);
		parent.RaiseOnCdromBurnError(parent, e);
	}

	public virtual void LibraryConnect(IWMPLibrary pLibrary)
	{
		_WMPOCXEvents_LibraryConnectEvent e = new _WMPOCXEvents_LibraryConnectEvent(pLibrary);
		parent.RaiseOnLibraryConnect(parent, e);
	}

	public virtual void LibraryDisconnect(IWMPLibrary pLibrary)
	{
		_WMPOCXEvents_LibraryDisconnectEvent e = new _WMPOCXEvents_LibraryDisconnectEvent(pLibrary);
		parent.RaiseOnLibraryDisconnect(parent, e);
	}

	public virtual void FolderScanStateChange(WMPFolderScanState wmpfss)
	{
		_WMPOCXEvents_FolderScanStateChangeEvent e = new _WMPOCXEvents_FolderScanStateChangeEvent(wmpfss);
		parent.RaiseOnFolderScanStateChange(parent, e);
	}

	public virtual void StringCollectionChange(object pdispStringCollection, WMPStringCollectionChangeEventType change, int lCollectionIndex)
	{
		_WMPOCXEvents_StringCollectionChangeEvent e = new _WMPOCXEvents_StringCollectionChangeEvent(pdispStringCollection, change, lCollectionIndex);
		parent.RaiseOnStringCollectionChange(parent, e);
	}

	public virtual void MediaCollectionMediaAdded(object pdispMedia)
	{
		_WMPOCXEvents_MediaCollectionMediaAddedEvent e = new _WMPOCXEvents_MediaCollectionMediaAddedEvent(pdispMedia);
		parent.RaiseOnMediaCollectionMediaAdded(parent, e);
	}

	public virtual void MediaCollectionMediaRemoved(object pdispMedia)
	{
		_WMPOCXEvents_MediaCollectionMediaRemovedEvent e = new _WMPOCXEvents_MediaCollectionMediaRemovedEvent(pdispMedia);
		parent.RaiseOnMediaCollectionMediaRemoved(parent, e);
	}

	public virtual void PlaylistCollectionPlaylistSetAsDeleted(string bstrPlaylistName, bool varfIsDeleted)
	{
		_WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEvent e = new _WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEvent(bstrPlaylistName, varfIsDeleted);
		parent.RaiseOnPlaylistCollectionPlaylistSetAsDeleted(parent, e);
	}

	public virtual void ModeChange(string modeName, bool newValue)
	{
		_WMPOCXEvents_ModeChangeEvent e = new _WMPOCXEvents_ModeChangeEvent(modeName, newValue);
		parent.RaiseOnModeChange(parent, e);
	}

	public virtual void MediaError(object pMediaObject)
	{
		_WMPOCXEvents_MediaErrorEvent e = new _WMPOCXEvents_MediaErrorEvent(pMediaObject);
		parent.RaiseOnMediaError(parent, e);
	}

	public virtual void OpenPlaylistSwitch(object pItem)
	{
		_WMPOCXEvents_OpenPlaylistSwitchEvent e = new _WMPOCXEvents_OpenPlaylistSwitchEvent(pItem);
		parent.RaiseOnOpenPlaylistSwitch(parent, e);
	}

	public virtual void DomainChange(string strDomain)
	{
		_WMPOCXEvents_DomainChangeEvent e = new _WMPOCXEvents_DomainChangeEvent(strDomain);
		parent.RaiseOnDomainChange(parent, e);
	}

	public virtual void SwitchedToPlayerApplication()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnSwitchedToPlayerApplication(parent, e);
	}

	public virtual void SwitchedToControl()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnSwitchedToControl(parent, e);
	}

	public virtual void PlayerDockedStateChange()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnPlayerDockedStateChange(parent, e);
	}

	public virtual void PlayerReconnect()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnPlayerReconnect(parent, e);
	}

	public virtual void Click(short nButton, short nShiftState, int fX, int fY)
	{
		_WMPOCXEvents_ClickEvent e = new _WMPOCXEvents_ClickEvent(nButton, nShiftState, fX, fY);
		parent.RaiseOnClickEvent(parent, e);
	}

	public virtual void DoubleClick(short nButton, short nShiftState, int fX, int fY)
	{
		_WMPOCXEvents_DoubleClickEvent e = new _WMPOCXEvents_DoubleClickEvent(nButton, nShiftState, fX, fY);
		parent.RaiseOnDoubleClickEvent(parent, e);
	}

	public virtual void KeyDown(short nKeyCode, short nShiftState)
	{
		_WMPOCXEvents_KeyDownEvent e = new _WMPOCXEvents_KeyDownEvent(nKeyCode, nShiftState);
		parent.RaiseOnKeyDownEvent(parent, e);
	}

	public virtual void KeyPress(short nKeyAscii)
	{
		_WMPOCXEvents_KeyPressEvent e = new _WMPOCXEvents_KeyPressEvent(nKeyAscii);
		parent.RaiseOnKeyPressEvent(parent, e);
	}

	public virtual void KeyUp(short nKeyCode, short nShiftState)
	{
		_WMPOCXEvents_KeyUpEvent e = new _WMPOCXEvents_KeyUpEvent(nKeyCode, nShiftState);
		parent.RaiseOnKeyUpEvent(parent, e);
	}

	public virtual void MouseDown(short nButton, short nShiftState, int fX, int fY)
	{
		_WMPOCXEvents_MouseDownEvent e = new _WMPOCXEvents_MouseDownEvent(nButton, nShiftState, fX, fY);
		parent.RaiseOnMouseDownEvent(parent, e);
	}

	public virtual void MouseMove(short nButton, short nShiftState, int fX, int fY)
	{
		_WMPOCXEvents_MouseMoveEvent e = new _WMPOCXEvents_MouseMoveEvent(nButton, nShiftState, fX, fY);
		parent.RaiseOnMouseMoveEvent(parent, e);
	}

	public virtual void MouseUp(short nButton, short nShiftState, int fX, int fY)
	{
		_WMPOCXEvents_MouseUpEvent e = new _WMPOCXEvents_MouseUpEvent(nButton, nShiftState, fX, fY);
		parent.RaiseOnMouseUpEvent(parent, e);
	}

	public virtual void DeviceConnect(IWMPSyncDevice pDevice)
	{
		_WMPOCXEvents_DeviceConnectEvent e = new _WMPOCXEvents_DeviceConnectEvent(pDevice);
		parent.RaiseOnDeviceConnect(parent, e);
	}

	public virtual void DeviceDisconnect(IWMPSyncDevice pDevice)
	{
		_WMPOCXEvents_DeviceDisconnectEvent e = new _WMPOCXEvents_DeviceDisconnectEvent(pDevice);
		parent.RaiseOnDeviceDisconnect(parent, e);
	}

	public virtual void DeviceStatusChange(IWMPSyncDevice pDevice, WMPDeviceStatus newStatus)
	{
		_WMPOCXEvents_DeviceStatusChangeEvent e = new _WMPOCXEvents_DeviceStatusChangeEvent(pDevice, newStatus);
		parent.RaiseOnDeviceStatusChange(parent, e);
	}

	public virtual void DeviceSyncStateChange(IWMPSyncDevice pDevice, WMPSyncState newState)
	{
		_WMPOCXEvents_DeviceSyncStateChangeEvent e = new _WMPOCXEvents_DeviceSyncStateChangeEvent(pDevice, newState);
		parent.RaiseOnDeviceSyncStateChange(parent, e);
	}

	public virtual void DeviceSyncError(IWMPSyncDevice pDevice, object pMedia)
	{
		_WMPOCXEvents_DeviceSyncErrorEvent e = new _WMPOCXEvents_DeviceSyncErrorEvent(pDevice, pMedia);
		parent.RaiseOnDeviceSyncError(parent, e);
	}

	public virtual void CreatePartnershipComplete(IWMPSyncDevice pDevice, int hrResult)
	{
		_WMPOCXEvents_CreatePartnershipCompleteEvent e = new _WMPOCXEvents_CreatePartnershipCompleteEvent(pDevice, hrResult);
		parent.RaiseOnCreatePartnershipComplete(parent, e);
	}

	public virtual void DeviceEstimation(IWMPSyncDevice pDevice, int hrResult, long qwEstimatedUsedSpace, long qwEstimatedSpace)
	{
		_WMPOCXEvents_DeviceEstimationEvent e = new _WMPOCXEvents_DeviceEstimationEvent(pDevice, hrResult, qwEstimatedUsedSpace, qwEstimatedSpace);
		parent.RaiseOnDeviceEstimation(parent, e);
	}

	public virtual void CdromRipStateChange(IWMPCdromRip pCdromRip, WMPRipState wmprs)
	{
		_WMPOCXEvents_CdromRipStateChangeEvent e = new _WMPOCXEvents_CdromRipStateChangeEvent(pCdromRip, wmprs);
		parent.RaiseOnCdromRipStateChange(parent, e);
	}

	public virtual void CdromRipMediaError(IWMPCdromRip pCdromRip, object pMedia)
	{
		_WMPOCXEvents_CdromRipMediaErrorEvent e = new _WMPOCXEvents_CdromRipMediaErrorEvent(pCdromRip, pMedia);
		parent.RaiseOnCdromRipMediaError(parent, e);
	}

	public virtual void CdromBurnStateChange(IWMPCdromBurn pCdromBurn, WMPBurnState wmpbs)
	{
		_WMPOCXEvents_CdromBurnStateChangeEvent e = new _WMPOCXEvents_CdromBurnStateChangeEvent(pCdromBurn, wmpbs);
		parent.RaiseOnCdromBurnStateChange(parent, e);
	}

	public virtual void CdromBurnMediaError(IWMPCdromBurn pCdromBurn, object pMedia)
	{
		_WMPOCXEvents_CdromBurnMediaErrorEvent e = new _WMPOCXEvents_CdromBurnMediaErrorEvent(pCdromBurn, pMedia);
		parent.RaiseOnCdromBurnMediaError(parent, e);
	}

	public virtual void OpenStateChange(int newState)
	{
		_WMPOCXEvents_OpenStateChangeEvent e = new _WMPOCXEvents_OpenStateChangeEvent(newState);
		parent.RaiseOnOpenStateChange(parent, e);
	}

	public virtual void PlayStateChange(int newState)
	{
		_WMPOCXEvents_PlayStateChangeEvent e = new _WMPOCXEvents_PlayStateChangeEvent(newState);
		parent.RaiseOnPlayStateChange(parent, e);
	}

	public virtual void AudioLanguageChange(int langID)
	{
		_WMPOCXEvents_AudioLanguageChangeEvent e = new _WMPOCXEvents_AudioLanguageChangeEvent(langID);
		parent.RaiseOnAudioLanguageChange(parent, e);
	}

	public virtual void StatusChange()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnStatusChange(parent, e);
	}

	public virtual void ScriptCommand(string scType, string param)
	{
		_WMPOCXEvents_ScriptCommandEvent e = new _WMPOCXEvents_ScriptCommandEvent(scType, param);
		parent.RaiseOnScriptCommand(parent, e);
	}

	public virtual void NewStream()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnNewStream(parent, e);
	}

	public virtual void Disconnect(int result)
	{
		_WMPOCXEvents_DisconnectEvent e = new _WMPOCXEvents_DisconnectEvent(result);
		parent.RaiseOnDisconnect(parent, e);
	}

	public virtual void Buffering(bool start)
	{
		_WMPOCXEvents_BufferingEvent e = new _WMPOCXEvents_BufferingEvent(start);
		parent.RaiseOnBuffering(parent, e);
	}

	public virtual void Error()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnErrorEvent(parent, e);
	}

	public virtual void Warning(int warningType, int param, string description)
	{
		_WMPOCXEvents_WarningEvent e = new _WMPOCXEvents_WarningEvent(warningType, param, description);
		parent.RaiseOnWarning(parent, e);
	}

	public virtual void EndOfStream(int result)
	{
		_WMPOCXEvents_EndOfStreamEvent e = new _WMPOCXEvents_EndOfStreamEvent(result);
		parent.RaiseOnEndOfStream(parent, e);
	}

	public virtual void PositionChange(double oldPosition, double newPosition)
	{
		_WMPOCXEvents_PositionChangeEvent e = new _WMPOCXEvents_PositionChangeEvent(oldPosition, newPosition);
		parent.RaiseOnPositionChange(parent, e);
	}

	public virtual void MarkerHit(int markerNum)
	{
		_WMPOCXEvents_MarkerHitEvent e = new _WMPOCXEvents_MarkerHitEvent(markerNum);
		parent.RaiseOnMarkerHit(parent, e);
	}

	public virtual void DurationUnitChange(int newDurationUnit)
	{
		_WMPOCXEvents_DurationUnitChangeEvent e = new _WMPOCXEvents_DurationUnitChangeEvent(newDurationUnit);
		parent.RaiseOnDurationUnitChange(parent, e);
	}

	public virtual void CdromMediaChange(int cdromNum)
	{
		_WMPOCXEvents_CdromMediaChangeEvent e = new _WMPOCXEvents_CdromMediaChangeEvent(cdromNum);
		parent.RaiseOnCdromMediaChange(parent, e);
	}

	public virtual void PlaylistChange(object playlist, WMPPlaylistChangeEventType change)
	{
		_WMPOCXEvents_PlaylistChangeEvent e = new _WMPOCXEvents_PlaylistChangeEvent(playlist, change);
		parent.RaiseOnPlaylistChange(parent, e);
	}

	public virtual void CurrentPlaylistChange(WMPPlaylistChangeEventType change)
	{
		_WMPOCXEvents_CurrentPlaylistChangeEvent e = new _WMPOCXEvents_CurrentPlaylistChangeEvent(change);
		parent.RaiseOnCurrentPlaylistChange(parent, e);
	}

	public virtual void CurrentPlaylistItemAvailable(string bstrItemName)
	{
		_WMPOCXEvents_CurrentPlaylistItemAvailableEvent e = new _WMPOCXEvents_CurrentPlaylistItemAvailableEvent(bstrItemName);
		parent.RaiseOnCurrentPlaylistItemAvailable(parent, e);
	}

	public virtual void MediaChange(object item)
	{
		_WMPOCXEvents_MediaChangeEvent e = new _WMPOCXEvents_MediaChangeEvent(item);
		parent.RaiseOnMediaChange(parent, e);
	}

	public virtual void CurrentMediaItemAvailable(string bstrItemName)
	{
		_WMPOCXEvents_CurrentMediaItemAvailableEvent e = new _WMPOCXEvents_CurrentMediaItemAvailableEvent(bstrItemName);
		parent.RaiseOnCurrentMediaItemAvailable(parent, e);
	}

	public virtual void CurrentItemChange(object pdispMedia)
	{
		_WMPOCXEvents_CurrentItemChangeEvent e = new _WMPOCXEvents_CurrentItemChangeEvent(pdispMedia);
		parent.RaiseOnCurrentItemChange(parent, e);
	}

	public virtual void MediaCollectionChange()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnMediaCollectionChange(parent, e);
	}

	public virtual void MediaCollectionAttributeStringAdded(string bstrAttribName, string bstrAttribVal)
	{
		_WMPOCXEvents_MediaCollectionAttributeStringAddedEvent e = new _WMPOCXEvents_MediaCollectionAttributeStringAddedEvent(bstrAttribName, bstrAttribVal);
		parent.RaiseOnMediaCollectionAttributeStringAdded(parent, e);
	}

	public virtual void MediaCollectionAttributeStringRemoved(string bstrAttribName, string bstrAttribVal)
	{
		_WMPOCXEvents_MediaCollectionAttributeStringRemovedEvent e = new _WMPOCXEvents_MediaCollectionAttributeStringRemovedEvent(bstrAttribName, bstrAttribVal);
		parent.RaiseOnMediaCollectionAttributeStringRemoved(parent, e);
	}

	public virtual void MediaCollectionAttributeStringChanged(string bstrAttribName, string bstrOldAttribVal, string bstrNewAttribVal)
	{
		_WMPOCXEvents_MediaCollectionAttributeStringChangedEvent e = new _WMPOCXEvents_MediaCollectionAttributeStringChangedEvent(bstrAttribName, bstrOldAttribVal, bstrNewAttribVal);
		parent.RaiseOnMediaCollectionAttributeStringChanged(parent, e);
	}

	public virtual void PlaylistCollectionChange()
	{
		EventArgs e = new EventArgs();
		parent.RaiseOnPlaylistCollectionChange(parent, e);
	}

	public virtual void PlaylistCollectionPlaylistAdded(string bstrPlaylistName)
	{
		_WMPOCXEvents_PlaylistCollectionPlaylistAddedEvent e = new _WMPOCXEvents_PlaylistCollectionPlaylistAddedEvent(bstrPlaylistName);
		parent.RaiseOnPlaylistCollectionPlaylistAdded(parent, e);
	}

	public virtual void PlaylistCollectionPlaylistRemoved(string bstrPlaylistName)
	{
		_WMPOCXEvents_PlaylistCollectionPlaylistRemovedEvent e = new _WMPOCXEvents_PlaylistCollectionPlaylistRemovedEvent(bstrPlaylistName);
		parent.RaiseOnPlaylistCollectionPlaylistRemoved(parent, e);
	}
}
