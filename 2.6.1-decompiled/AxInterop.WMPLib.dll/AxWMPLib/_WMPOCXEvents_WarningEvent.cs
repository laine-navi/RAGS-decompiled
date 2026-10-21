namespace AxWMPLib;

public class _WMPOCXEvents_WarningEvent
{
	public int warningType;

	public int param;

	public string description;

	public _WMPOCXEvents_WarningEvent(int warningType, int param, string description)
	{
		this.warningType = warningType;
		this.param = param;
		this.description = description;
	}
}
