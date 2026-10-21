using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_CdromBurnStateChangeEvent
{
	public IWMPCdromBurn pCdromBurn;

	public WMPBurnState wmpbs;

	public _WMPOCXEvents_CdromBurnStateChangeEvent(IWMPCdromBurn pCdromBurn, WMPBurnState wmpbs)
	{
		this.pCdromBurn = pCdromBurn;
		this.wmpbs = wmpbs;
	}
}
