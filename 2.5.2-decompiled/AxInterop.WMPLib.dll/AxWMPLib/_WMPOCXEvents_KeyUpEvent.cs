namespace AxWMPLib;

public class _WMPOCXEvents_KeyUpEvent
{
	public short nKeyCode;

	public short nShiftState;

	public _WMPOCXEvents_KeyUpEvent(short nKeyCode, short nShiftState)
	{
		this.nKeyCode = nKeyCode;
		this.nShiftState = nShiftState;
	}
}
