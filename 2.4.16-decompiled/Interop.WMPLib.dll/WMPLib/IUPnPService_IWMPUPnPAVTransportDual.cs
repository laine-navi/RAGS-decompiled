using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("0EA1DE14-E288-4958-A23C-942634A27EB5")]
[TypeLibType(4160)]
public interface IUPnPService_IWMPUPnPAVTransportDual
{
	[DispId(1)]
	string TransportState
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(2)]
	string TransportStatus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(2)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(3)]
	string PlaybackStorageMedium
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(3)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(4)]
	string RecordStorageMedium
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(4)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(5)]
	string PossiblePlaybackStorageMedia
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(5)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(6)]
	string PossibleRecordStorageMedia
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(6)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(7)]
	string CurrentPlayMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(7)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(8)]
	string TransportPlaySpeed
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(8)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(9)]
	string RecordMediumWriteStatus
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(9)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(10)]
	string CurrentRecordQualityMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(10)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(11)]
	string PossibleRecordQualityModes
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(11)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(12)]
	uint NumberOfTracks
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(12)]
		get;
	}

	[DispId(13)]
	uint CurrentTrack
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(13)]
		get;
	}

	[DispId(14)]
	string CurrentTrackDuration
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(14)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(15)]
	string CurrentMediaDuration
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(15)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(16)]
	string CurrentTrackMetaData
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(16)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(17)]
	string CurrentTrackURI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(17)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(18)]
	string AVTransportURI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(18)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(19)]
	string AVTransportURIMetaData
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(19)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(20)]
	string NextAVTransportURI
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(20)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(21)]
	string NextAVTransportURIMetaData
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(21)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(22)]
	string RelativeTimePosition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(22)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(23)]
	string AbsoluteTimePosition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(23)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(24)]
	int RelativeCounterPosition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(24)]
		get;
	}

	[DispId(25)]
	int AbsoluteCounterPosition
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(25)]
		get;
	}

	[DispId(26)]
	string CurrentTransportActions
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(26)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(27)]
	string LastChange
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(27)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(28)]
	string A_ARG_TYPE_SeekMode
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(28)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(29)]
	string A_ARG_TYPE_SeekTarget
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(29)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[DispId(30)]
	uint A_ARG_TYPE_InstanceID
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(30)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(31)]
	void SetAVTransportURI([In] uint InstanceID, [In][MarshalAs(UnmanagedType.BStr)] string CurrentURI, [In][MarshalAs(UnmanagedType.BStr)] string CurrentURIMetaData);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32)]
	void SetNextAVTransportURI([In] uint InstanceID, [In][MarshalAs(UnmanagedType.BStr)] string NextURI, [In][MarshalAs(UnmanagedType.BStr)] string NextURIMetaData);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(33)]
	void GetMediaInfo([In] uint InstanceID, [In][Out] ref uint pNrTracks, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pMediaDuration, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pCurrentURI, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pCurrentURIMetaData, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pNextURI, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pNextURIMetaData, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pPlayMedium, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pRecordMedium, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pWriteStatus);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(34)]
	void GetTransportInfo([In] uint InstanceID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pCurrentTransportState, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pCurrentTransportStatus, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pCurrentSpeed);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(35)]
	void GetPositionInfo([In] uint InstanceID, [In][Out] ref uint pTrack, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pTrackDuration, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pTrackMetaData, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pTrackURI, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pRelTime, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pAbsTime, [In][Out] ref int pRelCount, [In][Out] ref int pAbsCount);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(36)]
	void GetDeviceCapabilities([In] uint InstanceID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pPlayMedia, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pRecMedia, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pRecQualityModes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(37)]
	void GetTransportSettings([In] uint InstanceID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pPlayMode, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pRecQualityMode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(38)]
	void stop([In] uint InstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(39)]
	void play([In] uint InstanceID, [In][MarshalAs(UnmanagedType.BStr)] string Speed);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(40)]
	void pause([In] uint InstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(41)]
	void Record([In] uint InstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(42)]
	void Seek([In] uint InstanceID, [In][MarshalAs(UnmanagedType.BStr)] string Unit, [In][MarshalAs(UnmanagedType.BStr)] string Target);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(43)]
	void next([In] uint InstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(44)]
	void previous([In] uint InstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(45)]
	void SetPlayMode([In] uint InstanceID, [In][MarshalAs(UnmanagedType.BStr)] string NewPlayMode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(46)]
	void SetRecordQualityMode([In] uint InstanceID, [In][MarshalAs(UnmanagedType.BStr)] string NewRecordQualityMode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(47)]
	void GetCurrentTransportActions([In] uint InstanceID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pActions);
}
