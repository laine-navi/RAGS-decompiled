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
	private Game TheGame;

	internal TabControl theTabControl;

	internal ListBox lbSysVariables;

	internal ListBox lbVariables;

	internal ListBox lbCustProp;

	internal ComboBox cbObjectType;

	internal ComboBox cbObject;

	internal ComboBox cbAttribute;

	internal ComboBox cbActionName;

	internal ComboBox cbSecondaryAttribute;

	internal TextBox tbText;

	public TabControl thetabctrl => theTabControl;

	public ListBox sysvars => lbSysVariables;

	public ListBox vars => lbVariables;

	public ListBox custprop => lbCustProp;

	public TextBox thetext => tbText;

	public InsertVariableWindow(ref Game curgame)
	{
		InitializeComponent();
		TheGame = curgame;
		((Selector)cbObjectType).SelectedIndex = 0;
		PopulateVariableMenu();
	}

	private void cbObjectType_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)cbObject).Items.Clear();
		((UIElement)cbObject).IsEnabled = true;
		if (((ContentControl)(ComboBoxItem)((Selector)cbObjectType).SelectedItem).Content.ToString() == "IA")
		{
			foreach (GameObject @object in TheGame.ObjectList)
			{
				((ItemsControl)cbObject).Items.Add((object)@object);
			}
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)cbObjectType).SelectedItem).Content.ToString() == "CA")
		{
			foreach (Character character in TheGame.CharacterList)
			{
				((ItemsControl)cbObject).Items.Add((object)character);
			}
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)cbObjectType).SelectedItem).Content.ToString() == "PA")
		{
			((UIElement)cbObject).IsEnabled = false;
			((ItemsControl)cbAttribute).Items.Clear();
			((ItemsControl)cbAttribute).Items.Add((object)"Name");
			((ItemsControl)cbAttribute).Items.Add((object)"Gender");
			((ItemsControl)cbAttribute).Items.Add((object)"CurRoom");
			((ItemsControl)cbAttribute).Items.Add((object)"CurPortrait");
			((ItemsControl)cbAttribute).Items.Add((object)"Action");
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)cbObjectType).SelectedItem).Content.ToString() == "TA")
		{
			foreach (Timer timer in TheGame.TimerList)
			{
				((ItemsControl)cbObject).Items.Add((object)timer);
			}
		}
		else if (((ContentControl)(ComboBoxItem)((Selector)cbObjectType).SelectedItem).Content.ToString() == "RA")
		{
			foreach (Room room in TheGame.RoomList)
			{
				((ItemsControl)cbObject).Items.Add((object)room);
			}
		}
		if (((UIElement)cbObject).IsEnabled && ((CollectionView)((ItemsControl)cbObject).Items).Count > 0)
		{
			((Selector)cbObject).SelectedIndex = 0;
		}
		else if (((CollectionView)((ItemsControl)cbAttribute).Items).Count > 0)
		{
			((Selector)cbAttribute).SelectedIndex = 0;
		}
	}

	private void cbObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		((ItemsControl)cbAttribute).Items.Clear();
		Timer timer = ((Selector)cbObject).SelectedItem as Timer;
		Character character = ((Selector)cbObject).SelectedItem as Character;
		GameObject gameObject = ((Selector)cbObject).SelectedItem as GameObject;
		Room room = ((Selector)cbObject).SelectedItem as Room;
		if (gameObject != null)
		{
			((ItemsControl)cbAttribute).Items.Add((object)"Name");
			((ItemsControl)cbAttribute).Items.Add((object)"NameOverride");
			((ItemsControl)cbAttribute).Items.Add((object)"ID");
			((ItemsControl)cbAttribute).Items.Add((object)"ClothingLayers");
			((ItemsControl)cbAttribute).Items.Add((object)"Action");
			((ItemsControl)cbAttribute).Items.Add((object)"Preposition");
			((ItemsControl)cbAttribute).Items.Add((object)"Description");
			((ItemsControl)cbAttribute).Items.Add((object)"Important");
			((ItemsControl)cbAttribute).Items.Add((object)"Carryable");
			((ItemsControl)cbAttribute).Items.Add((object)"Wearable");
			((ItemsControl)cbAttribute).Items.Add((object)"Worn");
			((ItemsControl)cbAttribute).Items.Add((object)"Container");
			((ItemsControl)cbAttribute).Items.Add((object)"Openable");
			((ItemsControl)cbAttribute).Items.Add((object)"Open");
			((ItemsControl)cbAttribute).Items.Add((object)"Lockable");
			((ItemsControl)cbAttribute).Items.Add((object)"Locked");
			((ItemsControl)cbAttribute).Items.Add((object)"Visible");
			((ItemsControl)cbAttribute).Items.Add((object)"Enterable");
			((ItemsControl)cbAttribute).Items.Add((object)"Readable");
			((ItemsControl)cbAttribute).Items.Add((object)"Weight");
		}
		else if (room != null)
		{
			((ItemsControl)cbAttribute).Items.Add((object)"Name");
			((ItemsControl)cbAttribute).Items.Add((object)"Description");
			((ItemsControl)cbAttribute).Items.Add((object)"Action");
			((ItemsControl)cbAttribute).Items.Add((object)"Exit");
			((ItemsControl)cbAttribute).Items.Add((object)"SDesc");
			((ItemsControl)cbAttribute).Items.Add((object)"RoomPic");
			((ItemsControl)cbAttribute).Items.Add((object)"EnteredFirstTime");
			((ItemsControl)cbAttribute).Items.Add((object)"LeftFirstTime");
			((ItemsControl)cbAttribute).Items.Add((object)"ID");
		}
		else if (character != null)
		{
			((ItemsControl)cbAttribute).Items.Add((object)"Name");
			((ItemsControl)cbAttribute).Items.Add((object)"OverrideName");
			((ItemsControl)cbAttribute).Items.Add((object)"Action");
			((ItemsControl)cbAttribute).Items.Add((object)"Gender");
			((ItemsControl)cbAttribute).Items.Add((object)"CurrentRoom");
			((ItemsControl)cbAttribute).Items.Add((object)"AllowInvInteraction");
		}
		else if (timer != null)
		{
			((ItemsControl)cbAttribute).Items.Add((object)"Name");
			((ItemsControl)cbAttribute).Items.Add((object)"Active");
			((ItemsControl)cbAttribute).Items.Add((object)"TimerType");
			((ItemsControl)cbAttribute).Items.Add((object)"Action");
			((ItemsControl)cbAttribute).Items.Add((object)"Length");
			((ItemsControl)cbAttribute).Items.Add((object)"TurnNumber");
			((ItemsControl)cbAttribute).Items.Add((object)"LiveTimer");
			((ItemsControl)cbAttribute).Items.Add((object)"TimerSeconds");
		}
		if (((CollectionView)((ItemsControl)cbAttribute).Items).Count > 0)
		{
			((Selector)cbAttribute).SelectedIndex = 0;
		}
		UpdateText();
	}

	private void UpdateText()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		string empty = string.Empty;
		try
		{
			empty = "[" + ((ContentControl)(ComboBoxItem)((Selector)cbObjectType).SelectedItem).Content.ToString() + ":";
			if (((Selector)cbObject).SelectedItem != null)
			{
				empty = empty + ((Selector)cbObject).SelectedItem.ToString() + ":";
			}
			empty += ((Selector)cbAttribute).SelectedItem.ToString();
			if (((UIElement)cbActionName).IsEnabled)
			{
				string text = empty;
				empty = text + ":" + ((Selector)cbActionName).SelectedItem.ToString() + ":" + ((Selector)cbSecondaryAttribute).SelectedItem.ToString();
			}
			empty += "]";
		}
		catch
		{
			empty = string.Empty;
		}
		tbText.Text = empty;
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		((Window)this).DialogResult = true;
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		((Window)this).DialogResult = false;
	}

	private void cbAttribute_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		((UIElement)cbActionName).IsEnabled = false;
		((UIElement)cbSecondaryAttribute).IsEnabled = false;
		((ItemsControl)cbActionName).Items.Clear();
		((ItemsControl)cbSecondaryAttribute).Items.Clear();
		Timer timer = ((Selector)cbObject).SelectedItem as Timer;
		Character character = ((Selector)cbObject).SelectedItem as Character;
		GameObject gameObject = ((Selector)cbObject).SelectedItem as GameObject;
		Room room = ((Selector)cbObject).SelectedItem as Room;
		if (((Selector)cbAttribute).SelectedItem == "Action")
		{
			((UIElement)cbActionName).IsEnabled = true;
			((UIElement)cbSecondaryAttribute).IsEnabled = true;
			List<Rags.Action> list = null;
			if (((Selector)cbObjectType).SelectedItem == "PA")
			{
				list = TheGame.ThePlayer.Actions;
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
					((ItemsControl)cbActionName).Items.Add((object)item);
				}
			}
			if (((CollectionView)((ItemsControl)cbActionName).Items).Count > 0)
			{
				((Selector)cbActionName).SelectedIndex = 0;
			}
		}
		else if (((Selector)cbAttribute).SelectedItem == "Exit")
		{
			((UIElement)cbActionName).IsEnabled = true;
			((UIElement)cbSecondaryAttribute).IsEnabled = true;
			string[] names = Enum.GetNames(typeof(Exit.Directions));
			foreach (string text in names)
			{
				((ItemsControl)cbActionName).Items.Add((object)text);
			}
			if (((CollectionView)((ItemsControl)cbActionName).Items).Count > 0)
			{
				((Selector)cbActionName).SelectedIndex = 0;
			}
		}
		UpdateText();
	}

	private void cbSecondaryAttribute_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		UpdateText();
	}

	private void cbActionName_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		((ItemsControl)cbSecondaryAttribute).Items.Clear();
		if (((Selector)cbAttribute).SelectedItem == "Exit")
		{
			((ItemsControl)cbSecondaryAttribute).Items.Add((object)"Active");
			((ItemsControl)cbSecondaryAttribute).Items.Add((object)"Destination");
			((ItemsControl)cbSecondaryAttribute).Items.Add((object)"Portal");
			((Selector)cbSecondaryAttribute).SelectedIndex = 0;
		}
		else
		{
			((ItemsControl)cbSecondaryAttribute).Items.Add((object)"Active");
			((ItemsControl)cbSecondaryAttribute).Items.Add((object)"OverrideName");
			((ItemsControl)cbSecondaryAttribute).Items.Add((object)"ActionParent");
			((ItemsControl)cbSecondaryAttribute).Items.Add((object)"InputType");
			((Selector)cbSecondaryAttribute).SelectedIndex = 0;
		}
		UpdateText();
	}

	private void PopulateVariableMenu()
	{
		((ItemsControl)lbVariables).Items.Clear();
		((ItemsControl)lbCustProp).Items.Clear();
		List<string> list = new List<string>();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
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
			((ItemsControl)lbVariables).Items.Add((object)item);
		}
		list.Clear();
		for (int k = 0; k < TheGame.VariableList.Count; k++)
		{
			GameVariable gameVariable2 = TheGame.VariableList[k];
			if (gameVariable2.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable2.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable2.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				list.Add("[jsa: " + gameVariable2.varname + "]");
			}
		}
		list.Sort();
		foreach (string item2 in list)
		{
			((ItemsControl)lbVariables).Items.Add((object)item2);
		}
		list.Clear();
		foreach (Room room in TheGame.RoomList)
		{
			if (room.CustomProperties.Count <= 0)
			{
				continue;
			}
			int num = 0;
			foreach (Room room2 in TheGame.RoomList)
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
			((ItemsControl)lbCustProp).Items.Add((object)item3);
		}
		list.Clear();
		foreach (CustomProperty customProperty3 in TheGame.ThePlayer.CustomProperties)
		{
			list.Add("[pp: " + customProperty3.Name + "]");
		}
		list.Sort();
		foreach (string item4 in list)
		{
			((ItemsControl)lbCustProp).Items.Add((object)item4);
		}
		list.Clear();
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (@object.CustomProperties.Count <= 0)
			{
				continue;
			}
			int num2 = 0;
			foreach (GameObject object2 in TheGame.ObjectList)
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
			((ItemsControl)lbCustProp).Items.Add((object)item5);
		}
		list.Clear();
		foreach (Character character in TheGame.CharacterList)
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
			((ItemsControl)lbCustProp).Items.Add((object)item6);
		}
		list.Clear();
		foreach (GameVariable variable in TheGame.VariableList)
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
			((ItemsControl)lbCustProp).Items.Add((object)item7);
		}
		list.Clear();
		foreach (Timer timer in TheGame.TimerList)
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
			((ItemsControl)lbCustProp).Items.Add((object)item8);
		}
		list.Clear();
	}

	private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		Button_Click(null, null);
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
			theTabControl = (TabControl)target;
			break;
		case 2:
			lbSysVariables = (ListBox)target;
			((Control)lbSysVariables).MouseDoubleClick += ListBoxItem_MouseDoubleClick;
			break;
		case 3:
			lbVariables = (ListBox)target;
			((Control)lbVariables).MouseDoubleClick += ListBoxItem_MouseDoubleClick;
			break;
		case 4:
			lbCustProp = (ListBox)target;
			break;
		case 5:
			cbObjectType = (ComboBox)target;
			((Selector)cbObjectType).SelectionChanged += cbObjectType_SelectionChanged;
			break;
		case 6:
			cbObject = (ComboBox)target;
			((Selector)cbObject).SelectionChanged += cbObject_SelectionChanged;
			break;
		case 7:
			cbAttribute = (ComboBox)target;
			((Selector)cbAttribute).SelectionChanged += cbAttribute_SelectionChanged;
			break;
		case 8:
			cbActionName = (ComboBox)target;
			((Selector)cbActionName).SelectionChanged += cbActionName_SelectionChanged;
			break;
		case 9:
			cbSecondaryAttribute = (ComboBox)target;
			((Selector)cbSecondaryAttribute).SelectionChanged += cbSecondaryAttribute_SelectionChanged;
			break;
		case 10:
			tbText = (TextBox)target;
			break;
		case 11:
			((ButtonBase)(Button)target).Click += Button_Click;
			break;
		case 12:
			((ButtonBase)(Button)target).Click += Button_Click_1;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
