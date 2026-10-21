namespace AxWMPLib;

public class _WMPOCXEvents_MouseMoveEvent
{
	public short nButton;

	public short nShiftState;

	public int fX;

	public int fY;

	public _WMPOCXEvents_MouseMoveEvent(short nButton, short nShiftState, int fX, int fY)
	{
		this.nButton = nButton;
		this.nShiftState = nShiftState;
		this.fX = fX;
		this.fY = fY;
	}
}
