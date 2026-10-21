using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Rags;

[Serializable]
public class Condition : ISerializable
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

	public ArrayList PassCommands = new ArrayList();

	public ArrayList FailCommands = new ArrayList();

	public ArrayList Checks = new ArrayList();

	public string conditionname = "";

	public Condition(string cname)
	{
		conditionname = cname;
		Checks.Add(new Check());
	}

	public Condition()
	{
		Checks.Add(new Check());
	}

	protected Condition(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			PassCommands = (ArrayList)info.GetValue("PassCommands", PassCommands.GetType());
			FailCommands = (ArrayList)info.GetValue("FailCommands", FailCommands.GetType());
			conditionname = (string)info.GetValue("conditionname", conditionname.GetType());
			try
			{
				Checks = (ArrayList)info.GetValue("Checks", Checks.GetType());
			}
			catch
			{
				Checks = new ArrayList();
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				empty = (string)info.GetValue("ConditionStep2", empty.GetType());
				empty2 = (string)info.GetValue("ConditionStep3", empty2.GetType());
				empty3 = (string)info.GetValue("ConditionStep4", empty3.GetType());
				ConditionType conditionType = ConditionType.CT_Uninitialized;
				try
				{
					conditionType = (ConditionType)info.GetValue("CondType", conditionType.GetType());
				}
				catch
				{
				}
				Check check = new Check();
				if (Game.bUpgrading && conditionType > ConditionType.CT_AdditionalDataCheck)
				{
					conditionType++;
				}
				check.CondType = conditionType;
				check.ConditionStep2 = empty;
				check.ConditionStep3 = empty2;
				check.ConditionStep4 = empty3;
				Checks.Add(check);
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Unhandled exc in condition!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("PassCommands", PassCommands, PassCommands.GetType());
		info.AddValue("FailCommands", FailCommands, FailCommands.GetType());
		info.AddValue("conditionname", conditionname, conditionname.GetType());
		info.AddValue("Checks", Checks, Checks.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<Condition>");
		Game.AddXMLSection(ref CurDoc, "Name", conditionname);
		if (Checks.Count > 0)
		{
			CurDoc.WriteLine("<Checks>");
			foreach (Check check in Checks)
			{
				check.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Checks>");
		}
		if (PassCommands.Count > 0)
		{
			CurDoc.WriteLine("<PassCommands>");
			for (int i = 0; i < PassCommands.Count; i++)
			{
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command != null)
				{
					command.GetXMLData(ref CurDoc);
				}
				else
				{
					condition?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine("</PassCommands>");
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.WriteLine("<FailCommands>");
			for (int j = 0; j < FailCommands.Count; j++)
			{
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetXMLData(ref CurDoc);
				}
				else
				{
					condition2?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine("</FailCommands>");
		}
		CurDoc.WriteLine("</Condition>");
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append("<Condition>");
		Game.AddXMLSection(ref CurDoc, "Name", conditionname);
		if (Checks.Count > 0)
		{
			CurDoc.Append("<Checks>");
			foreach (Check check in Checks)
			{
				check.GetXMLData(ref CurDoc);
			}
			CurDoc.Append("</Checks>");
		}
		if (PassCommands.Count > 0)
		{
			CurDoc.Append("<PassCommands>");
			for (int i = 0; i < PassCommands.Count; i++)
			{
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command != null)
				{
					command.GetXMLData(ref CurDoc);
				}
				else
				{
					condition?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append("</PassCommands>");
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.Append("<FailCommands>");
			for (int j = 0; j < FailCommands.Count; j++)
			{
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetXMLData(ref CurDoc);
				}
				else
				{
					condition2?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append("</FailCommands>");
		}
		CurDoc.Append("</Condition>");
	}

	public void AddAdvSection(ref StringBuilder CurDoc)
	{
		CurDoc.Append("<Condition name=\"" + conditionname + "\">\r\n");
		if (Checks.Count > 0)
		{
			CurDoc.Append("<Checks>\r\n");
			foreach (Check check in Checks)
			{
				check.GetAdvancedText(ref CurDoc);
			}
			CurDoc.Append("</Checks>\r\n");
		}
		if (PassCommands.Count > 0)
		{
			CurDoc.Append("<Pass>\r\n");
			for (int i = 0; i < PassCommands.Count; i++)
			{
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command != null)
				{
					command.GetAdvancedText(ref CurDoc);
				}
				else
				{
					condition?.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append("</Pass>\r\n");
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.Append("<Fail>\r\n");
			for (int j = 0; j < FailCommands.Count; j++)
			{
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetAdvancedText(ref CurDoc);
				}
				else
				{
					condition2?.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append("</Fail>\r\n");
		}
		CurDoc.Append("</Condition>\r\n");
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		AddAdvSection(ref CurDoc);
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		Checks.Clear();
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			conditionname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Checks");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Check check = new Check();
				check.SetXMLData(ref CurNode2);
				Checks.Add(check);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "PassCommands");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Command command = new Command();
				Condition condition = new Condition();
				if (string.Compare(CurNode3.Name, "Condition", ignoreCase: true) == 0)
				{
					condition.SetXMLData(ref CurNode3);
					PassCommands.Add(condition);
				}
				else
				{
					command.SetXMLData(ref CurNode3);
					PassCommands.Add(command);
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "FailCommands");
		if (xMLSection == null)
		{
			return;
		}
		for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
		{
			XmlNode CurNode4 = xMLSection.ChildNodes[k];
			Command command2 = new Command();
			Condition condition2 = new Condition();
			if (string.Compare(CurNode4.Name, "Condition", ignoreCase: true) == 0)
			{
				condition2.SetXMLData(ref CurNode4);
				FailCommands.Add(condition2);
			}
			else
			{
				command2.SetXMLData(ref CurNode4);
				FailCommands.Add(command2);
			}
		}
	}

	public static void PopulateComboWithConditions(ComboBox cb, bool bFilter)
	{
		cb.Items.Clear();
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_AdditionalDataCheck, "Additional Data Check"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_CustomPropertyCheck, "Character: Custom Property Check"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_Gender, "Character: Gender"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_In_Room, "Character: In Room"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_In_RoomGroup, "Character: In Room Group"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_CustomPropertyCheck, "Item: Custom Property Check"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_InGroup, "Item: In Group"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Held_By_Character, "Item: Held By Character"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Held_By_Player, "Item: Held By Player"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_In_Object, "Item: In Object"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_In_Room, "Item: In Room"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_In_RoomGroup, "Item: In Room Group"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Not_Held_By_Player, "Item: Not Held By Player"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Not_In_Object, "Item: Not In Object"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_State_Check, "Item: State Check"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_While, "Loop: While"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Characters, "Loop: Characters"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Items, "Loop: Items"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Group, "Loop: Item Group"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Container, "Loop: Items In Container"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Room, "Loop: Items In Room"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Inventory, "Loop: Items In Player Inventory"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Char_Inventory, "Loop: Items In Character Inventory"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Rooms, "Loop: Rooms"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Exits, "Loop: Exits"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_MultiMedia_InGroup, "Multimedia: In Group"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_CustomPropertyCheck, "Player: Custom Property Check"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_Gender, "Player: Gender"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_In_Room, "Player: In Room"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_In_RoomGroup, "Player: In Room Group"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_In_Same_Room_As, "Player: In Same Room As"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_Moving, "Player: Moving In Direction"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Room_CustomPropertyCheck, "Room: Custom Property Check"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Timer_CustomPropertyCheck, "Timer: Custom Property Check"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Variable_Comparison, "Variable: Comparison"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Variable_To_Variable_Comparison, "Variable: Comparison To Variable"));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Variable_CustomPropertyCheck, "Variable: Custom Property Check"));
		if (!bFilter)
		{
			return;
		}
		List<string> list = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Condition);
		for (int num = cb.Items.Count - 1; num >= 0; num--)
		{
			if (cb.Items[num] is CommandConditionComboItem commandConditionComboItem && list.Contains(commandConditionComboItem.Name))
			{
				cb.Items.Remove((object)commandConditionComboItem);
			}
		}
	}

	public static string GetConditionName(ConditionType ct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		string result = string.Empty;
		ComboBox val = new ComboBox();
		PopulateComboWithConditions(val, bFilter: false);
		foreach (CommandConditionComboItem item in val.Items)
		{
			if (item.cndindex == ct)
			{
				result = item.Name;
				break;
			}
		}
		return result;
	}

	public static CommandConditionComboItem GetConditionItem(ComboBox tempcb, ConditionType ct)
	{
		CommandConditionComboItem commandConditionComboItem = null;
		foreach (CommandConditionComboItem item in tempcb.Items)
		{
			if (item.cndindex == ct)
			{
				commandConditionComboItem = item;
				break;
			}
		}
		if (commandConditionComboItem == null)
		{
			CommandConditionComboItem commandConditionComboItem3 = new CommandConditionComboItem(ct, GetConditionName(ct));
			tempcb.Items.Add((object)commandConditionComboItem3);
			commandConditionComboItem = commandConditionComboItem3;
		}
		return commandConditionComboItem;
	}

	public Command GetPassCommandByName(string cmdname)
	{
		for (int i = 0; i < PassCommands.Count; i++)
		{
			if (string.Compare(cmdname, ((Command)PassCommands[i]).CommandName, ignoreCase: true) == 0)
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
			if (string.Compare(cmdname, ((Command)FailCommands[i]).CommandName, ignoreCase: true) == 0)
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
