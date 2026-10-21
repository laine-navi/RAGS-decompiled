using System;
using System.Xml;
using System.Xml.Serialization;
using Rags.ragsgame.com;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public class XmlSerializationWriterCheckUpdates : XmlSerializationWriter
{
	public void Write4_CheckVersion(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		WriteStartElement("CheckVersion", "http://tempuri.org/", null, writePrefixed: false);
		WriteEndElement();
	}

	public void Write5_CheckVersionInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write6_Register(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		int num = p.Length;
		WriteStartElement("Register", "http://tempuri.org/", null, writePrefixed: false);
		if (num > 0)
		{
			WriteElementString("key", "http://tempuri.org/", (string)p[0]);
		}
		if (num > 1)
		{
			WriteElementString("email", "http://tempuri.org/", (string)p[1]);
		}
		if (num > 2)
		{
			WriteElementString("id", "http://tempuri.org/", (string)p[2]);
		}
		WriteEndElement();
	}

	public void Write7_RegisterInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write8_GetShareDataSummary(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		WriteStartElement("GetShareDataSummary", "http://tempuri.org/", null, writePrefixed: false);
		WriteEndElement();
	}

	public void Write9_GetShareDataSummaryInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write10_DownloadShare(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		int num = p.Length;
		WriteStartElement("DownloadShare", "http://tempuri.org/", null, writePrefixed: false);
		if (num > 0)
		{
			WriteElementStringRaw("index", "http://tempuri.org/", XmlConvert.ToString((int)p[0]));
		}
		WriteEndElement();
	}

	public void Write11_DownloadShareInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write12_UploadShare(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		int num = p.Length;
		WriteStartElement("UploadShare", "http://tempuri.org/", null, writePrefixed: false);
		if (num > 0)
		{
			Write3_ShareData("TheShare", "http://tempuri.org/", (ShareData)p[0], isNullable: false, needType: false);
		}
		if (num > 1)
		{
			WriteElementStringRaw("TheData", "http://tempuri.org/", XmlSerializationWriter.FromByteArrayBase64((byte[])p[1]));
		}
		if (num > 2)
		{
			WriteElementString("key", "http://tempuri.org/", (string)p[2]);
		}
		if (num > 3)
		{
			WriteElementString("ragsversion", "http://tempuri.org/", (string)p[3]);
		}
		WriteEndElement();
	}

	public void Write13_UploadShareInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write14_RemoveShare(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		int num = p.Length;
		WriteStartElement("RemoveShare", "http://tempuri.org/", null, writePrefixed: false);
		if (num > 0)
		{
			WriteElementStringRaw("index", "http://tempuri.org/", XmlConvert.ToString((int)p[0]));
		}
		if (num > 1)
		{
			WriteElementString("useremail", "http://tempuri.org/", (string)p[1]);
		}
		if (num > 2)
		{
			WriteElementString("key", "http://tempuri.org/", (string)p[2]);
		}
		WriteEndElement();
	}

	public void Write15_RemoveShareInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	private void Write3_ShareData(string n, string ns, ShareData o, bool isNullable, bool needType)
	{
		if (o == null)
		{
			if (isNullable)
			{
				WriteNullTagLiteral(n, ns);
			}
			return;
		}
		if (!needType)
		{
			Type type = o.GetType();
			if (!(type == typeof(ShareData)))
			{
				throw CreateUnknownTypeException(o);
			}
		}
		WriteStartElement(n, ns, o, writePrefixed: false, null);
		if (needType)
		{
			WriteXsiType("ShareData", "http://tempuri.org/");
		}
		WriteElementStringRaw("index", "http://tempuri.org/", XmlConvert.ToString(o.index));
		WriteElementString("useremail", "http://tempuri.org/", o.useremail);
		WriteElementString("usernickname", "http://tempuri.org/", o.usernickname);
		WriteElementString("sharename", "http://tempuri.org/", o.sharename);
		WriteElementString("category", "http://tempuri.org/", o.category);
		WriteElementStringRaw("bexplicit", "http://tempuri.org/", XmlConvert.ToString(o.bexplicit));
		WriteElementStringRaw("size", "http://tempuri.org/", XmlConvert.ToString(o.size));
		WriteElementString("description", "http://tempuri.org/", o.description);
		WriteElementStringRaw("lastupdated", "http://tempuri.org/", XmlSerializationWriter.FromDateTime(o.lastupdated));
		WriteElementStringRaw("downloads", "http://tempuri.org/", XmlConvert.ToString(o.downloads));
		WriteElementString("RagsVersion", "http://tempuri.org/", o.RagsVersion);
		WriteEndElement(o);
	}

	protected override void InitCallbacks()
	{
	}
}
