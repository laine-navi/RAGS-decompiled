using System.Drawing;

namespace Rags;

public sealed class RoomData
{
	public Room TheRoom;

	public Point pos = default;

	public bool DrawnAlready;

	public bool DrawThisRoom;

	public RoomData(Point curpoint, Room temproom)
	{
		TheRoom = temproom;
		pos = curpoint;
	}
}
