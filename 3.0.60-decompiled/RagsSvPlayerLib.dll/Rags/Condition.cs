using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Condition
{
	public enum ConditionType
	{
		CT_Uninitialized,
		CT_AdditionalDataCheck,
		CT_Character_CustomPropertyCheck,
		CT_Character_Gender,
		CT_Character_In_Room,
		CT_Character_In_RoomGroup,
		CT_Item_CustomPropertyCheck,
		CT_Item_InGroup,
		CT_Item_Held_By_Character,
		CT_Item_Held_By_Player,
		CT_Item_In_Object,
		CT_Item_In_Room,
		CT_Item_In_RoomGroup,
		CT_Item_Not_Held_By_Player,
		CT_Item_Not_In_Object,
		CT_Item_State_Check,
		CT_Loop_While,
		CT_Loop_Characters,
		CT_Loop_Items,
		CT_Loop_Item_Group,
		CT_Loop_Item_Container,
		CT_Loop_Item_Room,
		CT_Loop_Item_Inventory,
		CT_Loop_Item_Char_Inventory,
		CT_Loop_Rooms,
		CT_Loop_Exits,
		CT_MultiMedia_InGroup,
		CT_Player_CustomPropertyCheck,
		CT_Player_Gender,
		CT_Player_In_Room,
		CT_Player_In_RoomGroup,
		CT_Player_In_Same_Room_As,
		CT_Player_Moving,
		CT_Room_CustomPropertyCheck,
		CT_Timer_CustomPropertyCheck,
		CT_Variable_Comparison,
		CT_Variable_To_Variable_Comparison,
		CT_Variable_CustomPropertyCheck
	}

	[CompilerGenerated]
	private List<object> m_a;

	[CompilerGenerated]
	private List<object> b;

	[CompilerGenerated]
	private List<Check> c;

	[CompilerGenerated]
	private string d;

	public List<object> PassCommands
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

	public List<object> FailCommands
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

	public List<Check> Checks
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

	public string conditionname
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

	public Condition(string cname)
	{
		conditionname = cname;
		PassCommands = new List<object>();
		FailCommands = new List<object>();
		Checks = new List<Check>();
	}

	public Condition()
	{
		conditionname = string.Empty;
		PassCommands = new List<object>();
		FailCommands = new List<object>();
		Checks = new List<Check>();
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

	public bool ContainsValue(string val)
	{
		if (conditionname.Contains(val))
		{
			return true;
		}
		foreach (Check check in Checks)
		{
			if (check.ConditionStep2.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0 || check.ConditionStep3.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0 || check.ConditionStep4.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return true;
			}
		}
		return false;
	}

	internal void a(ref StringBuilder A_0)
	{
		A_0.Append("[");
		A_0.Append("\"COND\",");
		A_0.Append("\"" + conditionname.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		int num = 0;
		A_0.Append("[");
		foreach (Check check in Checks)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			check.a(ref A_0);
			num++;
		}
		A_0.Append("],");
		A_0.Append("[");
		num = 0;
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
		A_0.Append("]");
		A_0.Append("]");
	}
}
