using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Rags;

public class XMLUtilities
{
	public enum FilterType
	{
		FT_Command,
		FT_Condition
	}

	public static List<string> LoadXMLConfiguration(FilterType type)
	{
		List<string> list = new List<string>();
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Rags");
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string text2 = Path.Combine(text, "RagsConfig.xml");
		if (!File.Exists(text2))
		{
			string contents = "<Configuration> </Configuration>";
			File.WriteAllText(text2, contents);
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text2);
		XmlNodeList xmlNodeList = null;
		xmlNodeList = ((type != FilterType.FT_Command) ? xmlDocument.SelectNodes("Configuration/BlockedConditions") : xmlDocument.SelectNodes("Configuration/BlockedCommands"));
		foreach (XmlNode item in xmlNodeList)
		{
			foreach (XmlNode childNode in item.ChildNodes)
			{
				list.Add(childNode.Attributes["name"].Value);
			}
		}
		return list;
	}
}
