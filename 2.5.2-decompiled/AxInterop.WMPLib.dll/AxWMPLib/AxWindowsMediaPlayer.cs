using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WMPLib;

namespace AxWMPLib;

[DesignTimeVisible(true)]
[Clsid("{6bf52a52-394a-11d3-b153-00c04f79faa6}")]
public class AxWindowsMediaPlayer : AxHost
{
	private IWMPPlayer4 ocx;

	private AxWindowsMediaPlayerEventMulticaster eventMulticaster;

	private ConnectionPointCookie cookie;

	[DispId(1)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string URL
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("URL", (ActiveXInvokeKind)1);
			}
			return ocx.URL;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("URL", (ActiveXInvokeKind)2);
			}
			ocx.URL = value;
		}
	}

	[DispId(2)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual WMPOpenState openState
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("openState", (ActiveXInvokeKind)1);
			}
			return ocx.openState;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(10)]
	public virtual WMPPlayState playState
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("playState", (ActiveXInvokeKind)1);
			}
			return ocx.playState;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(4)]
	public virtual IWMPControls Ctlcontrols
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("Ctlcontrols", (ActiveXInvokeKind)1);
			}
			return ocx.controls;
		}
	}

	[DispId(5)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual IWMPSettings settings
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("settings", (ActiveXInvokeKind)1);
			}
			return ocx.settings;
		}
	}

	[DispId(6)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual IWMPMedia currentMedia
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("currentMedia", (ActiveXInvokeKind)1);
			}
			return ocx.currentMedia;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("currentMedia", (ActiveXInvokeKind)2);
			}
			ocx.currentMedia = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(8)]
	public virtual IWMPMediaCollection mediaCollection
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("mediaCollection", (ActiveXInvokeKind)1);
			}
			return ocx.mediaCollection;
		}
	}

	[DispId(9)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual IWMPPlaylistCollection playlistCollection
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("playlistCollection", (ActiveXInvokeKind)1);
			}
			return ocx.playlistCollection;
		}
	}

	[DispId(11)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string versionInfo
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("versionInfo", (ActiveXInvokeKind)1);
			}
			return ocx.versionInfo;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(7)]
	public virtual IWMPNetwork network
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("network", (ActiveXInvokeKind)1);
			}
			return ocx.network;
		}
	}

	[DispId(13)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual IWMPPlaylist currentPlaylist
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("currentPlaylist", (ActiveXInvokeKind)1);
			}
			return ocx.currentPlaylist;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("currentPlaylist", (ActiveXInvokeKind)2);
			}
			ocx.currentPlaylist = value;
		}
	}

	[DispId(14)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual IWMPCdromCollection cdromCollection
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("cdromCollection", (ActiveXInvokeKind)1);
			}
			return ocx.cdromCollection;
		}
	}

	[DispId(15)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual IWMPClosedCaption closedCaption
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("closedCaption", (ActiveXInvokeKind)1);
			}
			return ocx.closedCaption;
		}
	}

	[DispId(16)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool isOnline
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("isOnline", (ActiveXInvokeKind)1);
			}
			return ocx.isOnline;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[DispId(17)]
	public virtual IWMPError Error
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("Error", (ActiveXInvokeKind)1);
			}
			return ocx.Error;
		}
	}

	[DispId(18)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string status
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("status", (ActiveXInvokeKind)1);
			}
			return ocx.status;
		}
	}

	[Browsable(false)]
	[DispId(40)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual IWMPDVD dvd
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("dvd", (ActiveXInvokeKind)1);
			}
			return ocx.dvd;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(19)]
	public virtual bool Ctlenabled
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("Ctlenabled", (ActiveXInvokeKind)1);
			}
			return ocx.enabled;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("Ctlenabled", (ActiveXInvokeKind)2);
			}
			ocx.enabled = value;
		}
	}

	[DispId(21)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool fullScreen
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("fullScreen", (ActiveXInvokeKind)1);
			}
			return ocx.fullScreen;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("fullScreen", (ActiveXInvokeKind)2);
			}
			ocx.fullScreen = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(22)]
	public virtual bool enableContextMenu
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("enableContextMenu", (ActiveXInvokeKind)1);
			}
			return ocx.enableContextMenu;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("enableContextMenu", (ActiveXInvokeKind)2);
			}
			ocx.enableContextMenu = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(23)]
	public virtual string uiMode
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("uiMode", (ActiveXInvokeKind)1);
			}
			return ocx.uiMode;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("uiMode", (ActiveXInvokeKind)2);
			}
			ocx.uiMode = value;
		}
	}

	[DispId(24)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool stretchToFit
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("stretchToFit", (ActiveXInvokeKind)1);
			}
			return ocx.stretchToFit;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("stretchToFit", (ActiveXInvokeKind)2);
			}
			ocx.stretchToFit = value;
		}
	}

	[DispId(25)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual bool windowlessVideo
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("windowlessVideo", (ActiveXInvokeKind)1);
			}
			return ocx.windowlessVideo;
		}
		set
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("windowlessVideo", (ActiveXInvokeKind)2);
			}
			ocx.windowlessVideo = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(26)]
	public virtual bool isRemote
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("isRemote", (ActiveXInvokeKind)1);
			}
			return ocx.isRemote;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DispId(27)]
	public virtual IWMPPlayerApplication playerApplication
	{
		get
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			if (ocx == null)
			{
				throw new InvalidActiveXStateException("playerApplication", (ActiveXInvokeKind)1);
			}
			return ocx.playerApplication;
		}
	}

	public event _WMPOCXEvents_OpenStateChangeEventHandler OpenStateChange;

	public event _WMPOCXEvents_PlayStateChangeEventHandler PlayStateChange;

	public event _WMPOCXEvents_AudioLanguageChangeEventHandler AudioLanguageChange;

	public event EventHandler StatusChange;

	public event _WMPOCXEvents_ScriptCommandEventHandler ScriptCommand;

	public event EventHandler NewStream;

	public event _WMPOCXEvents_DisconnectEventHandler Disconnect;

	public event _WMPOCXEvents_BufferingEventHandler Buffering;

	public event EventHandler ErrorEvent;

	public event _WMPOCXEvents_WarningEventHandler Warning;

	public event _WMPOCXEvents_EndOfStreamEventHandler EndOfStream;

	public event _WMPOCXEvents_PositionChangeEventHandler PositionChange;

	public event _WMPOCXEvents_MarkerHitEventHandler MarkerHit;

	public event _WMPOCXEvents_DurationUnitChangeEventHandler DurationUnitChange;

	public event _WMPOCXEvents_CdromMediaChangeEventHandler CdromMediaChange;

	public event _WMPOCXEvents_PlaylistChangeEventHandler PlaylistChange;

	public event _WMPOCXEvents_CurrentPlaylistChangeEventHandler CurrentPlaylistChange;

	public event _WMPOCXEvents_CurrentPlaylistItemAvailableEventHandler CurrentPlaylistItemAvailable;

	public event _WMPOCXEvents_MediaChangeEventHandler MediaChange;

	public event _WMPOCXEvents_CurrentMediaItemAvailableEventHandler CurrentMediaItemAvailable;

	public event _WMPOCXEvents_CurrentItemChangeEventHandler CurrentItemChange;

	public event EventHandler MediaCollectionChange;

	public event _WMPOCXEvents_MediaCollectionAttributeStringAddedEventHandler MediaCollectionAttributeStringAdded;

	public event _WMPOCXEvents_MediaCollectionAttributeStringRemovedEventHandler MediaCollectionAttributeStringRemoved;

	public event _WMPOCXEvents_MediaCollectionAttributeStringChangedEventHandler MediaCollectionAttributeStringChanged;

	public event EventHandler PlaylistCollectionChange;

	public event _WMPOCXEvents_PlaylistCollectionPlaylistAddedEventHandler PlaylistCollectionPlaylistAdded;

	public event _WMPOCXEvents_PlaylistCollectionPlaylistRemovedEventHandler PlaylistCollectionPlaylistRemoved;

	public event _WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEventHandler PlaylistCollectionPlaylistSetAsDeleted;

	public event _WMPOCXEvents_ModeChangeEventHandler ModeChange;

	public event _WMPOCXEvents_MediaErrorEventHandler MediaError;

	public event _WMPOCXEvents_OpenPlaylistSwitchEventHandler OpenPlaylistSwitch;

	public event _WMPOCXEvents_DomainChangeEventHandler DomainChange;

	public event EventHandler SwitchedToPlayerApplication;

	public event EventHandler SwitchedToControl;

	public event EventHandler PlayerDockedStateChange;

	public event EventHandler PlayerReconnect;

	public event _WMPOCXEvents_ClickEventHandler ClickEvent;

	public event _WMPOCXEvents_DoubleClickEventHandler DoubleClickEvent;

	public event _WMPOCXEvents_KeyDownEventHandler KeyDownEvent;

	public event _WMPOCXEvents_KeyPressEventHandler KeyPressEvent;

	public event _WMPOCXEvents_KeyUpEventHandler KeyUpEvent;

	public event _WMPOCXEvents_MouseDownEventHandler MouseDownEvent;

	public event _WMPOCXEvents_MouseMoveEventHandler MouseMoveEvent;

	public event _WMPOCXEvents_MouseUpEventHandler MouseUpEvent;

	public event _WMPOCXEvents_DeviceConnectEventHandler DeviceConnect;

	public event _WMPOCXEvents_DeviceDisconnectEventHandler DeviceDisconnect;

	public event _WMPOCXEvents_DeviceStatusChangeEventHandler DeviceStatusChange;

	public event _WMPOCXEvents_DeviceSyncStateChangeEventHandler DeviceSyncStateChange;

	public event _WMPOCXEvents_DeviceSyncErrorEventHandler DeviceSyncError;

	public event _WMPOCXEvents_CreatePartnershipCompleteEventHandler CreatePartnershipComplete;

	public event _WMPOCXEvents_DeviceEstimationEventHandler DeviceEstimation;

	public event _WMPOCXEvents_CdromRipStateChangeEventHandler CdromRipStateChange;

	public event _WMPOCXEvents_CdromRipMediaErrorEventHandler CdromRipMediaError;

	public event _WMPOCXEvents_CdromBurnStateChangeEventHandler CdromBurnStateChange;

	public event _WMPOCXEvents_CdromBurnMediaErrorEventHandler CdromBurnMediaError;

	public event _WMPOCXEvents_CdromBurnErrorEventHandler CdromBurnError;

	public event _WMPOCXEvents_LibraryConnectEventHandler LibraryConnect;

	public event _WMPOCXEvents_LibraryDisconnectEventHandler LibraryDisconnect;

	public event _WMPOCXEvents_FolderScanStateChangeEventHandler FolderScanStateChange;

	public event _WMPOCXEvents_StringCollectionChangeEventHandler StringCollectionChange;

	public event _WMPOCXEvents_MediaCollectionMediaAddedEventHandler MediaCollectionMediaAdded;

	public event _WMPOCXEvents_MediaCollectionMediaRemovedEventHandler MediaCollectionMediaRemoved;

	public AxWindowsMediaPlayer()
		: base("6bf52a52-394a-11d3-b153-00c04f79faa6")
	{
	}

	public virtual void close()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (ocx == null)
		{
			throw new InvalidActiveXStateException("close", (ActiveXInvokeKind)0);
		}
		ocx.close();
	}

	public virtual void launchURL(string bstrURL)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (ocx == null)
		{
			throw new InvalidActiveXStateException("launchURL", (ActiveXInvokeKind)0);
		}
		ocx.launchURL(bstrURL);
	}

	public virtual IWMPPlaylist newPlaylist(string bstrName, string bstrURL)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (ocx == null)
		{
			throw new InvalidActiveXStateException("newPlaylist", (ActiveXInvokeKind)0);
		}
		return ocx.newPlaylist(bstrName, bstrURL);
	}

	public virtual IWMPMedia newMedia(string bstrURL)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (ocx == null)
		{
			throw new InvalidActiveXStateException("newMedia", (ActiveXInvokeKind)0);
		}
		return ocx.newMedia(bstrURL);
	}

	public virtual void openPlayer(string bstrURL)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (ocx == null)
		{
			throw new InvalidActiveXStateException("openPlayer", (ActiveXInvokeKind)0);
		}
		ocx.openPlayer(bstrURL);
	}

	protected override void CreateSink()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
		try
		{
			eventMulticaster = new AxWindowsMediaPlayerEventMulticaster(this);
			cookie = new ConnectionPointCookie((object)ocx, (object)eventMulticaster, typeof(_WMPOCXEvents));
		}
		catch (Exception)
		{
		}
	}

	protected override void DetachSink()
	{
		try
		{
			cookie.Disconnect();
		}
		catch (Exception)
		{
		}
	}

	protected override void AttachInterfaces()
	{
		try
		{
			ocx = (IWMPPlayer4)((AxHost)this).GetOcx();
		}
		catch (Exception)
		{
		}
	}

	internal void RaiseOnOpenStateChange(object sender, _WMPOCXEvents_OpenStateChangeEvent e)
	{
		if (OpenStateChange != null)
		{
			OpenStateChange(sender, e);
		}
	}

	internal void RaiseOnPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
	{
		if (PlayStateChange != null)
		{
			PlayStateChange(sender, e);
		}
	}

	internal void RaiseOnAudioLanguageChange(object sender, _WMPOCXEvents_AudioLanguageChangeEvent e)
	{
		if (AudioLanguageChange != null)
		{
			AudioLanguageChange(sender, e);
		}
	}

	internal void RaiseOnStatusChange(object sender, EventArgs e)
	{
		if (StatusChange != null)
		{
			StatusChange(sender, e);
		}
	}

	internal void RaiseOnScriptCommand(object sender, _WMPOCXEvents_ScriptCommandEvent e)
	{
		if (ScriptCommand != null)
		{
			ScriptCommand(sender, e);
		}
	}

	internal void RaiseOnNewStream(object sender, EventArgs e)
	{
		if (NewStream != null)
		{
			NewStream(sender, e);
		}
	}

	internal void RaiseOnDisconnect(object sender, _WMPOCXEvents_DisconnectEvent e)
	{
		if (Disconnect != null)
		{
			Disconnect(sender, e);
		}
	}

	internal void RaiseOnBuffering(object sender, _WMPOCXEvents_BufferingEvent e)
	{
		if (Buffering != null)
		{
			Buffering(sender, e);
		}
	}

	internal void RaiseOnErrorEvent(object sender, EventArgs e)
	{
		if (ErrorEvent != null)
		{
			ErrorEvent(sender, e);
		}
	}

	internal void RaiseOnWarning(object sender, _WMPOCXEvents_WarningEvent e)
	{
		if (Warning != null)
		{
			Warning(sender, e);
		}
	}

	internal void RaiseOnEndOfStream(object sender, _WMPOCXEvents_EndOfStreamEvent e)
	{
		if (EndOfStream != null)
		{
			EndOfStream(sender, e);
		}
	}

	internal void RaiseOnPositionChange(object sender, _WMPOCXEvents_PositionChangeEvent e)
	{
		if (PositionChange != null)
		{
			PositionChange(sender, e);
		}
	}

	internal void RaiseOnMarkerHit(object sender, _WMPOCXEvents_MarkerHitEvent e)
	{
		if (MarkerHit != null)
		{
			MarkerHit(sender, e);
		}
	}

	internal void RaiseOnDurationUnitChange(object sender, _WMPOCXEvents_DurationUnitChangeEvent e)
	{
		if (DurationUnitChange != null)
		{
			DurationUnitChange(sender, e);
		}
	}

	internal void RaiseOnCdromMediaChange(object sender, _WMPOCXEvents_CdromMediaChangeEvent e)
	{
		if (CdromMediaChange != null)
		{
			CdromMediaChange(sender, e);
		}
	}

	internal void RaiseOnPlaylistChange(object sender, _WMPOCXEvents_PlaylistChangeEvent e)
	{
		if (PlaylistChange != null)
		{
			PlaylistChange(sender, e);
		}
	}

	internal void RaiseOnCurrentPlaylistChange(object sender, _WMPOCXEvents_CurrentPlaylistChangeEvent e)
	{
		if (CurrentPlaylistChange != null)
		{
			CurrentPlaylistChange(sender, e);
		}
	}

	internal void RaiseOnCurrentPlaylistItemAvailable(object sender, _WMPOCXEvents_CurrentPlaylistItemAvailableEvent e)
	{
		if (CurrentPlaylistItemAvailable != null)
		{
			CurrentPlaylistItemAvailable(sender, e);
		}
	}

	internal void RaiseOnMediaChange(object sender, _WMPOCXEvents_MediaChangeEvent e)
	{
		if (MediaChange != null)
		{
			MediaChange(sender, e);
		}
	}

	internal void RaiseOnCurrentMediaItemAvailable(object sender, _WMPOCXEvents_CurrentMediaItemAvailableEvent e)
	{
		if (CurrentMediaItemAvailable != null)
		{
			CurrentMediaItemAvailable(sender, e);
		}
	}

	internal void RaiseOnCurrentItemChange(object sender, _WMPOCXEvents_CurrentItemChangeEvent e)
	{
		if (CurrentItemChange != null)
		{
			CurrentItemChange(sender, e);
		}
	}

	internal void RaiseOnMediaCollectionChange(object sender, EventArgs e)
	{
		if (MediaCollectionChange != null)
		{
			MediaCollectionChange(sender, e);
		}
	}

	internal void RaiseOnMediaCollectionAttributeStringAdded(object sender, _WMPOCXEvents_MediaCollectionAttributeStringAddedEvent e)
	{
		if (MediaCollectionAttributeStringAdded != null)
		{
			MediaCollectionAttributeStringAdded(sender, e);
		}
	}

	internal void RaiseOnMediaCollectionAttributeStringRemoved(object sender, _WMPOCXEvents_MediaCollectionAttributeStringRemovedEvent e)
	{
		if (MediaCollectionAttributeStringRemoved != null)
		{
			MediaCollectionAttributeStringRemoved(sender, e);
		}
	}

	internal void RaiseOnMediaCollectionAttributeStringChanged(object sender, _WMPOCXEvents_MediaCollectionAttributeStringChangedEvent e)
	{
		if (MediaCollectionAttributeStringChanged != null)
		{
			MediaCollectionAttributeStringChanged(sender, e);
		}
	}

	internal void RaiseOnPlaylistCollectionChange(object sender, EventArgs e)
	{
		if (PlaylistCollectionChange != null)
		{
			PlaylistCollectionChange(sender, e);
		}
	}

	internal void RaiseOnPlaylistCollectionPlaylistAdded(object sender, _WMPOCXEvents_PlaylistCollectionPlaylistAddedEvent e)
	{
		if (PlaylistCollectionPlaylistAdded != null)
		{
			PlaylistCollectionPlaylistAdded(sender, e);
		}
	}

	internal void RaiseOnPlaylistCollectionPlaylistRemoved(object sender, _WMPOCXEvents_PlaylistCollectionPlaylistRemovedEvent e)
	{
		if (PlaylistCollectionPlaylistRemoved != null)
		{
			PlaylistCollectionPlaylistRemoved(sender, e);
		}
	}

	internal void RaiseOnPlaylistCollectionPlaylistSetAsDeleted(object sender, _WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEvent e)
	{
		if (PlaylistCollectionPlaylistSetAsDeleted != null)
		{
			PlaylistCollectionPlaylistSetAsDeleted(sender, e);
		}
	}

	internal void RaiseOnModeChange(object sender, _WMPOCXEvents_ModeChangeEvent e)
	{
		if (ModeChange != null)
		{
			ModeChange(sender, e);
		}
	}

	internal void RaiseOnMediaError(object sender, _WMPOCXEvents_MediaErrorEvent e)
	{
		if (MediaError != null)
		{
			MediaError(sender, e);
		}
	}

	internal void RaiseOnOpenPlaylistSwitch(object sender, _WMPOCXEvents_OpenPlaylistSwitchEvent e)
	{
		if (OpenPlaylistSwitch != null)
		{
			OpenPlaylistSwitch(sender, e);
		}
	}

	internal void RaiseOnDomainChange(object sender, _WMPOCXEvents_DomainChangeEvent e)
	{
		if (DomainChange != null)
		{
			DomainChange(sender, e);
		}
	}

	internal void RaiseOnSwitchedToPlayerApplication(object sender, EventArgs e)
	{
		if (SwitchedToPlayerApplication != null)
		{
			SwitchedToPlayerApplication(sender, e);
		}
	}

	internal void RaiseOnSwitchedToControl(object sender, EventArgs e)
	{
		if (SwitchedToControl != null)
		{
			SwitchedToControl(sender, e);
		}
	}

	internal void RaiseOnPlayerDockedStateChange(object sender, EventArgs e)
	{
		if (PlayerDockedStateChange != null)
		{
			PlayerDockedStateChange(sender, e);
		}
	}

	internal void RaiseOnPlayerReconnect(object sender, EventArgs e)
	{
		if (PlayerReconnect != null)
		{
			PlayerReconnect(sender, e);
		}
	}

	internal void RaiseOnClickEvent(object sender, _WMPOCXEvents_ClickEvent e)
	{
		if (ClickEvent != null)
		{
			ClickEvent(sender, e);
		}
	}

	internal void RaiseOnDoubleClickEvent(object sender, _WMPOCXEvents_DoubleClickEvent e)
	{
		if (DoubleClickEvent != null)
		{
			DoubleClickEvent(sender, e);
		}
	}

	internal void RaiseOnKeyDownEvent(object sender, _WMPOCXEvents_KeyDownEvent e)
	{
		if (KeyDownEvent != null)
		{
			KeyDownEvent(sender, e);
		}
	}

	internal void RaiseOnKeyPressEvent(object sender, _WMPOCXEvents_KeyPressEvent e)
	{
		if (KeyPressEvent != null)
		{
			KeyPressEvent(sender, e);
		}
	}

	internal void RaiseOnKeyUpEvent(object sender, _WMPOCXEvents_KeyUpEvent e)
	{
		if (KeyUpEvent != null)
		{
			KeyUpEvent(sender, e);
		}
	}

	internal void RaiseOnMouseDownEvent(object sender, _WMPOCXEvents_MouseDownEvent e)
	{
		if (MouseDownEvent != null)
		{
			MouseDownEvent(sender, e);
		}
	}

	internal void RaiseOnMouseMoveEvent(object sender, _WMPOCXEvents_MouseMoveEvent e)
	{
		if (MouseMoveEvent != null)
		{
			MouseMoveEvent(sender, e);
		}
	}

	internal void RaiseOnMouseUpEvent(object sender, _WMPOCXEvents_MouseUpEvent e)
	{
		if (MouseUpEvent != null)
		{
			MouseUpEvent(sender, e);
		}
	}

	internal void RaiseOnDeviceConnect(object sender, _WMPOCXEvents_DeviceConnectEvent e)
	{
		if (DeviceConnect != null)
		{
			DeviceConnect(sender, e);
		}
	}

	internal void RaiseOnDeviceDisconnect(object sender, _WMPOCXEvents_DeviceDisconnectEvent e)
	{
		if (DeviceDisconnect != null)
		{
			DeviceDisconnect(sender, e);
		}
	}

	internal void RaiseOnDeviceStatusChange(object sender, _WMPOCXEvents_DeviceStatusChangeEvent e)
	{
		if (DeviceStatusChange != null)
		{
			DeviceStatusChange(sender, e);
		}
	}

	internal void RaiseOnDeviceSyncStateChange(object sender, _WMPOCXEvents_DeviceSyncStateChangeEvent e)
	{
		if (DeviceSyncStateChange != null)
		{
			DeviceSyncStateChange(sender, e);
		}
	}

	internal void RaiseOnDeviceSyncError(object sender, _WMPOCXEvents_DeviceSyncErrorEvent e)
	{
		if (DeviceSyncError != null)
		{
			DeviceSyncError(sender, e);
		}
	}

	internal void RaiseOnCreatePartnershipComplete(object sender, _WMPOCXEvents_CreatePartnershipCompleteEvent e)
	{
		if (CreatePartnershipComplete != null)
		{
			CreatePartnershipComplete(sender, e);
		}
	}

	internal void RaiseOnDeviceEstimation(object sender, _WMPOCXEvents_DeviceEstimationEvent e)
	{
		if (DeviceEstimation != null)
		{
			DeviceEstimation(sender, e);
		}
	}

	internal void RaiseOnCdromRipStateChange(object sender, _WMPOCXEvents_CdromRipStateChangeEvent e)
	{
		if (CdromRipStateChange != null)
		{
			CdromRipStateChange(sender, e);
		}
	}

	internal void RaiseOnCdromRipMediaError(object sender, _WMPOCXEvents_CdromRipMediaErrorEvent e)
	{
		if (CdromRipMediaError != null)
		{
			CdromRipMediaError(sender, e);
		}
	}

	internal void RaiseOnCdromBurnStateChange(object sender, _WMPOCXEvents_CdromBurnStateChangeEvent e)
	{
		if (CdromBurnStateChange != null)
		{
			CdromBurnStateChange(sender, e);
		}
	}

	internal void RaiseOnCdromBurnMediaError(object sender, _WMPOCXEvents_CdromBurnMediaErrorEvent e)
	{
		if (CdromBurnMediaError != null)
		{
			CdromBurnMediaError(sender, e);
		}
	}

	internal void RaiseOnCdromBurnError(object sender, _WMPOCXEvents_CdromBurnErrorEvent e)
	{
		if (CdromBurnError != null)
		{
			CdromBurnError(sender, e);
		}
	}

	internal void RaiseOnLibraryConnect(object sender, _WMPOCXEvents_LibraryConnectEvent e)
	{
		if (LibraryConnect != null)
		{
			LibraryConnect(sender, e);
		}
	}

	internal void RaiseOnLibraryDisconnect(object sender, _WMPOCXEvents_LibraryDisconnectEvent e)
	{
		if (LibraryDisconnect != null)
		{
			LibraryDisconnect(sender, e);
		}
	}

	internal void RaiseOnFolderScanStateChange(object sender, _WMPOCXEvents_FolderScanStateChangeEvent e)
	{
		if (FolderScanStateChange != null)
		{
			FolderScanStateChange(sender, e);
		}
	}

	internal void RaiseOnStringCollectionChange(object sender, _WMPOCXEvents_StringCollectionChangeEvent e)
	{
		if (StringCollectionChange != null)
		{
			StringCollectionChange(sender, e);
		}
	}

	internal void RaiseOnMediaCollectionMediaAdded(object sender, _WMPOCXEvents_MediaCollectionMediaAddedEvent e)
	{
		if (MediaCollectionMediaAdded != null)
		{
			MediaCollectionMediaAdded(sender, e);
		}
	}

	internal void RaiseOnMediaCollectionMediaRemoved(object sender, _WMPOCXEvents_MediaCollectionMediaRemovedEvent e)
	{
		if (MediaCollectionMediaRemoved != null)
		{
			MediaCollectionMediaRemoved(sender, e);
		}
	}
}
