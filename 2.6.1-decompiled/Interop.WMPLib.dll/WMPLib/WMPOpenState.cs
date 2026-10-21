namespace WMPLib;

public enum WMPOpenState
{
	wmposUndefined,
	wmposPlaylistChanging,
	wmposPlaylistLocating,
	wmposPlaylistConnecting,
	wmposPlaylistLoading,
	wmposPlaylistOpening,
	wmposPlaylistOpenNoMedia,
	wmposPlaylistChanged,
	wmposMediaChanging,
	wmposMediaLocating,
	wmposMediaConnecting,
	wmposMediaLoading,
	wmposMediaOpening,
	wmposMediaOpen,
	wmposBeginCodecAcquisition,
	wmposEndCodecAcquisition,
	wmposBeginLicenseAcquisition,
	wmposEndLicenseAcquisition,
	wmposBeginIndividualization,
	wmposEndIndividualization,
	wmposMediaWaiting,
	wmposOpeningUnknownURL
}
