using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public sealed class ArrayOfObjectSerializer1 : XmlSerializer1
{
	public override bool CanDeserialize(XmlReader xmlReader)
	{
		return xmlReader.IsStartElement("CheckVersionResponse", "http://tempuri.org/");
	}

	protected override object Deserialize(XmlSerializationReader reader)
	{
		return ((XmlSerializationReaderCheckUpdates)reader).Read4_CheckVersionResponse();
	}
}
