using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class GameObject
{
	public enum LocationType
	{
		LT_NULL,
		LT_IN_OBJECT,
		LT_ON_OBJECT,
		LT_ROOM,
		LT_PLAYER,
		LT_CHARACTER,
		LT_PORTAL
	}

	public static Game TheGame = null;

	public static Guid SelfObjectGuid = new Guid("00000000-0000-0000-0000-000000000004");

	[CompilerGenerated]
	private LocationType a;

	[CompilerGenerated]
	private Guid b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private string e;

	[CompilerGenerated]
	private string f;

	[CompilerGenerated]
	private string g;

	[CompilerGenerated]
	private string h;

	[CompilerGenerated]
	private List<Action> i;

	[CompilerGenerated]
	private List<string> j;

	[CompilerGenerated]
	private List<CustomProperty> k;

	[CompilerGenerated]
	private bool l;

	[CompilerGenerated]
	private bool m;

	[CompilerGenerated]
	private bool n;

	[CompilerGenerated]
	private bool o;

	[CompilerGenerated]
	private bool p;

	[CompilerGenerated]
	private bool q;

	[CompilerGenerated]
	private bool r;

	[CompilerGenerated]
	private double s;

	[CompilerGenerated]
	private bool t;

	[CompilerGenerated]
	private bool u;

	[CompilerGenerated]
	private bool v;

	[CompilerGenerated]
	private bool w;

	[CompilerGenerated]
	private bool x;

	[CompilerGenerated]
	private bool y;

	[CompilerGenerated]
	private bool z;

	[CompilerGenerated]
	private bool aa;

	[CompilerGenerated]
	private bool ab;

	public LocationType locationtype
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

	public Guid UniqueIdentifier
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

	public string locationname
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

	public string GroupName
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

	public string SortName
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public string name
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

	public string description
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

	public string sdesc
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

	public string preposition
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

	public List<Action> Actions
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

	public List<string> LayeredZoneLevels
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

	public bool bCarryable
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

	public bool bWearable
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

	public bool bOpenable
	{
		[CompilerGenerated]
		get
		{
			return n;
		}
		[CompilerGenerated]
		set
		{
			n = value;
		}
	}

	public bool bLockable
	{
		[CompilerGenerated]
		get
		{
			return o;
		}
		[CompilerGenerated]
		set
		{
			o = value;
		}
	}

	public bool bEnterable
	{
		[CompilerGenerated]
		get
		{
			return p;
		}
		[CompilerGenerated]
		set
		{
			p = value;
		}
	}

	public bool bReadable
	{
		[CompilerGenerated]
		get
		{
			return q;
		}
		[CompilerGenerated]
		set
		{
			q = value;
		}
	}

	public bool bContainer
	{
		[CompilerGenerated]
		get
		{
			return r;
		}
		[CompilerGenerated]
		set
		{
			r = value;
		}
	}

	public double dWeight
	{
		[CompilerGenerated]
		get
		{
			return s;
		}
		[CompilerGenerated]
		set
		{
			s = value;
		}
	}

	public bool bWorn
	{
		[CompilerGenerated]
		get
		{
			return t;
		}
		[CompilerGenerated]
		set
		{
			t = value;
		}
	}

	public bool bRead
	{
		[CompilerGenerated]
		get
		{
			return u;
		}
		[CompilerGenerated]
		set
		{
			u = value;
		}
	}

	public bool bLocked
	{
		[CompilerGenerated]
		get
		{
			return v;
		}
		[CompilerGenerated]
		set
		{
			v = value;
		}
	}

	public bool bOpen
	{
		[CompilerGenerated]
		get
		{
			return w;
		}
		[CompilerGenerated]
		set
		{
			w = value;
		}
	}

	public bool bEntered
	{
		[CompilerGenerated]
		get
		{
			return x;
		}
		[CompilerGenerated]
		set
		{
			x = value;
		}
	}

	public bool bVisible
	{
		[CompilerGenerated]
		get
		{
			return y;
		}
		[CompilerGenerated]
		set
		{
			y = value;
		}
	}

	public bool bEnterFirstTime
	{
		[CompilerGenerated]
		get
		{
			return z;
		}
		[CompilerGenerated]
		set
		{
			z = value;
		}
	}

	public bool bLeaveFirstTime
	{
		[CompilerGenerated]
		get
		{
			return aa;
		}
		[CompilerGenerated]
		set
		{
			aa = value;
		}
	}

	public bool bImportant
	{
		[CompilerGenerated]
		get
		{
			return ab;
		}
		[CompilerGenerated]
		set
		{
			ab = value;
		}
	}

	public GameObject()
	{
		locationtype = LocationType.LT_NULL;
		UniqueIdentifier = Guid.NewGuid();
		locationname = "";
		GroupName = string.Empty;
		name = "";
		description = "";
		sdesc = "";
		preposition = "a";
		Actions = new List<Action>();
		LayeredZoneLevels = new List<string>();
		CustomProperties = new List<CustomProperty>();
		bCarryable = false;
		bWearable = false;
		bOpenable = false;
		bLockable = false;
		bEnterable = false;
		bReadable = false;
		bContainer = false;
		dWeight = 0.0;
		bWorn = false;
		bRead = false;
		bLocked = false;
		bOpen = false;
		bEntered = false;
		bVisible = true;
		bEnterFirstTime = false;
		bLeaveFirstTime = false;
		bImportant = false;
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
	}

	public override string ToString()
	{
		string text = string.Empty;
		if (locationtype == LocationType.LT_IN_OBJECT || locationtype == LocationType.LT_CHARACTER)
		{
			text += "  ";
		}
		if (sdesc.Trim().Length <= 0)
		{
			text += name;
		}
		else
		{
			text = ((TheGame == null) ? (text + name) : (text + TheGame.PerformTextReplacements(sdesc, null)));
		}
		if (bOpenable && !bOpen)
		{
			text += " (closed)";
		}
		if (bOpenable && bOpen)
		{
			text += " (open)";
		}
		if (bWorn)
		{
			text += " (worn)";
		}
		return text;
	}

	public string GetDisplayStringNameOnly()
	{
		string text = string.Empty;
		if (preposition.Length > 0)
		{
			text = text + preposition + " ";
		}
		if (sdesc.Trim().Length > 0)
		{
			return text + sdesc;
		}
		return text + name;
	}

	public string GetDisplayString()
	{
		string text = string.Empty;
		if (preposition.Length > 0)
		{
			text = text + preposition + " ";
		}
		text = ((sdesc.Trim().Length <= 0) ? (text + name) : (text + sdesc));
		if (bOpenable && !bOpen)
		{
			text += " (closed)";
		}
		if (bOpenable && bOpen)
		{
			text += " (open)";
		}
		if (bWorn)
		{
			text += " (worn)";
		}
		return text;
	}

	public string GetDisplayName()
	{
		string empty = string.Empty;
		if (sdesc.Trim().Length > 0)
		{
			return empty + sdesc;
		}
		return empty + name;
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

	public string Display(List<GameObject> ObjectList)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(description);
		if (!TheGame.bTurnOffNotifications)
		{
			if (bOpenable)
			{
				if (bOpen)
				{
					stringBuilder.Append(".  It is open.");
				}
				else
				{
					stringBuilder.Append(".  It is closed.");
				}
			}
			if (bContainer && (!bOpenable || bOpen) && locationtype != LocationType.LT_PORTAL)
			{
				int num = 0;
				stringBuilder.Append(".  It contains:");
				for (int i = 0; i < ObjectList.Count; i++)
				{
					GameObject gameObject = ObjectList[i];
					if (gameObject.locationtype == LocationType.LT_IN_OBJECT && gameObject.locationname == UniqueIdentifier.ToString() && gameObject.bVisible)
					{
						stringBuilder.Append("\r\n");
						if (num > 0)
						{
							stringBuilder.Append("and ");
						}
						stringBuilder.Append(gameObject.preposition + " " + gameObject.GetDisplayName());
						num++;
					}
				}
				if (num == 0)
				{
					stringBuilder.Append("\r\n");
					stringBuilder.Append("Nothing");
				}
			}
		}
		stringBuilder.Append("\r\n");
		return stringBuilder.ToString();
	}

	public void UpdateFromSave(GameObject tempobj)
	{
		locationtype = tempobj.locationtype;
		locationname = tempobj.locationname;
		foreach (CustomProperty customProperty in tempobj.CustomProperties)
		{
			foreach (CustomProperty customProperty2 in CustomProperties)
			{
				if (customProperty2.Name == customProperty.Name)
				{
					customProperty2.Value = customProperty.Value;
				}
			}
		}
		foreach (Action action in tempobj.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
		bWorn = tempobj.bWorn;
		bRead = tempobj.bRead;
		bLocked = tempobj.bLocked;
		bOpen = tempobj.bOpen;
		bEntered = tempobj.bEntered;
		bVisible = tempobj.bVisible;
		bEnterFirstTime = tempobj.bEnterFirstTime;
		bLeaveFirstTime = tempobj.bLeaveFirstTime;
		bImportant = tempobj.bImportant;
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + name.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + UniqueIdentifier.ToString() + "\",");
		A_.Append("\"" + locationtype.ToString() + "\",");
		A_.Append("\"" + locationname + "\",");
		A_.Append("\"" + description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + sdesc.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + preposition + "\",");
		A_.Append(bCarryable.ToString().ToLower() + ",");
		A_.Append(bWearable.ToString().ToLower() + ",");
		A_.Append(bOpenable.ToString().ToLower() + ",");
		A_.Append(bLockable.ToString().ToLower() + ",");
		A_.Append(bEnterable.ToString().ToLower() + ",");
		A_.Append(bReadable.ToString().ToLower() + ",");
		A_.Append(bContainer.ToString().ToLower() + ",");
		A_.Append(dWeight + ",");
		A_.Append(bWorn.ToString().ToLower() + ",");
		A_.Append(bRead.ToString().ToLower() + ",");
		A_.Append(bLocked.ToString().ToLower() + ",");
		A_.Append(bOpen.ToString().ToLower() + ",");
		A_.Append(bVisible.ToString().ToLower() + ",");
		string text = string.Empty;
		int num = 0;
		foreach (string layeredZoneLevel in LayeredZoneLevels)
		{
			if (num > 0)
			{
				text += ":";
			}
			text += layeredZoneLevel;
		}
		A_.Append("[\"" + text + "\"],");
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
