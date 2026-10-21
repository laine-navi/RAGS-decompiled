using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using A;

namespace Rags;

[Serializable]
public sealed class Action : ISerializable
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

	public string name = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118551);

	public bool bActive = true;

	public string overridename = string.Empty;

	public string actionparent = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);

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
		if (info != null)
		{
			__ldtoken(Action._002Ector(SerializationInfo, StreamingContext));
			try
			{
				name = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65016), name.GetType());
				try
				{
					overridename = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118090), overridename.GetType());
				}
				catch
				{
					overridename = string.Empty;
				}
				try
				{
					actionparent = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118115), actionparent.GetType());
				}
				catch
				{
					actionparent = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);
				}
				bActive = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112274), bActive.GetType());
				bConditionFailOnFirst = (bool)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118140), bConditionFailOnFirst.GetType());
				InputType = (ActionInputType)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1907), InputType.GetType());
				try
				{
					PassCommands = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114412), PassCommands.GetType());
				}
				catch
				{
					PassCommands = new ArrayList();
					ArrayList arrayList = new ArrayList();
					arrayList = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114412), arrayList.GetType());
					IEnumerator enumerator = arrayList.GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							__ldtoken(Action._002Ector(SerializationInfo, StreamingContext));
							object current = enumerator.Current;
							PassCommands.Add(current);
						}
					}
					finally
					{
						IDisposable disposable3 = enumerator as IDisposable;
						if (disposable3 != null)
						{
							disposable3.Dispose();
						}
					}
				}
				try
				{
					FailCommands = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114437), FailCommands.GetType());
				}
				catch
				{
					FailCommands = new ArrayList();
					ArrayList arrayList2 = new ArrayList();
					arrayList2 = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114437), arrayList2.GetType());
					IEnumerator enumerator2 = arrayList2.GetEnumerator();
					try
					{
						while (enumerator2.MoveNext())
						{
							__ldtoken(Action._002Ector(SerializationInfo, StreamingContext));
							object current2 = enumerator2.Current;
							FailCommands.Add(current2);
						}
					}
					finally
					{
						if (!(enumerator2 is IDisposable disposable))
						{
							__ldtoken(Action._002Ector(SerializationInfo, StreamingContext));
						}
						else
						{
							disposable.Dispose();
						}
					}
				}
				try
				{
					Conditions = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118183), Conditions.GetType());
				}
				catch
				{
					Conditions = new ArrayList();
					ArrayList arrayList3 = new ArrayList();
					arrayList3 = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118183), arrayList3.GetType());
					IEnumerator enumerator3 = arrayList3.GetEnumerator();
					try
					{
						while (enumerator3.MoveNext())
						{
							__ldtoken(Action._002Ector(SerializationInfo, StreamingContext));
							object current3 = enumerator3.Current;
							Conditions.Add(current3);
						}
					}
					finally
					{
						if (!(enumerator3 is IDisposable disposable2))
						{
							__ldtoken(Action._002Ector(SerializationInfo, StreamingContext));
						}
						else
						{
							disposable2.Dispose();
						}
					}
				}
				try
				{
					CustomChoices = (ArrayList)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66004), CustomChoices.GetType());
				}
				catch
				{
					CustomChoices = new ArrayList();
				}
				try
				{
					EnhInputData = (EnhancedInputData)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469), EnhInputData.GetType());
				}
				catch
				{
					EnhInputData = new EnhancedInputData();
				}
				try
				{
					CustomChoiceTitle = (string)info.GetValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118204), CustomChoiceTitle.GetType());
					return;
				}
				catch
				{
					CustomChoiceTitle = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118566);
					return;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118615), ex.InnerException);
			}
		}
		throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
	}

	[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22002));
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(65016), name, name.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118090), overridename, overridename.GetType());
		try
		{
			info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118115), actionparent, actionparent.GetType());
		}
		catch
		{
			actionparent = cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(2514);
		}
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(112274), bActive, bActive.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118140), bConditionFailOnFirst, bConditionFailOnFirst.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1907), InputType, InputType.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114412), PassCommands, PassCommands.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114437), FailCommands, FailCommands.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118183), Conditions, Conditions.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66004), CustomChoices, CustomChoices.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118204), CustomChoiceTitle, CustomChoiceTitle.GetType());
		info.AddValue(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469), EnhInputData, EnhInputData.GetType());
	}

	public void GetXMLData(ref StreamWriter CurDoc)
	{
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118239));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), name);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1649), overridename);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118115), actionparent);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736), bActive.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118256), bConditionFailOnFirst.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1907), InputType.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118204), CustomChoiceTitle);
		if (CustomChoices.Count <= 0)
		{
			__ldtoken(Action.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66286));
			{
				IEnumerator enumerator = CustomChoices.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(Action.GetXMLData(ref StreamWriter));
						string value = (string)enumerator.Current;
						CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66317));
						Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), value);
						CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66346));
					}
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
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66377));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19895));
		EnhInputData.c83abeab8711e52857623283ffa75d603(ref CurDoc);
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19934));
		if (Conditions.Count > 0)
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118279));
			IEnumerator enumerator2 = Conditions.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					Condition condition = (Condition)enumerator2.Current;
					condition.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable))
				{
					__ldtoken(Action.GetXMLData(ref StreamWriter));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118304));
		}
		if (PassCommands.Count <= 0)
		{
			__ldtoken(Action.GetXMLData(ref StreamWriter));
		}
		else
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114561));
			for (int i = 0; i < PassCommands.Count; i++)
			{
				__ldtoken(Action.GetXMLData(ref StreamWriter));
				Command command = PassCommands[i] as Command;
				Condition condition2 = PassCommands[i] as Condition;
				if (command == null)
				{
					__ldtoken(Action.GetXMLData(ref StreamWriter));
					condition2?.GetXMLData(ref CurDoc);
				}
				else
				{
					command.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114590));
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114621));
			for (int j = 0; j < FailCommands.Count; j++)
			{
				__ldtoken(Action.GetXMLData(ref StreamWriter));
				Command command2 = FailCommands[j] as Command;
				Condition condition3 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetXMLData(ref CurDoc);
				}
				else if (condition3 == null)
				{
					__ldtoken(Action.GetXMLData(ref StreamWriter));
				}
				else
				{
					condition3.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114650));
		}
		CurDoc.WriteLine(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118331));
	}

	public void GetXMLData(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118239));
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), name);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1649), overridename);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118115), actionparent);
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736), bActive.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118256), bConditionFailOnFirst.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1907), InputType.ToString());
		Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118204), CustomChoiceTitle);
		if (CustomChoices.Count <= 0)
		{
			__ldtoken(Action.GetXMLData(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66286));
			IEnumerator enumerator = CustomChoices.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string value = (string)enumerator.Current;
					CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66317));
					Game.AddXMLSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), value);
					CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66346));
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Action.GetXMLData(ref StringBuilder));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66377));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19895));
		EnhInputData.c83abeab8711e52857623283ffa75d603(ref CurDoc);
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19934));
		if (Conditions.Count <= 0)
		{
			__ldtoken(Action.GetXMLData(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118279));
			IEnumerator enumerator2 = Conditions.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					__ldtoken(Action.GetXMLData(ref StringBuilder));
					Condition condition = (Condition)enumerator2.Current;
					condition.GetXMLData(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(Action.GetXMLData(ref StringBuilder));
				}
				else
				{
					disposable2.Dispose();
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118304));
		}
		if (PassCommands.Count > 0)
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114561));
			for (int i = 0; i < PassCommands.Count; i++)
			{
				__ldtoken(Action.GetXMLData(ref StringBuilder));
				Command command = PassCommands[i] as Command;
				Condition condition2 = PassCommands[i] as Condition;
				if (command != null)
				{
					command.GetXMLData(ref CurDoc);
				}
				else if (condition2 == null)
				{
					__ldtoken(Action.GetXMLData(ref StringBuilder));
				}
				else
				{
					condition2.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114590));
		}
		if (FailCommands.Count > 0)
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114621));
			for (int j = 0; j < FailCommands.Count; j++)
			{
				__ldtoken(Action.GetXMLData(ref StringBuilder));
				Command command2 = FailCommands[j] as Command;
				Condition condition3 = FailCommands[j] as Condition;
				if (command2 == null)
				{
					__ldtoken(Action.GetXMLData(ref StringBuilder));
					condition3?.GetXMLData(ref CurDoc);
				}
				else
				{
					command2.GetXMLData(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114650));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118331));
	}

	public void GetAdvancedText(ref StringBuilder CurDoc)
	{
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118350) + name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118379) + bActive + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
		if (!(overridename != string.Empty))
		{
			__ldtoken(Action.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118400) + overridename + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
		}
		if (!(actionparent != string.Empty))
		{
			__ldtoken(Action.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118431) + actionparent + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
		}
		if (InputType == ActionInputType.None)
		{
			__ldtoken(Action.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118462) + InputType.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118487) + CustomChoiceTitle + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(50561));
		if (CustomChoices.Count <= 0)
		{
			__ldtoken(Action.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66102));
			IEnumerator enumerator = CustomChoices.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					__ldtoken(Action.GetAdvancedText(ref StringBuilder));
					string value = (string)enumerator.Current;
					CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66137));
					Game.AddAdvSection(ref CurDoc, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173), value);
					CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66170));
				}
			}
			finally
			{
				if (!(enumerator is IDisposable disposable))
				{
					__ldtoken(Action.GetAdvancedText(ref StringBuilder));
				}
				else
				{
					disposable.Dispose();
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66205));
		}
		if (Conditions.Count <= 0)
		{
			__ldtoken(Action.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			IEnumerator enumerator2 = Conditions.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					Condition condition = (Condition)enumerator2.Current;
					condition.AddAdvSection(ref CurDoc);
				}
			}
			finally
			{
				if (!(enumerator2 is IDisposable disposable2))
				{
					__ldtoken(Action.GetAdvancedText(ref StringBuilder));
				}
				else
				{
					disposable2.Dispose();
				}
			}
		}
		if (PassCommands.Count <= 0)
		{
			__ldtoken(Action.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114794));
			for (int i = 0; i < PassCommands.Count; i++)
			{
				__ldtoken(Action.GetAdvancedText(ref StringBuilder));
				Command command = PassCommands[i] as Command;
				Condition condition2 = PassCommands[i] as Condition;
				if (command == null)
				{
					__ldtoken(Action.GetAdvancedText(ref StringBuilder));
					if (condition2 == null)
					{
						__ldtoken(Action.GetAdvancedText(ref StringBuilder));
					}
					else
					{
						condition2.GetAdvancedText(ref CurDoc);
					}
				}
				else
				{
					command.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114811));
		}
		if (FailCommands.Count <= 0)
		{
			__ldtoken(Action.GetAdvancedText(ref StringBuilder));
		}
		else
		{
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114830));
			for (int j = 0; j < FailCommands.Count; j++)
			{
				__ldtoken(Action.GetAdvancedText(ref StringBuilder));
				Command command2 = FailCommands[j] as Command;
				Condition condition3 = FailCommands[j] as Condition;
				if (command2 != null)
				{
					command2.GetAdvancedText(ref CurDoc);
				}
				else
				{
					condition3?.GetAdvancedText(ref CurDoc);
				}
			}
			CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114847));
		}
		CurDoc.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118528));
	}

	public void SetXMLData(ref XmlNode CurNode)
	{
		XmlNode xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1173));
		if (xMLSection == null)
		{
			__ldtoken(Action.SetXMLData(ref XmlNode));
		}
		else
		{
			name = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1649));
		if (xMLSection == null)
		{
			__ldtoken(Action.SetXMLData(ref XmlNode));
		}
		else
		{
			overridename = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118115));
		if (xMLSection != null)
		{
			actionparent = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118204));
		if (xMLSection == null)
		{
			__ldtoken(Action.SetXMLData(ref XmlNode));
		}
		else
		{
			CustomChoiceTitle = xMLSection.InnerText;
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1736));
		if (xMLSection == null)
		{
			__ldtoken(Action.SetXMLData(ref XmlNode));
		}
		else
		{
			bActive = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118256));
		if (xMLSection == null)
		{
			__ldtoken(Action.SetXMLData(ref XmlNode));
		}
		else
		{
			bConditionFailOnFirst = Convert.ToBoolean(xMLSection.InnerText);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1907));
		if (xMLSection != null)
		{
			InputType = (ActionInputType)Enum.Parse(typeof(ActionInputType), xMLSection.InnerText, ignoreCase: true);
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(66004));
		if (xMLSection != null)
		{
			for (int i = 0; i < xMLSection.ChildNodes.Count; i++)
			{
				XmlNode xmlNode = xMLSection.ChildNodes[i];
				string innerText = xmlNode.InnerText;
				CustomChoices.Add(innerText);
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(118183));
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
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114412));
		if (xMLSection == null)
		{
			__ldtoken(Action.SetXMLData(ref XmlNode));
		}
		else
		{
			for (int k = 0; k < xMLSection.ChildNodes.Count; k++)
			{
				XmlNode CurNode3 = xMLSection.ChildNodes[k];
				Command command = new Command();
				Condition condition2 = new Condition();
				if (string.Compare(CurNode3.Name, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114895), ignoreCase: true) != 0)
				{
					__ldtoken(Action.SetXMLData(ref XmlNode));
					command.SetXMLData(ref CurNode3);
					PassCommands.Add(command);
				}
				else
				{
					condition2.SetXMLData(ref CurNode3);
					PassCommands.Add(condition2);
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114437));
		if (xMLSection != null)
		{
			for (int l = 0; l < xMLSection.ChildNodes.Count; l++)
			{
				__ldtoken(Action.SetXMLData(ref XmlNode));
				XmlNode CurNode4 = xMLSection.ChildNodes[l];
				Command command2 = new Command();
				Condition condition3 = new Condition();
				if (string.Compare(CurNode4.Name, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(114895), ignoreCase: true) != 0)
				{
					__ldtoken(Action.SetXMLData(ref XmlNode));
					command2.SetXMLData(ref CurNode4);
					FailCommands.Add(command2);
				}
				else
				{
					condition3.SetXMLData(ref CurNode4);
					FailCommands.Add(condition3);
				}
			}
		}
		xMLSection = Game.GetXMLSection(ref CurNode, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(19469));
		if (xMLSection == null)
		{
			__ldtoken(Action.SetXMLData(ref XmlNode));
		}
		else
		{
			EnhInputData.SetXMLData(ref xMLSection);
		}
	}

	public void CallAction(object obj)
	{
		ActionInputType inputType = InputType;
		if (inputType == ActionInputType.Object)
		{
			__ldtoken(Action.CallAction(object));
		}
		else
		{
			_ = 4;
		}
	}

	public Command GetPassCommandByName(string cmdname)
	{
		for (int i = 0; i < PassCommands.Count; i++)
		{
			__ldtoken(Action.GetPassCommandByName(string));
			if (string.Compare(cmdname, ((Command)PassCommands[i]).CommandName, ignoreCase: true) != 0)
			{
				__ldtoken(Action.GetPassCommandByName(string));
				continue;
			}
			return (Command)PassCommands[i];
		}
		return null;
	}

	public Command GetFailCommandByName(string cmdname)
	{
		for (int i = 0; i < FailCommands.Count; i++)
		{
			__ldtoken(Action.GetFailCommandByName(string));
			if (string.Compare(cmdname, ((Command)FailCommands[i]).CommandName, ignoreCase: true) != 0)
			{
				__ldtoken(Action.GetFailCommandByName(string));
				continue;
			}
			return (Command)FailCommands[i];
		}
		return null;
	}

	public Condition GetConditionByName(string condname)
	{
		for (int i = 0; i < Conditions.Count; i++)
		{
			if (string.Compare(condname, ((Condition)Conditions[i]).conditionname, ignoreCase: true) != 0)
			{
				__ldtoken(Action.GetConditionByName(string));
				continue;
			}
			return (Condition)Conditions[i];
		}
		return null;
	}

	public override string ToString()
	{
		return name;
	}

	internal void cf6041572478dfbf6b8008081b026d5c3(Action P_0)
	{
		bActive = P_0.bActive;
	}

	internal void cc738ece0e9315f0db703b90a443636ff(ref StringBuilder P_0)
	{
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + name.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(bActive.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + overridename.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + actionparent + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(bConditionFailOnFirst.ToString().ToLower() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
		P_0.Append(string.Concat(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), InputType, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014)));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + CustomChoiceTitle + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22014));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		int num = 0;
		IEnumerator enumerator = PassCommands.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (num <= 0)
				{
					__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				}
				else
				{
					P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				Command command = current as Command;
				Condition condition = current as Condition;
				if (command != null)
				{
					command.GetJSText(ref P_0);
				}
				else
				{
					condition?.cc738ece0e9315f0db703b90a443636ff(ref P_0);
				}
			}
		}
		finally
		{
			if (!(enumerator is IDisposable disposable))
			{
				__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
			}
			else
			{
				disposable.Dispose();
			}
		}
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		IEnumerator enumerator2 = FailCommands.GetEnumerator();
		try
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				object current2 = enumerator2.Current;
				if (num <= 0)
				{
					__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				}
				else
				{
					P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				Command command2 = current2 as Command;
				Condition condition2 = current2 as Condition;
				if (command2 == null)
				{
					__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
					if (condition2 == null)
					{
						__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
					}
					else
					{
						condition2.cc738ece0e9315f0db703b90a443636ff(ref P_0);
					}
				}
				else
				{
					command2.GetJSText(ref P_0);
				}
			}
		}
		finally
		{
			if (!(enumerator2 is IDisposable disposable2))
			{
				__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
			}
			else
			{
				disposable2.Dispose();
			}
		}
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		num = 0;
		IEnumerator enumerator3 = Conditions.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				Condition condition3 = (Condition)enumerator3.Current;
				if (num <= 0)
				{
					__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
				}
				else
				{
					P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				num++;
				condition3.cc738ece0e9315f0db703b90a443636ff(ref P_0);
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		num = 0;
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926));
		IEnumerator enumerator4 = CustomChoices.GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				string text = (string)enumerator4.Current;
				if (num > 0)
				{
					P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243));
				}
				P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011) + text.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57589), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57592)).Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(51030)) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22011));
				num++;
			}
		}
		finally
		{
			if (!(enumerator4 is IDisposable disposable4))
			{
				__ldtoken(Action.cc738ece0e9315f0db703b90a443636ff(ref StringBuilder));
			}
			else
			{
				disposable4.Dispose();
			}
		}
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(57606));
		EnhInputData.cc738ece0e9315f0db703b90a443636ff(ref P_0);
		P_0.Append(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
	}
}
