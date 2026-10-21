using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_CurrentPlaylistChangeEvent
{
	public WMPPlaylistChangeEventType change;

	public _WMPOCXEvents_CurrentPlaylistChangeEvent(WMPPlaylistChangeEventType change)
	{
		this.change = change;
	}
}
