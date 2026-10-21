using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public sealed class ArrayOfObjectSerializer22 : XmlSerializer1
{
	public override bool CanDeserialize(XmlReader xmlReader)
	{
		return xmlReader.IsStartElement("RemoveShareInHeaders", "http://tempuri.org/");
	}

	protected override void Serialize(object objectToSerialize, XmlSerializationWriter writer)
	{
		((XmlSerializationWriterCheckUpdates)writer).Write15_RemoveShareInHeaders((object[])objectToSerialize);
	}
}
