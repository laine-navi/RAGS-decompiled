using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_CdromRipStateChangeEvent
{
	public IWMPCdromRip pCdromRip;

	public WMPRipState wmprs;

	public _WMPOCXEvents_CdromRipStateChangeEvent(IWMPCdromRip pCdromRip, WMPRipState wmprs)
	{
		this.pCdromRip = pCdromRip;
		this.wmprs = wmprs;
	}
}
