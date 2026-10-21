namespace WMPLib;

public enum WMPBurnState
{
	wmpbsUnknown,
	wmpbsBusy,
	wmpbsReady,
	wmpbsWaitingForDisc,
	wmpbsRefreshStatusPending,
	wmpbsPreparingToBurn,
	wmpbsBurning,
	wmpbsStopped,
	wmpbsErasing,
	wmpbsDownloading
}
