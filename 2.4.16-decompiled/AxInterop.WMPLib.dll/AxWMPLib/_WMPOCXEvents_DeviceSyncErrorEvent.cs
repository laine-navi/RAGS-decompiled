using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_DeviceSyncErrorEvent
{
	public IWMPSyncDevice pDevice;

	public object pMedia;

	public _WMPOCXEvents_DeviceSyncErrorEvent(IWMPSyncDevice pDevice, object pMedia)
	{
		this.pDevice = pDevice;
		this.pMedia = pMedia;
	}
}
