using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml;
using Microsoft.JScript;
using Microsoft.JScript.Vsa;
using Polenter.Serialization;
using Rags;

namespace WPFRagsLib;

public class SaveLoad
{
	private static VsaEngine vsaEngine = VsaEngine.CreateEngine();

	public static string DBName = string.Empty;

	public static WaitWindow tempwaitdlg = new WaitWindow();

	public static bool bDoneWithWaitDlg = false;

	public static SqlCeConnection TheCon = null;

	public static int PercentageComplete = 0;

	private static object Lockobj = new object();

	private DispatcherTimer checktimer = new DispatcherTimer();

	public static string Compress(string text)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		MemoryStream memoryStream = new MemoryStream();
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
		{
			gZipStream.Write(bytes, 0, bytes.Length);
		}
		memoryStream.Position = 0L;
		new MemoryStream();
		byte[] array = new byte[memoryStream.Length];
		memoryStream.Read(array, 0, array.Length);
		byte[] array2 = new byte[array.Length + 4];
		Buffer.BlockCopy(array, 0, array2, 4, array.Length);
		Buffer.BlockCopy(BitConverter.GetBytes(bytes.Length), 0, array2, 0, 4);
		return Convert.ToBase64String(array2);
	}

	public static string Decompress(string compressedText)
	{
		try
		{
			byte[] array = Convert.FromBase64String(compressedText);
			using MemoryStream memoryStream = new MemoryStream();
			int num = BitConverter.ToInt32(array, 0);
			memoryStream.Write(array, 4, array.Length - 4);
			byte[] array2 = new byte[num];
			memoryStream.Position = 0L;
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
			{
				gZipStream.Read(array2, 0, array2.Length);
			}
			return Encoding.UTF8.GetString(array2);
		}
		catch (Exception)
		{
			return compressedText;
		}
	}

	public static Rags.Action Action_CreateAction(string xmldata)
	{
		xmldata = Decompress(xmldata);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmldata);
		XmlNode CurNode = xmlDocument.FirstChild;
		return Action_SetXMLData(ref CurNode);
	}

	public static void Action_GetXMLData(ref StreamWriter CurDoc, Rags.Action tempact)
	{
		_ = tempact.name;
		CurDoc.WriteLine("<Action>");
		Game.AddXMLSection(ref CurDoc, "Name", tempact.name);
		Game.AddXMLSection(ref CurDoc, "OverrideName", tempact.overridename);
		Game.AddXMLSection(ref CurDoc, "actionparent", tempact.actionparent);
		Game.AddXMLSection(ref CurDoc, "Active", tempact.bActive.ToString());
		Game.AddXMLSection(ref CurDoc, "FailOnFirst", tempact.bConditionFailOnFirst.ToString());
		Game.AddXMLSection(ref CurDoc, "InputType", tempact.InputType.ToString());
		Game.AddXMLSection(ref CurDoc, "CustomChoiceTitle", tempact.CustomChoiceTitle);
		if (tempact.CustomChoices.Count > 0)
		{
			CurDoc.WriteLine("<CustomChoices>");
			foreach (string customChoice in tempact.CustomChoices)
			{
				CurDoc.WriteLine("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.WriteLine("</CustomChoice>");
			}
			CurDoc.WriteLine("</CustomChoices>");
		}
		CurDoc.WriteLine("<EnhancedInputData>");
		EnhancedInputData_GetXMLData(ref CurDoc, tempact.EnhInputData);
		CurDoc.WriteLine("</EnhancedInputData>");
		if (tempact.Conditions.Count > 0)
		{
			CurDoc.WriteLine("<Conditions>");
			foreach (Condition condition3 in tempact.Conditions)
			{
				Condition_GetXMLData(ref CurDoc, condition3);
			}
			CurDoc.WriteLine("</Conditions>");
		}
		if (tempact.PassCommands.Count > 0)
		{
			CurDoc.WriteLine("<PassCommands>");
			for (int i = 0; i < tempact.PassCommands.Count; i++)
			{
				Command command = tempact.PassCommands[i] as Command;
				Condition condition = tempact.PassCommands[i] as Condition;
				if (command != null)
				{
					Command_GetXMLData(ref CurDoc, command);
				}
				else if (condition != null)
				{
					Condition_GetXMLData(ref CurDoc, condition);
				}
			}
			CurDoc.WriteLine("</PassCommands>");
		}
		if (tempact.FailCommands.Count > 0)
		{
			CurDoc.WriteLine("<FailCommands>");
			for (int j = 0; j < tempact.FailCommands.Count; j++)
			{
				Command command2 = tempact.FailCommands[j] as Command;
				Condition condition2 = tempact.FailCommands[j] as Condition;
				if (command2 != null)
				{
					Command_GetXMLData(ref CurDoc, command2);
				}
				else if (condition2 != null)
				{
					Condition_GetXMLData(ref CurDoc, condition2);
				}
			}
			CurDoc.WriteLine("</FailCommands>");
		}
		CurDoc.WriteLine("</Action>");
	}

	public static void Action_GetXMLData(ref StringBuilder CurDoc, Rags.Action tempact)
	{
		_ = tempact.name;
		CurDoc.Append("<Action>");
		Game.AddXMLSection(ref CurDoc, "Name", tempact.name);
		Game.AddXMLSection(ref CurDoc, "OverrideName", tempact.overridename);
		Game.AddXMLSection(ref CurDoc, "actionparent", tempact.actionparent);
		Game.AddXMLSection(ref CurDoc, "Active", tempact.bActive.ToString());
		Game.AddXMLSection(ref CurDoc, "FailOnFirst", tempact.bConditionFailOnFirst.ToString());
		Game.AddXMLSection(ref CurDoc, "InputType", tempact.InputType.ToString());
		Game.AddXMLSection(ref CurDoc, "CustomChoiceTitle", tempact.CustomChoiceTitle);
		if (tempact.CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>");
			foreach (string customChoice in tempact.CustomChoices)
			{
				CurDoc.Append("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>");
			}
			CurDoc.Append("</CustomChoices>");
		}
		CurDoc.Append("<EnhancedInputData>");
		EnhancedInputData_GetXMLData(ref CurDoc, tempact.EnhInputData);
		CurDoc.Append("</EnhancedInputData>");
		if (tempact.Conditions.Count > 0)
		{
			CurDoc.Append("<Conditions>");
			foreach (Condition condition3 in tempact.Conditions)
			{
				Condition_GetXMLData(ref CurDoc, condition3);
			}
			CurDoc.Append("</Conditions>");
		}
		if (tempact.PassCommands.Count > 0)
		{
			CurDoc.Append("<PassCommands>");
			for (int i = 0; i < tempact.PassCommands.Count; i++)
			{
				Command command = tempact.PassCommands[i] as Command;
				Condition condition = tempact.PassCommands[i] as Condition;
				if (command != null)
				{
					Command_GetXMLData(ref CurDoc, command);
				}
				else if (condition != null)
				{
					Condition_GetXMLData(ref CurDoc, condition);
				}
			}
			CurDoc.Append("</PassCommands>");
		}
		if (tempact.FailCommands.Count > 0)
		{
			CurDoc.Append("<FailCommands>");
			for (int j = 0; j < tempact.FailCommands.Count; j++)
			{
				Command command2 = tempact.FailCommands[j] as Command;
				Condition condition2 = tempact.FailCommands[j] as Condition;
				if (command2 != null)
				{
					Command_GetXMLData(ref CurDoc, command2);
				}
				else if (condition2 != null)
				{
					Condition_GetXMLData(ref CurDoc, condition2);
				}
			}
			CurDoc.Append("</FailCommands>");
		}
		CurDoc.Append("</Action>");
	}

	public static void Action_GetAdvancedText(ref StringBuilder CurDoc, Rags.Action tempact)
	{
		_ = tempact.name;
		CurDoc.Append("<Action name=\"" + tempact.name + "\" active=\"" + tempact.bActive + "\"");
		if (tempact.overridename != string.Empty)
		{
			CurDoc.Append(" overridename=\"" + tempact.overridename + "\"");
		}
		if (tempact.actionparent != string.Empty)
		{
			CurDoc.Append(" actionparent=\"" + tempact.actionparent + "\"");
		}
		if (tempact.InputType != Rags.Action.ActionInputType.None)
		{
			CurDoc.Append(" InputType=\"" + tempact.InputType.ToString() + "\"");
			CurDoc.Append(" CustomChoiceTitle=\"" + tempact.CustomChoiceTitle + "\"");
		}
		CurDoc.Append(">\r\n");
		if (tempact.CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>\r\n");
			foreach (string customChoice in tempact.CustomChoices)
			{
				CurDoc.Append("<CustomChoice>\r\n");
				Game.AddAdvSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>\r\n");
			}
			CurDoc.Append("</CustomChoices>\r\n");
		}
		if (tempact.Conditions.Count > 0)
		{
			foreach (Condition condition3 in tempact.Conditions)
			{
				Condition_AddAdvSection(ref CurDoc, condition3);
			}
		}
		if (tempact.PassCommands.Count > 0)
		{
			CurDoc.Append("<Pass>\r\n");
			for (int i = 0; i < tempact.PassCommands.Count; i++)
			{
				Command command = tempact.PassCommands[i] as Command;
				Condition condition = tempact.PassCommands[i] as Condition;
				if (command != null)
				{
					Command_GetAdvancedText(ref CurDoc, command);
				}
				else if (condition != null)
				{
					Condition_GetAdvancedText(ref CurDoc, condition);
				}
			}
			CurDoc.Append("</Pass>\r\n");
		}
		if (tempact.FailCommands.Count > 0)
		{
			CurDoc.Append("<Fail>\r\n");
			for (int j = 0; j < tempact.FailCommands.Count; j++)
			{
				Command command2 = tempact.FailCommands[j] as Command;
				Condition condition2 = tempact.FailCommands[j] as Condition;
				if (command2 != null)
				{
					Command_GetAdvancedText(ref CurDoc, command2);
				}
				else if (condition2 != null)
				{
					Condition_GetAdvancedText(ref CurDoc, condition2);
				}
			}
			CurDoc.Append("</Fail>\r\n");
		}
		CurDoc.Append("</Action>\r\n");
	}

	private static Rags.Action Action_SetXMLData(ref XmlNode CurNode)
	{
		Rags.Action action = new Rags.Action();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			action.name = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "OverrideName");
		if (xMLSection != null)
		{
			action.overridename = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "actionparent");
		if (xMLSection != null)
		{
			action.actionparent = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomChoiceTitle");
		if (xMLSection != null)
		{
			action.CustomChoiceTitle = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Active");
		if (xMLSection != null)
		{
			action.bActive = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "FailOnFirst");
		if (xMLSection != null)
		{
			action.bConditionFailOnFirst = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "InputType");
		if (xMLSection != null)
		{
			action.InputType = (Rags.Action.ActionInputType)Enum.Parse(typeof(Rags.Action.ActionInputType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomChoices");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				string innerText = xmlNode.InnerText;
				action.CustomChoices.Add(innerText);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Conditions");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[j];
				Condition item = Condition_SetXMLData(ref CurNode2);
				action.Conditions.Add(item);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "PassCommands");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[k];
				Command command = null;
				Condition condition = new Condition();
				if (string.Compare(CurNode3.Name, "Condition", ignoreCase: true) == 0)
				{
					condition = Condition_SetXMLData(ref CurNode3);
					action.PassCommands.Add(condition);
				}
				else
				{
					command = Command_SetXMLData(ref CurNode3);
					action.PassCommands.Add(command);
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "FailCommands");
		if (xMLSection != null)
		{
			for (int l = 0; l < xMLSection.ChildNodes.Count; l++)
			{
				XmlNode CurNode4 = xMLSection.ChildNodes[l];
				Command command2 = null;
				Condition condition2 = new Condition();
				if (string.Compare(CurNode4.Name, "Condition", ignoreCase: true) == 0)
				{
					condition2 = Condition_SetXMLData(ref CurNode4);
					action.FailCommands.Add(condition2);
				}
				else
				{
					command2 = Command_SetXMLData(ref CurNode4);
					action.FailCommands.Add(command2);
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "EnhancedInputData");
		if (xMLSection != null)
		{
			action.EnhInputData = EnhancedInputData_SetXMLData(ref xMLSection);
		}
		return action;
	}

	public static Character Character_LoadCharacter(SqlCeDataReader dr)
	{
		string name = dr["Charname"].ToString();
		Character character = new Character(name);
		character.CharnameOverride = dr["CharnameOverride"].ToString();
		character.CharGender = (Player.Gender)dr["CharGender"];
		character.CurrentRoom = dr["CurrentRoom"].ToString();
		character.Description = dr["Description"].ToString();
		character.bAllowInventoryInteraction = (bool)dr["AllowInventoryInteraction"];
		character.bEnterFirstTime = (bool)dr["EnterFirstTime"];
		character.bLeaveFirstTime = (bool)dr["LeaveFirstTime"];
		character.CharPortrait = dr["CharPortrait"].ToString();
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from CharacterProperties where Charname=@Charname", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Charname", character.Charname);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			character.CustomProperties.Add(CustomProperty_LoadCustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from CharacterActions where Charname=@Charname", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Charname", character.Charname);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		character.Actions.Clear();
		while (sqlCeDataReader.Read())
		{
			character.Actions.Add(Action_CreateAction(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		return character;
	}

	public static void Character_UpdateDatabase(Character tempchar)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Characters values(\r\n                            @Charname,\r\n                            @CharnameOverride ,\r\n                            @CharGender ,\r\n                            @CurrentRoom ,\r\n                            @Description ,\r\n                            @AllowInventoryInteraction ,\r\n                            @EnterFirstTime ,\r\n                            @LeaveFirstTime,\r\n                            @CharPortrait)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Charname", tempchar.Charname);
		sqlCeCommand.Parameters.AddWithValue("@CharnameOverride", tempchar.CharnameOverride);
		sqlCeCommand.Parameters.AddWithValue("@CharGender", tempchar.CharGender);
		sqlCeCommand.Parameters.AddWithValue("@CurrentRoom", tempchar.CurrentRoom);
		sqlCeCommand.Parameters.AddWithValue("@Description", tempchar.Description);
		sqlCeCommand.Parameters.AddWithValue("@AllowInventoryInteraction", tempchar.bAllowInventoryInteraction);
		sqlCeCommand.Parameters.AddWithValue("@EnterFirstTime", tempchar.bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@LeaveFirstTime", tempchar.bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@CharPortrait", tempchar.CharPortrait);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Rags.Action action in tempchar.Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into CharacterActions (Charname,Data) values(@Charname,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Charname", tempchar.Charname);
			StringBuilder CurDoc = new StringBuilder();
			Action_GetXMLData(ref CurDoc, action);
			string value = Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in tempchar.CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into CharacterProperties (Charname,Name,Value) values(@Charname,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Charname", tempchar.Charname);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	public static void Character_GetXMLData(ref StreamWriter CurDoc, Character tempchar)
	{
		CurDoc.WriteLine(string.Format("<Character>", new object[0]));
		Game.AddXMLSection(ref CurDoc, "Name", tempchar.Charname);
		Game.AddXMLSection(ref CurDoc, "NameOverride", tempchar.CharnameOverride);
		Game.AddXMLSection(ref CurDoc, "CurrentRoom", tempchar.CurrentRoom.ToString());
		Game.AddXMLSection(ref CurDoc, "Description", tempchar.Description);
		Game.AddXMLSection(ref CurDoc, "CharPortrait", tempchar.CharPortrait);
		Game.AddXMLSection(ref CurDoc, "AllowInventoryInteraction", tempchar.bAllowInventoryInteraction.ToString());
		if (tempchar.Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Rags.Action action in tempchar.Actions)
			{
				Action_GetXMLData(ref CurDoc, action);
			}
			CurDoc.WriteLine("</Actions>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in tempchar.CustomProperties)
		{
			CustomProperty_GetXMLData(ref CurDoc, customProperty);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Character>");
	}

	public static Character Character_SetXMLData(ref XmlNode CurNode)
	{
		string name = string.Empty;
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			name = xMLSection.InnerText;
		}
		Character character = new Character(name);
		xMLSection = GetXMLSection(ref CurNode, "NameOverride");
		if (xMLSection != null)
		{
			character.CharnameOverride = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "CurrentRoom");
		if (xMLSection != null)
		{
			character.CurrentRoom = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Description");
		if (xMLSection != null)
		{
			character.Description = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "CharPortrait");
		if (xMLSection != null)
		{
			character.CharPortrait = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "AllowInventoryInteraction");
		if (xMLSection != null)
		{
			character.bAllowInventoryInteraction = Convert.ToBoolean(xMLSection.InnerText);
		}
		character.Actions.Clear();
		xMLSection = GetXMLSection(ref CurNode, "Actions");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Rags.Action action = Action_SetXMLData(ref CurNode2);
				foreach (Rags.Action action2 in character.Actions)
				{
					if (action2.name == action.name)
					{
						character.Actions.Remove(action2);
						break;
					}
				}
				character.Actions.Add(action);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				CustomProperty item = CustomProperty_SetXMLData(ref CurNode3);
				character.CustomProperties.Add(item);
			}
		}
		return character;
	}

	public static CustomProperty CustomProperty_LoadCustomProperty(SqlCeDataReader dr)
	{
		CustomProperty customProperty = new CustomProperty();
		customProperty.Name = dr["Name"].ToString();
		customProperty.Value = dr["Value"].ToString();
		return customProperty;
	}

	public static void CustomProperty_GetXMLData(ref StreamWriter CurDoc, CustomProperty tempcp)
	{
		CurDoc.WriteLine(string.Format("<CustomProperty>", new object[0]));
		Game.AddXMLSection(ref CurDoc, "Name", tempcp.Name);
		Game.AddXMLSection(ref CurDoc, "Value", tempcp.Value);
		CurDoc.WriteLine("</CustomProperty>");
	}

	public static void CustomProperty_GetXMLData(ref StringBuilder CurDoc, CustomProperty tempcp)
	{
		CurDoc.Append(string.Format("<CustomProperty>", new object[0]));
		Game.AddXMLSection(ref CurDoc, "Name", tempcp.Name);
		Game.AddXMLSection(ref CurDoc, "Value", tempcp.Value);
		CurDoc.Append("</CustomProperty>");
	}

	public static CustomProperty CustomProperty_SetXMLData(ref XmlNode CurNode)
	{
		CustomProperty customProperty = new CustomProperty();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			customProperty.Name = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Value");
		if (xMLSection != null)
		{
			customProperty.Value = xMLSection.InnerText;
		}
		return customProperty;
	}

	public static Game Game_LoadGame(string dbname)
	{
		Game tempgame = new Game();
		LoadQuickCommands(ref tempgame);
		tempgame.LayeredClothingZones.Add("Upper Body");
		tempgame.LayeredClothingZones.Add("Mid Body");
		tempgame.LayeredClothingZones.Add("Lower Body");
		DBName = dbname;
		tempgame.TheContent.Clear();
		tempgame.TheContent.Append(Game.InitialJavaScript);
		tempwaitdlg = new WaitWindow();
		bDoneWithWaitDlg = false;
		((Window)tempwaitdlg).Show();
		try
		{
			ThrdLoadData(tempgame);
			return tempgame;
		}
		finally
		{
			((Window)tempwaitdlg).Close();
		}
	}

	public static void LoadQuickCommands(ref Game tempgame)
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string path = Path.Combine(text, "WPFQuickCommands.bin");
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		if (!File.Exists(path))
		{
			RestoreDefaults(ref tempgame.QuickCommands);
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(path, FileMode.Create);
				sharpSerializer.Serialize(tempgame.QuickCommands, fileStream);
			}
			finally
			{
				fileStream.Flush();
				fileStream.Close();
				fileStream.Dispose();
			}
		}
		FileStream fileStream2 = null;
		try
		{
			fileStream2 = new FileStream(path, FileMode.Open);
			try
			{
				tempgame.QuickCommands = (List<QuickMenuItem>)sharpSerializer.Deserialize(fileStream2);
			}
			catch
			{
				tempgame.QuickCommands = null;
			}
		}
		finally
		{
			if (fileStream2 != null)
			{
				fileStream2.Close();
				fileStream2.Dispose();
			}
		}
	}

	public static void RestoreDefaults(ref List<QuickMenuItem> QuickCommands)
	{
		QuickCommands.Clear();
		QuickMenuItem quickMenuItem = new QuickMenuItem();
		quickMenuItem.Actions.Clear();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = true;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		Rags.Action action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		Command command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Char Data";
		command.cmdtype = Command.CommandType.CT_DISPLAYCHARDESC;
		command.CommandPart2 = "[Self]";
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Char Image";
		command.cmdtype = Command.CommandType.CT_CHAR_DISPLAYPORT;
		command.CommandPart2 = "[Self]";
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Item Data";
		command.cmdtype = Command.CommandType.CT_DISPLAYITEMDESC;
		command.CommandPart2 = "[Self]";
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = true;
		quickMenuItem.bRooms = false;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Player Description";
		command.cmdtype = Command.CommandType.CT_DISPLAYPLAYERDESC;
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Examine";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = false;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = true;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Examine";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Room Data";
		command.cmdtype = Command.CommandType.CT_DISPLAYROOMDESCRIPTION;
		command.CommandPart2 = "[Self]";
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Display Room Pic";
		command.cmdtype = Command.CommandType.CT_DISPLAYROOMPICTURE;
		command.CommandPart2 = "[Self]";
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bOpenable = true;
		quickMenuItem.Name = "Open/Close";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Open";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Open";
		command.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Open";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now open.";
		action.PassCommands.Add(command);
		Condition condition = new Condition("Check For Open");
		action.Conditions.Add(condition);
		condition.Checks.Add(new Check());
		Check check = condition.Checks[0];
		check.CondType = Condition.ConditionType.CT_Item_State_Check;
		check.ConditionStep2 = "[Self]";
		check.ConditionStep3 = "Closed";
		command = new Command();
		command.CommandName = "Display already open";
		command.CommandText = "[Self] is already open.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Close";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Closed";
		command.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Closed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now closed.";
		action.PassCommands.Add(command);
		condition = new Condition("Check For Closed");
		action.Conditions.Add(condition);
		condition.Checks.Add(new Check());
		check = condition.Checks[0];
		check.CondType = Condition.ConditionType.CT_Item_State_Check;
		check.ConditionStep2 = "[Self]";
		check.ConditionStep3 = "Open";
		command = new Command();
		command.CommandName = "Display already closed";
		command.CommandText = "[Self] is already closed.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bWearable = true;
		quickMenuItem.bCarryable = true;
		quickMenuItem.Name = "Wear/Remove";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Wear";
		action.bActive = true;
		condition = new Condition("Item must be in inventory");
		action.Conditions.Add(condition);
		condition.Checks.Add(new Check());
		Check check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Open";
		command = new Command();
		command.CommandName = "Display not held";
		command.CommandText = "You must get [Self] first.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Worn";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_WEAR;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Worn";
		condition = new Condition("Was the item worn?");
		action.PassCommands.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Worn";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Inactive";
		condition.PassCommands.Add(command);
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Remove";
		action.bActive = false;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Removed";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Removed";
		condition = new Condition("Item must be currently worn");
		action.Conditions.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Worn";
		command = new Command();
		command.CommandName = "Display not worn";
		command.CommandText = "You are not wearing [Self].";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		condition = new Condition("Was the item removed?");
		action.PassCommands.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Removed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Inactive";
		condition.PassCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.bLockable = true;
		quickMenuItem.Name = "Lock/Unlock";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Lock";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Locked";
		command.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Locked";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now locked.";
		action.PassCommands.Add(command);
		condition = new Condition("Check For Locked");
		action.Conditions.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Unlocked";
		command = new Command();
		command.CommandName = "Display already locked";
		command.CommandText = "[Self] is already locked.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Unlock";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Unlocked";
		command.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Unlocked";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "[Self] is now unlocked.";
		action.PassCommands.Add(command);
		condition = new Condition("Check For Unlocked");
		action.Conditions.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Locked";
		command = new Command();
		command.CommandName = "Display already unlocked";
		command.CommandText = "[Self] is already unlocked.";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		quickMenuItem.bCarryable = true;
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Take/Drop";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Take";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Pick Item Up";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = "[Self]";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You pick up [Self].";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Active";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Inactive";
		action.PassCommands.Add(command);
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Drop";
		action.bActive = false;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Drop Item";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "00000000-0000-0000-0000-000000000001";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You dropped [Self].";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Active";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Inactive";
		action.PassCommands.Add(command);
		quickMenuItem = new QuickMenuItem();
		quickMenuItem.bCarryable = true;
		quickMenuItem.bWearable = true;
		QuickCommands.Add(quickMenuItem);
		quickMenuItem.Name = "Take/Drop/Wear/Remove";
		quickMenuItem.bCharacters = false;
		quickMenuItem.bObjects = true;
		quickMenuItem.bPlayer = false;
		quickMenuItem.bRooms = false;
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Take";
		action.bActive = true;
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Pick Item Up";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = "[Self]";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You pick up [Self].";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Active";
		action.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Inactive";
		action.PassCommands.Add(command);
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Drop";
		action.bActive = false;
		condition = new Condition("Is Item Worn?");
		action.PassCommands.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Worn";
		command = new Command();
		condition.PassCommands.Add(command);
		command.CommandName = "Set Item To Removed";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = "[Self]";
		Condition condition2 = new Condition("Did we remove it successfully?");
		condition.PassCommands.Add(condition2);
		condition2.Checks.Add(new Check());
		check2 = condition2.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Removed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Active";
		condition2.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Inactive";
		condition2.PassCommands.Add(command);
		condition = new Condition("Is Item Removed?");
		action.PassCommands.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Removed";
		command = new Command();
		condition.PassCommands.Add(command);
		command.CommandName = "Drop Item";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "00000000-0000-0000-0000-000000000001";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Inactive";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		command.CommandName = "Display Result";
		command.CommandText = "You dropped [Self].";
		condition.PassCommands.Add(command);
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Wear";
		action.bActive = true;
		condition = new Condition("Is Item In Inventory?");
		action.PassCommands.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
		check2.ConditionStep2 = "[Self]";
		command = new Command();
		command.CommandName = "Display not held";
		command.CommandText = "You pick up [Self].";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		condition.FailCommands.Add(command);
		command.CommandName = "Pick Item Up";
		command.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
		command.CommandPart2 = "[Self]";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Drop";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Drop-Active";
		condition.FailCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Take";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Take-Inactive";
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Worn";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_WEAR;
		command.CommandPart2 = "[Self]";
		condition = new Condition("Did we wear the item?");
		action.PassCommands.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Worn";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Inactive";
		condition.PassCommands.Add(command);
		action = new Rags.Action();
		quickMenuItem.Actions.Add(action);
		action.name = "Remove";
		action.bActive = false;
		condition = new Condition("Item must be currently worn");
		action.Conditions.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Worn";
		command = new Command();
		command.CommandName = "Display not worn";
		command.CommandText = "You are not wearing [Self].";
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		condition.FailCommands.Add(command);
		command = new Command();
		action.PassCommands.Add(command);
		command.CommandName = "Set Item To Removed";
		command.cmdtype = Command.CommandType.CT_ITEM_LAYERED_REMOVE;
		command.CommandPart2 = "[Self]";
		condition = new Condition("Was the item removed?");
		action.PassCommands.Add(condition);
		condition.Checks.Add(new Check());
		check2 = condition.Checks[0];
		check2.CondType = Condition.ConditionType.CT_Item_State_Check;
		check2.ConditionStep2 = "[Self]";
		check2.ConditionStep3 = "Removed";
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Enable Wear";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Wear-Active";
		condition.PassCommands.Add(command);
		command = new Command();
		command.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
		command.CommandName = "Disable Remove";
		command.CommandPart2 = "[Self]";
		command.CommandPart3 = "Remove-Inactive";
		condition.PassCommands.Add(command);
	}

	public static SqlCeConnection GetDBConnection()
	{
		if (DBName == string.Empty)
		{
			return null;
		}
		EncDec.RagsZone("F1$asDDFHappy");
		string connectionString = "DataSource=" + DBName + ";Max Database Size=4024;Password=Ç°¥àòÅÅÇÉàññø";
		if (TheCon != null && DBName != TheCon.DataSource)
		{
			TheCon.Close();
		}
		if (TheCon == null || TheCon.State == ConnectionState.Closed)
		{
			try
			{
				TheCon = new SqlCeConnection(connectionString);
				TheCon.Open();
			}
			catch (Exception)
			{
				SqlCeEngine sqlCeEngine = new SqlCeEngine(connectionString);
				sqlCeEngine.Upgrade("DataSource=" + DBName + ";Password=Ç°¥àòÅÅÇÉàññø;encrypt database=TRUE");
				TheCon = new SqlCeConnection(connectionString);
				TheCon.Open();
			}
		}
		if (TheCon.State == ConnectionState.Broken)
		{
			TheCon.Close();
			TheCon.Open();
		}
		return TheCon;
	}

	public static void Game_CreateDatabase(string name)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (File.Exists(name))
		{
			if (TheCon != null)
			{
				TheCon.Close();
			}
			try
			{
				File.Delete(name);
			}
			catch
			{
				MessageBox.Show("Unable to overwrite the file.  Please choose a different name.");
				return;
			}
		}
		DBName = name;
		SqlCeEngine sqlCeEngine = new SqlCeEngine("DataSource=" + name + ";Password=Ç°¥àòÅÅÇÉàññø;encrypt database=TRUE");
		sqlCeEngine.CreateDatabase();
		sqlCeEngine.Dispose();
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("create table GameData(Title nvarchar(250),\r\n                            OpeningMessage ntext,\r\n                            HideMainPicDisplay bit,\r\n                            UseInlineImages bit,\r\n                            HidePortrait bit,\r\n                            AuthorName nvarchar(250),\r\n                            GameVersion nvarchar(50),\r\n                            GameInformation ntext,\r\n                            bgMusic nvarchar(250),\r\n                            RepeatbgMusic bit,\r\n                            PasswordProtected bit,\r\n                            GamePassword nvarchar(250),\r\n                            ObjectVersionNumber nvarchar(250),\r\n                            GameFont nvarchar(250))", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("create table Rooms(UniqueID nvarchar(250),\r\n                            Description ntext,\r\n                            SDesc nvarchar(250),\r\n                            Name nvarchar(250),\r\n                            RoomPic nvarchar(250),\r\n                            EnterFirstTime bit,\r\n                            LeaveFirstTime bit,\r\n                            [Group] nvarchar(250),\r\n                            LayeredRoomPic nvarchar(250))", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE RoomActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    RoomID nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE RoomProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    RoomID nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE RoomExits (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    RoomID nvarchar(250),\r\n                    Direction int,\r\n                    Active bit,\r\n                    DestinationRoom nvarchar(250),\r\n                    PortalObjectName nvarchar(250))", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("create table Items(UniqueID nvarchar(250),\r\n                            Name nvarchar(250),\r\n                            Description ntext,\r\n                            SDesc nvarchar(250),\r\n                            Preposition nvarchar(250),\r\n                            LocationName nvarchar(250),\r\n                            LocationType int,\r\n                            Carryable bit,\r\n                            Wearable bit,\r\n                            Openable bit,\r\n                            Lockable bit,\r\n                            Enterable bit,\r\n                            Readable bit,\r\n                            Container bit,\r\n                            Weight float,\r\n                            Worn bit,\r\n                            [Read] bit,\r\n                            Locked bit,\r\n                            [Open] bit,\r\n                            Entered bit,\r\n                            Visible bit,\r\n                            EnterFirstTime bit,\r\n                            LeaveFirstTime bit)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE ItemActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    ItemID nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE ItemProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    ItemID nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE ItemLayeredZoneLevels (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    ItemID nvarchar(250),\r\n                    Data nvarchar(250))", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("create table Media(Name nvarchar(250),\r\n                            BackgroundColor nvarchar(250),\r\n                            TextColor nvarchar(250),\r\n                            TextFont nvarchar(250),\r\n                            ImageName nvarchar(250),\r\n                            UseEnhancedGraphics bit,\r\n                            NewImage nvarchar(250),\r\n                            Data image)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE MediaLayeredImages (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    MediaName nvarchar(250),\r\n                    Data nvarchar(250))", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE Player (\r\n                    Name nvarchar(250),\r\n                    Description ntext,\r\n                    StartingRoom nvarchar(250),\r\n                    CurrentRoom nvarchar(250),\r\n                    PlayerLayeredImage nvarchar(250),\r\n                    PlayerGender int,\r\n                    PromptForName bit,\r\n                    PromptForGender bit,\r\n                    PlayerPortrait nvarchar(250),\r\n                    EnforceWeight bit,\r\n                    WeightLimit float\r\n                    )", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE PlayerActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Data ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE PlayerProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("create table Characters(Charname nvarchar(250),\r\n                            CharnameOverride nvarchar(250),\r\n                            CharGender int,\r\n                            CurrentRoom nvarchar(250),\r\n                            Description ntext,\r\n                            AllowInventoryInteraction bit,\r\n                            EnterFirstTime bit,\r\n                            LeaveFirstTime bit)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE CharacterActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Charname nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE CharacterProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Charname nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("create table Variables(VarName nvarchar(250),\r\n                            String ntext,\r\n                            NumType float,\r\n                            Min nvarchar(50),\r\n                            Max nvarchar(50),\r\n                            EnforceRestrictions bit,\r\n                            VarComment ntext,\r\n                            dtDateTime datetime,\r\n                            VarType int,\r\n                            VarArray ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE VariableProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    VarName nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("create table Timer(Name nvarchar(250),\r\n                            TType int,\r\n                            Active bit,\r\n                            Restart bit,\r\n                            TurnNumber int,\r\n                            Length int,\r\n                            LiveTimer bit,\r\n                            TimerSeconds int)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE TimerActions (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    Name nvarchar(250),\r\n                    Data ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("CREATE TABLE TimerProperties (\r\n                    ID int IDENTITY (1, 1) NOT NULL,\r\n                    TimerName nvarchar(250),\r\n                    Name nvarchar(250),\r\n                    Value ntext)", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		UpdateDatabaseModel();
	}

	private static void UpdateDatabaseModel()
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='MediaGroups'", dBConnection);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		bool flag = true;
		if (sqlCeDataReader.Read())
		{
			int @int = sqlCeDataReader.GetInt32(0);
			if (@int == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("Create table MediaGroups (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Parent nvarchar(255)\r\n                        )", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Items' and COLUMN_NAME='GroupName'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int2 = sqlCeDataReader.GetInt32(0);
			if (int2 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table Items Add Column \r\n                        GroupName nvarchar(255)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Items' and COLUMN_NAME='Important'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int3 = sqlCeDataReader.GetInt32(0);
			if (int3 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table Items Add Column \r\n                        Important bit not null default (0)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='RoomGroups'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int4 = sqlCeDataReader.GetInt32(0);
			if (int4 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table GameData Add Column \r\n                        RoomGroups ntext\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='ClothingZoneLevels'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int5 = sqlCeDataReader.GetInt32(0);
			if (int5 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table GameData Add Column \r\n                        ClothingZoneLevels ntext\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='NotificationsOff'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int6 = sqlCeDataReader.GetInt32(0);
			if (int6 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table GameData Add Column \r\n                        NotificationsOff bit not null default (0)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='GameData' and COLUMN_NAME='SortOrderRoom'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int7 = sqlCeDataReader.GetInt32(0);
			if (int7 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table GameData Add Column \r\n                        SortOrderRoom int not null default (0),\r\n                        SortOrderCharacters int not null default (0),\r\n                        SortOrderInventory int not null default (0)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Media' and COLUMN_NAME='GroupName'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int8 = sqlCeDataReader.GetInt32(0);
			if (int8 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table Media Add Column \r\n                        GroupName nvarchar(255)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='ItemGroups'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int9 = sqlCeDataReader.GetInt32(0);
			if (int9 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("Create table ItemGroups (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Parent nvarchar(255)\r\n                        )", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='VariableGroups'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int10 = sqlCeDataReader.GetInt32(0);
			if (int10 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("Create table VariableGroups (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Parent nvarchar(255)\r\n                        )", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Variables' and COLUMN_NAME='GroupName'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int11 = sqlCeDataReader.GetInt32(0);
			if (int11 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table Variables Add Column \r\n                        GroupName nvarchar(255)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.TABLES\r\n                    where TABLE_NAME='StatusBarItems'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int12 = sqlCeDataReader.GetInt32(0);
			if (int12 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("Create table StatusBarItems (\r\n                        ID int IDENTITY (1, 1) NOT NULL,\r\n                        Name nvarchar(255),\r\n                        Text ntext,\r\n                        Width int\r\n                        )", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS\r\n                    where TABLE_NAME='StatusBarItems' and COLUMN_NAME='Visible'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int13 = sqlCeDataReader.GetInt32(0);
			if (int13 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table StatusBarItems Add Column \r\n                        Visible bit not null default (1)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='Characters' and COLUMN_NAME='CharPortrait'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int14 = sqlCeDataReader.GetInt32(0);
			if (int14 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table Characters Add Column \r\n                        CharPortrait nvarchar(255)\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand = new SqlCeCommand("SELECT count(*) FROM INFORMATION_SCHEMA.COLUMNS where\r\n                    TABLE_NAME='MediaLayeredImages' and COLUMN_NAME='Order'", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		flag = true;
		if (sqlCeDataReader.Read())
		{
			int int15 = sqlCeDataReader.GetInt32(0);
			if (int15 == 1)
			{
				flag = false;
			}
		}
		if (flag)
		{
			sqlCeCommand = new SqlCeCommand("alter table MediaLayeredImages Add Column \r\n                        [Order] int\r\n                        ", dBConnection);
			sqlCeCommand.ExecuteNonQuery();
		}
	}

	public static void ThrdLoadData(object stateinfo)
	{
		Game game = stateinfo as Game;
		float num = 0f;
		PercentageComplete = 0;
		int num2 = 8;
		UpdateDatabaseModel();
		try
		{
			using SqlCeConnection connection = GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from GameData", connection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (sqlCeDataReader.Read())
			{
				game.Title = sqlCeDataReader["Title"].ToString();
				game.OpeningMessage = sqlCeDataReader["OpeningMessage"].ToString();
				game.bHideMainPicDisplay = (bool)sqlCeDataReader["HideMainPicDisplay"];
				game.bUseInlineImages = (bool)sqlCeDataReader["UseInlineImages"];
				game.bHidePortrait = (bool)sqlCeDataReader["HidePortrait"];
				game.AuthorName = sqlCeDataReader["AuthorName"].ToString();
				game.GameVersion = sqlCeDataReader["GameVersion"].ToString();
				game.GameInformation = sqlCeDataReader["GameInformation"].ToString();
				game.bgMusic = sqlCeDataReader["bgMusic"].ToString();
				game.bRepeatbgMusic = (bool)sqlCeDataReader["RepeatbgMusic"];
				game.bPasswordProtected = (bool)sqlCeDataReader["PasswordProtected"];
				game.GamePassword = sqlCeDataReader["GamePassword"].ToString();
				game.bTurnOffNotifications = (bool)sqlCeDataReader["NotificationsOff"];
				game.SortOrderRoomObjects = (Game.SortOrder)(int)sqlCeDataReader["SortOrderRoom"];
				game.SortOrderCharacters = (Game.SortOrder)(int)sqlCeDataReader["SortOrderCharacters"];
				game.SortOrderInventory = (Game.SortOrder)(int)sqlCeDataReader["SortOrderInventory"];
				Game.CurrentObjectVersionNumber = sqlCeDataReader["ObjectVersionNumber"].ToString();
				TypeDescriptor.GetConverter(typeof(FontFamily));
				string text = sqlCeDataReader["GameFont"].ToString();
				string text2 = sqlCeDataReader["RoomGroups"].ToString();
				string[] array = text2.Split(new string[1] { "," }, StringSplitOptions.None);
				game.RoomGroups.Clear();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != string.Empty)
					{
						game.RoomGroups.Add(array[i]);
					}
				}
				string text3 = sqlCeDataReader["ClothingZoneLevels"].ToString();
				string[] array2 = text3.Split(new string[1] { "," }, StringSplitOptions.None);
				game.LayeredClothingZones.Clear();
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] != string.Empty)
					{
						game.LayeredClothingZones.Add(array2[j]);
					}
				}
			}
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("Select * from StatusBarItems", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.StatusBarItems.Add(StatusBarItem_Load(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("Select * from Rooms", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.RoomList.Add(Room_Load(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("Select * from Items", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.ObjectList.Add(GameObject_Load(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("Select Name,BackgroundColor,TextColor,TextFont,\r\n                        ImageName, UseEnhancedGraphics,NewImage,GroupName from Media", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.PictureList.Add(GamePicture_Load(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("select * from Player", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			if (sqlCeDataReader.Read())
			{
				game.ThePlayer = Player_Load(sqlCeDataReader);
				try
				{
					game.ThePlayer.StartingRoom = game.GetRoomByID(new Guid(sqlCeDataReader["StartingRoom"].ToString()));
				}
				catch
				{
					game.ThePlayer.StartingRoom = null;
				}
				try
				{
					game.ThePlayer.CurrentRoom = game.GetRoomByID(new Guid(sqlCeDataReader["CurrentRoom"].ToString()));
				}
				catch
				{
					game.ThePlayer.CurrentRoom = null;
				}
			}
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("Select * from Characters", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.CharacterList.Add(Character_LoadCharacter(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("Select * from Variables", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.VariableList.Add(GameVariable_Load(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
			num++;
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
			((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			((DispatcherObject)tempwaitdlg).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
			{
			}));
			sqlCeCommand = new SqlCeCommand("Select * from Timer", connection);
			sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				game.TimerList.Add(Timer_Load(sqlCeDataReader));
			}
			sqlCeDataReader.Close();
			sqlCeDataReader.Dispose();
			sqlCeCommand.Dispose();
		}
		catch (Exception)
		{
			bDoneWithWaitDlg = true;
			((Window)tempwaitdlg).Close();
			return;
		}
		bDoneWithWaitDlg = true;
		((Window)tempwaitdlg).Close();
	}

	public static void ThrdUpdateDatabase(object stateinfo)
	{
		Game game = stateinfo as Game;
		float num = 0f;
		PercentageComplete = 0;
		int num2 = 8;
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from GameData", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("insert into GameData values(@Title,@OpeningMessage,\r\n                        @HideMainPicDisplay,@UseInlineImages,@HidePortrait,\r\n                        @AuthorName,@GameVersion,@GameInformation,@bgMusic,@RepeatbgMusic,@PasswordProtected,@Password,@ObjectVersionNumber,\r\n                          @GameFont,@RoomGroups,@ClothingZoneLevels,@NotificationsOff,@SortOrderRoom,\r\n                        @SortOrderCharacters, @SortOrderInventory)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Title", game.Title);
		sqlCeCommand.Parameters.AddWithValue("@OpeningMessage", game.OpeningMessage);
		sqlCeCommand.Parameters.AddWithValue("@HideMainPicDisplay", game.bHideMainPicDisplay);
		sqlCeCommand.Parameters.AddWithValue("@UseInlineImages", game.bUseInlineImages);
		sqlCeCommand.Parameters.AddWithValue("@HidePortrait", game.bHidePortrait);
		sqlCeCommand.Parameters.AddWithValue("@AuthorName", game.AuthorName);
		sqlCeCommand.Parameters.AddWithValue("@GameVersion", game.GameVersion);
		sqlCeCommand.Parameters.AddWithValue("@GameInformation", game.GameInformation);
		sqlCeCommand.Parameters.AddWithValue("@bgMusic", game.bgMusic);
		sqlCeCommand.Parameters.AddWithValue("@RepeatbgMusic", game.bRepeatbgMusic);
		sqlCeCommand.Parameters.AddWithValue("@PasswordProtected", game.bPasswordProtected);
		sqlCeCommand.Parameters.AddWithValue("@Password", game.GamePassword);
		if (Game.CurrentObjectVersionNumber == string.Empty)
		{
			Game.CurrentObjectVersionNumber = Game.ObjectVersionNumber;
		}
		sqlCeCommand.Parameters.AddWithValue("@ObjectVersionNumber", Game.CurrentObjectVersionNumber);
		TypeDescriptor.GetConverter(typeof(FontFamily));
		sqlCeCommand.Parameters.AddWithValue("@GameFont", "");
		string text = string.Empty;
		foreach (string roomGroup in game.RoomGroups)
		{
			if (text != string.Empty)
			{
				text += ",";
			}
			text += roomGroup;
		}
		sqlCeCommand.Parameters.AddWithValue("@RoomGroups", text);
		string text2 = string.Empty;
		foreach (string layeredClothingZone in game.LayeredClothingZones)
		{
			if (text2 != string.Empty)
			{
				text2 += ",";
			}
			text2 += layeredClothingZone;
		}
		sqlCeCommand.Parameters.AddWithValue("@ClothingZoneLevels", text2);
		sqlCeCommand.Parameters.AddWithValue("@NotificationsOff", game.bTurnOffNotifications);
		sqlCeCommand.Parameters.AddWithValue("@SortOrderRoom", game.SortOrderRoomObjects);
		sqlCeCommand.Parameters.AddWithValue("@SortOrderCharacters", game.SortOrderCharacters);
		sqlCeCommand.Parameters.AddWithValue("@SortOrderInventory", game.SortOrderInventory);
		sqlCeCommand.ExecuteNonQuery();
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		sqlCeCommand = new SqlCeCommand("delete from StatusBarItems", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (StatusBarItem statusBarItem in game.StatusBarItems)
		{
			StatusBarItem_UpdateDatabase(statusBarItem);
		}
		DateTime now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Rooms", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from RoomActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from RoomProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from RoomExits", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (Room room in game.RoomList)
		{
			Room_UpdateDatabase(room);
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Items", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from ItemActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from ItemProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from ItemLayeredZoneLevels", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (GameObject @object in game.ObjectList)
		{
			GameObject_UpdateDatabase(@object);
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		Player_UpdateDatabase(game.ThePlayer);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Characters", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from CharacterActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from CharacterProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (Character character in game.CharacterList)
		{
			Character_UpdateDatabase(character);
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Variables", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from VariableProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (GameVariable variable in game.VariableList)
		{
			GameVariable_UpdateDatabase(variable);
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		now = DateTime.Now;
		sqlCeCommand = new SqlCeCommand("delete from Timer", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from TimerActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand = new SqlCeCommand("delete from TimerProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		foreach (Timer timer in game.TimerList)
		{
			Timer_UpdateDatabase(timer);
		}
		new TimeSpan(DateTime.Now.Ticks - now.Ticks);
		num++;
		lock (Lockobj)
		{
			PercentageComplete = Convert.ToInt32((double)(num / (float)num2) * 100.0);
		}
		dBConnection.Close();
		dBConnection.Dispose();
		num++;
		bDoneWithWaitDlg = true;
	}

	public static void Game_UpdateDatabase(Game TheGame)
	{
		tempwaitdlg = new WaitWindow();
		try
		{
			bDoneWithWaitDlg = false;
			((Window)tempwaitdlg).Show();
			ThrdUpdateDatabase(TheGame);
		}
		finally
		{
			((Window)tempwaitdlg).Close();
		}
	}

	private void checktimer_Tick(object sender, EventArgs e)
	{
		lock (Lockobj)
		{
			if (PercentageComplete > 100)
			{
				PercentageComplete = 100;
			}
			Dispatcher.CurrentDispatcher.Invoke((System.Action)(() =>
			{
				((RangeBase)tempwaitdlg.sbProgress).Value = PercentageComplete;
			}));
			if (bDoneWithWaitDlg)
			{
				Dispatcher.CurrentDispatcher.Invoke((System.Action)(() =>
				{
					((RangeBase)tempwaitdlg.sbProgress).Value = 100.0;
				}));
				((Window)tempwaitdlg).Close();
				checktimer.Stop();
				bDoneWithWaitDlg = false;
			}
		}
	}

	public static void Game_GetXMLData(ref StreamWriter CurDoc, bool bRooms, bool bCharacters, bool bObjects, bool bVariables, bool bTimers, bool bStatusBarItems, bool bPlayer, bool bImages, Game tempgame)
	{
		CurDoc.WriteLine("<RAGSGAME>");
		AddXMLSection(ref CurDoc, "Title", tempgame.Title);
		AddXMLSection(ref CurDoc, "OpeningMessage", tempgame.OpeningMessage);
		AddXMLSection(ref CurDoc, "HideMainPicDisplay", tempgame.bHideMainPicDisplay.ToString());
		AddXMLSection(ref CurDoc, "UseInlineImages", tempgame.bUseInlineImages.ToString());
		AddXMLSection(ref CurDoc, "HidePortrait", tempgame.bHidePortrait.ToString());
		AddXMLSection(ref CurDoc, "AuthorName", tempgame.AuthorName.ToString());
		AddXMLSection(ref CurDoc, "GameVersion", tempgame.GameVersion.ToString());
		AddXMLSection(ref CurDoc, "GameInformation", tempgame.GameInformation.ToString());
		AddXMLSection(ref CurDoc, "bgMusic", tempgame.bgMusic.ToString());
		AddXMLSection(ref CurDoc, "bRepeatbgMusic", tempgame.bRepeatbgMusic.ToString());
		if (bRooms && tempgame.RoomList.Count > 0)
		{
			CurDoc.WriteLine("<Rooms>");
			foreach (Room room in tempgame.RoomList)
			{
				Room_GetXMLData(ref CurDoc, room);
			}
			CurDoc.WriteLine("</Rooms>");
		}
		if (bPlayer)
		{
			Player_GetXMLData(ref CurDoc, tempgame.ThePlayer);
		}
		if (bCharacters && tempgame.CharacterList.Count > 0)
		{
			CurDoc.WriteLine("<Characters>");
			foreach (Character character in tempgame.CharacterList)
			{
				Character_GetXMLData(ref CurDoc, character);
			}
			CurDoc.WriteLine("</Characters>");
		}
		if (bObjects && tempgame.ObjectList.Count > 0)
		{
			CurDoc.WriteLine("<Objects>");
			foreach (GameObject @object in tempgame.ObjectList)
			{
				GameObject_GetXMLData(ref CurDoc, @object);
			}
			CurDoc.WriteLine("</Objects>");
		}
		if (bVariables && tempgame.VariableList.Count > 0)
		{
			CurDoc.WriteLine("<Variables>");
			foreach (GameVariable variable in tempgame.VariableList)
			{
				GameVariable_GetXMLData(ref CurDoc, variable);
			}
			CurDoc.WriteLine("</Variables>");
		}
		if (bTimers && tempgame.TimerList.Count > 0)
		{
			CurDoc.WriteLine("<Timers>");
			foreach (Timer timer in tempgame.TimerList)
			{
				Timer_GetXMLData(ref CurDoc, timer);
			}
			CurDoc.WriteLine("</Timers>");
		}
		if (bStatusBarItems && tempgame.StatusBarItems.Count > 0)
		{
			CurDoc.WriteLine("<StatusBarItems>");
			foreach (StatusBarItem statusBarItem in tempgame.StatusBarItems)
			{
				StatusBarItem_GetXMLData(ref CurDoc, statusBarItem);
			}
			CurDoc.WriteLine("</StatusBarItems>");
		}
		if (bImages && tempgame.PictureList.Count > 0)
		{
			CurDoc.WriteLine("<Images>");
			foreach (GamePicture picture in tempgame.PictureList)
			{
				GamePicture_GetXMLData(ref CurDoc, picture);
			}
			CurDoc.WriteLine("</Images>");
		}
		if (tempgame.LayeredClothingZones.Count > 0)
		{
			CurDoc.WriteLine("<LayeredClothingZones>");
			foreach (string layeredClothingZone in tempgame.LayeredClothingZones)
			{
				Game.AddXMLSection(ref CurDoc, "LayeredClothingZone", layeredClothingZone);
			}
			CurDoc.WriteLine("</LayeredClothingZones>");
		}
		if (tempgame.RoomGroups.Count > 0)
		{
			CurDoc.WriteLine("<RoomGroups>");
			foreach (string roomGroup in tempgame.RoomGroups)
			{
				Game.AddXMLSection(ref CurDoc, "RoomGroup", roomGroup);
			}
			CurDoc.WriteLine("</RoomGroups>");
		}
		CurDoc.WriteLine("</RAGSGAME>");
	}

	public static void AddXMLSection(ref StreamWriter CurDoc, string titlename, string value)
	{
		CurDoc.WriteLine("<" + titlename + ">");
		CurDoc.WriteLine($"<![CDATA[{value}]]>");
		CurDoc.WriteLine("</" + titlename + ">");
	}

	public static void AddXMLSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append("<" + titlename + ">");
		CurDoc.Append($"<![CDATA[{value}]]>");
		CurDoc.Append("</" + titlename + ">");
	}

	public static void AddAdvSection(ref StringBuilder CurDoc, string titlename, string value)
	{
		CurDoc.Append("<" + titlename + ">");
		CurDoc.Append(value);
		CurDoc.Append("</" + titlename + ">\r\n");
	}

	public static XmlNode GetXMLSection(ref XmlNode node, string titlename)
	{
		XmlNode result = null;
		foreach (XmlNode childNode in node.ChildNodes)
		{
			if (childNode.Name == titlename)
			{
				result = childNode;
				break;
			}
		}
		return result;
	}

	public static Game Game_SetXMLData(ref XmlNode CurNode)
	{
		Game game = new Game();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Title");
		if (xMLSection != null)
		{
			game.Title = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "OpeningMessage");
		if (xMLSection != null)
		{
			game.OpeningMessage = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "HideMainPicDisplay");
		if (xMLSection != null)
		{
			game.bHideMainPicDisplay = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "UseInlineImages");
		if (xMLSection != null)
		{
			game.bUseInlineImages = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "HidePortrait");
		if (xMLSection != null)
		{
			game.bHidePortrait = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "AuthorName");
		if (xMLSection != null)
		{
			game.AuthorName = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "GameVersion");
		if (xMLSection != null)
		{
			game.GameVersion = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "GameInformation");
		if (xMLSection != null)
		{
			game.GameInformation = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "bgMusic");
		if (xMLSection != null)
		{
			game.bgMusic = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "bRepeatbgMusic");
		if (xMLSection != null)
		{
			game.bRepeatbgMusic = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Rooms");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Room room = Room_SetXMLData(ref CurNode2, game);
				foreach (Room room3 in game.RoomList)
				{
					if (room3.UniqueID == room.UniqueID)
					{
						game.RoomList.Remove(room3);
						break;
					}
				}
				game.RoomList.Add(room);
				if (game.ThePlayer.StartingRoom != null && room.UniqueID == game.ThePlayer.StartingRoom.UniqueID)
				{
					game.ThePlayer.StartingRoom = room;
				}
			}
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Room room2 = Room_SetXMLData(ref CurNode3, game);
				foreach (Room room4 in game.RoomList)
				{
					if (room4.UniqueID == room2.UniqueID)
					{
						game.RoomList.Remove(room4);
						break;
					}
				}
				game.RoomList.Add(room2);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Player");
		if (xMLSection != null)
		{
			game.ThePlayer = Player_SetXMLData(ref xMLSection, game);
		}
		xMLSection = GetXMLSection(ref CurNode, "Characters");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode4 = xMLSection.ChildNodes[k];
				Character character = Character_SetXMLData(ref CurNode4);
				foreach (Character character2 in game.CharacterList)
				{
					if (character2.Charname == character.Charname)
					{
						game.CharacterList.Remove(character2);
						break;
					}
				}
				game.CharacterList.Add(character);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Objects");
		if (xMLSection != null)
		{
			for (int l = 0; l < xMLSection.ChildNodes.Count; l++)
			{
				XmlNode CurNode5 = xMLSection.ChildNodes[l];
				GameObject gameObject = GameObject_SetXMLData(ref CurNode5);
				foreach (GameObject @object in game.ObjectList)
				{
					if (@object.name == gameObject.name)
					{
						game.ObjectList.Remove(@object);
						break;
					}
				}
				game.ObjectList.Add(gameObject);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Variables");
		if (xMLSection != null)
		{
			for (int m = 0; m < xMLSection.ChildNodes.Count; m++)
			{
				XmlNode CurNode6 = xMLSection.ChildNodes[m];
				GameVariable gameVariable = GameVariable_SetXMLData(ref CurNode6);
				foreach (GameVariable variable in game.VariableList)
				{
					if (variable.varname == gameVariable.varname)
					{
						game.VariableList.Remove(variable);
						break;
					}
				}
				game.VariableList.Add(gameVariable);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Timers");
		if (xMLSection != null)
		{
			for (int n = 0; n < xMLSection.ChildNodes.Count; n++)
			{
				XmlNode CurNode7 = xMLSection.ChildNodes[n];
				Timer timer = Timer_SetXMLData(ref CurNode7);
				foreach (Timer timer2 in game.TimerList)
				{
					if (timer2.Name == timer.Name)
					{
						game.TimerList.Remove(timer2);
						break;
					}
				}
				game.TimerList.Add(timer);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "StatusBarItems");
		if (xMLSection != null)
		{
			for (int num = 0; num < xMLSection.ChildNodes.Count; num++)
			{
				XmlNode CurNode8 = xMLSection.ChildNodes[num];
				StatusBarItem statusBarItem = StatusBarItem_SetXMLData(ref CurNode8);
				foreach (StatusBarItem statusBarItem2 in game.StatusBarItems)
				{
					if (statusBarItem2.Name == statusBarItem.Name)
					{
						game.StatusBarItems.Remove(statusBarItem2);
						break;
					}
				}
				game.StatusBarItems.Add(statusBarItem);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Images");
		if (xMLSection != null)
		{
			for (int num2 = 0; num2 < xMLSection.ChildNodes.Count; num2++)
			{
				XmlNode CurNode9 = xMLSection.ChildNodes[num2];
				GamePicture gamePicture = GamePicture_SetXMLData(ref CurNode9);
				foreach (GamePicture picture in game.PictureList)
				{
					if (picture.TheName == gamePicture.TheName)
					{
						game.PictureList.Remove(picture);
						break;
					}
				}
				game.PictureList.Add(gamePicture);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "LayeredClothingZones");
		if (xMLSection != null)
		{
			game.LayeredClothingZones.Clear();
			for (int num3 = 0; num3 < xMLSection.ChildNodes.Count; num3++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[num3];
				if (xmlNode != null)
				{
					game.LayeredClothingZones.Add(xmlNode.InnerText);
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "RoomGroups");
		if (xMLSection != null)
		{
			game.RoomGroups.Clear();
			for (int num4 = 0; num4 < xMLSection.ChildNodes.Count; num4++)
			{
				XmlNode xmlNode2 = xMLSection.ChildNodes[num4];
				if (xmlNode2 != null)
				{
					game.RoomGroups.Add(xmlNode2.InnerText);
				}
			}
		}
		return game;
	}

	public static GamePicture GetGamePictureByName(string picname, ref Game tempgame)
	{
		for (int i = 0; i < tempgame.PictureList.Count; i++)
		{
			if (string.Compare(picname, tempgame.PictureList[i].TheName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return tempgame.PictureList[i];
			}
		}
		return null;
	}

	public static object GetPictureByName(string picname, ref Game tempgame)
	{
		string text = Path.Combine(Path.GetTempPath(), picname);
		if (!File.Exists(text))
		{
			GamePicture gamePictureByName = GetGamePictureByName(picname, ref tempgame);
			if (gamePictureByName == null)
			{
				return string.Empty;
			}
			SqlCeConnection dBConnection = GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Name", gamePictureByName.TheName);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			byte[] bytes = null;
			if (sqlCeDataReader.Read())
			{
				bytes = (byte[])sqlCeDataReader["Data"];
			}
			File.WriteAllBytes(text, bytes);
		}
		return text;
	}

	public static void CorrectCommandAndConditions(ref Game TheGame)
	{
		WaitWindow waitWindow = new WaitWindow();
		((ContentControl)waitWindow.lblTitle).Content = "Updating HTML Codes...";
		((RangeBase)waitWindow.sbProgress).Value = 0.0;
		TheGame.OpeningMessage = Game.UpdateStringToHTML(TheGame.OpeningMessage);
		((Window)waitWindow).Show();
		for (int i = 0; i < TheGame.RoomList.Count; i++)
		{
			Room room = TheGame.RoomList[i];
			for (int j = 0; j < room.Actions.Count; j++)
			{
				Rags.Action tempact = room.Actions[j];
				Game.CorrectAction(ref tempact);
			}
		}
		ProgressBar sbProgress = waitWindow.sbProgress;
		((RangeBase)sbProgress).Value = ((RangeBase)sbProgress).Value + 20.0;
		((DispatcherObject)waitWindow).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
		{
		}));
		for (int num = 0; num < TheGame.ObjectList.Count; num++)
		{
			GameObject gameObject = TheGame.ObjectList[num];
			for (int num2 = 0; num2 < gameObject.Actions.Count; num2++)
			{
				Rags.Action tempact2 = gameObject.Actions[num2];
				Game.CorrectAction(ref tempact2);
			}
		}
		ProgressBar sbProgress2 = waitWindow.sbProgress;
		((RangeBase)sbProgress2).Value = ((RangeBase)sbProgress2).Value + 20.0;
		((DispatcherObject)waitWindow).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
		{
		}));
		for (int num3 = 0; num3 < TheGame.ThePlayer.Actions.Count; num3++)
		{
			Rags.Action tempact3 = TheGame.ThePlayer.Actions[num3];
			Game.CorrectAction(ref tempact3);
		}
		ProgressBar sbProgress3 = waitWindow.sbProgress;
		((RangeBase)sbProgress3).Value = ((RangeBase)sbProgress3).Value + 20.0;
		((DispatcherObject)waitWindow).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
		{
		}));
		for (int num4 = 0; num4 < TheGame.CharacterList.Count; num4++)
		{
			Character character = TheGame.CharacterList[num4];
			for (int num5 = 0; num5 < character.Actions.Count; num5++)
			{
				Rags.Action tempact4 = character.Actions[num5];
				Game.CorrectAction(ref tempact4);
			}
		}
		for (int num6 = 0; num6 < TheGame.VariableList.Count; num6++)
		{
			GameVariable gameVariable = TheGame.VariableList[num6];
			gameVariable.CorrectVariableData();
		}
		ProgressBar sbProgress4 = waitWindow.sbProgress;
		((RangeBase)sbProgress4).Value = ((RangeBase)sbProgress4).Value + 20.0;
		((DispatcherObject)waitWindow).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
		{
		}));
		for (int num7 = 0; num7 < TheGame.TimerList.Count; num7++)
		{
			Timer timer = TheGame.TimerList[num7];
			for (int num8 = 0; num8 < timer.Actions.Count; num8++)
			{
				Rags.Action tempact5 = timer.Actions[num8];
				Game.CorrectAction(ref tempact5);
			}
		}
		ProgressBar sbProgress5 = waitWindow.sbProgress;
		((RangeBase)sbProgress5).Value = ((RangeBase)sbProgress5).Value + 20.0;
		((DispatcherObject)waitWindow).Dispatcher.Invoke((DispatcherPriority)7, (Delegate)(System.Action)(() =>
		{
		}));
		((Window)waitWindow).Close();
	}

	public static void ValidateText(string text, ref Game TheGame)
	{
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		string text2 = string.Empty;
		text = TheGame.PerformTextReplacements(text, null);
		bool flag = false;
		text.LastIndexOf("[v", StringComparison.OrdinalIgnoreCase);
		for (int num = text.LastIndexOf("[v:", StringComparison.OrdinalIgnoreCase); num >= 0; num = text.LastIndexOf("[v:", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Remove(num, 3);
			int num2 = text.IndexOf("]", num, StringComparison.OrdinalIgnoreCase);
			int num3 = text.IndexOf("(", num, StringComparison.OrdinalIgnoreCase);
			if (num3 < num2 && num3 != -1)
			{
				int num4 = text.IndexOf(")", num, StringComparison.OrdinalIgnoreCase);
				if (num4 != -1)
				{
					string text3 = text.Substring(num, num3 - num).Trim();
					if (num4 - (num3 + 1) < 0)
					{
						text2 += "Missing a closing ] in the variable reference.";
						flag = true;
						break;
					}
					string text4 = text.Substring(num3 + 1, num4 - (num3 + 1)).Trim();
					int num5 = 0;
					try
					{
						num5 = Convert.ToInt32(text4);
					}
					catch
					{
						text2 = text2 + "An array index is not valid. Array index evaluated to " + text4 + ".";
						flag = true;
						num5 = -1;
					}
					int num6 = text.IndexOf(")", num4 + 1, StringComparison.OrdinalIgnoreCase);
					int num7 = -1;
					if (num6 != -1)
					{
						string text5 = string.Empty;
						try
						{
							text5 = text.Substring(num4 + 2, num6 - (num4 + 2));
							num7 = Convert.ToInt32(text5);
						}
						catch
						{
							text2 = text2 + "An array index is not valid. Array index in the multi dimensional array evaluated to " + text5 + ".";
							flag = true;
							num5 = -1;
						}
					}
					if (num5 > -1)
					{
						string text6 = string.Empty;
						if (text3.IndexOf(":") > -1)
						{
							text6 = text3.Substring(text3.IndexOf(":") + 1);
							text3 = text3.Substring(0, text3.IndexOf(":"));
						}
						GameVariable variableByName = TheGame.GetVariableByName(text3);
						if (variableByName == null)
						{
							text2 = text2 + "The variable named " + text3 + " could not be located.";
							flag = true;
						}
						if (variableByName != null)
						{
							int num8 = 0;
							num8 = ((num6 <= -1) ? (num4 - num + 2) : (num6 - num + 2));
							text = text.Remove(num, num8);
							if (num5 >= variableByName.VarArray.Count)
							{
								string text7 = text2;
								text2 = text7 + "The array index of " + num5 + " exceeded the limits of the array " + variableByName.varname + ".";
								flag = true;
							}
							if (num5 < variableByName.VarArray.Count)
							{
								string value = string.Empty;
								switch (variableByName.vartype)
								{
								case GameVariable.VarType.VT_NUMBERARRAY:
								case GameVariable.VarType.VT_STRINGARRAY:
									if (num7 > -1)
									{
										try
										{
											value = ((List<object>)variableByName.VarArray[num5])[num7].ToString();
										}
										catch
										{
											value = "<invalid variable reference>";
										}
									}
									else
									{
										value = variableByName.VarArray[num5].ToString();
									}
									break;
								case GameVariable.VarType.VT_DATETIMEARRAY:
									if (num7 > -1)
									{
										string value2 = ((List<object>)variableByName.VarArray[num5])[num7].ToString();
										DateTime dateTime = Convert.ToDateTime(value2);
										value = ((!(text6 != string.Empty)) ? dateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") : dateTime.ToString(text6));
									}
									else
									{
										value = ((!(text6 != string.Empty)) ? ((DateTime)variableByName.VarArray[num5]).ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") : ((DateTime)variableByName.VarArray[num5]).ToString(text6));
									}
									break;
								}
								text = text.Insert(num, value);
							}
						}
					}
				}
			}
			else if (num2 > -1)
			{
				string text8 = text.Substring(num, num2 - num).Trim();
				text = text.Remove(num, num2 - num + 1);
				string text9 = string.Empty;
				if (text8.IndexOf(":") > -1)
				{
					text9 = text8.Substring(text8.IndexOf(":") + 1);
					text8 = text8.Substring(0, text8.IndexOf(":"));
				}
				GameVariable variableByName2 = TheGame.GetVariableByName(text8);
				if (variableByName2 == null)
				{
					text2 = text2 + "The variable named " + text8 + " could not be located.";
					flag = true;
				}
				if (variableByName2 != null)
				{
					string value3 = string.Empty;
					switch (variableByName2.vartype)
					{
					case GameVariable.VarType.VT_NUMBER:
						value3 = variableByName2.dNumType.ToString();
						break;
					case GameVariable.VarType.VT_STRING:
						value3 = variableByName2.sString;
						break;
					case GameVariable.VarType.VT_DATETIME:
						value3 = ((!(text9 != string.Empty)) ? variableByName2.dtDateTime.ToString("dddd, MMMM, dd yyyy hh:mm:ss tt") : variableByName2.dtDateTime.ToString(text9));
						break;
					}
					text = text.Insert(num, value3);
				}
			}
		}
		if (flag)
		{
			MessageBox.Show("Formatting error detected: " + text2, "Formatting Error", (MessageBoxButton)0);
		}
	}

	public static void Command_GetAdvancedText(ref StringBuilder CurDoc, Command tempcmd)
	{
		CurDoc.Append("<Command>\r\n");
		Game.AddAdvSection(ref CurDoc, "CmdType", tempcmd.cmdtype.ToString());
		if (tempcmd.CommandText != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "CommandText", tempcmd.CommandText);
		}
		if (tempcmd.CommandPart2 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Part2", tempcmd.CommandPart2);
		}
		if (tempcmd.CommandPart3 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Part3", tempcmd.CommandPart3);
		}
		if (tempcmd.CommandPart4 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Part4", tempcmd.CommandPart4);
		}
		if (tempcmd.CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>\r\n");
			foreach (string customChoice in tempcmd.CustomChoices)
			{
				CurDoc.Append("<CustomChoice>\r\n");
				Game.AddAdvSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>\r\n");
			}
			CurDoc.Append("</CustomChoices>\r\n");
		}
		CurDoc.Append("</Command>\r\n");
	}

	public static void Command_GetXMLData(ref StreamWriter CurDoc, Command tempcmd)
	{
		CurDoc.WriteLine("<Command>");
		Game.AddXMLSection(ref CurDoc, "CmdType", tempcmd.cmdtype.ToString());
		Game.AddXMLSection(ref CurDoc, "CommandText", tempcmd.CommandText);
		Game.AddXMLSection(ref CurDoc, "Part2", tempcmd.CommandPart2);
		Game.AddXMLSection(ref CurDoc, "Part3", tempcmd.CommandPart3);
		Game.AddXMLSection(ref CurDoc, "Part4", tempcmd.CommandPart4);
		if (tempcmd.CustomChoices.Count > 0)
		{
			CurDoc.WriteLine("<CustomChoices>");
			foreach (string customChoice in tempcmd.CustomChoices)
			{
				CurDoc.WriteLine("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.WriteLine("</CustomChoice>");
			}
			CurDoc.WriteLine("</CustomChoices>");
		}
		CurDoc.WriteLine("<EnhancedInputData>");
		EnhancedInputData_GetXMLData(ref CurDoc, tempcmd.EnhInputData);
		CurDoc.WriteLine("</EnhancedInputData>");
		CurDoc.WriteLine("</Command>");
	}

	public static void Command_GetXMLData(ref StringBuilder CurDoc, Command tempcmd)
	{
		CurDoc.Append("<Command>");
		Game.AddXMLSection(ref CurDoc, "CmdType", tempcmd.cmdtype.ToString());
		Game.AddXMLSection(ref CurDoc, "CommandText", tempcmd.CommandText);
		Game.AddXMLSection(ref CurDoc, "Part2", tempcmd.CommandPart2);
		Game.AddXMLSection(ref CurDoc, "Part3", tempcmd.CommandPart3);
		Game.AddXMLSection(ref CurDoc, "Part4", tempcmd.CommandPart4);
		if (tempcmd.CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>");
			foreach (string customChoice in tempcmd.CustomChoices)
			{
				CurDoc.Append("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>");
			}
			CurDoc.Append("</CustomChoices>");
		}
		CurDoc.Append("<EnhancedInputData>");
		EnhancedInputData_GetXMLData(ref CurDoc, tempcmd.EnhInputData);
		CurDoc.Append("</EnhancedInputData>");
		CurDoc.Append("</Command>");
	}

	public static Command Command_SetXMLData(ref XmlNode CurNode)
	{
		Command command = new Command();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "CmdType");
		if (xMLSection != null)
		{
			command.cmdtype = (Command.CommandType)Enum.Parse(typeof(Command.CommandType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "CommandText");
		if (xMLSection != null)
		{
			command.CommandText = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Part2");
		if (xMLSection != null)
		{
			command.CommandPart2 = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Part3");
		if (xMLSection != null)
		{
			command.CommandPart3 = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Part4");
		if (xMLSection != null)
		{
			command.CommandPart4 = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomChoices");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				string innerText = xmlNode.InnerText;
				command.CustomChoices.Add(innerText);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "EnhancedInputData");
		if (xMLSection != null)
		{
			command.EnhInputData = EnhancedInputData_SetXMLData(ref xMLSection);
		}
		return command;
	}

	public static void PopulateComboWithCommands(ItemCollection cb, bool bFilter)
	{
		cb.Clear();
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ACTION_ADD_CUSTOMCHOICE, "Action: Add Custom Choice"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE, "Action: Clear Custom Choice"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE, "Action: Remove Custom Choice"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYCHARDESC, "Character: Display Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CHAR_DISPLAYPORT, "Character: Display Portrait"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVECHAR, "Character: Move To Room"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVECHARINVTOPLAYER, "Character: Move Inventory To Player"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CHAR_MOVETOOBJ, "Character: Move To Object"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CHAR_SETPORT, "Character: Set Portrait Media"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETCHARACTION, "Character: Set Action To Active/Inactive"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY, "Character: Set Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS, "Character: Set Custom Property (Javascript)"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETCHARDESC, "Character: Set Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CHAR_SET_GENDER, "Character: Set Gender"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CHAR_SET_NAME, "Character: Set Display Name"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_COMMENT, "Add A Comment"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DEBUGTEXT, "Debug Text"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_JAVA_SET_RAGS, "Set RAGS data with Javascript"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYTEXT, "Display Text"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_EXPORTVARIABLE, "Export Variable"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_IMPORTVARIABLE, "Import Variable"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_PAUSEGAME, "Pause Game"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYLAYEREDPICTURE, "Media: Display Layered Picture"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYPICTURE, "Media: Display Multimedia"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC, "Media: Set Background Music"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC, "Media: Stop Background Music"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MM_PLAY_SOUNDEFFECT, "Media: Play Sound Effect"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MM_SET_MAIN_COMPASS, "Media: Set Main Compass Picture"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MM_SET_UD_COMPASS, "Media: Set Up/Down Compass Picture"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_LAYEREDIMAGE_ADD, "Image: Add Layered Image"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_LAYEREDIMAGE_CLEAR, "Image: Clear Layered Images"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_LAYEREDIMAGE_REMOVE, "Image: Remove Layered Image"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_LAYEREDIMAGE_REPLACE, "Image: Replace Layered Image"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYITEMDESC, "Item: Display Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEM_LAYERED_REMOVE, "Item: Layered Remove"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEM_LAYERED_WEAR, "Item: Layered Wear"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVEITEMTOCHAR, "Item: Move To Character"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVEITEMTOINV, "Item: Move To Inventory"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVEITEMTOOBJ, "Item: Move Inside Object"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVEITEMTOROOM, "Item: Move To Room"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETOBJECTACTION, "Item: Set Action To Active/Inactive"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY, "Item: Set Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS, "Item: Set Custom Property (Javascript)"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETITEMDESC, "Item: Set Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEM_SET_NAME_OVERRIDE, "Item: Set Display Name"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETLOCKEDUNLOCKED, "Item: Set State To Locked/Unlocked"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETOPENCLOSED, "Item: Set State To Open/Closed"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETITEMTOWORN, "Item: Set State To Worn/Removed"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEM_SET_VISIBILITY, "Item: Set Visibility"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER, "Items: Move All From Container To Container"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_LOOP_BREAK, "Loop: Break Out Of Loop"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_CANCELMOVE, "Player: Cancel Move"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYPLAYERDESC, "Player: Display Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT, "Player: Set Layered Portrait"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVEINVENTORYTOCHAR, "Player: Move Inventory To Character"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVEINVENTORYTOROOM, "Player: Move Inventory To Room"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVEPLAYER, "Player: Move To Room"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVETOCHAR, "Player: Move To Character"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MOVETOOBJ, "Player: Move To Object"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY, "Player: Set Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS, "Player: Set Custom Property (Javascript)"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETPLAYERACTION, "Player: Set Action To Active/Inactive"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETPLAYERDESC, "Player: Set Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETPLAYERGENDER, "Player: Set Gender"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETPLAYERNAME, "Player: Set Name"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETPLAYERPORTRAIT, "Player: Set Portrait Media"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYROOMDESCRIPTION, "Room: Display Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYROOMPICTURE, "Room: Display Picture"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER, "Room: Move Items To Player"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETROOMACTION, "Room: Set Action To Active/Inactive"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY, "Room: Set Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS, "Room: Set Custom Property (Javascript)"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETROOMDESCRIPTION, "Room: Set Description"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETEXIT, "Room: Set Exit To Active/Inactive"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETEXITDESTINATION, "Room: Set Exit Destination"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ROOM_SET_NAME_OVERRIDE, "Room: Set Display Name"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETROOMLAYEREDPIC, "Room: Set Layered Picture"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETROOMPIC, "Room: Set Picture"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_Execute_SQL, "SQL: Execute Command"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_Status_ItemVisibleInvisible, "StatusBar: Set Visible/Invisible"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_EXECUTETIMER, "Timer: Execute Timer"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_RESETTIMER, "Timer: Reset Timer"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY, "Timer: Set Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS, "Timer: Set Custom Property (Javascript)"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETTIMER, "Timer: Set Timer To Active/Inactive"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_DISPLAYVARIABLE, "Variable: Display Data"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETVARIABLE, "Variable: Set"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ITEM_GETRANDOMGROUP, "Variable: Set With Random Item Group Member"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_MM_GETRANDOMGROUP, "Variable: Set With Random Media Group Member"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT, "Variable: Set (Javascript)"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETVARIABLEBYINPUT, "Variable: Set By User Input"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT, "Variable: Set Numeric By User Input"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY, "Variable: Set Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS, "Variable: Set Custom Property (Javascript)"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_RANDOMLY, "Variable: Set Numeric Randomly"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE, "Variable: Set With Character Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE, "Variable: Set With Item Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE, "Variable: Set With Player Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE, "Variable: Set With Room Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE, "Variable: Set With Timer Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE, "Variable: Set With Variable"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE, "Variable: Set With Variable Custom Property"));
		cb.Add((object)new CommandConditionComboItem(Command.CommandType.CT_ENDGAME, "End The Game"));
	}

	public static void Check_GetXMLData(ref StreamWriter CurDoc, Check tempcheck)
	{
		CurDoc.WriteLine("<Check>");
		Game.AddXMLSection(ref CurDoc, "CondType", tempcheck.CondType.ToString());
		Game.AddXMLSection(ref CurDoc, "CkType", tempcheck.CkType.ToString());
		Game.AddXMLSection(ref CurDoc, "Step2", tempcheck.ConditionStep2);
		Game.AddXMLSection(ref CurDoc, "Step3", tempcheck.ConditionStep3);
		Game.AddXMLSection(ref CurDoc, "Step4", tempcheck.ConditionStep4);
		CurDoc.WriteLine("</Check>");
	}

	public static void Check_GetXMLData(ref StringBuilder CurDoc, Check tempcheck)
	{
		CurDoc.Append("<Check>");
		Game.AddXMLSection(ref CurDoc, "CondType", tempcheck.CondType.ToString());
		Game.AddXMLSection(ref CurDoc, "CkType", tempcheck.CkType.ToString());
		Game.AddXMLSection(ref CurDoc, "Step2", tempcheck.ConditionStep2);
		Game.AddXMLSection(ref CurDoc, "Step3", tempcheck.ConditionStep3);
		Game.AddXMLSection(ref CurDoc, "Step4", tempcheck.ConditionStep4);
		CurDoc.Append("</Check>");
	}

	public static void Check_GetAdvancedText(ref StringBuilder CurDoc, Check tempcheck)
	{
		CurDoc.Append("<Check>\r\n");
		Game.AddAdvSection(ref CurDoc, "CondType", tempcheck.CondType.ToString());
		if (tempcheck.CkType != CheckType.CT_Uninitialized)
		{
			Game.AddAdvSection(ref CurDoc, "CkType", tempcheck.CkType.ToString());
		}
		if (tempcheck.ConditionStep2 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Step2", tempcheck.ConditionStep2);
		}
		if (tempcheck.ConditionStep3 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Step3", tempcheck.ConditionStep3);
		}
		if (tempcheck.ConditionStep4 != string.Empty)
		{
			Game.AddAdvSection(ref CurDoc, "Step4", tempcheck.ConditionStep4);
		}
		CurDoc.Append("</Check>\r\n");
	}

	public static Check Check_SetXMLData(ref XmlNode CurNode)
	{
		Check check = new Check();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "CondType");
		if (xMLSection != null)
		{
			check.CondType = (Condition.ConditionType)Enum.Parse(typeof(Condition.ConditionType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "CkType");
		if (xMLSection != null)
		{
			check.CkType = (CheckType)Enum.Parse(typeof(CheckType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "Step2");
		if (xMLSection != null)
		{
			check.ConditionStep2 = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Step3");
		if (xMLSection != null)
		{
			check.ConditionStep3 = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Step4");
		if (xMLSection != null)
		{
			check.ConditionStep4 = xMLSection.InnerText;
		}
		return check;
	}

	public static void Condition_GetXMLData(ref StreamWriter CurDoc, Condition tempcond)
	{
		CurDoc.WriteLine("<Condition>");
		Game.AddXMLSection(ref CurDoc, "Name", tempcond.conditionname);
		if (tempcond.Checks.Count > 0)
		{
			CurDoc.WriteLine("<Checks>");
			foreach (Check check in tempcond.Checks)
			{
				Check_GetXMLData(ref CurDoc, check);
			}
			CurDoc.WriteLine("</Checks>");
		}
		if (tempcond.PassCommands.Count > 0)
		{
			CurDoc.WriteLine("<PassCommands>");
			for (int i = 0; i < tempcond.PassCommands.Count; i++)
			{
				Command command = tempcond.PassCommands[i] as Command;
				Condition condition = tempcond.PassCommands[i] as Condition;
				if (command != null)
				{
					Command_GetXMLData(ref CurDoc, command);
				}
				else if (condition != null)
				{
					Condition_GetXMLData(ref CurDoc, condition);
				}
			}
			CurDoc.WriteLine("</PassCommands>");
		}
		if (tempcond.FailCommands.Count > 0)
		{
			CurDoc.WriteLine("<FailCommands>");
			for (int j = 0; j < tempcond.FailCommands.Count; j++)
			{
				Command command2 = tempcond.FailCommands[j] as Command;
				Condition condition2 = tempcond.FailCommands[j] as Condition;
				if (command2 != null)
				{
					Command_GetXMLData(ref CurDoc, command2);
				}
				else if (condition2 != null)
				{
					Condition_GetXMLData(ref CurDoc, condition2);
				}
			}
			CurDoc.WriteLine("</FailCommands>");
		}
		CurDoc.WriteLine("</Condition>");
	}

	public static void Condition_GetXMLData(ref StringBuilder CurDoc, Condition tempcond)
	{
		CurDoc.Append("<Condition>");
		Game.AddXMLSection(ref CurDoc, "Name", tempcond.conditionname);
		if (tempcond.Checks.Count > 0)
		{
			CurDoc.Append("<Checks>");
			foreach (Check check in tempcond.Checks)
			{
				Check_GetXMLData(ref CurDoc, check);
			}
			CurDoc.Append("</Checks>");
		}
		if (tempcond.PassCommands.Count > 0)
		{
			CurDoc.Append("<PassCommands>");
			for (int i = 0; i < tempcond.PassCommands.Count; i++)
			{
				Command command = tempcond.PassCommands[i] as Command;
				Condition condition = tempcond.PassCommands[i] as Condition;
				if (command != null)
				{
					Command_GetXMLData(ref CurDoc, command);
				}
				else if (condition != null)
				{
					Condition_GetXMLData(ref CurDoc, condition);
				}
			}
			CurDoc.Append("</PassCommands>");
		}
		if (tempcond.FailCommands.Count > 0)
		{
			CurDoc.Append("<FailCommands>");
			for (int j = 0; j < tempcond.FailCommands.Count; j++)
			{
				Command command2 = tempcond.FailCommands[j] as Command;
				Condition condition2 = tempcond.FailCommands[j] as Condition;
				if (command2 != null)
				{
					Command_GetXMLData(ref CurDoc, command2);
				}
				else if (condition2 != null)
				{
					Condition_GetXMLData(ref CurDoc, condition2);
				}
			}
			CurDoc.Append("</FailCommands>");
		}
		CurDoc.Append("</Condition>");
	}

	public static void Condition_AddAdvSection(ref StringBuilder CurDoc, Condition tempcond)
	{
		CurDoc.Append("<Condition name=\"" + tempcond.conditionname + "\">\r\n");
		if (tempcond.Checks.Count > 0)
		{
			CurDoc.Append("<Checks>\r\n");
			foreach (Check check in tempcond.Checks)
			{
				Check_GetAdvancedText(ref CurDoc, check);
			}
			CurDoc.Append("</Checks>\r\n");
		}
		if (tempcond.PassCommands.Count > 0)
		{
			CurDoc.Append("<Pass>\r\n");
			for (int i = 0; i < tempcond.PassCommands.Count; i++)
			{
				Command command = tempcond.PassCommands[i] as Command;
				Condition condition = tempcond.PassCommands[i] as Condition;
				if (command != null)
				{
					Command_GetAdvancedText(ref CurDoc, command);
				}
				else if (condition != null)
				{
					Condition_GetAdvancedText(ref CurDoc, condition);
				}
			}
			CurDoc.Append("</Pass>\r\n");
		}
		if (tempcond.FailCommands.Count > 0)
		{
			CurDoc.Append("<Fail>\r\n");
			for (int j = 0; j < tempcond.FailCommands.Count; j++)
			{
				Command command2 = tempcond.FailCommands[j] as Command;
				Condition condition2 = tempcond.FailCommands[j] as Condition;
				if (command2 != null)
				{
					Command_GetAdvancedText(ref CurDoc, command2);
				}
				else if (condition2 != null)
				{
					Condition_GetAdvancedText(ref CurDoc, condition2);
				}
			}
			CurDoc.Append("</Fail>\r\n");
		}
		CurDoc.Append("</Condition>\r\n");
	}

	public static void Condition_GetAdvancedText(ref StringBuilder CurDoc, Condition tempcond)
	{
		Condition_AddAdvSection(ref CurDoc, tempcond);
	}

	public static Condition Condition_SetXMLData(ref XmlNode CurNode)
	{
		Condition condition = new Condition();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			condition.conditionname = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Checks");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Check item = Check_SetXMLData(ref CurNode2);
				condition.Checks.Add(item);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "PassCommands");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Command command = new Command();
				Condition condition2 = new Condition();
				if (string.Compare(CurNode3.Name, "Condition", ignoreCase: true) == 0)
				{
					condition2 = Condition_SetXMLData(ref CurNode3);
					condition.PassCommands.Add(condition2);
				}
				else
				{
					command = Command_SetXMLData(ref CurNode3);
					condition.PassCommands.Add(command);
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "FailCommands");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode4 = xMLSection.ChildNodes[k];
				Command command2 = new Command();
				Condition condition3 = new Condition();
				if (string.Compare(CurNode4.Name, "Condition", ignoreCase: true) == 0)
				{
					condition3 = Condition_SetXMLData(ref CurNode4);
					condition.FailCommands.Add(condition3);
				}
				else
				{
					command2 = Command_SetXMLData(ref CurNode4);
					condition.FailCommands.Add(command2);
				}
			}
		}
		return condition;
	}

	public static Exit Exit_Load(SqlCeDataReader dr)
	{
		Exit exit = new Exit();
		exit.Direction = (Exit.Directions)dr["Direction"];
		exit.bActive = (bool)dr["Active"];
		exit.DestinationRoom = dr["DestinationRoom"].ToString();
		exit.PortalObjectName = dr["PortalObjectName"].ToString();
		return exit;
	}

	public static void Exit_GetXMLData(ref StreamWriter CurDoc, Exit tempexit)
	{
		if (tempexit.DestinationRoom != null)
		{
			CurDoc.WriteLine(string.Format("<Exit>", new object[0]));
			Game.AddXMLSection(ref CurDoc, "Direction", tempexit.Direction.ToString());
			Game.AddXMLSection(ref CurDoc, "Active", tempexit.bActive.ToString());
			if (tempexit.DestinationRoom != null)
			{
				Game.AddXMLSection(ref CurDoc, "DestinationRoom", tempexit.DestinationRoom);
			}
			Game.AddXMLSection(ref CurDoc, "PortalObjectName", tempexit.PortalObjectName);
			CurDoc.WriteLine("</Exit>");
		}
	}

	public static void Exit_GetAdvancedText(ref StringBuilder CurDoc, Exit tempexit)
	{
		if (tempexit.DestinationRoom != null)
		{
			CurDoc.Append(string.Format("<Exit>\r\n", new object[0]));
			Game.AddAdvSection(ref CurDoc, "Direction", tempexit.Direction.ToString());
			Game.AddAdvSection(ref CurDoc, "Active", tempexit.bActive.ToString());
			if (tempexit.DestinationRoom != null)
			{
				Game.AddAdvSection(ref CurDoc, "DestinationRoom", tempexit.DestinationRoom);
			}
			Game.AddAdvSection(ref CurDoc, "PortalObjectName", tempexit.PortalObjectName);
			CurDoc.Append("</Exit>\r\n");
		}
	}

	public static Exit Exit_SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		Exit exit = new Exit();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Direction");
		if (xMLSection != null)
		{
			exit.Direction = (Exit.Directions)Enum.Parse(typeof(Exit.Directions), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "Active");
		if (xMLSection != null)
		{
			exit.bActive = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "PortalObjectName");
		if (xMLSection != null)
		{
			exit.PortalObjectName = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "DestinationRoom");
		if (xMLSection != null)
		{
			exit.DestinationRoom = xMLSection.InnerText;
		}
		return exit;
	}

	public static GameObject GameObject_Load(SqlCeDataReader dr)
	{
		GameObject gameObject = new GameObject();
		gameObject.UniqueIdentifier = new Guid(dr["UniqueID"].ToString());
		gameObject.name = dr["Name"].ToString();
		gameObject.description = dr["Description"].ToString();
		gameObject.sdesc = dr["SDesc"].ToString();
		gameObject.preposition = dr["Preposition"].ToString();
		gameObject.locationname = dr["LocationName"].ToString();
		gameObject.locationtype = (GameObject.LocationType)dr["LocationType"];
		gameObject.bCarryable = (bool)dr["Carryable"];
		gameObject.bWearable = (bool)dr["Wearable"];
		gameObject.bLockable = (bool)dr["Lockable"];
		gameObject.bEnterable = (bool)dr["Enterable"];
		gameObject.bReadable = (bool)dr["Readable"];
		gameObject.bContainer = (bool)dr["Container"];
		gameObject.dWeight = (double)dr["Weight"];
		gameObject.bWorn = (bool)dr["Worn"];
		gameObject.bRead = (bool)dr["Read"];
		gameObject.bLocked = (bool)dr["Locked"];
		gameObject.bOpen = (bool)dr["Open"];
		gameObject.bOpenable = (bool)dr["Openable"];
		gameObject.bEntered = (bool)dr["Entered"];
		gameObject.bVisible = (bool)dr["Visible"];
		gameObject.bEnterFirstTime = (bool)dr["EnterFirstTime"];
		gameObject.bLeaveFirstTime = (bool)dr["LeaveFirstTime"];
		gameObject.GroupName = dr["GroupName"].ToString();
		gameObject.bImportant = (bool)dr["Important"];
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from ItemLayeredZoneLevels where ItemID=@ItemID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@ItemID", gameObject.UniqueIdentifier.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			gameObject.LayeredZoneLevels.Add(sqlCeDataReader["Data"].ToString());
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from ItemProperties where ItemID=@ItemID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@ItemID", gameObject.UniqueIdentifier.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			gameObject.CustomProperties.Add(CustomProperty_LoadCustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from ItemActions where ItemID=@ItemID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@ItemID", gameObject.UniqueIdentifier.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		gameObject.Actions.Clear();
		while (sqlCeDataReader.Read())
		{
			gameObject.Actions.Add(Action_CreateAction(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		return gameObject;
	}

	public static void GameObject_UpdateGroupName(GameObject tempobj)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("Select GroupName from Items\r\n                    where UniqueID=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", tempobj.UniqueIdentifier.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			tempobj.GroupName = sqlCeDataReader["GroupName"].ToString();
		}
	}

	public static void GameObject_UpdateDatabase(GameObject tempobj)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Items values(@UniqueID,@Name,\r\n                        @Description,@SDesc,@Preposition,@LocationName,@LocationType,\r\n                        @Carryable,@Wearable,@Openable,@Lockable,@Enterable,@Readable,@Container,\r\n                        @Weight,@Worn,@Read,@Locked,@Open,@Entered,@Visible,\r\n                        @EnterFirstTime,@LeaveFirstTime,@GroupName,@Important)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@UniqueID", tempobj.UniqueIdentifier.ToString());
		sqlCeCommand.Parameters.AddWithValue("@Name", tempobj.name);
		sqlCeCommand.Parameters.AddWithValue("@Description", tempobj.description);
		sqlCeCommand.Parameters.AddWithValue("@SDesc", tempobj.sdesc);
		sqlCeCommand.Parameters.AddWithValue("@Preposition", tempobj.preposition);
		sqlCeCommand.Parameters.AddWithValue("@LocationName", tempobj.locationname);
		sqlCeCommand.Parameters.AddWithValue("@LocationType", tempobj.locationtype);
		sqlCeCommand.Parameters.AddWithValue("@Carryable", tempobj.bCarryable);
		sqlCeCommand.Parameters.AddWithValue("@Wearable", tempobj.bWearable);
		sqlCeCommand.Parameters.AddWithValue("@Openable", tempobj.bOpenable);
		sqlCeCommand.Parameters.AddWithValue("@Lockable", tempobj.bLockable);
		sqlCeCommand.Parameters.AddWithValue("@Enterable", tempobj.bEnterable);
		sqlCeCommand.Parameters.AddWithValue("@Readable", tempobj.bReadable);
		sqlCeCommand.Parameters.AddWithValue("@Container", tempobj.bContainer);
		sqlCeCommand.Parameters.AddWithValue("@Weight", tempobj.dWeight);
		sqlCeCommand.Parameters.AddWithValue("@Worn", tempobj.bWorn);
		sqlCeCommand.Parameters.AddWithValue("@Read", tempobj.bRead);
		sqlCeCommand.Parameters.AddWithValue("@Locked", tempobj.bLocked);
		sqlCeCommand.Parameters.AddWithValue("@Open", tempobj.bOpen);
		sqlCeCommand.Parameters.AddWithValue("@Entered", tempobj.bEntered);
		sqlCeCommand.Parameters.AddWithValue("@Visible", tempobj.bVisible);
		sqlCeCommand.Parameters.AddWithValue("@EnterFirstTime", tempobj.bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@LeaveFirstTime", tempobj.bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@GroupName", tempobj.GroupName);
		sqlCeCommand.Parameters.AddWithValue("@Important", tempobj.bImportant);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Rags.Action action in tempobj.Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into ItemActions (ItemID,Data) values(@ItemID,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@ItemID", tempobj.UniqueIdentifier.ToString());
			StringBuilder CurDoc = new StringBuilder();
			Action_GetXMLData(ref CurDoc, action);
			string value = Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in tempobj.CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into ItemProperties (ItemID,Name,Value) values(@ItemID,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@ItemID", tempobj.UniqueIdentifier.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (string layeredZoneLevel in tempobj.LayeredZoneLevels)
		{
			sqlCeCommand = new SqlCeCommand("insert into ItemLayeredZoneLevels (ItemID,Data) \r\n                        values(@ItemID,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@ItemID", tempobj.UniqueIdentifier.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", layeredZoneLevel);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	public static void GameObject_GetXMLData(ref StreamWriter CurDoc, GameObject tempobj)
	{
		CurDoc.WriteLine("<Object>");
		Game.AddXMLSection(ref CurDoc, "Name", tempobj.name);
		Game.AddXMLSection(ref CurDoc, "UniqueIdentifier", tempobj.UniqueIdentifier.ToString());
		Game.AddXMLSection(ref CurDoc, "LocationType", tempobj.locationtype.ToString());
		Game.AddXMLSection(ref CurDoc, "LocationName", tempobj.locationname);
		Game.AddXMLSection(ref CurDoc, "Description", tempobj.description);
		Game.AddXMLSection(ref CurDoc, "SDesc", tempobj.sdesc);
		Game.AddXMLSection(ref CurDoc, "Preposition", tempobj.preposition);
		Game.AddXMLSection(ref CurDoc, "Carryable", tempobj.bCarryable.ToString());
		Game.AddXMLSection(ref CurDoc, "Wearable", tempobj.bWearable.ToString());
		Game.AddXMLSection(ref CurDoc, "Openable", tempobj.bOpenable.ToString());
		Game.AddXMLSection(ref CurDoc, "Lockable", tempobj.bLockable.ToString());
		Game.AddXMLSection(ref CurDoc, "Enterable", tempobj.bEnterable.ToString());
		Game.AddXMLSection(ref CurDoc, "Readable", tempobj.bReadable.ToString());
		Game.AddXMLSection(ref CurDoc, "Container", tempobj.bContainer.ToString());
		Game.AddXMLSection(ref CurDoc, "Weight", tempobj.dWeight.ToString());
		Game.AddXMLSection(ref CurDoc, "Worn", tempobj.bWorn.ToString());
		Game.AddXMLSection(ref CurDoc, "Read", tempobj.bRead.ToString());
		Game.AddXMLSection(ref CurDoc, "Locked", tempobj.bLocked.ToString());
		Game.AddXMLSection(ref CurDoc, "Open", tempobj.bOpen.ToString());
		Game.AddXMLSection(ref CurDoc, "Visible", tempobj.bVisible.ToString());
		if (tempobj.Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Rags.Action action in tempobj.Actions)
			{
				Action_GetXMLData(ref CurDoc, action);
			}
			CurDoc.WriteLine("</Actions>");
		}
		if (tempobj.LayeredZoneLevels.Count > 0)
		{
			CurDoc.WriteLine("<LayeredZoneLevels>");
			foreach (string layeredZoneLevel in tempobj.LayeredZoneLevels)
			{
				Game.AddXMLSection(ref CurDoc, "LayeredZoneLevel", layeredZoneLevel);
			}
			CurDoc.WriteLine("</LayeredZoneLevels>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in tempobj.CustomProperties)
		{
			CustomProperty_GetXMLData(ref CurDoc, customProperty);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Object>");
	}

	public static GameObject GameObject_SetXMLData(ref XmlNode CurNode)
	{
		GameObject gameObject = new GameObject();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			gameObject.name = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "UniqueIdentifier");
		if (xMLSection != null)
		{
			gameObject.UniqueIdentifier = new Guid(xMLSection.InnerText);
		}
		else
		{
			gameObject.UniqueIdentifier = Guid.NewGuid();
		}
		xMLSection = GetXMLSection(ref CurNode, "LocationType");
		if (xMLSection != null)
		{
			gameObject.locationtype = (GameObject.LocationType)Enum.Parse(typeof(GameObject.LocationType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "LocationName");
		if (xMLSection != null)
		{
			gameObject.locationname = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Description");
		if (xMLSection != null)
		{
			gameObject.description = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "SDesc");
		if (xMLSection != null)
		{
			gameObject.sdesc = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Preposition");
		if (xMLSection != null)
		{
			gameObject.preposition = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Carryable");
		if (xMLSection != null)
		{
			gameObject.bCarryable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Wearable");
		if (xMLSection != null)
		{
			gameObject.bWearable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Openable");
		if (xMLSection != null)
		{
			gameObject.bOpenable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Lockable");
		if (xMLSection != null)
		{
			gameObject.bLockable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Enterable");
		if (xMLSection != null)
		{
			gameObject.bEnterable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Readable");
		if (xMLSection != null)
		{
			gameObject.bReadable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Container");
		if (xMLSection != null)
		{
			gameObject.bContainer = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Weight");
		if (xMLSection != null)
		{
			gameObject.dWeight = Convert.ToDouble(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Worn");
		if (xMLSection != null)
		{
			gameObject.bWorn = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Read");
		if (xMLSection != null)
		{
			gameObject.bRead = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Locked");
		if (xMLSection != null)
		{
			gameObject.bLocked = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Open");
		if (xMLSection != null)
		{
			gameObject.bOpen = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Visible");
		if (xMLSection != null)
		{
			gameObject.bVisible = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Actions");
		gameObject.Actions.Clear();
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Rags.Action action = Action_SetXMLData(ref CurNode2);
				foreach (Rags.Action action2 in gameObject.Actions)
				{
					if (action2.name == action.name)
					{
						gameObject.Actions.Remove(action2);
						break;
					}
				}
				gameObject.Actions.Add(action);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "LayeredZoneLevels");
		if (xMLSection != null)
		{
			gameObject.LayeredZoneLevels.Clear();
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[j];
				gameObject.LayeredZoneLevels.Add(xmlNode.InnerText);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[k];
				CustomProperty item = CustomProperty_SetXMLData(ref CurNode3);
				gameObject.CustomProperties.Add(item);
			}
		}
		return gameObject;
	}

	public static GamePicture GamePicture_Load(SqlCeDataReader dr)
	{
		GamePicture gamePicture = new GamePicture();
		gamePicture.TheName = dr["Name"].ToString();
		gamePicture.enhinputdata.Imagename = dr["ImageName"].ToString();
		gamePicture.enhinputdata.bUseEnhancedGraphics = (bool)dr["UseEnhancedGraphics"];
		gamePicture.enhinputdata.NewImage = dr["NewImage"].ToString();
		try
		{
			gamePicture.GroupName = dr["GroupName"].ToString();
		}
		catch
		{
		}
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from MediaLayeredImages where MediaName=@name order by [Order]", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", gamePicture.TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			gamePicture.LayeredImages.Add(sqlCeDataReader["data"].ToString());
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		return gamePicture;
	}

	public static void GamePicture_UpdatePictureGroup(GamePicture temppic)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("Select GroupName from Media\r\n                    where Name=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", temppic.TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			temppic.GroupName = sqlCeDataReader["GroupName"].ToString();
		}
	}

	public static GamePicture GamePicture_SetXMLData(ref XmlNode CurNode)
	{
		GamePicture gamePicture = new GamePicture();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "TheName");
		if (xMLSection != null)
		{
			gamePicture.TheName = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "LayeredImages");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				gamePicture.LayeredImages.Add(xmlNode.InnerText);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Choices");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode xmlNode2 = xMLSection.ChildNodes[j];
				gamePicture.Choices.Add(xmlNode2.InnerText);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "EnhancedInputData");
		if (xMLSection != null)
		{
			gamePicture.enhinputdata = EnhancedInputData_SetXMLData(ref xMLSection);
		}
		return gamePicture;
	}

	public static void GamePicture_GetXMLData(ref StreamWriter CurDoc, GamePicture temppic)
	{
		byte[] array = null;
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", temppic.TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			array = (byte[])sqlCeDataReader["Data"];
		}
		if (array == null)
		{
			return;
		}
		CurDoc.WriteLine(string.Format("<Image>", new object[0]));
		Game.AddXMLSection(ref CurDoc, "TheName", temppic.TheName.ToString());
		CurDoc.WriteLine("<ImageData>");
		CurDoc.WriteLine("<![CDATA[" + Convert.ToBase64String(array) + "]]>");
		CurDoc.WriteLine("</ImageData>");
		CurDoc.WriteLine("<LayeredImages>");
		foreach (string layeredImage in temppic.LayeredImages)
		{
			Game.AddXMLSection(ref CurDoc, "LayeredImage", layeredImage);
		}
		CurDoc.WriteLine("</LayeredImages>");
		CurDoc.WriteLine("<Choices>");
		foreach (object choice in temppic.Choices)
		{
			Game.AddXMLSection(ref CurDoc, "Choice", choice.ToString());
		}
		CurDoc.WriteLine("</Choices>");
		CurDoc.WriteLine("<EnhancedInputData>");
		EnhancedInputData_GetXMLData(ref CurDoc, temppic.enhinputdata);
		CurDoc.WriteLine("</EnhancedInputData>");
		CurDoc.WriteLine("</Image>");
	}

	public static void GamePicture_InsertToDatabase(string imagepath, GamePicture temppic)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Media values (\r\n                            @Name ,\r\n                            @BackgroundColor ,\r\n                            @TextColor,\r\n                            @TextFont ,\r\n                            @ImageName ,\r\n                            @UseEnhancedGraphics,\r\n                            @NewImage,\r\n                            @Data,\r\n                            @GroupName\r\n                            ) ", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("Name", temppic.TheName);
		sqlCeCommand.Parameters.AddWithValue("BackgroundColor", "");
		sqlCeCommand.Parameters.AddWithValue("TextColor", "");
		TypeDescriptor.GetConverter(typeof(FontFamily));
		sqlCeCommand.Parameters.AddWithValue("TextFont", "");
		sqlCeCommand.Parameters.AddWithValue("ImageName", temppic.enhinputdata.Imagename);
		sqlCeCommand.Parameters.AddWithValue("UseEnhancedGraphics", temppic.enhinputdata.bUseEnhancedGraphics);
		sqlCeCommand.Parameters.AddWithValue("NewImage", temppic.enhinputdata.NewImage);
		byte[] array = File.ReadAllBytes(imagepath);
		sqlCeCommand.Parameters.AddWithValue("Data", array);
		sqlCeCommand.Parameters.AddWithValue("GroupName", temppic.GroupName);
		if (array != null)
		{
			sqlCeCommand.ExecuteNonQuery();
		}
		sqlCeCommand.Dispose();
	}

	public static void GamePicture_UpdateDatabase(GamePicture temppic)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("update Media set \r\n                            BackgroundColor= @BackgroundColor ,\r\n                           TextColor= @TextColor,\r\n                            TextFont=@TextFont ,\r\n                            ImageName=@ImageName ,\r\n                            UseEnhancedGraphics=@UseEnhancedGraphics,\r\n                            NewImage=@NewImage\r\n                            where Name=@Name ", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@BackgroundColor", "");
		sqlCeCommand.Parameters.AddWithValue("@TextColor", "");
		TypeDescriptor.GetConverter(typeof(FontFamily));
		sqlCeCommand.Parameters.AddWithValue("@TextFont", "");
		sqlCeCommand.Parameters.AddWithValue("@ImageName", temppic.enhinputdata.Imagename);
		sqlCeCommand.Parameters.AddWithValue("@UseEnhancedGraphics", temppic.enhinputdata.bUseEnhancedGraphics);
		sqlCeCommand.Parameters.AddWithValue("@NewImage", temppic.enhinputdata.NewImage);
		sqlCeCommand.Parameters.AddWithValue("@Name", temppic.TheName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
	}

	public static Image GamePicure_GetTheImage(GamePicture temppic)
	{
		byte[] buffer = null;
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select Data from Media where \r\n                            Name=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", temppic.TheName);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			buffer = (byte[])sqlCeDataReader["Data"];
		}
		new MemoryStream(buffer);
		try
		{
			return null;
		}
		catch
		{
			return null;
		}
	}

	public static void PopulateComboWithConditions(ItemCollection cb, bool bFilter)
	{
		cb.Clear();
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_AdditionalDataCheck, "Additional Data Check"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Character_CustomPropertyCheck, "Character: Custom Property Check"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Character_Gender, "Character: Gender"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Character_In_Room, "Character: In Room"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Character_In_RoomGroup, "Character: In Room Group"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_CustomPropertyCheck, "Item: Custom Property Check"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_InGroup, "Item: In Group"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_Held_By_Character, "Item: Held By Character"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_Held_By_Player, "Item: Held By Player"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_In_Object, "Item: In Object"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_In_Room, "Item: In Room"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_In_RoomGroup, "Item: In Room Group"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_Not_Held_By_Player, "Item: Not Held By Player"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_Not_In_Object, "Item: Not In Object"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Item_State_Check, "Item: State Check"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_While, "Loop: While"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Characters, "Loop: Characters"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Items, "Loop: Items"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Item_Group, "Loop: Item Group"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Item_Container, "Loop: Items In Container"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Item_Room, "Loop: Items In Room"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Item_Inventory, "Loop: Items In Player Inventory"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Item_Char_Inventory, "Loop: Items In Character Inventory"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Rooms, "Loop: Rooms"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Loop_Exits, "Loop: Exits"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_MultiMedia_InGroup, "Multimedia: In Group"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Player_CustomPropertyCheck, "Player: Custom Property Check"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Player_Gender, "Player: Gender"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Player_In_Room, "Player: In Room"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Player_In_RoomGroup, "Player: In Room Group"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Player_In_Same_Room_As, "Player: In Same Room As"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Player_Moving, "Player: Moving In Direction"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Room_CustomPropertyCheck, "Room: Custom Property Check"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Timer_CustomPropertyCheck, "Timer: Custom Property Check"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Variable_Comparison, "Variable: Comparison"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Variable_To_Variable_Comparison, "Variable: Comparison To Variable"));
		cb.Add((object)new CommandConditionComboItem(Condition.ConditionType.CT_Variable_CustomPropertyCheck, "Variable: Custom Property Check"));
	}

	public static string GetConditionName(Condition.ConditionType ct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		string result = string.Empty;
		ComboBox val = new ComboBox();
		PopulateComboWithConditions(((ItemsControl)val).Items, bFilter: false);
		foreach (CommandConditionComboItem item in (IEnumerable)((ItemsControl)val).Items)
		{
			if (item.cndindex == ct)
			{
				result = item.Name;
				break;
			}
		}
		return result;
	}

	public static CommandConditionComboItem GetConditionItem(ItemCollection tempcb, Condition.ConditionType ct)
	{
		CommandConditionComboItem commandConditionComboItem = null;
		foreach (CommandConditionComboItem item in (IEnumerable)tempcb)
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
			tempcb.Add((object)commandConditionComboItem3);
			commandConditionComboItem = commandConditionComboItem3;
		}
		return commandConditionComboItem;
	}

	public static CommandConditionComboItem GetCommandItem(ItemCollection tempcb, Command.CommandType ct)
	{
		CommandConditionComboItem commandConditionComboItem = null;
		foreach (CommandConditionComboItem item in (IEnumerable)tempcb)
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
			tempcb.Add((object)commandConditionComboItem3);
			commandConditionComboItem = commandConditionComboItem3;
		}
		return commandConditionComboItem;
	}

	public static string GetCommandName(Command.CommandType ct)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		string result = string.Empty;
		ComboBox val = new ComboBox();
		PopulateComboWithCommands(((ItemsControl)val).Items, bFilter: false);
		foreach (CommandConditionComboItem item in (IEnumerable)((ItemsControl)val).Items)
		{
			if (item.ctindex == ct)
			{
				result = item.Name;
				break;
			}
		}
		return result;
	}

	public static EnhancedInputData EnhancedInputData_SetXMLData(ref XmlNode CurNode)
	{
		EnhancedInputData enhancedInputData = new EnhancedInputData();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "UseEnhancedGraphics");
		if (xMLSection != null)
		{
			enhancedInputData.bUseEnhancedGraphics = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "AllowCancel");
		if (xMLSection != null)
		{
			enhancedInputData.bAllowCancel = Convert.ToBoolean(xMLSection.InnerText);
		}
		if (enhancedInputData.bUseEnhancedGraphics)
		{
			xMLSection = GetXMLSection(ref CurNode, "BackgroundColor");
			if (xMLSection != null)
			{
			}
			xMLSection = GetXMLSection(ref CurNode, "TextColor");
			if (xMLSection != null)
			{
			}
			xMLSection = GetXMLSection(ref CurNode, "Imagename");
			if (xMLSection != null)
			{
				enhancedInputData.Imagename = xMLSection.InnerText;
			}
			xMLSection = GetXMLSection(ref CurNode, "NewImage");
			if (xMLSection != null)
			{
				enhancedInputData.NewImage = xMLSection.InnerText;
			}
			xMLSection = GetXMLSection(ref CurNode, "TextFont");
		}
		return enhancedInputData;
	}

	public static void EnhancedInputData_GetXMLData(ref StreamWriter CurDoc, EnhancedInputData tempeid)
	{
		Game.AddXMLSection(ref CurDoc, "Imagename", tempeid.Imagename);
		Game.AddXMLSection(ref CurDoc, "UseEnhancedGraphics", tempeid.bUseEnhancedGraphics.ToString());
		Game.AddXMLSection(ref CurDoc, "AllowCancel", tempeid.bAllowCancel.ToString());
		Game.AddXMLSection(ref CurDoc, "NewImage", tempeid.NewImage);
		TypeDescriptor.GetConverter(typeof(FontFamily));
	}

	public static void EnhancedInputData_GetXMLData(ref StringBuilder CurDoc, EnhancedInputData tempeid)
	{
		Game.AddXMLSection(ref CurDoc, "Imagename", tempeid.Imagename);
		Game.AddXMLSection(ref CurDoc, "UseEnhancedGraphics", tempeid.bUseEnhancedGraphics.ToString());
		Game.AddXMLSection(ref CurDoc, "AllowCancel", tempeid.bAllowCancel.ToString());
		Game.AddXMLSection(ref CurDoc, "NewImage", tempeid.NewImage);
	}

	public static void EnhancedInputData_GetAdvancedText(ref StringBuilder CurDoc, EnhancedInputData tempeid)
	{
		Game.AddAdvSection(ref CurDoc, "Imagename", tempeid.Imagename);
		Game.AddAdvSection(ref CurDoc, "UseEnhancedGraphics", tempeid.bUseEnhancedGraphics.ToString());
		Game.AddAdvSection(ref CurDoc, "AllowCancel", tempeid.bAllowCancel.ToString());
		Game.AddAdvSection(ref CurDoc, "NewImage", tempeid.NewImage);
		TypeDescriptor.GetConverter(typeof(FontFamily));
		Game.AddAdvSection(ref CurDoc, "TextFont", "");
	}

	public static GameVariable GameVariable_Load(SqlCeDataReader dr)
	{
		string vname = dr["VarName"].ToString();
		GameVariable gameVariable = new GameVariable(vname);
		gameVariable.sString = dr["String"].ToString();
		gameVariable.dNumType = (double)dr["NumType"];
		gameVariable.dMin = dr["Min"].ToString();
		gameVariable.dMax = dr["Max"].ToString();
		gameVariable.bEnforceRestrictions = (bool)dr["EnforceRestrictions"];
		gameVariable.VarComment = dr["VarComment"].ToString();
		gameVariable.dtDateTime = (DateTime)dr["dtDateTime"];
		gameVariable.vartype = (GameVariable.VarType)dr["VarType"];
		string xml = dr["VarArray"].ToString();
		try
		{
			gameVariable.GroupName = dr["GroupName"].ToString();
		}
		catch
		{
			gameVariable.GroupName = string.Empty;
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.LoadXml(xml);
			XmlNode firstChild = xmlDocument.FirstChild;
			if (firstChild != null)
			{
				for (int i = 0; i < firstChild.ChildNodes.Count; i++)
				{
					XmlNode xmlNode = firstChild.ChildNodes[i];
					string innerText = xmlNode.InnerText;
					if (innerText.IndexOf("*S*E*P*") > -1)
					{
						List<string> list = new List<string>();
						gameVariable.VarArray.Add(list);
						string[] array = innerText.Split(new string[1] { "*S*E*P*" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string item in array2)
						{
							list.Add(item);
						}
						continue;
					}
					switch (gameVariable.vartype)
					{
					case GameVariable.VarType.VT_DATETIMEARRAY:
						gameVariable.VarArray.Add(Convert.ToDateTime(innerText));
						break;
					case GameVariable.VarType.VT_NUMBERARRAY:
						gameVariable.VarArray.Add(Convert.ToDouble(innerText));
						break;
					case GameVariable.VarType.VT_STRINGARRAY:
						gameVariable.VarArray.Add(innerText);
						break;
					}
				}
			}
		}
		catch
		{
		}
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from VariableProperties where VarName=@VarName", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@VarName", gameVariable.varname);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			gameVariable.CustomProperties.Add(CustomProperty_LoadCustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		return gameVariable;
	}

	public static void GameVariable_UpdateDatabase(GameVariable tempvar)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Variables values(\r\n                            @VarName,\r\n                            @String ,\r\n                            @NumType ,\r\n                            @Min ,\r\n                            @Max ,\r\n                            @EnforceRestrictions ,\r\n                            @VarComment ,\r\n                            @dtDateTime,\r\n                            @VarType,\r\n                            @VarArray,\r\n                            @GroupName)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@VarName", tempvar.varname);
		sqlCeCommand.Parameters.AddWithValue("@String", tempvar.sString);
		sqlCeCommand.Parameters.AddWithValue("@NumType", tempvar.dNumType);
		sqlCeCommand.Parameters.AddWithValue("@Min", tempvar.dMin);
		sqlCeCommand.Parameters.AddWithValue("@Max", tempvar.dMax);
		sqlCeCommand.Parameters.AddWithValue("@EnforceRestrictions", tempvar.bEnforceRestrictions);
		sqlCeCommand.Parameters.AddWithValue("@VarComment", tempvar.VarComment);
		sqlCeCommand.Parameters.AddWithValue("@dtDateTime", tempvar.dtDateTime);
		sqlCeCommand.Parameters.AddWithValue("@VarType", tempvar.vartype);
		StringBuilder CurDoc = new StringBuilder();
		if (tempvar.VarArray.Count > 0)
		{
			CurDoc.Append("<ArrayItems>");
			for (int i = 0; i < tempvar.VarArray.Count; i++)
			{
				if (tempvar.VarArray[i] is List<string>)
				{
					string text = string.Empty;
					int num = 0;
					foreach (string item in (List<string>)tempvar.VarArray[i])
					{
						if (num > 0)
						{
							text += "*S*E*P*";
						}
						text += item;
						num++;
					}
					Game.AddXMLSection(ref CurDoc, "ArrayItem", text);
				}
				else
				{
					Game.AddXMLSection(ref CurDoc, "ArrayItem", tempvar.VarArray[i].ToString());
				}
			}
			CurDoc.Append("</ArrayItems>");
		}
		sqlCeCommand.Parameters.AddWithValue("@VarArray", CurDoc.ToString());
		sqlCeCommand.Parameters.AddWithValue("@GroupName", tempvar.GroupName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (CustomProperty customProperty in tempvar.CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into VariableProperties (VarName,Name,Value) values(@VarName,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@VarName", tempvar.varname);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	public static void GameVariable_GetXMLData(ref StreamWriter CurDoc, GameVariable tempvar)
	{
		CurDoc.WriteLine("<Variable>");
		Game.AddXMLSection(ref CurDoc, "Name", tempvar.varname);
		Game.AddXMLSection(ref CurDoc, "Comment", tempvar.VarComment);
		Game.AddXMLSection(ref CurDoc, "Type", tempvar.vartype.ToString());
		Game.AddXMLSection(ref CurDoc, "EnforceRestrictions", tempvar.bEnforceRestrictions.ToString());
		Game.AddXMLSection(ref CurDoc, "Number", tempvar.dNumType.ToString());
		Game.AddXMLSection(ref CurDoc, "String", tempvar.sString);
		Game.AddXMLSection(ref CurDoc, "DateTime", tempvar.dtDateTime.ToString());
		Game.AddXMLSection(ref CurDoc, "Min", tempvar.dMin.ToString());
		Game.AddXMLSection(ref CurDoc, "Max", tempvar.dMax.ToString());
		Game.AddXMLSection(ref CurDoc, "GroupName", tempvar.GroupName.ToString());
		if (tempvar.VarArray.Count > 0)
		{
			CurDoc.WriteLine("<ArrayItems>");
			for (int i = 0; i < tempvar.VarArray.Count; i++)
			{
				if (tempvar.VarArray[i] is List<string>)
				{
					string text = string.Empty;
					int num = 0;
					foreach (string item in (List<string>)tempvar.VarArray[i])
					{
						if (num > 0)
						{
							text += "*S*E*P*";
						}
						text += item;
						num++;
					}
					Game.AddXMLSection(ref CurDoc, "ArrayItem", text);
				}
				else
				{
					Game.AddXMLSection(ref CurDoc, "ArrayItem", tempvar.VarArray[i].ToString());
				}
			}
			CurDoc.WriteLine("</ArrayItems>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in tempvar.CustomProperties)
		{
			CustomProperty_GetXMLData(ref CurDoc, customProperty);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Variable>");
	}

	public static GameVariable GameVariable_SetXMLData(ref XmlNode CurNode)
	{
		string vname = string.Empty;
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			vname = xMLSection.InnerText;
		}
		GameVariable gameVariable = new GameVariable(vname);
		xMLSection = GetXMLSection(ref CurNode, "Comment");
		if (xMLSection != null)
		{
			gameVariable.VarComment = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Type");
		if (xMLSection != null)
		{
			gameVariable.vartype = (GameVariable.VarType)Enum.Parse(typeof(GameVariable.VarType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "EnforceRestrictions");
		if (xMLSection != null)
		{
			gameVariable.bEnforceRestrictions = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Number");
		if (xMLSection != null)
		{
			gameVariable.dNumType = Convert.ToDouble(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Min");
		if (xMLSection != null)
		{
			gameVariable.dMin = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Max");
		if (xMLSection != null)
		{
			gameVariable.dMax = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "GroupName");
		if (xMLSection != null)
		{
			gameVariable.GroupName = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "String");
		if (xMLSection != null)
		{
			gameVariable.sString = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "DateTime");
		if (xMLSection != null)
		{
			gameVariable.dtDateTime = Convert.ToDateTime(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "ArrayItems");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				string innerText = xmlNode.InnerText;
				if (innerText.IndexOf("*S*E*P*") > -1)
				{
					List<string> list = new List<string>();
					gameVariable.VarArray.Add(list);
					string[] array = innerText.Split(new string[1] { "*S*E*P*" }, StringSplitOptions.None);
					string[] array2 = array;
					foreach (string item in array2)
					{
						list.Add(item);
					}
					continue;
				}
				switch (gameVariable.vartype)
				{
				case GameVariable.VarType.VT_DATETIMEARRAY:
					gameVariable.VarArray.Add(Convert.ToDateTime(innerText));
					break;
				case GameVariable.VarType.VT_NUMBERARRAY:
					gameVariable.VarArray.Add(Convert.ToDouble(innerText));
					break;
				case GameVariable.VarType.VT_STRINGARRAY:
					gameVariable.VarArray.Add(innerText);
					break;
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[k];
				CustomProperty item2 = CustomProperty_SetXMLData(ref CurNode2);
				gameVariable.CustomProperties.Add(item2);
			}
		}
		return gameVariable;
	}

	public static void GameVariable_UpdateGroupName(GameVariable tempvar)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("Select GroupName from Variables\r\n                    where VarName=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", tempvar.varname.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			tempvar.GroupName = sqlCeDataReader["GroupName"].ToString();
		}
	}

	public static Player Player_Load(SqlCeDataReader dr)
	{
		Player player = new Player();
		player.Name = dr["Name"].ToString();
		player.Description = dr["Description"].ToString();
		player.PlayerLayeredImage = dr["PlayerLayeredImage"].ToString();
		player.PlayerGender = (Player.Gender)dr["PlayerGender"];
		player.bPromptForName = (bool)dr["PromptForName"];
		player.bPromptForGender = (bool)dr["PromptForGender"];
		player.PlayerPortrait = dr["PlayerPortrait"].ToString();
		player.bEnforceWeight = (bool)dr["EnforceWeight"];
		player.dWeightLimit = (double)dr["WeightLimit"];
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from PlayerProperties", dBConnection);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			player.CustomProperties.Add(CustomProperty_LoadCustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from PlayerActions", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		player.Actions.Clear();
		while (sqlCeDataReader.Read())
		{
			player.Actions.Add(Action_CreateAction(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		return player;
	}

	public static void Player_UpdateDatabase(Player tempplayer)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from Player", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("insert into Player values(\r\n                    @Name ,\r\n                    @Description ,\r\n                    @StartingRoom ,\r\n                    @CurrentRoom ,\r\n                    @PlayerLayeredImage ,\r\n                    @PlayerGender ,\r\n                    @PromptForName ,\r\n                    @PromptForGender ,\r\n                    @PlayerPortrait ,\r\n                    @EnforceWeight ,\r\n                    @WeightLimit \r\n                    )", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", tempplayer.Name);
		sqlCeCommand.Parameters.AddWithValue("@Description", tempplayer.Description);
		if (tempplayer.StartingRoom == null)
		{
			sqlCeCommand.Parameters.AddWithValue("@StartingRoom", string.Empty);
		}
		else
		{
			sqlCeCommand.Parameters.AddWithValue("@StartingRoom", tempplayer.StartingRoom.UniqueID.ToString());
		}
		if (tempplayer.CurrentRoom == null)
		{
			sqlCeCommand.Parameters.AddWithValue("@CurrentRoom", string.Empty);
		}
		else
		{
			sqlCeCommand.Parameters.AddWithValue("@CurrentRoom", tempplayer.CurrentRoom.UniqueID.ToString());
		}
		sqlCeCommand.Parameters.AddWithValue("@PlayerLayeredImage", tempplayer.PlayerLayeredImage);
		sqlCeCommand.Parameters.AddWithValue("@PlayerGender", tempplayer.PlayerGender);
		sqlCeCommand.Parameters.AddWithValue("@PromptForName", tempplayer.bPromptForName);
		sqlCeCommand.Parameters.AddWithValue("@PromptForGender", tempplayer.bPromptForGender);
		sqlCeCommand.Parameters.AddWithValue("@PlayerPortrait", tempplayer.PlayerPortrait);
		sqlCeCommand.Parameters.AddWithValue("@EnforceWeight", tempplayer.bEnforceWeight);
		sqlCeCommand.Parameters.AddWithValue("@WeightLimit", tempplayer.dWeightLimit);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("delete from PlayerActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Rags.Action action in tempplayer.Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into PlayerActions (Data) values(@Data)", dBConnection);
			StringBuilder CurDoc = new StringBuilder();
			Action_GetXMLData(ref CurDoc, action);
			string value = Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		sqlCeCommand = new SqlCeCommand("delete from PlayerProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (CustomProperty customProperty in tempplayer.CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into PlayerProperties (Name,Value) values(@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	public static void Player_GetXMLData(ref StreamWriter CurDoc, Player tempplayer)
	{
		CurDoc.WriteLine("<Player>");
		Game.AddXMLSection(ref CurDoc, "Name", tempplayer.Name);
		Game.AddXMLSection(ref CurDoc, "Description", tempplayer.Description);
		if (tempplayer.StartingRoom != null)
		{
			Game.AddXMLSection(ref CurDoc, "StartingRoom", tempplayer.StartingRoom.UniqueID.ToString());
		}
		Game.AddXMLSection(ref CurDoc, "PlayerGender", tempplayer.PlayerGender.ToString());
		Game.AddXMLSection(ref CurDoc, "PromptForName", tempplayer.bPromptForName.ToString());
		Game.AddXMLSection(ref CurDoc, "PromptForGender", tempplayer.bPromptForGender.ToString());
		Game.AddXMLSection(ref CurDoc, "PlayerPortrait", tempplayer.PlayerPortrait);
		Game.AddXMLSection(ref CurDoc, "EnforceWeightRestrictions", tempplayer.bEnforceWeight.ToString());
		if (tempplayer.Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Rags.Action action in tempplayer.Actions)
			{
				Action_GetXMLData(ref CurDoc, action);
			}
			CurDoc.WriteLine("</Actions>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in tempplayer.CustomProperties)
		{
			CustomProperty_GetXMLData(ref CurDoc, customProperty);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Player>");
	}

	public static Player Player_SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		Player player = new Player();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			player.Name = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Description");
		if (xMLSection != null)
		{
			player.Description = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "StartingRoom");
		if (xMLSection != null)
		{
			player.StartingRoom = TheGame.GetRoomByID(new Guid(xMLSection.InnerText));
		}
		xMLSection = GetXMLSection(ref CurNode, "PlayerGender");
		if (xMLSection != null)
		{
			player.PlayerGender = (Player.Gender)Enum.Parse(typeof(Player.Gender), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "PromptForName");
		if (xMLSection != null)
		{
			player.bPromptForName = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "PromptForGender");
		if (xMLSection != null)
		{
			player.bPromptForGender = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "PlayerPortrait");
		if (xMLSection != null)
		{
			player.PlayerPortrait = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "EnforceWeightRestrictions");
		if (xMLSection != null)
		{
			player.bEnforceWeight = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Actions");
		player.Actions.Clear();
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Rags.Action action = Action_SetXMLData(ref CurNode2);
				foreach (Rags.Action action2 in player.Actions)
				{
					if (action2.name == action.name)
					{
						player.Actions.Remove(action2);
						break;
					}
				}
				player.Actions.Add(action);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				CustomProperty item = CustomProperty_SetXMLData(ref CurNode3);
				player.CustomProperties.Add(item);
			}
		}
		return player;
	}

	public static Room Room_Load(SqlCeDataReader dr)
	{
		Room room = new Room();
		room.Description = dr["Description"].ToString();
		room.SDesc = dr["SDesc"].ToString();
		room.Name = dr["Name"].ToString();
		room.RoomPic = dr["RoomPic"].ToString();
		room.bEnterFirstTime = (bool)dr["EnterFirstTime"];
		room.bLeaveFirstTime = (bool)dr["LeaveFirstTime"];
		room.UniqueID = new Guid(dr["UniqueID"].ToString());
		room.Group = dr["Group"].ToString();
		room.LayeredRoomPic = dr["LayeredRoomPic"].ToString();
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from RoomExits where RoomID=@RoomID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@RoomID", room.UniqueID.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		room.Exits.Clear();
		while (sqlCeDataReader.Read())
		{
			room.Exits.Add(Exit_Load(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from RoomProperties where RoomID=@RoomID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@RoomID", room.UniqueID.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			room.CustomProperties.Add(CustomProperty_LoadCustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from RoomActions where RoomID=@RoomID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@RoomID", room.UniqueID.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		room.Actions.Clear();
		while (sqlCeDataReader.Read())
		{
			room.Actions.Add(Action_CreateAction(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		return room;
	}

	public static void Room_GetXMLData(ref StreamWriter CurDoc, Room temproom)
	{
		CurDoc.WriteLine(string.Format("<Room>", new object[0]));
		Game.AddXMLSection(ref CurDoc, "Name", temproom.Name);
		Game.AddXMLSection(ref CurDoc, "Description", temproom.Description);
		Game.AddXMLSection(ref CurDoc, "SDesc", temproom.SDesc);
		Game.AddXMLSection(ref CurDoc, "RoomPic", temproom.RoomPic);
		Game.AddXMLSection(ref CurDoc, "UniqueID", temproom.UniqueID.ToString());
		Game.AddXMLSection(ref CurDoc, "Group", temproom.Group.ToString());
		CurDoc.WriteLine("<Exits>");
		foreach (Exit exit in temproom.Exits)
		{
			Exit_GetXMLData(ref CurDoc, exit);
		}
		CurDoc.WriteLine("</Exits>");
		if (temproom.Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Rags.Action action in temproom.Actions)
			{
				Action_GetXMLData(ref CurDoc, action);
			}
			CurDoc.WriteLine("</Actions>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in temproom.CustomProperties)
		{
			CustomProperty_GetXMLData(ref CurDoc, customProperty);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Room>");
	}

	public static string Room_GetAdvancedText(Room temproom)
	{
		StringBuilder CurDoc = new StringBuilder();
		CurDoc.Append(string.Format("<Room>\\r\\n", new object[0]));
		Game.AddAdvSection(ref CurDoc, "Name", temproom.Name);
		Game.AddAdvSection(ref CurDoc, "Description", temproom.Description);
		Game.AddAdvSection(ref CurDoc, "SDesc", temproom.SDesc);
		Game.AddAdvSection(ref CurDoc, "RoomPic", temproom.RoomPic);
		Game.AddAdvSection(ref CurDoc, "UniqueID", temproom.UniqueID.ToString());
		Game.AddAdvSection(ref CurDoc, "Group", temproom.Group.ToString());
		CurDoc.Append("<Exits>\r\n");
		foreach (Exit exit in temproom.Exits)
		{
			Exit_GetAdvancedText(ref CurDoc, exit);
		}
		CurDoc.Append("</Exits>\r\n");
		if (temproom.Actions.Count > 0)
		{
			CurDoc.Append("<Actions>\r\n");
			foreach (Rags.Action action in temproom.Actions)
			{
				Action_GetAdvancedText(ref CurDoc, action);
			}
			CurDoc.Append("</Actions>\r\n");
		}
		CurDoc.Append("<CustomProperties>");
		foreach (CustomProperty customProperty in temproom.CustomProperties)
		{
			CustomProperty_GetXMLData(ref CurDoc, customProperty);
		}
		CurDoc.Append("</CustomProperties>\r\n");
		CurDoc.Append("</Room>\r\n");
		return CurDoc.ToString();
	}

	public static Room Room_SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		Room room = new Room();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			room.Name = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Description");
		if (xMLSection != null)
		{
			room.Description = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "SDesc");
		if (xMLSection != null)
		{
			room.SDesc = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "RoomPic");
		if (xMLSection != null)
		{
			room.RoomPic = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "UniqueID");
		if (xMLSection != null)
		{
			room.UniqueID = new Guid(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Group");
		if (xMLSection != null)
		{
			room.Group = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Exits");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Exit exit = Exit_SetXMLData(ref CurNode2, TheGame);
				int num = -1;
				foreach (Exit exit2 in room.Exits)
				{
					num++;
					if (exit2.Direction == exit.Direction)
					{
						room.Exits.Remove(exit2);
						room.Exits.Insert(num, exit);
						break;
					}
				}
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "Actions");
		room.Actions.Clear();
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Rags.Action action = Action_SetXMLData(ref CurNode3);
				foreach (Rags.Action action2 in room.Actions)
				{
					if (action2.name == action.name)
					{
						room.Actions.Remove(action2);
						break;
					}
				}
				room.Actions.Add(action);
			}
		}
		if (TheGame.RoomList.Count > 0)
		{
			foreach (CustomProperty customProperty2 in TheGame.RoomList[0].CustomProperties)
			{
				room.CustomProperties.Add(customProperty2);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode4 = xMLSection.ChildNodes[k];
				CustomProperty customProperty = CustomProperty_SetXMLData(ref CurNode4);
				bool flag = true;
				foreach (CustomProperty customProperty3 in room.CustomProperties)
				{
					if (customProperty3.Name == customProperty.Name)
					{
						room.CustomProperties.Remove(customProperty3);
						flag = false;
						break;
					}
				}
				if (flag)
				{
					foreach (Room room2 in TheGame.RoomList)
					{
						room2.CustomProperties.Add(customProperty);
					}
				}
				else
				{
					room.CustomProperties.Add(customProperty);
				}
			}
		}
		return room;
	}

	public static void Room_UpdateDatabase(Room temproom)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Rooms values(@UniqueID,@Description,\r\n                        @SDesc,@Name,@RoomPic,\r\n                        @EnterFirstTime,@LeaveFirstTime,@Group,@LayeredRoomPic)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@UniqueID", temproom.UniqueID.ToString());
		sqlCeCommand.Parameters.AddWithValue("@Description", temproom.Description);
		sqlCeCommand.Parameters.AddWithValue("@SDesc", temproom.SDesc);
		sqlCeCommand.Parameters.AddWithValue("@Name", temproom.Name);
		sqlCeCommand.Parameters.AddWithValue("@RoomPic", temproom.RoomPic);
		sqlCeCommand.Parameters.AddWithValue("@EnterFirstTime", temproom.bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@LeaveFirstTime", temproom.bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@Group", temproom.Group);
		sqlCeCommand.Parameters.AddWithValue("@LayeredRoomPic", temproom.LayeredRoomPic);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Rags.Action action in temproom.Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into RoomActions (RoomID,Data) values(@RoomID,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@RoomID", temproom.UniqueID.ToString());
			StringBuilder CurDoc = new StringBuilder();
			Action_GetXMLData(ref CurDoc, action);
			string value = Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in temproom.CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into RoomProperties (RoomID,Name,Value) values(@RoomID,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@RoomID", temproom.UniqueID.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (Exit exit in temproom.Exits)
		{
			sqlCeCommand = new SqlCeCommand("insert into RoomExits (RoomID,Direction,Active,\r\n                        DestinationRoom,PortalObjectName) values(@RoomID,@Direction,@Active,\r\n                        @DestinationRoom,@PortalObjectName)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@RoomID", temproom.UniqueID.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Direction", exit.Direction);
			sqlCeCommand.Parameters.AddWithValue("@Active", exit.bActive);
			if (exit.DestinationRoom == null)
			{
				exit.DestinationRoom = string.Empty;
			}
			sqlCeCommand.Parameters.AddWithValue("@DestinationRoom", exit.DestinationRoom);
			sqlCeCommand.Parameters.AddWithValue("@PortalObjectName", exit.PortalObjectName);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	public static StatusBarItem StatusBarItem_Load(SqlCeDataReader dr)
	{
		StatusBarItem statusBarItem = new StatusBarItem();
		statusBarItem.Name = dr["Name"].ToString();
		statusBarItem.Text = dr["Text"].ToString();
		statusBarItem.bVisisble = (bool)dr["Visible"];
		statusBarItem.Width = (int)dr["Width"];
		return statusBarItem;
	}

	public static void StatusBarItem_GetXMLData(ref StreamWriter CurDoc, StatusBarItem tempitem)
	{
		CurDoc.WriteLine("<StatusBarItem>");
		Game.AddXMLSection(ref CurDoc, "Name", tempitem.Name);
		Game.AddXMLSection(ref CurDoc, "Text", tempitem.Text);
		Game.AddXMLSection(ref CurDoc, "Width", tempitem.Width.ToString());
		Game.AddXMLSection(ref CurDoc, "Visible", tempitem.bVisisble.ToString());
		CurDoc.WriteLine("</StatusBarItem>");
	}

	public static StatusBarItem StatusBarItem_SetXMLData(ref XmlNode CurNode)
	{
		StatusBarItem statusBarItem = new StatusBarItem();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			statusBarItem.Name = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Text");
		if (xMLSection != null)
		{
			statusBarItem.Text = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Width");
		if (xMLSection != null)
		{
			statusBarItem.Width = Convert.ToInt32(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Visible");
		if (xMLSection != null)
		{
			statusBarItem.bVisisble = Convert.ToBoolean(xMLSection.InnerText);
		}
		return statusBarItem;
	}

	public static void StatusBarItem_UpdateDatabase(StatusBarItem tempitem)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into StatusBarItems\r\n                        (Name,Text,Width,Visible) values(@Name,@Text,\r\n                        @Width,@Visible)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", tempitem.Name);
		sqlCeCommand.Parameters.AddWithValue("@Text", tempitem.Text);
		sqlCeCommand.Parameters.AddWithValue("@Width", tempitem.Width);
		sqlCeCommand.Parameters.AddWithValue("@Visible", tempitem.bVisisble);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
	}

	public static Timer Timer_Load(SqlCeDataReader dr)
	{
		Timer timer = new Timer();
		timer.Name = dr["Name"].ToString();
		timer.TType = (Timer.TimerType)dr["TType"];
		timer.Active = (bool)dr["Active"];
		timer.Restart = (bool)dr["Restart"];
		timer.TurnNumber = (int)dr["TurnNumber"];
		timer.Length = (int)dr["Length"];
		timer.LiveTimer = (bool)dr["LiveTimer"];
		timer.TimerSeconds = (int)dr["TimerSeconds"];
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from TimerProperties where TimerName=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", timer.Name);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			timer.CustomProperties.Add(CustomProperty_LoadCustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from TimerActions where Name=@Name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", timer.Name);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		timer.Actions.Clear();
		while (sqlCeDataReader.Read())
		{
			timer.Actions.Add(Action_CreateAction(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		return timer;
	}

	public static void Timer_UpdateDatabase(Timer temptimer)
	{
		SqlCeConnection dBConnection = GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Timer values(\r\n                            @Name,\r\n                            @TType ,\r\n                            @Active ,\r\n                            @Restart ,\r\n                            @TurnNumber ,\r\n                            @Length ,\r\n                            @LiveTimer ,\r\n                            @TimerSeconds )", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", temptimer.Name);
		sqlCeCommand.Parameters.AddWithValue("@TType", temptimer.TType);
		sqlCeCommand.Parameters.AddWithValue("@Active", temptimer.Active);
		sqlCeCommand.Parameters.AddWithValue("@Restart", temptimer.Restart);
		sqlCeCommand.Parameters.AddWithValue("@TurnNumber", temptimer.TurnNumber);
		sqlCeCommand.Parameters.AddWithValue("@Length", temptimer.Length);
		sqlCeCommand.Parameters.AddWithValue("@LiveTimer", temptimer.LiveTimer);
		sqlCeCommand.Parameters.AddWithValue("@TimerSeconds", temptimer.TimerSeconds);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Rags.Action action in temptimer.Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into TimerActions (Name,Data) values(@Name,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Name", temptimer.Name);
			StringBuilder CurDoc = new StringBuilder();
			Action_GetXMLData(ref CurDoc, action);
			string value = Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in temptimer.CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into TimerProperties (TimerName,Name,Value) values(@TimerName,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@TimerName", temptimer.Name);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	public static void Timer_GetXMLData(ref StreamWriter CurDoc, Timer temptimer)
	{
		CurDoc.WriteLine("<Timer>");
		Game.AddXMLSection(ref CurDoc, "Name", temptimer.Name);
		Game.AddXMLSection(ref CurDoc, "Type", temptimer.TType.ToString());
		Game.AddXMLSection(ref CurDoc, "Active", temptimer.Active.ToString());
		Game.AddXMLSection(ref CurDoc, "Restart", temptimer.Restart.ToString());
		Game.AddXMLSection(ref CurDoc, "Length", temptimer.Length.ToString());
		Game.AddXMLSection(ref CurDoc, "LiveTimer", temptimer.LiveTimer.ToString());
		Game.AddXMLSection(ref CurDoc, "TimerSeconds", temptimer.TimerSeconds.ToString());
		if (temptimer.Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Rags.Action action in temptimer.Actions)
			{
				Action_GetXMLData(ref CurDoc, action);
			}
			CurDoc.WriteLine("</Actions>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in temptimer.CustomProperties)
		{
			CustomProperty_GetXMLData(ref CurDoc, customProperty);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Timer>");
	}

	public static Timer Timer_SetXMLData(ref XmlNode CurNode)
	{
		Timer timer = new Timer();
		XmlNode xMLSection = GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			timer.Name = xMLSection.InnerText;
		}
		xMLSection = GetXMLSection(ref CurNode, "Type");
		if (xMLSection != null)
		{
			timer.TType = (Timer.TimerType)Enum.Parse(typeof(Timer.TimerType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = GetXMLSection(ref CurNode, "Active");
		if (xMLSection != null)
		{
			timer.Active = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Restart");
		if (xMLSection != null)
		{
			timer.Restart = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Length");
		if (xMLSection != null)
		{
			timer.Length = Convert.ToInt32(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "LiveTimer");
		if (xMLSection != null)
		{
			timer.LiveTimer = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "TimerSeconds");
		if (xMLSection != null)
		{
			timer.TimerSeconds = Convert.ToInt32(xMLSection.InnerText);
		}
		xMLSection = GetXMLSection(ref CurNode, "Actions");
		timer.Actions.Clear();
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Rags.Action action = Action_SetXMLData(ref CurNode2);
				foreach (Rags.Action action2 in timer.Actions)
				{
					if (action2.name == action.name)
					{
						timer.Actions.Remove(action2);
						break;
					}
				}
				timer.Actions.Add(action);
			}
		}
		xMLSection = GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				CustomProperty item = CustomProperty_SetXMLData(ref CurNode3);
				timer.CustomProperties.Add(item);
			}
		}
		return timer;
	}

	public static void AddTextToRTF(ref WebBrowser rtcontrol, ref Game TheGame, string text)
	{
		if (TheGame != null)
		{
			string text2 = string.Empty;
			while (!text2.Equals(text))
			{
				text2 = text;
				text = TheGame.PerformTextReplacements(text, null);
			}
		}
		text = text.Replace("\r\n", "<br/>");
		TheGame.TheContent.Append(text);
		if (TheGame.TheContent.ToString() != string.Empty)
		{
			rtcontrol.NavigateToString(TheGame.TheContent.ToString());
		}
	}

	public static void EvaluateString(ref object result, string sStringToEvaluate)
	{
		if (sStringToEvaluate.Trim() == string.Empty)
		{
			result = Eval.JScriptEvaluate((object)(-1), vsaEngine);
			return;
		}
		try
		{
			if (vsaEngine == null)
			{
				vsaEngine = VsaEngine.CreateEngine();
			}
			result = Eval.JScriptEvaluate((object)CleanScript(sStringToEvaluate), vsaEngine);
			if (result == null)
			{
				result = "Null value returned from evaluate.";
			}
		}
		catch (Exception ex)
		{
			result = ex.StackTrace;
			if (vsaEngine != null)
			{
				((BaseVsaEngine)vsaEngine).Reset();
			}
		}
	}

	private static string CleanScript(string curscript)
	{
		string empty = string.Empty;
		return curscript.Replace("Scripting.FileSystemObject", string.Empty);
	}

	internal static double EvaluateStringAsDouble(string sStringToEvaluate)
	{
		object result = null;
		EvaluateString(ref result, sStringToEvaluate);
		return Convert.ToDouble(result);
	}

	public SaveLoad()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
	}
}
