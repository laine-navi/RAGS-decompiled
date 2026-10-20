using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using A;

namespace Rags;

[Serializable]
public sealed class Check : ISerializable
{
	public Condition.ConditionType CondType = Condition.ConditionType.CT_Item_Held_By_Player;

	public CheckType CkType;

	public string ConditionStep2 = "";

	public string ConditionStep3 = "";

	public string ConditionStep4 = "";

	public Check()
	{
	}

	protected Check(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(Check._002Ector(SerializationInfo, StreamingContext));
			try
			{
				try
				{
					CondType = (Condition.ConditionType)Enum.Parse(typeof(Condition.ConditionType), (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125), ConditionStep2.GetType()), ignoreCase: true);
				}
				catch
				{
					try
					{
						CondType = (Condition.ConditionType)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125), CondType.GetType());
					}
					catch
					{
						CondType = Condition.ConditionType.CT_Uninitialized;
					}
				}
				CkType = (CheckType)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114142), CkType.GetType());
				ConditionStep2 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114155), ConditionStep2.GetType());
				ConditionStep3 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114184), ConditionStep3.GetType());
				if (ConditionStep3.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114347)) <= -1)
				{
					__ldtoken(Check._002Ector(SerializationInfo, StreamingContext));
				}
				else
				{
					ConditionStep3 = ConditionStep3.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114347), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114356));
				}
				ConditionStep4 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114213), ConditionStep4.GetType());
				return;
			}
			catch (Exception ex)
			{
				throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114365), ex.InnerException);
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public static string ValidateCheck(ref Check tempcheck, ref Game TheGame)
	{
		string text = string.Empty;
		Character character = null;
		Room room = null;
		GameObject gameObject = null;
		GameVariable gameVariable = null;
		string roomname = TheGame.PerformTextReplacements(tempcheck.ConditionStep2, null);
		string roomname2 = TheGame.PerformTextReplacements(tempcheck.ConditionStep3, null);
		switch (tempcheck.CondType)
		{
		case Condition.ConditionType.CT_Item_Held_By_Character:
			character = TheGame.GetCharacterByName(roomname);
			if (character != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112465);
			}
			gameObject = TheGame.GetObjectByName(roomname2);
			if (gameObject != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			gameObject = TheGame.GetObjectByNameOld(roomname2);
			if (gameObject == null)
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112615);
			}
			break;
		case Condition.ConditionType.CT_Item_Held_By_Player:
			gameObject = TheGame.GetObjectByName(roomname);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(roomname);
				if (gameObject != null)
				{
					__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112759);
				}
			}
			break;
		case Condition.ConditionType.CT_Item_In_Object:
			gameObject = TheGame.GetObjectByName(roomname);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(roomname);
				if (gameObject == null)
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112897);
				}
			}
			gameObject = TheGame.GetObjectByName(roomname2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(roomname2);
				if (gameObject == null)
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112897);
				}
			}
			break;
		case Condition.ConditionType.CT_Item_In_Room:
			gameObject = TheGame.GetObjectByName(roomname);
			if (gameObject != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				gameObject = TheGame.GetObjectByNameOld(roomname);
				if (gameObject != null)
				{
					__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113024);
				}
			}
			if (!(tempcheck.ConditionStep3 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			if (!(tempcheck.ConditionStep3 != Room.VoidRoomGuid.ToString()))
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			room = TheGame.GetRoomForValidation(roomname2);
			if (room != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			room = TheGame.GetRoomByName(ref roomname2);
			if (room != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113147);
			}
			break;
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
			gameObject = TheGame.GetObjectByName(roomname);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(roomname);
				if (gameObject != null)
				{
					__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113266);
				}
			}
			break;
		case Condition.ConditionType.CT_Item_State_Check:
			gameObject = TheGame.GetObjectByName(roomname);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(roomname);
				if (gameObject != null)
				{
					__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113412);
				}
			}
			break;
		case Condition.ConditionType.CT_Player_In_Room:
			if (!(tempcheck.ConditionStep2 != Room.CurrentRoomGuid.ToString()))
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			if (!(tempcheck.ConditionStep2 != Room.VoidRoomGuid.ToString()))
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			room = TheGame.GetRoomForValidation(roomname);
			if (room != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			room = TheGame.GetRoomByName(ref roomname);
			if (room != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113544);
			}
			break;
		case Condition.ConditionType.CT_Player_In_Same_Room_As:
			if (!(tempcheck.ConditionStep2 != Room.CurrentRoomGuid.ToString()))
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			if (!(tempcheck.ConditionStep2 != Room.VoidRoomGuid.ToString()))
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
				break;
			}
			character = TheGame.GetCharacterByName(tempcheck.ConditionStep2);
			if (character != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113667);
			}
			break;
		case Condition.ConditionType.CT_Variable_Comparison:
			gameVariable = TheGame.GetVariableByName(TheGame.PerformTextReplacements(tempcheck.ConditionStep2, null));
			if (gameVariable != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113817);
			}
			break;
		case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
			gameVariable = TheGame.GetVariableByName(TheGame.PerformTextReplacements(tempcheck.ConditionStep2, null));
			if (gameVariable != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113959);
			}
			gameVariable = TheGame.GetVariableByName(TheGame.PerformTextReplacements(tempcheck.ConditionStep4, null));
			if (gameVariable != null)
			{
				__ldtoken(Check.ValidateCheck(ref Check, ref Game));
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(113959);
			}
			break;
		}
		return text;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125), CondType.ToString(), ConditionStep2.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114142), CkType, CkType.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114155), ConditionStep2, ConditionStep2.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114184), ConditionStep3, ConditionStep3.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114213), ConditionStep4, ConditionStep4.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114242));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125), CondType.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114142), CkType.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114257), ConditionStep2);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114268), ConditionStep3);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114279), ConditionStep4);
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114290));
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114242));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125), CondType.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114142), CkType.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114257), ConditionStep2);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114268), ConditionStep3);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114279), ConditionStep4);
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114290));
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114307));
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125), CondType.ToString());
		if (CkType == CheckType.CT_Uninitialized)
		{
			__ldtoken(Check.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114142), CkType.ToString());
		}
		if (!(ConditionStep2 != string.Empty))
		{
			__ldtoken(Check.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114257), ConditionStep2);
		}
		if (ConditionStep3 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114268), ConditionStep3);
		}
		if (!(ConditionStep4 != string.Empty))
		{
			__ldtoken(Check.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114279), ConditionStep4);
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114326));
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114125));
		if (xMLSection == null)
		{
			__ldtoken(Check.SetXMLData(ref XmlNode));
		}
		else
		{
			CondType = (Condition.ConditionType)Enum.Parse(typeof(Condition.ConditionType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114142));
		if (xMLSection == null)
		{
			__ldtoken(Check.SetXMLData(ref XmlNode));
		}
		else
		{
			CkType = (CheckType)Enum.Parse(typeof(CheckType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114257));
		if (xMLSection != null)
		{
			ConditionStep2 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114268));
		if (xMLSection == null)
		{
			__ldtoken(Check.SetXMLData(ref XmlNode));
		}
		else
		{
			ConditionStep3 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114279));
		if (xMLSection != null)
		{
			ConditionStep4 = xMLSection.InnerText;
		}
	}

	internal void cc738ece0e9315f0db703b90a443636ff(ref StringBuilder P_0)
	{
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CondType.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CkType.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + ConditionStep2.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + ConditionStep3.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + ConditionStep4.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
	}
}
