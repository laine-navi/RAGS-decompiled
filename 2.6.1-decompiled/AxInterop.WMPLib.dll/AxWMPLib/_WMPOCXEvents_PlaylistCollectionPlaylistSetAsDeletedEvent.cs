namespace AxWMPLib;

public class _WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEvent
{
	public string bstrPlaylistName;

	public bool varfIsDeleted;

	public _WMPOCXEvents_PlaylistCollectionPlaylistSetAsDeletedEvent(string bstrPlaylistName, bool varfIsDeleted)
	{
		this.bstrPlaylistName = bstrPlaylistName;
		this.varfIsDeleted = varfIsDeleted;
	}
}
