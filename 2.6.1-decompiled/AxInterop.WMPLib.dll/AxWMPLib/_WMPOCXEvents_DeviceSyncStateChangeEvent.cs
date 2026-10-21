using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_DeviceSyncStateChangeEvent
{
	public IWMPSyncDevice pDevice;

	public WMPSyncState newState;

	public _WMPOCXEvents_DeviceSyncStateChangeEvent(IWMPSyncDevice pDevice, WMPSyncState newState)
	{
		this.pDevice = pDevice;
		this.newState = newState;
	}
}
