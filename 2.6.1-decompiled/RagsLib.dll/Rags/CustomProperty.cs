using System;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class CustomProperty : ISerializable
{
	public string Name;

	public string Value;

	public CustomProperty()
	{
		Name = string.Empty;
		Value = string.Empty;
	}

	public CustomProperty(SqlCeDataReader dr)
	{
		Name = dr["Name"].ToString();
		Value = dr["Value"].ToString();
	}

	public CustomProperty(string name, string val)
	{
		Name = name;
		Value = val;
	}

	protected CustomProperty(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			Name = info.GetString("Name");
		}
		catch
		{
			Name = "Unknown";
		}
		try
		{
			Value = info.GetString("Value");
		}
		catch
		{
			Value = string.Empty;
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("Name", Name, Name.GetType());
		info.AddValue("Value", Value, Value.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(string.Format("<CustomProperty>", Array.Empty<object>()));
		Game.AddXMLSection(ref CurDoc, "Name", Name);
		Game.AddXMLSection(ref CurDoc, "Value", Value);
		CurDoc.WriteLine("</CustomProperty>");
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append(string.Format("<CustomProperty>", Array.Empty<object>()));
		Game.AddXMLSection(ref CurDoc, "Name", Name);
		Game.AddXMLSection(ref CurDoc, "Value", Value);
		CurDoc.Append("</CustomProperty>");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			Name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Value");
		if (xMLSection != null)
		{
			Value = xMLSection.InnerText;
		}
	}
}
