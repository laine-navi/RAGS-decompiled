using System;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class Exit : ISerializable
{
	public enum Directions
	{
		Empty,
		North,
		South,
		East,
		West,
		Up,
		Down,
		NorthEast,
		NorthWest,
		SouthWest,
		SouthEast,
		In,
		Out
	}

	public Directions Direction;

	public bool bActive;

	public string DestinationRoom = string.Empty;

	public string PortalObjectName = "<None>";

	public Exit()
	{
	}

	public Exit(SqlCeDataReader dr)
	{
		Direction = (Directions)dr["Direction"];
		bActive = (bool)dr["Active"];
		DestinationRoom = dr["DestinationRoom"].ToString();
		PortalObjectName = dr["PortalObjectName"].ToString();
	}

	protected Exit(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		Direction = (Directions)info.GetValue("Direction", Direction.GetType());
		bActive = (bool)info.GetValue("bActive", bActive.GetType());
		object obj = null;
		try
		{
			obj = info.GetValue("DestinationRoom", DestinationRoom.GetType());
			DestinationRoom = obj as string;
			if (DestinationRoom == null)
			{
				DestinationRoom = string.Empty;
				try
				{
					Room room = (Room)info.GetValue("DestinationRoom", typeof(Room));
					if (room != null)
					{
						DestinationRoom = room.UniqueID.ToString();
					}
				}
				catch
				{
					DestinationRoom = string.Empty;
				}
			}
		}
		catch
		{
			Room room2 = (Room)info.GetValue("DestinationRoom", typeof(Room));
			if (room2 != null)
			{
				DestinationRoom = room2.UniqueID.ToString();
			}
			else
			{
				DestinationRoom = string.Empty;
			}
		}
		try
		{
			PortalObjectName = (string)info.GetValue("PortalObjectName", PortalObjectName.GetType());
		}
		catch
		{
			PortalObjectName = "<None>";
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("Direction", Direction, Direction.GetType());
		info.AddValue("bActive", bActive, bActive.GetType());
		if (DestinationRoom != null)
		{
			info.AddValue("DestinationRoom", DestinationRoom, DestinationRoom.GetType());
		}
		else
		{
			info.AddValue("DestinationRoom", null);
		}
		info.AddValue("PortalObjectName", PortalObjectName, PortalObjectName.GetType());
	}

	public bool MovePlayer()
	{
		_ = bActive;
		return false;
	}

	public static Directions GetOppositeDir(Directions dir)
	{
		Directions result = Directions.North;
		switch (dir)
		{
		case Directions.North:
			result = Directions.South;
			break;
		case Directions.South:
			result = Directions.North;
			break;
		case Directions.West:
			result = Directions.East;
			break;
		case Directions.East:
			result = Directions.West;
			break;
		case Directions.Up:
			result = Directions.Down;
			break;
		case Directions.Down:
			result = Directions.Up;
			break;
		case Directions.NorthWest:
			result = Directions.SouthEast;
			break;
		case Directions.NorthEast:
			result = Directions.SouthWest;
			break;
		case Directions.SouthWest:
			result = Directions.NorthEast;
			break;
		case Directions.SouthEast:
			result = Directions.NorthWest;
			break;
		case Directions.In:
			result = Directions.Out;
			break;
		case Directions.Out:
			result = Directions.In;
			break;
		}
		return result;
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		if (DestinationRoom != null)
		{
			CurDoc.WriteLine(string.Format("<Exit>", Array.Empty<object>()));
			Game.AddXMLSection(ref CurDoc, "Direction", Direction.ToString());
			Game.AddXMLSection(ref CurDoc, "Active", bActive.ToString());
			if (DestinationRoom != null)
			{
				Game.AddXMLSection(ref CurDoc, "DestinationRoom", DestinationRoom);
			}
			Game.AddXMLSection(ref CurDoc, "PortalObjectName", PortalObjectName);
			CurDoc.WriteLine("</Exit>");
		}
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		if (DestinationRoom != null)
		{
			CurDoc.Append(string.Format("<Exit>\r\n", Array.Empty<object>()));
			Game.AddAdvSection(ref CurDoc, "Direction", Direction.ToString());
			Game.AddAdvSection(ref CurDoc, "Active", bActive.ToString());
			if (DestinationRoom != null)
			{
				Game.AddAdvSection(ref CurDoc, "DestinationRoom", DestinationRoom);
			}
			Game.AddAdvSection(ref CurDoc, "PortalObjectName", PortalObjectName);
			CurDoc.Append("</Exit>\r\n");
		}
	}

	public void SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Direction");
		if (xMLSection != null)
		{
			Direction = (Directions)Enum.Parse(typeof(Directions), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Active");
		if (xMLSection != null)
		{
			bActive = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "PortalObjectName");
		if (xMLSection != null)
		{
			PortalObjectName = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "DestinationRoom");
		if (xMLSection != null)
		{
			DestinationRoom = xMLSection.InnerText;
		}
	}

	internal void a(Exit A_0)
	{
		bActive = A_0.bActive;
	}
}
