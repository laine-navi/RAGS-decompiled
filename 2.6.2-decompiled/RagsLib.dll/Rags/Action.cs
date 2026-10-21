using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;

namespace Rags;

[Serializable]
public class Action : ISerializable
{
	public enum ActionInputType
	{
		None,
		Object,
		Character,
		ObjectOrCharacter,
		Text,
		Custom,
		Inventory
	}

	public string name = "default";

	public bool bActive = true;

	public string overridename = string.Empty;

	public string actionparent = "None";

	public bool bConditionFailOnFirst = true;

	public ActionInputType InputType;

	public ArrayList PassCommands = new ArrayList();

	public ArrayList FailCommands = new ArrayList();

	public ArrayList Conditions = new ArrayList();

	public ArrayList CustomChoices = new ArrayList();

	public EnhancedInputData EnhInputData = new EnhancedInputData();

	public string CustomChoiceTitle = string.Empty;

	public Action()
	{
	}

	public Action(string xmldata)
	{
		xmldata = TextHandlers.Decompress(xmldata);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmldata);
		XmlNode CurNode = xmlDocument.FirstChild;
		SetXMLData(ref CurNode);
	}

	protected Action(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		try
		{
			name = (string)info.GetValue("name", name.GetType());
			try
			{
				overridename = (string)info.GetValue("nameoverride", overridename.GetType());
			}
			catch
			{
				overridename = string.Empty;
			}
			try
			{
				actionparent = (string)info.GetValue("actionparent", actionparent.GetType());
			}
			catch
			{
				actionparent = "None";
			}
			bActive = (bool)info.GetValue("bActive", bActive.GetType());
			bConditionFailOnFirst = (bool)info.GetValue("bConditionFailOnFirst", bConditionFailOnFirst.GetType());
			InputType = (ActionInputType)info.GetValue("InputType", InputType.GetType());
			try
			{
				PassCommands = (ArrayList)info.GetValue("PassCommands", PassCommands.GetType());
			}
			catch
			{
				PassCommands = new ArrayList();
				ArrayList arrayList = new ArrayList();
				arrayList = (ArrayList)info.GetValue("PassCommands", arrayList.GetType());
				foreach (object item in arrayList)
				{
					PassCommands.Add(item);
				}
			}
			try
			{
				FailCommands = (ArrayList)info.GetValue("FailCommands", FailCommands.GetType());
			}
			catch
			{
				FailCommands = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				arrayList2 = (ArrayList)info.GetValue("FailCommands", arrayList2.GetType());
				foreach (object item2 in arrayList2)
				{
					FailCommands.Add(item2);
				}
			}
			try
			{
				Conditions = (ArrayList)info.GetValue("Conditions", Conditions.GetType());
			}
			catch
			{
				Conditions = new ArrayList();
				ArrayList arrayList3 = new ArrayList();
				arrayList3 = (ArrayList)info.GetValue("Conditions", arrayList3.GetType());
				foreach (object item3 in arrayList3)
				{
					Conditions.Add(item3);
				}
			}
			try
			{
				CustomChoices = (ArrayList)info.GetValue("CustomChoices", CustomChoices.GetType());
			}
			catch
			{
				CustomChoices = new ArrayList();
			}
			try
			{
				EnhInputData = (EnhancedInputData)info.GetValue("EnhancedInputData", EnhInputData.GetType());
			}
			catch
			{
				EnhInputData = new EnhancedInputData();
			}
			try
			{
				CustomChoiceTitle = (string)info.GetValue("CustomChoiceTitle", CustomChoiceTitle.GetType());
			}
			catch
			{
				CustomChoiceTitle = "Please make a selection:";
			}
		}
		catch (Exception ex)
		{
			throw new Exception("Unhandled exc in actions!", ex.InnerException);
		}
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("name", name, name.GetType());
		info.AddValue("nameoverride", overridename, overridename.GetType());
		try
		{
			info.AddValue("actionparent", actionparent, actionparent.GetType());
		}
		catch
		{
			actionparent = "None";
		}
		info.AddValue("bActive", bActive, bActive.GetType());
		info.AddValue("bConditionFailOnFirst", bConditionFailOnFirst, bConditionFailOnFirst.GetType());
		info.AddValue("InputType", InputType, InputType.GetType());
		info.AddValue("PassCommands", PassCommands, PassCommands.GetType());
		info.AddValue("FailCommands", FailCommands, FailCommands.GetType());
		info.AddValue("Conditions", Conditions, Conditions.GetType());
		info.AddValue("CustomChoices", CustomChoices, CustomChoices.GetType());
		info.AddValue("CustomChoiceTitle", CustomChoiceTitle, CustomChoiceTitle.GetType());
		info.AddValue("EnhancedInputData", EnhInputData, EnhInputData.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		_ = name;
		CurDoc.WriteLine("<Action>");
		Game.AddXMLSection(ref CurDoc, "Name", name);
		Game.AddXMLSection(ref CurDoc, "OverrideName", overridename);
		Game.AddXMLSection(ref CurDoc, "actionparent", actionparent);
		Game.AddXMLSection(ref CurDoc, "Active", bActive.ToString());
		Game.AddXMLSection(ref CurDoc, "FailOnFirst", bConditionFailOnFirst.ToString());
		Game.AddXMLSection(ref CurDoc, "InputType", InputType.ToString());
		Game.AddXMLSection(ref CurDoc, "CustomChoiceTitle", CustomChoiceTitle);
		if (CustomChoices.Count > 0)
		{
			CurDoc.WriteLine("<CustomChoices>");
			foreach (string customChoice in CustomChoices)
			{
				CurDoc.WriteLine("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.WriteLine("</CustomChoice>");
			}
			CurDoc.WriteLine("</CustomChoices>");
		}
		CurDoc.WriteLine("<EnhancedInputData>");
		EnhInputData.a(ref CurDoc);
		CurDoc.WriteLine("</EnhancedInputData>");
		if (Conditions.Count > 0)
		{
			CurDoc.WriteLine("<Conditions>");
			foreach (Condition condition3 in Conditions)
			{
				condition3.GetXMLData(ref CurDoc);
			}
			CurDoc.WriteLine("</Conditions>");
		}
		if (PassCommands.Count > 0)
		{
			CurDoc.WriteLine("<PassCommands>");
			for (int i = 0; i < PassCommands.Count; i++)
			{
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command != null)
				{
					command.GetXMLData(ref CurDoc);
				}
				else
				{
					condition?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine("</PassCommands>");
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.WriteLine("<FailCommands>");
			for (int j = 0; j < FailCommands.Count; j++)
			{
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetXMLData(ref CurDoc);
				}
				else
				{
					condition2?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine("</FailCommands>");
		}
		CurDoc.WriteLine("</Action>");
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		_ = name;
		CurDoc.Append("<Action>");
		Game.AddXMLSection(ref CurDoc, "Name", name);
		Game.AddXMLSection(ref CurDoc, "OverrideName", overridename);
		Game.AddXMLSection(ref CurDoc, "actionparent", actionparent);
		Game.AddXMLSection(ref CurDoc, "Active", bActive.ToString());
		Game.AddXMLSection(ref CurDoc, "FailOnFirst", bConditionFailOnFirst.ToString());
		Game.AddXMLSection(ref CurDoc, "InputType", InputType.ToString());
		Game.AddXMLSection(ref CurDoc, "CustomChoiceTitle", CustomChoiceTitle);
		if (CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>");
			foreach (string customChoice in CustomChoices)
			{
				CurDoc.Append("<CustomChoice>");
				Game.AddXMLSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>");
			}
			CurDoc.Append("</CustomChoices>");
		}
		CurDoc.Append("<EnhancedInputData>");
		EnhInputData.a(ref CurDoc);
		CurDoc.Append("</EnhancedInputData>");
		if (Conditions.Count > 0)
		{
			CurDoc.Append("<Conditions>");
			foreach (Condition condition3 in Conditions)
			{
				condition3.GetXMLData(ref CurDoc);
			}
			CurDoc.Append("</Conditions>");
		}
		if (PassCommands.Count > 0)
		{
			CurDoc.Append("<PassCommands>");
			for (int i = 0; i < PassCommands.Count; i++)
			{
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command != null)
				{
					command.GetXMLData(ref CurDoc);
				}
				else
				{
					condition?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append("</PassCommands>");
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.Append("<FailCommands>");
			for (int j = 0; j < FailCommands.Count; j++)
			{
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetXMLData(ref CurDoc);
				}
				else
				{
					condition2?.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append("</FailCommands>");
		}
		CurDoc.Append("</Action>");
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		_ = name;
		CurDoc.Append("<Action name=\"" + name + "\" active=\"" + bActive + "\"");
		if (overridename != string.Empty)
		{
			CurDoc.Append(" overridename=\"" + overridename + "\"");
		}
		if (actionparent != string.Empty)
		{
			CurDoc.Append(" actionparent=\"" + actionparent + "\"");
		}
		if (InputType != ActionInputType.None)
		{
			CurDoc.Append(" InputType=\"" + InputType.ToString() + "\"");
			CurDoc.Append(" CustomChoiceTitle=\"" + CustomChoiceTitle + "\"");
		}
		CurDoc.Append(">\r\n");
		if (CustomChoices.Count > 0)
		{
			CurDoc.Append("<CustomChoices>\r\n");
			foreach (string customChoice in CustomChoices)
			{
				CurDoc.Append("<CustomChoice>\r\n");
				Game.AddAdvSection(ref CurDoc, "Name", customChoice);
				CurDoc.Append("</CustomChoice>\r\n");
			}
			CurDoc.Append("</CustomChoices>\r\n");
		}
		if (Conditions.Count > 0)
		{
			foreach (Condition condition3 in Conditions)
			{
				condition3.AddAdvSection(ref CurDoc);
			}
		}
		if (PassCommands.Count > 0)
		{
			CurDoc.Append("<Pass>\r\n");
			for (int i = 0; i < PassCommands.Count; i++)
			{
				Command command = PassCommands[i] as Command;
				Condition condition = PassCommands[i] as Condition;
				if (command != null)
				{
					command.GetAdvancedText(ref CurDoc);
				}
				else
				{
					condition?.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append("</Pass>\r\n");
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.Append("<Fail>\r\n");
			for (int j = 0; j < FailCommands.Count; j++)
			{
				Command command2 = FailCommands[j] as Command;
				Condition condition2 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetAdvancedText(ref CurDoc);
				}
				else
				{
					condition2?.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append("</Fail>\r\n");
		}
		CurDoc.Append("</Action>\r\n");
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, "Name");
		if (xMLSection != null)
		{
			name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "OverrideName");
		if (xMLSection != null)
		{
			overridename = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "actionparent");
		if (xMLSection != null)
		{
			actionparent = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomChoiceTitle");
		if (xMLSection != null)
		{
			CustomChoiceTitle = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Active");
		if (xMLSection != null)
		{
			bActive = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "FailOnFirst");
		if (xMLSection != null)
		{
			bConditionFailOnFirst = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "InputType");
		if (xMLSection != null)
		{
			InputType = (ActionInputType)Enum.Parse(typeof(ActionInputType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "CustomChoices");
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				string innerText = xMLSection.ChildNodes[i].InnerText;
				CustomChoices.Add(innerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "Conditions");
		if (xMLSection != null)
		{
			for (int j = 0; j < xMLSection.ChildNodes.Count; j++)
			{
				XmlNode CurNode2 = xMLSection.ChildNodes[j];
				Condition condition = new Condition();
				condition.SetXMLData(ref CurNode2);
				Conditions.Add(condition);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "PassCommands");
		if (xMLSection != null)
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[k];
				Command command = new Command();
				Condition condition2 = new Condition();
				if (string.Compare(CurNode3.Name, "Condition", ignoreCase: true) == 0)
				{
					condition2.SetXMLData(ref CurNode3);
					PassCommands.Add(condition2);
				}
				else
				{
					command.SetXMLData(ref CurNode3);
					PassCommands.Add(command);
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "FailCommands");
		if (xMLSection != null)
		{
			for (int l = 0; l < xMLSection.ChildNodes.Count; l++)
			{
				XmlNode CurNode4 = xMLSection.ChildNodes[l];
				Command command2 = new Command();
				Condition condition3 = new Condition();
				if (string.Compare(CurNode4.Name, "Condition", ignoreCase: true) == 0)
				{
					condition3.SetXMLData(ref CurNode4);
					FailCommands.Add(condition3);
				}
				else
				{
					command2.SetXMLData(ref CurNode4);
					FailCommands.Add(command2);
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, "EnhancedInputData");
		if (xMLSection != null)
		{
			EnhInputData.SetXMLData(ref xMLSection);
		}
	}

	public void CallAction(object obj)
	{
		ActionInputType inputType = InputType;
		if (inputType != ActionInputType.Object)
		{
			_ = 4;
		}
	}

	public Command GetPassCommandByName(string cmdname)
	{
		for (int i = 0; i < PassCommands.Count; i++)
		{
			if (string.Compare(cmdname, ((Command)PassCommands[i]).CommandName, ignoreCase: true) == 0)
			{
				return (Command)PassCommands[i];
			}
		}
		return null;
	}

	public Command GetFailCommandByName(string cmdname)
	{
		for (int i = 0; i < FailCommands.Count; i++)
		{
			if (string.Compare(cmdname, ((Command)FailCommands[i]).CommandName, ignoreCase: true) == 0)
			{
				return (Command)FailCommands[i];
			}
		}
		return null;
	}

	public Condition GetConditionByName(string condname)
	{
		for (int i = 0; i < Conditions.Count; i++)
		{
			if (string.Compare(condname, ((Condition)Conditions[i]).conditionname, ignoreCase: true) == 0)
			{
				return (Condition)Conditions[i];
			}
		}
		return null;
	}

	public override string ToString()
	{
		return name;
	}

	internal void a(Action A_0)
	{
		bActive = A_0.bActive;
	}

	internal void a(ref StringBuilder A_0)
	{
		A_0.Append("[");
		A_0.Append("\"" + name.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_0.Append(bActive.ToString().ToLower() + ",");
		A_0.Append("\"" + overridename.Replace("'", "\\'").Replace("\"", "\\\"") + "\",");
		A_0.Append("\"" + actionparent + "\",");
		A_0.Append(bConditionFailOnFirst.ToString().ToLower() + ",");
		A_0.Append(string.Concat("\"", InputType, "\","));
		A_0.Append("\"" + CustomChoiceTitle + "\",");
		A_0.Append("[");
		int num = 0;
		foreach (object passCommand in PassCommands)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			num++;
			Command command = passCommand as Command;
			Condition condition = passCommand as Condition;
			if (command != null)
			{
				command.GetJSText(ref A_0);
			}
			else
			{
				condition?.a(ref A_0);
			}
		}
		A_0.Append("],");
		A_0.Append("[");
		num = 0;
		foreach (object failCommand in FailCommands)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			num++;
			Command command2 = failCommand as Command;
			Condition condition2 = failCommand as Condition;
			if (command2 != null)
			{
				command2.GetJSText(ref A_0);
			}
			else
			{
				condition2?.a(ref A_0);
			}
		}
		A_0.Append("],");
		A_0.Append("[");
		num = 0;
		foreach (Condition condition3 in Conditions)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			num++;
			condition3.a(ref A_0);
		}
		A_0.Append("],");
		num = 0;
		A_0.Append("[");
		foreach (string customChoice in CustomChoices)
		{
			if (num > 0)
			{
				A_0.Append(",");
			}
			A_0.Append("\"" + customChoice.Replace("'", "\\'").Replace("\"", "\\\"") + "\"");
			num++;
		}
		A_0.Append("],");
		EnhInputData.c(ref A_0);
		A_0.Append("]");
	}
}
