namespace WMPLib;

public enum WMPPlayState
{
	wmppsUndefined,
	wmppsStopped,
	wmppsPaused,
	wmppsPlaying,
	wmppsScanForward,
	wmppsScanReverse,
	wmppsBuffering,
	wmppsWaiting,
	wmppsMediaEnded,
	wmppsTransitioning,
	wmppsReady,
	wmppsReconnecting,
	wmppsLast
}
