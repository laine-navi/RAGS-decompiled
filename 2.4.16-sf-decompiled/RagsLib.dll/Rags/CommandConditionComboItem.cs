namespace Rags;

public sealed class CommandConditionComboItem
{
	public Command.CommandType ctindex;

	public Condition.ConditionType cndindex;

	public string Name = string.Empty;

	public CommandConditionComboItem()
	{
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
