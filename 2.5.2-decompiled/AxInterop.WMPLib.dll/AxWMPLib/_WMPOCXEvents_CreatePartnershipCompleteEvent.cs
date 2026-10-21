using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_CreatePartnershipCompleteEvent
{
	public IWMPSyncDevice pDevice;

	public int hrResult;

	public _WMPOCXEvents_CreatePartnershipCompleteEvent(IWMPSyncDevice pDevice, int hrResult)
	{
		this.pDevice = pDevice;
		this.hrResult = hrResult;
	}
}
