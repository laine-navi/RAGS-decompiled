using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public class XmlSerializationWriterCheckUpdates : XmlSerializationWriter
{
	public void Write3_HelloWorld(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		WriteStartElement("HelloWorld", "http://tempuri.org/", null, writePrefixed: false);
		WriteEndElement();
	}

	public void Write4_HelloWorldInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write5_CheckVersion(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		WriteStartElement("CheckVersion", "http://tempuri.org/", null, writePrefixed: false);
		WriteEndElement();
	}

	public void Write6_CheckVersionInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write7_CheckBetaVersion(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
		WriteStartElement("CheckBetaVersion", "http://tempuri.org/", null, writePrefixed: false);
		WriteEndElement();
	}

	public void Write8_CheckBetaVersionInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	public void Write9_Register(object[] p)
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

	public void Write10_RegisterInHeaders(object[] p)
	{
		WriteStartDocument();
		TopLevelElement();
	}

	protected override void InitCallbacks()
	{
	}
}
