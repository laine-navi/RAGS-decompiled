using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Player
{
	public enum Gender
	{
		Male,
		Female,
		Other
	}

	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private Room c;

	[CompilerGenerated]
	private Room d;

	[CompilerGenerated]
	private Gender e;

	[CompilerGenerated]
	private bool f;

	[CompilerGenerated]
	private bool g;

	[CompilerGenerated]
	private string h;

	[CompilerGenerated]
	private string i;

	[CompilerGenerated]
	private List<Action> j;

	[CompilerGenerated]
	private bool k;

	[CompilerGenerated]
	private double l;

	[CompilerGenerated]
	private List<CustomProperty> m;

	public string Name
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

	public string Description
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

	public Room StartingRoom
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

	public Room CurrentRoom
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

	public Gender PlayerGender
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

	public bool bPromptForName
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

	public bool bPromptForGender
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

	public string PlayerPortrait
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

	public string PlayerLayeredImage
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

	public List<Action> Actions
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

	public bool bEnforceWeight
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

	public double dWeightLimit
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

	public List<CustomProperty> CustomProperties
	{
		[CompilerGenerated]
		get
		{
			return m;
		}
		[CompilerGenerated]
		set
		{
			m = value;
		}
	}

	public Player()
	{
		Name = "";
		Description = "";
		StartingRoom = null;
		CurrentRoom = null;
		PlayerGender = Gender.Male;
		bPromptForName = false;
		bPromptForGender = false;
		PlayerPortrait = "";
		PlayerLayeredImage = "";
		Actions = new List<Action>();
		bEnforceWeight = false;
		dWeightLimit = 100.5;
		CustomProperties = new List<CustomProperty>();
		Action item = new Action
		{
			name = "<<On Game Start>>"
		};
		Actions.Add(item);
		item = new Action
		{
			name = "<<On Player Enter>>"
		};
		Actions.Add(item);
		item = new Action();
		Actions.Add(item);
		item.name = "<<On Player Leave>>";
	}

	public Action GetActionByName(string actionname)
	{
		for (int i = 0; i < Actions.Count; i++)
		{
			if (string.Compare(actionname, Actions[i].name, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return Actions[i];
			}
		}
		return null;
	}

	public void UpdateFromSave(Player player)
	{
		Name = player.Name;
		Description = player.Description;
		CurrentRoom = player.CurrentRoom;
		PlayerGender = player.PlayerGender;
		PlayerPortrait = player.PlayerPortrait;
		foreach (CustomProperty customProperty in player.CustomProperties)
		{
			foreach (CustomProperty customProperty2 in CustomProperties)
			{
				if (customProperty2.Name == customProperty.Name)
				{
					customProperty2.Value = customProperty.Value;
				}
			}
		}
		foreach (Action action in player.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + Name + "\",");
		A_.Append("\"" + Description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + StartingRoom.UniqueID.ToString() + "\",");
		A_.Append("\"" + PlayerGender.ToString() + "\",");
		A_.Append("\"" + PlayerLayeredImage + "\",");
		A_.Append(bPromptForName.ToString().ToLower() + ",");
		A_.Append(bPromptForGender.ToString().ToLower() + ",");
		A_.Append("\"" + PlayerPortrait + "\",");
		A_.Append(bEnforceWeight.ToString().ToLower() + ",");
		A_.Append(dWeightLimit + ",");
		A_.Append("[");
		int num = 0;
		foreach (CustomProperty customProperty in CustomProperties)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			A_.Append("[");
			A_.Append("\"" + customProperty.Name.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
			A_.Append("\"" + customProperty.Value.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\"");
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
}
