using System.Drawing;

namespace Rags;

public class RoomData
{
	public Room TheRoom;

	public Point pos;

	public bool DrawnAlready;

	public bool DrawThisRoom;

	public RoomData(Point curpoint, Room temproom)
	{
		TheRoom = temproom;
		pos = curpoint;
	}
}
