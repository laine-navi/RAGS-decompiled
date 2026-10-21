using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public sealed class ArrayOfObjectSerializer4 : XmlSerializer1
{
	public override bool CanDeserialize(XmlReader xmlReader)
	{
		return xmlReader.IsStartElement("CheckVersion", "http://tempuri.org/");
	}

	protected override void Serialize(object objectToSerialize, XmlSerializationWriter writer)
	{
		((XmlSerializationWriterCheckUpdates)writer).Write5_CheckVersion((object[])objectToSerialize);
	}
}
