using System;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class StatusBarItem : ISerializable
{
	public string Name = string.Empty;

	public string Text = string.Empty;

	public bool bVisisble = true;

	public int Width;

	public StatusBarItem()
	{
	}

	public StatusBarItem(SqlCeDataReader dr)
	{
		Name = dr["Name"].ToString();
		Text = dr["Text"].ToString();
		bVisisble = (bool)dr["Visible"];
		Width = (int)dr["Width"];
	}

	protected StatusBarItem(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			Name = (string)info.GetValue("Name", Name.GetType());
			Text = (string)info.GetValue("Text", Text.GetType());
			Width = (int)info.GetValue("Width", Width.GetType());
			try
			{
				bVisisble = (bool)info.GetValue("bVisible", bVisisble.GetType());
			}
			catch
			{
				bVisisble = true;
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Unhandled exc in command!", ex.InnerException);
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
		info.AddValue("Text", Text.ToString(), Text.GetType());
		info.AddValue("Width", Width, Width.GetType());
		info.AddValue("bVisible", bVisisble, bVisisble.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine("<StatusBarItem>");
		Game.AddXMLSection(ref CurDoc, "Name", Name);
		Game.AddXMLSection(ref CurDoc, "Text", Text);
		Game.AddXMLSection(ref CurDoc, "Width", Width.ToString());
		Game.AddXMLSection(ref CurDoc, "Visible", bVisisble.ToString());
		CurDoc.WriteLine("</StatusBarItem>");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			Name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Text");
		if (xMLSection != null)
		{
			Text = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Width");
		if (xMLSection != null)
		{
			Width = Convert.ToInt32(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Visible");
		if (xMLSection != null)
		{
			bVisisble = Convert.ToBoolean(xMLSection.InnerText);
		}
	}

	public void UpdateDatabase()
	{
		SqlCeConnection dBConnection = Game.GetDBConnection();
		SqlCeCommand sqlCeCommand = new SqlCeCommand("insert into StatusBarItems\r\n                        (Name,Text,Width,Visible) values(@Name,@Text,\r\n                        @Width,@Visible)", dBConnection);
		sqlCeCommand.Parameters.AddWithValue("@Name", Name);
		sqlCeCommand.Parameters.AddWithValue("@Text", Text);
		sqlCeCommand.Parameters.AddWithValue("@Width", Width);
		sqlCeCommand.Parameters.AddWithValue("@Visible", bVisisble);
		sqlCeCommand.ExecuteNonQuery();
		sqlCeCommand.Dispose();
	}

	public void UpdateFromSave(StatusBarItem tempitem)
	{
		bVisisble = tempitem.bVisisble;
	}

	public string GetJSData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[");
		stringBuilder.Append("\"" + Name + "\",");
		stringBuilder.Append("\"" + Text + "\",");
		stringBuilder.Append(bVisisble.ToString().ToLower() + ",");
		stringBuilder.Append(Width.ToString());
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}
}
