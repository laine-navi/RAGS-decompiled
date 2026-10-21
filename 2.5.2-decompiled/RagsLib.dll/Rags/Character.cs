using System;
using System.Collections;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class Character : ISerializable
{
	public static Game TheGame;

	public string Charname = "";

	public string CharnameOverride = string.Empty;

	public ArrayList Inventory = new ArrayList();

	public ArrayList Actions = new ArrayList();

	public Player.Gender CharGender = Player.Gender.Other;

	public string CurrentRoom = Room.VoidRoomGuid.ToString();

	public string Description = "";

	public string CharPortrait = string.Empty;

	public bool bEnterFirstTime;

	public bool bLeaveFirstTime;

	public bool bAllowInventoryInteraction;

	public ArrayList CustomProperties = new ArrayList();

	public Character(string name)
	{
		Charname = name;
		Action value = new Action
		{
			name = "<<On Player Enter First Time>>"
		};
		Actions.Add(value);
		value = new Action
		{
			name = "<<On Player Enter>>"
		};
		Actions.Add(value);
		value = new Action();
		Actions.Add(value);
		value.name = "<<On Player Leave First Time>>";
		value = new Action();
		Actions.Add(value);
		value.name = "<<On Player Leave>>";
		value = new Action();
		Actions.Add(value);
		value.name = "<<On Character Enter>>";
		value = new Action();
		Actions.Add(value);
		value.name = "<<On Character Leave>>";
	}

	public Character(SqlCeDataReader dr)
	{
		Charname = dr["Charname"].ToString();
		CharnameOverride = dr["CharnameOverride"].ToString();
		CharGender = (Player.Gender)dr["CharGender"];
		CurrentRoom = dr["CurrentRoom"].ToString();
		Description = dr["Description"].ToString();
		bAllowInventoryInteraction = (bool)dr["AllowInventoryInteraction"];
		bEnterFirstTime = (bool)dr["EnterFirstTime"];
		bLeaveFirstTime = (bool)dr["LeaveFirstTime"];
		CharPortrait = dr["CharPortrait"].ToString();
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from CharacterProperties where Charname=@Charname", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Charname", Charname);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from CharacterActions where Charname=@Charname", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Charname", Charname);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			Actions.Add(new Action(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	public override string ToString()
	{
		if (CharnameOverride == string.Empty)
		{
			return Charname;
		}
		if (TheGame == null)
		{
			return Charname;
		}
		return TheGame.PerformTextReplacements(CharnameOverride, null);
	}

	public void UpdateDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Characters values(\r\n                            @Charname,\r\n                            @CharnameOverride ,\r\n                            @CharGender ,\r\n                            @CurrentRoom ,\r\n                            @Description ,\r\n                            @AllowInventoryInteraction ,\r\n                            @EnterFirstTime ,\r\n                            @LeaveFirstTime,\r\n                            @CharPortrait)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Charname", Charname);
		sqlCeCommand.Parameters.AddWithValue("@CharnameOverride", CharnameOverride);
		sqlCeCommand.Parameters.AddWithValue("@CharGender", CharGender);
		sqlCeCommand.Parameters.AddWithValue("@CurrentRoom", CurrentRoom);
		sqlCeCommand.Parameters.AddWithValue("@Description", Description);
		sqlCeCommand.Parameters.AddWithValue("@AllowInventoryInteraction", bAllowInventoryInteraction);
		sqlCeCommand.Parameters.AddWithValue("@EnterFirstTime", bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@LeaveFirstTime", bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@CharPortrait", CharPortrait);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Action action in Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into CharacterActions (Charname,Data) values(@Charname,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Charname", Charname);
			StringBuilder CurDoc = new StringBuilder();
			action.GetXMLData(ref CurDoc);
			string value = TextHandlers.Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into CharacterProperties (Charname,Name,Value) values(@Charname,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Charname", Charname);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	protected Character(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			Charname = (string)info.GetValue("Charname", Charname.GetType());
			try
			{
				CharnameOverride = (string)info.GetValue("CharnameOverride", CharnameOverride.GetType());
			}
			catch
			{
				CharnameOverride = string.Empty;
			}
			Inventory = (ArrayList)info.GetValue("Inventory", Inventory.GetType());
			Actions = (ArrayList)info.GetValue("Actions", Actions.GetType());
			CharGender = (Player.Gender)info.GetValue("CharGender", CharGender.GetType());
			CurrentRoom = (string)info.GetValue("CurrentRoom", CurrentRoom.GetType());
			Description = (string)info.GetValue("Description", Description.GetType());
			try
			{
				bEnterFirstTime = (bool)info.GetValue("bEnterFirstTime", bEnterFirstTime.GetType());
				bLeaveFirstTime = (bool)info.GetValue("bLeaveFirstTime", bLeaveFirstTime.GetType());
				CharPortrait = (string)info.GetValue("CharPortrait", CharPortrait.GetType());
			}
			catch
			{
				bEnterFirstTime = false;
				bLeaveFirstTime = false;
			}
			try
			{
				bAllowInventoryInteraction = (bool)info.GetValue("bAllowInventoryInteraction", bAllowInventoryInteraction.GetType());
			}
			catch
			{
				bAllowInventoryInteraction = false;
			}
			try
			{
				CustomProperties = (ArrayList)info.GetValue("CustomProperties", CustomProperties.GetType());
			}
			catch
			{
				CustomProperties = new ArrayList();
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Unhandled exc in character!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("Charname", Charname, Charname.GetType());
		info.AddValue("CharnameOverride", CharnameOverride, CharnameOverride.GetType());
		info.AddValue("Inventory", Inventory, Inventory.GetType());
		info.AddValue("Actions", Actions, Actions.GetType());
		info.AddValue("CharGender", CharGender, CharGender.GetType());
		info.AddValue("CurrentRoom", CurrentRoom, CurrentRoom.GetType());
		info.AddValue("Description", Description, Description.GetType());
		info.AddValue("bEnterFirstTime", bEnterFirstTime, bEnterFirstTime.GetType());
		info.AddValue("bLeaveFirstTime", bLeaveFirstTime, bLeaveFirstTime.GetType());
		info.AddValue("bAllowInventoryInteraction", bAllowInventoryInteraction, bAllowInventoryInteraction.GetType());
		info.AddValue("CustomProperties", CustomProperties, CustomProperties.GetType());
		info.AddValue("CharPortrait", CharPortrait, CharPortrait.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(string.Format("<Character>", Array.Empty<object>()));
		Game.AddXMLSection(ref CurDoc, "Name", Charname);
		Game.AddXMLSection(ref CurDoc, "NameOverride", CharnameOverride);
		Game.AddXMLSection(ref CurDoc, "CurrentRoom", CurrentRoom.ToString());
		Game.AddXMLSection(ref CurDoc, "Description", Description);
		Game.AddXMLSection(ref CurDoc, "CharPortrait", CharPortrait);
		Game.AddXMLSection(ref CurDoc, "AllowInventoryInteraction", bAllowInventoryInteraction.ToString());
		if (Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Action action in Actions)
			{
				action.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Actions>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in CustomProperties)
		{
			customProperty.GetXMLData(ref CurDoc);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Character>");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			Charname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "NameOverride");
		if (xMLSection != null)
		{
			CharnameOverride = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CurrentRoom");
		if (xMLSection != null)
		{
			CurrentRoom = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Description");
		if (xMLSection != null)
		{
			Description = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CharPortrait");
		if (xMLSection != null)
		{
			CharPortrait = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "AllowInventoryInteraction");
		if (xMLSection != null)
		{
			bAllowInventoryInteraction = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Actions");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Action action = new Action();
				action.SetXMLData(ref CurNode2);
				foreach (Action action2 in Actions)
				{
					if (action2.name == action.name)
					{
						Actions.Remove(action2);
						break;
					}
				}
				Actions.Add(action);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				CustomProperty customProperty = new CustomProperty();
				customProperty.SetXMLData(ref CurNode3);
				CustomProperties.Add(customProperty);
			}
		}
	}

	public Action GetActionByName(string actionname)
	{
		for (int i = 0; i < Actions.Count; i++)
		{
			if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) == 0)
			{
				return (Action)Actions[i];
			}
		}
		return null;
	}

	public void UpdateFromSave(Character SvChar)
	{
		CharnameOverride = SvChar.CharnameOverride;
		CurrentRoom = SvChar.CurrentRoom;
		CharPortrait = SvChar.CharPortrait;
		bEnterFirstTime = SvChar.bEnterFirstTime;
		bLeaveFirstTime = SvChar.bLeaveFirstTime;
		foreach (CustomProperty customProperty3 in SvChar.CustomProperties)
		{
			foreach (CustomProperty customProperty4 in CustomProperties)
			{
				if (customProperty4.Name == customProperty3.Name)
				{
					customProperty4.Value = customProperty3.Value;
				}
			}
		}
		foreach (Action action in SvChar.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + Charname.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_.Append("\"" + CharnameOverride.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_.Append("\"" + Description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + CharGender.ToString() + "\",");
		A_.Append("\"" + CurrentRoom + "\",");
		A_.Append(bAllowInventoryInteraction.ToString().ToLower() + ",");
		A_.Append("\"" + CharPortrait + "\",");
		A_.Append("[");
		int num = 0;
		foreach (CustomProperty customProperty in CustomProperties)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			A_.Append("[");
			A_.Append("\"" + customProperty.Name + "\",");
			A_.Append("\"" + customProperty.Value + "\"");
			A_.Append("]");
		}
		A_.Append("],");
		A_.Append("[");
		num = 0;
		foreach (Action action in Actions)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			action.a(ref A_);
		}
		A_.Append("]");
		A_.Append("]");
		return A_.ToString();
	}
}
