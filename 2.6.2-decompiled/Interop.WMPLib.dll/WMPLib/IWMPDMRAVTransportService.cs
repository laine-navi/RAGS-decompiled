using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WMPLib;

[ComImport]
[Guid("4E195DB1-9E29-47FC-9CE1-DE9937D32925")]
[TypeLibType(4160)]
public interface IWMPDMRAVTransportService
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

	[DispId(45)]
	string CurrentProtocolInfo
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(45)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
	}

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(31)]
	void SetAVTransportURI([In][MarshalAs(UnmanagedType.IUnknown)] object punkRemoteEndpointInfo, [In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrCurrentURI, [In][MarshalAs(UnmanagedType.BStr)] string bstrCurrentURIMetaData);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(33)]
	void GetMediaInfo([In] uint ulInstanceID, out uint pulNumTracks, [MarshalAs(UnmanagedType.BStr)] out string pbstrMediaDuration, [MarshalAs(UnmanagedType.BStr)] out string pbstrCurrentURI, [MarshalAs(UnmanagedType.BStr)] out string pbstrCurrentURIMetaData, [MarshalAs(UnmanagedType.BStr)] out string pbstrNextURI, [MarshalAs(UnmanagedType.BStr)] out string pNextURIMetaData, [MarshalAs(UnmanagedType.BStr)] out string pbstrPlayMedium, [MarshalAs(UnmanagedType.BStr)] out string pbstrRecordMedium, [MarshalAs(UnmanagedType.BStr)] out string pbstrWriteStatus);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(34)]
	void GetTransportInfo([In] uint ulInstanceID, [MarshalAs(UnmanagedType.BStr)] out string pbstrCurrentTransportState, [MarshalAs(UnmanagedType.BStr)] out string pbstrCurrentTransportStatus, [MarshalAs(UnmanagedType.BStr)] out string pbstrCurrentSpeed);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(35)]
	void GetPositionInfo([In] uint ulInstanceID, out uint pTrack, [MarshalAs(UnmanagedType.BStr)] out string pbstrTrackDuration, [MarshalAs(UnmanagedType.BStr)] out string pbstrTrackMetaData, [MarshalAs(UnmanagedType.BStr)] out string pbstrTrackURI, [MarshalAs(UnmanagedType.BStr)] out string pbstrRelTime, [MarshalAs(UnmanagedType.BStr)] out string pbstrAbsTime, out int plRelCount, out int plAbsCount);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(36)]
	void GetDeviceCapabilities([In] uint ulInstanceID, [MarshalAs(UnmanagedType.BStr)] out string pbstrPlayMedia, [MarshalAs(UnmanagedType.BStr)] out string pbstrRecMedia, [MarshalAs(UnmanagedType.BStr)] out string pbstrRecQualityModes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(37)]
	void GetTransportSettings([In] uint ulInstanceID, [MarshalAs(UnmanagedType.BStr)] out string pbstrPlayMode, [MarshalAs(UnmanagedType.BStr)] out string pbstrRecQualityMode);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(38)]
	void stop([In] uint ulInstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(39)]
	void play([In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrSpeed);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(40)]
	void pause([In] uint ulInstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(41)]
	void Seek([In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrUnit, [In][MarshalAs(UnmanagedType.BStr)] string bstrTarget);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(42)]
	void next([In] uint ulInstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(43)]
	void previous([In] uint ulInstanceID);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(44)]
	void GetCurrentTransportActions([In] uint ulInstanceID, [In][Out][MarshalAs(UnmanagedType.BStr)] ref string pbstrActions);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(32)]
	void SetNextAVTransportURI([In][MarshalAs(UnmanagedType.IUnknown)] object punkRemoteEndpointInfo, [In] uint ulInstanceID, [In][MarshalAs(UnmanagedType.BStr)] string bstrNextURI, [In][MarshalAs(UnmanagedType.BStr)] string bstrNextURIMetaData);
}
