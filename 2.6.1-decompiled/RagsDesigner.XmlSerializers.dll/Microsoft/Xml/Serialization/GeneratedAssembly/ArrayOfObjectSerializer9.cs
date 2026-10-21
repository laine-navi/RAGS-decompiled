using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public sealed class ArrayOfObjectSerializer9 : XmlSerializer1
{
	public override bool CanDeserialize(XmlReader xmlReader)
	{
		return xmlReader.IsStartElement("CheckBetaVersionResponse", "http://tempuri.org/");
	}

	protected override object Deserialize(XmlSerializationReader reader)
	{
		return ((XmlSerializationReaderCheckUpdates)reader).Read7_CheckBetaVersionResponse();
	}
}
