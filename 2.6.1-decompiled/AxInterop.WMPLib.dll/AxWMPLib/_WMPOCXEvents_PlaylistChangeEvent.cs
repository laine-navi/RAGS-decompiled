using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_PlaylistChangeEvent
{
	public object playlist;

	public WMPPlaylistChangeEventType change;

	public _WMPOCXEvents_PlaylistChangeEvent(object playlist, WMPPlaylistChangeEventType change)
	{
		this.playlist = playlist;
		this.change = change;
	}
}
