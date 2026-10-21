using System;
using System.Collections;

namespace Rags;

[Serializable]
public sealed class QuickMenuItem
{
	public Guid UniqueID = default;

	public string Name = string.Empty;

	public bool bRooms = true;

	public bool bPlayer = true;

	public bool bObjects = true;

	public bool bCharacters = true;

	public bool bCarryable;

	public bool bWearable;

	public bool bContainer;

	public bool bOpenable;

	public bool bLockable;

	public bool bEnterable;

	public bool bReadable;

	public bool bOverwrite;

	public ArrayList Actions = new ArrayList();

	public QuickMenuItem()
	{
		UniqueID = Guid.NewGuid();
	}

	public override string ToString()
	{
		return Name;
	}

	public Action GetActionByName(string actionname)
	{
		if (Actions == null)
		{
			__ldtoken(QuickMenuItem.GetActionByName(string));
		}
		else
		{
			for (int i = 0; i < Actions.Count; i++)
			{
				__ldtoken(QuickMenuItem.GetActionByName(string));
				if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) != 0)
				{
					__ldtoken(QuickMenuItem.GetActionByName(string));
					continue;
				}
				return (Action)Actions[i];
			}
		}
		return null;
	}
}
