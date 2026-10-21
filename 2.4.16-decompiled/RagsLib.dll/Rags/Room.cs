using System;
using System.Collections;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using A;

namespace Rags;

[Serializable]
public sealed class Room : ISerializable
{
	public string Description = "";

	public string SDesc = "";

	public string Name = "";

	public string Group = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);

	public ArrayList Exits = new ArrayList();

	public ArrayList Actions = new ArrayList();

	public ArrayList CustomProperties = new ArrayList();

	public string RoomPic = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);

	public string LayeredRoomPic = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);

	public bool bEnterFirstTime;

	public bool bLeaveFirstTime;

	public Guid UniqueID = Guid.NewGuid();

	public static Guid CurrentRoomGuid = new Guid(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(53584));

	public static Guid VoidRoomGuid = new Guid(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62863));

	public Room()
	{
		Action value = new Action
		{
			name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57611)
		};
		Actions.Add(value);
		value = new Action
		{
			name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57672)
		};
		Actions.Add(value);
		value = new Action();
		Actions.Add(value);
		value.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57711);
		value = new Action();
		Actions.Add(value);
		value.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57772);
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
		Description = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328)].ToString();
		SDesc = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563)].ToString();
		Name = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)].ToString();
		RoomPic = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1574)].ToString();
		bEnterFirstTime = (bool)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57811)];
		bLeaveFirstTime = (bool)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57840)];
		UniqueID = new Guid(dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033)].ToString());
		Group = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61050)].ToString();
		LayeredRoomPic = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60993)].ToString();
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62537), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61860), UniqueID.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			__ldtoken(Room._002Ector(SqlCeDataReader));
			Exits.Add(new Exit(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62626), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61860), UniqueID.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62725), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61860), UniqueID.ToString());
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			__ldtoken(Room._002Ector(SqlCeDataReader));
			Actions.Add(new Action(sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	protected Room(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		try
		{
			Description = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description.GetType());
			SDesc = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563), SDesc.GetType());
			Name = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Name.GetType());
			RoomPic = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1574), RoomPic.GetType());
			Exits = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61022), Exits.GetType());
			Actions = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions.GetType());
			try
			{
				bEnterFirstTime = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57201), bEnterFirstTime.GetType());
			}
			catch
			{
				bEnterFirstTime = false;
			}
			try
			{
				bLeaveFirstTime = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57232), bLeaveFirstTime.GetType());
			}
			catch
			{
				bLeaveFirstTime = false;
			}
			try
			{
				UniqueID = (Guid)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033), UniqueID.GetType());
			}
			catch
			{
				UniqueID = Guid.NewGuid();
			}
			try
			{
				Group = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61050), Group.GetType());
			}
			catch
			{
				Group = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);
			}
			try
			{
				LayeredRoomPic = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60993), LayeredRoomPic.GetType());
			}
			catch
			{
				LayeredRoomPic = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);
			}
			try
			{
				CustomProperties = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316), CustomProperties.GetType());
			}
			catch
			{
				CustomProperties = new ArrayList();
			}
		}
		catch (Exception ex)
		{
			throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62818), ex.InnerException);
		}
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + SDesc.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Description.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Name.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Group + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + RoomPic + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + LayeredRoomPic + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(bEnterFirstTime.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bLeaveFirstTime.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + UniqueID.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		int num = 0;
		IEnumerator enumerator = Exits.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Room.GetJSData());
				Exit exit = (Exit)enumerator.Current;
				if (num > 0)
				{
					stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + exit.Direction.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
				stringBuilder.Append(exit.bActive.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + exit.DestinationRoom + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + exit.PortalObjectName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Room.GetJSData());
			}
			else
			{
				disposable.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				if (num <= 0)
				{
					__ldtoken(Room.GetJSData());
				}
				else
				{
					stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + customProperty.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + customProperty.Value + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Room.GetJSData());
			}
			else
			{
				disposable2.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		IEnumerator enumerator3 = Actions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(Room.GetJSData());
				Action action = (Action)enumerator3.Current;
				if (num <= 0)
				{
					__ldtoken(Room.GetJSData());
				}
				else
				{
					stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				action.cc738ece0e9315f0db703b90a443636ff(ref stringBuilder);
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(Room.GetJSData());
			}
			else
			{
				disposable3.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		return stringBuilder.ToString();
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(Room.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description, Description.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563), SDesc, SDesc.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Name, Name.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1574), RoomPic, RoomPic.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60993), LayeredRoomPic, LayeredRoomPic.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61022), Exits, Exits.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions, Actions.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57201), bEnterFirstTime, bEnterFirstTime.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57232), bLeaveFirstTime, bLeaveFirstTime.GetType());
			try
			{
				info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033), UniqueID, UniqueID.GetType());
			}
			catch
			{
				info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033), VoidRoomGuid, VoidRoomGuid.GetType());
			}
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61050), Group, Group.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316), CustomProperties, CustomProperties.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public Exit GetExit(Exit.Directions dir)
	{
		for (int i = 0; i < Exits.Count; i++)
		{
			if (((Exit)Exits[i]).Direction != dir)
			{
				__ldtoken(Room.GetExit(Exit.Directions));
				continue;
			}
			return (Exit)Exits[i];
		}
		return null;
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61061), new object[0]));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Name);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563), SDesc);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1574), RoomPic);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033), UniqueID.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61050), Group.ToString());
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61074));
		IEnumerator enumerator = Exits.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Room.GetXMLData(ref StreamWriter));
				Exit exit = (Exit)enumerator.Current;
				exit.GetXMLData(ref CurDoc);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Room.GetXMLData(ref StreamWriter));
			}
			else
			{
				disposable.Dispose();
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61089));
		if (Actions.Count <= 0)
		{
			__ldtoken(Room.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57448));
			IEnumerator enumerator2 = Actions.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					Action action = (Action)enumerator2.Current;
					action.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(Room.GetXMLData(ref StreamWriter));
				}
				else
				{
					disposable2.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57467));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57488));
		IEnumerator enumerator3 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				CustomProperty customProperty = (CustomProperty)enumerator3.Current;
				customProperty.GetXMLData(ref CurDoc);
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(Room.GetXMLData(ref StreamWriter));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57525));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61106));
	}

	public string GetAdvancedText()
	{
		StringBuilder CurDoc = new StringBuilder();
		CurDoc.Append(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61121), new object[0]));
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Name);
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description);
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563), SDesc);
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1574), RoomPic);
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033), UniqueID.ToString());
		Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61050), Group.ToString());
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61142));
		IEnumerator enumerator = Exits.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Room.GetAdvancedText());
				Exit exit = (Exit)enumerator.Current;
				exit.GetAdvancedText(ref CurDoc);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Room.GetAdvancedText());
			}
			else
			{
				disposable.Dispose();
			}
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61161));
		if (Actions.Count > 0)
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61182));
			IEnumerator enumerator2 = Actions.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					__ldtoken(Room.GetAdvancedText());
					Action action = (Action)enumerator2.Current;
					action.GetAdvancedText(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(Room.GetAdvancedText());
				}
				else
				{
					disposable2.Dispose();
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61205));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57488));
		IEnumerator enumerator3 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(Room.GetAdvancedText());
				CustomProperty customProperty = (CustomProperty)enumerator3.Current;
				customProperty.GetXMLData(ref CurDoc);
			}
		}
		finally
		{
			IDisposable disposable3 = enumerator3 as IDisposable;
			if (disposable3 != null)
			{
				disposable3.Dispose();
			}
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61230));
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61273));
		return CurDoc.ToString();
	}

	public void SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			Name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328));
		if (xMLSection != null)
		{
			Description = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			SDesc = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1574));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			RoomPic = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			UniqueID = new Guid(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61050));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			Group = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61022));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Exit exit = new Exit();
				exit.SetXMLData(ref CurNode2, TheGame);
				int num = -1;
				IEnumerator enumerator = Exits.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Room.SetXMLData(ref XmlNode, Game));
						Exit exit2 = (Exit)enumerator.Current;
						num++;
						if (exit2.Direction != exit.Direction)
						{
							__ldtoken(Room.SetXMLData(ref XmlNode, Game));
							continue;
						}
						Exits.Remove(exit2);
						Exits.Insert(num, exit);
						break;
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(Room.SetXMLData(ref XmlNode, Game));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				__ldtoken(Room.SetXMLData(ref XmlNode, Game));
				XmlNode CurNode3 = xMLSection.ChildNodes[j];
				Action action = new Action();
				action.SetXMLData(ref CurNode3);
				foreach (Action action2 in Actions)
				{
					if (!(action2.name == action.name))
					{
						__ldtoken(Room.SetXMLData(ref XmlNode, Game));
						continue;
					}
					Actions.Remove(action2);
					break;
				}
				Actions.Add(action);
			}
		}
		if (TheGame.RoomList.Count > 0)
		{
			{
				IEnumerator enumerator3 = (TheGame.RoomList[0] as Room).CustomProperties.GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						__ldtoken(Room.SetXMLData(ref XmlNode, Game));
						CustomProperty value = (CustomProperty)enumerator3.Current;
						CustomProperties.Add(value);
					}
				}
				finally
				{
					IDisposable disposable4 = enumerator3 as IDisposable;
					if (disposable4 != null)
					{
						disposable4.Dispose();
					}
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316));
		if (xMLSection == null)
		{
			__ldtoken(Room.SetXMLData(ref XmlNode, Game));
			return;
		}
		for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
		{
			XmlNode CurNode4 = xMLSection.ChildNodes[k];
			CustomProperty customProperty = new CustomProperty();
			customProperty.SetXMLData(ref CurNode4);
			bool flag = true;
			IEnumerator enumerator4 = CustomProperties.GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					__ldtoken(Room.SetXMLData(ref XmlNode, Game));
					CustomProperty customProperty2 = (CustomProperty)enumerator4.Current;
					if (customProperty2.Name == customProperty.Name)
					{
						CustomProperties.Remove(customProperty2);
						flag = false;
						break;
					}
				}
			}
			finally
			{
				if (!(enumerator4 is IDisposable disposable2))
				{
					__ldtoken(Room.SetXMLData(ref XmlNode, Game));
				}
				else
				{
					disposable2.Dispose();
				}
			}
			if (!flag)
			{
				__ldtoken(Room.SetXMLData(ref XmlNode, Game));
				CustomProperties.Add(customProperty);
				continue;
			}
			IEnumerator enumerator5 = TheGame.RoomList.GetEnumerator();
			try
			{
				while (enumerator5.MoveNext())
				{
					__ldtoken(Room.SetXMLData(ref XmlNode, Game));
					Room room = (Room)enumerator5.Current;
					room.CustomProperties.Add(customProperty);
				}
			}
			finally
			{
				if (!(enumerator5 is IDisposable disposable3))
				{
					__ldtoken(Room.SetXMLData(ref XmlNode, Game));
				}
				else
				{
					disposable3.Dispose();
				}
			}
		}
	}

	public Action GetActionByName(string actionname)
	{
		if (Actions == null)
		{
			__ldtoken(Room.GetActionByName(string));
		}
		else
		{
			for (int i = 0; i < Actions.Count; i++)
			{
				__ldtoken(Room.GetActionByName(string));
				if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) != 0)
				{
					__ldtoken(Room.GetActionByName(string));
					continue;
				}
				return (Action)Actions[i];
			}
		}
		return null;
	}

	public string GetName()
	{
		if (SDesc.Trim().Length <= 0)
		{
			__ldtoken(Room.GetName());
			return Name;
		}
		return SDesc;
	}

	internal void c99c4de57cc28b83b24000ba9447c3a36()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61292), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61648), UniqueID.ToString());
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56616), Description);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61667), SDesc);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), Name);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61680), RoomPic);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56694), bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56725), bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61697), Group);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61710), LayeredRoomPic);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		IEnumerator enumerator = Actions.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Room.c99c4de57cc28b83b24000ba9447c3a36());
				Action action = (Action)enumerator.Current;
				sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61741), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61860), UniqueID.ToString());
				StringBuilder CurDoc = new StringBuilder();
				action.GetXMLData(ref CurDoc);
				string value = TextHandlers.Compress(CurDoc.ToString());
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56921), value);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Room.c99c4de57cc28b83b24000ba9447c3a36());
			}
			else
			{
				disposable.Dispose();
			}
		}
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(Room.c99c4de57cc28b83b24000ba9447c3a36());
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61875), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61860), UniqueID.ToString());
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), customProperty.Name);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57102), customProperty.Value);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Room.c99c4de57cc28b83b24000ba9447c3a36());
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator3 = Exits.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(Room.c99c4de57cc28b83b24000ba9447c3a36());
				Exit exit = (Exit)enumerator3.Current;
				sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62027), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61860), UniqueID.ToString());
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62433), exit.Direction);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62454), exit.bActive);
				if (exit.DestinationRoom != null)
				{
					__ldtoken(Room.c99c4de57cc28b83b24000ba9447c3a36());
				}
				else
				{
					exit.DestinationRoom = string.Empty;
				}
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62469), exit.DestinationRoom);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62502), exit.PortalObjectName);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(Room.c99c4de57cc28b83b24000ba9447c3a36());
			}
			else
			{
				disposable3.Dispose();
			}
		}
	}

	public void FixExits()
	{
		Exit exit = null;
		if (GetExit(Exit.Directions.North) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
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
		if (GetExit(Exit.Directions.East) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.East;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.West) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.West;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Up) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
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
		if (GetExit(Exit.Directions.NorthWest) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.NorthWest;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.NorthEast) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
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
		if (GetExit(Exit.Directions.SouthEast) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.SouthEast;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.In) != null)
		{
			__ldtoken(Room.FixExits());
		}
		else
		{
			exit = new Exit();
			exit.Direction = Exit.Directions.In;
			Exits.Add(exit);
		}
		if (GetExit(Exit.Directions.Out) != null)
		{
			__ldtoken(Room.FixExits());
			return;
		}
		exit = new Exit();
		exit.Direction = Exit.Directions.Out;
		Exits.Add(exit);
	}

	public override string ToString()
	{
		return Name;
	}

	public void UpdateFromSave(Room temproom)
	{
		IEnumerator enumerator = temproom.Exits.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Room.UpdateFromSave(Room));
				Exit exit = (Exit)enumerator.Current;
				GetExit(exit.Direction)?.cf6041572478dfbf6b8008081b026d5c3(exit);
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Room.UpdateFromSave(Room));
			}
			else
			{
				disposable.Dispose();
			}
		}
		IEnumerator enumerator2 = temproom.Actions.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				Action action = (Action)enumerator2.Current;
				Action actionByName = GetActionByName(action.name);
				if (actionByName == null)
				{
					__ldtoken(Room.UpdateFromSave(Room));
				}
				else
				{
					actionByName.cf6041572478dfbf6b8008081b026d5c3(action);
				}
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Room.UpdateFromSave(Room));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator3 = temproom.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(Room.UpdateFromSave(Room));
				CustomProperty customProperty = (CustomProperty)enumerator3.Current;
				IEnumerator enumerator4 = CustomProperties.GetEnumerator();
				try
				{
					while (enumerator4.MoveNext())
					{
						__ldtoken(Room.UpdateFromSave(Room));
						CustomProperty customProperty2 = (CustomProperty)enumerator4.Current;
						if (customProperty2.Name == customProperty.Name)
						{
							customProperty2.Value = customProperty.Value;
						}
					}
				}
				finally
				{
					if (!(enumerator4 is IDisposable disposable3))
					{
						__ldtoken(Room.UpdateFromSave(Room));
					}
					else
					{
						disposable3.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable4))
			{
				__ldtoken(Room.UpdateFromSave(Room));
			}
			else
			{
				disposable4.Dispose();
			}
		}
		bEnterFirstTime = temproom.bEnterFirstTime;
		bLeaveFirstTime = temproom.bLeaveFirstTime;
	}
}
