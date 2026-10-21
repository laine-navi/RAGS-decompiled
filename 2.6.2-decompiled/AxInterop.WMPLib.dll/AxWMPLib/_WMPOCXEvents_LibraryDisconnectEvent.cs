using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_LibraryDisconnectEvent
{
	public IWMPLibrary pLibrary;

	public _WMPOCXEvents_LibraryDisconnectEvent(IWMPLibrary pLibrary)
	{
		this.pLibrary = pLibrary;
	}
}
