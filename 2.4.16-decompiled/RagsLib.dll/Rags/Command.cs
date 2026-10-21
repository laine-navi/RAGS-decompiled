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
public sealed class Command : ISerializable
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
		if (info != null)
		{
			__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
			try
			{
				CommandName = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65868), CommandName.GetType());
				try
				{
					cmdtype = (CommandType)Enum.Parse(typeof(CommandType), (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65891), CommandName.GetType()), ignoreCase: true);
				}
				catch
				{
					cmdtype = (CommandType)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65891), cmdtype.GetType());
				}
				CommandText = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65906), CommandText.GetType());
				CommandPart2 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65929), CommandPart2.GetType());
				CommandPart3 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65954), CommandPart3.GetType());
				CommandPart4 = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65979), CommandPart4.GetType());
				try
				{
					CustomChoices = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66004), CustomChoices.GetType());
				}
				catch
				{
					CustomChoices = new ArrayList();
				}
				try
				{
					EnhInputData = (EnhancedInputData)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469), EnhInputData.GetType());
				}
				catch
				{
					EnhInputData = new EnhancedInputData();
				}
				if (!Game.bUpgrading)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
				}
				else if (string.Compare(Game.CurrentObjectVersionNumber, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105215), ignoreCase: true) >= 0)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
				}
				else if (cmdtype <= CommandType.CT_DISPLAYPLAYERDESC)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
				}
				else
				{
					cmdtype += 2;
				}
				if (!Game.bUpgrading)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
				}
				else if (string.Compare(Game.CurrentObjectVersionNumber, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105222), ignoreCase: true) >= 0)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
				}
				else if (cmdtype <= CommandType.CT_SETROOMPIC)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
				}
				else
				{
					cmdtype++;
				}
				if (!Game.bUpgrading)
				{
					return;
				}
				if (string.Compare(Game.CurrentObjectVersionNumber, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105229), ignoreCase: true) >= 0)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
					return;
				}
				if (cmdtype <= CommandType.CT_MM_SET_MAIN_COMPASS)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
					if (cmdtype <= CommandType.CT_SETPLAYERACTION)
					{
						__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
						if (cmdtype <= CommandType.CT_DISPLAYTEXT)
						{
							__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
						}
						else
						{
							cmdtype++;
						}
					}
					else
					{
						cmdtype += 3;
					}
				}
				else
				{
					cmdtype += 4;
				}
				if (cmdtype <= CommandType.CT_SETROOMACTION)
				{
					__ldtoken(Command._002Ector(SerializationInfo, StreamingContext));
				}
				else
				{
					cmdtype++;
				}
				return;
			}
			catch (Exception ex)
			{
				throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58565), ex.InnerException);
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65868), CommandName, CommandName.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65891), cmdtype.ToString(), CommandName.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65906), CommandText, CommandText.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65929), CommandPart2, CommandPart2.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65954), CommandPart3, CommandPart3.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65979), CommandPart4, CommandPart4.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66004), CustomChoices, CustomChoices.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469), EnhInputData, EnhInputData.GetType());
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66031));
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66054), cmdtype.ToString());
		if (!(CommandText != string.Empty))
		{
			__ldtoken(Command.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65906), CommandText);
		}
		if (!(CommandPart2 != string.Empty))
		{
			__ldtoken(Command.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66069), CommandPart2);
		}
		if (CommandPart3 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66080), CommandPart3);
		}
		if (!(CommandPart4 != string.Empty))
		{
			__ldtoken(Command.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66091), CommandPart4);
		}
		if (CustomChoices.Count <= 0)
		{
			__ldtoken(Command.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66102));
			{
				IEnumerator enumerator = CustomChoices.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Command.GetAdvancedText(ref StringBuilder));
						string value = (string)enumerator.Current;
						CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66137));
						Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), value);
						CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66170));
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66205));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66242));
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66267));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66054), cmdtype.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65906), CommandText);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66069), CommandPart2);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66080), CommandPart3);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66091), CommandPart4);
		if (CustomChoices.Count > 0)
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66286));
			IEnumerator enumerator = CustomChoices.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(Command.GetXMLData(ref StreamWriter));
					string value = (string)enumerator.Current;
					CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66317));
					Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), value);
					CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66346));
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Command.GetXMLData(ref StreamWriter));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66377));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19895));
		EnhInputData.c83abeab8711e52857623283ffa75d603(ref CurDoc);
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19934));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66410));
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66267));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66054), cmdtype.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65906), CommandText);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66069), CommandPart2);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66080), CommandPart3);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66091), CommandPart4);
		if (CustomChoices.Count > 0)
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66286));
			IEnumerator enumerator = CustomChoices.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string value = (string)enumerator.Current;
					CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66317));
					Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), value);
					CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66346));
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Command.GetXMLData(ref StringBuilder));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66377));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19895));
		EnhInputData.c83abeab8711e52857623283ffa75d603(ref CurDoc);
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19934));
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66410));
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66054));
		if (xMLSection == null)
		{
			__ldtoken(Command.SetXMLData(ref XmlNode));
		}
		else
		{
			cmdtype = (CommandType)Enum.Parse(typeof(CommandType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65906));
		if (xMLSection != null)
		{
			CommandText = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66069));
		if (xMLSection == null)
		{
			__ldtoken(Command.SetXMLData(ref XmlNode));
		}
		else
		{
			CommandPart2 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66080));
		if (xMLSection == null)
		{
			__ldtoken(Command.SetXMLData(ref XmlNode));
		}
		else
		{
			CommandPart3 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66091));
		if (xMLSection == null)
		{
			__ldtoken(Command.SetXMLData(ref XmlNode));
		}
		else
		{
			CommandPart4 = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66004));
		if (xMLSection == null)
		{
			__ldtoken(Command.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				__ldtoken(Command.SetXMLData(ref XmlNode));
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				string innerText = xmlNode.InnerText;
				CustomChoices.Add(innerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469));
		if (xMLSection == null)
		{
			__ldtoken(Command.SetXMLData(ref XmlNode));
		}
		else
		{
			EnhInputData.SetXMLData(ref xMLSection);
		}
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
		string roomname = TheGame.PerformTextReplacements(tempcmd.CommandPart2, null);
		string roomname2 = TheGame.PerformTextReplacements(tempcmd.CommandPart3, null);
		TheGame.PerformTextReplacements(tempcmd.CommandPart4, null);
		string text2 = TheGame.PerformTextReplacements(tempcmd.CommandText, null);
		CommandType commandType = tempcmd.cmdtype;
		if (commandType > CommandType.CT_SETCHARDESC)
		{
			__ldtoken(Command.ValidateCommand(ref Command, ref Game));
			if (commandType > CommandType.CT_SETVARIABLEBYINPUT)
			{
				__ldtoken(Command.ValidateCommand(ref Command, ref Game));
				switch (commandType)
				{
				case CommandType.CT_VARIABLE_SET_RANDOMLY:
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					gameVariable = TheGame.GetVariableByName(roomname);
					if (gameVariable != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(71739);
					}
					break;
				case CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					gameVariable = TheGame.GetVariableByName(roomname);
					if (gameVariable != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(71907);
					}
					break;
				}
			}
			else
			{
				switch (commandType)
				{
				case CommandType.CT_DISPLAYPICTURE:
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					break;
				case CommandType.CT_DISPLAYITEMDESC:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67426);
					}
					break;
				case CommandType.CT_MOVEITEMTOCHAR:
					if (roomname != GameObject.SelfObjectGuid.ToString())
					{
						gameObject = TheGame.GetObjectByName(roomname);
						if (gameObject != null)
						{
							__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						}
						else
						{
							gameObject = TheGame.GetObjectByNameOld(roomname);
							if (gameObject == null)
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67570);
							}
						}
					}
					character = TheGame.GetCharacterByName(roomname2);
					if (character != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67710);
					}
					break;
				case CommandType.CT_MOVEITEMTOINV:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67856);
					}
					break;
				case CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						gameObject = TheGame.GetObjectByName(roomname);
						if (gameObject != null)
						{
							__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						}
						else
						{
							gameObject = TheGame.GetObjectByNameOld(roomname);
							if (gameObject == null)
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67996);
							}
						}
					}
					if (!(roomname2 != GameObject.SelfObjectGuid.ToString()))
					{
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname2);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname2);
					if (gameObject == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67996);
					}
					break;
				case CommandType.CT_MOVEITEMTOOBJ:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						gameObject = TheGame.GetObjectByName(roomname);
						if (gameObject == null)
						{
							gameObject = TheGame.GetObjectByNameOld(roomname);
							if (gameObject != null)
							{
								__ldtoken(Command.ValidateCommand(ref Command, ref Game));
							}
							else
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(68144);
							}
						}
					}
					if (!(roomname2 != GameObject.SelfObjectGuid.ToString()))
					{
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname2);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname2);
					if (gameObject == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(68144);
					}
					break;
				case CommandType.CT_MOVEITEMTOROOM:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						gameObject = TheGame.GetObjectByName(roomname);
						if (gameObject != null)
						{
							__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						}
						else
						{
							gameObject = TheGame.GetObjectByNameOld(roomname);
							if (gameObject != null)
							{
								__ldtoken(Command.ValidateCommand(ref Command, ref Game));
							}
							else
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(68286);
							}
						}
					}
					if (!(roomname2 != Room.VoidRoomGuid.ToString()))
					{
						break;
					}
					if (!(roomname2 != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname2);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomByName(ref roomname2);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(68416);
					}
					break;
				case CommandType.CT_SETOBJECTACTION:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(68541);
					}
					break;
				case CommandType.CT_SETITEMDESC:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname);
					if (gameObject == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(68705);
					}
					break;
				case CommandType.CT_SETLOCKEDUNLOCKED:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname);
					if (gameObject == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(68841);
					}
					break;
				case CommandType.CT_SETOPENCLOSED:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject == null)
					{
						gameObject = TheGame.GetObjectByNameOld(roomname);
						if (gameObject == null)
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(69003);
						}
					}
					break;
				case CommandType.CT_SETITEMTOWORN:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(69157);
					}
					break;
				case CommandType.CT_ITEM_SET_VISIBILITY:
					if (!(roomname != GameObject.SelfObjectGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByName(roomname);
					if (gameObject != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					gameObject = TheGame.GetObjectByNameOld(roomname);
					if (gameObject == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(69313);
					}
					break;
				case CommandType.CT_MOVEINVENTORYTOCHAR:
					character = TheGame.GetCharacterByName(roomname);
					if (character != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(69447);
					}
					break;
				case CommandType.CT_MOVEINVENTORYTOROOM:
					if (!(roomname != Room.VoidRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					if (!(roomname != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomByName(ref roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(69617);
					}
					break;
				case CommandType.CT_MOVEPLAYER:
					if (!(roomname != Room.VoidRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					if (!(roomname != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomByName(ref roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(69767);
					}
					break;
				case CommandType.CT_SETPLAYERGENDER:
					try
					{
						_ = (Player.Gender)Enum.Parse(typeof(Player.Gender), roomname);
					}
					catch
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(69897);
					}
					break;
				case CommandType.CT_DISPLAYROOMDESCRIPTION:
					if (!(roomname != Room.VoidRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					if (!(roomname != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomByName(ref roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(70027);
					}
					break;
				case CommandType.CT_DISPLAYROOMPICTURE:
					if (!(roomname != Room.VoidRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					if (!(roomname != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomByName(ref roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(70167);
					}
					break;
				case CommandType.CT_SETROOMACTION:
					if (!(roomname != Room.VoidRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					if (!(roomname != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room == null)
					{
						room = TheGame.GetRoomByName(ref roomname);
						if (room != null)
						{
							__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						}
						else
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(70299);
						}
					}
					break;
				case CommandType.CT_SETROOMDESCRIPTION:
					if (!(roomname != Room.VoidRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					if (!(roomname != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room == null)
					{
						room = TheGame.GetRoomByName(ref roomname);
						if (room != null)
						{
							__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						}
						else
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(70459);
						}
					}
					break;
				case CommandType.CT_SETEXIT:
					if (!(roomname != Room.VoidRoomGuid.ToString()))
					{
						break;
					}
					if (!(roomname != Room.CurrentRoomGuid.ToString()))
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomByName(ref roomname);
					if (room == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(70591);
					}
					break;
				case CommandType.CT_SETROOMPIC:
					if (!(roomname != Room.VoidRoomGuid.ToString()) || !(roomname != Room.CurrentRoomGuid.ToString()))
					{
						break;
					}
					room = TheGame.GetRoomForValidation(roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
						break;
					}
					room = TheGame.GetRoomByName(ref roomname);
					if (room != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(70747);
					}
					break;
				case CommandType.CT_EXECUTETIMER:
					timer = TheGame.GetTimerByName(roomname);
					if (timer == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(70870);
					}
					break;
				case CommandType.CT_RESETTIMER:
					timer = TheGame.GetTimerByName(roomname);
					if (timer != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(71002);
					}
					break;
				case CommandType.CT_SETTIMER:
					timer = TheGame.GetTimerByName(roomname);
					if (timer == null)
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(71129);
					}
					break;
				case CommandType.CT_DISPLAYVARIABLE:
					gameVariable = TheGame.GetVariableByName(roomname);
					if (gameVariable != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(71291);
					}
					break;
				case CommandType.CT_SETVARIABLE:
					gameVariable = TheGame.GetVariableByName(roomname);
					if (gameVariable != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(71443);
					}
					break;
				case CommandType.CT_SETVARIABLEBYINPUT:
					gameVariable = TheGame.GetVariableByName(roomname2);
					if (gameVariable != null)
					{
						__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					}
					else
					{
						text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(71577);
					}
					break;
				}
			}
		}
		else
		{
			switch (commandType)
			{
			case CommandType.CT_SETCHARACTION:
				__ldtoken(Command.ValidateCommand(ref Command, ref Game));
				character = TheGame.GetCharacterByName(roomname);
				if (character != null)
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67098);
				}
				break;
			case CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			{
				empty = roomname;
				array = empty.Split(new char[1] { ':' }, StringSplitOptions.None);
				if (array.Length >= 2)
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					break;
				}
				string text4 = text;
				text = text4 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66431) + roomname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66540) + text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287);
				break;
			}
			case CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
				empty = roomname;
				array = empty.Split(new char[1] { ':' }, StringSplitOptions.None);
				if (array.Length < 2)
				{
					string text3 = text;
					text = text3 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66547) + roomname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66540) + text2 + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287);
				}
				break;
			case CommandType.CT_DISPLAYCHARDESC:
				character = TheGame.GetCharacterByName(roomname);
				if (character != null)
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66662);
				}
				break;
			case CommandType.CT_MOVECHAR:
				character = TheGame.GetCharacterByName(roomname);
				if (character != null)
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66820);
				}
				if (!(roomname2 != Room.VoidRoomGuid.ToString()))
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					break;
				}
				if (!(roomname2 != Room.CurrentRoomGuid.ToString()))
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					break;
				}
				room = TheGame.GetRoomForValidation(roomname2);
				if (room != null)
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
					break;
				}
				room = TheGame.GetRoomByName(ref roomname2);
				if (room != null)
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66964);
				}
				break;
			case CommandType.CT_SETCHARDESC:
				character = TheGame.GetCharacterByName(roomname);
				if (character != null)
				{
					__ldtoken(Command.ValidateCommand(ref Command, ref Game));
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(67276);
				}
				break;
			}
		}
		return text;
	}

	public static string GetCommandHelpText(CommandType cmdtype)
	{
		string empty = string.Empty;
		switch (cmdtype)
		{
		case CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72069);
		case CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(72699);
		case CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73125);
		case CommandType.CT_DISPLAYCHARDESC:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73805);
		case CommandType.CT_MOVECHAR:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(73961);
		case CommandType.CT_MOVECHARINVTOPLAYER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74097);
		case CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74337);
		case CommandType.CT_SETCHARACTION:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(74561);
		case CommandType.CT_SETCHARDESC:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(75093);
		case CommandType.CT_CANCELMOVE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(75359);
		case CommandType.CT_COMMENT:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(75989);
		case CommandType.CT_DEBUGTEXT:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(76367);
		case CommandType.CT_DISPLAYLAYEREDPICTURE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(76887);
		case CommandType.CT_DISPLAYPICTURE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(77369);
		case CommandType.CT_DISPLAYTEXT:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(77633);
		case CommandType.CT_EXPORTVARIABLE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(78091);
		case CommandType.CT_IMPORTVARIABLE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(78667);
		case CommandType.CT_PAUSEGAME:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(79103);
		case CommandType.CT_ENDGAME:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(79761);
		case CommandType.CT_DISPLAYITEMDESC:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(80001);
		case CommandType.CT_MOVEITEMTOCHAR:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(80273);
		case CommandType.CT_MOVEITEMTOINV:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(80597);
		case CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(80875);
		case CommandType.CT_MOVEITEMTOOBJ:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(81381);
		case CommandType.CT_MOVEITEMTOROOM:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(81841);
		case CommandType.CT_SETOBJECTACTION:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(82143);
		case CommandType.CT_SETITEMDESC:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(82693);
		case CommandType.CT_SETLOCKEDUNLOCKED:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(82953);
		case CommandType.CT_SETOPENCLOSED:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(83267);
		case CommandType.CT_SETITEMTOWORN:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(83575);
		case CommandType.CT_ITEM_SET_VISIBILITY:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(83883);
		case CommandType.CT_MOVEINVENTORYTOCHAR:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(84375);
		case CommandType.CT_MOVEINVENTORYTOROOM:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(84529);
		case CommandType.CT_MOVEPLAYER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(84679);
		case CommandType.CT_SETPLAYERGENDER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(84790);
		case CommandType.CT_SETPLAYERPORTRAIT:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(85086);
		case CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(85362);
		case CommandType.CT_DISPLAYROOMDESCRIPTION:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(85838);
		case CommandType.CT_DISPLAYROOMPICTURE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(86098);
		case CommandType.CT_SETROOMACTION:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(86410);
		case CommandType.CT_SETROOMDESCRIPTION:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(86930);
		case CommandType.CT_SETEXIT:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(87360);
		case CommandType.CT_SETEXITDESTINATION:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(88100);
		case CommandType.CT_SETROOMLAYEREDPIC:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(88628);
		case CommandType.CT_SETROOMPIC:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(89254);
		case CommandType.CT_LOOP_BREAK:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(89674);
		case CommandType.CT_EXECUTETIMER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(89962);
		case CommandType.CT_RESETTIMER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(90658);
		case CommandType.CT_SETTIMER:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(91408);
		case CommandType.CT_DISPLAYVARIABLE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(91678);
		case CommandType.CT_SETVARIABLE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(91986);
		case CommandType.CT_SETVARIABLEBYINPUT:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(92718);
		case CommandType.CT_VARIABLE_SET_RANDOMLY:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(93796);
		case CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(94266);
		case CommandType.CT_ITEM_LAYERED_REMOVE:
		case CommandType.CT_ITEM_LAYERED_WEAR:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(94876);
		default:
			return cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98224);
		}
	}

	public static void PopulateComboWithCommands(ComboBox cb, bool bFilter)
	{
		cb.Items.Clear();
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ACTION_ADD_CUSTOMCHOICE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98287)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98338)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98393)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYCHARDESC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98450)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_DISPLAYPORT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98511)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVECHAR, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98566)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVECHARINVTOPLAYER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98613)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_MOVETOOBJ, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98684)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SETPORT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98735)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETCHARACTION, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98794)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_CUSTOM_PROPERTY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98875)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(98936)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETCHARDESC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99023)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_GENDER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99076)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CHAR_SET_NAME, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99119)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_COMMENT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99174)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DEBUGTEXT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99201)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_JAVA_SET_RAGS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99222)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYTEXT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_EXPORTVARIABLE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99281)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_IMPORTVARIABLE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99312)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_PAUSEGAME, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99343)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYLAYEREDPICTURE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99364)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYPICTURE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99425)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_SET_BACKGROUND_MUSIC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99476)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_STOP_BACKGROUND_MUSIC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99531)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_PLAY_SOUNDEFFECT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99588)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_SET_MAIN_COMPASS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99637)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_SET_UD_COMPASS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99700)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_ADD, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99769)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_CLEAR, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99818)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_REMOVE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99873)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LAYEREDIMAGE_REPLACE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99928)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYITEMDESC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99985)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_LAYERED_REMOVE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100036)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_LAYERED_WEAR, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100077)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOCHAR, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100114)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOINV, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100161)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOOBJ, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100208)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEITEMTOROOM, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100257)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETOBJECTACTION, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100294)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_CUSTOM_PROPERTY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100365)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100416)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETITEMDESC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100493)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_NAME_OVERRIDE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100536)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETLOCKEDUNLOCKED, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100581)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETOPENCLOSED, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100650)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETITEMTOWORN, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100711)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_SET_VISIBILITY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100774)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100815)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_LOOP_BREAK, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100902)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_CANCELMOVE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100949)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYPLAYERDESC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(100988)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETLAYEREDPLAYERPORTRAIT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101043)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEINVENTORYTOCHAR, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101100)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEINVENTORYTOROOM, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101171)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVEPLAYER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101232)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVETOCHAR, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101273)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MOVETOOBJ, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101324)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101369)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101424)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERACTION, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101505)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERDESC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101580)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERGENDER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101627)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERNAME, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101664)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETPLAYERPORTRAIT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101697)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYROOMDESCRIPTION, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101750)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYROOMPICTURE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101801)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101844)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMACTION, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101897)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_SET_CUSTOM_PROPERTY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(101968)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102019)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMDESCRIPTION, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102096)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETEXIT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102139)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETEXITDESTINATION, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102206)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ROOM_SET_NAME_OVERRIDE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102259)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMLAYEREDPIC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102304)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETROOMPIC, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102355)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_Status_ItemVisibleInvisible, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102390)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_EXECUTETIMER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102455)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_RESETTIMER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102496)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_TIMER_SET_CUSTOM_PROPERTY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102533)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102586)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETTIMER, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102665)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_DISPLAYVARIABLE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102736)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETVARIABLE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102781)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ITEM_GETRANDOMGROUP, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102808)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_MM_GETRANDOMGROUP, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102895)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_JAVASCRIPT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(102984)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETVARIABLEBYINPUT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103037)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103092)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103163)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103222)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_RANDOMLY, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103307)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103368)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103457)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103536)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103619)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103698)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_VARIABLE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103779)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103834)));
		cb.Items.Add((object)new CommandConditionComboItem(CommandType.CT_ENDGAME, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103921)));
		if (!bFilter)
		{
			__ldtoken(Command.PopulateComboWithCommands(ComboBox, bool));
			return;
		}
		List<string> list = XMLUtilities.LoadXMLConfiguration(XMLUtilities.FilterType.FT_Command);
		for (int num = cb.Items.Count - 1; num >= 0; num--)
		{
			if (!(cb.Items[num] is CommandConditionComboItem commandConditionComboItem))
			{
				__ldtoken(Command.PopulateComboWithCommands(ComboBox, bool));
			}
			else if (!list.Contains(commandConditionComboItem.Name))
			{
				__ldtoken(Command.PopulateComboWithCommands(ComboBox, bool));
			}
			else
			{
				cb.Items.Remove((object)commandConditionComboItem);
			}
		}
	}

	public static string GetCommandName(CommandType ct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		string result = string.Empty;
		ComboBox val = new ComboBox();
		PopulateComboWithCommands(val, bFilter: false);
		IEnumerator enumerator = val.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Command.GetCommandName(CommandType));
				CommandConditionComboItem commandConditionComboItem = (CommandConditionComboItem)enumerator.Current;
				if (commandConditionComboItem.ctindex != ct)
				{
					__ldtoken(Command.GetCommandName(CommandType));
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
				__ldtoken(Command.GetCommandName(CommandType));
			}
			else
			{
				disposable.Dispose();
			}
		}
		return result;
	}

	public static CommandConditionComboItem GetCommandItem(ComboBox tempcb, CommandType ct)
	{
		CommandConditionComboItem commandConditionComboItem = null;
		IEnumerator enumerator = tempcb.Items.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Command.GetCommandItem(ComboBox, CommandType));
				CommandConditionComboItem commandConditionComboItem2 = (CommandConditionComboItem)enumerator.Current;
				if (commandConditionComboItem2.ctindex != ct)
				{
					__ldtoken(Command.GetCommandItem(ComboBox, CommandType));
					continue;
				}
				commandConditionComboItem = commandConditionComboItem2;
				break;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Command.GetCommandItem(ComboBox, CommandType));
			}
			else
			{
				disposable.Dispose();
			}
		}
		if (commandConditionComboItem != null)
		{
			__ldtoken(Command.GetCommandItem(ComboBox, CommandType));
		}
		else
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
		TreeNode val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165));
		TreeNode val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103946));
		val2.Tag = CommandType.CT_ACTION_ADD_CUSTOMCHOICE;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103981));
		val2.Tag = CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE;
		val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5692));
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104022));
		val2.Tag = CommandType.CT_DISPLAYCHARDESC;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104061));
		val2.Tag = CommandType.CT_MOVECHAR;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104086));
		val2.Tag = CommandType.CT_SETCHARACTION;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104086));
		val2.Tag = CommandType.CT_SETCHARDESC;
		val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104145));
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99174));
		val2.Tag = CommandType.CT_COMMENT;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104164));
		val2.Tag = CommandType.CT_DISPLAYLAYEREDPICTURE;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17691));
		val2.Tag = CommandType.CT_DISPLAYPICTURE;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(16462));
		val2.Tag = CommandType.CT_DISPLAYTEXT;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(99343));
		val2.Tag = CommandType.CT_PAUSEGAME;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(103921));
		val2.Tag = CommandType.CT_ENDGAME;
		val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(708));
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104022));
		val2.Tag = CommandType.CT_DISPLAYITEMDESC;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104211));
		val2.Tag = CommandType.CT_MOVEITEMTOCHAR;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104246));
		val2.Tag = CommandType.CT_MOVEITEMTOINV;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104281));
		val2.Tag = CommandType.CT_MOVEITEMTOOBJ;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104061));
		val2.Tag = CommandType.CT_MOVEITEMTOROOM;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104086));
		val2.Tag = CommandType.CT_SETOBJECTACTION;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104318));
		val2.Tag = CommandType.CT_SETITEMDESC;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104349));
		val2.Tag = CommandType.CT_SETLOCKEDUNLOCKED;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104406));
		val2.Tag = CommandType.CT_SETOPENCLOSED;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104455));
		val2.Tag = CommandType.CT_SETITEMTOWORN;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104506));
		val2.Tag = CommandType.CT_ITEM_SET_VISIBILITY;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104535));
		val2.Tag = CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER;
		val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50579));
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104608));
		val2.Tag = CommandType.CT_CANCELMOVE;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104022));
		val2.Tag = CommandType.CT_DISPLAYPLAYERDESC;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104631));
		val2.Tag = CommandType.CT_SETLAYEREDPLAYERPORTRAIT;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104672));
		val2.Tag = CommandType.CT_MOVEINVENTORYTOCHAR;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104727));
		val2.Tag = CommandType.CT_MOVEINVENTORYTOROOM;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104061));
		val2.Tag = CommandType.CT_MOVEPLAYER;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104086));
		val2.Tag = CommandType.CT_SETPLAYERACTION;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104318));
		val2.Tag = CommandType.CT_SETPLAYERDESC;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104772));
		val2.Tag = CommandType.CT_SETPLAYERGENDER;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104793));
		val2.Tag = CommandType.CT_SETPLAYERNAME;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104810));
		val2.Tag = CommandType.CT_SETPLAYERPORTRAIT;
		val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50568));
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104022));
		val2.Tag = CommandType.CT_DISPLAYROOMDESCRIPTION;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(17691));
		val2.Tag = CommandType.CT_DISPLAYROOMPICTURE;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104086));
		val2.Tag = CommandType.CT_SETROOMACTION;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104318));
		val2.Tag = CommandType.CT_SETROOMDESCRIPTION;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104835));
		val2.Tag = CommandType.CT_SETEXIT;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104890));
		val2.Tag = CommandType.CT_SETROOMLAYEREDPIC;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104929));
		val2.Tag = CommandType.CT_SETROOMPIC;
		val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50592));
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104952));
		val2.Tag = CommandType.CT_EXECUTETIMER;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(104979));
		val2.Tag = CommandType.CT_RESETTIMER;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105002));
		val2.Tag = CommandType.CT_SETTIMER;
		val = tv.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(576));
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105059));
		val2.Tag = CommandType.CT_DISPLAYVARIABLE;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105084));
		val2.Tag = CommandType.CT_SETVARIABLE;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105091));
		val2.Tag = CommandType.CT_SETVARIABLEBYINPUT;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105126));
		val2.Tag = CommandType.CT_VARIABLE_SET_RANDOMLY;
		val2 = val.Nodes.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105167));
		val2.Tag = CommandType.CT_VARIABLE_SET_WITH_VARIABLE;
	}

	public bool ContainsValue(string val)
	{
		if (CommandName.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0)
		{
			__ldtoken(Command.ContainsValue(string));
		}
		else if (CommandPart2.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0)
		{
			__ldtoken(Command.ContainsValue(string));
		}
		else if (CommandPart3.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0)
		{
			__ldtoken(Command.ContainsValue(string));
		}
		else if (CommandPart4.IndexOf(val, StringComparison.OrdinalIgnoreCase) >= 0)
		{
			__ldtoken(Command.ContainsValue(string));
		}
		else if (CommandText.IndexOf(val, StringComparison.OrdinalIgnoreCase) < 0)
		{
			__ldtoken(Command.ContainsValue(string));
			return false;
		}
		return true;
	}

	public void GetJSText(ref StringBuilder sb)
	{
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(105202));
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + cmdtype.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CommandName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CommandText.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597))
			.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CommandPart2.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CommandPart3.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CommandPart4.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597))
			.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		int num = 0;
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		IEnumerator enumerator = CustomChoices.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string text = (string)enumerator.Current;
				if (num <= 0)
				{
					__ldtoken(Command.GetJSText(ref StringBuilder));
				}
				else
				{
					sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + text.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
				num++;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Command.GetJSText(ref StringBuilder));
			}
			else
			{
				disposable.Dispose();
			}
		}
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		EnhInputData.cc738ece0e9315f0db703b90a443636ff(ref sb);
		sb.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
	}
}
