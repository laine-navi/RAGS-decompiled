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
public class Command : ISerializable
{
	public enum CommandType
	{
		CT_UNINITIALIZED,
		CT_ACTION_ADD_CUSTOMCHOICE,
		CT_ACTION_CLEAR_CUSTOMCHOICE,
		CT_ACTION_REMOVE_CUSTOMCHOICE,
		CT_DISPLAYCHARDESC,
		CT_CHAR_DISPLAYPORT,
		CT_MOVECHAR,
		CT_MOVECHARINVTOPLAYER,
		CT_CHAR_MOVETOOBJ,
		CT_CHAR_SETPORT,
		CT_SETCHARACTION,
		CT_CHAR_SET_CUSTOM_PROPERTY,
		CT_CHAR_SET_CUSTOM_PROPERTY_JS,
		CT_SETCHARDESC,
		CT_CHAR_SET_GENDER,
		CT_CHAR_SET_NAME,
		CT_COMMENT,
		CT_DEBUGTEXT,
		CT_JAVA_SET_RAGS,
		CT_DISPLAYTEXT,
		CT_EXPORTVARIABLE,
		CT_IMPORTVARIABLE,
		CT_PAUSEGAME,
		CT_DISPLAYLAYEREDPICTURE,
		CT_DISPLAYPICTURE,
		CT_MM_SET_BACKGROUND_MUSIC,
		CT_MM_STOP_BACKGROUND_MUSIC,
		CT_MM_PLAY_SOUNDEFFECT,
		CT_MM_SET_MAIN_COMPASS,
		CT_MM_SET_UD_COMPASS,
		CT_LAYEREDIMAGE_ADD,
		CT_LAYEREDIMAGE_CLEAR,
		CT_LAYEREDIMAGE_REMOVE,
		CT_LAYEREDIMAGE_REPLACE,
		CT_DISPLAYITEMDESC,
		CT_ITEM_LAYERED_REMOVE,
		CT_ITEM_LAYERED_WEAR,
		CT_MOVEITEMTOCHAR,
		CT_MOVEITEMTOINV,
		CT_MOVEITEMTOOBJ,
		CT_MOVEITEMTOROOM,
		CT_SETOBJECTACTION,
		CT_ITEM_SET_CUSTOM_PROPERTY,
		CT_ITEM_SET_CUSTOM_PROPERTY_JS,
		CT_SETITEMDESC,
		CT_ITEM_SET_NAME_OVERRIDE,
		CT_SETLOCKEDUNLOCKED,
		CT_SETOPENCLOSED,
		CT_SETITEMTOWORN,
		CT_ITEM_SET_VISIBILITY,
		CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER,
		CT_LOOP_BREAK,
		CT_CANCELMOVE,
		CT_DISPLAYPLAYERDESC,
		CT_SETLAYEREDPLAYERPORTRAIT,
		CT_MOVEINVENTORYTOCHAR,
		CT_MOVEINVENTORYTOROOM,
		CT_MOVEPLAYER,
		CT_MOVETOCHAR,
		CT_MOVETOOBJ,
		CT_PLAYER_SET_CUSTOM_PROPERTY,
		CT_PLAYER_SET_CUSTOM_PROPERTY_JS,
		CT_SETPLAYERACTION,
		CT_SETPLAYERDESC,
		CT_SETPLAYERGENDER,
		CT_SETPLAYERNAME,
		CT_SETPLAYERPORTRAIT,
		CT_DISPLAYROOMDESCRIPTION,
		CT_DISPLAYROOMPICTURE,
		CT_ROOM_MOVE_ITEMS_TO_PLAYER,
		CT_SETROOMACTION,
		CT_ROOM_SET_CUSTOM_PROPERTY,
		CT_ROOM_SET_CUSTOM_PROPERTY_JS,
		CT_SETROOMDESCRIPTION,
		CT_SETEXIT,
		CT_SETEXITDESTINATION,
		CT_ROOM_SET_NAME_OVERRIDE,
		CT_SETROOMLAYEREDPIC,
		CT_SETROOMPIC,
		CT_Status_ItemVisibleInvisible,
		CT_EXECUTETIMER,
		CT_RESETTIMER,
		CT_TIMER_SET_CUSTOM_PROPERTY,
		CT_TIMER_SET_CUSTOM_PROPERTY_JS,
		CT_SETTIMER,
		CT_DISPLAYVARIABLE,
		CT_SETVARIABLE,
		CT_ITEM_GETRANDOMGROUP,
		CT_MM_GETRANDOMGROUP,
		CT_VARIABLE_SET_JAVASCRIPT,
		CT_SETVARIABLEBYINPUT,
		CT_SETVARIABLE_NUMERIC_BYINPUT,
		CT_VARIABLE_SET_CUSTOM_PROPERTY,
		CT_VARIABLE_SET_CUSTOM_PROPERTY_JS,
		CT_VARIABLE_SET_RANDOMLY,
		CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE,
		CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE,
		CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE,
		CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE,
		CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE,
		CT_VARIABLE_SET_WITH_VARIABLE,
		CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE,
		CT_ENDGAME
	}

	public CommandType cmdtype;

	public string CommandName = "";

	public string CommandText = "";

	public string CommandPart2 = "";

	public string CommandPart3 = "";

	public string CommandPart4 = "";

	public ArrayList CustomChoices = new ArrayList();

	public EnhancedInputData EnhInputData = new EnhancedInputData();

	public Command()
	{
	}

	protected Command(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			CommandName = (string)info.GetValue("CommandName", CommandName.GetType());
			try
			{
				cmdtype = (CommandType)Enum.Parse(typeof(CommandType), (string)info.GetValue("cmdtype", CommandName.GetType()), ignoreCase: true);
			}
			catch
			{
				cmdtype = (CommandType)info.GetValue("cmdtype", cmdtype.GetType());
			}
			CommandText = (string)info.GetValue("CommandText", CommandText.GetType());
			CommandPart2 = (string)info.GetValue("CommandPart2", CommandPart2.GetType());
			CommandPart3 = (string)info.GetValue("CommandPart3", CommandPart3.GetType());
			CommandPart4 = (string)info.GetValue("CommandPart4", CommandPart4.GetType());
			try
			{
				CustomChoices = (ArrayList)info.GetValue("CustomChoices", CustomChoices.GetType());
			}
			catch
			{
				CustomChoices = new ArrayList();
			}
			try
			{
				EnhInputData = (EnhancedInputData)info.GetValue("EnhancedInputData", EnhInputData.GetType());
			}
			catch
			{
				EnhInputData = new EnhancedInputData();
			}
			if (Game.bUpgrading && string.Compare(Game.CurrentObjectVersionNumber, "0.6", ignoreCase: true) < 0 && cmdtype > CommandType.CT_DISPLAYPLAYERDESC)
			{
				cmdtype += 2;
			}
			if (Game.bUpgrading && string.Compare(Game.CurrentObjectVersionNumber, "0.8", ignoreCase: true) < 0 && cmdtype > CommandType.CT_SETROOMPIC)
			{
				cmdtype++;
			}
			if (Game.bUpgrading && string.Compare(Game.CurrentObjectVersionNumber, "0.9.1", ignoreCase: true) < 0)
			{
				if (cmdtype > CommandType.CT_MM_SET_MAIN_COMPASS)
				{
					cmdtype += 4;
				}
				else if (cmdtype > CommandType.CT_SETPLAYERACTION)
				{
					cmdtype += 3;
				}
				else if (cmdtype > CommandType.CT_DISPLAYTEXT)
				{
					cmdtype++;
				}
				if (cmdtype > CommandType.CT_SETROOMACTION)
				{
					cmdtype++;
				}
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Unhandled exc in command!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("CommandName", CommandName, CommandName.GetType());
		info.AddValue("cmdtype", cmdtype.ToString(), CommandName.GetType());
		info.AddValue("CommandText", CommandText, CommandText.GetType());
		info.AddValue("CommandPart2", CommandPart2, CommandPart2.GetType());
		info.AddValue("CommandPart3", CommandPart3, CommandPart3.GetType());
		info.AddValue("CommandPart4", CommandPart4, CommandPart4.GetType());
		info.AddValue("CustomChoices", CustomChoices, CustomChoices.GetType());
		info.AddValue("EnhancedInputData", EnhInputData, EnhInputData.GetType());
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		CurDoc.Append("<Command>\r\n");
		Game.AddAdvSection(ref CurDoc, "CmdType", cmdtype.ToString());
		if (CommandText != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "CommandText", CommandText);
		}
		if (CommandPart2 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Part2", CommandPart2);
		}
		if (CommandPart3 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Part3", CommandPart3);
		}
		if (CommandPart4 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Part4", CommandPart4);
		}
		if (CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>\r\n");
			foreach (string customChoice in CustomChoices)
			{
				CurDoc.Append("<CustomChoice>\r\n");
				Game.AddAdvSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>\r\n");
			}
			CurDoc.Append("</CustomChoices>\r\n");
		}
		CurDoc.Append("</Command>\r\n");
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<Command>");
		Game.AddXMLSection(ref CurDoc, "CmdType", cmdtype.ToString());
		Game.AddXMLSection(ref CurDoc, "CommandText", CommandText);
		Game.AddXMLSection(ref CurDoc, "Part2", CommandPart2);
		Game.AddXMLSection(ref CurDoc, "Part3", CommandPart3);
		Game.AddXMLSection(ref CurDoc, "Part4", CommandPart4);
		if (CustomChoices.Count > 0)
		{
			CurDoc.WriteLine("<CustomChoices>");
			foreach (string customChoice in CustomChoices)
			{
				CurDoc.WriteLine("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.WriteLine("</CustomChoice>");
			}
			CurDoc.WriteLine("</CustomChoices>");
		}
		CurDoc.WriteLine("<EnhancedInputData>");
		EnhInputData.a(ref CurDoc);
		CurDoc.WriteLine("</EnhancedInputData>");
		CurDoc.WriteLine("</Command>");
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append("<Command>");
		Game.AddXMLSection(ref CurDoc, "CmdType", cmdtype.ToString());
		Game.AddXMLSection(ref CurDoc, "CommandText", CommandText);
		Game.AddXMLSection(ref CurDoc, "Part2", CommandPart2);
		Game.AddXMLSection(ref CurDoc, "Part3", CommandPart3);
		Game.AddXMLSection(ref CurDoc, "Part4", CommandPart4);
		if (CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>");
			foreach (string customChoice in CustomChoices)
			{
				CurDoc.Append("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>");
			}
			CurDoc.Append("</CustomChoices>");
		}
		CurDoc.Append("<EnhancedInputData>");
		EnhInputData.a(ref CurDoc);
		CurDoc.Append("</EnhancedInputData>");
		CurDoc.Append("</Command>");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "CmdType");
		if (xMLSection != null)
		{
			cmdtype = (CommandType)Enum.Parse(typeof(CommandType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CommandText");
		if (xMLSection != null)
		{
			CommandText = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Part2");
		if (xMLSection != null)
		{
			CommandPart2 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Part3");
		if (xMLSection != null)
		{
			CommandPart3 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Part4");
		if (xMLSection != null)
		{
			CommandPart4 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomChoices");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				string innerText = xMLSection.ChildNodes[i].InnerText;
				CustomChoices.Add(innerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "EnhancedInputData");
		if (xMLSection != null)
		{
			EnhInputData.SetXMLData(ref xMLSection);
		}
	}

	public static string ValidateCommand(ref Command tempcmd, ref Game TheGame)
	{
		string text = string.Empty;
		_ = string.Empty;
		string roomname = TheGame.PerformTextReplacements(tempcmd.CommandPart2, null);
		string roomname2 = TheGame.PerformTextReplacements(tempcmd.CommandPart3, null);
		TheGame.PerformTextReplacements(tempcmd.CommandPart4, null);
		string text2 = TheGame.PerformTextReplacements(tempcmd.CommandText, null);
		switch (tempcmd.cmdtype)
		{
		case CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			if (roomname.Split(new char[1] { ':' }, StringSplitOptions.None).Length < 2)
			{
				text = text + "Command not set correctly: Action Add Custom Choice - " + roomname + " - " + text2 + "\r\n";
			}
			break;
		case CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
			if (roomname.Split(new char[1] { ':' }, StringSplitOptions.None).Length < 2)
			{
				text = text + "Command not set correctly: Action Remove Custom Choice - " + roomname + " - " + text2 + "\r\n";
			}
			break;
		case CommandType.CT_DISPLAYCHARDESC:
			if (TheGame.GetCharacterByName(roomname) == null)
			{
				text += "Command not set correctly: Character Display Description: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_MOVECHAR:
			if (TheGame.GetCharacterByName(roomname) == null)
			{
				text += "Command not set correctly: Character Move To Room: Invalid Character.\r\n";
			}
			if (roomname2 != Room.VoidRoomGuid.ToString() && roomname2 != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname2) == null && TheGame.GetRoomByName(ref roomname2) == null)
			{
				text += "Command not set correctly: Character Move To Room: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_SETCHARACTION:
			if (TheGame.GetCharacterByName(roomname) == null)
			{
				text += "Command not set correctly: Character Set Action To Active/Inactive: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_SETCHARDESC:
			if (TheGame.GetCharacterByName(roomname) == null)
			{
				text += "Command not set correctly: Character Set Description: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_DISPLAYITEMDESC:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Display Description: Invalid object.\r\n";
			}
			break;
		case CommandType.CT_MOVEITEMTOCHAR:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Move To Character: Invalid Object.\r\n";
			}
			if (TheGame.GetCharacterByName(roomname2) == null)
			{
				text += "Command not set correctly: Item: Move To Character: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_MOVEITEMTOINV:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Move To Inventory: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Items: Move All From Container To Container.\r\n";
			}
			if (roomname2 != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname2) == null && TheGame.GetObjectByNameOld(roomname2) == null)
			{
				text += "Command not set correctly: Items: Move All From Container To Container.\r\n";
			}
			break;
		case CommandType.CT_MOVEITEMTOOBJ:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Move Inside Object: Invalid Object.\r\n";
			}
			if (roomname2 != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname2) == null && TheGame.GetObjectByNameOld(roomname2) == null)
			{
				text += "Command not set correctly: Item: Move Inside Object: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_MOVEITEMTOROOM:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Move To Room: Invalid Object.\r\n";
			}
			if (roomname2 != Room.VoidRoomGuid.ToString() && roomname2 != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname2) == null && TheGame.GetRoomByName(ref roomname2) == null)
			{
				text += "Command not set correctly: Item: Move To Room: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_SETOBJECTACTION:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Set Action To Active/Inactive: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_SETITEMDESC:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Set Description: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_SETLOCKEDUNLOCKED:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Set State To Locked/Unlocked: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_SETOPENCLOSED:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Set State To Open/Closed: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_SETITEMTOWORN:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Set State To Worn/Removed: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_ITEM_SET_VISIBILITY:
			if (roomname != GameObject.SelfObjectGuid.ToString() && TheGame.GetObjectByName(roomname) == null && TheGame.GetObjectByNameOld(roomname) == null)
			{
				text += "Command not set correctly: Item: Set Visibility: Invalid Object.\r\n";
			}
			break;
		case CommandType.CT_MOVEINVENTORYTOCHAR:
			if (TheGame.GetCharacterByName(roomname) == null)
			{
				text += "Command not set correctly: Player: Move Inventory To Character: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_MOVEINVENTORYTOROOM:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Player: Move Inventory To Room: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_MOVEPLAYER:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Player: Move To Room: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_SETPLAYERGENDER:
			try
			{
				_ = (Player.Gender)Enum.Parse(typeof(Player.Gender), roomname);
			}
			catch
			{
				text += "Command not set correctly: Player: Set Gender: Invalid Gender.\r\n";
			}
			break;
		case CommandType.CT_DISPLAYROOMDESCRIPTION:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Room: Display Description: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_DISPLAYROOMPICTURE:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Room: Display Picture: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_SETROOMACTION:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Room: Set Action To Active/Inactive: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_SETROOMDESCRIPTION:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Room: Set Description: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_SETEXIT:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Room: Set Exit To Active/Inactive: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_SETROOMPIC:
			if (roomname != Room.VoidRoomGuid.ToString() && roomname != Room.CurrentRoomGuid.ToString() && TheGame.GetRoomForValidation(roomname) == null && TheGame.GetRoomByName(ref roomname) == null)
			{
				text += "Command not set correctly: Room: Set Picture: Invalid Room.\r\n";
			}
			break;
		case CommandType.CT_EXECUTETIMER:
			if (TheGame.GetTimerByName(roomname) == null)
			{
				text += "Command not set correctly: Timer: Execute Timer: Invalid Timer.\r\n";
			}
			break;
		case CommandType.CT_RESETTIMER:
			if (TheGame.GetTimerByName(roomname) == null)
			{
				text += "Command not set correctly: Timer: Reset Timer: Invalid Timer.\r\n";
			}
			break;
		case CommandType.CT_SETTIMER:
			if (TheGame.GetTimerByName(roomname) == null)
			{
				text += "Command not set correctly: Timer: Set Timer To Active/Inactive: Invalid Timer.\r\n";
			}
			break;
		case CommandType.CT_DISPLAYVARIABLE:
			if (TheGame.GetVariableByName(roomname) == null)
			{
				text += "Command not set correctly: Variable: Display Data: Invalid Variable Name.\r\n";
			}
			break;
		case CommandType.CT_SETVARIABLE:
			if (TheGame.GetVariableByName(roomname) == null)
			{
				text += "Command not set correctly: Variable: Set: Invalid Variable Name.\r\n";
			}
			break;
		case CommandType.CT_SETVARIABLEBYINPUT:
			if (TheGame.GetVariableByName(roomname2) == null)
			{
				text += "Command not set correctly: Variable: Set By User Input: Invalid Variable Name.\r\n";
			}
			break;
		case CommandType.CT_VARIABLE_SET_RANDOMLY:
			if (TheGame.GetVariableByName(roomname) == null)
			{
				text += "Command not set correctly: Variable: Set Numeric Randomly: Invalid Variable Name.\r\n";
			}
			break;
		case CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			if (TheGame.GetVariableByName(roomname) == null)
			{
				text += "Command not set correctly: Variable: Set With Variable: Invalid Variable Name.\r\n";
			}
			break;
		}
		return text;
	}

	public static string GetCommandHelpText(CommandType cmdtype)
	{
		string empty = string.Empty;
		switch (cmdtype)
		{
		case CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			return "This command lets you add a custom choice to an Action that takes custom input.  In order for an action to show up in the drop down list for Select Action, it must be marked as taking custom input obviously.  Finally, type in your new custom choice and it will show up the next time the player executes the action.";
		case CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
			return "This command lets you clear all custom choices in an Action that takes custom input.  In order for an action to show up in the drop down list for Select Action, it must be marked as taking custom input obviously.";
		case CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
			return "This command lets you remove a custom choice to an Action that takes custom input.  In order for an action to show up in the drop down list for Select Action, it must be marked as taking custom input obviously.  Finally, type in the custom choice you would like removed and it will not show up the next time the player executes the action.";
		case CommandType.CT_DISPLAYCHARDESC:
			return "This command will display the selected character's description to the player.";
		case CommandType.CT_MOVECHAR:
			return "This command will move the selected character to the selected room.";
		case CommandType.CT_MOVECHARINVTOPLAYER:
			return "This command will move the selected character's inventory to the player.  This will only move carryable, visible items.";
		case CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
			return "This command will move items in the selected room to the player.  This will only move carryable, visible items.";
		case CommandType.CT_SETCHARACTION:
			return "This command lets you activate or deactivate certain actions availabe on a character.  Select your character in the combo box, then select from their list of available actions and events.  You can enable and disable any event or action you'd like for the character.";
		case CommandType.CT_SETCHARDESC:
			return "This command lets you change a character's description.  Select your character in the combo box, then type in their new description.";
		case CommandType.CT_CANCELMOVE:
			return "This command will stop a player from moving.  This command is typically used in the <<on player enter>> or <<on player leave>> events of a room, but could be used anywhere.  If a player is in the process of moving to another room, this command will cancel the move and the player will remain in their current room.";
		case CommandType.CT_COMMENT:
			return "This command does nothing except let the designer store comments in the game file.  This will let you remember what a complicated action does or what you have remaining to do in your game.";
		case CommandType.CT_DEBUGTEXT:
			return "This command shows useful text messages in the player, but they will only show up when you are debugging your game.  During normal gameplay, these messages will not show up. In order to debug your game, simply choose \"Debug Current Game\" under the Tools menu.";
		case CommandType.CT_DISPLAYLAYEREDPICTURE:
			return "This command lets you change the main picture's layered image viewed by the player.  Simply select the picture you'd like to display to the player.  This should typically be a transparent GIF that will display over the current main picture.";
		case CommandType.CT_DISPLAYPICTURE:
			return "This command lets you change the main picture viewed by the player.  Simply select the picture you'd like to display to the player.";
		case CommandType.CT_DISPLAYTEXT:
			return "This command will display text to the player.  You can of course use variable replacement codes and color codes to modify the display.  Use Alt-V to bring up a list of variable replacements when you return to the action control.";
		case CommandType.CT_EXPORTVARIABLE:
			return "This command will let you save variable data for later importing into a new game or part 2 of a game so your players can carry their data through to the next game.  The user will be prompted with a save dialog so they can specify a filename and the variable will be exported to the file.";
		case CommandType.CT_IMPORTVARIABLE:
			return "This command will let you load variable data into your game.  The user will be prompted with a load file dialog so they can specify a previously saved exported variable file from a previous game into the current game.";
		case CommandType.CT_PAUSEGAME:
			return "This command will temporarily pause the game.  The click to continue button will be illuminated in the player.  Once the player clicks the button, the game will continue.  this is a good way to display a series of pictures in sequence during a command, or if you have a lot of text you'd like to display in chunks to the player.";
		case CommandType.CT_ENDGAME:
			return "This command will end the game.  You can enter text that will display to the player and explain why the game has ended.";
		case CommandType.CT_DISPLAYITEMDESC:
			return "This command lets you display an item's description.  Simply select the item from the combo box whose description you'd like displayed.";
		case CommandType.CT_MOVEITEMTOCHAR:
			return "This command lets you move an item into a character's inventory.  Select the item you'd like to move, then select the character who will now be holding the item.";
		case CommandType.CT_MOVEITEMTOINV:
			return "This command lets you move an item to the player's inventory.  You only need to select which item will be moved to the player's inventory.";
		case CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
			return "This command lets you move all items from one container to another.  First, select the source container.  This container should currently have items in it.  Next, select the destination container.  This is the container that will receive all the items.";
		case CommandType.CT_MOVEITEMTOOBJ:
			return "This command will put an item inside an object.  First, select the object you'd like to move.  Next, select a container object that will hold the item.  Only items with the container property will show up in this final combo box.";
		case CommandType.CT_MOVEITEMTOROOM:
			return "This command will move the selected object into the selected room.  First, select the object, then select the room you want the object to be moved to.";
		case CommandType.CT_SETOBJECTACTION:
			return "This command lets you activate or deactivate certain actions availabe on an item/object.  Select your item in the combo box, then select from their list of available actions and events.  You can enable and disable any event or action you'd like for the selected item/object.";
		case CommandType.CT_SETITEMDESC:
			return "This command lets you modify the description of an item/object.  First, select the item/object, then type in its new description.";
		case CommandType.CT_SETLOCKEDUNLOCKED:
			return "This command lets you change the state of a lockable object.  First, select the lockable item from the combo box, then select its state: Locked or Unlocked.";
		case CommandType.CT_SETOPENCLOSED:
			return "This command lets you change the state of an openable object.  First, select the openable item from the combo box, then select its state: Open or Closed.";
		case CommandType.CT_SETITEMTOWORN:
			return "This command lets you change the state of a wearable object.  First, select the wearable item from the combo box, then select its state: Worn or Removed.";
		case CommandType.CT_ITEM_SET_VISIBILITY:
			return "This command lets you change the visible state of an object.  First, select the item from the combo box, then select its state: Visible or Invisible. Invisible objects won't show up in any descriptions and can't be interacted with by the player.";
		case CommandType.CT_MOVEINVENTORYTOCHAR:
			return "This command will move the players entire inventory to a selected character.";
		case CommandType.CT_MOVEINVENTORYTOROOM:
			return "This command will move the player's entire inventory to the selected room.";
		case CommandType.CT_MOVEPLAYER:
			return "This command will move the player to the selected room.";
		case CommandType.CT_SETPLAYERGENDER:
			return "This command will change your player's gender.  This will affect certain text replacement triggers such as [man/woman] [boy/girl] or [male/female].";
		case CommandType.CT_SETPLAYERPORTRAIT:
			return "This command will change the player's portrait in the rags player.  Simply select the picture you'd like displayed in the portrait panel.";
		case CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
			return "This command will change the player's layered portrait in the rags player.  Simply select the picture you'd like displayed in the portrait panel.  This should be a transparent GIF image that will lay over the portrait's background image.";
		case CommandType.CT_DISPLAYROOMDESCRIPTION:
			return "This command will display the selected room's description.  You just need to choose which room's description should be displayed.";
		case CommandType.CT_DISPLAYROOMPICTURE:
			return "This command will display the selected room's picture in the main picture display panel.  You just need to choose which room's picture should be displayed.";
		case CommandType.CT_SETROOMACTION:
			return "This command lets you activate or deactivate certain actions availabe on a room.  Select your room in the combo box, then select from their list of available actions and events.  You can enable and disable any event or action you'd like for the selected room.";
		case CommandType.CT_SETROOMDESCRIPTION:
			return "This command will set the selected room's description.  You just need to choose which a room, then type in that room's new description.  Please note that this will NOT display the new description, merely change it.";
		case CommandType.CT_SETEXIT:
			return "This command will let you activate or deactivate exits from the selected room.  First, select the room whose exits are to be modified.  Next, select from the available exits and choose whether the exit should be active or inactive.  once an exit is inactive, it will not show up on the navigation compass in the RAGS player's compass rose until it becomes active again.";
		case CommandType.CT_SETEXITDESTINATION:
			return "This command will let you change the exit destination from the selected room.  First, select the room whose exits are to be modified.  Next, select the direction to change.  Finally, specify the new room to link to.  By default, these new destinations are active.";
		case CommandType.CT_SETROOMLAYEREDPIC:
			return "This command will set the selected room's default layered picture.  You just need to choose which a room, then select the appropriate picture.  This should typically be a transparent GIF that will be imposed over the room's main picture.  Please note that this will NOT display the new picture, merely change it.";
		case CommandType.CT_SETROOMPIC:
			return "This command will set the selected room's default picture.  You just need to choose which a room, then select the appropriate picture.  Please note that this will NOT display the new picture, merely change it.";
		case CommandType.CT_LOOP_BREAK:
			return "This command will exit the current loop condition if you are currently in a loop.  If you are not currently in a loop, this command is ignored.";
		case CommandType.CT_EXECUTETIMER:
			return "This command will immediately run the selected timer.  This command is the equivalent of a function call, immediately executing the <<on each turn>> event of the selected timer.  This is an excellent way of grouping commonly called commands and condition checks together so you're not copying the same commands and conditions throughout your game.";
		case CommandType.CT_RESETTIMER:
			return "This command will immediately reset the turn count of the selected timer to 0.  This command has one extra powerful feature.  If you use this command within a timer and reset the currently running timer, the timer will immediately restart like a while loop.  This is a powerful way to loop through a large number of items and do a great deal of processing in your RAGS game.";
		case CommandType.CT_SETTIMER:
			return "This command will turn a timer on or off.  Select the timer you'd like to change, and specify whether it should be active or inactive.";
		case CommandType.CT_DISPLAYVARIABLE:
			return "This command will display the contents of a variable to the player.  You just need to select the variable whose contents will be displayed to the player.";
		case CommandType.CT_SETVARIABLE:
			return "This command will set the contents of a variable.  Once you select the variable you'd like to modify, the options will change based on the variable type.  You will be able to add, subtract, add days, set text, etc... depending on the variable type you are manipulating.  You can also use variable replacements to set the contents of a variable ex. [v: SomeVariable]";
		case CommandType.CT_SETVARIABLEBYINPUT:
			return "This command will set the contents of a text variable with the player's input.  You need to specify which type of input you will be receiving from the player.  You can choose objects, characters, objects and characters, inventory, custom, or text input just like at the action level.  The Player's reponse is stored in the selected text variable.  This can be used as a custom storage for a player's name so that it can be easily modifed later, or any other input data you'd like to track and be able to directly modify later in the game.";
		case CommandType.CT_VARIABLE_SET_RANDOMLY:
			return "This command will set the contents of a numeric variable randomly.  In order to set the variable randomly, the numeric variable must have its enforce limits turned on.  The min and max limits are what RAGS uses to randomize the value.";
		case CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			return "This command will set the contents of a variable with the value of another variable.  Once you select the variable you'd like to modify, the options will change based on the variable type.  You will be able to add, subtract, add days, set text, etc... depending on the variable type you are manipulating.";
		case CommandType.CT_ITEM_LAYERED_REMOVE:
		case CommandType.CT_ITEM_LAYERED_WEAR:
			return "Layered Clothing is comprised of zones and levels.  A zone corresponds to a part of the body and the level is the order in which the clothing should be worn.  Level 1 is the closest to the skin, and level 10 would be the farthest from the skin.  RAGS preloads three body zones for you.  They are \"Lower Body\", \"Mid Body\", and \"Upper Body\".  You can add to these zones, say, a \"Head\" zone, or delete all the zones and create your own custom zones.  One piece of clothing may occupy more then one zone and level.  This is perfectly fine.  Just assign as many zones and levels as required.  Ex: Socks could be \"Lower Body Level 1\", Shoes could be \"Lower Body Level 2\", and say a dress could be \"Upper Body Level 2 and Mid Body Level 2\".  There are two commands that use the layered clothing scheme.  Item: Layered Wear and Item: Layered Remove.  These commands enforce layered clothing limits.  Since clothing may or may not be worn after the command runs, you will need to check the status of the item and see if its worn, if you need to do additional commands after its successfully worn.  All text displays to the player are automatically handled by the command.  You no longer need to display text telling the player their item is worn or removed.  Here are the enforced rules by the layered clothes engine using our socks and shoes as an example.  Shoes(lvl 2) may be worn without Socks(lvl 1).  Socks(lvl 1) can not be worn if Shoes(lvl 2) are currently worn, or if another pair of Socks(lvl 1) are already worn.  Socks could not be removed if Shoes(lvl 2) are also already worn.  For Items that span multiple zones, the same rules apply, the are enforced at each level.";
		default:
			return "No help found for this command.";
		}
	}

	public static void PopulateComboWithCommands(ComboBox cb, bool bFilter)
	{
		cb.Items.Clear();
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ACTION_ADD_CUSTOMCHOICE, "Action: Add Custom Choice"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE, "Action: Clear Custom Choice"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE, "Action: Remove Custom Choice"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYCHARDESC, "Character: Display Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_DISPLAYPORT, "Character: Display Portrait"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVECHAR, "Character: Move To Room"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVECHARINVTOPLAYER, "Character: Move Inventory To Player"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_MOVETOOBJ, "Character: Move To Object"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SETPORT, "Character: Set Portrait Media"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETCHARACTION, "Character: Set Action To Active/Inactive"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_CUSTOM_PROPERTY, "Character: Set Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS, "Character: Set Custom Property (Javascript)"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETCHARDESC, "Character: Set Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_GENDER, "Character: Set Gender"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_NAME, "Character: Set Display Name"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_COMMENT, "Add A Comment"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DEBUGTEXT, "Debug Text"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_JAVA_SET_RAGS, "Set RAGS data with Javascript"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYTEXT, "Display Text"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_EXPORTVARIABLE, "Export Variable"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_IMPORTVARIABLE, "Import Variable"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_PAUSEGAME, "Pause Game"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYLAYEREDPICTURE, "Media: Display Layered Picture"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYPICTURE, "Media: Display Multimedia"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_SET_BACKGROUND_MUSIC, "Media: Set Background Music"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_STOP_BACKGROUND_MUSIC, "Media: Stop Background Music"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_PLAY_SOUNDEFFECT, "Media: Play Sound Effect"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_SET_MAIN_COMPASS, "Media: Set Main Compass Picture"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_SET_UD_COMPASS, "Media: Set Up/Down Compass Picture"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_ADD, "Image: Add Layered Image"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_CLEAR, "Image: Clear Layered Images"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_REMOVE, "Image: Remove Layered Image"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_REPLACE, "Image: Replace Layered Image"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYITEMDESC, "Item: Display Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_LAYERED_REMOVE, "Item: Layered Remove"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_LAYERED_WEAR, "Item: Layered Wear"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOCHAR, "Item: Move To Character"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOINV, "Item: Move To Inventory"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOOBJ, "Item: Move Inside Object"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOROOM, "Item: Move To Room"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETOBJECTACTION, "Item: Set Action To Active/Inactive"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_CUSTOM_PROPERTY, "Item: Set Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS, "Item: Set Custom Property (Javascript)"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETITEMDESC, "Item: Set Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_NAME_OVERRIDE, "Item: Set Display Name"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETLOCKEDUNLOCKED, "Item: Set State To Locked/Unlocked"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETOPENCLOSED, "Item: Set State To Open/Closed"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETITEMTOWORN, "Item: Set State To Worn/Removed"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_VISIBILITY, "Item: Set Visibility"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER, "Items: Move All From Container To Container"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LOOP_BREAK, "Loop: Break Out Of Loop"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CANCELMOVE, "Player: Cancel Move"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYPLAYERDESC, "Player: Display Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETLAYEREDPLAYERPORTRAIT, "Player: Set Layered Portrait"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEINVENTORYTOCHAR, "Player: Move Inventory To Character"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEINVENTORYTOROOM, "Player: Move Inventory To Room"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEPLAYER, "Player: Move To Room"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVETOCHAR, "Player: Move To Character"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVETOOBJ, "Player: Move To Object"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY, "Player: Set Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS, "Player: Set Custom Property (Javascript)"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERACTION, "Player: Set Action To Active/Inactive"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERDESC, "Player: Set Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERGENDER, "Player: Set Gender"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERNAME, "Player: Set Name"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERPORTRAIT, "Player: Set Portrait Media"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYROOMDESCRIPTION, "Room: Display Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYROOMPICTURE, "Room: Display Picture"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER, "Room: Move Items To Player"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMACTION, "Room: Set Action To Active/Inactive"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_SET_CUSTOM_PROPERTY, "Room: Set Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS, "Room: Set Custom Property (Javascript)"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMDESCRIPTION, "Room: Set Description"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETEXIT, "Room: Set Exit To Active/Inactive"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETEXITDESTINATION, "Room: Set Exit Destination"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_SET_NAME_OVERRIDE, "Room: Set Display Name"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMLAYEREDPIC, "Room: Set Layered Picture"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMPIC, "Room: Set Picture"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_Status_ItemVisibleInvisible, "StatusBar: Set Visible/Invisible"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_EXECUTETIMER, "Timer: Execute Timer"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_RESETTIMER, "Timer: Reset Timer"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_TIMER_SET_CUSTOM_PROPERTY, "Timer: Set Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS, "Timer: Set Custom Property (Javascript)"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETTIMER, "Timer: Set Timer To Active/Inactive"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYVARIABLE, "Variable: Display Data"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETVARIABLE, "Variable: Set"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_GETRANDOMGROUP, "Variable: Set With Random Item Group Member"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_GETRANDOMGROUP, "Variable: Set With Random Media Group Member"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_JAVASCRIPT, "Variable: Set (Javascript)"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETVARIABLEBYINPUT, "Variable: Set By User Input"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT, "Variable: Set Numeric By User Input"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY, "Variable: Set Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS, "Variable: Set Custom Property (Javascript)"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_RANDOMLY, "Variable: Set Numeric Randomly"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE, "Variable: Set With Character Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE, "Variable: Set With Item Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE, "Variable: Set With Player Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE, "Variable: Set With Room Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE, "Variable: Set With Timer Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_VARIABLE, "Variable: Set With Variable"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE, "Variable: Set With Variable Custom Property"));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ENDGAME, "End The Game"));
		if (!bFilter)
		{
			return;
		}
		List<string> list = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Command);
		for (int num = cb.Items.Count - 1; num >= 0; num--)
		{
			if (cb.Items[num] is CommandConditionComboItem commandConditionComboItem && list.Contains(commandConditionComboItem.Name))
			{
				cb.Items.Remove((object)commandConditionComboItem);
			}
		}
	}

	public static string GetCommandName(CommandType ct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		string result = string.Empty;
		ComboBox val = new ComboBox();
		PopulateComboWithCommands(val, bFilter: false);
		foreach (CommandConditionComboItem item in val.Items)
		{
			if (item.ctindex == ct)
			{
				result = item.Name;
				break;
			}
		}
		return result;
	}

	public static CommandConditionComboItem GetCommandItem(ComboBox tempcb, CommandType ct)
	{
		CommandConditionComboItem commandConditionComboItem = null;
		foreach (CommandConditionComboItem item in tempcb.Items)
		{
			if (item.ctindex == ct)
			{
				commandConditionComboItem = item;
				break;
			}
		}
		if (commandConditionComboItem == null)
		{
			CommandConditionComboItem commandConditionComboItem3 = new CommandConditionComboItem(ct, GetCommandName(ct));
			tempcb.Items.Add((object)commandConditionComboItem3);
			commandConditionComboItem = commandConditionComboItem3;
		}
		return commandConditionComboItem;
	}

	public static void PopulateTreeViewWithCommands(TreeView tv)
	{
		tv.Nodes.Clear();
		TreeNode val = tv.Nodes.Add("Actions");
		val.Nodes.Add("Add Custom Choice").Tag = CommandType.CT_ACTION_ADD_CUSTOMCHOICE;
		val.Nodes.Add("Remove Custom Choice").Tag = CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE;
		TreeNode val2 = tv.Nodes.Add("Characters");
		val2.Nodes.Add("Display Description").Tag = CommandType.CT_DISPLAYCHARDESC;
		val2.Nodes.Add("Move To Room").Tag = CommandType.CT_MOVECHAR;
		val2.Nodes.Add("Set Action To Active/Inactive").Tag = CommandType.CT_SETCHARACTION;
		val2.Nodes.Add("Set Action To Active/Inactive").Tag = CommandType.CT_SETCHARDESC;
		TreeNode val3 = tv.Nodes.Add("Utilities");
		val3.Nodes.Add("Add A Comment").Tag = CommandType.CT_COMMENT;
		val3.Nodes.Add("Display Layered Picture").Tag = CommandType.CT_DISPLAYLAYEREDPICTURE;
		val3.Nodes.Add("Display Picture").Tag = CommandType.CT_DISPLAYPICTURE;
		val3.Nodes.Add("Display Text").Tag = CommandType.CT_DISPLAYTEXT;
		val3.Nodes.Add("Pause Game").Tag = CommandType.CT_PAUSEGAME;
		val3.Nodes.Add("End The Game").Tag = CommandType.CT_ENDGAME;
		TreeNode val4 = tv.Nodes.Add("Objects");
		val4.Nodes.Add("Display Description").Tag = CommandType.CT_DISPLAYITEMDESC;
		val4.Nodes.Add("Move To Character").Tag = CommandType.CT_MOVEITEMTOCHAR;
		val4.Nodes.Add("Move To Inventory").Tag = CommandType.CT_MOVEITEMTOINV;
		val4.Nodes.Add("Move Inside Object").Tag = CommandType.CT_MOVEITEMTOOBJ;
		val4.Nodes.Add("Move To Room").Tag = CommandType.CT_MOVEITEMTOROOM;
		val4.Nodes.Add("Set Action To Active/Inactive").Tag = CommandType.CT_SETOBJECTACTION;
		val4.Nodes.Add("Set Description").Tag = CommandType.CT_SETITEMDESC;
		val4.Nodes.Add("Set State To Locked/Unlocked").Tag = CommandType.CT_SETLOCKEDUNLOCKED;
		val4.Nodes.Add("Set State To Open/Closed").Tag = CommandType.CT_SETOPENCLOSED;
		val4.Nodes.Add("Set State To Worn/Removed").Tag = CommandType.CT_SETITEMTOWORN;
		val4.Nodes.Add("Set Visibility").Tag = CommandType.CT_ITEM_SET_VISIBILITY;
		val4.Nodes.Add("Move All From Container To Container").Tag = CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER;
		TreeNode val5 = tv.Nodes.Add("Player");
		val5.Nodes.Add("Cancel Move").Tag = CommandType.CT_CANCELMOVE;
		val5.Nodes.Add("Display Description").Tag = CommandType.CT_DISPLAYPLAYERDESC;
		val5.Nodes.Add("Set Layered Portrait").Tag = CommandType.CT_SETLAYEREDPLAYERPORTRAIT;
		val5.Nodes.Add("Move Inventory To Character").Tag = CommandType.CT_MOVEINVENTORYTOCHAR;
		val5.Nodes.Add("Move Inventory To Room").Tag = CommandType.CT_MOVEINVENTORYTOROOM;
		val5.Nodes.Add("Move To Room").Tag = CommandType.CT_MOVEPLAYER;
		val5.Nodes.Add("Set Action To Active/Inactive").Tag = CommandType.CT_SETPLAYERACTION;
		val5.Nodes.Add("Set Description").Tag = CommandType.CT_SETPLAYERDESC;
		val5.Nodes.Add("Set Gender").Tag = CommandType.CT_SETPLAYERGENDER;
		val5.Nodes.Add("Set Name").Tag = CommandType.CT_SETPLAYERNAME;
		val5.Nodes.Add("Set Portrait").Tag = CommandType.CT_SETPLAYERPORTRAIT;
		TreeNode val6 = tv.Nodes.Add("Rooms");
		val6.Nodes.Add("Display Description").Tag = CommandType.CT_DISPLAYROOMDESCRIPTION;
		val6.Nodes.Add("Display Picture").Tag = CommandType.CT_DISPLAYROOMPICTURE;
		val6.Nodes.Add("Set Action To Active/Inactive").Tag = CommandType.CT_SETROOMACTION;
		val6.Nodes.Add("Set Description").Tag = CommandType.CT_SETROOMDESCRIPTION;
		val6.Nodes.Add("Set Exit To Active/Inactive").Tag = CommandType.CT_SETEXIT;
		val6.Nodes.Add("Set Layered Picture").Tag = CommandType.CT_SETROOMLAYEREDPIC;
		val6.Nodes.Add("Set Picture").Tag = CommandType.CT_SETROOMPIC;
		TreeNode val7 = tv.Nodes.Add("Timers");
		val7.Nodes.Add("Execute Timer").Tag = CommandType.CT_EXECUTETIMER;
		val7.Nodes.Add("Reset Timer").Tag = CommandType.CT_RESETTIMER;
		val7.Nodes.Add("Set Timer To Active/Inactive").Tag = CommandType.CT_SETTIMER;
		TreeNode val8 = tv.Nodes.Add("Variables");
		val8.Nodes.Add("Display Data").Tag = CommandType.CT_DISPLAYVARIABLE;
		val8.Nodes.Add("Set").Tag = CommandType.CT_SETVARIABLE;
		val8.Nodes.Add("Set By User Input").Tag = CommandType.CT_SETVARIABLEBYINPUT;
		val8.Nodes.Add("Set Numeric Randomly").Tag = CommandType.CT_VARIABLE_SET_RANDOMLY;
		val8.Nodes.Add("Set With Variable").Tag = CommandType.CT_VARIABLE_SET_WITH_VARIABLE;
	}

	public bool ContainsValue(string val)
	{
		if (CommandName.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0 || CommandPart2.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0 || CommandPart3.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0 || CommandPart4.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0 || CommandText.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		return false;
	}

	public void GetJSText(ref StringBuilder sb)
	{
		sb.Append("[");
		sb.Append("\"CMD\",");
		sb.Append("\"" + cmdtype.ToString() + "\",");
		sb.Append("\"" + CommandName + "\",");
		sb.Append("\"" + CommandText.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>")
			.Replace("\n", "<br>") + "\",");
		sb.Append("\"" + CommandPart2.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		sb.Append("\"" + CommandPart3.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		sb.Append("\"" + CommandPart4.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>")
			.Replace("\n", "<br>") + "\",");
		int num = 0;
		sb.Append("[");
		foreach (string customChoice in CustomChoices)
		{
			if (num > 0)
			{
				sb.Append(",");
			}
			sb.Append("\"" + customChoice.Replace("'", "\\'").Replace("\"", "\\\"") + "\"");
			num++;
		}
		sb.Append("],");
		EnhInputData.c(ref sb);
		sb.Append("]");
	}
}
