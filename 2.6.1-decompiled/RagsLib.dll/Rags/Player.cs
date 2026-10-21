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
public class Player : ISerializable
{
	public enum Gender
	{
		Male,
		Female,
		Other
	}

	public string Name = "";

	public string Description = "";

	public Room StartingRoom;

	public Room CurrentRoom;

	public Gender PlayerGender;

	public bool bPromptForName;

	public bool bPromptForGender;

	public string PlayerPortrait = "";

	public string PlayerLayeredImage = "";

	public ArrayList Actions = new ArrayList();

	public bool bEnforceWeight;

	public double dWeightLimit = 100.5;

	public ArrayList CustomProperties = new ArrayList();

	protected Player(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		Name = (string)info.GetValue("Name", Name.GetType());
		Description = (string)info.GetValue("Description", Description.GetType());
		try
		{
			StartingRoom = (Room)info.GetValue("StartingRoom", typeof(Room));
		}
		catch
		{
			StartingRoom = null;
		}
		try
		{
			CurrentRoom = (Room)info.GetValue("CurrentRoom", typeof(Room));
		}
		catch
		{
			CurrentRoom = null;
		}
		try
		{
			PlayerLayeredImage = (string)info.GetValue("PlayerLayeredImage", PlayerLayeredImage.GetType());
		}
		catch
		{
			PlayerLayeredImage = "";
		}
		PlayerGender = (Gender)info.GetValue("PlayerGender", PlayerGender.GetType());
		bPromptForName = (bool)info.GetValue("bPromptForName", bPromptForName.GetType());
		bPromptForGender = (bool)info.GetValue("bPromptForGender", bPromptForGender.GetType());
		PlayerPortrait = (string)info.GetValue("PlayerPortrait", PlayerPortrait.GetType());
		Actions = (ArrayList)info.GetValue("Actions", Actions.GetType());
		bEnforceWeight = (bool)info.GetValue("bEnforceWeight", bEnforceWeight.GetType());
		dWeightLimit = (double)info.GetValue("dWeightLimit", dWeightLimit.GetType());
		try
		{
			CustomProperties = (ArrayList)info.GetValue("CustomProperties", CustomProperties.GetType());
		}
		catch
		{
			CustomProperties = new ArrayList();
		}
	}

	public void UpdateDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("delete from Player", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("insert into Player values(\r\n                    @Name ,\r\n                    @Description ,\r\n                    @StartingRoom ,\r\n                    @CurrentRoom ,\r\n                    @PlayerLayeredImage ,\r\n                    @PlayerGender ,\r\n                    @PromptForName ,\r\n                    @PromptForGender ,\r\n                    @PlayerPortrait ,\r\n                    @EnforceWeight ,\r\n                    @WeightLimit \r\n                    )", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", Name);
		sqlCeCommand.Parameters.AddWithValue("@Description", Description);
		if (StartingRoom == null)
		{
			sqlCeCommand.Parameters.AddWithValue("@StartingRoom", string.Empty);
		}
		else
		{
			sqlCeCommand.Parameters.AddWithValue("@StartingRoom", StartingRoom.UniqueID.ToString());
		}
		if (CurrentRoom == null)
		{
			sqlCeCommand.Parameters.AddWithValue("@CurrentRoom", string.Empty);
		}
		else
		{
			sqlCeCommand.Parameters.AddWithValue("@CurrentRoom", CurrentRoom.UniqueID.ToString());
		}
		sqlCeCommand.Parameters.AddWithValue("@PlayerLayeredImage", PlayerLayeredImage);
		sqlCeCommand.Parameters.AddWithValue("@PlayerGender", PlayerGender);
		sqlCeCommand.Parameters.AddWithValue("@PromptForName", bPromptForName);
		sqlCeCommand.Parameters.AddWithValue("@PromptForGender", bPromptForGender);
		sqlCeCommand.Parameters.AddWithValue("@PlayerPortrait", PlayerPortrait);
		sqlCeCommand.Parameters.AddWithValue("@EnforceWeight", bEnforceWeight);
		sqlCeCommand.Parameters.AddWithValue("@WeightLimit", dWeightLimit);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("delete from PlayerActions", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Action action in Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into PlayerActions (Data) values(@Data)", dBConnection);
			StringBuilder CurDoc = new StringBuilder();
			action.GetXMLData(ref CurDoc);
			string value = TextHandlers.Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		sqlCeCommand = new SqlCeCommand("delete from PlayerProperties", dBConnection);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (CustomProperty customProperty in CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into PlayerProperties (Name,Value) values(@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("Name", Name, Name.GetType());
		info.AddValue("Description", Description, Description.GetType());
		if (StartingRoom != null)
		{
			info.AddValue("StartingRoom", StartingRoom, StartingRoom.GetType());
		}
		info.AddValue("PlayerGender", PlayerGender, PlayerGender.GetType());
		info.AddValue("bPromptForName", bPromptForName, bPromptForName.GetType());
		info.AddValue("bPromptForGender", bPromptForGender, bPromptForGender.GetType());
		info.AddValue("PlayerPortrait", PlayerPortrait, PlayerPortrait.GetType());
		info.AddValue("PlayerLayeredImage", PlayerLayeredImage, PlayerLayeredImage.GetType());
		info.AddValue("Actions", Actions, Actions.GetType());
		info.AddValue("bEnforceWeight", bEnforceWeight, bEnforceWeight.GetType());
		info.AddValue("dWeightLimit", dWeightLimit, dWeightLimit.GetType());
		if (CurrentRoom != null)
		{
			info.AddValue("CurrentRoom", CurrentRoom, CurrentRoom.GetType());
		}
		info.AddValue("CustomProperties", CustomProperties, CustomProperties.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<Player>");
		Game.AddXMLSection(ref CurDoc, "Name", Name);
		Game.AddXMLSection(ref CurDoc, "Description", Description);
		if (StartingRoom != null)
		{
			Game.AddXMLSection(ref CurDoc, "StartingRoom", StartingRoom.UniqueID.ToString());
		}
		Game.AddXMLSection(ref CurDoc, "PlayerGender", PlayerGender.ToString());
		Game.AddXMLSection(ref CurDoc, "PromptForName", bPromptForName.ToString());
		Game.AddXMLSection(ref CurDoc, "PromptForGender", bPromptForGender.ToString());
		Game.AddXMLSection(ref CurDoc, "PlayerPortrait", PlayerPortrait);
		Game.AddXMLSection(ref CurDoc, "EnforceWeightRestrictions", bEnforceWeight.ToString());
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
		CurDoc.WriteLine("</Player>");
	}

	public void SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			Name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Description");
		if (xMLSection != null)
		{
			Description = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "StartingRoom");
		if (xMLSection != null)
		{
			StartingRoom = TheGame.GetRoomByID(new Guid(xMLSection.InnerText));
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "PlayerGender");
		if (xMLSection != null)
		{
			PlayerGender = (Gender)Enum.Parse(typeof(Gender), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "PromptForName");
		if (xMLSection != null)
		{
			bPromptForName = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "PromptForGender");
		if (xMLSection != null)
		{
			bPromptForGender = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "PlayerPortrait");
		if (xMLSection != null)
		{
			PlayerPortrait = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "EnforceWeightRestrictions");
		if (xMLSection != null)
		{
			bEnforceWeight = Convert.ToBoolean(xMLSection.InnerText);
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

	public Player()
	{
		Action value = new Action
		{
			name = "<<On Game Start>>"
		};
		Actions.Add(value);
		value = new Action
		{
			name = "<<On Player Enter>>"
		};
		Actions.Add(value);
		value = new Action();
		Actions.Add(value);
		value.name = "<<On Player Leave>>";
	}

	public Player(SqlCeDataReader dr)
	{
		Name = dr["Name"].ToString();
		Description = dr["Description"].ToString();
		PlayerLayeredImage = dr["PlayerLayeredImage"].ToString();
		PlayerGender = (Gender)dr["PlayerGender"];
		bPromptForName = (bool)dr["PromptForName"];
		bPromptForGender = (bool)dr["PromptForGender"];
		PlayerPortrait = dr["PlayerPortrait"].ToString();
		bEnforceWeight = (bool)dr["EnforceWeight"];
		dWeightLimit = (double)dr["WeightLimit"];
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from PlayerProperties", dBConnection);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from PlayerActions", dBConnection);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			Actions.Add(new Action(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
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

	public void UpdateFromSave(Player player)
	{
		Name = player.Name;
		Description = player.Description;
		CurrentRoom = player.CurrentRoom;
		PlayerGender = player.PlayerGender;
		PlayerPortrait = player.PlayerPortrait;
		foreach (CustomProperty customProperty3 in player.CustomProperties)
		{
			foreach (CustomProperty customProperty4 in CustomProperties)
			{
				if (customProperty4.Name == customProperty3.Name)
				{
					customProperty4.Value = customProperty3.Value;
				}
			}
		}
		foreach (Action action in player.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + Name + "\",");
		A_.Append("\"" + Description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + StartingRoom.UniqueID.ToString() + "\",");
		A_.Append("\"" + PlayerGender.ToString() + "\",");
		A_.Append("\"" + PlayerLayeredImage + "\",");
		A_.Append(bPromptForName.ToString().ToLower() + ",");
		A_.Append(bPromptForGender.ToString().ToLower() + ",");
		A_.Append("\"" + PlayerPortrait + "\",");
		A_.Append(bEnforceWeight.ToString().ToLower() + ",");
		A_.Append(dWeightLimit + ",");
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
			A_.Append("\"" + customProperty.Name.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
			A_.Append("\"" + customProperty.Value.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\"");
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
