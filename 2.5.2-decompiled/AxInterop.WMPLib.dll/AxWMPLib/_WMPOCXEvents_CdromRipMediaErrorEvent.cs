using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_CdromRipMediaErrorEvent
{
	public IWMPCdromRip pCdromRip;

	public object pMedia;

	public _WMPOCXEvents_CdromRipMediaErrorEvent(IWMPCdromRip pCdromRip, object pMedia)
	{
		this.pCdromRip = pCdromRip;
		this.pMedia = pMedia;
	}
}
