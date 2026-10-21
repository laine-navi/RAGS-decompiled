using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_DeviceConnectEvent
{
	public IWMPSyncDevice pDevice;

	public _WMPOCXEvents_DeviceConnectEvent(IWMPSyncDevice pDevice)
	{
		this.pDevice = pDevice;
	}
}
