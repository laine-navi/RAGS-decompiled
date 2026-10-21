using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_DeviceEstimationEvent
{
	public IWMPSyncDevice pDevice;

	public int hrResult;

	public long qwEstimatedUsedSpace;

	public long qwEstimatedSpace;

	public _WMPOCXEvents_DeviceEstimationEvent(IWMPSyncDevice pDevice, int hrResult, long qwEstimatedUsedSpace, long qwEstimatedSpace)
	{
		this.pDevice = pDevice;
		this.hrResult = hrResult;
		this.qwEstimatedUsedSpace = qwEstimatedUsedSpace;
		this.qwEstimatedSpace = qwEstimatedSpace;
	}
}
