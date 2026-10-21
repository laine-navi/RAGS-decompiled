using System;
using System.Collections;
using System.ComponentModel;
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
public sealed class Player : ISerializable
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
		if (info != null)
		{
			__ldtoken(Player._002Ector(SerializationInfo, StreamingContext));
			Name = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Name.GetType());
			Description = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description.GetType());
			try
			{
				StartingRoom = (Room)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47059), typeof(Room));
			}
			catch
			{
				StartingRoom = null;
			}
			try
			{
				CurrentRoom = (Room)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674), typeof(Room));
			}
			catch
			{
				CurrentRoom = null;
			}
			try
			{
				PlayerLayeredImage = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107873), PlayerLayeredImage.GetType());
			}
			catch
			{
				PlayerLayeredImage = "";
			}
			PlayerGender = (Gender)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107757), PlayerGender.GetType());
			bPromptForName = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107782), bPromptForName.GetType());
			bPromptForGender = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107811), bPromptForGender.GetType());
			PlayerPortrait = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107844), PlayerPortrait.GetType());
			Actions = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions.GetType());
			bEnforceWeight = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107910), bEnforceWeight.GetType());
			dWeightLimit = (double)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107939), dWeightLimit.GetType());
			try
			{
				CustomProperties = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316), CustomProperties.GetType());
				return;
			}
			catch
			{
				CustomProperties = new ArrayList();
				return;
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public Player()
	{
		Action value = new Action
		{
			name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108109)
		};
		Actions.Add(value);
		value = new Action
		{
			name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57672)
		};
		Actions.Add(value);
		value = new Action();
		Actions.Add(value);
		value.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57772);
	}

	public Player(SqlCeDataReader dr)
	{
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected Obj, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected Obj, but got Unknown
		Name = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)].ToString();
		Description = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328)].ToString();
		PlayerLayeredImage = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107873)].ToString();
		PlayerGender = (Gender)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107757)];
		bPromptForName = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107981)];
		bPromptForGender = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108008)];
		PlayerPortrait = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107844)].ToString();
		bEnforceWeight = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108144)];
		dWeightLimit = (double)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108171)];
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108194), dBConnection);
		SqlCeDataReader val2 = val.ExecuteReader();
		while (((DbDataReader)(object)val2).Read())
		{
			__ldtoken(Player._002Ector(SqlCeDataReader));
			CustomProperties.Add(new CustomProperty(val2));
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
		val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108255), dBConnection);
		val2 = val.ExecuteReader();
		while (((DbDataReader)(object)val2).Read())
		{
			__ldtoken(Player._002Ector(SqlCeDataReader));
			Actions.Add(new Action(((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)].ToString()));
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
	}

	public void UpdateDatabase()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected Obj, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected Obj, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected Obj, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected Obj, but got Unknown
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106238), dBConnection);
		((DbCommand)(object)val).ExecuteNonQuery();
		((Component)(object)val).Dispose();
		val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(106275), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), (object)Name);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56616), (object)Description);
		if (StartingRoom != null)
		{
			__ldtoken(Player.UpdateDatabase());
			val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107191), (object)StartingRoom.UniqueID.ToString());
		}
		else
		{
			val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107191), (object)string.Empty);
		}
		if (CurrentRoom != null)
		{
			__ldtoken(Player.UpdateDatabase());
			val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56591), (object)CurrentRoom.UniqueID.ToString());
		}
		else
		{
			val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56591), (object)string.Empty);
		}
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107218), (object)PlayerLayeredImage);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107257), (object)PlayerGender);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107284), (object)bPromptForName);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107313), (object)bPromptForGender);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107346), (object)PlayerPortrait);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107377), (object)bEnforceWeight);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107406), (object)dWeightLimit);
		((DbCommand)(object)val).ExecuteNonQuery();
		((Component)(object)val).Dispose();
		val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107431), dBConnection);
		((DbCommand)(object)val).ExecuteNonQuery();
		((Component)(object)val).Dispose();
		IEnumerator enumerator = Actions.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Action action = (Action)enumerator.Current;
				val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107482), dBConnection);
				StringBuilder CurDoc = new StringBuilder();
				action.GetXMLData(ref CurDoc);
				string text = TextHandlers.Compress(CurDoc.ToString());
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56921), (object)text);
				((DbCommand)(object)val).ExecuteNonQuery();
				((Component)(object)val).Dispose();
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Player.UpdateDatabase());
			}
			else
			{
				disposable.Dispose();
			}
		}
		val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107575), dBConnection);
		((DbCommand)(object)val).ExecuteNonQuery();
		((Component)(object)val).Dispose();
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(Player.UpdateDatabase());
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107632), dBConnection);
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), (object)customProperty.Name);
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57102), (object)customProperty.Value);
				((DbCommand)(object)val).ExecuteNonQuery();
				((Component)(object)val).Dispose();
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Player.UpdateDatabase());
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Name, Name.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description, Description.GetType());
		if (StartingRoom == null)
		{
			__ldtoken(Player.GetObjectData(SerializationInfo, StreamingContext));
		}
		else
		{
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47059), StartingRoom, StartingRoom.GetType());
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107757), PlayerGender, PlayerGender.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107782), bPromptForName, bPromptForName.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107811), bPromptForGender, bPromptForGender.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107844), PlayerPortrait, PlayerPortrait.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107873), PlayerLayeredImage, PlayerLayeredImage.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions, Actions.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107910), bEnforceWeight, bEnforceWeight.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107939), dWeightLimit, dWeightLimit.GetType());
		if (CurrentRoom == null)
		{
			__ldtoken(Player.GetObjectData(SerializationInfo, StreamingContext));
		}
		else
		{
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674), CurrentRoom, CurrentRoom.GetType());
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316), CustomProperties, CustomProperties.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107964));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Name);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description);
		if (StartingRoom == null)
		{
			__ldtoken(Player.GetXMLData(ref StreamWriter));
		}
		else
		{
			Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47059), StartingRoom.UniqueID.ToString());
		}
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107757), PlayerGender.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107981), bPromptForName.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108008), bPromptForGender.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107844), PlayerPortrait);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108039), bEnforceWeight.ToString());
		if (Actions.Count <= 0)
		{
			__ldtoken(Player.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57448));
			foreach (Action action in Actions)
			{
				action.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57467));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57488));
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(Player.GetXMLData(ref StreamWriter));
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				customProperty.GetXMLData(ref CurDoc);
			}
		}
		finally
		{
			IDisposable disposable = enumerator2 as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57525));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108090));
	}

	public void SetXMLData(ref XmlNode CurNode, Game TheGame)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			Name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			Description = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(47059));
		if (xMLSection != null)
		{
			StartingRoom = TheGame.GetRoomByID(new Guid(xMLSection.InnerText));
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107757));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			PlayerGender = (Gender)Enum.Parse(typeof(Gender), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107981));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			bPromptForName = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108008));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			bPromptForGender = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(107844));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			PlayerPortrait = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(108039));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			bEnforceWeight = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				__ldtoken(Player.SetXMLData(ref XmlNode, Game));
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Action action = new Action();
				action.SetXMLData(ref CurNode2);
				IEnumerator enumerator = Actions.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Player.SetXMLData(ref XmlNode, Game));
						Action action2 = (Action)enumerator.Current;
						if (!(action2.name == action.name))
						{
							__ldtoken(Player.SetXMLData(ref XmlNode, Game));
							continue;
						}
						Actions.Remove(action2);
						break;
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(Player.SetXMLData(ref XmlNode, Game));
					}
					else
					{
						disposable.Dispose();
					}
				}
				Actions.Add(action);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316));
		if (xMLSection == null)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
			return;
		}
		for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
		{
			__ldtoken(Player.SetXMLData(ref XmlNode, Game));
			XmlNode CurNode3 = xMLSection.ChildNodes[j];
			CustomProperty customProperty = new CustomProperty();
			customProperty.SetXMLData(ref CurNode3);
			CustomProperties.Add(customProperty);
		}
	}

	public Action GetActionByName(string actionname)
	{
		for (int i = 0; i < Actions.Count; i++)
		{
			__ldtoken(Player.GetActionByName(string));
			if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) != 0)
			{
				__ldtoken(Player.GetActionByName(string));
				continue;
			}
			return (Action)Actions[i];
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
		IEnumerator enumerator = player.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Player.UpdateFromSave(Player));
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				IEnumerator enumerator2 = CustomProperties.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(Player.UpdateFromSave(Player));
						CustomProperty customProperty2 = (CustomProperty)enumerator2.Current;
						if (!(customProperty2.Name == customProperty.Name))
						{
							__ldtoken(Player.UpdateFromSave(Player));
						}
						else
						{
							customProperty2.Value = customProperty.Value;
						}
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(Player.UpdateFromSave(Player));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable3 = enumerator as IDisposable;
			if (disposable3 != null)
			{
				disposable3.Dispose();
			}
		}
		IEnumerator enumerator3 = player.Actions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(Player.UpdateFromSave(Player));
				Action action = (Action)enumerator3.Current;
				Action actionByName = GetActionByName(action.name);
				if (actionByName == null)
				{
					__ldtoken(Player.UpdateFromSave(Player));
				}
				else
				{
					actionByName.cf6041572478dfbf6b8008081b026d5c3(action);
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable2))
			{
				__ldtoken(Player.UpdateFromSave(Player));
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Description.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + StartingRoom.UniqueID.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + PlayerGender.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + PlayerLayeredImage + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(bPromptForName.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bPromptForGender.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + PlayerPortrait + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(bEnforceWeight.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(dWeightLimit + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		int num = 0;
		IEnumerator enumerator = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				if (num > 0)
				{
					stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + customProperty.Name.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + customProperty.Value.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Player.GetJSData());
			}
			else
			{
				disposable.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		IEnumerator enumerator2 = Actions.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(Player.GetJSData());
				Action action = (Action)enumerator2.Current;
				if (num <= 0)
				{
					__ldtoken(Player.GetJSData());
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
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Player.GetJSData());
			}
			else
			{
				disposable2.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		return stringBuilder.ToString();
	}
}
