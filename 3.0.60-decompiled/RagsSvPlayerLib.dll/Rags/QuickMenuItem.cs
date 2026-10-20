using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Rags;

public class QuickMenuItem
{
	[CompilerGenerated]
	private Guid a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private bool c;

	[CompilerGenerated]
	private bool d;

	[CompilerGenerated]
	private bool e;

	[CompilerGenerated]
	private bool f;

	[CompilerGenerated]
	private bool g;

	[CompilerGenerated]
	private bool h;

	[CompilerGenerated]
	private bool i;

	[CompilerGenerated]
	private bool j;

	[CompilerGenerated]
	private bool k;

	[CompilerGenerated]
	private bool l;

	[CompilerGenerated]
	private bool m;

	[CompilerGenerated]
	private bool n;

	[CompilerGenerated]
	private List<Action> o;

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

	public string Name
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

	public bool bRooms
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

	public bool bPlayer
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

	public bool bObjects
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

	public bool bCharacters
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

	public bool bCarryable
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

	public bool bWearable
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

	public bool bContainer
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

	public bool bOpenable
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

	public bool bLockable
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

	public bool bEnterable
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

	public bool bReadable
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

	public bool bOverwrite
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

	public List<Action> Actions
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

	public QuickMenuItem()
	{
		Actions = new List<Action>();
		UniqueID = Guid.NewGuid();
	}

	public override string ToString()
	{
		return Name;
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
}
