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
public class Room : ISerializable
{
	public string Description = "";

	public string SDesc = "";

	public string Name = "";

	public string Group = "None";

	public ArrayList Exits = new ArrayList();

	public ArrayList Actions = new ArrayList();

	public ArrayList CustomProperties = new ArrayList();

	public string RoomPic = "None";

	public string LayeredRoomPic = "None";

	public bool bEnterFirstTime;

	public bool bLeaveFirstTime;

	public Guid UniqueID = Guid.NewGuid();

	public static Guid CurrentRoomGuid = new Guid("00000000-0000-0000-0000-000000000001");

	public static Guid VoidRoomGuid = new Guid("00000000-0000-0000-0000-000000000002");

	public Room()
	{
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
		Exit value2 = new Exit
		{
			Direction = Exit.Directions.North
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.South
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.West
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.East
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.Up
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.Down
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.NorthWest
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.NorthEast
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.SouthWest
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.SouthEast
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.In
		};
		Exits.Add(value2);
		value2 = new Exit
		{
			Direction = Exit.Directions.Out
		};
		Exits.Add(value2);
	}

	public Room(SqlCeDataReader dr)
	{
		Description = dr["Description"].ToString();
		SDesc = dr["SDesc"].ToString();
		Name = dr["Name"].ToString();
		RoomPic = dr["RoomPic"].ToString();
		bEnterFirstTime = (bool)dr["EnterFirstTime"];
		bLeaveFirstTime = (bool)dr["LeaveFirstTime"];
		UniqueID = new Guid(dr["UniqueID"].ToString());
		Group = dr["Group"].ToString();
		LayeredRoomPic = dr["LayeredRoomPic"].ToString();
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from RoomExits where RoomID=@RoomID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@RoomID", UniqueID.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			Exits.Add(new Exit(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from RoomProperties where RoomID=@RoomID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@RoomID", UniqueID.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from RoomActions where RoomID=@RoomID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@RoomID", UniqueID.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			Actions.Add(new Action(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + SDesc.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + Description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + Name.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + Group + "\",");
		A_.Append("\"" + RoomPic + "\",");
		A_.Append("\"" + LayeredRoomPic + "\",");
		A_.Append(bEnterFirstTime.ToString().ToLower() + ",");
		A_.Append(bLeaveFirstTime.ToString().ToLower() + ",");
		A_.Append("\"" + UniqueID.ToString() + "\",");
		A_.Append("[");
		int num = 0;
		foreach (Exit exit in Exits)
		{
			if (num > 0)
			{
				A_.Append(",");
			}
			num++;
			A_.Append("[");
			A_.Append("\"" + exit.Direction.ToString() + "\",");
			A_.Append(exit.bActive.ToString().ToLower() + ",");
			A_.Append("\"" + exit.DestinationRoom + "\",");
			A_.Append("\"" + exit.PortalObjectName + "\"");
			A_.Append("]");
		}
		A_.Append("],");
		A_.Append("[");
		num = 0;
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

	protected Room(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			Description = (string)info.GetValue("Description", Description.GetType());
			SDesc = (string)info.GetValue("SDesc", SDesc.GetType());
			Name = (string)info.GetValue("Name", Name.GetType());
			RoomPic = (string)info.GetValue("RoomPic", RoomPic.GetType());
			Exits = (ArrayList)info.GetValue("Exits", Exits.GetType());
			Actions = (ArrayList)info.GetValue("Actions", Actions.GetType());
			try
			{
				bEnterFirstTime = (bool)info.GetValue("bEnterFirstTime", bEnterFirstTime.GetType());
			}
			catch
			{
				bEnterFirstTime = false;
			}
			try
			{
				bLeaveFirstTime = (bool)info.GetValue("bLeaveFirstTime", bLeaveFirstTime.GetType());
			}
			catch
			{
				bLeaveFirstTime = false;
			}
			try
			{
				UniqueID = (Guid)info.GetValue("UniqueID", UniqueID.GetType());
			}
			catch
			{
				UniqueID = Guid.NewGuid();
			}
			try
			{
				Group = (string)info.GetValue("Group", Group.GetType());
			}
			catch
			{
				Group = "None";
			}
			try
			{
				LayeredRoomPic = (string)info.GetValue("LayeredRoomPic", LayeredRoomPic.GetType());
			}
			catch
			{
				LayeredRoomPic = "None";
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
			throw new Exception("Unhandled exc in room!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("Description", Description, Description.GetType());
		info.AddValue("SDesc", SDesc, SDesc.GetType());
		info.AddValue("Name", Name, Name.GetType());
		info.AddValue("RoomPic", RoomPic, RoomPic.GetType());
		info.AddValue("LayeredRoomPic", LayeredRoomPic, LayeredRoomPic.GetType());
		info.AddValue("Exits", Exits, Exits.GetType());
		info.AddValue("Actions", Actions, Actions.GetType());
		info.AddValue("bEnterFirstTime", bEnterFirstTime, bEnterFirstTime.GetType());
		info.AddValue("bLeaveFirstTime", bLeaveFirstTime, bLeaveFirstTime.GetType());
		try
		{
			info.AddValue("UniqueID", UniqueID, UniqueID.GetType());
		}
		catch
		{
			info.AddValue("UniqueID", VoidRoomGuid, VoidRoomGuid.GetType());
		}
		info.AddValue("Group", Group, Group.GetType());
		info.AddValue("CustomProperties", CustomProperties, CustomProperties.GetType());
	}

	public Exit GetExit(Exit.Directions dir)
	{
		for (int i = 0; i < Exits.Count; i++)
		{
			if (((Exit)Exits[i]).Direction == dir)
			{
				return (Exit)Exits[i];
			}
		}
		return null;
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(string.Format("<Room>", Array.Empty<object>()));
		Game.AddXMLSection(ref CurDoc, "Name", Name);
		Game.AddXMLSection(ref CurDoc, "Description", Description);
		Game.AddXMLSection(ref CurDoc, "SDesc", SDesc);
		Game.AddXMLSection(ref CurDoc, "RoomPic", RoomPic);
		Game.AddXMLSection(ref CurDoc, "UniqueID", UniqueID.ToString());
		Game.AddXMLSection(ref CurDoc, "Group", Group.ToString());
		CurDoc.WriteLine("<Exits>");
		foreach (Exit exit in Exits)
		{
			exit.GetXMLData(ref CurDoc);
		}
		CurDoc.WriteLine("</Exits>");
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
		CurDoc.WriteLine("</Room>");
	}

	public string GetAdvancedText()
	{
		StringBuilder CurDoc = new StringBuilder();
		CurDoc.Append(string.Format("<Room>\\r\\n", Array.Empty<object>()));
		Game.AddAdvSection(ref CurDoc, "Name", Name);
		Game.AddAdvSection(ref CurDoc, "Description", Description);
		Game.AddAdvSection(ref CurDoc, "SDesc", SDesc);
		Game.AddAdvSection(ref CurDoc, "RoomPic", RoomPic);
		Game.AddAdvSection(ref CurDoc, "UniqueID", UniqueID.ToString());
		Game.AddAdvSection(ref CurDoc, "Group", Group.ToString());
		CurDoc.Append("<Exits>\r\n");
		foreach (Exit exit in Exits)
		{
			exit.GetAdvancedText(ref CurDoc);
		}
		CurDoc.Append("</Exits>\r\n");
		if (Actions.Count > 0)
		{
			CurDoc.Append("<Actions>\r\n");
			foreach (Action action in Actions)
			{
				action.GetAdvancedText(ref CurDoc);
			}
			CurDoc.Append("</Actions>\r\n");
		}
		CurDoc.Append("<CustomProperties>");
		foreach (CustomProperty customProperty in CustomProperties)
		{
			customProperty.GetXMLData(ref CurDoc);
		}
		CurDoc.Append("</CustomProperties>\r\n");
		CurDoc.Append("</Room>\r\n");
		return CurDoc.ToString();
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
		xMLSection = Game.GetXMLSection(ref CurNode, "SDesc");
		if (xMLSection != null)
		{
			SDesc = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "RoomPic");
		if (xMLSection != null)
		{
			RoomPic = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "UniqueID");
		if (xMLSection != null)
		{
			UniqueID = new Guid(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Group");
		if (xMLSection != null)
		{
			Group = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Exits");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Exit exit = new Exit();
				exit.SetXMLData(ref CurNode2, TheGame);
				int num = -1;
				foreach (Exit exit2 in Exits)
				{
					num++;
					if (exit2.Direction == exit.Direction)
					{
						Exits.Remove(exit2);
						Exits.Insert(num, exit);
						break;
					}
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Actions");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Action action = new Action();
				action.SetXMLData(ref CurNode3);
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
		if (TheGame.RoomList.Count > 0)
		{
			foreach (CustomProperty customProperty3 in (TheGame.RoomList[0] as Room).CustomProperties)
			{
				CustomProperties.Add(customProperty3);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection == null)
		{
			return;
		}
		for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
		{
			XmlNode CurNode4 = xMLSection.ChildNodes[k];
			CustomProperty customProperty = new CustomProperty();
			customProperty.SetXMLData(ref CurNode4);
			bool flag = true;
			foreach (CustomProperty customProperty4 in CustomProperties)
			{
				if (customProperty4.Name == customProperty.Name)
				{
					CustomProperties.Remove(customProperty4);
					flag = false;
					break;
				}
			}
			if (flag)
			{
				foreach (Room room in TheGame.RoomList)
				{
					room.CustomProperties.Add(customProperty);
				}
			}
			else
			{
				CustomProperties.Add(customProperty);
			}
		}
	}

	public Action GetActionByName(string actionname)
	{
		if (Actions != null)
		{
			for (int i = 0; i < Actions.Count; i++)
			{
				if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) == 0)
				{
					return (Action)Actions[i];
				}
			}
		}
		return null;
	}

	public string GetName()
	{
		if (SDesc.Trim().Length > 0)
		{
			return SDesc;
		}
		return Name;
	}

	internal void a()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Rooms values(@UniqueID,@Description,\r\n                        @SDesc,@Name,@RoomPic,\r\n                        @EnterFirstTime,@LeaveFirstTime,@Group,@LayeredRoomPic)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@UniqueID", UniqueID.ToString());
		sqlCeCommand.Parameters.AddWithValue("@Description", Description);
		sqlCeCommand.Parameters.AddWithValue("@SDesc", SDesc);
		sqlCeCommand.Parameters.AddWithValue("@Name", Name);
		sqlCeCommand.Parameters.AddWithValue("@RoomPic", RoomPic);
		sqlCeCommand.Parameters.AddWithValue("@EnterFirstTime", bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@LeaveFirstTime", bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@Group", Group);
		sqlCeCommand.Parameters.AddWithValue("@LayeredRoomPic", LayeredRoomPic);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Action action in Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into RoomActions (RoomID,Data) values(@RoomID,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@RoomID", UniqueID.ToString());
			StringBuilder CurDoc = new StringBuilder();
			action.GetXMLData(ref CurDoc);
			string value = TextHandlers.Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into RoomProperties (RoomID,Name,Value) values(@RoomID,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@RoomID", UniqueID.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (Exit exit in Exits)
		{
			sqlCeCommand = new SqlCeCommand("insert into RoomExits (RoomID,Direction,Active,\r\n                        DestinationRoom,PortalObjectName) values(@RoomID,@Direction,@Active,\r\n                        @DestinationRoom,@PortalObjectName)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@RoomID", UniqueID.ToString());
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

	public void FixExits()
	{
		Exit exit = null;
		if (GetExit(Exit.Directions.North) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.North;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.South) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.South;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.East) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.East;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.West) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.West;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Up) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.Up;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Down) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.Down;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.NorthWest) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.NorthWest;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.NorthEast) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.NorthEast;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.SouthWest) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.SouthWest;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.SouthEast) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.SouthEast;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.In) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.In;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Out) == null)
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.Out;
			Exits.Add(exit);
		}
	}

	public override string ToString()
	{
		return Name;
	}

	public void UpdateFromSave(Room temproom)
	{
		foreach (Exit exit in temproom.Exits)
		{
			GetExit(exit.Direction)?.a(exit);
		}
		foreach (Action action in temproom.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
		foreach (CustomProperty customProperty3 in temproom.CustomProperties)
		{
			foreach (CustomProperty customProperty4 in CustomProperties)
			{
				if (customProperty4.Name == customProperty3.Name)
				{
					customProperty4.Value = customProperty3.Value;
				}
			}
		}
		bEnterFirstTime = temproom.bEnterFirstTime;
		bLeaveFirstTime = temproom.bLeaveFirstTime;
	}
}
