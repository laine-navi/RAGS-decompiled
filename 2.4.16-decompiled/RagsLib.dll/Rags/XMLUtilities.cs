using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using A;

namespace Rags;

public sealed class XMLUtilities
{
	public enum FilterType
	{
		FT_Command,
		FT_Condition
	}

	public static List<string> LoadXMLConfiguration(FilterType type)
	{
		List<string> list = new List<string>();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23172));
		if (Directory.Exists(text))
		{
			__ldtoken(XMLUtilities.LoadXMLConfiguration(FilterType));
		}
		else
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116569));
		if (File.Exists(text2))
		{
			__ldtoken(XMLUtilities.LoadXMLConfiguration(FilterType));
		}
		else
		{
			string contents = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116598);
			File.WriteAllText(text2, contents);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text2);
		XmlNodeList xmlNodeList = null;
		xmlNodeList = ((type != FilterType.FT_Command) ? xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116722)) : xmlDocument.SelectNodes(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(116663)));
		IEnumerator enumerator = xmlNodeList.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(XMLUtilities.LoadXMLConfiguration(FilterType));
				XmlNode xmlNode = (XmlNode)enumerator.Current;
				IEnumerator enumerator2 = xmlNode.ChildNodes.GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						XmlNode xmlNode2 = (XmlNode)enumerator2.Current;
						list.Add(xmlNode2.Attributes[cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65016)].Value);
					}
				}
				finally
				{
					if (!(enumerator2 is IDisposable disposable))
					{
						__ldtoken(XMLUtilities.LoadXMLConfiguration(FilterType));
					}
					else
					{
						disposable.Dispose();
					}
				}
			}
			return list;
		}
		finally
		{
			IDisposable disposable2 = enumerator as IDisposable;
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
		}
	}
}
