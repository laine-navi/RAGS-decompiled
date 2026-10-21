namespace AxWMPLib;

public class _WMPOCXEvents_PositionChangeEvent
{
	public double oldPosition;

	public double newPosition;

	public _WMPOCXEvents_PositionChangeEvent(double oldPosition, double newPosition)
	{
		this.oldPosition = oldPosition;
		this.newPosition = newPosition;
	}
}
