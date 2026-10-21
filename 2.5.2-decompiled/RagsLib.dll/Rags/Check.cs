using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class Check : ISerializable
{
	public Condition.ConditionType CondType = Condition.ConditionType.CT_Item_Held_By_Player;

	public CheckType CkType;

	public string ConditionStep2 = "";

	public string ConditionStep3 = "";

	public string ConditionStep4 = "";

	public Check()
	{
	}

	public static string ValidateCheck(ref Check tempcheck, ref Game TheGame)
	{
		string text = string.Empty;
		string roomname = TheGame.PerformTextReplacements(tempcheck.ConditionStep2, null);
		string roomname2 = TheGame.PerformTextReplacements(tempcheck.ConditionStep3, null);
		switch (tempcheck.CondType)
		{
		case Condition.ConditionType.CT_Item_Held_By_Character:
			if (TheGame.GetCharacterByName(roomname) == null)
			{
				text += "Condition not set correctly: Item: Held By Character: Invalid Character.\r\n";
			}
			if (TheGame.GetObjectByName(roomname2) == null && TheGame.GetObjectByNameOld(roomname2) == null)
			{
				text += "Condition not set correctly: Item: Held By Character: Invalid Object.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Item_Held_By_Player:
			if (TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Condition not set correctly: Item: Held By Player: Invalid Object.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Item_In_Object:
			if (TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Condition not set correctly: Item: In Object: Invalid Object.\r\n";
			}
			if (TheGame.GetObjectByName(roomname2) == null && TheGame.GetObjectByNameOld(roomname2) == null)
			{
				text += "Condition not set correctly: Item: In Object: Invalid Object.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Item_In_Room:
			if (TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Condition not set correctly: Item: In Room: Invalid Object.\r\n";
			}
			if (tempcheck.ConditionStep3 != Room.CurrentRoomGuid.ToString() && tempcheck.ConditionStep3 != Room.VoidRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname2) == null && TheGame.GetRoomByName(ref roomname2) == null)
			{
				text += "Condition not set correctly: Item: In Room: Invalid Room.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
			if (TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Condition not set correctly: Item: Not Held By Player: Invalid Object.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Item_State_Check:
			if (TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Condition not set correctly: Item: State Check: Invalid Object.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Player_In_Room:
			if (tempcheck.ConditionStep2 != Room.CurrentRoomGuid.ToString() && tempcheck.ConditionStep2 != Room.VoidRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Condition not set correctly: Player: In Room: Invalid Room.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Player_In_Same_Room_As:
			if (tempcheck.ConditionStep2 != Room.CurrentRoomGuid.ToString() && tempcheck.ConditionStep2 != Room.VoidRoomGuid.ToString() && TheGame.GetCharacterByName(tempcheck.ConditionStep2) == null)
			{
				text += "Condition not set correctly: Player: In Same Room As: Invalid Character.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Variable_Comparison:
		{
			Game obj3 = TheGame;
			if (obj3.GetVariableByName(obj3.PerformTextReplacements(tempcheck.ConditionStep2, null)) == null)
			{
				text += "Condition not set correctly: Variable: Comparison: Invalid Variable.\r\n";
			}
			break;
		}
		case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
		{
			Game obj = TheGame;
			if (obj.GetVariableByName(obj.PerformTextReplacements(tempcheck.ConditionStep2, null)) == null)
			{
				text += "Condition not set correctly: Variable: Comparison To Variable: Invalid Variable.\r\n";
			}
			Game obj2 = TheGame;
			if (obj2.GetVariableByName(obj2.PerformTextReplacements(tempcheck.ConditionStep4, null)) == null)
			{
				text += "Condition not set correctly: Variable: Comparison To Variable: Invalid Variable.\r\n";
			}
			break;
		}
		}
		return text;
	}

	protected Check(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			try
			{
				CondType = (Condition.ConditionType)Enum.Parse(typeof(Condition.ConditionType), (string)info.GetValue("CondType", ConditionStep2.GetType()), ignoreCase: true);
			}
			catch
			{
				try
				{
					CondType = (Condition.ConditionType)info.GetValue("CondType", CondType.GetType());
				}
				catch
				{
					CondType = Condition.ConditionType.CT_Uninitialized;
				}
			}
			CkType = (CheckType)info.GetValue("CkType", CkType.GetType());
			ConditionStep2 = (string)info.GetValue("ConditionStep2", ConditionStep2.GetType());
			ConditionStep3 = (string)info.GetValue("ConditionStep3", ConditionStep3.GetType());
			if (ConditionStep3.IndexOf("Then") > -1)
			{
				ConditionStep3 = ConditionStep3.Replace("Then", "Than");
			}
			ConditionStep4 = (string)info.GetValue("ConditionStep4", ConditionStep4.GetType());
		}
		catch (Exception ex)
		{
			throw new Exception("Unhandled exc in check!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("CondType", CondType.ToString(), ConditionStep2.GetType());
		info.AddValue("CkType", CkType, CkType.GetType());
		info.AddValue("ConditionStep2", ConditionStep2, ConditionStep2.GetType());
		info.AddValue("ConditionStep3", ConditionStep3, ConditionStep3.GetType());
		info.AddValue("ConditionStep4", ConditionStep4, ConditionStep4.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<Check>");
		Game.AddXMLSection(ref CurDoc, "CondType", CondType.ToString());
		Game.AddXMLSection(ref CurDoc, "CkType", CkType.ToString());
		Game.AddXMLSection(ref CurDoc, "Step2", ConditionStep2);
		Game.AddXMLSection(ref CurDoc, "Step3", ConditionStep3);
		Game.AddXMLSection(ref CurDoc, "Step4", ConditionStep4);
		CurDoc.WriteLine("</Check>");
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append("<Check>");
		Game.AddXMLSection(ref CurDoc, "CondType", CondType.ToString());
		Game.AddXMLSection(ref CurDoc, "CkType", CkType.ToString());
		Game.AddXMLSection(ref CurDoc, "Step2", ConditionStep2);
		Game.AddXMLSection(ref CurDoc, "Step3", ConditionStep3);
		Game.AddXMLSection(ref CurDoc, "Step4", ConditionStep4);
		CurDoc.Append("</Check>");
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		CurDoc.Append("<Check>\r\n");
		Game.AddAdvSection(ref CurDoc, "CondType", CondType.ToString());
		if (CkType != CheckType.CT_Uninitialized)
		{
			Game.AddAdvSection(ref CurDoc, "CkType", CkType.ToString());
		}
		if (ConditionStep2 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Step2", ConditionStep2);
		}
		if (ConditionStep3 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Step3", ConditionStep3);
		}
		if (ConditionStep4 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Step4", ConditionStep4);
		}
		CurDoc.Append("</Check>\r\n");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "CondType");
		if (xMLSection != null)
		{
			CondType = (Condition.ConditionType)Enum.Parse(typeof(Condition.ConditionType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CkType");
		if (xMLSection != null)
		{
			CkType = (CheckType)Enum.Parse(typeof(CheckType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Step2");
		if (xMLSection != null)
		{
			ConditionStep2 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Step3");
		if (xMLSection != null)
		{
			ConditionStep3 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Step4");
		if (xMLSection != null)
		{
			ConditionStep4 = xMLSection.InnerText;
		}
	}

	internal void a(ref StringBuilder A_0)
	{
		A_0.Append("[");
		A_0.Append("\"" + CondType.ToString() + "\",");
		A_0.Append("\"" + CkType.ToString() + "\",");
		A_0.Append("\"" + ConditionStep2.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_0.Append("\"" + ConditionStep3.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_0.Append("\"" + ConditionStep4.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\"");
		A_0.Append("]");
	}
}
