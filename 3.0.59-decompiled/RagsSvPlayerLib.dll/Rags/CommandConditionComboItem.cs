using System.Runtime.CompilerServices;

namespace Rags;

public class CommandConditionComboItem
{
	[CompilerGenerated]
	private Command.CommandType a;

	[CompilerGenerated]
	private Condition.ConditionType b;

	[CompilerGenerated]
	private string c;

	public Command.CommandType ctindex
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

	public Condition.ConditionType cndindex
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

	public CommandConditionComboItem()
	{
		Name = string.Empty;
	}

	public CommandConditionComboItem(Command.CommandType idx, string name)
	{
		ctindex = idx;
		Name = name;
	}

	public CommandConditionComboItem(Condition.ConditionType idx, string name)
	{
		cndindex = idx;
		Name = name;
	}

	public override string ToString()
	{
		return Name;
	}
}
