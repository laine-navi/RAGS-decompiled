using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Check
{
	[CompilerGenerated]
	private Condition.ConditionType m_a;

	[CompilerGenerated]
	private CheckType b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private string e;

	public Condition.ConditionType CondType
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

	public CheckType CkType
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

	public string ConditionStep2
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

	public string ConditionStep3
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

	public string ConditionStep4
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

	public Check()
	{
		CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		CkType = CheckType.CT_Uninitialized;
		ConditionStep2 = string.Empty;
		ConditionStep3 = string.Empty;
		ConditionStep4 = string.Empty;
	}

	public static string ValidateCheck(ref Check tempcheck, ref Game TheGame)
	{
		string text = string.Empty;
		Character character = null;
		Room room = null;
		GameObject gameObject = null;
		GameVariable gameVariable = null;
		string text2 = TheGame.PerformTextReplacements(tempcheck.ConditionStep2, null);
		string text3 = TheGame.PerformTextReplacements(tempcheck.ConditionStep3, null);
		switch (tempcheck.CondType)
		{
		case Condition.ConditionType.CT_Item_Held_By_Character:
			character = TheGame.GetCharacterByName(text2);
			if (character == null)
			{
				text += "Condition not set correctly: Item: Held By Character: Invalid Character.\r\n";
			}
			gameObject = TheGame.GetObjectByName(text3);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text3);
				if (gameObject == null)
				{
					text += "Condition not set correctly: Item: Held By Character: Invalid Object.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Item_Held_By_Player:
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Condition not set correctly: Item: Held By Player: Invalid Object.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Item_In_Object:
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Condition not set correctly: Item: In Object: Invalid Object.\r\n";
				}
			}
			gameObject = TheGame.GetObjectByName(text3);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text3);
				if (gameObject == null)
				{
					text += "Condition not set correctly: Item: In Object: Invalid Object.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Item_In_Room:
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Condition not set correctly: Item: In Room: Invalid Object.\r\n";
				}
			}
			if (!(tempcheck.ConditionStep3 != Room.CurrentRoomGuid.ToString()) || !(tempcheck.ConditionStep3 != Room.VoidRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text3);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text3);
				if (room == null)
				{
					text += "Condition not set correctly: Item: In Room: Invalid Room.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Condition not set correctly: Item: Not Held By Player: Invalid Object.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Item_State_Check:
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Condition not set correctly: Item: State Check: Invalid Object.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Player_In_Room:
			if (!(tempcheck.ConditionStep2 != Room.CurrentRoomGuid.ToString()) || !(tempcheck.ConditionStep2 != Room.VoidRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Condition not set correctly: Player: In Room: Invalid Room.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Player_In_Same_Room_As:
			if (tempcheck.ConditionStep2 != Room.CurrentRoomGuid.ToString() && tempcheck.ConditionStep2 != Room.VoidRoomGuid.ToString())
			{
				character = TheGame.GetCharacterByName(tempcheck.ConditionStep2);
				if (character == null)
				{
					text += "Condition not set correctly: Player: In Same Room As: Invalid Character.\r\n";
				}
			}
			break;
		case Condition.ConditionType.CT_Variable_Comparison:
			gameVariable = TheGame.GetVariableByName(TheGame.PerformTextReplacements(tempcheck.ConditionStep2, null));
			if (gameVariable == null)
			{
				text += "Condition not set correctly: Variable: Comparison: Invalid Variable.\r\n";
			}
			break;
		case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
			gameVariable = TheGame.GetVariableByName(TheGame.PerformTextReplacements(tempcheck.ConditionStep2, null));
			if (gameVariable == null)
			{
				text += "Condition not set correctly: Variable: Comparison To Variable: Invalid Variable.\r\n";
			}
			gameVariable = TheGame.GetVariableByName(TheGame.PerformTextReplacements(tempcheck.ConditionStep4, null));
			if (gameVariable == null)
			{
				text += "Condition not set correctly: Variable: Comparison To Variable: Invalid Variable.\r\n";
			}
			break;
		}
		return text;
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
