using System.Runtime.InteropServices;

namespace WMPLib;

[TypeLibType(TypeLibTypeFlags.FHidden)]
[ClassInterface(ClassInterfaceType.None)]
public sealed class _WMPOCXEvents_SinkHelper : _WMPOCXEvents
{
	public _WMPOCXEvents_OpenStateChangeEventHandler m_OpenStateChangeDelegate;

	public _WMPOCXEvents_PlayStateChangeEventHandler m_PlayStateChangeDelegate;

	public _WMPOCXEvents_AudioLanguageChangeEventHandler m_AudioLanguageChangeDelegate;

	public _WMPOCXEvents_StatusChangeEventHandler m_StatusChangeDelegate;

	public _WMPOCXEvents_ScriptCommandEventHandler m_ScriptCommandDelegate;

	public _WMPOCXEvents_NewStreamEventHandler m_NewStreamDelegate;

	public _WMPOCXEvents_DisconnectEventHandler m_DisconnectDelegate;

	public _WMPOCXEvents_BufferingEventHandler m_BufferingDelegate;

	public _WMPOCXEvents_ErrorEventHandler m_ErrorDelegate;

	public _WMPOCXEvents_WarningEventHandler m_WarningDelegate;

	public _WMPOCXEvents_EndOfStreamEventHandler m_EndOfStreamDelegate;

	public _WMPOCXEvents_PositionChangeEventHandler m_PositionChangeDelegate;

	public _WMPOCXEvents_MarkerHitEventHandler m_MarkerHitDelegate;

	public _WMPOCXEvents_DurationUnitChangeEventHandler m_DurationUnitChangeDelegate;

	public _WMPOCXEvents_CdromMediaChangeEventHandler m_CdromMediaChangeDelegate;

	public _WMPOCXEvents_PlaylistChangeEventHandler m_PlaylistChangeDelegate;

	public _WMPOCXEvents_CurrentPlaylistChangeEventHandler m_CurrentPlaylistChangeDelegate;

	public _WMPOCXEvents_CurrentPlaylistItemAvailableEventHandler m_CurrentPlaylistItemAvailableDelegate;

	public _WMPOCXEvents_MediaChangeEventHandler m_MediaChangeDelegate;

	public _WMPOCXEvents_CurrentMediaItemAvailableEventHandler m_CurrentMediaItemAvailableDelegate;

	public _WMPOCXEvents_CurrentItemChangeEventHandler m_CurrentItemChangeDelegate;

	public _WMPOCXEvents_MediaCollectionChangeEventHandler m_MediaCollectionChangeDelegate;

	public _WMPOCXEvents_MediaCollectionAttributeStringAddedEventHandler m_MediaCollectionAttributeStringAddedDelegate;

	public _WMPOCXEvents_MediaCollectionAttributeStringRemovedEventHandler m_MediaCollectionAttributeStringRemovedDelegate;

	public _WMPOCXEvents_MediaCollectionAttributeStringChangedEventHandler m_MediaCollectionAttributeStringChangedDelegate;

	public _WMPOCXEvents_PlaylistCollectionChangeEventHandler m_PlaylistCollectionChangeDelegate;

	public _WMPOCXEvents_PlaylistCollectionPlaylistAddedEventHandler m_PlaylistCollectionPlaylistAddedDelegate;

	public _WMPOCXEvents_PlaylistCollectionPlaylistRemovedEventHandler m_PlaylistCollectionPlaylistRemovedDelegate;

	public _WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler m_PlaylistCollectionPlaylistSetAsDeletedDelegate;

	public _WMPOCXEvents_ModeChangeEventHandler m_ModeChangeDelegate;

	public _WMPOCXEvents_MediaErrorEventHandler m_MediaErrorDelegate;

	public _WMPOCXEvents_OpenPlaylistSwitchEventHandler m_OpenPlaylistSwitchDelegate;

	public _WMPOCXEvents_DomainChangeEventHandler m_DomainChangeDelegate;

	public _WMPOCXEvents_SwitchedToPlayerApplicationEventHandler m_SwitchedToPlayerApplicationDelegate;

	public _WMPOCXEvents_SwitchedToControlEventHandler m_SwitchedToControlDelegate;

	public _WMPOCXEvents_PlayerDockedStateChangeEventHandler m_PlayerDockedStateChangeDelegate;

	public _WMPOCXEvents_PlayerReconnectEventHandler m_PlayerReconnectDelegate;

	public _WMPOCXEvents_ClickEventHandler m_ClickDelegate;

	public _WMPOCXEvents_DoubleClickEventHandler m_DoubleClickDelegate;

	public _WMPOCXEvents_KeyDownEventHandler m_KeyDownDelegate;

	public _WMPOCXEvents_KeyPressEventHandler m_KeyPressDelegate;

	public _WMPOCXEvents_KeyUpEventHandler m_KeyUpDelegate;

	public _WMPOCXEvents_MouseDownEventHandler m_MouseDownDelegate;

	public _WMPOCXEvents_MouseMoveEventHandler m_MouseMoveDelegate;

	public _WMPOCXEvents_MouseUpEventHandler m_MouseUpDelegate;

	public _WMPOCXEvents_DeviceConnectEventHandler m_DeviceConnectDelegate;

	public _WMPOCXEvents_DeviceDisconnectEventHandler m_DeviceDisconnectDelegate;

	public _WMPOCXEvents_DeviceStatusChangeEventHandler m_DeviceStatusChangeDelegate;

	public _WMPOCXEvents_DeviceSyncStateChangeEventHandler m_DeviceSyncStateChangeDelegate;

	public _WMPOCXEvents_DeviceSyncErrorEventHandler m_DeviceSyncErrorDelegate;

	public _WMPOCXEvents_CreatePartnershipCompleteEventHandler m_CreatePartnershipCompleteDelegate;

	public _WMPOCXEvents_DeviceEstimationEventHandler m_DeviceEstimationDelegate;

	public _WMPOCXEvents_CdromRipStateChangeEventHandler m_CdromRipStateChangeDelegate;

	public _WMPOCXEvents_CdromRipMediaErrorEventHandler m_CdromRipMediaErrorDelegate;

	public _WMPOCXEvents_CdromBurnStateChangeEventHandler m_CdromBurnStateChangeDelegate;

	public _WMPOCXEvents_CdromBurnMediaErrorEventHandler m_CdromBurnMediaErrorDelegate;

	public _WMPOCXEvents_CdromBurnErrorEventHandler m_CdromBurnErrorDelegate;

	public _WMPOCXEvents_LibraryConnectEventHandler m_LibraryConnectDelegate;

	public _WMPOCXEvents_LibraryDisconnectEventHandler m_LibraryDisconnectDelegate;

	public _WMPOCXEvents_FolderScanStateChangeEventHandler m_FolderScanStateChangeDelegate;

	public _WMPOCXEvents_StringCollectionChangeEventHandler m_StringCollectionChangeDelegate;

	public _WMPOCXEvents_MediaCollectionMediaAddedEventHandler m_MediaCollectionMediaAddedDelegate;

	public _WMPOCXEvents_MediaCollectionMediaRemovedEventHandler m_MediaCollectionMediaRemovedDelegate;

	public int m_dwCookie;

	public void OpenStateChange(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_OpenStateChangeDelegate != null)
		{
			m_OpenStateChangeDelegate(P_0);
		}
	}

	public void PlayStateChange(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlayStateChangeDelegate != null)
		{
			m_PlayStateChangeDelegate(P_0);
		}
	}

	public void AudioLanguageChange(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_AudioLanguageChangeDelegate != null)
		{
			m_AudioLanguageChangeDelegate(P_0);
		}
	}

	public void StatusChange()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_StatusChangeDelegate != null)
		{
			m_StatusChangeDelegate();
		}
	}

	public void ScriptCommand(string P_0, string P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ScriptCommandDelegate != null)
		{
			m_ScriptCommandDelegate(P_0, P_1);
		}
	}

	public void NewStream()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_NewStreamDelegate != null)
		{
			m_NewStreamDelegate();
		}
	}

	public void Disconnect(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DisconnectDelegate != null)
		{
			m_DisconnectDelegate(P_0);
		}
	}

	public void Buffering(bool P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_BufferingDelegate != null)
		{
			m_BufferingDelegate(P_0);
		}
	}

	public void Error()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ErrorDelegate != null)
		{
			m_ErrorDelegate();
		}
	}

	public void Warning(int P_0, int P_1, string P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_WarningDelegate != null)
		{
			m_WarningDelegate(P_0, P_1, P_2);
		}
	}

	public void EndOfStream(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_EndOfStreamDelegate != null)
		{
			m_EndOfStreamDelegate(P_0);
		}
	}

	public void PositionChange(double P_0, double P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PositionChangeDelegate != null)
		{
			m_PositionChangeDelegate(P_0, P_1);
		}
	}

	public void MarkerHit(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MarkerHitDelegate != null)
		{
			m_MarkerHitDelegate(P_0);
		}
	}

	public void DurationUnitChange(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DurationUnitChangeDelegate != null)
		{
			m_DurationUnitChangeDelegate(P_0);
		}
	}

	public void CdromMediaChange(int P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CdromMediaChangeDelegate != null)
		{
			m_CdromMediaChangeDelegate(P_0);
		}
	}

	public void PlaylistChange(object P_0, WMPPlaylistChangeEventType P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlaylistChangeDelegate != null)
		{
			m_PlaylistChangeDelegate(P_0, P_1);
		}
	}

	public void CurrentPlaylistChange(WMPPlaylistChangeEventType P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CurrentPlaylistChangeDelegate != null)
		{
			m_CurrentPlaylistChangeDelegate(P_0);
		}
	}

	public void CurrentPlaylistItemAvailable(string P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CurrentPlaylistItemAvailableDelegate != null)
		{
			m_CurrentPlaylistItemAvailableDelegate(P_0);
		}
	}

	public void MediaChange(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaChangeDelegate != null)
		{
			m_MediaChangeDelegate(P_0);
		}
	}

	public void CurrentMediaItemAvailable(string P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CurrentMediaItemAvailableDelegate != null)
		{
			m_CurrentMediaItemAvailableDelegate(P_0);
		}
	}

	public void CurrentItemChange(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CurrentItemChangeDelegate != null)
		{
			m_CurrentItemChangeDelegate(P_0);
		}
	}

	public void MediaCollectionChange()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaCollectionChangeDelegate != null)
		{
			m_MediaCollectionChangeDelegate();
		}
	}

	public void MediaCollectionAttributeStringAdded(string P_0, string P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaCollectionAttributeStringAddedDelegate != null)
		{
			m_MediaCollectionAttributeStringAddedDelegate(P_0, P_1);
		}
	}

	public void MediaCollectionAttributeStringRemoved(string P_0, string P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaCollectionAttributeStringRemovedDelegate != null)
		{
			m_MediaCollectionAttributeStringRemovedDelegate(P_0, P_1);
		}
	}

	public void MediaCollectionAttributeStringChanged(string P_0, string P_1, string P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaCollectionAttributeStringChangedDelegate != null)
		{
			m_MediaCollectionAttributeStringChangedDelegate(P_0, P_1, P_2);
		}
	}

	public void PlaylistCollectionChange()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlaylistCollectionChangeDelegate != null)
		{
			m_PlaylistCollectionChangeDelegate();
		}
	}

	public void PlaylistCollectionPlaylistAdded(string P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlaylistCollectionPlaylistAddedDelegate != null)
		{
			m_PlaylistCollectionPlaylistAddedDelegate(P_0);
		}
	}

	public void PlaylistCollectionPlaylistRemoved(string P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlaylistCollectionPlaylistRemovedDelegate != null)
		{
			m_PlaylistCollectionPlaylistRemovedDelegate(P_0);
		}
	}

	public void PlaylistCollectionPlaylistSetAsDeleted(string P_0, bool P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlaylistCollectionPlaylistSetAsDeletedDelegate != null)
		{
			m_PlaylistCollectionPlaylistSetAsDeletedDelegate(P_0, P_1);
		}
	}

	public void ModeChange(string P_0, bool P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ModeChangeDelegate != null)
		{
			m_ModeChangeDelegate(P_0, P_1);
		}
	}

	public void MediaError(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaErrorDelegate != null)
		{
			m_MediaErrorDelegate(P_0);
		}
	}

	public void OpenPlaylistSwitch(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_OpenPlaylistSwitchDelegate != null)
		{
			m_OpenPlaylistSwitchDelegate(P_0);
		}
	}

	public void DomainChange(string P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DomainChangeDelegate != null)
		{
			m_DomainChangeDelegate(P_0);
		}
	}

	public void SwitchedToPlayerApplication()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_SwitchedToPlayerApplicationDelegate != null)
		{
			m_SwitchedToPlayerApplicationDelegate();
		}
	}

	public void SwitchedToControl()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_SwitchedToControlDelegate != null)
		{
			m_SwitchedToControlDelegate();
		}
	}

	public void PlayerDockedStateChange()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlayerDockedStateChangeDelegate != null)
		{
			m_PlayerDockedStateChangeDelegate();
		}
	}

	public void PlayerReconnect()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_PlayerReconnectDelegate != null)
		{
			m_PlayerReconnectDelegate();
		}
	}

	public void Click(short P_0, short P_1, int P_2, int P_3)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_ClickDelegate != null)
		{
			m_ClickDelegate(P_0, P_1, P_2, P_3);
		}
	}

	public void DoubleClick(short P_0, short P_1, int P_2, int P_3)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DoubleClickDelegate != null)
		{
			m_DoubleClickDelegate(P_0, P_1, P_2, P_3);
		}
	}

	public void KeyDown(short P_0, short P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_KeyDownDelegate != null)
		{
			m_KeyDownDelegate(P_0, P_1);
		}
	}

	public void KeyPress(short P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_KeyPressDelegate != null)
		{
			m_KeyPressDelegate(P_0);
		}
	}

	public void KeyUp(short P_0, short P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_KeyUpDelegate != null)
		{
			m_KeyUpDelegate(P_0, P_1);
		}
	}

	public void MouseDown(short P_0, short P_1, int P_2, int P_3)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MouseDownDelegate != null)
		{
			m_MouseDownDelegate(P_0, P_1, P_2, P_3);
		}
	}

	public void MouseMove(short P_0, short P_1, int P_2, int P_3)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MouseMoveDelegate != null)
		{
			m_MouseMoveDelegate(P_0, P_1, P_2, P_3);
		}
	}

	public void MouseUp(short P_0, short P_1, int P_2, int P_3)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MouseUpDelegate != null)
		{
			m_MouseUpDelegate(P_0, P_1, P_2, P_3);
		}
	}

	public void DeviceConnect(IWMPSyncDevice P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DeviceConnectDelegate != null)
		{
			m_DeviceConnectDelegate(P_0);
		}
	}

	public void DeviceDisconnect(IWMPSyncDevice P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DeviceDisconnectDelegate != null)
		{
			m_DeviceDisconnectDelegate(P_0);
		}
	}

	public void DeviceStatusChange(IWMPSyncDevice P_0, WMPDeviceStatus P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DeviceStatusChangeDelegate != null)
		{
			m_DeviceStatusChangeDelegate(P_0, P_1);
		}
	}

	public void DeviceSyncStateChange(IWMPSyncDevice P_0, WMPSyncState P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DeviceSyncStateChangeDelegate != null)
		{
			m_DeviceSyncStateChangeDelegate(P_0, P_1);
		}
	}

	public void DeviceSyncError(IWMPSyncDevice P_0, object P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DeviceSyncErrorDelegate != null)
		{
			m_DeviceSyncErrorDelegate(P_0, P_1);
		}
	}

	public void CreatePartnershipComplete(IWMPSyncDevice P_0, int P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CreatePartnershipCompleteDelegate != null)
		{
			m_CreatePartnershipCompleteDelegate(P_0, P_1);
		}
	}

	public void DeviceEstimation(IWMPSyncDevice P_0, int P_1, long P_2, long P_3)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_DeviceEstimationDelegate != null)
		{
			m_DeviceEstimationDelegate(P_0, P_1, P_2, P_3);
		}
	}

	public void CdromRipStateChange(IWMPCdromRip P_0, WMPRipState P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CdromRipStateChangeDelegate != null)
		{
			m_CdromRipStateChangeDelegate(P_0, P_1);
		}
	}

	public void CdromRipMediaError(IWMPCdromRip P_0, object P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CdromRipMediaErrorDelegate != null)
		{
			m_CdromRipMediaErrorDelegate(P_0, P_1);
		}
	}

	public void CdromBurnStateChange(IWMPCdromBurn P_0, WMPBurnState P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CdromBurnStateChangeDelegate != null)
		{
			m_CdromBurnStateChangeDelegate(P_0, P_1);
		}
	}

	public void CdromBurnMediaError(IWMPCdromBurn P_0, object P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CdromBurnMediaErrorDelegate != null)
		{
			m_CdromBurnMediaErrorDelegate(P_0, P_1);
		}
	}

	public void CdromBurnError(IWMPCdromBurn P_0, int P_1)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_CdromBurnErrorDelegate != null)
		{
			m_CdromBurnErrorDelegate(P_0, P_1);
		}
	}

	public void LibraryConnect(IWMPLibrary P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_LibraryConnectDelegate != null)
		{
			m_LibraryConnectDelegate(P_0);
		}
	}

	public void LibraryDisconnect(IWMPLibrary P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_LibraryDisconnectDelegate != null)
		{
			m_LibraryDisconnectDelegate(P_0);
		}
	}

	public void FolderScanStateChange(WMPFolderScanState P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_FolderScanStateChangeDelegate != null)
		{
			m_FolderScanStateChangeDelegate(P_0);
		}
	}

	public void StringCollectionChange(object P_0, WMPStringCollectionChangeEventType P_1, int P_2)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_StringCollectionChangeDelegate != null)
		{
			m_StringCollectionChangeDelegate(P_0, P_1, P_2);
		}
	}

	public void MediaCollectionMediaAdded(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaCollectionMediaAddedDelegate != null)
		{
			m_MediaCollectionMediaAddedDelegate(P_0);
		}
	}

	public void MediaCollectionMediaRemoved(object P_0)
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		if (m_MediaCollectionMediaRemovedDelegate != null)
		{
			m_MediaCollectionMediaRemovedDelegate(P_0);
		}
	}

	internal _WMPOCXEvents_SinkHelper()
	{
		//Error decoding local variables: Signature type sequence must have at least one element.
		m_dwCookie = 0;
		m_OpenStateChangeDelegate = null;
		m_PlayStateChangeDelegate = null;
		m_AudioLanguageChangeDelegate = null;
		m_StatusChangeDelegate = null;
		m_ScriptCommandDelegate = null;
		m_NewStreamDelegate = null;
		m_DisconnectDelegate = null;
		m_BufferingDelegate = null;
		m_ErrorDelegate = null;
		m_WarningDelegate = null;
		m_EndOfStreamDelegate = null;
		m_PositionChangeDelegate = null;
		m_MarkerHitDelegate = null;
		m_DurationUnitChangeDelegate = null;
		m_CdromMediaChangeDelegate = null;
		m_PlaylistChangeDelegate = null;
		m_CurrentPlaylistChangeDelegate = null;
		m_CurrentPlaylistItemAvailableDelegate = null;
		m_MediaChangeDelegate = null;
		m_CurrentMediaItemAvailableDelegate = null;
		m_CurrentItemChangeDelegate = null;
		m_MediaCollectionChangeDelegate = null;
		m_MediaCollectionAttributeStringAddedDelegate = null;
		m_MediaCollectionAttributeStringRemovedDelegate = null;
		m_MediaCollectionAttributeStringChangedDelegate = null;
		m_PlaylistCollectionChangeDelegate = null;
		m_PlaylistCollectionPlaylistAddedDelegate = null;
		m_PlaylistCollectionPlaylistRemovedDelegate = null;
		m_PlaylistCollectionPlaylistSetAsDeletedDelegate = null;
		m_ModeChangeDelegate = null;
		m_MediaErrorDelegate = null;
		m_OpenPlaylistSwitchDelegate = null;
		m_DomainChangeDelegate = null;
		m_SwitchedToPlayerApplicationDelegate = null;
		m_SwitchedToControlDelegate = null;
		m_PlayerDockedStateChangeDelegate = null;
		m_PlayerReconnectDelegate = null;
		m_ClickDelegate = null;
		m_DoubleClickDelegate = null;
		m_KeyDownDelegate = null;
		m_KeyPressDelegate = null;
		m_KeyUpDelegate = null;
		m_MouseDownDelegate = null;
		m_MouseMoveDelegate = null;
		m_MouseUpDelegate = null;
		m_DeviceConnectDelegate = null;
		m_DeviceDisconnectDelegate = null;
		m_DeviceStatusChangeDelegate = null;
		m_DeviceSyncStateChangeDelegate = null;
		m_DeviceSyncErrorDelegate = null;
		m_CreatePartnershipCompleteDelegate = null;
		m_DeviceEstimationDelegate = null;
		m_CdromRipStateChangeDelegate = null;
		m_CdromRipMediaErrorDelegate = null;
		m_CdromBurnStateChangeDelegate = null;
		m_CdromBurnMediaErrorDelegate = null;
		m_CdromBurnErrorDelegate = null;
		m_LibraryConnectDelegate = null;
		m_LibraryDisconnectDelegate = null;
		m_FolderScanStateChangeDelegate = null;
		m_StringCollectionChangeDelegate = null;
		m_MediaCollectionMediaAddedDelegate = null;
		m_MediaCollectionMediaRemovedDelegate = null;
	}
}
