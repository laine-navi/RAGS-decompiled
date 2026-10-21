namespace AxWMPLib;

public class _WMPOCXEvents_DoubleClickEvent
{
	public short nButton;

	public short nShiftState;

	public int fX;

	public int fY;

	public _WMPOCXEvents_DoubleClickEvent(short nButton, short nShiftState, int fX, int fY)
	{
		this.nButton = nButton;
		this.nShiftState = nShiftState;
		this.fX = fX;
		this.fY = fY;
	}
}
