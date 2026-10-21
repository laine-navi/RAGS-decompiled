namespace AxWMPLib;

public class _WMPOCXEvents_MediaCollectionAttributeStringRemovedEvent
{
	public string bstrAttribName;

	public string bstrAttribVal;

	public _WMPOCXEvents_MediaCollectionAttributeStringRemovedEvent(string bstrAttribName, string bstrAttribVal)
	{
		this.bstrAttribName = bstrAttribName;
		this.bstrAttribVal = bstrAttribVal;
	}
}
