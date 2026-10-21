namespace AxWMPLib;

public class _WMPOCXEvents_KeyDownEvent
{
	public short nKeyCode;

	public short nShiftState;

	public _WMPOCXEvents_KeyDownEvent(short nKeyCode, short nShiftState)
	{
		this.nKeyCode = nKeyCode;
		this.nShiftState = nShiftState;
	}
}
