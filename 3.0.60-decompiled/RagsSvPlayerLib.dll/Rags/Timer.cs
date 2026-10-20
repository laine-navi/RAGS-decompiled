using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Timer
{
	public enum TimerType
	{
		TT_RUNALWAYS,
		TT_LENGTH
	}

	public DateTime LastFire = DateTime.Now;

	[CompilerGenerated]
	private string m_a;

	[CompilerGenerated]
	private TimerType b;

	[CompilerGenerated]
	private bool c;

	[CompilerGenerated]
	private bool d;

	[CompilerGenerated]
	private List<Action> e;

	[CompilerGenerated]
	private int f;

	[CompilerGenerated]
	private int g;

	[CompilerGenerated]
	private List<CustomProperty> h;

	[CompilerGenerated]
	private bool i;

	[CompilerGenerated]
	private int j;

	public string Name
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

	public TimerType TType
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

	public bool Active
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

	public bool Restart
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

	public List<Action> Actions
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

	public int Length
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

	public int TurnNumber
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

	public List<CustomProperty> CustomProperties
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

	public bool LiveTimer
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

	public int TimerSeconds
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

	public Timer()
	{
		Name = string.Empty;
		TType = TimerType.TT_RUNALWAYS;
		Active = false;
		Restart = false;
		Actions = new List<Action>();
		Length = 0;
		TurnNumber = 0;
		CustomProperties = new List<CustomProperty>();
		LiveTimer = false;
		TimerSeconds = 1;
		a();
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

	private void a()
	{
		Action action = new Action();
		action.name = "<<On Each Turn>>";
		Actions.Add(action);
	}

	public override string ToString()
	{
		return Name;
	}

	public void UpdateFromSave(Timer temptimer)
	{
		Active = temptimer.Active;
		TurnNumber = temptimer.TurnNumber;
		foreach (CustomProperty customProperty in temptimer.CustomProperties)
		{
			foreach (CustomProperty customProperty2 in CustomProperties)
			{
				if (customProperty2.Name == customProperty.Name)
				{
					customProperty2.Value = customProperty.Value;
				}
			}
		}
		foreach (Action action in temptimer.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + Name + "\",");
		A_.Append("\"" + TType.ToString() + "\",");
		A_.Append(Active.ToString().ToLower() + ",");
		A_.Append(Restart.ToString().ToLower() + ",");
		A_.Append(TurnNumber + ",");
		A_.Append(Length + ",");
		A_.Append(LiveTimer.ToString().ToLower() + ",");
		A_.Append(TimerSeconds + ",");
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
