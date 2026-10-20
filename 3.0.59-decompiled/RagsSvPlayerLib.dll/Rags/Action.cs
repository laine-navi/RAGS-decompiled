using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Action
{
	public enum ActionInputType
	{
		None,
		Object,
		Character,
		ObjectOrCharacter,
		Text,
		Custom,
		Inventory
	}

	public GameObject actdata;

	[CompilerGenerated]
	private string m_a;

	[CompilerGenerated]
	private bool b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private bool e;

	[CompilerGenerated]
	private ActionInputType f;

	[CompilerGenerated]
	private List<object> g;

	[CompilerGenerated]
	private List<object> h;

	[CompilerGenerated]
	private List<Condition> i;

	[CompilerGenerated]
	private List<string> j;

	[CompilerGenerated]
	private EnhancedInputData k;

	[CompilerGenerated]
	private string l;

	public string name
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

	public string overridename
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

	public string actionparent
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

	public bool bConditionFailOnFirst
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

	public ActionInputType InputType
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

	public List<object> PassCommands
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

	public List<object> FailCommands
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

	public List<Condition> Conditions
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

	public List<string> CustomChoices
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

	public EnhancedInputData EnhInputData
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

	public string CustomChoiceTitle
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

	public Action()
	{
		name = "default";
		bActive = true;
		overridename = string.Empty;
		actionparent = "None";
		bConditionFailOnFirst = true;
		InputType = ActionInputType.None;
		PassCommands = new List<object>();
		FailCommands = new List<object>();
		Conditions = new List<Condition>();
		CustomChoices = new List<string>();
		EnhInputData = new EnhancedInputData();
		CustomChoiceTitle = string.Empty;
	}

	public void CallAction(object obj)
	{
		ActionInputType inputType = InputType;
		if (inputType != ActionInputType.Object)
		{
			_ = 4;
		}
	}

	public Command GetPassCommandByName(string cmdname)
	{
		for (int i = 0; i < PassCommands.Count; i++)
		{
			if (string.Compare(cmdname, ((Command)PassCommands[i]).CommandName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return (Command)PassCommands[i];
			}
		}
		return null;
	}

	public Command GetFailCommandByName(string cmdname)
	{
		for (int i = 0; i < FailCommands.Count; i++)
		{
			if (string.Compare(cmdname, ((Command)FailCommands[i]).CommandName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return (Command)FailCommands[i];
			}
		}
		return null;
	}

	public Condition GetConditionByName(string condname)
	{
		for (int i = 0; i < Conditions.Count; i++)
		{
			if (string.Compare(condname, Conditions[i].conditionname, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return Conditions[i];
			}
		}
		return null;
	}

	public override string ToString()
	{
		return name;
	}

	internal void a(Action A_0)
	{
		bActive = A_0.bActive;
	}

	internal void a(ref StringBuilder A_0)
	{
		A_0.Append("[");
		A_0.Append("\"" + name.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_0.Append(bActive.ToString().ToLower() + ",");
		A_0.Append("\"" + overridename.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_0.Append("\"" + actionparent + "\",");
		A_0.Append(bConditionFailOnFirst.ToString().ToLower() + ",");
		A_0.Append(string.Concat("\"", InputType, "\","));
		A_0.Append("\"" + CustomChoiceTitle + "\",");
		A_0.Append("[");
		int num = 0;
		foreach (object passCommand in PassCommands)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			num++;
			Command command = passCommand as Command;
			Condition condition = passCommand as Condition;
			if (command != null)
			{
				command.GetJSText(ref A_0);
			}
			else
			{
				condition?.a(ref A_0);
			}
		}
		A_0.Append("],");
		A_0.Append("[");
		num = 0;
		foreach (object failCommand in FailCommands)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			num++;
			Command command2 = failCommand as Command;
			Condition condition2 = failCommand as Condition;
			if (command2 != null)
			{
				command2.GetJSText(ref A_0);
			}
			else
			{
				condition2?.a(ref A_0);
			}
		}
		A_0.Append("],");
		A_0.Append("[");
		num = 0;
		foreach (Condition condition3 in Conditions)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			num++;
			condition3.a(ref A_0);
		}
		A_0.Append("],");
		num = 0;
		A_0.Append("[");
		foreach (string customChoice in CustomChoices)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			A_0.Append("\"" + customChoice.Replace("'", "\\'").Replace("\"", "\\\"") + "\"");
			num++;
		}
		A_0.Append("],");
		EnhInputData.a(ref A_0);
		A_0.Append("]");
	}
}
