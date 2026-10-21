namespace AxWMPLib;

public class _WMPOCXEvents_MediaCollectionAttributeStringAddedEvent
{
	public string bstrAttribName;

	public string bstrAttribVal;

	public _WMPOCXEvents_MediaCollectionAttributeStringAddedEvent(string bstrAttribName, string bstrAttribVal)
	{
		this.bstrAttribName = bstrAttribName;
		this.bstrAttribVal = bstrAttribVal;
	}
}
