using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Character
{
	public static Game TheGame;

	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private List<Action> c;

	[CompilerGenerated]
	private Player.Gender d;

	[CompilerGenerated]
	private string e;

	[CompilerGenerated]
	private string f;

	[CompilerGenerated]
	private string g;

	[CompilerGenerated]
	private bool h;

	[CompilerGenerated]
	private bool i;

	[CompilerGenerated]
	private bool j;

	[CompilerGenerated]
	private List<CustomProperty> k;

	public string Charname
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

	public string CharnameOverride
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

	public List<Action> Actions
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

	public Player.Gender CharGender
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

	public string CurrentRoom
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

	public string Description
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

	public string CharPortrait
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

	public bool bEnterFirstTime
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

	public bool bLeaveFirstTime
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

	public bool bAllowInventoryInteraction
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

	public List<CustomProperty> CustomProperties
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

	public string CharProp
	{
		get
		{
			return Charname;
		}
		set
		{
			Charname = value;
		}
	}

	public Character()
	{
		Charname = string.Empty;
		CharnameOverride = string.Empty;
		Actions = new List<Action>();
		CharGender = Player.Gender.Other;
		CurrentRoom = Room.VoidRoomGuid.ToString();
		Description = string.Empty;
		CharPortrait = string.Empty;
		bEnterFirstTime = false;
		bLeaveFirstTime = false;
		bAllowInventoryInteraction = false;
		CustomProperties = new List<CustomProperty>();
	}

	public Character(string name)
	{
		Charname = name;
		CharnameOverride = string.Empty;
		Actions = new List<Action>();
		CharGender = Player.Gender.Other;
		CurrentRoom = Room.VoidRoomGuid.ToString();
		Description = string.Empty;
		CharPortrait = string.Empty;
		bEnterFirstTime = false;
		bLeaveFirstTime = false;
		bAllowInventoryInteraction = false;
		CustomProperties = new List<CustomProperty>();
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
		item = new Action();
		Actions.Add(item);
		item.name = "<<On Character Enter>>";
		item = new Action();
		Actions.Add(item);
		item.name = "<<On Character Leave>>";
	}

	public override string ToString()
	{
		if (CharnameOverride == string.Empty)
		{
			return Charname;
		}
		if (TheGame == null)
		{
			return Charname;
		}
		return TheGame.PerformTextReplacements(CharnameOverride, null);
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

	public void UpdateFromSave(Character SvChar)
	{
		CharnameOverride = SvChar.CharnameOverride;
		CurrentRoom = SvChar.CurrentRoom;
		CharPortrait = SvChar.CharPortrait;
		bEnterFirstTime = SvChar.bEnterFirstTime;
		bLeaveFirstTime = SvChar.bLeaveFirstTime;
		foreach (CustomProperty customProperty in SvChar.CustomProperties)
		{
			foreach (CustomProperty customProperty2 in CustomProperties)
			{
				if (customProperty2.Name == customProperty.Name)
				{
					customProperty2.Value = customProperty.Value;
				}
			}
		}
		foreach (Action action in SvChar.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + Charname.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_.Append("\"" + CharnameOverride.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_.Append("\"" + Description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + CharGender.ToString() + "\",");
		A_.Append("\"" + CurrentRoom + "\",");
		A_.Append(bAllowInventoryInteraction.ToString().ToLower() + ",");
		A_.Append("\"" + CharPortrait + "\",");
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
}
