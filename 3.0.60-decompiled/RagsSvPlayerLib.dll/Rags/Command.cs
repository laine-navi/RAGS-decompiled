using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rags;

public class Command
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
		CT_Execute_SQL,
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

	public static bool bWebVersion;

	[CompilerGenerated]
	private CommandType a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private string c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private string e;

	[CompilerGenerated]
	private string f;

	[CompilerGenerated]
	private List<string> g;

	[CompilerGenerated]
	private EnhancedInputData h;

	public CommandType cmdtype
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

	public string CommandName
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

	public string CommandText
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

	public string CommandPart2
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

	public string CommandPart3
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

	public string CommandPart4
	{
		[CompilerGenerated]
		get
		{
			return f;
		}
		[CompilerGenerated]
		set
		{
			f = value;
		}
	}

	public List<string> CustomChoices
	{
		[CompilerGenerated]
		get
		{
			return g;
		}
		[CompilerGenerated]
		set
		{
			g = value;
		}
	}

	public EnhancedInputData EnhInputData
	{
		[CompilerGenerated]
		get
		{
			return h;
		}
		[CompilerGenerated]
		set
		{
			h = value;
		}
	}

	public Command()
	{
		cmdtype = CommandType.CT_UNINITIALIZED;
		CommandName = string.Empty;
		CommandText = string.Empty;
		CommandPart2 = string.Empty;
		CommandPart3 = string.Empty;
		CommandPart4 = string.Empty;
		CustomChoices = new List<string>();
		EnhInputData = new EnhancedInputData();
	}

	public static string ValidateCommand(ref Command tempcmd, ref Game TheGame)
	{
		string text = string.Empty;
		string empty = string.Empty;
		string[] array = null;
		Character character = null;
		GameObject gameObject = null;
		Room room = null;
		GameVariable gameVariable = null;
		Timer timer = null;
		string text2 = TheGame.PerformTextReplacements(tempcmd.CommandPart2, null);
		string text3 = TheGame.PerformTextReplacements(tempcmd.CommandPart3, null);
		TheGame.PerformTextReplacements(tempcmd.CommandPart4, null);
		string text4 = TheGame.PerformTextReplacements(tempcmd.CommandText, null);
		switch (tempcmd.cmdtype)
		{
		case CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			empty = text2;
			array = empty.Split(new char[1] { ':' }, StringSplitOptions.None);
			if (array.Length < 2)
			{
				string text6 = text;
				text = text6 + "Command not set correctly: Action Add Custom Choice - " + text2 + " - " + text4 + "\r\n";
			}
			break;
		case CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
			empty = text2;
			array = empty.Split(new char[1] { ':' }, StringSplitOptions.None);
			if (array.Length < 2)
			{
				string text5 = text;
				text = text5 + "Command not set correctly: Action Remove Custom Choice - " + text2 + " - " + text4 + "\r\n";
			}
			break;
		case CommandType.CT_DISPLAYCHARDESC:
			character = TheGame.GetCharacterByName(text2);
			if (character == null)
			{
				text += "Command not set correctly: Character Display Description: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_MOVECHAR:
			character = TheGame.GetCharacterByName(text2);
			if (character == null)
			{
				text += "Command not set correctly: Character Move To Room: Invalid Character.\r\n";
			}
			if (!(text3 != Room.VoidRoomGuid.ToString()) || !(text3 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text3);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text3);
				if (room == null)
				{
					text += "Command not set correctly: Character Move To Room: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_SETCHARACTION:
			character = TheGame.GetCharacterByName(text2);
			if (character == null)
			{
				text += "Command not set correctly: Character Set Action To Active/Inactive: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_SETCHARDESC:
			character = TheGame.GetCharacterByName(text2);
			if (character == null)
			{
				text += "Command not set correctly: Character Set Description: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_DISPLAYITEMDESC:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Display Description: Invalid object.\r\n";
				}
			}
			break;
		case CommandType.CT_MOVEITEMTOCHAR:
			if (text2 != GameObject.SelfObjectGuid.ToString())
			{
				gameObject = TheGame.GetObjectByName(text2);
				if (gameObject == null)
				{
					gameObject = TheGame.GetObjectByNameOld(text2);
					if (gameObject == null)
					{
						text += "Command not set correctly: Item: Move To Character: Invalid Object.\r\n";
					}
				}
			}
			character = TheGame.GetCharacterByName(text3);
			if (character == null)
			{
				text += "Command not set correctly: Item: Move To Character: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_MOVEITEMTOINV:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Move To Inventory: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
			if (text2 != GameObject.SelfObjectGuid.ToString())
			{
				gameObject = TheGame.GetObjectByName(text2);
				if (gameObject == null)
				{
					gameObject = TheGame.GetObjectByNameOld(text2);
					if (gameObject == null)
					{
						text += "Command not set correctly: Items: Move All From Container To Container.\r\n";
					}
				}
			}
			if (!(text3 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text3);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text3);
				if (gameObject == null)
				{
					text += "Command not set correctly: Items: Move All From Container To Container.\r\n";
				}
			}
			break;
		case CommandType.CT_MOVEITEMTOOBJ:
			if (text2 != GameObject.SelfObjectGuid.ToString())
			{
				gameObject = TheGame.GetObjectByName(text2);
				if (gameObject == null)
				{
					gameObject = TheGame.GetObjectByNameOld(text2);
					if (gameObject == null)
					{
						text += "Command not set correctly: Item: Move Inside Object: Invalid Object.\r\n";
					}
				}
			}
			if (!(text3 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text3);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text3);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Move Inside Object: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_MOVEITEMTOROOM:
			if (text2 != GameObject.SelfObjectGuid.ToString())
			{
				gameObject = TheGame.GetObjectByName(text2);
				if (gameObject == null)
				{
					gameObject = TheGame.GetObjectByNameOld(text2);
					if (gameObject == null)
					{
						text += "Command not set correctly: Item: Move To Room: Invalid Object.\r\n";
					}
				}
			}
			if (!(text3 != Room.VoidRoomGuid.ToString()) || !(text3 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text3);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text3);
				if (room == null)
				{
					text += "Command not set correctly: Item: Move To Room: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_SETOBJECTACTION:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Set Action To Active/Inactive: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_SETITEMDESC:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Set Description: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_SETLOCKEDUNLOCKED:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Set State To Locked/Unlocked: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_SETOPENCLOSED:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Set State To Open/Closed: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_SETITEMTOWORN:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Set State To Worn/Removed: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_ITEM_SET_VISIBILITY:
			if (!(text2 != GameObject.SelfObjectGuid.ToString()))
			{
				break;
			}
			gameObject = TheGame.GetObjectByName(text2);
			if (gameObject == null)
			{
				gameObject = TheGame.GetObjectByNameOld(text2);
				if (gameObject == null)
				{
					text += "Command not set correctly: Item: Set Visibility: Invalid Object.\r\n";
				}
			}
			break;
		case CommandType.CT_MOVEINVENTORYTOCHAR:
			character = TheGame.GetCharacterByName(text2);
			if (character == null)
			{
				text += "Command not set correctly: Player: Move Inventory To Character: Invalid Character.\r\n";
			}
			break;
		case CommandType.CT_MOVEINVENTORYTOROOM:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Player: Move Inventory To Room: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_MOVEPLAYER:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Player: Move To Room: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_SETPLAYERGENDER:
			try
			{
				_ = (Player.Gender)Enum.Parse(typeof(Player.Gender), text2, ignoreCase: true);
			}
			catch
			{
				text += "Command not set correctly: Player: Set Gender: Invalid Gender.\r\n";
			}
			break;
		case CommandType.CT_DISPLAYROOMDESCRIPTION:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Room: Display Description: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_DISPLAYROOMPICTURE:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Room: Display Picture: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_SETROOMACTION:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Room: Set Action To Active/Inactive: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_SETROOMDESCRIPTION:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Room: Set Description: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_SETEXIT:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Room: Set Exit To Active/Inactive: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_SETROOMPIC:
			if (!(text2 != Room.VoidRoomGuid.ToString()) || !(text2 != Room.CurrentRoomGuid.ToString()))
			{
				break;
			}
			room = TheGame.GetRoomForValidation(text2);
			if (room == null)
			{
				room = TheGame.GetRoomByName(text2);
				if (room == null)
				{
					text += "Command not set correctly: Room: Set Picture: Invalid Room.\r\n";
				}
			}
			break;
		case CommandType.CT_EXECUTETIMER:
			timer = TheGame.GetTimerByName(text2);
			if (timer == null)
			{
				text += "Command not set correctly: Timer: Execute Timer: Invalid Timer.\r\n";
			}
			break;
		case CommandType.CT_RESETTIMER:
			timer = TheGame.GetTimerByName(text2);
			if (timer == null)
			{
				text += "Command not set correctly: Timer: Reset Timer: Invalid Timer.\r\n";
			}
			break;
		case CommandType.CT_SETTIMER:
			timer = TheGame.GetTimerByName(text2);
			if (timer == null)
			{
				text += "Command not set correctly: Timer: Set Timer To Active/Inactive: Invalid Timer.\r\n";
			}
			break;
		case CommandType.CT_DISPLAYVARIABLE:
			gameVariable = TheGame.GetVariableByName(text2);
			if (gameVariable == null)
			{
				text += "Command not set correctly: Variable: Display Data: Invalid Variable Name.\r\n";
			}
			break;
		case CommandType.CT_SETVARIABLE:
			gameVariable = TheGame.GetVariableByName(text2);
			if (gameVariable == null)
			{
				text += "Command not set correctly: Variable: Set: Invalid Variable Name.\r\n";
			}
			break;
		case CommandType.CT_SETVARIABLEBYINPUT:
			gameVariable = TheGame.GetVariableByName(text3);
			if (gameVariable == null)
			{
				text += "Command not set correctly: Variable: Set By User Input: Invalid Variable Name.\r\n";
			}
			break;
		case CommandType.CT_VARIABLE_SET_RANDOMLY:
			gameVariable = TheGame.GetVariableByName(text2);
			if (gameVariable == null)
			{
				text += "Command not set correctly: Variable: Set Numeric Randomly: Invalid Variable Name.\r\n";
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
		case CommandType.CT_ITEM_LAYERED_REMOVE:
		case CommandType.CT_ITEM_LAYERED_WEAR:
			return "Layered Clothing is comprised of zones and levels.  A zone corresponds to a part of the body and the level is the order in which the clothing should be worn.  Level 1 is the closest to the skin, and level 10 would be the farthest from the skin.  RAGS preloads three body zones for you.  They are \"Lower Body\", \"Mid Body\", and \"Upper Body\".  You can add to these zones, say, a \"Head\" zone, or delete all the zones and create your own custom zones.  One piece of clothing may occupy more then one zone and level.  This is perfectly fine.  Just assign as many zones and levels as required.  Ex: Socks could be \"Lower Body Level 1\", Shoes could be \"Lower Body Level 2\", and say a dress could be \"Upper Body Level 2 and Mid Body Level 2\".  There are two commands that use the layered clothing scheme.  Item: Layered Wear and Item: Layered Remove.  These commands enforce layered clothing limits.  Since clothing may or may not be worn after the command runs, you will need to check the status of the item and see if its worn, if you need to do additional commands after its successfully worn.  All text displays to the player are automatically handled by the command.  You no longer need to display text telling the player their item is worn or removed.  Here are the enforced rules by the layered clothes engine using our socks and shoes as an example.  Shoes(lvl 2) may be worn without Socks(lvl 1).  Socks(lvl 1) can not be worn if Shoes(lvl 2) are currently worn, or if another pair of Socks(lvl 1) are already worn.  Socks could not be removed if Shoes(lvl 2) are also already worn.  For Items that span multiple zones, the same rules apply, the are enforced at each level.";
		default:
			return "No help found for this command.";
		}
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
		EnhInputData.a(ref sb);
		sb.Append("]");
	}
}
