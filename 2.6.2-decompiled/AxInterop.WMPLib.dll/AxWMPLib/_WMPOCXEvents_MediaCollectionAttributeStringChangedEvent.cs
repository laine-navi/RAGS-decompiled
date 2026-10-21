namespace AxWMPLib;

public class _WMPOCXEvents_MediaCollectionAttributeStringChangedEvent
{
	public string bstrAttribName;

	public string bstrOldAttribVal;

	public string bstrNewAttribVal;

	public _WMPOCXEvents_MediaCollectionAttributeStringChangedEvent(string bstrAttribName, string bstrOldAttribVal, string bstrNewAttribVal)
	{
		this.bstrAttribName = bstrAttribName;
		this.bstrOldAttribVal = bstrOldAttribVal;
		this.bstrNewAttribVal = bstrNewAttribVal;
	}
}
