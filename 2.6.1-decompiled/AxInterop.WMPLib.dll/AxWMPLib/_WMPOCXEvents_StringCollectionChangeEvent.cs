using WMPLib;

namespace AxWMPLib;

public class _WMPOCXEvents_StringCollectionChangeEvent
{
	public object pdispStringCollection;

	public WMPStringCollectionChangeEventType change;

	public int lCollectionIndex;

	public _WMPOCXEvents_StringCollectionChangeEvent(object pdispStringCollection, WMPStringCollectionChangeEventType change, int lCollectionIndex)
	{
		this.pdispStringCollection = pdispStringCollection;
		this.change = change;
		this.lCollectionIndex = lCollectionIndex;
	}
}
