using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Room
{
	public static Guid CurrentRoomGuid = new Guid("00000000-0000-0000-0000-000000000001");

	public static Guid VoidRoomGuid = new Guid("00000000-0000-0000-0000-000000000002");

	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private List<Exit> e;

	[CompilerGenerated]
	private List<Action> f;

	[CompilerGenerated]
	private List<CustomProperty> g;

	[CompilerGenerated]
	private string h;

	[CompilerGenerated]
	private string i;

	[CompilerGenerated]
	private bool j;

	[CompilerGenerated]
	private bool k;

	[CompilerGenerated]
	private Guid l;

	public string Description
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

	public string SDesc
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

	public string Name
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

	public string Group
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

	public List<Exit> Exits
	{
		[CompilerGenerated]
		get
		{
			return e;
		}
		[CompilerGenerated]
		set
		{
			e = value;
		}
	}

	public List<Action> Actions
	{
		[CompilerGenerated]
		get
		{
			return f;
		}
		[CompilerGenerated]
		set
		{
			f = value;
		}
	}

	public List<CustomProperty> CustomProperties
	{
		[CompilerGenerated]
		get
		{
			return g;
		}
		[CompilerGenerated]
		set
		{
			g = value;
		}
	}

	public string RoomPic
	{
		[CompilerGenerated]
		get
		{
			return h;
		}
		[CompilerGenerated]
		set
		{
			h = value;
		}
	}

	public string LayeredRoomPic
	{
		[CompilerGenerated]
		get
		{
			return i;
		}
		[CompilerGenerated]
		set
		{
			i = value;
		}
	}

	public bool bEnterFirstTime
	{
		[CompilerGenerated]
		get
		{
			return j;
		}
		[CompilerGenerated]
		set
		{
			j = value;
		}
	}

	public bool bLeaveFirstTime
	{
		[CompilerGenerated]
		get
		{
			return k;
		}
		[CompilerGenerated]
		set
		{
			k = value;
		}
	}

	public Guid UniqueID
	{
		[CompilerGenerated]
		get
		{
			return l;
		}
		[CompilerGenerated]
		set
		{
			l = value;
		}
	}

	public string NameProp => Name;

	public Room()
	{
		Description = string.Empty;
		SDesc = string.Empty;
		Name = string.Empty;
		Group = "None";
		Exits = new List<Exit>();
		Actions = new List<Action>();
		CustomProperties = new List<CustomProperty>();
		RoomPic = "None";
		LayeredRoomPic = "None";
		bEnterFirstTime = false;
		bLeaveFirstTime = false;
		UniqueID = Guid.NewGuid();
		Action item = new Action
		{
			name = "<<On Player Enter First Time>>"
		};
		Actions.Add(item);
		item = new Action
		{
			name = "<<On Player Enter>>"
		};
		Actions.Add(item);
		item = new Action();
		Actions.Add(item);
		item.name = "<<On Player Leave First Time>>";
		item = new Action();
		Actions.Add(item);
		item.name = "<<On Player Leave>>";
		Exit item2 = new Exit
		{
			Direction = Exit.Directions.North
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.South
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.West
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.East
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.Up
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.Down
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.NorthWest
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.NorthEast
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.SouthWest
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.SouthEast
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.In
		};
		Exits.Add(item2);
		item2 = new Exit
		{
			Direction = Exit.Directions.Out
		};
		Exits.Add(item2);
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + SDesc.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + Description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + Name.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + Group + "\",");
		A_.Append("\"" + RoomPic + "\",");
		A_.Append("\"" + LayeredRoomPic + "\",");
		A_.Append(bEnterFirstTime.ToString().ToLower() + ",");
		A_.Append(bLeaveFirstTime.ToString().ToLower() + ",");
		A_.Append("\"" + UniqueID.ToString() + "\",");
		A_.Append("[");
		int num = 0;
		foreach (Exit exit in Exits)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			A_.Append("[");
			A_.Append("\"" + exit.Direction.ToString() + "\",");
			A_.Append(exit.bActive.ToString().ToLower() + ",");
			A_.Append("\"" + exit.DestinationRoom + "\",");
			A_.Append("\"" + exit.PortalObjectName + "\"");
			A_.Append("]");
		}
		A_.Append("],");
		A_.Append("[");
		num = 0;
		foreach (CustomProperty customProperty in CustomProperties)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			A_.Append("[");
			A_.Append("\"" + customProperty.Name + "\",");
			A_.Append("\"" + customProperty.Value + "\"");
			A_.Append("]");
		}
		A_.Append("],");
		A_.Append("[");
		num = 0;
		foreach (Action action in Actions)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			action.a(ref A_);
		}
		A_.Append("]");
		A_.Append("]");
		return A_.ToString();
	}

	public Exit GetExit(Exit.Directions dir)
	{
		for (int i = 0; i < Exits.Count; i++)
		{
			if (Exits[i].Direction == dir)
			{
				return Exits[i];
			}
		}
		return null;
	}

	public Action GetActionByName(string actionname)
	{
		if (Actions != null)
		{
			for (int i = 0; i < Actions.Count; i++)
			{
				if (string.Compare(actionname, Actions[i].name, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return Actions[i];
				}
			}
		}
		return null;
	}

	public string GetName()
	{
		if (SDesc.Trim().Length > 0)
		{
			return SDesc;
		}
		return Name;
	}

	public void FixExits()
	{
		Exit exit = null;
		if (GetExit(Exit.Directions.North) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.North;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.South) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.South;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.East) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.East;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.West) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.West;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Up) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.Up;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Down) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.Down;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.NorthWest) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.NorthWest;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.NorthEast) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.NorthEast;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.SouthWest) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.SouthWest;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.SouthEast) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.SouthEast;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.In) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.In;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Out) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.Out;
			Exits.Add(exit);
		}
	}

	public override string ToString()
	{
		return Name;
	}

	public void UpdateFromSave(Room temproom)
	{
		foreach (Exit exit in temproom.Exits)
		{
			GetExit(exit.Direction)?.a(exit);
		}
		foreach (Action action in temproom.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
		foreach (CustomProperty customProperty in temproom.CustomProperties)
		{
			foreach (CustomProperty customProperty2 in CustomProperties)
			{
				if (customProperty2.Name == customProperty.Name)
				{
					customProperty2.Value = customProperty.Value;
				}
			}
		}
		bEnterFirstTime = temproom.bEnterFirstTime;
		bLeaveFirstTime = temproom.bLeaveFirstTime;
	}
}
