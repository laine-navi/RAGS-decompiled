using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public abstract class XmlSerializer1 : XmlSerializer
{
	protected override XmlSerializationReader CreateReader()
	{
		return new XmlSerializationReaderCheckUpdates();
	}

	protected override XmlSerializationWriter CreateWriter()
	{
		return new XmlSerializationWriterCheckUpdates();
	}
}
