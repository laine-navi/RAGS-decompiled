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
public class GameVariable : ISerializable
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

	public string dMin = "0.0";

	public string dMax = "100.0";

	public string sString = "";

	public string varname = "";

	public string GroupName = string.Empty;

	public bool bEnforceRestrictions;

	public DateTime dtDateTime = DateTime.Now;

	public VarType vartype;

	public string VarComment = string.Empty;

	public ArrayList VarArray = new ArrayList();

	public ArrayList CustomProperties = new ArrayList();

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<Variable>");
		Game.AddXMLSection(ref CurDoc, "Name", varname);
		Game.AddXMLSection(ref CurDoc, "Comment", VarComment);
		Game.AddXMLSection(ref CurDoc, "Type", vartype.ToString());
		Game.AddXMLSection(ref CurDoc, "EnforceRestrictions", bEnforceRestrictions.ToString());
		Game.AddXMLSection(ref CurDoc, "Number", dNumType.ToString());
		Game.AddXMLSection(ref CurDoc, "String", sString);
		Game.AddXMLSection(ref CurDoc, "DateTime", dtDateTime.ToString());
		Game.AddXMLSection(ref CurDoc, "Min", dMin.ToString());
		Game.AddXMLSection(ref CurDoc, "Max", dMax.ToString());
		Game.AddXMLSection(ref CurDoc, "GroupName", GroupName.ToString());
		if (VarArray.Count > 0)
		{
			CurDoc.WriteLine("<ArrayItems>");
			for (int i = 0; i < VarArray.Count; i++)
			{
				if (VarArray[i] is ArrayList)
				{
					string text = string.Empty;
					int num = 0;
					foreach (string item in (ArrayList)VarArray[i])
					{
						if (num > 0)
						{
							text += "*S*E*P*";
						}
						text += item;
						num++;
					}
					Game.AddXMLSection(ref CurDoc, "ArrayItem", text);
				}
				else
				{
					Game.AddXMLSection(ref CurDoc, "ArrayItem", VarArray[i].ToString());
				}
			}
			CurDoc.WriteLine("</ArrayItems>");
		}
		CurDoc.WriteLine("<CustomProperties>");
		foreach (CustomProperty customProperty in CustomProperties)
		{
			customProperty.GetXMLData(ref CurDoc);
		}
		CurDoc.WriteLine("</CustomProperties>");
		CurDoc.WriteLine("</Variable>");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			varname = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Comment");
		if (xMLSection != null)
		{
			VarComment = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Type");
		if (xMLSection != null)
		{
			vartype = (VarType)Enum.Parse(typeof(VarType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "EnforceRestrictions");
		if (xMLSection != null)
		{
			bEnforceRestrictions = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Number");
		if (xMLSection != null)
		{
			dNumType = Convert.ToDouble(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Min");
		if (xMLSection != null)
		{
			dMin = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Max");
		if (xMLSection != null)
		{
			dMax = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "GroupName");
		if (xMLSection != null)
		{
			GroupName = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "String");
		if (xMLSection != null)
		{
			sString = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "DateTime");
		if (xMLSection != null)
		{
			dtDateTime = Convert.ToDateTime(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "ArrayItems");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				string innerText = xMLSection.ChildNodes[i].InnerText;
				if (innerText.IndexOf("*S*E*P*") > -1)
				{
					ArrayList arrayList = new ArrayList();
					VarArray.Add(arrayList);
					string[] array = innerText.Split(new string[1] { "*S*E*P*" }, StringSplitOptions.None);
					foreach (string value in array)
					{
						arrayList.Add(value);
					}
					continue;
				}
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
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomProperties");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[k];
				CustomProperty customProperty = new CustomProperty();
				customProperty.SetXMLData(ref CurNode2);
				CustomProperties.Add(customProperty);
			}
		}
	}

	public GameVariable(string vname)
	{
		varname = vname;
	}

	public GameVariable(SqlCeDataReader dr)
	{
		varname = dr["VarName"].ToString();
		sString = dr["String"].ToString();
		dNumType = (double)dr["NumType"];
		dMin = dr["Min"].ToString();
		dMax = dr["Max"].ToString();
		bEnforceRestrictions = (bool)dr["EnforceRestrictions"];
		VarComment = dr["VarComment"].ToString();
		dtDateTime = (DateTime)dr["dtDateTime"];
		vartype = (VarType)dr["VarType"];
		string xml = dr["VarArray"].ToString();
		try
		{
			GroupName = dr["GroupName"].ToString();
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
			if (firstChild != null)
			{
				for (int i = 0; i < firstChild.ChildNodes.Count; i++)
				{
					string innerText = firstChild.ChildNodes[i].InnerText;
					if (innerText.IndexOf("*S*E*P*") > -1)
					{
						ArrayList arrayList = new ArrayList();
						VarArray.Add(arrayList);
						string[] array = innerText.Split(new string[1] { "*S*E*P*" }, StringSplitOptions.None);
						foreach (string value in array)
						{
							arrayList.Add(value);
						}
						continue;
					}
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
			}
		}
		catch
		{
		}
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("select * from VariableProperties where VarName=@VarName", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@VarName", varname);
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		while (sqlCeDataReader.Read())
		{
			CustomProperties.Add(new CustomProperty(sqlCeDataReader));
		}
		sqlCeDataReader.Close();
		sqlCeDataReader.Dispose();
		sqlCeCommand.Dispose();
	}

	public void UpdateDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into Variables values(\r\n                            @VarName,\r\n                            @String ,\r\n                            @NumType ,\r\n                            @Min ,\r\n                            @Max ,\r\n                            @EnforceRestrictions ,\r\n                            @VarComment ,\r\n                            @dtDateTime,\r\n                            @VarType,\r\n                            @VarArray,\r\n                            @GroupName)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@VarName", varname);
		sqlCeCommand.Parameters.AddWithValue("@String", sString);
		sqlCeCommand.Parameters.AddWithValue("@NumType", dNumType);
		sqlCeCommand.Parameters.AddWithValue("@Min", dMin);
		sqlCeCommand.Parameters.AddWithValue("@Max", dMax);
		sqlCeCommand.Parameters.AddWithValue("@EnforceRestrictions", bEnforceRestrictions);
		sqlCeCommand.Parameters.AddWithValue("@VarComment", VarComment);
		sqlCeCommand.Parameters.AddWithValue("@dtDateTime", dtDateTime);
		sqlCeCommand.Parameters.AddWithValue("@VarType", vartype);
		StringBuilder CurDoc = new StringBuilder();
		if (VarArray.Count > 0)
		{
			CurDoc.Append("<ArrayItems>");
			for (int i = 0; i < VarArray.Count; i++)
			{
				if (VarArray[i] is ArrayList)
				{
					string text = string.Empty;
					int num = 0;
					foreach (string item in (ArrayList)VarArray[i])
					{
						if (num > 0)
						{
							text += "*S*E*P*";
						}
						text += item;
						num++;
					}
					Game.AddXMLSection(ref CurDoc, "ArrayItem", text);
				}
				else
				{
					Game.AddXMLSection(ref CurDoc, "ArrayItem", VarArray[i].ToString());
				}
			}
			CurDoc.Append("</ArrayItems>");
		}
		sqlCeCommand.Parameters.AddWithValue("@VarArray", CurDoc.ToString());
		sqlCeCommand.Parameters.AddWithValue("@GroupName", GroupName);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
		foreach (CustomProperty customProperty in CustomProperties)
		{
			sqlCeCommand = new SqlCeCommand("insert into VariableProperties (VarName,Name,Value) values(@VarName,@Name,@Value)", dBConnection);
			sqlCeCommand.Parameters.AddWithValue("@VarName", varname);
			sqlCeCommand.Parameters.AddWithValue("@Name", customProperty.Name);
			sqlCeCommand.Parameters.AddWithValue("@Value", customProperty.Value);
			sqlCeCommand.ExecuteNonQuery();
			sqlCeCommand.Dispose();
		}
	}

	protected GameVariable(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			dNumType = (double)info.GetValue("dNumType", dNumType.GetType());
			try
			{
				dMin = info.GetValue("dMin", dMin.GetType()).ToString();
			}
			catch
			{
				dMin = "0.0";
			}
			try
			{
				dMax = info.GetValue("dMax", dMax.GetType()).ToString();
			}
			catch
			{
				dMax = "0.0";
			}
			sString = (string)info.GetValue("sString", sString.GetType());
			varname = (string)info.GetValue("varname", varname.GetType());
			try
			{
				bEnforceRestrictions = (bool)info.GetValue("bEnforceRestrictions", bEnforceRestrictions.GetType());
			}
			catch
			{
				bEnforceRestrictions = false;
			}
			try
			{
				VarComment = info.GetValue("VarComment", VarComment.GetType()).ToString();
			}
			catch
			{
				VarComment = string.Empty;
			}
			try
			{
				dtDateTime = (DateTime)info.GetValue("dtDateTime", dtDateTime.GetType());
			}
			catch
			{
				dtDateTime = DateTime.Now;
			}
			vartype = (VarType)info.GetValue("vartype", vartype.GetType());
			try
			{
				VarArray = (ArrayList)info.GetValue("VarArray", VarArray.GetType());
			}
			catch
			{
				VarArray = new ArrayList();
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
			throw new Exception("Unhandled exc in gamevariable!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("dNumType", dNumType, dNumType.GetType());
		info.AddValue("dMin", dMin, dMin.GetType());
		info.AddValue("dMax", dMax, dMax.GetType());
		info.AddValue("sString", sString, sString.GetType());
		info.AddValue("varname", varname, varname.GetType());
		info.AddValue("bEnforceRestrictions", bEnforceRestrictions, bEnforceRestrictions.GetType());
		info.AddValue("dtDateTime", dtDateTime, dtDateTime.GetType());
		info.AddValue("vartype", vartype, vartype.GetType());
		info.AddValue("VarComment", VarComment, VarComment.GetType());
		info.AddValue("VarArray", VarArray, VarArray.GetType());
		info.AddValue("CustomProperties", CustomProperties, CustomProperties.GetType());
	}

	public void UpdateGroupName()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("Select GroupName from Variables\r\n                    where VarName=@name", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@name", varname.ToString());
		SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
		if (sqlCeDataReader.Read())
		{
			GroupName = sqlCeDataReader["GroupName"].ToString();
		}
	}

	public void UpdateFromSave(GameVariable tempvar)
	{
		dNumType = tempvar.dNumType;
		sString = tempvar.sString;
		dtDateTime = tempvar.dtDateTime;
		VarArray = tempvar.VarArray;
		foreach (CustomProperty customProperty3 in tempvar.CustomProperties)
		{
			foreach (CustomProperty customProperty4 in CustomProperties)
			{
				if (customProperty4.Name == customProperty3.Name)
				{
					customProperty4.Value = customProperty3.Value;
				}
			}
		}
	}

	private string a()
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
			text = "[";
			for (int i = 0; i < VarArray.Count; i++)
			{
				num++;
				if (num > 0)
				{
					text += ",";
				}
				if (!(VarArray[i] is ArrayList arrayList))
				{
					text = ((!flag2) ? (text + VarArray[i].ToString()) : (text + "\"" + VarArray[i].ToString().Replace("'", "\\'").Replace("\"", "\\\"")
						.Replace("\r\n", "<br>")
						.Replace("\n", "<br>") + "\""));
					continue;
				}
				text += "[";
				int num2 = -1;
				foreach (object item in arrayList)
				{
					num2++;
					if (num2 > 0)
					{
						text += ",";
					}
					text = ((!flag2) ? (text + item.ToString()) : (text + "\"" + item.ToString().Replace("'", "\\'").Replace("\"", "\\\"")
						.Replace("\r\n", "<br>")
						.Replace("\n", "<br>") + "\""));
				}
				text += "]";
			}
			text += "]";
		}
		catch
		{
		}
		return text;
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		stringBuilder.Append(dNumType + ",");
		stringBuilder.Append("\"" + dMin + "\",");
		stringBuilder.Append("\"" + dMax + "\",");
		stringBuilder.Append("\"" + sString.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>")
			.Replace("\n", "<br>") + "\",");
		stringBuilder.Append("\"" + varname.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r\n", "<br>")
			.Replace("\n", "<br>") + "\",");
		stringBuilder.Append("\"" + GroupName + "\",");
		stringBuilder.Append(bEnforceRestrictions.ToString().ToLower() + ",");
		stringBuilder.Append("\"" + dtDateTime.ToString() + "\",");
		stringBuilder.Append("\"" + vartype.ToString() + "\",");
		stringBuilder.Append("\"" + VarComment.ToString().Replace("'", "\\'").Replace("\"", "\\\"")
			.Replace("\r\n", "<br>") + "\",");
		stringBuilder.Append(a());
		stringBuilder.Append(",");
		stringBuilder.Append("[");
		int num = 0;
		foreach (CustomProperty customProperty in CustomProperties)
		{
			if (num > 0)
			{
				stringBuilder.Append(",");
			}
			num++;
			stringBuilder.Append("[");
			stringBuilder.Append("\"" + customProperty.Name + "\",");
			stringBuilder.Append("\"" + customProperty.Value + "\"");
			stringBuilder.Append("]");
		}
		stringBuilder.Append("]");
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
