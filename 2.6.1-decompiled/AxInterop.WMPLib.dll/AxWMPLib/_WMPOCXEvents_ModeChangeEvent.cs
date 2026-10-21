namespace AxWMPLib;

public class _WMPOCXEvents_ModeChangeEvent
{
	public string modeName;

	public bool newValue;

	public _WMPOCXEvents_ModeChangeEvent(string modeName, bool newValue)
	{
		this.modeName = modeName;
		this.newValue = newValue;
	}
}
