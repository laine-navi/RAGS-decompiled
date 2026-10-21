using System.Xml;
using System.Xml.Serialization;
using RagsDesigner.ragsgame.com;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public class XmlSerializationReaderCheckUpdates : XmlSerializationReader
{
	private string id6_CheckBetaVersionResponse;

	private string id5_CheckVersionResult;

	private string id12_expire;

	private string id11_retval;

	private string id3_HelloWorldResult;

	private string id2_httptempuriorg;

	private string id1_HelloWorldResponse;

	private string id8_RegisterResponse;

	private string id9_RegisterResult;

	private string id7_CheckBetaVersionResult;

	private string id10_RegData;

	private string id4_CheckVersionResponse;

	public object[] Read3_HelloWorldResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id1_HelloWorldResponse, id2_httptempuriorg))
			{
				bool[] array2 = new bool[1];
				if (Reader.IsEmptyElement)
				{
					Reader.Skip();
					Reader.MoveToContent();
					continue;
				}
				Reader.ReadStartElement();
				Reader.MoveToContent();
				int whileIterations2 = 0;
				int readerCount2 = ReaderCount;
				while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
				{
					if (Reader.NodeType == XmlNodeType.Element)
					{
						if (!array2[0] && (object)Reader.LocalName == id3_HelloWorldResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
						{
							array[0] = Reader.ReadElementString();
							array2[0] = true;
						}
						else
						{
							UnknownNode(array, "http://tempuri.org/:HelloWorldResult");
						}
					}
					else
					{
						UnknownNode(array, "http://tempuri.org/:HelloWorldResult");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:HelloWorldResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read4_HelloWorldResponseOutHeaders()
	{
		Reader.MoveToContent();
		object[] array = new object[0];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.NodeType == XmlNodeType.Element)
			{
				UnknownNode(array, "");
			}
			else
			{
				UnknownNode(array, "");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read5_CheckVersionResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id4_CheckVersionResponse, id2_httptempuriorg))
			{
				bool[] array2 = new bool[1];
				if (Reader.IsEmptyElement)
				{
					Reader.Skip();
					Reader.MoveToContent();
					continue;
				}
				Reader.ReadStartElement();
				Reader.MoveToContent();
				int whileIterations2 = 0;
				int readerCount2 = ReaderCount;
				while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
				{
					if (Reader.NodeType == XmlNodeType.Element)
					{
						if (!array2[0] && (object)Reader.LocalName == id5_CheckVersionResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
						{
							array[0] = Reader.ReadElementString();
							array2[0] = true;
						}
						else
						{
							UnknownNode(array, "http://tempuri.org/:CheckVersionResult");
						}
					}
					else
					{
						UnknownNode(array, "http://tempuri.org/:CheckVersionResult");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:CheckVersionResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read6_CheckVersionResponseOutHeaders()
	{
		Reader.MoveToContent();
		object[] array = new object[0];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.NodeType == XmlNodeType.Element)
			{
				UnknownNode(array, "");
			}
			else
			{
				UnknownNode(array, "");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read7_CheckBetaVersionResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id6_CheckBetaVersionResponse, id2_httptempuriorg))
			{
				bool[] array2 = new bool[1];
				if (Reader.IsEmptyElement)
				{
					Reader.Skip();
					Reader.MoveToContent();
					continue;
				}
				Reader.ReadStartElement();
				Reader.MoveToContent();
				int whileIterations2 = 0;
				int readerCount2 = ReaderCount;
				while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
				{
					if (Reader.NodeType == XmlNodeType.Element)
					{
						if (!array2[0] && (object)Reader.LocalName == id7_CheckBetaVersionResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
						{
							array[0] = Reader.ReadElementString();
							array2[0] = true;
						}
						else
						{
							UnknownNode(array, "http://tempuri.org/:CheckBetaVersionResult");
						}
					}
					else
					{
						UnknownNode(array, "http://tempuri.org/:CheckBetaVersionResult");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:CheckBetaVersionResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read8_Item()
	{
		Reader.MoveToContent();
		object[] array = new object[0];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.NodeType == XmlNodeType.Element)
			{
				UnknownNode(array, "");
			}
			else
			{
				UnknownNode(array, "");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read9_RegisterResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id8_RegisterResponse, id2_httptempuriorg))
			{
				bool[] array2 = new bool[1];
				if (Reader.IsEmptyElement)
				{
					Reader.Skip();
					Reader.MoveToContent();
					continue;
				}
				Reader.ReadStartElement();
				Reader.MoveToContent();
				int whileIterations2 = 0;
				int readerCount2 = ReaderCount;
				while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
				{
					if (Reader.NodeType == XmlNodeType.Element)
					{
						if (!array2[0] && (object)Reader.LocalName == id9_RegisterResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
						{
							array[0] = Read2_RegData(isNullable: false, checkType: true);
							array2[0] = true;
						}
						else
						{
							UnknownNode(array, "http://tempuri.org/:RegisterResult");
						}
					}
					else
					{
						UnknownNode(array, "http://tempuri.org/:RegisterResult");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:RegisterResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read10_RegisterResponseOutHeaders()
	{
		Reader.MoveToContent();
		object[] array = new object[0];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.NodeType == XmlNodeType.Element)
			{
				UnknownNode(array, "");
			}
			else
			{
				UnknownNode(array, "");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	private RegData Read2_RegData(bool isNullable, bool checkType)
	{
		XmlQualifiedName xmlQualifiedName = (checkType ? GetXsiType() : null);
		bool flag = false;
		if (isNullable)
		{
			flag = ReadNull();
		}
		if (checkType && !(xmlQualifiedName == null) && ((object)xmlQualifiedName.Name != id10_RegData || (object)xmlQualifiedName.Namespace != id2_httptempuriorg))
		{
			throw CreateUnknownTypeException(xmlQualifiedName);
		}
		if (flag)
		{
			return null;
		}
		RegData regData = new RegData();
		bool[] array = new bool[2];
		while (Reader.MoveToNextAttribute())
		{
			if (!IsXmlnsAttribute(Reader.Name))
			{
				UnknownNode(regData);
			}
		}
		Reader.MoveToElement();
		if (Reader.IsEmptyElement)
		{
			Reader.Skip();
			return regData;
		}
		Reader.ReadStartElement();
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.NodeType == XmlNodeType.Element)
			{
				if (!array[0] && (object)Reader.LocalName == id11_retval && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					regData.retval = XmlConvert.ToInt32(Reader.ReadElementString());
					array[0] = true;
				}
				else if (!array[1] && (object)Reader.LocalName == id12_expire && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					regData.expire = XmlSerializationReader.ToDateTime(Reader.ReadElementString());
					array[1] = true;
				}
				else
				{
					UnknownNode(regData, "http://tempuri.org/:retval, http://tempuri.org/:expire");
				}
			}
			else
			{
				UnknownNode(regData, "http://tempuri.org/:retval, http://tempuri.org/:expire");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		ReadEndElement();
		return regData;
	}

	protected override void InitCallbacks()
	{
	}

	protected override void InitIDs()
	{
		id6_CheckBetaVersionResponse = Reader.NameTable.Add("CheckBetaVersionResponse");
		id5_CheckVersionResult = Reader.NameTable.Add("CheckVersionResult");
		id12_expire = Reader.NameTable.Add("expire");
		id11_retval = Reader.NameTable.Add("retval");
		id3_HelloWorldResult = Reader.NameTable.Add("HelloWorldResult");
		id2_httptempuriorg = Reader.NameTable.Add("http://tempuri.org/");
		id1_HelloWorldResponse = Reader.NameTable.Add("HelloWorldResponse");
		id8_RegisterResponse = Reader.NameTable.Add("RegisterResponse");
		id9_RegisterResult = Reader.NameTable.Add("RegisterResult");
		id7_CheckBetaVersionResult = Reader.NameTable.Add("CheckBetaVersionResult");
		id10_RegData = Reader.NameTable.Add("RegData");
		id4_CheckVersionResponse = Reader.NameTable.Add("CheckVersionResponse");
	}
}
