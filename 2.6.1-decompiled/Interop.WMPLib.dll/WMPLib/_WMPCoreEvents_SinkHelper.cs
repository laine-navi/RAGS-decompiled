using System.Runtime.InteropServices;

namespace WMPLib;

[ClassInterface(ClassInterfaceType.None)]
[TypeLibType(TypeLibTypeFlags.FHidden)]
public sealed class _WMPCoreEvents_SinkHelper : _WMPCoreEvents
{
	public _WMPCoreEvents_OpenStateChangeEventHandler m_OpenStateChangeDelegate;

	public _WMPCoreEvents_PlayStateChangeEventHandler m_PlayStateChangeDelegate;

	public _WMPCoreEvents_AudioLanguageChangeEventHandler m_AudioLanguageChangeDelegate;

	public _WMPCoreEvents_StatusChangeEventHandler m_StatusChangeDelegate;

	public _WMPCoreEvents_ScriptCommandEventHandler m_ScriptCommandDelegate;

	public _WMPCoreEvents_NewStreamEventHandler m_NewStreamDelegate;

	public _WMPCoreEvents_DisconnectEventHandler m_DisconnectDelegate;

	public _WMPCoreEvents_BufferingEventHandler m_BufferingDelegate;

	public _WMPCoreEvents_ErrorEventHandler m_ErrorDelegate;

	public _WMPCoreEvents_WarningEventHandler m_WarningDelegate;

	public _WMPCoreEvents_EndOfStreamEventHandler m_EndOfStreamDelegate;

	public _WMPCoreEvents_PositionChangeEventHandler m_PositionChangeDelegate;

	public _WMPCoreEvents_MarkerHitEventHandler m_MarkerHitDelegate;

	public _WMPCoreEvents_DurationUnitChangeEventHandler m_DurationUnitChangeDelegate;

	public _WMPCoreEvents_CdromMediaChangeEventHandler m_CdromMediaChangeDelegate;

	public _WMPCoreEvents_PlaylistChangeEventHandler m_PlaylistChangeDelegate;

	public _WMPCoreEvents_CurrentPlaylistChangeEventHandler m_CurrentPlaylistChangeDelegate;

	public _WMPCoreEvents_CurrentPlaylistItemAvailableEventHandler m_CurrentPlaylistItemAvailableDelegate;

	public _WMPCoreEvents_MediaChangeEventHandler m_MediaChangeDelegate;

	public _WMPCoreEvents_CurrentMediaItemAvailableEventHandler m_CurrentMediaItemAvailableDelegate;

	public _WMPCoreEvents_CurrentItemChangeEventHandler m_CurrentItemChangeDelegate;

	public _WMPCoreEvents_MediaCollectionChangeEventHandler m_MediaCollectionChangeDelegate;

	public _WMPCoreEvents_MediaCollectionAttributeStringAddedEventHandler m_MediaCollectionAttributeStringAddedDelegate;

	public _WMPCoreEvents_MediaCollectionAttributeStringRemovedEventHandler m_MediaCollectionAttributeStringRemovedDelegate;

	public _WMPCoreEvents_MediaCollectionAttributeStringChangedEventHandler m_MediaCollectionAttributeStringChangedDelegate;

	public _WMPCoreEvents_PlaylistCollectionChangeEventHandler m_PlaylistCollectionChangeDelegate;

	public _WMPCoreEvents_PlaylistCollectionPlaylistAddedEventHandler m_PlaylistCollectionPlaylistAddedDelegate;

	public _WMPCoreEvents_PlaylistCollectionPlaylistRemovedEventHandler m_PlaylistCollectionPlaylistRemovedDelegate;

	public _WMPCoreEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler m_PlaylistCollectionPlaylistSetAsDeletedDelegate;

	public _WMPCoreEvents_ModeChangeEventHandler m_ModeChangeDelegate;

	public _WMPCoreEvents_MediaErrorEventHandler m_MediaErrorDelegate;

	public _WMPCoreEvents_OpenPlaylistSwitchEventHandler m_OpenPlaylistSwitchDelegate;

	public _WMPCoreEvents_DomainChangeEventHandler m_DomainChangeDelegate;

	public _WMPCoreEvents_StringCollectionChangeEventHandler m_StringCollectionChangeDelegate;

	public _WMPCoreEvents_MediaCollectionMediaAddedEventHandler m_MediaCollectionMediaAddedDelegate;

	public _WMPCoreEvents_MediaCollectionMediaRemovedEventHandler m_MediaCollectionMediaRemovedDelegate;

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

	internal _WMPCoreEvents_SinkHelper()
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
		m_StringCollectionChangeDelegate = null;
		m_MediaCollectionMediaAddedDelegate = null;
		m_MediaCollectionMediaRemovedDelegate = null;
	}
}
