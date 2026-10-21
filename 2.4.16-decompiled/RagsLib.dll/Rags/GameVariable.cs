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
public sealed class GameVariable : ISerializable
{
	public enum VarType
	{
		VT_UNINITIALIZED,
		VT_NUMBER,
		VT_STRING,
		VT_DATETIME,
		VT_NUMBERARRAY,
		VT_STRINGARRAY,
		VT_DATETIMEARRAY
	}

	public double dNumType;

	public string dMin = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60664);

	public string dMax = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60671);

	public string sString = "";

	public string varname = "";

	public string GroupName = string.Empty;

	public bool bEnforceRestrictions;

	public DateTime dtDateTime = DateTime.Now;

	public VarType vartype;

	public string VarComment = string.Empty;

	public ArrayList VarArray = new ArrayList();

	public ArrayList CustomProperties = new ArrayList();

	public GameVariable(string vname)
	{
		varname = vname;
	}

	public GameVariable(SqlCeDataReader dr)
	{
		varname = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60682)].ToString();
		sString = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58835)].ToString();
		dNumType = (double)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60697)];
		dMin = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58865)].ToString();
		dMax = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58872)].ToString();
		bEnforceRestrictions = (bool)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58783)];
		VarComment = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60480)].ToString();
		dtDateTime = (DateTime)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60444)];
		vartype = (VarType)dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60712)];
		string xml = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60501)].ToString();
		try
		{
			GroupName = dr[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		}
		catch
		{
			GroupName = string.Empty;
		}
		XmlDocument xmlDocument = new XmlDocument();
		try
		{
			xmlDocument.LoadXml(xml);
			XmlNode firstChild = xmlDocument.FirstChild;
			if (firstChild == null)
			{
				__ldtoken(GameVariable._002Ector(SqlCeDataReader));
			}
			else
			{
				for (int i = 0; i < firstChild.ChildNodes.Count; i++)
				{
					__ldtoken(GameVariable._002Ector(SqlCeDataReader));
					XmlNode xmlNode = firstChild.ChildNodes[i];
					string innerText = xmlNode.InnerText;
					if (innerText.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58904)) <= -1)
					{
						__ldtoken(GameVariable._002Ector(SqlCeDataReader));
						switch (vartype)
						{
						case VarType.VT_DATETIMEARRAY:
							VarArray.Add(Convert.ToDateTime(innerText));
							break;
						case VarType.VT_NUMBERARRAY:
							VarArray.Add(Convert.ToDouble(innerText));
							break;
						case VarType.VT_STRINGARRAY:
							VarArray.Add(innerText);
							break;
						}
					}
					else
					{
						ArrayList arrayList = new ArrayList();
						VarArray.Add(arrayList);
						string[] array = innerText.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58904) }, StringSplitOptions.None);
						string[] array2 = array;
						for (int j = 0; j < array2.Length; j++)
						{
							__ldtoken(GameVariable._002Ector(SqlCeDataReader));
							string value = array2[j];
							arrayList.Add(value);
						}
					}
				}
			}
		}
		catch
		{
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60727), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59963), varname);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			__ldtoken(GameVariable._002Ector(SqlCeDataReader));
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	protected GameVariable(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		try
		{
			dNumType = (double)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60338), dNumType.GetType());
			try
			{
				dMin = info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60355), dMin.GetType()).ToString();
			}
			catch
			{
				dMin = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60664);
			}
			try
			{
				dMax = info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60364), dMax.GetType()).ToString();
			}
			catch
			{
				dMax = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60664);
			}
			sString = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60373), sString.GetType());
			varname = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60388), varname.GetType());
			try
			{
				bEnforceRestrictions = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60403), bEnforceRestrictions.GetType());
			}
			catch
			{
				bEnforceRestrictions = false;
			}
			try
			{
				VarComment = info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60480), VarComment.GetType()).ToString();
			}
			catch
			{
				VarComment = string.Empty;
			}
			try
			{
				dtDateTime = (DateTime)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60444), dtDateTime.GetType());
			}
			catch
			{
				dtDateTime = DateTime.Now;
			}
			vartype = (VarType)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60465), vartype.GetType());
			try
			{
				VarArray = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60501), VarArray.GetType());
			}
			catch
			{
				VarArray = new ArrayList();
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
			throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60838), ex.InnerException);
		}
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58738));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), varname);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58759), VarComment);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58774), vartype.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58783), bEnforceRestrictions.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58822), dNumType.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58835), sString);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58848), dtDateTime.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58865), dMin.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58872), dMax.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374), GroupName.ToString());
		if (VarArray.Count <= 0)
		{
			__ldtoken(GameVariable.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58879));
			for (int i = 0; i < VarArray.Count; i++)
			{
				__ldtoken(GameVariable.GetXMLData(ref StreamWriter));
				if (!(VarArray[i] is ArrayList))
				{
					__ldtoken(GameVariable.GetXMLData(ref StreamWriter));
					Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58919), VarArray[i].ToString());
					continue;
				}
				string text = string.Empty;
				int num = 0;
				{
					IEnumerator enumerator = ((ArrayList)VarArray[i]).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(GameVariable.GetXMLData(ref StreamWriter));
							string text2 = (string)enumerator.Current;
							if (num <= 0)
							{
								__ldtoken(GameVariable.GetXMLData(ref StreamWriter));
							}
							else
							{
								text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58904);
							}
							text += text2;
							num++;
						}
					}
					finally
					{
						IDisposable disposable2 = enumerator as IDisposable;
						if (disposable2 != null)
						{
							disposable2.Dispose();
						}
					}
				}
				Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58919), text);
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58938));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57488));
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(GameVariable.GetXMLData(ref StreamWriter));
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				customProperty.GetXMLData(ref CurDoc);
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable))
			{
				__ldtoken(GameVariable.GetXMLData(ref StreamWriter));
			}
			else
			{
				disposable.Dispose();
			}
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57525));
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58965));
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			varname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58759));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			VarComment = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58774));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			vartype = (VarType)Enum.Parse(typeof(VarType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58783));
		if (xMLSection != null)
		{
			bEnforceRestrictions = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58822));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			dNumType = Convert.ToDouble(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58865));
		if (xMLSection != null)
		{
			dMin = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58872));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			dMax = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374));
		if (xMLSection != null)
		{
			GroupName = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58835));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			sString = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58848));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			dtDateTime = Convert.ToDateTime(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58988));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				__ldtoken(GameVariable.SetXMLData(ref XmlNode));
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				string innerText = xmlNode.InnerText;
				if (innerText.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58904)) <= -1)
				{
					__ldtoken(GameVariable.SetXMLData(ref XmlNode));
					switch (vartype)
					{
					case VarType.VT_DATETIMEARRAY:
						VarArray.Add(Convert.ToDateTime(innerText));
						break;
					case VarType.VT_NUMBERARRAY:
						VarArray.Add(Convert.ToDouble(innerText));
						break;
					case VarType.VT_STRINGARRAY:
						VarArray.Add(innerText);
						break;
					}
				}
				else
				{
					ArrayList arrayList = new ArrayList();
					VarArray.Add(arrayList);
					string[] array = innerText.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58904) }, StringSplitOptions.None);
					string[] array2 = array;
					for (int j = 0; j < array2.Length; j++)
					{
						__ldtoken(GameVariable.SetXMLData(ref XmlNode));
						string value = array2[j];
						arrayList.Add(value);
					}
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316));
		if (xMLSection == null)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
			return;
		}
		for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
		{
			__ldtoken(GameVariable.SetXMLData(ref XmlNode));
			XmlNode CurNode2 = xMLSection.ChildNodes[k];
			CustomProperty customProperty = new CustomProperty();
			customProperty.SetXMLData(ref CurNode2);
			CustomProperties.Add(customProperty);
		}
	}

	public void UpdateDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59009), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59963), varname);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59980), sString);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59995), dNumType);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60012), dMin);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60021), dMax);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60030), bEnforceRestrictions);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60071), VarComment);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60094), dtDateTime);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60117), vartype);
		StringBuilder CurDoc = new StringBuilder();
		if (VarArray.Count <= 0)
		{
			__ldtoken(GameVariable.UpdateDatabase());
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58879));
			for (int i = 0; i < VarArray.Count; i++)
			{
				__ldtoken(GameVariable.UpdateDatabase());
				if (!(VarArray[i] is ArrayList))
				{
					__ldtoken(GameVariable.UpdateDatabase());
					Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58919), VarArray[i].ToString());
					continue;
				}
				string text = string.Empty;
				int num = 0;
				IEnumerator enumerator = ((ArrayList)VarArray[i]).GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(GameVariable.UpdateDatabase());
						string text2 = (string)enumerator.Current;
						if (num <= 0)
						{
							__ldtoken(GameVariable.UpdateDatabase());
						}
						else
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58904);
						}
						text += text2;
						num++;
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(GameVariable.UpdateDatabase());
					}
					else
					{
						disposable.Dispose();
					}
				}
				Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58919), text);
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(58938));
		}
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60134), CurDoc.ToString());
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60153), GroupName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		IEnumerator enumerator2 = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				CustomProperty customProperty = (CustomProperty)enumerator2.Current;
				sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60174), dBConnection);
				sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(59963), varname);
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
				__ldtoken(GameVariable.UpdateDatabase());
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
		if (info != null)
		{
			__ldtoken(GameVariable.GetObjectData(SerializationInfo, StreamingContext));
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60338), dNumType, dNumType.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60355), dMin, dMin.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60364), dMax, dMax.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60373), sString, sString.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60388), varname, varname.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60403), bEnforceRestrictions, bEnforceRestrictions.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60444), dtDateTime, dtDateTime.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60465), vartype, vartype.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60480), VarComment, VarComment.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60501), VarArray, VarArray.GetType());
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57316), CustomProperties, CustomProperties.GetType());
			return;
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	public void UpdateGroupName()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(60518), dBConnection);
		sqlCeCommand.Parameters.AddWithValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19363), varname.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (!sqlCeDataReader.Read())
		{
			__ldtoken(GameVariable.UpdateGroupName());
		}
		else
		{
			GroupName = sqlCeDataReader[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19374)].ToString();
		}
	}

	public void UpdateFromSave(GameVariable tempvar)
	{
		dNumType = tempvar.dNumType;
		sString = tempvar.sString;
		dtDateTime = tempvar.dtDateTime;
		VarArray = tempvar.VarArray;
		IEnumerator enumerator = tempvar.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(GameVariable.UpdateFromSave(GameVariable));
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				foreach (CustomProperty customProperty2 in CustomProperties)
				{
					if (!(customProperty2.Name == customProperty.Name))
					{
						__ldtoken(GameVariable.UpdateFromSave(GameVariable));
					}
					else
					{
						customProperty2.Value = customProperty.Value;
					}
				}
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

	private string c7ee52cf6e2d0bf2a3ce55b4c09a672fd()
	{
		bool flag = false;
		bool flag2 = true;
		switch (vartype)
		{
		case VarType.VT_NUMBERARRAY:
			flag2 = false;
			flag = true;
			break;
		case VarType.VT_STRINGARRAY:
		case VarType.VT_DATETIMEARRAY:
			flag = true;
			break;
		}
		if (!flag)
		{
			return string.Empty;
		}
		string text = string.Empty;
		try
		{
			int num = -1;
			text = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926);
			for (int i = 0; i < VarArray.Count; i++)
			{
				num++;
				if (num <= 0)
				{
					__ldtoken(GameVariable.c7ee52cf6e2d0bf2a3ce55b4c09a672fd());
				}
				else
				{
					text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
				}
				if (!(VarArray[i] is ArrayList arrayList))
				{
					__ldtoken(GameVariable.c7ee52cf6e2d0bf2a3ce55b4c09a672fd());
					text = ((!flag2) ? (text + VarArray[i].ToString()) : (text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + VarArray[i].ToString().Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030))
						.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597))
						.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011)));
					continue;
				}
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926);
				int num2 = -1;
				IEnumerator enumerator = arrayList.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(GameVariable.c7ee52cf6e2d0bf2a3ce55b4c09a672fd());
						object current = enumerator.Current;
						num2++;
						if (num2 > 0)
						{
							text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243);
						}
						if (!flag2)
						{
							__ldtoken(GameVariable.c7ee52cf6e2d0bf2a3ce55b4c09a672fd());
							text += current.ToString();
						}
						else
						{
							text = text + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + current.ToString().Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030))
								.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597))
								.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011);
						}
					}
				}
				finally
				{
					if (!(enumerator is IDisposable disposable))
					{
						__ldtoken(GameVariable.c7ee52cf6e2d0bf2a3ce55b4c09a672fd());
					}
					else
					{
						disposable.Dispose();
					}
				}
				text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
			}
			text += cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932);
		}
		catch
		{
		}
		return text;
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		stringBuilder.Append(dNumType + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + dMin + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + dMax + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + sString.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597))
			.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + varname.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597))
			.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + GroupName + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(bEnforceRestrictions.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + dtDateTime.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + vartype.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + VarComment.ToString().Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030))
			.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57597)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		stringBuilder.Append(c7ee52cf6e2d0bf2a3ce55b4c09a672fd());
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		int num = 0;
		IEnumerator enumerator = CustomProperties.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(GameVariable.GetJSData());
				CustomProperty customProperty = (CustomProperty)enumerator.Current;
				if (num <= 0)
				{
					__ldtoken(GameVariable.GetJSData());
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
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(GameVariable.GetJSData());
			}
			else
			{
				disposable.Dispose();
			}
		}
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		stringBuilder.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		return stringBuilder.ToString();
	}
}
