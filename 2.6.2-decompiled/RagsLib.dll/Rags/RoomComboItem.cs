using System;

namespace Rags;

public class RoomComboItem
{
	public Guid UniqueID;

	public string RoomName = string.Empty;

	public RoomComboItem()
	{
	}

	public RoomComboItem(Guid Uid, string name)
	{
		UniqueID = Uid;
		RoomName = name;
	}

	public override string ToString()
	{
		return RoomName;
	}
}
