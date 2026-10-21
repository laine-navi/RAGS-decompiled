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
public class GameObject : ISerializable
{
	public enum LocationType
	{
		LT_NULL,
		LT_IN_OBJECT,
		LT_ON_OBJECT,
		LT_ROOM,
		LT_PLAYER,
		LT_CHARACTER,
		LT_PORTAL
	}

	public static Game TheGame = null;

	public static Guid SelfObjectGuid = new Guid("00000000-0000-0000-0000-000000000004");

	public LocationType locationtype;

	public Guid UniqueIdentifier = Guid.NewGuid();

	public string locationname = "";

	public string GroupName = string.Empty;

	public string name = "";

	public string description = "";

	public string sdesc = "";

	public string preposition = "a";

	public ArrayList Actions = new ArrayList();

	public ArrayList LayeredZoneLevels = new ArrayList();

	public ArrayList CustomProperties = new ArrayList();

	public bool bCarryable;

	public bool bWearable;

	public bool bOpenable;

	public bool bLockable;

	public bool bEnterable;

	public bool bReadable;

	public bool bContainer;

	public double dWeight;

	public bool bWorn;

	public bool bRead;

	public bool bLocked;

	public bool bOpen;

	public bool bEntered;

	public bool bVisible = true;

	public bool bEnterFirstTime;

	public bool bLeaveFirstTime;

	public bool bImportant;

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<Object>");
		Game.AddXMLSection(ref CurDoc, "Name", name);
		Game.AddXMLSection(ref CurDoc, "UniqueIdentifier", UniqueIdentifier.ToString());
		Game.AddXMLSection(ref CurDoc, "LocationType", locationtype.ToString());
		Game.AddXMLSection(ref CurDoc, "LocationName", locationname);
		Game.AddXMLSection(ref CurDoc, "Description", description);
		Game.AddXMLSection(ref CurDoc, "SDesc", sdesc);
		Game.AddXMLSection(ref CurDoc, "Preposition", preposition);
		Game.AddXMLSection(ref CurDoc, "Carryable", bCarryable.ToString());
		Game.AddXMLSection(ref CurDoc, "Wearable", bWearable.ToString());
		Game.AddXMLSection(ref CurDoc, "Openable", bOpenable.ToString());
		Game.AddXMLSection(ref CurDoc, "Lockable", bLockable.ToString());
		Game.AddXMLSection(ref CurDoc, "Enterable", bEnterable.ToString());
		Game.AddXMLSection(ref CurDoc, "Readable", bReadable.ToString());
		Game.AddXMLSection(ref CurDoc, "Container", bContainer.ToString());
		Game.AddXMLSection(ref CurDoc, "Weight", dWeight.ToString());
		Game.AddXMLSection(ref CurDoc, "Worn", bWorn.ToString());
		Game.AddXMLSection(ref CurDoc, "Read", bRead.ToString());
		Game.AddXMLSection(ref CurDoc, "Locked", bLocked.ToString());
		Game.AddXMLSection(ref CurDoc, "Open", bOpen.ToString());
		Game.AddXMLSection(ref CurDoc, "Visible", bVisible.ToString());
		if (Actions.Count > 0)
		{
			CurDoc.WriteLine("<Actions>");
			foreach (Action action in Actions)
			{
				action.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Actions>");
		}
		if (LayeredZoneLevels.Count > 0)
		{
			CurDoc.WriteLine("<LayeredZoneLevels>");
			foreach (string layeredZoneLevel in LayeredZoneLevels)
			{
				Game.AddXMLSection(ref CurDoc, "LayeredZoneLevel", layeredZoneLevel);
			}
			CurDoc.WriteLine("</LayeredZoneLevels>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in CustomProperties)
		{
			customProperty.GetXMLData(ref CurDoc);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Object>");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "UniqueIdentifier");
		if (xMLSection != null)
		{
			UniqueIdentifier = new Guid(xMLSection.InnerText);
		}
		else
		{
			UniqueIdentifier = Guid.NewGuid();
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "LocationType");
		if (xMLSection != null)
		{
			locationtype = (LocationType)Enum.Parse(typeof(LocationType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "LocationName");
		if (xMLSection != null)
		{
			locationname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Description");
		if (xMLSection != null)
		{
			description = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "SDesc");
		if (xMLSection != null)
		{
			sdesc = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Preposition");
		if (xMLSection != null)
		{
			preposition = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Carryable");
		if (xMLSection != null)
		{
			bCarryable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Wearable");
		if (xMLSection != null)
		{
			bWearable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Openable");
		if (xMLSection != null)
		{
			bOpenable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Lockable");
		if (xMLSection != null)
		{
			bLockable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Enterable");
		if (xMLSection != null)
		{
			bEnterable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Readable");
		if (xMLSection != null)
		{
			bReadable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Container");
		if (xMLSection != null)
		{
			bContainer = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Weight");
		if (xMLSection != null)
		{
			dWeight = Convert.ToDouble(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Worn");
		if (xMLSection != null)
		{
			bWorn = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Read");
		if (xMLSection != null)
		{
			bRead = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Locked");
		if (xMLSection != null)
		{
			bLocked = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Open");
		if (xMLSection != null)
		{
			bOpen = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Visible");
		if (xMLSection != null)
		{
			bVisible = Convert.ToBoolean(xMLSection.InnerText);
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
		xMLSection = Game.GetXMLSection(ref CurNode, "LayeredZoneLevels");
		if (xMLSection != null)
		{
			LayeredZoneLevels.Clear();
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[j];
				LayeredZoneLevels.Add(xmlNode.InnerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[k];
				CustomProperty customProperty = new CustomProperty();
				customProperty.SetXMLData(ref CurNode3);
				CustomProperties.Add(customProperty);
			}
		}
	}

	public GameObject()
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
	}

	public GameObject(SqlCeDataReader dr)
	{
		UniqueIdentifier = new Guid(dr["UniqueID"].ToString());
		name = dr["Name"].ToString();
		description = dr["Description"].ToString();
		sdesc = dr["SDesc"].ToString();
		preposition = dr["Preposition"].ToString();
		locationname = dr["LocationName"].ToString();
		locationtype = (LocationType)dr["LocationType"];
		bCarryable = (bool)dr["Carryable"];
		bWearable = (bool)dr["Wearable"];
		bLockable = (bool)dr["Lockable"];
		bEnterable = (bool)dr["Enterable"];
		bReadable = (bool)dr["Readable"];
		bContainer = (bool)dr["Container"];
		dWeight = (double)dr["Weight"];
		bWorn = (bool)dr["Worn"];
		bRead = (bool)dr["Read"];
		bLocked = (bool)dr["Locked"];
		bOpen = (bool)dr["Open"];
		bOpenable = (bool)dr["Openable"];
		bEntered = (bool)dr["Entered"];
		bVisible = (bool)dr["Visible"];
		bEnterFirstTime = (bool)dr["EnterFirstTime"];
		bLeaveFirstTime = (bool)dr["LeaveFirstTime"];
		GroupName = dr["GroupName"].ToString();
		bImportant = (bool)dr["Important"];
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from ItemLayeredZoneLevels where ItemID=@ItemID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@ItemID", UniqueIdentifier.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			LayeredZoneLevels.Add(sqlCeDataReader["Data"].ToString());
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from ItemProperties where ItemID=@ItemID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@ItemID", UniqueIdentifier.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand("select * from ItemActions where ItemID=@ItemID", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@ItemID", UniqueIdentifier.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			Actions.Add(new Action(sqlCeDataReader["Data"].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	public void UpdateGroupName()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("Select GroupName from Items\r\n                    where UniqueID=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", UniqueIdentifier.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			GroupName = sqlCeDataReader["GroupName"].ToString();
		}
	}

	internal void a()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Items values(@UniqueID,@Name,\r\n                        @Description,@SDesc,@Preposition,@LocationName,@LocationType,\r\n                        @Carryable,@Wearable,@Openable,@Lockable,@Enterable,@Readable,@Container,\r\n                        @Weight,@Worn,@Read,@Locked,@Open,@Entered,@Visible,\r\n                        @EnterFirstTime,@LeaveFirstTime,@GroupName,@Important)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@UniqueID", UniqueIdentifier.ToString());
		sqlCeCommand.Parameters.AddWithValue("@Name", name);
		sqlCeCommand.Parameters.AddWithValue("@Description", description);
		sqlCeCommand.Parameters.AddWithValue("@SDesc", sdesc);
		sqlCeCommand.Parameters.AddWithValue("@Preposition", preposition);
		sqlCeCommand.Parameters.AddWithValue("@LocationName", locationname);
		sqlCeCommand.Parameters.AddWithValue("@LocationType", locationtype);
		sqlCeCommand.Parameters.AddWithValue("@Carryable", bCarryable);
		sqlCeCommand.Parameters.AddWithValue("@Wearable", bWearable);
		sqlCeCommand.Parameters.AddWithValue("@Openable", bOpenable);
		sqlCeCommand.Parameters.AddWithValue("@Lockable", bLockable);
		sqlCeCommand.Parameters.AddWithValue("@Enterable", bEnterable);
		sqlCeCommand.Parameters.AddWithValue("@Readable", bReadable);
		sqlCeCommand.Parameters.AddWithValue("@Container", bContainer);
		sqlCeCommand.Parameters.AddWithValue("@Weight", dWeight);
		sqlCeCommand.Parameters.AddWithValue("@Worn", bWorn);
		sqlCeCommand.Parameters.AddWithValue("@Read", bRead);
		sqlCeCommand.Parameters.AddWithValue("@Locked", bLocked);
		sqlCeCommand.Parameters.AddWithValue("@Open", bOpen);
		sqlCeCommand.Parameters.AddWithValue("@Entered", bEntered);
		sqlCeCommand.Parameters.AddWithValue("@Visible", bVisible);
		sqlCeCommand.Parameters.AddWithValue("@EnterFirstTime", bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@LeaveFirstTime", bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue("@GroupName", GroupName);
		sqlCeCommand.Parameters.AddWithValue("@Important", bImportant);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (Action action in Actions)
		{
			sqlCeCommand = new SqlCeCommand("insert into ItemActions (ItemID,Data) values(@ItemID,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@ItemID", UniqueIdentifier.ToString());
			StringBuilder CurDoc = new StringBuilder();
			action.GetXMLData(ref CurDoc);
			string value = TextHandlers.Compress(CurDoc.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (CustomProperty customProperty in CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into ItemProperties (ItemID,Name,Value) values(@ItemID,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@ItemID", UniqueIdentifier.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
		foreach (string layeredZoneLevel in LayeredZoneLevels)
		{
			sqlCeCommand = new SqlCeCommand("insert into ItemLayeredZoneLevels (ItemID,Data) \r\n                        values(@ItemID,@Data)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@ItemID", UniqueIdentifier.ToString());
			sqlCeCommand.Parameters.AddWithValue("@Data", layeredZoneLevel);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	public override string ToString()
	{
		string text = string.Empty;
		if (locationtype == LocationType.LT_IN_OBJECT || locationtype == LocationType.LT_CHARACTER)
		{
			text += "  ";
		}
		if (sdesc.Trim().Length <= 0)
		{
			text += name;
		}
		else
		{
			text = ((TheGame == null) ? (text + name) : (text + TheGame.PerformTextReplacements(sdesc, null)));
		}
		if (bOpenable && !bOpen)
		{
			text += " (closed)";
		}
		if (bOpenable && bOpen)
		{
			text += " (open)";
		}
		if (bWorn)
		{
			text += " (worn)";
		}
		return text;
	}

	public string GetDisplayStringNameOnly()
	{
		string text = string.Empty;
		if (preposition.Length > 0)
		{
			text = text + preposition + " ";
		}
		if (sdesc.Trim().Length > 0)
		{
			return text + sdesc;
		}
		return text + name;
	}

	public string GetDisplayString()
	{
		string text = string.Empty;
		if (preposition.Length > 0)
		{
			text = text + preposition + " ";
		}
		text = ((sdesc.Trim().Length <= 0) ? (text + name) : (text + sdesc));
		if (bOpenable && !bOpen)
		{
			text += " (closed)";
		}
		if (bOpenable && bOpen)
		{
			text += " (open)";
		}
		if (bWorn)
		{
			text += " (worn)";
		}
		return text;
	}

	public string GetDisplayName()
	{
		string empty = string.Empty;
		if (sdesc.Trim().Length > 0)
		{
			return empty + sdesc;
		}
		return empty + name;
	}

	protected GameObject(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			locationname = (string)info.GetValue("locationname", locationname.GetType());
			locationtype = (LocationType)info.GetValue("locationtype", locationtype.GetType());
			name = (string)info.GetValue("name", name.GetType());
			try
			{
				UniqueIdentifier = (Guid)info.GetValue("UniqueIdentifier", UniqueIdentifier.GetType());
			}
			catch
			{
				UniqueIdentifier = Guid.NewGuid();
			}
			description = (string)info.GetValue("description", description.GetType());
			sdesc = (string)info.GetValue("sdesc", sdesc.GetType());
			try
			{
				preposition = (string)info.GetValue("preposition", preposition.GetType());
			}
			catch
			{
				preposition = "a";
			}
			Actions = (ArrayList)info.GetValue("Actions", Actions.GetType());
			bCarryable = (bool)info.GetValue("bCarryable", bCarryable.GetType());
			bWearable = (bool)info.GetValue("bWearable", bWearable.GetType());
			bOpenable = (bool)info.GetValue("bOpenable", bOpenable.GetType());
			bLockable = (bool)info.GetValue("bLockable", bLockable.GetType());
			bEnterable = (bool)info.GetValue("bEnterable", bEnterable.GetType());
			bReadable = (bool)info.GetValue("bReadable", bReadable.GetType());
			try
			{
				bContainer = (bool)info.GetValue("bContainer", bContainer.GetType());
			}
			catch
			{
				bContainer = false;
			}
			dWeight = (double)info.GetValue("dWeight", dWeight.GetType());
			bWorn = (bool)info.GetValue("bWorn", bWorn.GetType());
			bRead = (bool)info.GetValue("bRead", bRead.GetType());
			bLocked = (bool)info.GetValue("bLocked", bLocked.GetType());
			bOpen = (bool)info.GetValue("bOpen", bOpen.GetType());
			bEntered = (bool)info.GetValue("bEntered", bEntered.GetType());
			try
			{
				bVisible = (bool)info.GetValue("bVisible", bVisible.GetType());
			}
			catch
			{
				bVisible = true;
			}
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
				LayeredZoneLevels = (ArrayList)info.GetValue("LayeredZoneLevels", LayeredZoneLevels.GetType());
			}
			catch
			{
				LayeredZoneLevels = new ArrayList();
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
			throw new Exception("Unhandled exc in gameobject!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("locationname", locationname, locationname.GetType());
		info.AddValue("locationtype", locationtype, locationtype.GetType());
		info.AddValue("name", name, name.GetType());
		info.AddValue("UniqueIdentifier", UniqueIdentifier, UniqueIdentifier.GetType());
		info.AddValue("description", description, description.GetType());
		info.AddValue("sdesc", sdesc, sdesc.GetType());
		info.AddValue("preposition", preposition, preposition.GetType());
		info.AddValue("Actions", Actions, Actions.GetType());
		info.AddValue("bCarryable", bCarryable, bCarryable.GetType());
		info.AddValue("bWearable", bWearable, bWearable.GetType());
		info.AddValue("bOpenable", bOpenable, bOpenable.GetType());
		info.AddValue("bLockable", bLockable, bLockable.GetType());
		info.AddValue("bEnterable", bEnterable, bEnterable.GetType());
		info.AddValue("bReadable", bReadable, bReadable.GetType());
		info.AddValue("bContainer", bContainer, bContainer.GetType());
		info.AddValue("dWeight", dWeight, dWeight.GetType());
		info.AddValue("bWorn", bWorn, bWorn.GetType());
		info.AddValue("bRead", bRead, bRead.GetType());
		info.AddValue("bLocked", bLocked, bLocked.GetType());
		info.AddValue("bOpen", bOpen, bOpen.GetType());
		info.AddValue("bEntered", bEntered, bEntered.GetType());
		info.AddValue("bVisible", bVisible, bVisible.GetType());
		info.AddValue("bEnterFirstTime", bEnterFirstTime, bEnterFirstTime.GetType());
		info.AddValue("bLeaveFirstTime", bLeaveFirstTime, bLeaveFirstTime.GetType());
		info.AddValue("LayeredZoneLevels", LayeredZoneLevels, LayeredZoneLevels.GetType());
		info.AddValue("CustomProperties", CustomProperties, CustomProperties.GetType());
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

	public string Display(ref ArrayList ObjectList)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(description);
		if (!TheGame.bTurnOffNotifications)
		{
			if (bOpenable)
			{
				if (bOpen)
				{
					stringBuilder.Append(".  It is open.");
				}
				else
				{
					stringBuilder.Append(".  It is closed.");
				}
			}
			if (bContainer && (!bOpenable || bOpen) && locationtype != LocationType.LT_PORTAL)
			{
				int num = 0;
				stringBuilder.Append(".  It contains:");
				for (int i = 0; i < ObjectList.Count; i++)
				{
					GameObject gameObject = (GameObject)ObjectList[i];
					if (gameObject.locationtype == LocationType.LT_IN_OBJECT && gameObject.locationname == UniqueIdentifier.ToString() && gameObject.bVisible)
					{
						stringBuilder.Append("\r\n");
						if (num > 0)
						{
							stringBuilder.Append("and ");
						}
						stringBuilder.Append(gameObject.preposition + " " + gameObject.GetDisplayName());
						num++;
					}
				}
				if (num == 0)
				{
					stringBuilder.Append("\r\n");
					stringBuilder.Append("Nothing");
				}
			}
		}
		stringBuilder.Append("\r\n");
		return stringBuilder.ToString();
	}

	public void UpdateFromSave(GameObject tempobj)
	{
		locationtype = tempobj.locationtype;
		locationname = tempobj.locationname;
		foreach (CustomProperty customProperty3 in tempobj.CustomProperties)
		{
			foreach (CustomProperty customProperty4 in CustomProperties)
			{
				if (customProperty4.Name == customProperty3.Name)
				{
					customProperty4.Value = customProperty3.Value;
				}
			}
		}
		foreach (Action action in tempobj.Actions)
		{
			GetActionByName(action.name)?.a(action);
		}
		bWorn = tempobj.bWorn;
		bRead = tempobj.bRead;
		bLocked = tempobj.bLocked;
		bOpen = tempobj.bOpen;
		bEntered = tempobj.bEntered;
		bVisible = tempobj.bVisible;
		bEnterFirstTime = tempobj.bEnterFirstTime;
		bLeaveFirstTime = tempobj.bLeaveFirstTime;
		bImportant = tempobj.bImportant;
	}

	public string GetJSData()
	{
		StringBuilder A_ = new StringBuilder();
		A_.Append("[");
		A_.Append("\"" + name.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + UniqueIdentifier.ToString() + "\",");
		A_.Append("\"" + locationtype.ToString() + "\",");
		A_.Append("\"" + locationname + "\",");
		A_.Append("\"" + description.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + sdesc.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>") + "\",");
		A_.Append("\"" + preposition + "\",");
		A_.Append(bCarryable.ToString().ToLower() + ",");
		A_.Append(bWearable.ToString().ToLower() + ",");
		A_.Append(bOpenable.ToString().ToLower() + ",");
		A_.Append(bLockable.ToString().ToLower() + ",");
		A_.Append(bEnterable.ToString().ToLower() + ",");
		A_.Append(bReadable.ToString().ToLower() + ",");
		A_.Append(bContainer.ToString().ToLower() + ",");
		A_.Append(dWeight + ",");
		A_.Append(bWorn.ToString().ToLower() + ",");
		A_.Append(bRead.ToString().ToLower() + ",");
		A_.Append(bLocked.ToString().ToLower() + ",");
		A_.Append(bOpen.ToString().ToLower() + ",");
		A_.Append(bVisible.ToString().ToLower() + ",");
		string text = string.Empty;
		int num = 0;
		foreach (string layeredZoneLevel in LayeredZoneLevels)
		{
			if (num > 0)
			{
				text += ":";
			}
			text += layeredZoneLevel;
		}
		A_.Append("[\"" + text + "\"],");
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
