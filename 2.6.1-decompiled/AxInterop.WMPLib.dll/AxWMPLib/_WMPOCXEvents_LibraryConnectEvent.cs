using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_LibraryConnectEvent
{
	public IWMPLibrary pLibrary;

	public _WMPOCXEvents_LibraryConnectEvent(IWMPLibrary pLibrary)
	{
		this.pLibrary = pLibrary;
	}
}
