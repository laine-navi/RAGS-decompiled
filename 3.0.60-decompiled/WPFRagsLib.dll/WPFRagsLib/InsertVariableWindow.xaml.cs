using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Rags;

namespace WPFRagsLib;

public partial class InsertVariableWindow : Window, IComponentConnector
{
	private Game m_a;

	internal TabControl b;

	internal ListBox c;

	internal ListBox d;

	internal ListBox e;

	internal ComboBox f;

	internal ComboBox g;

	internal ComboBox h;

	internal ComboBox i;

	internal ComboBox j;

	internal TextBox k;

	private bool l;

	public TabControl thetabctrl => this.b;

	public ListBox sysvars => this.c;

	public ListBox vars => this.d;

	public ListBox custprop => this.e;

	public TextBox thetext => k;

	public InsertVariableWindow(ref Game curgame)
	{
		InitializeComponent();
		this.m_a = curgame;
		((Selector)f).SelectedIndex = 0;
		a();
	}

	private void e(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)g).Items.Clear();
		((UIElement)g).IsEnabled = true;
		if (((ContentControl)(ComboBoxItem)((Selector)f).SelectedItem).Content.ToString() == "IA")
		{
			foreach (GameObject @object in this.m_a.ObjectList)
			{
				((ItemsControl)g).Items.Add((object)@object);
			}
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)f).SelectedItem).Content.ToString() == "CA")
		{
			foreach (Character character in this.m_a.CharacterList)
			{
				((ItemsControl)g).Items.Add((object)character);
			}
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)f).SelectedItem).Content.ToString() == "PA")
		{
			((UIElement)g).IsEnabled = false;
			((ItemsControl)h).Items.Clear();
			((ItemsControl)h).Items.Add((object)"Name");
			((ItemsControl)h).Items.Add((object)"Gender");
			((ItemsControl)h).Items.Add((object)"CurRoom");
			((ItemsControl)h).Items.Add((object)"CurPortrait");
			((ItemsControl)h).Items.Add((object)"Action");
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)f).SelectedItem).Content.ToString() == "TA")
		{
			foreach (Timer timer in this.m_a.TimerList)
			{
				((ItemsControl)g).Items.Add((object)timer);
			}
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)f).SelectedItem).Content.ToString() == "RA")
		{
			foreach (Room room in this.m_a.RoomList)
			{
				((ItemsControl)g).Items.Add((object)room);
			}
		}
		if (((UIElement)g).IsEnabled && ((CollectionView)((ItemsControl)g).Items).Count > 0)
		{
			((Selector)g).SelectedIndex = 0;
		}
		else if (((CollectionView)((ItemsControl)h).Items).Count > 0)
		{
			((Selector)h).SelectedIndex = 0;
		}
	}

	private void d(object A_0, SelectionChangedEventArgs A_1)
	{
		((ItemsControl)h).Items.Clear();
		Timer timer = ((Selector)g).SelectedItem as Timer;
		Character character = ((Selector)g).SelectedItem as Character;
		GameObject gameObject = ((Selector)g).SelectedItem as GameObject;
		Room room = ((Selector)g).SelectedItem as Room;
		if (gameObject != null)
		{
			((ItemsControl)h).Items.Add((object)"Name");
			((ItemsControl)h).Items.Add((object)"NameOverride");
			((ItemsControl)h).Items.Add((object)"ID");
			((ItemsControl)h).Items.Add((object)"ClothingLayers");
			((ItemsControl)h).Items.Add((object)"Action");
			((ItemsControl)h).Items.Add((object)"Preposition");
			((ItemsControl)h).Items.Add((object)"Description");
			((ItemsControl)h).Items.Add((object)"Important");
			((ItemsControl)h).Items.Add((object)"Carryable");
			((ItemsControl)h).Items.Add((object)"Wearable");
			((ItemsControl)h).Items.Add((object)"Worn");
			((ItemsControl)h).Items.Add((object)"Container");
			((ItemsControl)h).Items.Add((object)"Openable");
			((ItemsControl)h).Items.Add((object)"Open");
			((ItemsControl)h).Items.Add((object)"Lockable");
			((ItemsControl)h).Items.Add((object)"Locked");
			((ItemsControl)h).Items.Add((object)"Visible");
			((ItemsControl)h).Items.Add((object)"Enterable");
			((ItemsControl)h).Items.Add((object)"Readable");
			((ItemsControl)h).Items.Add((object)"Weight");
		}
		else if (room != null)
		{
			((ItemsControl)h).Items.Add((object)"Name");
			((ItemsControl)h).Items.Add((object)"Description");
			((ItemsControl)h).Items.Add((object)"Action");
			((ItemsControl)h).Items.Add((object)"Exit");
			((ItemsControl)h).Items.Add((object)"SDesc");
			((ItemsControl)h).Items.Add((object)"RoomPic");
			((ItemsControl)h).Items.Add((object)"EnteredFirstTime");
			((ItemsControl)h).Items.Add((object)"LeftFirstTime");
			((ItemsControl)h).Items.Add((object)"ID");
		}
		else if (character != null)
		{
			((ItemsControl)h).Items.Add((object)"Name");
			((ItemsControl)h).Items.Add((object)"OverrideName");
			((ItemsControl)h).Items.Add((object)"Action");
			((ItemsControl)h).Items.Add((object)"Gender");
			((ItemsControl)h).Items.Add((object)"CurrentRoom");
			((ItemsControl)h).Items.Add((object)"AllowInvInteraction");
		}
		else if (timer != null)
		{
			((ItemsControl)h).Items.Add((object)"Name");
			((ItemsControl)h).Items.Add((object)"Active");
			((ItemsControl)h).Items.Add((object)"TimerType");
			((ItemsControl)h).Items.Add((object)"Action");
			((ItemsControl)h).Items.Add((object)"Length");
			((ItemsControl)h).Items.Add((object)"TurnNumber");
			((ItemsControl)h).Items.Add((object)"LiveTimer");
			((ItemsControl)h).Items.Add((object)"TimerSeconds");
		}
		if (((CollectionView)((ItemsControl)h).Items).Count > 0)
		{
			((Selector)h).SelectedIndex = 0;
		}
		b();
	}

	private void b()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		string empty = string.Empty;
		try
		{
			empty = "[" + ((ContentControl)(ComboBoxItem)((Selector)f).SelectedItem).Content.ToString() + ":";
			if (((Selector)g).SelectedItem != null)
			{
				empty = empty + ((Selector)g).SelectedItem.ToString() + ":";
			}
			empty += ((Selector)h).SelectedItem.ToString();
			if (((UIElement)i).IsEnabled)
			{
				string text = empty;
				empty = text + ":" + ((Selector)i).SelectedItem.ToString() + ":" + ((Selector)j).SelectedItem.ToString();
			}
			empty += "]";
		}
		catch
		{
			empty = string.Empty;
		}
		k.Text = empty;
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = true;
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		((Window)this).DialogResult = false;
	}

	private void c(object A_0, SelectionChangedEventArgs A_1)
	{
		((UIElement)this.i).IsEnabled = false;
		((UIElement)j).IsEnabled = false;
		((ItemsControl)this.i).Items.Clear();
		((ItemsControl)j).Items.Clear();
		Timer timer = ((Selector)g).SelectedItem as Timer;
		Character character = ((Selector)g).SelectedItem as Character;
		GameObject gameObject = ((Selector)g).SelectedItem as GameObject;
		Room room = ((Selector)g).SelectedItem as Room;
		if (((Selector)h).SelectedItem == "Action")
		{
			((UIElement)this.i).IsEnabled = true;
			((UIElement)j).IsEnabled = true;
			List<Rags.Action> list = null;
			if (((Selector)f).SelectedItem == "PA")
			{
				list = this.m_a.ThePlayer.Actions;
			}
			else if (gameObject != null)
			{
				list = gameObject.Actions;
			}
			else if (character != null)
			{
				list = character.Actions;
			}
			else if (timer != null)
			{
				list = timer.Actions;
			}
			else if (room != null)
			{
				list = room.Actions;
			}
			if (list != null)
			{
				foreach (Rags.Action item in list)
				{
					((ItemsControl)this.i).Items.Add((object)item);
				}
			}
			if (((CollectionView)((ItemsControl)this.i).Items).Count > 0)
			{
				((Selector)this.i).SelectedIndex = 0;
			}
		}
		else if (((Selector)h).SelectedItem == "Exit")
		{
			((UIElement)this.i).IsEnabled = true;
			((UIElement)j).IsEnabled = true;
			string[] names = Enum.GetNames(typeof(Exit.Directions));
			foreach (string text in names)
			{
				((ItemsControl)this.i).Items.Add((object)text);
			}
			if (((CollectionView)((ItemsControl)this.i).Items).Count > 0)
			{
				((Selector)this.i).SelectedIndex = 0;
			}
		}
		b();
	}

	private void b(object A_0, SelectionChangedEventArgs A_1)
	{
		b();
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		((ItemsControl)j).Items.Clear();
		if (((Selector)h).SelectedItem == "Exit")
		{
			((ItemsControl)j).Items.Add((object)"Active");
			((ItemsControl)j).Items.Add((object)"Destination");
			((ItemsControl)j).Items.Add((object)"Portal");
			((Selector)j).SelectedIndex = 0;
		}
		else
		{
			((ItemsControl)j).Items.Add((object)"Active");
			((ItemsControl)j).Items.Add((object)"OverrideName");
			((ItemsControl)j).Items.Add((object)"ActionParent");
			((ItemsControl)j).Items.Add((object)"InputType");
			((Selector)j).SelectedIndex = 0;
		}
		b();
	}

	private void a()
	{
		((ItemsControl)this.d).Items.Clear();
		((ItemsControl)this.e).Items.Clear();
		List<string> list = new List<string>();
		for (int i = 0; i < this.m_a.VariableList.Count; i++)
		{
			GameVariable gameVariable = this.m_a.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is List<string>)
					{
						list.Add("[v: " + gameVariable.varname + "(" + j + ")(0.." + (((List<string>)gameVariable.VarArray[j]).Count - 1) + ")]");
					}
					else
					{
						list.Add("[v: " + gameVariable.varname + "(" + j + ")]");
					}
				}
			}
			else
			{
				list.Add("[v: " + gameVariable.varname + "]");
			}
		}
		list.Sort();
		foreach (string item in list)
		{
			((ItemsControl)this.d).Items.Add((object)item);
		}
		list.Clear();
		for (int k = 0; k < this.m_a.VariableList.Count; k++)
		{
			GameVariable gameVariable2 = this.m_a.VariableList[k];
			if (gameVariable2.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable2.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable2.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				list.Add("[jsa: " + gameVariable2.varname + "]");
			}
		}
		list.Sort();
		foreach (string item2 in list)
		{
			((ItemsControl)this.d).Items.Add((object)item2);
		}
		list.Clear();
		foreach (Room room in this.m_a.RoomList)
		{
			if (room.CustomProperties.Count <= 0)
			{
				continue;
			}
			int num = 0;
			foreach (Room room2 in this.m_a.RoomList)
			{
				if (room2.Name == room.Name)
				{
					num++;
				}
			}
			if (num > 1)
			{
				foreach (CustomProperty customProperty in room.CustomProperties)
				{
					list.Add("[rp: " + room.UniqueID.ToString() + "(" + room.Name + "):" + customProperty.Name + "]");
				}
				continue;
			}
			foreach (CustomProperty customProperty2 in room.CustomProperties)
			{
				list.Add("[rp: " + room.Name + ":" + customProperty2.Name + "]");
			}
		}
		list.Sort();
		foreach (string item3 in list)
		{
			((ItemsControl)this.e).Items.Add((object)item3);
		}
		list.Clear();
		foreach (CustomProperty customProperty3 in this.m_a.ThePlayer.CustomProperties)
		{
			list.Add("[pp: " + customProperty3.Name + "]");
		}
		list.Sort();
		foreach (string item4 in list)
		{
			((ItemsControl)this.e).Items.Add((object)item4);
		}
		list.Clear();
		foreach (GameObject @object in this.m_a.ObjectList)
		{
			if (@object.CustomProperties.Count <= 0)
			{
				continue;
			}
			int num2 = 0;
			foreach (GameObject object2 in this.m_a.ObjectList)
			{
				if (object2.name == @object.name)
				{
					num2++;
				}
			}
			if (num2 > 1)
			{
				foreach (CustomProperty customProperty4 in @object.CustomProperties)
				{
					list.Add("[ip: " + @object.UniqueIdentifier.ToString() + "(" + @object.name + ") : " + customProperty4.Name + "]");
				}
				continue;
			}
			foreach (CustomProperty customProperty5 in @object.CustomProperties)
			{
				list.Add("[ip: " + @object.name + " : " + customProperty5.Name + "]");
			}
		}
		list.Sort();
		foreach (string item5 in list)
		{
			((ItemsControl)this.e).Items.Add((object)item5);
		}
		list.Clear();
		foreach (Character character in this.m_a.CharacterList)
		{
			if (character.CustomProperties.Count <= 0)
			{
				continue;
			}
			foreach (CustomProperty customProperty6 in character.CustomProperties)
			{
				list.Add("[cp: " + character.Charname + " : " + customProperty6.Name + "]");
			}
		}
		list.Sort();
		foreach (string item6 in list)
		{
			((ItemsControl)this.e).Items.Add((object)item6);
		}
		list.Clear();
		foreach (GameVariable variable in this.m_a.VariableList)
		{
			if (variable.CustomProperties.Count <= 0)
			{
				continue;
			}
			foreach (CustomProperty customProperty7 in variable.CustomProperties)
			{
				list.Add("[vp: " + variable.varname + " : " + customProperty7.Name + "]");
			}
		}
		list.Sort();
		foreach (string item7 in list)
		{
			((ItemsControl)this.e).Items.Add((object)item7);
		}
		list.Clear();
		foreach (Timer timer in this.m_a.TimerList)
		{
			if (timer.CustomProperties.Count <= 0)
			{
				continue;
			}
			foreach (CustomProperty customProperty8 in timer.CustomProperties)
			{
				list.Add("[tp: " + timer.Name + " : " + customProperty8.Name + "]");
			}
		}
		list.Sort();
		foreach (string item8 in list)
		{
			((ItemsControl)this.e).Items.Add((object)item8);
		}
		list.Clear();
	}

	private void a(object A_0, MouseButtonEventArgs A_1)
	{
		b((object)null, (RoutedEventArgs)null);
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Obj, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected Obj, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected Obj, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			this.b = (TabControl)target;
			break;
		case 2:
			this.c = (ListBox)target;
			((Control)this.c).MouseDoubleClick += a;
			break;
		case 3:
			this.d = (ListBox)target;
			((Control)this.d).MouseDoubleClick += a;
			break;
		case 4:
			this.e = (ListBox)target;
			break;
		case 5:
			f = (ComboBox)target;
			((Selector)f).SelectionChanged += e;
			break;
		case 6:
			g = (ComboBox)target;
			((Selector)g).SelectionChanged += d;
			break;
		case 7:
			h = (ComboBox)target;
			((Selector)h).SelectionChanged += c;
			break;
		case 8:
			i = (ComboBox)target;
			((Selector)i).SelectionChanged += a;
			break;
		case 9:
			j = (ComboBox)target;
			((Selector)j).SelectionChanged += b;
			break;
		case 10:
			k = (TextBox)target;
			break;
		case 11:
			((ButtonBase)(Button)target).Click += b;
			break;
		case 12:
			((ButtonBase)(Button)target).Click += a;
			break;
		default:
			l = true;
			break;
		}
	}
}
