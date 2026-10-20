using System.Runtime.CompilerServices;

namespace Rags;

public class Exit
{
	public enum Directions
	{
		Empty,
		North,
		South,
		East,
		West,
		Up,
		Down,
		NorthEast,
		NorthWest,
		SouthWest,
		SouthEast,
		In,
		Out
	}

	[CompilerGenerated]
	private Directions m_a;

	[CompilerGenerated]
	private bool b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	public Directions Direction
	{
		[CompilerGenerated]
		get
		{
			return this.m_a;
		}
		[CompilerGenerated]
		set
		{
			this.m_a = value;
		}
	}

	public bool bActive
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

	public string DestinationRoom
	{
		[CompilerGenerated]
		get
		{
			return c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	public string PortalObjectName
	{
		[CompilerGenerated]
		get
		{
			return d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	public Exit()
	{
		Direction = Directions.Empty;
		bActive = false;
		DestinationRoom = string.Empty;
		PortalObjectName = "<None>";
	}

	public bool MovePlayer()
	{
		bool result = false;
		_ = bActive;
		return result;
	}

	public static Directions GetOppositeDir(Directions dir)
	{
		Directions result = Directions.North;
		switch (dir)
		{
		case Directions.North:
			result = Directions.South;
			break;
		case Directions.South:
			result = Directions.North;
			break;
		case Directions.West:
			result = Directions.East;
			break;
		case Directions.East:
			result = Directions.West;
			break;
		case Directions.Up:
			result = Directions.Down;
			break;
		case Directions.Down:
			result = Directions.Up;
			break;
		case Directions.NorthWest:
			result = Directions.SouthEast;
			break;
		case Directions.NorthEast:
			result = Directions.SouthWest;
			break;
		case Directions.SouthWest:
			result = Directions.NorthEast;
			break;
		case Directions.SouthEast:
			result = Directions.NorthWest;
			break;
		case Directions.In:
			result = Directions.Out;
			break;
		case Directions.Out:
			result = Directions.In;
			break;
		}
		return result;
	}

	internal void a(Exit A_0)
	{
		bActive = A_0.bActive;
	}
}
