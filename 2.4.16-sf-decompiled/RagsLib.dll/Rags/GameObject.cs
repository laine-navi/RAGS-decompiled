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
public sealed class GameObject : ISerializable
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

	public static Guid SelfObjectGuid = new Guid(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65795));

	public LocationType locationtype;

	public Guid UniqueIdentifier = Guid.NewGuid();

	public string locationname = "";

	public string GroupName = string.Empty;

	public string name = "";

	public string description = "";

	public string sdesc = "";

	public string preposition = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51788);

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

	public GameObject()
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
	}

	public GameObject(SqlCeDataReader dr)
	{
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected Obj, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected Obj, but got Unknown
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Expected Obj, but got Unknown
		UniqueIdentifier = new Guid(((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61033)].ToString());
		name = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173)].ToString();
		description = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328)].ToString();
		sdesc = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563)].ToString();
		preposition = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1305)].ToString();
		locationname = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63011)].ToString();
		locationtype = (LocationType)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62986)];
		bCarryable = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1370)];
		bWearable = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1389)];
		bLockable = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1460)];
		bEnterable = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1505)];
		bReadable = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1524)];
		bContainer = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1415)];
		dWeight = (double)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1541)];
		bWorn = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406)];
		bRead = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3345)];
		bLocked = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477)];
		bOpen = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451)];
		bOpenable = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1434)];
		bEntered = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65418)];
		bVisible = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1490)];
		bEnterFirstTime = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57811)];
		bLeaveFirstTime = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57840)];
		GroupName = ((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		bImportant = (bool)((DbDataReader)(object)dr)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1351)];
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65433), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64553), (object)UniqueIdentifier.ToString());
		SqlCeDataReader val2 = val.ExecuteReader();
		while (((DbDataReader)(object)val2).Read())
		{
			__ldtoken(GameObject._002Ector(SqlCeDataReader));
			LayeredZoneLevels.Add(((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)].ToString());
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
		val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65546), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64553), (object)UniqueIdentifier.ToString());
		val2 = val.ExecuteReader();
		while (((DbDataReader)(object)val2).Read())
		{
			__ldtoken(GameObject._002Ector(SqlCeDataReader));
			CustomProperties.Add(new CustomProperty(val2));
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
		val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65645), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64553), (object)UniqueIdentifier.ToString());
		val2 = val.ExecuteReader();
		while (((DbDataReader)(object)val2).Read())
		{
			__ldtoken(GameObject._002Ector(SqlCeDataReader));
			Actions.Add(new Action(((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19655)].ToString()));
		}
		((DbDataReader)(object)val2).Close();
		val2.Dispose();
		((Component)(object)val).Dispose();
	}

	protected GameObject(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		try
		{
			locationname = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64966), locationname.GetType());
			locationtype = (LocationType)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64991), locationtype.GetType());
			name = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65016), name.GetType());
			try
			{
				UniqueIdentifier = (Guid)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62953), UniqueIdentifier.GetType());
			}
			catch
			{
				UniqueIdentifier = Guid.NewGuid();
			}
			description = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65025), description.GetType());
			sdesc = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65048), sdesc.GetType());
			try
			{
				preposition = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65059), preposition.GetType());
			}
			catch
			{
				preposition = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51788);
			}
			Actions = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions.GetType());
			bCarryable = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65082), bCarryable.GetType());
			bWearable = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65103), bWearable.GetType());
			bOpenable = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65122), bOpenable.GetType());
			bLockable = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65141), bLockable.GetType());
			bEnterable = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65160), bEnterable.GetType());
			bReadable = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65181), bReadable.GetType());
			try
			{
				bContainer = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65200), bContainer.GetType());
			}
			catch
			{
				bContainer = false;
			}
			dWeight = (double)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65221), dWeight.GetType());
			bWorn = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65236), bWorn.GetType());
			bRead = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65247), bRead.GetType());
			bLocked = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65258), bLocked.GetType());
			bOpen = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65273), bOpen.GetType());
			bEntered = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65284), bEntered.GetType());
			try
			{
				bVisible = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58163), bVisible.GetType());
			}
			catch
			{
				bVisible = true;
			}
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
				LayeredZoneLevels = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63168), LayeredZoneLevels.GetType());
			}
			catch
			{
				LayeredZoneLevels = new ArrayList();
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
			throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65738), ex.InnerException);
		}
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62936));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), name);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62953), UniqueIdentifier.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62986), locationtype.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63011), locationname);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328), description);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563), sdesc);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1305), preposition);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1370), bCarryable.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1389), bWearable.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1434), bOpenable.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1460), bLockable.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1505), bEnterable.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1524), bReadable.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1415), bContainer.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1541), dWeight.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406), bWorn.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3345), bRead.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477), bLocked.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451), bOpen.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1490), bVisible.ToString());
		if (Actions.Count > 0)
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57448));
			IEnumerator enumerator = Actions.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Action action = (Action)enumerator.Current;
					action.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(GameObject.GetXMLData(ref StreamWriter));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57467));
		}
		if (LayeredZoneLevels.Count > 0)
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63036));
			IEnumerator enumerator2 = LayeredZoneLevels.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					__ldtoken(GameObject.GetXMLData(ref StreamWriter));
					string value = (string)enumerator2.Current;
					Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63075), value);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(GameObject.GetXMLData(ref StreamWriter));
				}
				else
				{
					disposable2.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63108));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57488));
		IEnumerator enumerator3 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(GameObject.GetXMLData(ref StreamWriter));
				CustomProperty customProperty = (CustomProperty)enumerator3.Current;
				customProperty.GetXMLData(ref CurDoc);
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(GameObject.GetXMLData(ref StreamWriter));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57525));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63149));
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62953));
		if (xMLSection != null)
		{
			UniqueIdentifier = new Guid(xMLSection.InnerText);
		}
		else
		{
			UniqueIdentifier = Guid.NewGuid();
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62986));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			locationtype = (LocationType)Enum.Parse(typeof(LocationType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63011));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			locationname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1328));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			description = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1563));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			sdesc = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1305));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			preposition = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1370));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bCarryable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1389));
		if (xMLSection != null)
		{
			bWearable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1434));
		if (xMLSection != null)
		{
			bOpenable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1460));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bLockable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1505));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bEnterable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1524));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bReadable = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1415));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bContainer = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1541));
		if (xMLSection != null)
		{
			dWeight = Convert.ToDouble(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1406));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bWorn = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(3345));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bRead = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1477));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bLocked = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1451));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			bOpen = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1490));
		if (xMLSection != null)
		{
			bVisible = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				__ldtoken(GameObject.SetXMLData(ref XmlNode));
				XmlNode CurNode2 = xMLSection.ChildNodes[i];
				Action action = new Action();
				action.SetXMLData(ref CurNode2);
				{
					IEnumerator enumerator = Actions.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(GameObject.SetXMLData(ref XmlNode));
							Action action2 = (Action)enumerator.Current;
							if (!(action2.name == action.name))
							{
								__ldtoken(GameObject.SetXMLData(ref XmlNode));
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
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63168));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
		}
		else
		{
			LayeredZoneLevels.Clear();
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				__ldtoken(GameObject.SetXMLData(ref XmlNode));
				XmlNode xmlNode = xMLSection.ChildNodes[j];
				LayeredZoneLevels.Add(xmlNode.InnerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316));
		if (xMLSection == null)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
			return;
		}
		for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
		{
			__ldtoken(GameObject.SetXMLData(ref XmlNode));
			XmlNode CurNode3 = xMLSection.ChildNodes[k];
			CustomProperty customProperty = new CustomProperty();
			customProperty.SetXMLData(ref CurNode3);
			CustomProperties.Add(customProperty);
		}
	}

	public void UpdateGroupName()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63203), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19363), (object)UniqueIdentifier.ToString());
		SqlCeDataReader val2 = val.ExecuteReader();
		if (((DbDataReader)(object)val2).Read())
		{
			GroupName = ((DbDataReader)(object)val2)[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		}
	}

	internal void c99c4de57cc28b83b24000ba9447c3a36()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected Obj, but got Unknown
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected Obj, but got Unknown
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected Obj, but got Unknown
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63343), dBConnection);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61648), (object)UniqueIdentifier.ToString());
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), (object)name);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56616), (object)description);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(61667), (object)sdesc);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64115), (object)preposition);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64140), (object)locationname);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64167), (object)locationtype);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64194), (object)bCarryable);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64215), (object)bWearable);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64234), (object)bOpenable);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64253), (object)bLockable);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64272), (object)bEnterable);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64293), (object)bReadable);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64312), (object)bContainer);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64333), (object)dWeight);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64348), (object)bWorn);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64359), (object)bRead);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64370), (object)bLocked);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64385), (object)bOpen);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64396), (object)bEntered);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58548), (object)bVisible);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56694), (object)bEnterFirstTime);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56725), (object)bLeaveFirstTime);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60153), (object)GroupName);
		val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64413), (object)bImportant);
		((DbCommand)(object)val).ExecuteNonQuery();
		((Component)(object)val).Dispose();
		IEnumerator enumerator = Actions.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(GameObject.c99c4de57cc28b83b24000ba9447c3a36());
				Action action = (Action)enumerator.Current;
				val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64434), dBConnection);
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64553), (object)UniqueIdentifier.ToString());
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
				__ldtoken(GameObject.c99c4de57cc28b83b24000ba9447c3a36());
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
				__ldtoken(GameObject.c99c4de57cc28b83b24000ba9447c3a36());
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64568), dBConnection);
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64553), (object)UniqueIdentifier.ToString());
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19644), (object)customProperty.Name);
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57102), (object)customProperty.Value);
				((DbCommand)(object)val).ExecuteNonQuery();
				((Component)(object)val).Dispose();
			}
		}
		finally
		{
			IDisposable disposable3 = enumerator2 as IDisposable;
			if (disposable3 != null)
			{
				disposable3.Dispose();
			}
		}
		IEnumerator enumerator3 = LayeredZoneLevels.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(GameObject.c99c4de57cc28b83b24000ba9447c3a36());
				string text2 = (string)enumerator3.Current;
				val = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64720), dBConnection);
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64553), (object)UniqueIdentifier.ToString());
				val.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(56921), (object)text2);
				((DbCommand)(object)val).ExecuteNonQuery();
				((Component)(object)val).Dispose();
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable2))
			{
				__ldtoken(GameObject.c99c4de57cc28b83b24000ba9447c3a36());
			}
			else
			{
				disposable2.Dispose();
			}
		}
	}

	public override string ToString()
	{
		string text = string.Empty;
		if (locationtype == LocationType.LT_IN_OBJECT)
		{
			__ldtoken(GameObject.ToString());
		}
		else if (locationtype != LocationType.LT_CHARACTER)
		{
			__ldtoken(GameObject.ToString());
			goto IL_003f;
		}
		text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64912);
		goto IL_003f;
		IL_003f:
		if (sdesc.Trim().Length <= 0)
		{
			__ldtoken(GameObject.ToString());
			text += name;
		}
		else if (TheGame == null)
		{
			__ldtoken(GameObject.ToString());
			text += name;
		}
		else
		{
			text += TheGame.PerformTextReplacements(sdesc, null);
		}
		if (bOpenable)
		{
			if (bOpen)
			{
				__ldtoken(GameObject.ToString());
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64917);
			}
		}
		if (bOpenable)
		{
			if (!bOpen)
			{
				__ldtoken(GameObject.ToString());
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64936);
			}
		}
		if (bWorn)
		{
			text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64951);
		}
		return text;
	}

	public string GetDisplayStringNameOnly()
	{
		string text = string.Empty;
		if (preposition.Length > 0)
		{
			text = text + preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528);
		}
		if (sdesc.Trim().Length <= 0)
		{
			__ldtoken(GameObject.GetDisplayStringNameOnly());
			return text + name;
		}
		return text + sdesc;
	}

	public string GetDisplayString()
	{
		string text = string.Empty;
		if (preposition.Length <= 0)
		{
			__ldtoken(GameObject.GetDisplayString());
		}
		else
		{
			text = text + preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528);
		}
		if (sdesc.Trim().Length <= 0)
		{
			__ldtoken(GameObject.GetDisplayString());
			text += name;
		}
		else
		{
			text += sdesc;
		}
		if (!bOpenable)
		{
			__ldtoken(GameObject.GetDisplayString());
		}
		else if (!bOpen)
		{
			text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64917);
		}
		if (bOpenable)
		{
			if (!bOpen)
			{
				__ldtoken(GameObject.GetDisplayString());
			}
			else
			{
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64936);
			}
		}
		if (!bWorn)
		{
			__ldtoken(GameObject.GetDisplayString());
		}
		else
		{
			text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64951);
		}
		return text;
	}

	public string GetDisplayName()
	{
		string empty = string.Empty;
		if (sdesc.Trim().Length <= 0)
		{
			__ldtoken(GameObject.GetDisplayName());
			return empty + name;
		}
		return empty + sdesc;
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info != null)
		{
			__ldtoken(GameObject.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64966), locationname, locationname.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(64991), locationtype, locationtype.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65016), name, name.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(62953), UniqueIdentifier, UniqueIdentifier.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65025), description, description.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65048), sdesc, sdesc.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65059), preposition, preposition.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57165), Actions, Actions.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65082), bCarryable, bCarryable.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65103), bWearable, bWearable.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65122), bOpenable, bOpenable.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65141), bLockable, bLockable.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65160), bEnterable, bEnterable.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65181), bReadable, bReadable.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65200), bContainer, bContainer.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65221), dWeight, dWeight.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65236), bWorn, bWorn.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65247), bRead, bRead.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65258), bLocked, bLocked.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65273), bOpen, bOpen.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65284), bEntered, bEntered.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58163), bVisible, bVisible.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57201), bEnterFirstTime, bEnterFirstTime.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57232), bLeaveFirstTime, bLeaveFirstTime.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(63168), LayeredZoneLevels, LayeredZoneLevels.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316), CustomProperties, CustomProperties.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public Action GetActionByName(string actionname)
	{
		for (int i = 0; i < Actions.Count; i++)
		{
			if (string.Compare(actionname, ((Action)Actions[i]).name, ignoreCase: true) != 0)
			{
				__ldtoken(GameObject.GetActionByName(string));
				continue;
			}
			return (Action)Actions[i];
		}
		return null;
	}

	public string Display(ref ArrayList ObjectList)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(description);
		if (TheGame.bTurnOffNotifications)
		{
			__ldtoken(GameObject.Display(ref ArrayList));
		}
		else
		{
			if (!bOpenable)
			{
				__ldtoken(GameObject.Display(ref ArrayList));
			}
			else if (bOpen)
			{
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65301));
			}
			else
			{
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65330));
			}
			if (!bContainer)
			{
				__ldtoken(GameObject.Display(ref ArrayList));
			}
			else
			{
				if (!bOpenable)
				{
					__ldtoken(GameObject.Display(ref ArrayList));
				}
				else if (!bOpen)
				{
					__ldtoken(GameObject.Display(ref ArrayList));
					goto IL_01f7;
				}
				if (locationtype == LocationType.LT_PORTAL)
				{
					__ldtoken(GameObject.Display(ref ArrayList));
				}
				else
				{
					int num = 0;
					stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65363));
					for (int i = 0; i < ObjectList.Count; i++)
					{
						__ldtoken(GameObject.Display(ref ArrayList));
						GameObject gameObject = (GameObject)ObjectList[i];
						if (gameObject.locationtype != LocationType.LT_IN_OBJECT)
						{
							__ldtoken(GameObject.Display(ref ArrayList));
							continue;
						}
						if (!(gameObject.locationname == UniqueIdentifier.ToString()))
						{
							__ldtoken(GameObject.Display(ref ArrayList));
							continue;
						}
						if (!gameObject.bVisible)
						{
							__ldtoken(GameObject.Display(ref ArrayList));
							continue;
						}
						stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287));
						if (num <= 0)
						{
							__ldtoken(GameObject.Display(ref ArrayList));
						}
						else
						{
							stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65394));
						}
						stringBuilder.Append(gameObject.preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2528) + gameObject.GetDisplayName());
						num++;
					}
					if (num == 0)
					{
						stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287));
						stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65403));
					}
				}
			}
		}
		goto IL_01f7;
		IL_01f7:
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287));
		return stringBuilder.ToString();
	}

	public void UpdateFromSave(GameObject tempobj)
	{
		locationtype = tempobj.locationtype;
		locationname = tempobj.locationname;
		IEnumerator enumerator = tempobj.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(GameObject.UpdateFromSave(GameObject));
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				IEnumerator enumerator2 = CustomProperties.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						__ldtoken(GameObject.UpdateFromSave(GameObject));
						CustomProperty customProperty2 = (CustomProperty)enumerator2.Current;
						if (!(customProperty2.Name == customProperty.Name))
						{
							__ldtoken(GameObject.UpdateFromSave(GameObject));
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
						__ldtoken(GameObject.UpdateFromSave(GameObject));
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
				__ldtoken(GameObject.UpdateFromSave(GameObject));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		IEnumerator enumerator3 = tempobj.Actions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(GameObject.UpdateFromSave(GameObject));
				Action action = (Action)enumerator3.Current;
				Action actionByName = GetActionByName(action.name);
				if (actionByName == null)
				{
					__ldtoken(GameObject.UpdateFromSave(GameObject));
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
				__ldtoken(GameObject.UpdateFromSave(GameObject));
			}
			else
			{
				disposable3.Dispose();
			}
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
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + name.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + UniqueIdentifier.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + locationtype.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + locationname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + description.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + sdesc.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + preposition + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(bCarryable.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bWearable.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bOpenable.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bLockable.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bEnterable.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bReadable.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bContainer.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(dWeight + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bWorn.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bRead.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bLocked.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bOpen.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(bVisible.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		string text = string.Empty;
		int num = 0;
		IEnumerator enumerator = LayeredZoneLevels.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(GameObject.GetJSData());
				string text2 = (string)enumerator.Current;
				if (num <= 0)
				{
					__ldtoken(GameObject.GetJSData());
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929);
				}
				text += text2;
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(GameObject.GetJSData());
			}
			else
			{
				disposable.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22019) + text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22024));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(GameObject.GetJSData());
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
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
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(GameObject.GetJSData());
			}
			else
			{
				disposable2.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		foreach (Action action in Actions)
		{
			if (num <= 0)
			{
				__ldtoken(GameObject.GetJSData());
			}
			else
			{
				stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
			}
			num++;
			action.cc738ece0e9315f0db703b90a443636ff(ref stringBuilder);
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		return stringBuilder.ToString();
	}
}
