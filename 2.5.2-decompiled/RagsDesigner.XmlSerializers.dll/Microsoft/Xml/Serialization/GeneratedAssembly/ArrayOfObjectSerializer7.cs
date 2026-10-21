using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public sealed class ArrayOfObjectSerializer7 : XmlSerializer1
{
	public override bool CanDeserialize(XmlReader xmlReader)
	{
		return xmlReader.IsStartElement("CheckVersionResponseOutHeaders", "http://tempuri.org/");
	}

	protected override object Deserialize(XmlSerializationReader reader)
	{
		return ((XmlSerializationReaderCheckUpdates)reader).Read6_CheckVersionResponseOutHeaders();
	}
}
