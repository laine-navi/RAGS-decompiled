using System;
using System.Runtime.CompilerServices;

namespace Rags;

public class RoomComboItem
{
	[CompilerGenerated]
	private Guid a;

	[CompilerGenerated]
	private string b;

	public Guid UniqueID
	{
		[CompilerGenerated]
		get
		{
			return a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	public string RoomName
	{
		[CompilerGenerated]
		get
		{
			return b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	public RoomComboItem()
	{
		UniqueID = Guid.NewGuid();
		RoomName = string.Empty;
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
