using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_DeviceStatusChangeEvent
{
	public IWMPSyncDevice pDevice;

	public WMPDeviceStatus newStatus;

	public _WMPOCXEvents_DeviceStatusChangeEvent(IWMPSyncDevice pDevice, WMPDeviceStatus newStatus)
	{
		this.pDevice = pDevice;
		this.newStatus = newStatus;
	}
}
