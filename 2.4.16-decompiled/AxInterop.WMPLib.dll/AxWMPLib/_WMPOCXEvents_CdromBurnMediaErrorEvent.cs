using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_CdromBurnMediaErrorEvent
{
	public IWMPCdromBurn pCdromBurn;

	public object pMedia;

	public _WMPOCXEvents_CdromBurnMediaErrorEvent(IWMPCdromBurn pCdromBurn, object pMedia)
	{
		this.pCdromBurn = pCdromBurn;
		this.pMedia = pMedia;
	}
}
