using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_CdromBurnErrorEvent
{
	public IWMPCdromBurn pCdromBurn;

	public int hrError;

	public _WMPOCXEvents_CdromBurnErrorEvent(IWMPCdromBurn pCdromBurn, int hrError)
	{
		this.pCdromBurn = pCdromBurn;
		this.hrError = hrError;
	}
}
