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
public sealed class Character : ISerializable
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
		value = new Action();
		Actions.Add(value);
		value.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50940);
		value = new Action();
		Actions.Add(value);
		value.name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50985);
	}

	public Character(SqlCeDataReader dr)
	{
		Charname = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57115)].ToString();
		CharnameOverride = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57132)].ToString();
		CharGender = (Player.Gender)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57180)];
		CurrentRoom = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674)].ToString();
		Description = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328)].ToString();
		bAllowInventoryInteraction = (bool)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57397)];
		bEnterFirstTime = (bool)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57811)];
		bLeaveFirstTime = (bool)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57840)];
		CharPortrait = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57349)].ToString();
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57869), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56514), Charname);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
		sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57986), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56514), Charname);
		sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			__ldtoken(Character._002Ector(SqlCeDataReader));
			Actions.Add(new Action(sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)].ToString()));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	protected Character(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(Character._002Ector(SerializationInfo, StreamingContext));
			try
			{
				Charname = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57115), Charname.GetType());
				try
				{
					CharnameOverride = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57132), CharnameOverride.GetType());
				}
				catch
				{
					CharnameOverride = string.Empty;
				}
				Inventory = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5771), Inventory.GetType());
				Actions = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions.GetType());
				CharGender = (Player.Gender)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57180), CharGender.GetType());
				CurrentRoom = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674), CurrentRoom.GetType());
				Description = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description.GetType());
				try
				{
					bEnterFirstTime = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57201), bEnterFirstTime.GetType());
					bLeaveFirstTime = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57232), bLeaveFirstTime.GetType());
					CharPortrait = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57349), CharPortrait.GetType());
				}
				catch
				{
					bEnterFirstTime = false;
					bLeaveFirstTime = false;
				}
				try
				{
					bAllowInventoryInteraction = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57263), bAllowInventoryInteraction.GetType());
				}
				catch
				{
					bAllowInventoryInteraction = false;
				}
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
			catch (Exception ex)
			{
				throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58097), ex.InnerException);
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public override string ToString()
	{
		if (!(CharnameOverride == string.Empty))
		{
			__ldtoken(Character.ToString());
			if (TheGame != null)
			{
				__ldtoken(Character.ToString());
				return TheGame.PerformTextReplacements(CharnameOverride, null);
			}
			return Charname;
		}
		return Charname;
	}

	public void UpdateDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(55622), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56514), Charname);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56533), CharnameOverride);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56568), CharGender);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56591), CurrentRoom);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56616), Description);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56641), bAllowInventoryInteraction);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56694), bEnterFirstTime);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56725), bLeaveFirstTime);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56756), CharPortrait);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		IEnumerator enumerator = Actions.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Character.UpdateDatabase());
				Action action = (Action)enumerator.Current;
				sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56783), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56514), Charname);
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
				__ldtoken(Character.UpdateDatabase());
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
				__ldtoken(Character.UpdateDatabase());
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56932), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56514), Charname);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), customProperty.Name);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57102), customProperty.Value);
				sqlCeCommand.ExecuteNonQuery();
				sqlCeCommand.Dispose();
			}
		}
		finally
		{
			IDisposable disposable2 = enumerator2 as IDisposable;
			if (disposable2 != null)
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
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57115), Charname, Charname.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57132), CharnameOverride, CharnameOverride.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(5771), Inventory, Inventory.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions, Actions.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57180), CharGender, CharGender.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674), CurrentRoom, CurrentRoom.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description, Description.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57201), bEnterFirstTime, bEnterFirstTime.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57232), bLeaveFirstTime, bLeaveFirstTime.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57263), bAllowInventoryInteraction, bAllowInventoryInteraction.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316), CustomProperties, CustomProperties.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57349), CharPortrait, CharPortrait.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(string.Format(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57374), new object[0]));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), Charname);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1246), CharnameOverride);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674), CurrentRoom.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), Description);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57349), CharPortrait);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57397), bAllowInventoryInteraction.ToString());
		if (Actions.Count <= 0)
		{
			__ldtoken(Character.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57448));
			IEnumerator enumerator = Actions.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(Character.GetXMLData(ref StreamWriter));
					Action action = (Action)enumerator.Current;
					action.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Character.GetXMLData(ref StreamWriter));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57467));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57488));
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				customProperty.GetXMLData(ref CurDoc);
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Character.GetXMLData(ref StreamWriter));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57525));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57564));
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
		if (xMLSection == null)
		{
			__ldtoken(Character.SetXMLData(ref XmlNode));
		}
		else
		{
			Charname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1246));
		if (xMLSection == null)
		{
			__ldtoken(Character.SetXMLData(ref XmlNode));
		}
		else
		{
			CharnameOverride = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1674));
		if (xMLSection == null)
		{
			__ldtoken(Character.SetXMLData(ref XmlNode));
		}
		else
		{
			CurrentRoom = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328));
		if (xMLSection != null)
		{
			Description = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57349));
		if (xMLSection == null)
		{
			__ldtoken(Character.SetXMLData(ref XmlNode));
		}
		else
		{
			CharPortrait = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57397));
		if (xMLSection != null)
		{
			bAllowInventoryInteraction = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165));
		if (xMLSection == null)
		{
			__ldtoken(Character.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				__ldtoken(Character.SetXMLData(ref XmlNode));
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Action action = new Action();
				action.SetXMLData(ref CurNode2);
				{
					IEnumerator enumerator = Actions.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(Character.SetXMLData(ref XmlNode));
							Action action2 = (Action)enumerator.Current;
							if (!(action2.name == action.name))
							{
								__ldtoken(Character.SetXMLData(ref XmlNode));
								continue;
							}
							Actions.Remove(action2);
							break;
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
				Actions.Add(action);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316));
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				__ldtoken(Character.SetXMLData(ref XmlNode));
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
			if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) != 0)
			{
				__ldtoken(Character.GetActionByName(string));
				continue;
			}
			return (Action)Actions[i];
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
		IEnumerator enumerator = SvChar.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Character.UpdateFromSave(Character));
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				IEnumerator enumerator2 = CustomProperties.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						CustomProperty customProperty2 = (CustomProperty)enumerator2.Current;
						if (!(customProperty2.Name == customProperty.Name))
						{
							__ldtoken(Character.UpdateFromSave(Character));
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
						__ldtoken(Character.UpdateFromSave(Character));
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
			if (!(enumerator is IDisposable disposable2))
			{
				__ldtoken(Character.UpdateFromSave(Character));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator3 = SvChar.Actions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				Action action = (Action)enumerator3.Current;
				Action actionByName = GetActionByName(action.name);
				if (actionByName == null)
				{
					__ldtoken(Character.UpdateFromSave(Character));
				}
				else
				{
					actionByName.cf6041572478dfbf6b8008081b026d5c3(action);
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(Character.UpdateFromSave(Character));
			}
			else
			{
				disposable3.Dispose();
			}
		}
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Charname.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CharnameOverride.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + Description.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CharGender.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CurrentRoom + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(bAllowInventoryInteraction.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CharPortrait + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		int num = 0;
		IEnumerator enumerator = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(Character.GetJSData());
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				if (num > 0)
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
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Character.GetJSData());
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
				__ldtoken(Character.GetJSData());
				Action action = (Action)enumerator2.Current;
				if (num <= 0)
				{
					__ldtoken(Character.GetJSData());
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
				__ldtoken(Character.GetJSData());
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
