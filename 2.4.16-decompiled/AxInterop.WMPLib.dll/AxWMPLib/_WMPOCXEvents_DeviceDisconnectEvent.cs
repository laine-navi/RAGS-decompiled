using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_DeviceDisconnectEvent
{
	public IWMPSyncDevice pDevice;

	public _WMPOCXEvents_DeviceDisconnectEvent(IWMPSyncDevice pDevice)
	{
		this.pDevice = pDevice;
	}
}
