using System.Xml;
using System.Xml.Serialization;
using Rags.ragsgame.com;

namespace Microsoft.Xml.Serialization.GeneratedAssembly;

public class XmlSerializationReaderCheckUpdates : XmlSerializationReader
{
	private string id18_index;

	private string id21_sharename;

	private string id24_size;

	private string id16_retval;

	private string id13_ShareData;

	private string id23_bexplicit;

	private string id6_GetShareDataSummaryResponse;

	private string id27_downloads;

	private string id11_UploadShareResponse;

	private string id15_ArrayOfAnyType;

	private string id2_httptempuriorg;

	private string id22_category;

	private string id17_expire;

	private string id8_anyType;

	private string id1_CheckVersionResponse;

	private string id9_DownloadShareResponse;

	private string id19_useremail;

	private string id3_CheckVersionResult;

	private string id7_GetShareDataSummaryResult;

	private string id26_lastupdated;

	private string id28_RagsVersion;

	private string id25_description;

	private string id14_RegData;

	private string id5_RegisterResult;

	private string id10_DownloadShareResult;

	private string id20_usernickname;

	private string id12_RemoveShareResponse;

	private string id4_RegisterResponse;

	public object[] Read4_CheckVersionResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id1_CheckVersionResponse, id2_httptempuriorg))
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
						if (!array2[0] && (object)Reader.LocalName == id3_CheckVersionResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
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

	public object[] Read5_CheckVersionResponseOutHeaders()
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

	public object[] Read6_RegisterResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id4_RegisterResponse, id2_httptempuriorg))
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
						if (!array2[0] && (object)Reader.LocalName == id5_RegisterResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
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

	public object[] Read7_RegisterResponseOutHeaders()
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

	public object[] Read8_GetShareDataSummaryResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id6_GetShareDataSummaryResponse, id2_httptempuriorg))
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
						if (!array2[0] && (object)Reader.LocalName == id7_GetShareDataSummaryResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
						{
							if (!ReadNull())
							{
								object[] array3 = null;
								int num = 0;
								if (Reader.IsEmptyElement)
								{
									Reader.Skip();
								}
								else
								{
									Reader.ReadStartElement();
									Reader.MoveToContent();
									int whileIterations3 = 0;
									int readerCount3 = ReaderCount;
									while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
									{
										if (Reader.NodeType == XmlNodeType.Element)
										{
											if ((object)Reader.LocalName == id8_anyType && (object)Reader.NamespaceURI == id2_httptempuriorg)
											{
												array3 = (object[])EnsureArrayIndex(array3, num, typeof(object));
												array3[num++] = Read1_Object(isNullable: true, checkType: true);
											}
											else
											{
												UnknownNode(null, "http://tempuri.org/:anyType");
											}
										}
										else
										{
											UnknownNode(null, "http://tempuri.org/:anyType");
										}
										Reader.MoveToContent();
										CheckReaderCount(ref whileIterations3, ref readerCount3);
									}
									ReadEndElement();
								}
								array[0] = (object[])ShrinkArray(array3, num, typeof(object), isNullable: false);
							}
							array2[0] = true;
						}
						else
						{
							UnknownNode(array, "http://tempuri.org/:GetShareDataSummaryResult");
						}
					}
					else
					{
						UnknownNode(array, "http://tempuri.org/:GetShareDataSummaryResult");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:GetShareDataSummaryResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read9_Item()
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

	public object[] Read10_DownloadShareResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[1];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id9_DownloadShareResponse, id2_httptempuriorg))
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
						if (!array2[0] && (object)Reader.LocalName == id10_DownloadShareResult && (object)Reader.NamespaceURI == id2_httptempuriorg)
						{
							array[0] = ToByteArrayBase64(isNull: false);
							array2[0] = true;
						}
						else
						{
							UnknownNode(array, "http://tempuri.org/:DownloadShareResult");
						}
					}
					else
					{
						UnknownNode(array, "http://tempuri.org/:DownloadShareResult");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:DownloadShareResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read11_Item()
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

	public object[] Read12_UploadShareResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[0];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id11_UploadShareResponse, id2_httptempuriorg))
			{
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
						UnknownNode(array, "");
					}
					else
					{
						UnknownNode(array, "");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:UploadShareResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read13_UploadShareResponseOutHeaders()
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

	public object[] Read14_RemoveShareResponse()
	{
		Reader.MoveToContent();
		object[] array = new object[0];
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.IsStartElement(id12_RemoveShareResponse, id2_httptempuriorg))
			{
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
						UnknownNode(array, "");
					}
					else
					{
						UnknownNode(array, "");
					}
					Reader.MoveToContent();
					CheckReaderCount(ref whileIterations2, ref readerCount2);
				}
				ReadEndElement();
			}
			else
			{
				UnknownNode(null, "http://tempuri.org/:RemoveShareResponse");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		return array;
	}

	public object[] Read15_RemoveShareResponseOutHeaders()
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

	private object Read1_Object(bool isNullable, bool checkType)
	{
		XmlQualifiedName xmlQualifiedName = (checkType ? GetXsiType() : null);
		bool flag = false;
		if (isNullable)
		{
			flag = ReadNull();
		}
		if (checkType)
		{
			if (flag)
			{
				if (xmlQualifiedName != null)
				{
					return ReadTypedNull(xmlQualifiedName);
				}
				return null;
			}
			if (xmlQualifiedName == null)
			{
				return ReadTypedPrimitive(new XmlQualifiedName("anyType", "http://www.w3.org/2001/XMLSchema"));
			}
			if ((object)xmlQualifiedName.Name == id13_ShareData && (object)xmlQualifiedName.Namespace == id2_httptempuriorg)
			{
				return Read3_ShareData(isNullable, checkType: false);
			}
			if ((object)xmlQualifiedName.Name == id14_RegData && (object)xmlQualifiedName.Namespace == id2_httptempuriorg)
			{
				return Read2_RegData(isNullable, checkType: false);
			}
			if ((object)xmlQualifiedName.Name == id15_ArrayOfAnyType && (object)xmlQualifiedName.Namespace == id2_httptempuriorg)
			{
				object[] result = null;
				if (!ReadNull())
				{
					object[] array = null;
					int num = 0;
					if (Reader.IsEmptyElement)
					{
						Reader.Skip();
					}
					else
					{
						Reader.ReadStartElement();
						Reader.MoveToContent();
						int whileIterations = 0;
						int readerCount = ReaderCount;
						while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
						{
							if (Reader.NodeType == XmlNodeType.Element)
							{
								if ((object)Reader.LocalName == id8_anyType && (object)Reader.NamespaceURI == id2_httptempuriorg)
								{
									array = (object[])EnsureArrayIndex(array, num, typeof(object));
									array[num++] = Read1_Object(isNullable: true, checkType: true);
								}
								else
								{
									UnknownNode(null, "http://tempuri.org/:anyType");
								}
							}
							else
							{
								UnknownNode(null, "http://tempuri.org/:anyType");
							}
							Reader.MoveToContent();
							CheckReaderCount(ref whileIterations, ref readerCount);
						}
						ReadEndElement();
					}
					result = (object[])ShrinkArray(array, num, typeof(object), isNullable: false);
				}
				return result;
			}
			return ReadTypedPrimitive(xmlQualifiedName);
		}
		if (flag)
		{
			return null;
		}
		object obj = new object();
		while (Reader.MoveToNextAttribute())
		{
			if (!IsXmlnsAttribute(Reader.Name))
			{
				UnknownNode(obj);
			}
		}
		Reader.MoveToElement();
		if (Reader.IsEmptyElement)
		{
			Reader.Skip();
			return obj;
		}
		Reader.ReadStartElement();
		Reader.MoveToContent();
		int whileIterations2 = 0;
		int readerCount2 = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.NodeType == XmlNodeType.Element)
			{
				UnknownNode(obj, "");
			}
			else
			{
				UnknownNode(obj, "");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations2, ref readerCount2);
		}
		ReadEndElement();
		return obj;
	}

	private RegData Read2_RegData(bool isNullable, bool checkType)
	{
		XmlQualifiedName xmlQualifiedName = (checkType ? GetXsiType() : null);
		bool flag = false;
		if (isNullable)
		{
			flag = ReadNull();
		}
		if (checkType && !(xmlQualifiedName == null) && ((object)xmlQualifiedName.Name != id14_RegData || (object)xmlQualifiedName.Namespace != id2_httptempuriorg))
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
				if (!array[0] && (object)Reader.LocalName == id16_retval && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					regData.retval = XmlConvert.ToInt32(Reader.ReadElementString());
					array[0] = true;
				}
				else if (!array[1] && (object)Reader.LocalName == id17_expire && (object)Reader.NamespaceURI == id2_httptempuriorg)
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

	private ShareData Read3_ShareData(bool isNullable, bool checkType)
	{
		XmlQualifiedName xmlQualifiedName = (checkType ? GetXsiType() : null);
		bool flag = false;
		if (isNullable)
		{
			flag = ReadNull();
		}
		if (checkType && !(xmlQualifiedName == null) && ((object)xmlQualifiedName.Name != id13_ShareData || (object)xmlQualifiedName.Namespace != id2_httptempuriorg))
		{
			throw CreateUnknownTypeException(xmlQualifiedName);
		}
		if (flag)
		{
			return null;
		}
		ShareData shareData = new ShareData();
		bool[] array = new bool[11];
		while (Reader.MoveToNextAttribute())
		{
			if (!IsXmlnsAttribute(Reader.Name))
			{
				UnknownNode(shareData);
			}
		}
		Reader.MoveToElement();
		if (Reader.IsEmptyElement)
		{
			Reader.Skip();
			return shareData;
		}
		Reader.ReadStartElement();
		Reader.MoveToContent();
		int whileIterations = 0;
		int readerCount = ReaderCount;
		while (Reader.NodeType != XmlNodeType.EndElement && Reader.NodeType != XmlNodeType.None)
		{
			if (Reader.NodeType == XmlNodeType.Element)
			{
				if (!array[0] && (object)Reader.LocalName == id18_index && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.index = XmlConvert.ToInt32(Reader.ReadElementString());
					array[0] = true;
				}
				else if (!array[1] && (object)Reader.LocalName == id19_useremail && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.useremail = Reader.ReadElementString();
					array[1] = true;
				}
				else if (!array[2] && (object)Reader.LocalName == id20_usernickname && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.usernickname = Reader.ReadElementString();
					array[2] = true;
				}
				else if (!array[3] && (object)Reader.LocalName == id21_sharename && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.sharename = Reader.ReadElementString();
					array[3] = true;
				}
				else if (!array[4] && (object)Reader.LocalName == id22_category && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.category = Reader.ReadElementString();
					array[4] = true;
				}
				else if (!array[5] && (object)Reader.LocalName == id23_bexplicit && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.bexplicit = XmlConvert.ToBoolean(Reader.ReadElementString());
					array[5] = true;
				}
				else if (!array[6] && (object)Reader.LocalName == id24_size && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.size = XmlConvert.ToInt32(Reader.ReadElementString());
					array[6] = true;
				}
				else if (!array[7] && (object)Reader.LocalName == id25_description && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.description = Reader.ReadElementString();
					array[7] = true;
				}
				else if (!array[8] && (object)Reader.LocalName == id26_lastupdated && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.lastupdated = XmlSerializationReader.ToDateTime(Reader.ReadElementString());
					array[8] = true;
				}
				else if (!array[9] && (object)Reader.LocalName == id27_downloads && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.downloads = XmlConvert.ToInt32(Reader.ReadElementString());
					array[9] = true;
				}
				else if (!array[10] && (object)Reader.LocalName == id28_RagsVersion && (object)Reader.NamespaceURI == id2_httptempuriorg)
				{
					shareData.RagsVersion = Reader.ReadElementString();
					array[10] = true;
				}
				else
				{
					UnknownNode(shareData, "http://tempuri.org/:index, http://tempuri.org/:useremail, http://tempuri.org/:usernickname, http://tempuri.org/:sharename, http://tempuri.org/:category, http://tempuri.org/:bexplicit, http://tempuri.org/:size, http://tempuri.org/:description, http://tempuri.org/:lastupdated, http://tempuri.org/:downloads, http://tempuri.org/:RagsVersion");
				}
			}
			else
			{
				UnknownNode(shareData, "http://tempuri.org/:index, http://tempuri.org/:useremail, http://tempuri.org/:usernickname, http://tempuri.org/:sharename, http://tempuri.org/:category, http://tempuri.org/:bexplicit, http://tempuri.org/:size, http://tempuri.org/:description, http://tempuri.org/:lastupdated, http://tempuri.org/:downloads, http://tempuri.org/:RagsVersion");
			}
			Reader.MoveToContent();
			CheckReaderCount(ref whileIterations, ref readerCount);
		}
		ReadEndElement();
		return shareData;
	}

	protected override void InitCallbacks()
	{
	}

	protected override void InitIDs()
	{
		id18_index = Reader.NameTable.Add("index");
		id21_sharename = Reader.NameTable.Add("sharename");
		id24_size = Reader.NameTable.Add("size");
		id16_retval = Reader.NameTable.Add("retval");
		id13_ShareData = Reader.NameTable.Add("ShareData");
		id23_bexplicit = Reader.NameTable.Add("bexplicit");
		id6_GetShareDataSummaryResponse = Reader.NameTable.Add("GetShareDataSummaryResponse");
		id27_downloads = Reader.NameTable.Add("downloads");
		id11_UploadShareResponse = Reader.NameTable.Add("UploadShareResponse");
		id15_ArrayOfAnyType = Reader.NameTable.Add("ArrayOfAnyType");
		id2_httptempuriorg = Reader.NameTable.Add("http://tempuri.org/");
		id22_category = Reader.NameTable.Add("category");
		id17_expire = Reader.NameTable.Add("expire");
		id8_anyType = Reader.NameTable.Add("anyType");
		id1_CheckVersionResponse = Reader.NameTable.Add("CheckVersionResponse");
		id9_DownloadShareResponse = Reader.NameTable.Add("DownloadShareResponse");
		id19_useremail = Reader.NameTable.Add("useremail");
		id3_CheckVersionResult = Reader.NameTable.Add("CheckVersionResult");
		id7_GetShareDataSummaryResult = Reader.NameTable.Add("GetShareDataSummaryResult");
		id26_lastupdated = Reader.NameTable.Add("lastupdated");
		id28_RagsVersion = Reader.NameTable.Add("RagsVersion");
		id25_description = Reader.NameTable.Add("description");
		id14_RegData = Reader.NameTable.Add("RegData");
		id5_RegisterResult = Reader.NameTable.Add("RegisterResult");
		id10_DownloadShareResult = Reader.NameTable.Add("DownloadShareResult");
		id20_usernickname = Reader.NameTable.Add("usernickname");
		id12_RemoveShareResponse = Reader.NameTable.Add("RemoveShareResponse");
		id4_RegisterResponse = Reader.NameTable.Add("RegisterResponse");
	}
}
