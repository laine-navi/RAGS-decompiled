using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Xml;
using Rags;
using WPFRagsLib;

namespace WPFRagsDesigner;

public partial class SearchWindow : Window, IComponentConnector
{
	private RagsDesigner m_a;

	private List<SearchResult> b = new List<SearchResult>();

	internal TextBox c;

	internal ListView d;

	private bool e;

	public SearchWindow(RagsDesigner tempparent)
	{
		InitializeComponent();
		this.m_a = tempparent;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		b = new List<SearchResult>();
		((ItemsControl)d).ItemsSource = b;
		SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
		if (dBConnection == null)
		{
			return;
		}
		foreach (Room room in RagsDesigner.TheGame.RoomList)
		{
			foreach (Rags.Action action in room.Actions)
			{
				StringBuilder CurDoc = new StringBuilder();
				SaveLoad.Action_GetXMLData(ref CurDoc, action);
				if (CurDoc.ToString().IndexOf(c.Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(CurDoc.ToString());
					XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Action/Name");
					string data = "Unknown";
					if (xmlNodeList.Count > 0)
					{
						data = "Action: " + xmlNodeList[0].InnerText;
					}
					b.Add(new SearchResult("Room", room.Name, data, room));
				}
			}
		}
		foreach (Rags.Action action2 in RagsDesigner.TheGame.ThePlayer.Actions)
		{
			StringBuilder CurDoc2 = new StringBuilder();
			SaveLoad.Action_GetXMLData(ref CurDoc2, action2);
			if (CurDoc2.ToString().IndexOf(c.Text, StringComparison.CurrentCultureIgnoreCase) > -1)
			{
				XmlDocument xmlDocument2 = new XmlDocument();
				xmlDocument2.LoadXml(CurDoc2.ToString());
				XmlNodeList xmlNodeList2 = xmlDocument2.SelectNodes("Action/Name");
				string data2 = "Unknown";
				if (xmlNodeList2.Count > 0)
				{
					data2 = "Action: " + xmlNodeList2[0].InnerText;
				}
				b.Add(new SearchResult("Player", "Player Actions", data2, null));
			}
		}
		foreach (GameObject @object in RagsDesigner.TheGame.ObjectList)
		{
			foreach (Rags.Action action3 in @object.Actions)
			{
				StringBuilder CurDoc3 = new StringBuilder();
				SaveLoad.Action_GetXMLData(ref CurDoc3, action3);
				if (CurDoc3.ToString().IndexOf(c.Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument3 = new XmlDocument();
					xmlDocument3.LoadXml(CurDoc3.ToString());
					XmlNodeList xmlNodeList3 = xmlDocument3.SelectNodes("Action/Name");
					string data3 = "Unknown";
					if (xmlNodeList3.Count > 0)
					{
						data3 = "Action: " + xmlNodeList3[0].InnerText;
					}
					b.Add(new SearchResult("Item", @object.name, data3, @object));
				}
			}
		}
		foreach (Character character in RagsDesigner.TheGame.CharacterList)
		{
			foreach (Rags.Action action4 in character.Actions)
			{
				StringBuilder CurDoc4 = new StringBuilder();
				SaveLoad.Action_GetXMLData(ref CurDoc4, action4);
				if (CurDoc4.ToString().IndexOf(c.Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument4 = new XmlDocument();
					xmlDocument4.LoadXml(CurDoc4.ToString());
					XmlNodeList xmlNodeList4 = xmlDocument4.SelectNodes("Action/Name");
					string data4 = "Unknown";
					if (xmlNodeList4.Count > 0)
					{
						data4 = "Action: " + xmlNodeList4[0].InnerText;
					}
					b.Add(new SearchResult("Character", character.Charname, data4, character));
				}
			}
		}
		foreach (Timer timer in RagsDesigner.TheGame.TimerList)
		{
			foreach (Rags.Action action5 in timer.Actions)
			{
				StringBuilder CurDoc5 = new StringBuilder();
				SaveLoad.Action_GetXMLData(ref CurDoc5, action5);
				if (CurDoc5.ToString().IndexOf(c.Text, StringComparison.CurrentCultureIgnoreCase) > -1)
				{
					XmlDocument xmlDocument5 = new XmlDocument();
					xmlDocument5.LoadXml(CurDoc5.ToString());
					XmlNodeList xmlNodeList5 = xmlDocument5.SelectNodes("Action/Name");
					string data5 = "Unknown";
					if (xmlNodeList5.Count > 0)
					{
						data5 = "Action: " + xmlNodeList5[0].InnerText;
					}
					b.Add(new SearchResult("Timer", timer.Name, data5, timer));
				}
			}
		}
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((ListBox)d).SelectedItems.Count > 0 && ((Selector)d).SelectedItem is SearchResult { Type: var type } searchResult)
		{
			_ = searchResult.Name;
			string data = searchResult.Data;
			switch (type)
			{
			case "Room":
				((Selector)this.m_a.u).SelectedIndex = 1;
				((Selector)this.m_a.a0).SelectedIndex = 3;
				((Selector)this.m_a.av).SelectedItem = searchResult.internalobject as Room;
				a(data, this.m_a.cj);
				break;
			case "Item":
				((Selector)this.m_a.u).SelectedIndex = 3;
				((Selector)this.m_a.c3).SelectedIndex = 3;
				this.m_a.SelectTreeObject(((GameObject)searchResult.internalobject).UniqueIdentifier, ((ItemsControl)this.m_a.g7).Items);
				a(data, this.m_a.ea);
				break;
			case "Character":
				((Selector)this.m_a.u).SelectedIndex = 4;
				((Selector)this.m_a.ef).SelectedIndex = 2;
				((Selector)this.m_a.eb).SelectedItem = searchResult.internalobject as Character;
				a(data, this.m_a.e0);
				break;
			case "Player":
				((Selector)this.m_a.u).SelectedIndex = 2;
				((Selector)this.m_a.ck).SelectedIndex = 2;
				a(data, this.m_a.c2);
				break;
			case "Timer":
				((Selector)this.m_a.u).SelectedIndex = 6;
				((Selector)this.m_a.f8).SelectedIndex = 2;
				((Selector)this.m_a.f4).SelectedItem = searchResult.internalobject as Timer;
				a(data, this.m_a.gs);
				break;
			}
		}
	}

	private void a(string A_0, WPFActionControl A_1)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		string[] array = A_0.Split(new string[1] { ":" }, StringSplitOptions.None);
		string obj = array[1].Trim();
		A_1.ExpandCollapseAll(((ItemsControl)A_1.tvActionsConditions).Items, bExpand: true);
		foreach (TreeViewItem item in (IEnumerable)((ItemsControl)A_1.tvActionsConditions).Items)
		{
			TreeViewItem val = item;
			if (!((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.Equals(obj))
			{
				continue;
			}
			val.IsSelected = true;
			((FrameworkElement)val).BringIntoView();
			{
				foreach (TreeViewItem item2 in (IEnumerable)((ItemsControl)val).Items)
				{
					TreeViewItem a_ = item2;
					if (a(a_, A_1))
					{
						break;
					}
				}
				break;
			}
		}
	}

	private bool a(TreeViewItem A_0, WPFActionControl A_1)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		bool flag = false;
		Command command = ((FrameworkElement)A_0).Tag as Command;
		Condition condition = ((FrameworkElement)A_0).Tag as Condition;
		if (command != null)
		{
			flag = command.ContainsValue(c.Text);
			if (flag)
			{
				A_0.IsSelected = true;
				((FrameworkElement)A_0).BringIntoView();
			}
		}
		else if (condition != null)
		{
			flag = condition.ContainsValue(c.Text);
			if (flag)
			{
				A_0.IsSelected = true;
				((FrameworkElement)A_0).BringIntoView();
			}
		}
		if (!flag)
		{
			foreach (TreeViewItem item in (IEnumerable)((ItemsControl)A_0).Items)
			{
				TreeViewItem a_ = item;
				flag = a(a_, A_1);
				if (flag)
				{
					break;
				}
			}
		}
		return flag;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate a(Type A_0, string A_1)
	{
		return Delegate.CreateDelegate(A_0, this, A_1);
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			c = (TextBox)target;
			break;
		case 2:
			((ButtonBase)(Button)target).Click += a;
			break;
		case 3:
			d = (ListView)target;
			((Selector)d).SelectionChanged += a;
			break;
		default:
			e = true;
			break;
		}
	}
}
