using System;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using A;

namespace Rags;

[Serializable]
public sealed class Exit : ISerializable
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

	public string PortalObjectName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7072);

	public Exit()
	{
	}

	public Exit(SqlCeDataReader dr)
	{
		Direction = (Directions)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112255)];
		bActive = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736)];
		DestinationRoom = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289)].ToString();
		PortalObjectName = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112320)].ToString();
	}

	protected Exit(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(Exit._002Ector(SerializationInfo, StreamingContext));
			Direction = (Directions)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112255), Direction.GetType());
			bActive = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112274), bActive.GetType());
			object obj = null;
			try
			{
				obj = info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289), DestinationRoom.GetType());
				DestinationRoom = obj as string;
				if (DestinationRoom != null)
				{
					__ldtoken(Exit._002Ector(SerializationInfo, StreamingContext));
				}
				else
				{
					DestinationRoom = string.Empty;
					try
					{
						Room room = (Room)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289), typeof(Room));
						if (room == null)
						{
							__ldtoken(Exit._002Ector(SerializationInfo, StreamingContext));
						}
						else
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
				Room room2 = (Room)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289), typeof(Room));
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
				PortalObjectName = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112320), PortalObjectName.GetType());
				return;
			}
			catch
			{
				PortalObjectName = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7072);
				return;
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(Exit.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112255), Direction, Direction.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112274), bActive, bActive.GetType());
			if (DestinationRoom == null)
			{
				__ldtoken(Exit.GetObjectData(SerializationInfo, StreamingContext));
				info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289), null);
			}
			else
			{
				info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289), DestinationRoom, DestinationRoom.GetType());
			}
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112320), PortalObjectName, PortalObjectName.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public bool MovePlayer()
	{
		bool result = false;
		_ = bActive;
		return result;
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
		if (DestinationRoom == null)
		{
			__ldtoken(Exit.GetXMLData(ref StreamWriter));
			return;
		}
		CurDoc.WriteLine(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112353), new object[0]));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112255), Direction.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736), bActive.ToString());
		if (DestinationRoom == null)
		{
			__ldtoken(Exit.GetXMLData(ref StreamWriter));
		}
		else
		{
			Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289), DestinationRoom);
		}
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112320), PortalObjectName);
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112366));
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		if (DestinationRoom == null)
		{
			__ldtoken(Exit.GetAdvancedText(ref StringBuilder));
			return;
		}
		CurDoc.Append(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112381), new object[0]));
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112255), Direction.ToString());
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736), bActive.ToString());
		if (DestinationRoom == null)
		{
			__ldtoken(Exit.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289), DestinationRoom);
		}
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112320), PortalObjectName);
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112398));
	}

	public void SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112255));
		if (xMLSection == null)
		{
			__ldtoken(Exit.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			Direction = (Directions)Enum.Parse(typeof(Directions), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
		if (xMLSection == null)
		{
			__ldtoken(Exit.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			bActive = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112320));
		if (xMLSection != null)
		{
			PortalObjectName = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112289));
		if (xMLSection != null)
		{
			DestinationRoom = xMLSection.InnerText;
		}
	}

	internal void cf6041572478dfbf6b8008081b026d5c3(Exit P_0)
	{
		bActive = P_0.bActive;
	}
}
