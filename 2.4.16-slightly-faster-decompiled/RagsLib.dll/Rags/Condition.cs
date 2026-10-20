using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using A;

namespace Rags;

[Serializable]
public sealed class Condition : ISerializable
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
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		try
		{
			PassCommands = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114412), PassCommands.GetType());
			FailCommands = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114437), FailCommands.GetType());
			conditionname = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114462), conditionname.GetType());
			try
			{
				Checks = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114489), Checks.GetType());
			}
			catch
			{
				Checks = new ArrayList();
				string empty = string.Empty;
				string empty2 = string.Empty;
				string empty3 = string.Empty;
				empty = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114155), empty.GetType());
				empty2 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114184), empty2.GetType());
				empty3 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114213), empty3.GetType());
				ConditionType conditionType = ConditionType.CT_Uninitialized;
				try
				{
					conditionType = (ConditionType)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125), conditionType.GetType());
				}
				catch
				{
				}
				Check check = new Check();
				if (Game.bUpgrading)
				{
					if (conditionType <= ConditionType.CT_AdditionalDataCheck)
					{
						__ldtoken(Condition._002Ector(SerializationInfo, StreamingContext));
					}
					else
					{
						conditionType++;
					}
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
			throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116514), ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(Condition.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114412), PassCommands, PassCommands.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114437), FailCommands, FailCommands.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114462), conditionname, conditionname.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114489), Checks, Checks.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114502));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), conditionname);
		if (Checks.Count <= 0)
		{
			__ldtoken(Condition.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114525));
			IEnumerator enumerator = Checks.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(Condition.GetXMLData(ref StreamWriter));
					Check check = (Check)enumerator.Current;
					check.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Condition.GetXMLData(ref StreamWriter));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114542));
		}
		if (PassCommands.Count <= 0)
		{
			__ldtoken(Condition.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114561));
			for (int i = 0; i < PassCommands.Count; i++)
			{
				__ldtoken(Condition.GetXMLData(ref StreamWriter));
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command == null)
				{
					__ldtoken(Condition.GetXMLData(ref StreamWriter));
					condition?.GetXMLData(ref CurDoc);
				}
				else
				{
					command.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114590));
		}
		if (FailCommands.Count <= 0)
		{
			__ldtoken(Condition.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114621));
			for (int j = 0; j < FailCommands.Count; j++)
			{
				__ldtoken(Condition.GetXMLData(ref StreamWriter));
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 == null)
				{
					__ldtoken(Condition.GetXMLData(ref StreamWriter));
					condition2?.GetXMLData(ref CurDoc);
				}
				else
				{
					command2.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114650));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114681));
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114502));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), conditionname);
		if (Checks.Count <= 0)
		{
			__ldtoken(Condition.GetXMLData(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114525));
			IEnumerator enumerator = Checks.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(Condition.GetXMLData(ref StringBuilder));
					Check check = (Check)enumerator.Current;
					check.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Condition.GetXMLData(ref StringBuilder));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114542));
		}
		if (PassCommands.Count <= 0)
		{
			__ldtoken(Condition.GetXMLData(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114561));
			for (int i = 0; i < PassCommands.Count; i++)
			{
				__ldtoken(Condition.GetXMLData(ref StringBuilder));
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command == null)
				{
					__ldtoken(Condition.GetXMLData(ref StringBuilder));
					if (condition == null)
					{
						__ldtoken(Condition.GetXMLData(ref StringBuilder));
					}
					else
					{
						condition.GetXMLData(ref CurDoc);
					}
				}
				else
				{
					command.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114590));
		}
		if (FailCommands.Count <= 0)
		{
			__ldtoken(Condition.GetXMLData(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114621));
			for (int j = 0; j < FailCommands.Count; j++)
			{
				__ldtoken(Condition.GetXMLData(ref StringBuilder));
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 == null)
				{
					__ldtoken(Condition.GetXMLData(ref StringBuilder));
					if (condition2 == null)
					{
						__ldtoken(Condition.GetXMLData(ref StringBuilder));
					}
					else
					{
						condition2.GetXMLData(ref CurDoc);
					}
				}
				else
				{
					command2.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114650));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114681));
	}

	public void AddAdvSection(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114706) + conditionname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114741));
		if (Checks.Count <= 0)
		{
			__ldtoken(Condition.AddAdvSection(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114750));
			foreach (Check check in Checks)
			{
				check.GetAdvancedText(ref CurDoc);
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114771));
		}
		if (PassCommands.Count <= 0)
		{
			__ldtoken(Condition.AddAdvSection(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114794));
			for (int i = 0; i < PassCommands.Count; i++)
			{
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command == null)
				{
					__ldtoken(Condition.AddAdvSection(ref StringBuilder));
					if (condition == null)
					{
						__ldtoken(Condition.AddAdvSection(ref StringBuilder));
					}
					else
					{
						condition.GetAdvancedText(ref CurDoc);
					}
				}
				else
				{
					command.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114811));
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114830));
			for (int j = 0; j < FailCommands.Count; j++)
			{
				__ldtoken(Condition.AddAdvSection(ref StringBuilder));
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 == null)
				{
					__ldtoken(Condition.AddAdvSection(ref StringBuilder));
					condition2?.GetAdvancedText(ref CurDoc);
				}
				else
				{
					command2.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114847));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114866));
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		AddAdvSection(ref CurDoc);
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		Checks.Clear();
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
		if (xMLSection == null)
		{
			__ldtoken(Condition.SetXMLData(ref XmlNode));
		}
		else
		{
			conditionname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114489));
		if (xMLSection == null)
		{
			__ldtoken(Condition.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				__ldtoken(Condition.SetXMLData(ref XmlNode));
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Check check = new Check();
				check.SetXMLData(ref CurNode2);
				Checks.Add(check);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114412));
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				__ldtoken(Condition.SetXMLData(ref XmlNode));
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Command command = new Command();
				Condition condition = new Condition();
				if (string.Compare(CurNode3.Name, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114895), ignoreCase: true) != 0)
				{
					__ldtoken(Condition.SetXMLData(ref XmlNode));
					command.SetXMLData(ref CurNode3);
					PassCommands.Add(command);
				}
				else
				{
					condition.SetXMLData(ref CurNode3);
					PassCommands.Add(condition);
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114437));
		if (xMLSection == null)
		{
			__ldtoken(Condition.SetXMLData(ref XmlNode));
			return;
		}
		for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
		{
			XmlNode CurNode4 = xMLSection.ChildNodes[k];
			Command command2 = new Command();
			Condition condition2 = new Condition();
			if (string.Compare(CurNode4.Name, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114895), ignoreCase: true) != 0)
			{
				__ldtoken(Condition.SetXMLData(ref XmlNode));
				command2.SetXMLData(ref CurNode4);
				FailCommands.Add(command2);
			}
			else
			{
				condition2.SetXMLData(ref CurNode4);
				FailCommands.Add(condition2);
			}
		}
	}

	public static void PopulateComboWithConditions(ComboBox cb, bool bFilter)
	{
		cb.Items.Clear();
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_AdditionalDataCheck, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114914)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_CustomPropertyCheck, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114957)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_Gender, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115022)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_In_Room, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115057)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Character_In_RoomGroup, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115094)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_CustomPropertyCheck, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115143)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_InGroup, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115198)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Held_By_Character, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115227)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Held_By_Player, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115274)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_In_Object, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115315)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_In_Room, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115346)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_In_RoomGroup, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115373)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Not_Held_By_Player, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115412)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_Not_In_Object, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115461)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Item_State_Check, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115500)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_While, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115535)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Characters, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115558)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Items, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115591)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Group, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115614)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Container, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115647)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Room, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115696)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Inventory, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115735)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Item_Char_Inventory, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115798)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Rooms, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115867)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Loop_Exits, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115890)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_MultiMedia_InGroup, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115913)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_CustomPropertyCheck, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(115954)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_Gender, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116013)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_In_Room, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116042)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_In_RoomGroup, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116073)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_In_Same_Room_As, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116116)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Player_Moving, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116163)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Room_CustomPropertyCheck, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116218)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Timer_CustomPropertyCheck, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116273)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Variable_Comparison, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116330)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Variable_To_Variable_Comparison, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116371)));
		cb.Items.Add((object)new CommandConditionComboItem(ConditionType.CT_Variable_CustomPropertyCheck, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116436)));
		if (!bFilter)
		{
			__ldtoken(Condition.PopulateComboWithConditions(ComboBox, bool));
			return;
		}
		List<string> list = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Condition);
		for (int num = cb.Items.Count - 1; num >= 0; num--)
		{
			__ldtoken(Condition.PopulateComboWithConditions(ComboBox, bool));
			if (cb.Items[num] is CommandConditionComboItem commandConditionComboItem && list.Contains(commandConditionComboItem.Name))
			{
				cb.Items.Remove((object)commandConditionComboItem);
			}
		}
	}

	public static string GetConditionName(ConditionType ct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		string result = string.Empty;
		ComboBox val = new ComboBox();
		PopulateComboWithConditions(val, bFilter: false);
		IEnumerator enumerator = val.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Condition.GetConditionName(ConditionType));
				CommandConditionComboItem commandConditionComboItem = (CommandConditionComboItem)enumerator.Current;
				if (commandConditionComboItem.cndindex != ct)
				{
					__ldtoken(Condition.GetConditionName(ConditionType));
					continue;
				}
				result = commandConditionComboItem.Name;
				break;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Condition.GetConditionName(ConditionType));
			}
			else
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	public static CommandConditionComboItem GetConditionItem(ComboBox tempcb, ConditionType ct)
	{
		CommandConditionComboItem commandConditionComboItem = null;
		IEnumerator enumerator = tempcb.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Condition.GetConditionItem(ComboBox, ConditionType));
				CommandConditionComboItem commandConditionComboItem2 = (CommandConditionComboItem)enumerator.Current;
				if (commandConditionComboItem2.cndindex == ct)
				{
					commandConditionComboItem = commandConditionComboItem2;
					break;
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Condition.GetConditionItem(ComboBox, ConditionType));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (commandConditionComboItem != null)
		{
			__ldtoken(Condition.GetConditionItem(ComboBox, ConditionType));
		}
		else
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
			if (string.Compare(cmdname, ((Command)PassCommands[i]).CommandName, ignoreCase: true) != 0)
			{
				__ldtoken(Condition.GetPassCommandByName(string));
				continue;
			}
			return (Command)PassCommands[i];
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
		if (!conditionname.Contains(val))
		{
			__ldtoken(Condition.ContainsValue(string));
			IEnumerator enumerator = Checks.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Check check = (Check)enumerator.Current;
					if (check.ConditionStep2.IndexOf(val, StringComparison.OrdinalIgnoreCase) < 0)
					{
						if (check.ConditionStep3.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0)
						{
							__ldtoken(Condition.ContainsValue(string));
						}
						else if (check.ConditionStep4.IndexOf(val, StringComparison.OrdinalIgnoreCase) < 0)
						{
							__ldtoken(Condition.ContainsValue(string));
							continue;
						}
					}
					return true;
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Condition.ContainsValue(string));
				}
				else
				{
					disposable.Dispose();
				}
			}
			return false;
		}
		return true;
	}

	internal void cc738ece0e9315f0db703b90a443636ff(ref StringBuilder P_0)
	{
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116499));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + conditionname.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		int num = 0;
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		IEnumerator enumerator = Checks.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				Check check = (Check)enumerator.Current;
				if (num > 0)
				{
					P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				check.cc738ece0e9315f0db703b90a443636ff(ref P_0);
				num++;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
			}
			else
			{
				disposable.Dispose();
			}
		}
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		IEnumerator enumerator2 = PassCommands.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				object current = enumerator2.Current;
				if (num <= 0)
				{
					__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				}
				else
				{
					P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				Command command = current as Command;
				Condition condition = current as Condition;
				if (command == null)
				{
					__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
					if (condition == null)
					{
						__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
					}
					else
					{
						condition.cc738ece0e9315f0db703b90a443636ff(ref P_0);
					}
				}
				else
				{
					command.GetJSText(ref P_0);
				}
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		foreach (object failCommand in FailCommands)
		{
			if (num > 0)
			{
				P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
			}
			num++;
			Command command2 = failCommand as Command;
			Condition condition2 = failCommand as Condition;
			if (command2 == null)
			{
				__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				if (condition2 == null)
				{
					__ldtoken(Condition.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				}
				else
				{
					condition2.cc738ece0e9315f0db703b90a443636ff(ref P_0);
				}
			}
			else
			{
				command2.GetJSText(ref P_0);
			}
		}
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
	}
}
