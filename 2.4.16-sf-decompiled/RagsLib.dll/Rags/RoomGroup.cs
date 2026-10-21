using System.Collections;
using System.Drawing;

namespace Rags;

public sealed class RoomGroup
{
	public int maxx;

	public int maxy;

	public int minx;

	public int miny;

	public Point OrigStart;

	public string MapGroupName = string.Empty;

	public ArrayList DrawRooms = new ArrayList();

	public RoomGroup(string name)
	{
		MapGroupName = name;
	}
}
