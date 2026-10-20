using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Polenter.Serialization;
using Rags;

namespace WPFRagsLib;

public partial class WPFActionControl : UserControl, IComponentConnector
{
	public enum PageType
	{
		objects,
		characters,
		room,
		player,
		timers,
		quickcommand
	}

	private Game TheGame;

	private string TheCurrentObject = string.Empty;

	private Point startPoint;

	private List<Rags.Action> UndoActions;

	private static MemoryStream ClipboardMS = new MemoryStream();

	internal Grid TreeControl;

	public TreeView tvActionsConditions;

	internal GroupBox gbActionAttributes;

	internal TextBox tbActionNameOverride;

	internal CheckBox cbActionActive;

	internal ComboBox cbActionParent;

	internal GroupBox gbCondBehavior;

	internal RadioButton rbFailOnFirst;

	internal RadioButton rbRunAll;

	internal GroupBox gbAddInput;

	internal RadioButton rbaddinputnone;

	internal RadioButton rbaddinputObject;

	internal RadioButton rbaddinputCharacter;

	internal RadioButton rbaddinputText;

	internal RadioButton rbaddinputObjectorCharacter;

	internal RadioButton rbaddinputCustom;

	internal RadioButton rbAddInputInventory;

	internal Button btnAdvancedOptions;

	internal GroupBox gbCustomChoices;

	internal TextBox tbCustomChoiceTitle;

	internal ListBox lbActionCustomChoices;

	internal Button btnActionCustomAdd;

	internal Button btnActionCustomUpdate;

	internal Button btnActionCustomDelete;

	internal GroupBox gbCommands;

	internal Grid grdCommandGrid;

	internal Grid grdCommandSteps;

	internal ComboBox cbCommandStep1;

	internal Label lblCommandStep2;

	internal ComboBox cbCommandStep2;

	internal Label lblCommandStep3;

	internal Label lblCommandText;

	internal ComboBox cbCommandStep3;

	internal TextBox txtCommandText;

	internal Label lblCommandStep4;

	internal ComboBox cbCommandStep4;

	internal TextBox txtStep4;

	internal GroupBox gbCommandChoices;

	internal ListBox lbCustomChoices;

	internal Button CmdAddCustomChoice;

	internal Button CmdUpdateCustomChoice;

	internal Button CmdDelCustomChoice;

	internal Button CmdAdvCustomChoice;

	internal GroupBox gbConditionData;

	internal TextBox txtConditionName;

	internal ListBox lbChecks;

	internal Label lblConditionStep1;

	internal ComboBox cbConditionStep1;

	internal Label lblConditionStep2;

	internal ComboBox cbConditionStep2;

	internal Label lblConditionStep3;

	internal ComboBox cbConditionStep3;

	internal Label lblConditionStep4;

	internal ComboBox cbConditionStep4;

	internal TextBox txtConditionStep4;

	public PageType ThePageType { get; set; }

	public WPFActionControl()
	{
		InitializeComponent();
		SaveLoad.PopulateComboWithCommands(((ItemsControl)cbCommandStep1).Items, bFilter: true);
		SaveLoad.PopulateComboWithConditions(((ItemsControl)cbConditionStep1).Items, bFilter: true);
	}

	public void SetGameObject(ref Game CurGame)
	{
		TheGame = CurGame;
	}

	public void SetPageType(PageType pt)
	{
		ThePageType = pt;
	}

	public void SetObjectName(string name)
	{
		TheCurrentObject = name;
	}

	public void RefreshActions()
	{
		((UIElement)tvActionsConditions).IsEnabled = true;
		((ItemsControl)tvActionsConditions).Items.Clear();
		List<Rags.Action> list = n();
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Rags.Action a_ = list[i];
				a(a_, -1, A_2: false);
			}
			r();
		}
	}

	private Rags.Action s()
	{
		if (tvActionsConditions.SelectedItem != null)
		{
			object selectedItem = tvActionsConditions.SelectedItem;
			TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
			while (val != null && ((FrameworkElement)val).Parent is TreeViewItem)
			{
				DependencyObject parent = ((FrameworkElement)val).Parent;
				val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			}
			return ((FrameworkElement)val).Tag as Rags.Action;
		}
		return null;
	}

	private void r()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem != null)
		{
			((UIElement)gbCommands).IsEnabled = true;
			((UIElement)gbConditionData).IsEnabled = true;
			((UIElement)gbCustomChoices).IsEnabled = true;
			((UIElement)gbCondBehavior).IsEnabled = true;
			((UIElement)cbConditionStep2).Visibility = (Visibility)1;
			((UIElement)lblConditionStep2).Visibility = (Visibility)1;
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			if (o() && !(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition))
			{
				Rags.Action action = s();
				tbCustomChoiceTitle.Text = action.CustomChoiceTitle;
				tbActionNameOverride.Text = action.overridename;
				p();
				((ItemsControl)lbActionCustomChoices).Items.Clear();
				foreach (string customChoice in action.CustomChoices)
				{
					((ItemsControl)lbActionCustomChoices).Items.Add((object)customChoice);
				}
				((ToggleButton)cbActionActive).IsChecked = action.bActive;
				if (action.bConditionFailOnFirst)
				{
					((ToggleButton)rbFailOnFirst).IsChecked = true;
				}
				else
				{
					((ToggleButton)rbRunAll).IsChecked = true;
				}
				((UIElement)gbCustomChoices).IsEnabled = false;
				switch (action.InputType)
				{
				case Rags.Action.ActionInputType.None:
					((ToggleButton)rbaddinputnone).IsChecked = true;
					((UIElement)gbCustomChoices).IsEnabled = false;
					((UIElement)lbActionCustomChoices).IsEnabled = false;
					((UIElement)tbCustomChoiceTitle).IsEnabled = false;
					((UIElement)btnActionCustomAdd).IsEnabled = false;
					((UIElement)btnActionCustomUpdate).IsEnabled = false;
					((UIElement)btnActionCustomDelete).IsEnabled = false;
					break;
				case Rags.Action.ActionInputType.Character:
					((ToggleButton)rbaddinputCharacter).IsChecked = true;
					((UIElement)gbCustomChoices).IsEnabled = true;
					((UIElement)lbActionCustomChoices).IsEnabled = false;
					((UIElement)tbCustomChoiceTitle).IsEnabled = true;
					((UIElement)btnActionCustomAdd).IsEnabled = false;
					((UIElement)btnActionCustomUpdate).IsEnabled = false;
					((UIElement)btnActionCustomDelete).IsEnabled = false;
					break;
				case Rags.Action.ActionInputType.Object:
					((ToggleButton)rbaddinputObject).IsChecked = true;
					((UIElement)gbCustomChoices).IsEnabled = true;
					((UIElement)lbActionCustomChoices).IsEnabled = false;
					((UIElement)tbCustomChoiceTitle).IsEnabled = true;
					((UIElement)btnActionCustomAdd).IsEnabled = false;
					((UIElement)btnActionCustomUpdate).IsEnabled = false;
					((UIElement)btnActionCustomDelete).IsEnabled = false;
					break;
				case Rags.Action.ActionInputType.ObjectOrCharacter:
					((ToggleButton)rbaddinputObjectorCharacter).IsChecked = true;
					((UIElement)gbCustomChoices).IsEnabled = true;
					((UIElement)lbActionCustomChoices).IsEnabled = false;
					((UIElement)tbCustomChoiceTitle).IsEnabled = true;
					((UIElement)btnActionCustomAdd).IsEnabled = false;
					((UIElement)btnActionCustomUpdate).IsEnabled = false;
					((UIElement)btnActionCustomDelete).IsEnabled = false;
					break;
				case Rags.Action.ActionInputType.Text:
					((ToggleButton)rbaddinputText).IsChecked = true;
					((UIElement)gbCustomChoices).IsEnabled = true;
					((UIElement)lbActionCustomChoices).IsEnabled = false;
					((UIElement)tbCustomChoiceTitle).IsEnabled = true;
					((UIElement)btnActionCustomAdd).IsEnabled = false;
					((UIElement)btnActionCustomUpdate).IsEnabled = false;
					((UIElement)btnActionCustomDelete).IsEnabled = false;
					break;
				case Rags.Action.ActionInputType.Custom:
					((ToggleButton)rbaddinputCustom).IsChecked = true;
					((UIElement)gbCustomChoices).IsEnabled = true;
					tbCustomChoiceTitle.Text = action.CustomChoiceTitle;
					((UIElement)gbCustomChoices).IsEnabled = true;
					((UIElement)lbActionCustomChoices).IsEnabled = true;
					((UIElement)tbCustomChoiceTitle).IsEnabled = true;
					((UIElement)btnActionCustomAdd).IsEnabled = true;
					((UIElement)btnActionCustomUpdate).IsEnabled = true;
					((UIElement)btnActionCustomDelete).IsEnabled = true;
					break;
				case Rags.Action.ActionInputType.Inventory:
					((ToggleButton)rbAddInputInventory).IsChecked = true;
					((UIElement)gbCustomChoices).IsEnabled = true;
					((UIElement)lbActionCustomChoices).IsEnabled = false;
					((UIElement)tbCustomChoiceTitle).IsEnabled = true;
					((UIElement)btnActionCustomAdd).IsEnabled = false;
					((UIElement)btnActionCustomUpdate).IsEnabled = false;
					((UIElement)btnActionCustomDelete).IsEnabled = false;
					break;
				}
			}
			else
			{
				Condition condition = q();
				if (condition != null)
				{
					a(condition);
					txtConditionName.Text = condition.conditionname;
					((Selector)lbChecks).SelectedIndex = 0;
				}
			}
			object selectedItem = tvActionsConditions.SelectedItem;
			TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
			if (!(((FrameworkElement)val).Tag is Command command))
			{
				return;
			}
			((ItemsControl)lbCustomChoices).Items.Clear();
			foreach (string customChoice2 in command.CustomChoices)
			{
				((ItemsControl)lbCustomChoices).Items.Add((object)customChoice2);
			}
			txtCommandText.Text = command.CommandText;
			txtStep4.Text = command.CommandPart4;
			((Selector)cbConditionStep1).SelectedItem = SaveLoad.GetCommandItem(((ItemsControl)cbCommandStep1).Items, command.cmdtype);
			h((object)null, (SelectionChangedEventArgs)null);
			try
			{
				Guid guid = new Guid(command.CommandPart2);
				foreach (RoomComboItem item in (IEnumerable)((ItemsControl)cbCommandStep2).Items)
				{
					if (item.UniqueID == guid)
					{
						((Selector)cbCommandStep2).SelectedItem = item;
						break;
					}
				}
			}
			catch
			{
				cbCommandStep2.Text = command.CommandPart2;
			}
			try
			{
				Guid guid2 = new Guid(command.CommandPart3);
				foreach (RoomComboItem item2 in (IEnumerable)((ItemsControl)cbCommandStep3).Items)
				{
					if (item2.UniqueID == guid2)
					{
						((Selector)cbCommandStep3).SelectedItem = item2;
						break;
					}
				}
			}
			catch
			{
				cbCommandStep3.Text = command.CommandPart3;
			}
			try
			{
				Guid guid3 = new Guid(command.CommandPart4);
				for (int i = 0; i < ((CollectionView)((ItemsControl)cbCommandStep4).Items).Count; i++)
				{
					RoomComboItem roomComboItem3 = null;
					try
					{
						roomComboItem3 = (RoomComboItem)((ItemsControl)cbCommandStep4).Items[i];
					}
					catch
					{
						roomComboItem3 = null;
					}
					if (roomComboItem3 != null && roomComboItem3.UniqueID == guid3)
					{
						((Selector)cbCommandStep4).SelectedItem = roomComboItem3;
						break;
					}
				}
				return;
			}
			catch
			{
				cbCommandStep4.Text = command.CommandPart4;
				return;
			}
		}
		((UIElement)gbCommands).IsEnabled = false;
		((UIElement)gbConditionData).IsEnabled = false;
		((UIElement)gbCustomChoices).IsEnabled = false;
		((UIElement)gbCondBehavior).IsEnabled = false;
	}

	private void a(Condition A_0)
	{
		((ItemsControl)lbChecks).Items.Clear();
		foreach (Check check in A_0.Checks)
		{
			if (check.CkType != CheckType.CT_Uninitialized)
			{
				((ItemsControl)lbChecks).Items.Add((object)(check.CkType.ToString() + " " + SaveLoad.GetConditionName(check.CondType)));
			}
			else
			{
				((ItemsControl)lbChecks).Items.Add((object)SaveLoad.GetConditionName(check.CondType));
			}
		}
		if (((CollectionView)((ItemsControl)lbChecks).Items).Count > 0)
		{
			((Selector)lbChecks).SelectedIndex = 0;
		}
	}

	private Condition q()
	{
		Condition condition = null;
		int num = 0;
		object selectedItem = tvActionsConditions.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		while (((FrameworkElement)val).Parent is TreeViewItem)
		{
			num++;
			DependencyObject parent = ((FrameworkElement)val).Parent;
			val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		if (num >= 1)
		{
			object selectedItem2 = tvActionsConditions.SelectedItem;
			TreeViewItem val2 = (TreeViewItem)((selectedItem2 is TreeViewItem) ? selectedItem2 : null);
			condition = ((FrameworkElement)val2).Tag as Condition;
			while (condition == null && val2 != null)
			{
				DependencyObject parent2 = ((FrameworkElement)val2).Parent;
				val2 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
				condition = ((val2 != null) ? (((FrameworkElement)val2).Tag as Condition) : null);
			}
		}
		return condition;
	}

	private void p()
	{
		Rags.Action action = s();
		if (action == null)
		{
			return;
		}
		((ItemsControl)cbActionParent).Items.Clear();
		((ItemsControl)cbActionParent).Items.Add((object)"None");
		if (action.actionparent == "None")
		{
			((Selector)cbActionParent).SelectedIndex = 0;
		}
		List<Rags.Action> list = n();
		for (int i = 0; i < list.Count; i++)
		{
			Rags.Action action2 = list[i];
			if (!action2.name.Contains("<<") && action2.name != action.name)
			{
				int selectedIndex = ((ItemsControl)cbActionParent).Items.Add((object)action2.name);
				if (action.actionparent == action2.name)
				{
					((Selector)cbActionParent).SelectedIndex = selectedIndex;
				}
			}
		}
	}

	private bool o()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		object selectedItem = tvActionsConditions.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		string strA = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.ToString();
		if (string.Compare(strA, "Commands On Success", ignoreCase: true) != 0 && string.Compare(strA, "Commands On Failure", ignoreCase: true) != 0)
		{
			if (((FrameworkElement)val).Tag is Rags.Action)
			{
				return true;
			}
			int num = 0;
			DependencyObject parent = ((FrameworkElement)val).Parent;
			TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			while (val2 != null)
			{
				num++;
				DependencyObject parent2 = ((FrameworkElement)val2).Parent;
				val2 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
			}
			if ((((FrameworkElement)val).Tag is Command && num == 2) || (((FrameworkElement)val).Tag is Condition && num == 2))
			{
				return true;
			}
		}
		else if (((FrameworkElement)(TreeViewItem)((FrameworkElement)val).Parent).Tag is Rags.Action)
		{
			return true;
		}
		return false;
	}

	private void a(Rags.Action A_0, int A_1, bool A_2)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		if (A_0 == null)
		{
			return;
		}
		TreeViewItem val = new TreeViewItem();
		((HeaderedItemsControl)val).Header = b(A_0.name, "pack://application:,,/Images/run.png");
		((FrameworkElement)val).Tag = A_0;
		for (int i = 0; i < A_0.Conditions.Count; i++)
		{
			a(A_0.Conditions[i], val, -1);
		}
		TreeViewItem val2 = new TreeViewItem();
		((HeaderedItemsControl)val2).Header = b("Commands on Success", "pack://application:,,/Images/Green.png");
		((ItemsControl)val).Items.Add((object)val2);
		TreeViewItem val3 = new TreeViewItem();
		((HeaderedItemsControl)val3).Header = b("Commands on Failure", "pack://application:,,/Images/Red.png");
		((ItemsControl)val).Items.Add((object)val3);
		for (int j = 0; j < A_0.PassCommands.Count; j++)
		{
			Command command = A_0.PassCommands[j] as Command;
			Condition condition = A_0.PassCommands[j] as Condition;
			if (command != null)
			{
				a(command, val2);
			}
			else if (condition != null)
			{
				a(condition, val2, -1);
			}
		}
		for (int k = 0; k < A_0.FailCommands.Count; k++)
		{
			Command command2 = A_0.FailCommands[k] as Command;
			Condition condition2 = A_0.FailCommands[k] as Condition;
			if (command2 != null)
			{
				a(command2, val3);
			}
			else if (condition2 != null)
			{
				a(condition2, val3, -1);
			}
		}
		if (A_1 == -1)
		{
			((ItemsControl)tvActionsConditions).Items.Add((object)val);
		}
		else
		{
			((ItemsControl)tvActionsConditions).Items.Insert(A_1, (object)val);
		}
	}

	private string a(Command A_0)
	{
		string text = string.Empty;
		if (A_0 != null)
		{
			text = SaveLoad.GetCommandName(A_0.cmdtype);
			if (A_0.CommandPart2 != string.Empty)
			{
				try
				{
					Guid guid = new Guid(A_0.CommandPart2);
					if (guid == Room.CurrentRoomGuid)
					{
						text += ": <CurrentRoom>";
					}
					else if (guid == Room.VoidRoomGuid)
					{
						text += ": <Void>";
					}
					else if (guid == GameObject.SelfObjectGuid)
					{
						text += ": <<Self>>";
					}
					else
					{
						text = ((TheGame.GetRoomByID(guid) == null) ? (text + ": " + TheGame.GetObjectByName(guid.ToString()).name) : (text + ": " + TheGame.GetRoomByID(guid).Name));
					}
				}
				catch
				{
					text = text + ": " + A_0.CommandPart2;
				}
			}
			if (A_0.CommandPart3 != string.Empty)
			{
				try
				{
					Guid guid2 = new Guid(A_0.CommandPart3);
					if (guid2 == Room.CurrentRoomGuid)
					{
						text += ", <CurrentRoom>";
					}
					else if (guid2 == Room.VoidRoomGuid)
					{
						text += ", <Void>";
					}
					else if (guid2 == GameObject.SelfObjectGuid)
					{
						text += ": <<Self>>";
					}
					else
					{
						text = ((TheGame.GetRoomByID(guid2) == null) ? (text + ", " + TheGame.GetObjectByName(guid2.ToString()).name) : (text + ", " + TheGame.GetRoomByID(guid2).Name));
					}
				}
				catch
				{
					text = text + ", " + A_0.CommandPart3;
				}
			}
			if (A_0.CommandPart4 != string.Empty)
			{
				try
				{
					Guid guid3 = new Guid(A_0.CommandPart4);
					if (guid3 == Room.CurrentRoomGuid)
					{
						text += ", <CurrentRoom>";
					}
					else if (guid3 == Room.VoidRoomGuid)
					{
						text += ", <Void>";
					}
					else if (guid3 == GameObject.SelfObjectGuid)
					{
						text += ": <<Self>>";
					}
					else
					{
						text = ((TheGame.GetRoomByID(guid3) == null) ? (text + ", " + TheGame.GetObjectByName(guid3.ToString()).name) : (text + ", " + TheGame.GetRoomByID(guid3).Name));
					}
				}
				catch
				{
					text = text + ", " + A_0.CommandPart4;
				}
			}
			if (A_0.CommandText != string.Empty)
			{
				text = ((A_0.CommandText.Length <= 20) ? (text + ", " + A_0.CommandText) : (text + ", " + A_0.CommandText.Substring(0, 20) + "..."));
			}
		}
		return text;
	}

	private void a(Command A_0, TreeViewItem A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		TreeViewItem val = new TreeViewItem();
		((HeaderedItemsControl)val).Header = b(a(A_0), "pack://application:,,/Images/command.png");
		((FrameworkElement)val).Tag = A_0;
		((ItemsControl)A_1).Items.Add((object)val);
	}

	private StackPanel b(string A_0, string A_1)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		StackPanel val = new StackPanel();
		val.Orientation = (Orientation)0;
		((FrameworkElement)val).Height = 22.0;
		Image val2 = new Image();
		val2.Source = (ImageSource)new BitmapImage(new Uri(A_1));
		((FrameworkElement)val2).Width = 16.0;
		((FrameworkElement)val2).Height = 16.0;
		Label val3 = new Label();
		((ContentControl)val3).Content = A_0;
		((FrameworkElement)val3).VerticalAlignment = (VerticalAlignment)1;
		((FrameworkElement)val2).VerticalAlignment = (VerticalAlignment)1;
		((Control)val3).FontSize = 9.0;
		((Panel)val).Children.Add((UIElement)(object)val2);
		((Panel)val).Children.Add((UIElement)(object)val3);
		return val;
	}

	private void a(Condition A_0, TreeViewItem A_1, int A_2)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		TreeViewItem val = new TreeViewItem();
		((FrameworkElement)val).Tag = A_0;
		((HeaderedItemsControl)val).Header = b(A_0.conditionname, "pack://application:,,/Images/Question.png");
		((FrameworkElement)val).Tag = A_0;
		TreeViewItem val2 = new TreeViewItem();
		((HeaderedItemsControl)val2).Header = b("Commands on Success", "pack://application:,,/Images/Green.png");
		((ItemsControl)val).Items.Add((object)val2);
		TreeViewItem val3 = new TreeViewItem();
		((HeaderedItemsControl)val3).Header = b("Commands on Failure", "pack://application:,,/Images/Red.png");
		((ItemsControl)val).Items.Add((object)val3);
		for (int i = 0; i < A_0.PassCommands.Count; i++)
		{
			if (A_0.PassCommands[i] is Command a_)
			{
				a(a_, val2);
			}
			else if (A_0.PassCommands[i] is Condition a_2)
			{
				a(a_2, val2, -1);
			}
		}
		for (int j = 0; j < A_0.FailCommands.Count; j++)
		{
			if (A_0.FailCommands[j] is Command a_3)
			{
				a(a_3, val3);
			}
			else if (A_0.FailCommands[j] is Condition a_4)
			{
				a(a_4, val3, -1);
			}
		}
		if (A_2 == -1)
		{
			((ItemsControl)A_1).Items.Add((object)val);
		}
		else
		{
			((ItemsControl)A_1).Items.Insert(A_2, (object)val);
		}
		val.IsSelected = true;
		((FrameworkElement)val).BringIntoView();
	}

	public bool SelectActionTreeObject(string thename, ItemCollection data)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		bool flag = false;
		foreach (TreeViewItem item in (IEnumerable)data)
		{
			TreeViewItem val = item;
			if (!(((FrameworkElement)val).Tag is GamePicture) && !flag)
			{
				if (((CollectionView)((ItemsControl)val).Items).Count > 0)
				{
					flag = SelectActionTreeObject(thename, ((ItemsControl)val).Items);
				}
			}
			else if (((FrameworkElement)val).Tag != null && ((FrameworkElement)val).Tag is GamePicture && ((GamePicture)((FrameworkElement)val).Tag).TheName == thename)
			{
				val.IsSelected = true;
				DependencyObject parent = ((FrameworkElement)val).Parent;
				TreeViewItem val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
				while (val2 != null)
				{
					val2.IsExpanded = true;
					DependencyObject parent2 = ((FrameworkElement)val2).Parent;
					val2 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
				}
				return true;
			}
		}
		return flag;
	}

	private List<Rags.Action> n()
	{
		if (TheCurrentObject == string.Empty && ThePageType != PageType.player)
		{
			return null;
		}
		List<Rags.Action> result = null;
		switch (ThePageType)
		{
		case PageType.characters:
			result = TheGame.GetCharacterByName(TheCurrentObject).Actions;
			break;
		case PageType.objects:
			result = TheGame.GetObjectByName(TheCurrentObject).Actions;
			break;
		case PageType.player:
			result = TheGame.ThePlayer.Actions;
			break;
		case PageType.room:
			result = TheGame.GetRoomByID(new Guid(TheCurrentObject)).Actions;
			break;
		case PageType.timers:
			result = TheGame.GetTimerByName(TheCurrentObject).Actions;
			break;
		case PageType.quickcommand:
			result = TheGame.GetMenuItemByName(TheCurrentObject).Actions;
			break;
		}
		return result;
	}

	private void h(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Command a_ = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
		m();
		if (tvActionsConditions.SelectedItem != null)
		{
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(a(a_), "pack://application:,,/Images/command.png");
		}
	}

	private void ad(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bWearable)
			{
				GameObject gameObject = TheGame.ObjectList[i];
				((ItemsControl)A_0).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void ac(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			((ItemsControl)A_0).Items.Add((object)TheGame.PictureList[i].TheName);
		}
	}

	private void ab(ref ComboBox A_0)
	{
		try
		{
			((ItemsControl)A_0).Items.Clear();
			SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from MediaGroups", dBConnection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				((ItemsControl)A_0).Items.Add((object)sqlCeDataReader["Name"].ToString());
			}
		}
		catch
		{
		}
	}

	private void aa(ref ComboBox A_0)
	{
		try
		{
			((ItemsControl)A_0).Items.Clear();
			SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from ItemGroups", dBConnection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				((ItemsControl)A_0).Items.Add((object)sqlCeDataReader["Name"].ToString());
			}
		}
		catch
		{
		}
	}

	private void z(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			GameObject gameObject = TheGame.ObjectList[i];
			((ItemsControl)A_0).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
	}

	private void y(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (@object.bContainer)
			{
				((ItemsControl)A_0).Items.Add((object)new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
	}

	private void x(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			GameObject gameObject = TheGame.ObjectList[i];
			((ItemsControl)A_0).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
		for (int j = 0; j < TheGame.CharacterList.Count; j++)
		{
			((ItemsControl)A_0).Items.Add((object)TheGame.CharacterList[j].Charname);
		}
	}

	private void w(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bCarryable)
			{
				((ItemsControl)A_0).Items.Add((object)new RoomComboItem(TheGame.ObjectList[i].UniqueIdentifier, TheGame.ObjectList[i].name));
			}
		}
	}

	private void v(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		((ItemsControl)A_0).Items.Add((object)"North");
		((ItemsControl)A_0).Items.Add((object)"South");
		((ItemsControl)A_0).Items.Add((object)"East");
		((ItemsControl)A_0).Items.Add((object)"West");
		((ItemsControl)A_0).Items.Add((object)"Up");
		((ItemsControl)A_0).Items.Add((object)"Down");
		((ItemsControl)A_0).Items.Add((object)"NorthEast");
		((ItemsControl)A_0).Items.Add((object)"NorthWest");
		((ItemsControl)A_0).Items.Add((object)"SouthEast");
		((ItemsControl)A_0).Items.Add((object)"SouthWest");
		((ItemsControl)A_0).Items.Add((object)"In");
		((ItemsControl)A_0).Items.Add((object)"Out");
	}

	private void u(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (Room room in TheGame.RoomList)
		{
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = room.UniqueID;
			if (room.SDesc.Trim().Length > 0)
			{
				roomComboItem.RoomName = room.Name + "-" + room.SDesc;
			}
			else
			{
				roomComboItem.RoomName = room.Name;
			}
			((ItemsControl)A_0).Items.Add((object)roomComboItem);
		}
	}

	private void t(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (string roomGroup in TheGame.RoomGroups)
		{
			((ItemsControl)A_0).Items.Add((object)roomGroup);
		}
	}

	private void s(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		if (TheGame.RoomList.Count <= 0)
		{
			return;
		}
		int num = 0;
		foreach (Room room in TheGame.RoomList)
		{
			if (num == 0)
			{
				foreach (CustomProperty customProperty in room.CustomProperties)
				{
					((ItemsControl)A_0).Items.Add((object)("<CurrentRoom>:" + customProperty.Name));
					num++;
				}
			}
			foreach (CustomProperty customProperty2 in room.CustomProperties)
			{
				((ItemsControl)A_0).Items.Add((object)(room.Name + ":" + customProperty2.Name));
			}
		}
	}

	private void r(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		if (TheGame.CharacterList.Count <= 0)
		{
			return;
		}
		foreach (Character character in TheGame.CharacterList)
		{
			foreach (CustomProperty customProperty in character.CustomProperties)
			{
				((ItemsControl)A_0).Items.Add((object)(character.Charname + ":" + customProperty.Name));
			}
		}
	}

	private void q(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		if (TheGame.TimerList.Count <= 0)
		{
			return;
		}
		foreach (Timer timer in TheGame.TimerList)
		{
			foreach (CustomProperty customProperty in timer.CustomProperties)
			{
				((ItemsControl)A_0).Items.Add((object)(timer.Name + ":" + customProperty.Name));
			}
		}
	}

	private void p(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		if (TheGame.VariableList.Count <= 0)
		{
			return;
		}
		foreach (GameVariable variable in TheGame.VariableList)
		{
			foreach (CustomProperty customProperty in variable.CustomProperties)
			{
				((ItemsControl)A_0).Items.Add((object)(variable.varname + ":" + customProperty.Name));
			}
		}
	}

	private void o(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		if (TheGame.ObjectList.Count <= 0)
		{
			return;
		}
		int num = 0;
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (num == 0 && ThePageType == PageType.objects)
			{
				foreach (CustomProperty customProperty in @object.CustomProperties)
				{
					((ItemsControl)A_0).Items.Add((object)("<Self>:" + customProperty.Name));
					num++;
				}
			}
			foreach (CustomProperty customProperty2 in @object.CustomProperties)
			{
				((ItemsControl)A_0).Items.Add((object)(@object.name + ":" + customProperty2.Name));
			}
		}
	}

	private void n(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (CustomProperty customProperty in TheGame.ThePlayer.CustomProperties)
		{
			((ItemsControl)A_0).Items.Add((object)customProperty.Name);
		}
	}

	private void m(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						((ItemsControl)A_0).Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)A_0).Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
			else
			{
				((ItemsControl)A_0).Items.Add((object)gameVariable.varname);
			}
		}
	}

	private void l(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			((ItemsControl)A_0).Items.Add((object)gameVariable.varname);
		}
	}

	private void k(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.VarArray != null && gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				((ItemsControl)A_0).Items.Add((object)gameVariable.varname);
			}
		}
	}

	private void j(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (GameVariable variable in TheGame.VariableList)
		{
			if (variable.vartype == GameVariable.VarType.VT_DATETIME || variable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				((ItemsControl)A_0).Items.Add((object)variable.varname);
			}
			else
			{
				if (variable.vartype != GameVariable.VarType.VT_NUMBERARRAY && variable.vartype != GameVariable.VarType.VT_DATETIMEARRAY)
				{
					continue;
				}
				for (int i = 0; i < variable.VarArray.Count; i++)
				{
					if (variable.VarArray[i] is ArrayList)
					{
						((ItemsControl)A_0).Items.Add((object)(variable.varname + "(" + i + ")(0.." + (((ArrayList)variable.VarArray[i]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)A_0).Items.Add((object)(variable.varname + "(" + i + ")"));
					}
				}
			}
		}
	}

	private void i(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (GameVariable variable in TheGame.VariableList)
		{
			if (variable.vartype == GameVariable.VarType.VT_STRING || variable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				((ItemsControl)A_0).Items.Add((object)variable.varname);
			}
			else
			{
				if (variable.vartype != GameVariable.VarType.VT_STRINGARRAY && variable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
				{
					continue;
				}
				for (int i = 0; i < variable.VarArray.Count; i++)
				{
					if (variable.VarArray[i] is ArrayList)
					{
						((ItemsControl)A_0).Items.Add((object)(variable.varname + "(" + i + ")(0.." + (((ArrayList)variable.VarArray[i]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)A_0).Items.Add((object)(variable.varname + "(" + i + ")"));
					}
				}
			}
		}
	}

	private void h(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_STRING)
			{
				((ItemsControl)A_0).Items.Add((object)gameVariable.varname);
			}
			else
			{
				if (gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
				{
					continue;
				}
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						((ItemsControl)A_0).Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)A_0).Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
		}
	}

	private void g(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				((ItemsControl)A_0).Items.Add((object)gameVariable.varname);
			}
			else
			{
				if (gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY)
				{
					continue;
				}
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						((ItemsControl)A_0).Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)A_0).Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
		}
	}

	private void f(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (Character character in TheGame.CharacterList)
		{
			foreach (Rags.Action action in character.Actions)
			{
				_ = action;
			}
		}
		foreach (GameObject @object in TheGame.ObjectList)
		{
			foreach (Rags.Action action2 in @object.Actions)
			{
				if (action2.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)A_0).Items.Add((object)("Obj:" + @object.name + ":" + action2.name));
				}
			}
		}
		foreach (Rags.Action action3 in TheGame.ThePlayer.Actions)
		{
			if (action3.InputType == Rags.Action.ActionInputType.Custom)
			{
				((ItemsControl)A_0).Items.Add((object)("Player:" + action3.name));
			}
		}
		foreach (Room room in TheGame.RoomList)
		{
			foreach (Rags.Action action4 in room.Actions)
			{
				if (action4.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)A_0).Items.Add((object)("Room:" + room.Name + ":" + action4.name));
				}
			}
		}
	}

	private void e(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		foreach (Character character in TheGame.CharacterList)
		{
			foreach (Rags.Action action in character.Actions)
			{
				if (action.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)A_0).Items.Add((object)("Chr:" + character.Charname + ":" + action.name));
				}
			}
		}
		foreach (GameObject @object in TheGame.ObjectList)
		{
			foreach (Rags.Action action2 in @object.Actions)
			{
				if (action2.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)A_0).Items.Add((object)("Obj:" + @object.name + ":" + action2.name));
				}
			}
		}
		foreach (Rags.Action action3 in TheGame.ThePlayer.Actions)
		{
			if (action3.InputType == Rags.Action.ActionInputType.Custom)
			{
				((ItemsControl)A_0).Items.Add((object)("Player:" + action3.name));
			}
		}
		foreach (Room room in TheGame.RoomList)
		{
			foreach (Rags.Action action4 in room.Actions)
			{
				if (action4.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)A_0).Items.Add((object)("Room:" + room.Name + ":" + action4.name));
				}
			}
		}
		foreach (Timer timer in TheGame.TimerList)
		{
			foreach (Rags.Action action5 in timer.Actions)
			{
				if (action5.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)A_0).Items.Add((object)("Timer:" + timer.Name + ":" + action5.name));
				}
			}
		}
	}

	private void d(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.CharacterList.Count; i++)
		{
			((ItemsControl)A_0).Items.Add((object)TheGame.CharacterList[i].Charname);
		}
	}

	private void c(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.TimerList.Count; i++)
		{
			((ItemsControl)A_0).Items.Add((object)TheGame.TimerList[i].Name);
		}
	}

	private void b(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bLockable)
			{
				GameObject gameObject = TheGame.ObjectList[i];
				((ItemsControl)A_0).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void a(ref ComboBox A_0)
	{
		((ItemsControl)A_0).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bOpenable)
			{
				GameObject gameObject = TheGame.ObjectList[i];
				((ItemsControl)A_0).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void a(ref ComboBox A_0, Guid A_1)
	{
		((ItemsControl)A_0).Items.Clear();
		Room roomByID = TheGame.GetRoomByID(A_1);
		if (roomByID == null)
		{
			return;
		}
		foreach (Exit exit in roomByID.Exits)
		{
			if (exit.DestinationRoom != string.Empty)
			{
				((ItemsControl)A_0).Items.Add((object)(exit.Direction.ToString() + "-Active-To:" + TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
				((ItemsControl)A_0).Items.Add((object)(exit.Direction.ToString() + "-InActive-To:" + TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
			}
		}
	}

	private void m()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)cbCommandStep1).SelectedItem == null)
		{
			return;
		}
		grdCommandGrid.ColumnDefinitions[1].Width = new GridLength(0.0);
		((UIElement)gbCustomChoices).Visibility = (Visibility)1;
		((UIElement)lbCustomChoices).Visibility = (Visibility)1;
		((UIElement)cbCommandStep4).Visibility = (Visibility)1;
		switch (((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex)
		{
		case Command.CommandType.CT_ITEM_GETRANDOMGROUP:
			((ContentControl)lblCommandStep2).Content = "Select Variable:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			h(ref cbCommandStep2);
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Item Group:";
			aa(ref cbCommandStep3);
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_MM_GETRANDOMGROUP:
			((ContentControl)lblCommandStep2).Content = "Select Variable:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			h(ref cbCommandStep2);
			ab(ref cbCommandStep3);
			((ContentControl)lblCommandStep3).Content = "Select Media Group:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_CANCELMOVE:
			((ContentControl)lblCommandStep2).Content = "Select Action:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_Status_ItemVisibleInvisible:
			((ContentControl)lblCommandStep2).Content = "Select Status Bar Item:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Visible/Invisible:";
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			foreach (StatusBarItem statusBarItem in TheGame.StatusBarItems)
			{
				((ItemsControl)cbCommandStep2).Items.Add((object)statusBarItem.Name);
			}
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Visible");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Invisible");
			break;
		case Command.CommandType.CT_LOOP_BREAK:
			((ContentControl)lblCommandStep2).Content = "Select Action:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_ACTION_CLEAR_CUSTOMCHOICE:
			((ContentControl)lblCommandStep2).Content = "Select Action:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			e(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_ACTION_ADD_CUSTOMCHOICE:
			((ContentControl)lblCommandStep2).Content = "Select Action:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((ItemsControl)cbCommandStep2).Items.Clear();
			e(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_ADD:
		case Command.CommandType.CT_LAYEREDIMAGE_REMOVE:
			((ContentControl)lblCommandStep2).Content = "Select Base Image:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Image to Add/Remove:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			ac(ref cbCommandStep2);
			ac(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_REPLACE:
			((ContentControl)lblCommandStep2).Content = "Select Base Image:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Layered Image to Replace:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep4).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Select New Layered Image:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			ac(ref cbCommandStep2);
			ac(ref cbCommandStep3);
			ac(ref cbCommandStep4);
			break;
		case Command.CommandType.CT_LAYEREDIMAGE_CLEAR:
			((ContentControl)lblCommandStep2).Content = "Select Base Image To Clear:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Image to Add/Remove:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			ac(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_ITEM_SET_VISIBILITY:
			((ContentControl)lblCommandStep2).Content = "Select Item:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Visibility State:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			z(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Visible");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Invisible");
			break;
		case Command.CommandType.CT_ITEM_LAYERED_WEAR:
			((ContentControl)lblCommandStep2).Content = "Item to Wear:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ad(ref cbCommandStep2);
			if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).bWearable)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_ITEM_LAYERED_REMOVE:
			((ContentControl)lblCommandStep2).Content = "Item to Remove:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ad(ref cbCommandStep2);
			if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).bWearable)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_ITEMS_MOVE_CONTAINER_TO_CONTAINER:
			((ContentControl)lblCommandStep2).Content = "Select Source Container Item:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Dest Container Item:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Clear();
			y(ref cbCommandStep2);
			y(ref cbCommandStep3);
			if (ThePageType == PageType.objects)
			{
				GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
				if (objectByName != null && objectByName.bContainer)
				{
					((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
					((ItemsControl)cbCommandStep3).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
				}
			}
			break;
		case Command.CommandType.CT_VARIABLE_SET_RANDOMLY:
			((ContentControl)lblCommandStep2).Content = "Select Numeric Variable:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Custom Choice:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			g(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_ACTION_REMOVE_CUSTOMCHOICE:
			((ContentControl)lblCommandStep2).Content = "Select Action:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Custom Choice To Remove:";
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((ItemsControl)cbCommandStep2).Items.Clear();
			e(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_Execute_SQL:
			((ContentControl)lblCommandStep2).Content = "Select Text MDA Variable For Results:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "SQL To Execute:";
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((ItemsControl)cbCommandStep2).Items.Clear();
			k(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_SETPLAYERDESC:
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			break;
		case Command.CommandType.CT_SETPLAYERNAME:
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_SETPLAYERGENDER:
			((ContentControl)lblCommandStep2).Content = "Select Gender:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep2).Items.Clear();
			((ItemsControl)cbCommandStep2).Items.Add((object)"Male");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Female");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Other");
			break;
		case Command.CommandType.CT_CHAR_SET_GENDER:
			((ContentControl)lblCommandStep2).Content = "Select Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Gender:";
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "Player's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Male");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Female");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Other");
			break;
		case Command.CommandType.CT_CHAR_SET_NAME:
			((ContentControl)lblCommandStep2).Content = "Select Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep3).Content = "Select Gender:";
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Character's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)0;
			d(ref cbCommandStep2);
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_ROOM_SET_NAME_OVERRIDE:
			((ContentControl)lblCommandStep2).Content = "Select Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep3).Content = "Select Gender:";
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Room's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)0;
			u(ref cbCommandStep2);
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_ITEM_SET_NAME_OVERRIDE:
			((ContentControl)lblCommandStep2).Content = "Select Item:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep3).Content = "Select Gender:";
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Item's Name:";
			((UIElement)txtStep4).Visibility = (Visibility)0;
			z(ref cbCommandStep2);
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_PAUSEGAME:
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_EXECUTETIMER:
			((ContentControl)lblCommandStep2).Content = "Timer:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Active/Inactive:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			c(ref cbCommandStep2);
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Active");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Inactive");
			break;
		case Command.CommandType.CT_RESETTIMER:
			((ContentControl)lblCommandStep2).Content = "Timer:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Active/Inactive:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			c(ref cbCommandStep2);
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Active");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Inactive");
			break;
		case Command.CommandType.CT_SETTIMER:
			((ContentControl)lblCommandStep2).Content = "Timer:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Active/Inactive:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			c(ref cbCommandStep2);
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Active");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Inactive");
			break;
		case Command.CommandType.CT_SETVARIABLEBYINPUT:
			((UIElement)gbCommandChoices).Visibility = (Visibility)0;
			((UIElement)lbCustomChoices).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep2).Content = "Entry Type:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Variable To Set:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((UIElement)txtStep4).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Title Of Entry Form:";
			((ItemsControl)cbCommandStep2).Items.Clear();
			((ItemsControl)cbCommandStep2).Items.Add((object)"Text");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Characters");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Objects");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Characters And Objects");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Custom");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Inventory");
			h(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
			((UIElement)gbCommandChoices).Visibility = (Visibility)0;
			((UIElement)lbCustomChoices).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep2).Content = "Entry Type:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Variable To Set:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((UIElement)txtStep4).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Title Of Entry Form:";
			((ItemsControl)cbCommandStep2).Items.Clear();
			((ItemsControl)cbCommandStep2).Items.Add((object)"Text");
			((ItemsControl)cbCommandStep2).Items.Add((object)"Custom");
			g(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_SETCHARDESC:
			((ContentControl)lblCommandStep2).Content = "Character to change:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_SETROOMDESCRIPTION:
		{
			((ContentControl)lblCommandStep2).Content = "Room to change:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "New Room Description:";
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			RoomComboItem roomComboItem10 = new RoomComboItem();
			roomComboItem10.UniqueID = Room.CurrentRoomGuid;
			roomComboItem10.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem10);
			break;
		}
		case Command.CommandType.CT_DISPLAYROOMDESCRIPTION:
		{
			((ContentControl)lblCommandStep2).Content = "Room's Description to Display:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Room Description:";
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			RoomComboItem roomComboItem9 = new RoomComboItem();
			roomComboItem9.UniqueID = Room.CurrentRoomGuid;
			roomComboItem9.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem9);
			break;
		}
		case Command.CommandType.CT_DISPLAYROOMPICTURE:
		{
			((ContentControl)lblCommandStep2).Content = "Room's Picture to Display:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Room Description:";
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			RoomComboItem roomComboItem8 = new RoomComboItem();
			roomComboItem8.UniqueID = Room.CurrentRoomGuid;
			roomComboItem8.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem8);
			break;
		}
		case Command.CommandType.CT_SETITEMDESC:
			((ContentControl)lblCommandStep2).Content = "Item to change description:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			z(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_ROOMPROPERTYVALUE:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((ContentControl)lblCommandStep3).Content = "Custom Property Value:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)cbCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			this.i(ref cbCommandStep2);
			s(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_CHARPROPERTYVALUE:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((ContentControl)lblCommandStep3).Content = "Custom Property Value:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)cbCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			this.i(ref cbCommandStep2);
			r(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_TIMERPROPERTYVALUE:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((ContentControl)lblCommandStep3).Content = "Custom Property Value:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)cbCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			this.i(ref cbCommandStep2);
			q(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLEPROPERTYVALUE:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((ContentControl)lblCommandStep3).Content = "Custom Property Value:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)cbCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			this.i(ref cbCommandStep2);
			p(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_ITEMPROPERTYVALUE:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((ContentControl)lblCommandStep3).Content = "Custom Property Value:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)cbCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			this.i(ref cbCommandStep2);
			o(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_PLAYERPROPERTYVALUE:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((ContentControl)lblCommandStep3).Content = "Custom Property Value:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)cbCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			this.i(ref cbCommandStep2);
			n(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_SETVARIABLE:
		case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Variable data:";
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			if (txtStep4.Text.Trim() != "")
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((ContentControl)lblCommandText).Content = "Variable data:";
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((ContentControl)lblCommandText).Content = "Variable data:";
				if (txtCommandText.Text.Trim() != "")
				{
					((UIElement)lblCommandText).Visibility = (Visibility)0;
					((UIElement)txtCommandText).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)lblCommandText).Visibility = (Visibility)1;
					((UIElement)txtCommandText).Visibility = (Visibility)1;
				}
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
			}
			m(ref cbCommandStep2);
			if (((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
			{
				break;
			}
			{
				foreach (GameVariable variable in TheGame.VariableList)
				{
					switch (variable.vartype)
					{
					case GameVariable.VarType.VT_NUMBERARRAY:
					case GameVariable.VarType.VT_STRINGARRAY:
					case GameVariable.VarType.VT_DATETIMEARRAY:
						((ItemsControl)cbCommandStep2).Items.Add((object)("Array:" + variable.varname));
						break;
					}
				}
				break;
			}
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
			((ContentControl)lblCommandStep2).Content = "Room Property To Set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Property Value:";
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			if (txtStep4.Text.Trim() != "")
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((ContentControl)lblCommandText).Content = "Property Value:";
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((ContentControl)lblCommandText).Content = "Property Value:";
				if (txtCommandText.Text.Trim() != "")
				{
					((UIElement)lblCommandText).Visibility = (Visibility)0;
					((UIElement)txtCommandText).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)lblCommandText).Visibility = (Visibility)1;
					((UIElement)txtCommandText).Visibility = (Visibility)1;
				}
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
			}
			s(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
			((ContentControl)lblCommandStep2).Content = "Timer Property To Set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Property Value:";
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			if (txtStep4.Text.Trim() != "")
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((ContentControl)lblCommandText).Content = "Property Value:";
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((ContentControl)lblCommandText).Content = "Property Value:";
				if (txtCommandText.Text.Trim() != "")
				{
					((UIElement)lblCommandText).Visibility = (Visibility)0;
					((UIElement)txtCommandText).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)lblCommandText).Visibility = (Visibility)1;
					((UIElement)txtCommandText).Visibility = (Visibility)1;
				}
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
			}
			q(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
			((ContentControl)lblCommandStep2).Content = "Variable Property To Set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Property Value:";
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			if (txtStep4.Text.Trim() != "")
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((ContentControl)lblCommandText).Content = "Property Value:";
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((ContentControl)lblCommandText).Content = "Property Value:";
				if (txtCommandText.Text.Trim() != "")
				{
					((UIElement)lblCommandText).Visibility = (Visibility)0;
					((UIElement)txtCommandText).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)lblCommandText).Visibility = (Visibility)1;
					((UIElement)txtCommandText).Visibility = (Visibility)1;
				}
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
			}
			p(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
			((ContentControl)lblCommandStep2).Content = "Character Property To Set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Property Value:";
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			if (txtStep4.Text.Trim() != "")
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((ContentControl)lblCommandText).Content = "Property Value:";
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((ContentControl)lblCommandText).Content = "Property Value:";
				if (txtCommandText.Text.Trim() != "")
				{
					((UIElement)lblCommandText).Visibility = (Visibility)0;
					((UIElement)txtCommandText).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)lblCommandText).Visibility = (Visibility)1;
					((UIElement)txtCommandText).Visibility = (Visibility)1;
				}
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
			}
			r(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
			((ContentControl)lblCommandStep2).Content = "Item Property To Set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Property Value:";
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Property Value:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((UIElement)txtStep4).Visibility = (Visibility)0;
			o(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
			((ContentControl)lblCommandStep2).Content = "Player Property To Set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Property Value:";
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			if (txtStep4.Text.Trim() != "")
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((ContentControl)lblCommandText).Content = "Property Value:";
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((ContentControl)lblCommandText).Content = "Property Value:";
				if (txtCommandText.Text.Trim() != "")
				{
					((UIElement)lblCommandText).Visibility = (Visibility)0;
					((UIElement)txtCommandText).Visibility = (Visibility)0;
				}
				else
				{
					((UIElement)lblCommandText).Visibility = (Visibility)1;
					((UIElement)txtCommandText).Visibility = (Visibility)1;
				}
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
			}
			n(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_IMPORTVARIABLE:
			((ContentControl)lblCommandStep2).Content = "Variable to Import:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			m(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_EXPORTVARIABLE:
			((ContentControl)lblCommandStep2).Content = "Variable to Export:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			l(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_DEBUGTEXT:
		case Command.CommandType.CT_DISPLAYTEXT:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)gbCommandChoices).Visibility = (Visibility)2;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_JAVA_SET_RAGS:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Javascript to run:";
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_COMMENT:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Rags Designer Comment:";
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_DISPLAYPLAYERDESC:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_DISPLAYITEMDESC:
			((ContentControl)lblCommandStep2).Content = "Item to display:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			z(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_MOVEITEMTOINV:
			((ContentControl)lblCommandStep2).Content = "Item to Move:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			w(ref cbCommandStep2);
			if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).bCarryable)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			break;
		case Command.CommandType.CT_MOVEINVENTORYTOCHAR:
			((ContentControl)lblCommandStep2).Content = "Which Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MOVEITEMTOOBJ:
			((ContentControl)lblCommandStep2).Content = "Select Item To Move:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Container Item:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			z(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			y(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_MOVEINVENTORYTOROOM:
		{
			((ContentControl)lblCommandStep2).Content = "Which Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			RoomComboItem roomComboItem7 = new RoomComboItem();
			roomComboItem7.RoomName = "<CurrentRoom>";
			roomComboItem7.UniqueID = Room.CurrentRoomGuid;
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem7);
			roomComboItem7 = new RoomComboItem();
			roomComboItem7.RoomName = "<Void>";
			roomComboItem7.UniqueID = Room.VoidRoomGuid;
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem7);
			break;
		}
		case Command.CommandType.CT_ROOM_MOVE_ITEMS_TO_PLAYER:
		{
			((ContentControl)lblCommandStep2).Content = "Which Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			RoomComboItem roomComboItem6 = new RoomComboItem();
			roomComboItem6.RoomName = "<CurrentRoom>";
			roomComboItem6.UniqueID = Room.CurrentRoomGuid;
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem6);
			break;
		}
		case Command.CommandType.CT_MOVEITEMTOROOM:
		{
			((ContentControl)lblCommandStep2).Content = "Item to Move:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Destination Room:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			z(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			u(ref cbCommandStep3);
			RoomComboItem roomComboItem5 = new RoomComboItem();
			roomComboItem5.UniqueID = Room.CurrentRoomGuid;
			roomComboItem5.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep3).Items.Insert(0, (object)roomComboItem5);
			roomComboItem5 = new RoomComboItem();
			roomComboItem5.UniqueID = Room.VoidRoomGuid;
			roomComboItem5.RoomName = "<Void>";
			((ItemsControl)cbCommandStep3).Items.Insert(0, (object)roomComboItem5);
			break;
		}
		case Command.CommandType.CT_MOVEITEMTOCHAR:
			((ContentControl)lblCommandStep2).Content = "Item to Move:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Destination Character:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			z(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			d(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_SETEXIT:
			((ContentControl)lblCommandStep2).Content = "Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Direction to modify:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			((Selector)cbCommandStep2).SelectedIndex = 0;
			a(ref cbCommandStep3, ((RoomComboItem)((Selector)cbCommandStep2).SelectedItem).UniqueID);
			break;
		case Command.CommandType.CT_SETEXITDESTINATION:
			((ContentControl)lblCommandStep2).Content = "Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Direction to modify:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep4).Content = "New Destination Room";
			((UIElement)cbCommandStep4).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			v(ref cbCommandStep3);
			u(ref cbCommandStep4);
			((ItemsControl)cbCommandStep4).Items.Insert(0, (object)"<None>");
			break;
		case Command.CommandType.CT_DISPLAYVARIABLE:
			((ContentControl)lblCommandStep2).Content = "Variable to display:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Direction to modify:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			m(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_SETROOMPIC:
		{
			((ContentControl)lblCommandStep2).Content = "Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			RoomComboItem roomComboItem4 = new RoomComboItem();
			roomComboItem4.UniqueID = Room.CurrentRoomGuid;
			roomComboItem4.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem4);
			ac(ref cbCommandStep3);
			break;
		}
		case Command.CommandType.CT_CHAR_SETPORT:
			((ContentControl)lblCommandStep2).Content = "Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			ac(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_CHAR_DISPLAYPORT:
			((ContentControl)lblCommandStep2).Content = "Character's Picture to Display:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "New Room Description:";
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_SETROOMLAYEREDPIC:
		{
			((ContentControl)lblCommandStep2).Content = "Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			RoomComboItem roomComboItem3 = new RoomComboItem();
			roomComboItem3.UniqueID = Room.CurrentRoomGuid;
			roomComboItem3.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem3);
			ac(ref cbCommandStep3);
			((ItemsControl)cbCommandStep3).Items.Insert(0, (object)"<None>");
			break;
		}
		case Command.CommandType.CT_SETPLAYERPORTRAIT:
			((ContentControl)lblCommandStep2).Content = "Picture:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MM_SET_MAIN_COMPASS:
			((ContentControl)lblCommandStep2).Content = "Picture:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)"<Default>");
			break;
		case Command.CommandType.CT_MM_SET_UD_COMPASS:
			((ContentControl)lblCommandStep2).Content = "Picture:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)"<Default>");
			break;
		case Command.CommandType.CT_SETLAYEREDPLAYERPORTRAIT:
			((ContentControl)lblCommandStep2).Content = "Picture:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)"<None>");
			break;
		case Command.CommandType.CT_DISPLAYPICTURE:
			((ContentControl)lblCommandStep2).Content = "Media:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MM_SET_BACKGROUND_MUSIC:
			((ContentControl)lblCommandStep2).Content = "Media:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MM_STOP_BACKGROUND_MUSIC:
			((ContentControl)lblCommandStep2).Content = "Media:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MM_PLAY_SOUNDEFFECT:
			((ContentControl)lblCommandStep2).Content = "Media:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_DISPLAYLAYEREDPICTURE:
			((ContentControl)lblCommandStep2).Content = "Picture:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Picture:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ac(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_SETOBJECTACTION:
			((ContentControl)lblCommandStep2).Content = "Object:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Action:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			z(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			else if (ThePageType == PageType.quickcommand)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)"[Self]");
			}
			break;
		case Command.CommandType.CT_SETCHARACTION:
			((ContentControl)lblCommandStep2).Content = "Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Action:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_SETPLAYERACTION:
		{
			((ContentControl)lblCommandStep2).Content = "Object:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Rags.Action and State:";
			((ItemsControl)cbCommandStep3).Items.Clear();
			for (int i = 0; i < TheGame.ThePlayer.Actions.Count; i++)
			{
				Rags.Action action = TheGame.ThePlayer.Actions[i];
				((ItemsControl)cbCommandStep3).Items.Add((object)(action.name + "-Active"));
				((ItemsControl)cbCommandStep3).Items.Add((object)(action.name + "-Inactive"));
			}
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			break;
		}
		case Command.CommandType.CT_SETROOMACTION:
			((ContentControl)lblCommandStep2).Content = "Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Action:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_SETLOCKEDUNLOCKED:
			((ContentControl)lblCommandStep2).Content = "Object:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "State:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			b(ref cbCommandStep2);
			if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).bLockable)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Locked");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Unlocked");
			break;
		case Command.CommandType.CT_SETOPENCLOSED:
			((ContentControl)lblCommandStep2).Content = "Object:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "State:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			a(ref cbCommandStep2);
			if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).bOpenable)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Open");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Closed");
			break;
		case Command.CommandType.CT_SETITEMTOWORN:
			((ContentControl)lblCommandStep2).Content = "Object:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "State:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			ad(ref cbCommandStep2);
			if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).bWearable)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Worn");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Removed");
			break;
		case Command.CommandType.CT_DISPLAYCHARDESC:
			((ContentControl)lblCommandStep2).Content = "Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "State:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MOVECHAR:
		{
			((ContentControl)lblCommandStep2).Content = "Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Room:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			u(ref cbCommandStep3);
			RoomComboItem roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.CurrentRoomGuid;
			roomComboItem2.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep3).Items.Insert(0, (object)roomComboItem2);
			roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.VoidRoomGuid;
			roomComboItem2.RoomName = "<Void>";
			((ItemsControl)cbCommandStep3).Items.Insert(0, (object)roomComboItem2);
			break;
		}
		case Command.CommandType.CT_MOVECHARINVTOPLAYER:
		{
			((ContentControl)lblCommandStep2).Content = "Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Room:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			u(ref cbCommandStep3);
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.CurrentRoomGuid;
			roomComboItem.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep3).Items.Insert(0, (object)roomComboItem);
			roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.VoidRoomGuid;
			roomComboItem.RoomName = "<Void>";
			((ItemsControl)cbCommandStep3).Items.Insert(0, (object)roomComboItem);
			break;
		}
		case Command.CommandType.CT_MOVEPLAYER:
			((ContentControl)lblCommandStep2).Content = "Room:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Room:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			u(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MOVETOCHAR:
			((ContentControl)lblCommandStep2).Content = "Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Room:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_MOVETOOBJ:
			((ContentControl)lblCommandStep2).Content = "Object:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Room:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			z(ref cbCommandStep2);
			break;
		case Command.CommandType.CT_CHAR_MOVETOOBJ:
			((ContentControl)lblCommandStep2).Content = "Character:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Object:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandText).Content = "Text to display:";
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			d(ref cbCommandStep2);
			z(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_ENDGAME:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((UIElement)lblCommandStep2).Visibility = (Visibility)1;
			((UIElement)cbCommandStep2).Visibility = (Visibility)1;
			((UIElement)lblCommandStep3).Visibility = (Visibility)1;
			((UIElement)cbCommandStep3).Visibility = (Visibility)1;
			((ContentControl)lblCommandText).Content = "Text to display at completion:";
			((UIElement)lblCommandText).Visibility = (Visibility)0;
			((UIElement)txtCommandText).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)1;
			((UIElement)txtStep4).Visibility = (Visibility)1;
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			break;
		}
	}

	private void a(object A_0, RoutedPropertyChangedEventArgs<object> A_1)
	{
		object selectedItem = tvActionsConditions.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		if (val != null)
		{
			if (((FrameworkElement)val).Tag is Command)
			{
				((UIElement)gbCommands).Visibility = (Visibility)0;
				((UIElement)gbConditionData).Visibility = (Visibility)1;
				((UIElement)gbCustomChoices).Visibility = (Visibility)1;
				((Selector)cbCommandStep1).SelectedItem = SaveLoad.GetCommandItem(((ItemsControl)cbCommandStep1).Items, ((Command)((FrameworkElement)val).Tag).cmdtype);
			}
			else if (o() && !(((FrameworkElement)val).Tag is Condition))
			{
				((UIElement)gbCommands).Visibility = (Visibility)1;
				((UIElement)gbConditionData).Visibility = (Visibility)1;
				((UIElement)gbCustomChoices).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)gbCommands).Visibility = (Visibility)1;
				((UIElement)gbConditionData).Visibility = (Visibility)0;
				((UIElement)gbCustomChoices).Visibility = (Visibility)1;
			}
			if (val == null)
			{
				txtConditionName.Text = "";
				((UIElement)gbCommands).Visibility = (Visibility)1;
				((UIElement)gbConditionData).Visibility = (Visibility)1;
				((UIElement)gbCustomChoices).Visibility = (Visibility)1;
			}
			else if (((FrameworkElement)val).Tag is Rags.Action)
			{
				txtConditionName.Text = "";
				((UIElement)cbActionActive).IsEnabled = true;
				((UIElement)gbCondBehavior).IsEnabled = true;
				((UIElement)gbAddInput).IsEnabled = true;
			}
			else
			{
				((UIElement)cbActionActive).IsEnabled = false;
				((UIElement)gbCondBehavior).IsEnabled = false;
				((UIElement)gbAddInput).IsEnabled = false;
			}
			r();
		}
	}

	private void g(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)cbCommandStep2).SelectedItem == null)
		{
			return;
		}
		switch (((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex)
		{
		case Command.CommandType.CT_SETVARIABLEBYINPUT:
		case Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT:
			if (((Selector)cbCommandStep2).SelectedItem.ToString() == "Custom")
			{
				grdCommandGrid.ColumnDefinitions[1].Width = new GridLength(1.0, (GridUnitType)0);
			}
			else
			{
				grdCommandGrid.ColumnDefinitions[1].Width = new GridLength(0.0);
			}
			break;
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_CHAR_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_PLAYER_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_TIMER_SET_CUSTOM_PROPERTY_JS:
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY:
		case Command.CommandType.CT_VARIABLE_SET_CUSTOM_PROPERTY_JS:
			((ContentControl)lblCommandStep3).Content = "Set Type:";
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((UIElement)lblCommandStep4).Visibility = (Visibility)0;
			((UIElement)txtStep4).Visibility = (Visibility)0;
			((UIElement)lblCommandText).Visibility = (Visibility)1;
			((UIElement)txtCommandText).Visibility = (Visibility)1;
			((ItemsControl)cbCommandStep3).Items.Clear();
			((ItemsControl)cbCommandStep3).Items.Add((object)"Equals");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Add");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Multiply");
			((ItemsControl)cbCommandStep3).Items.Add((object)"Divide");
			break;
		case Command.CommandType.CT_SETVARIABLE:
		case Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT:
		{
			if (((Selector)cbCommandStep2).SelectedItem == null)
			{
				return;
			}
			string text = TheGame.PerformTextReplacements(((Selector)cbCommandStep2).SelectedItem.ToString(), null);
			bool flag = false;
			int num = text.IndexOf("Array:");
			if (num > -1)
			{
				flag = true;
				text = text.Remove(num, 6);
			}
			GameVariable variableByName3 = TheGame.GetVariableByName(text);
			if (variableByName3 == null)
			{
				return;
			}
			((ContentControl)lblCommandStep3).Content = "Set Type:";
			switch (variableByName3.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
			case GameVariable.VarType.VT_DATETIMEARRAY:
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((ItemsControl)cbCommandStep3).Items.Clear();
				((ItemsControl)cbCommandStep3).Items.Add((object)"Equals");
				if (!flag)
				{
					((ItemsControl)cbCommandStep3).Items.Add((object)"Add Days");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Add Hours");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Add Minutes");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Add Seconds");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Days");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Hours");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Minutes");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Seconds");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Set Day Of Month To");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Set Hours To");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Set Minutes To");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Set Seconds To");
				}
				break;
			case GameVariable.VarType.VT_NUMBER:
			case GameVariable.VarType.VT_NUMBERARRAY:
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)0;
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((ItemsControl)cbCommandStep3).Items.Clear();
				((ItemsControl)cbCommandStep3).Items.Add((object)"Equals");
				if (!flag)
				{
					((ItemsControl)cbCommandStep3).Items.Add((object)"Add");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Multiply");
					((ItemsControl)cbCommandStep3).Items.Add((object)"Divide");
				}
				break;
			case GameVariable.VarType.VT_STRING:
			case GameVariable.VarType.VT_STRINGARRAY:
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
				((UIElement)lblCommandText).Visibility = (Visibility)0;
				((UIElement)txtCommandText).Visibility = (Visibility)0;
				break;
			}
			break;
		}
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
		{
			GameVariable variableByName2 = TheGame.GetVariableByName(TheGame.PerformTextReplacements(cbCommandStep2.Text, null));
			switch (variableByName2.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)1;
				((UIElement)cbCommandStep4).Visibility = (Visibility)0;
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((ItemsControl)cbCommandStep3).Items.Clear();
				((ItemsControl)cbCommandStep3).Items.Add((object)"Add Days");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Add Hours");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Add Minutes");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Add Seconds");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Days");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Hours");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Minutes");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract Seconds");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Set Day Of Month To");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Set Hours To");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Set Minutes To");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Set Seconds To");
				break;
			case GameVariable.VarType.VT_NUMBER:
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)1;
				((UIElement)cbCommandStep4).Visibility = (Visibility)0;
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((ItemsControl)cbCommandStep3).Items.Clear();
				((ItemsControl)cbCommandStep3).Items.Add((object)"Equals");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Add");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Subtract");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Multiply");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Divide");
				break;
			}
			break;
		}
		case Command.CommandType.CT_DISPLAYVARIABLE:
		{
			GameVariable variableByName = TheGame.GetVariableByName(TheGame.PerformTextReplacements(cbCommandStep2.Text, null));
			switch (variableByName.vartype)
			{
			case GameVariable.VarType.VT_DATETIME:
				((ContentControl)lblCommandStep3).Content = "DateTime Display Type";
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((ItemsControl)cbCommandStep3).Items.Clear();
				((ItemsControl)cbCommandStep3).Items.Add((object)"Display Date & Time");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Display Date Only");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Display Time Only");
				((ItemsControl)cbCommandStep3).Items.Add((object)"Display Weekday Only");
				((Selector)cbCommandStep3).SelectedIndex = 0;
				ae(null, null);
				break;
			case GameVariable.VarType.VT_NUMBER:
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				break;
			case GameVariable.VarType.VT_STRING:
				((UIElement)lblCommandStep3).Visibility = (Visibility)1;
				((UIElement)cbCommandStep3).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)1;
				((UIElement)txtStep4).Visibility = (Visibility)1;
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				break;
			}
			break;
		}
		case Command.CommandType.CT_SETOBJECTACTION:
		{
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Action and State:";
			((ItemsControl)cbCommandStep3).Items.Clear();
			GameObject gameObject = null;
			if (((Selector)cbCommandStep2).SelectedItem.ToString() == "<<Self>>")
			{
				gameObject = TheGame.GetObjectByName(TheCurrentObject);
			}
			else if (((Selector)cbCommandStep2).SelectedItem.ToString() == "[Self]" && ThePageType == PageType.quickcommand)
			{
				QuickMenuItem menuItemByName = TheGame.GetMenuItemByName(TheCurrentObject);
				foreach (Rags.Action action4 in menuItemByName.Actions)
				{
					((ItemsControl)cbCommandStep3).Items.Add((object)(action4.name + "-Active"));
					((ItemsControl)cbCommandStep3).Items.Add((object)(action4.name + "-Inactive"));
				}
				gameObject = null;
			}
			else
			{
				gameObject = TheGame.GetObjectByName(((RoomComboItem)((Selector)cbCommandStep2).SelectedItem).UniqueID.ToString());
			}
			if (gameObject != null)
			{
				for (int k = 0; k < gameObject.Actions.Count; k++)
				{
					Rags.Action action3 = gameObject.Actions[k];
					((ItemsControl)cbCommandStep3).Items.Add((object)(action3.name + "-Active"));
					((ItemsControl)cbCommandStep3).Items.Add((object)(action3.name + "-Inactive"));
				}
			}
			break;
		}
		case Command.CommandType.CT_SETCHARACTION:
		{
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Action and State:";
			((ItemsControl)cbCommandStep3).Items.Clear();
			Character characterByName = TheGame.GetCharacterByName(((Selector)cbCommandStep2).SelectedItem.ToString());
			if (characterByName != null)
			{
				for (int j = 0; j < characterByName.Actions.Count; j++)
				{
					Rags.Action action2 = characterByName.Actions[j];
					((ItemsControl)cbCommandStep3).Items.Add((object)(action2.name + "-Active"));
					((ItemsControl)cbCommandStep3).Items.Add((object)(action2.name + "-Inactive"));
				}
			}
			break;
		}
		case Command.CommandType.CT_SETROOMACTION:
		{
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Action and State:";
			((ItemsControl)cbCommandStep3).Items.Clear();
			Room roomByID = TheGame.GetRoomByID(((RoomComboItem)((Selector)cbCommandStep2).SelectedItem).UniqueID);
			if (roomByID != null)
			{
				for (int i = 0; i < roomByID.Actions.Count; i++)
				{
					Rags.Action action = roomByID.Actions[i];
					((ItemsControl)cbCommandStep3).Items.Add((object)(action.name + "-Active"));
					((ItemsControl)cbCommandStep3).Items.Add((object)(action.name + "-Inactive"));
				}
			}
			break;
		}
		case Command.CommandType.CT_SETEXIT:
			a(ref cbCommandStep3, ((RoomComboItem)((Selector)cbCommandStep2).SelectedItem).UniqueID);
			break;
		}
		_ = ((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex;
		_ = 87;
		_ = ((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex;
		_ = 41;
	}

	private void ae(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem != null)
		{
			Command command = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
			if (((Selector)cbCommandStep3).SelectedItem is RoomComboItem roomComboItem)
			{
				command.CommandPart3 = roomComboItem.UniqueID.ToString();
			}
			else
			{
				command.CommandPart3 = cbCommandStep3.Text;
				SaveLoad.ValidateText(cbCommandStep3.Text, ref TheGame);
			}
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(a(command), "pack://application:,,/Images/command.png");
		}
	}

	private void f(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		Command.CommandType ctindex = ((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex;
		if (ctindex != Command.CommandType.CT_SETVARIABLE && ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			return;
		}
		string text = TheGame.PerformTextReplacements(cbCommandStep2.Text, null);
		int num = text.IndexOf("Array:");
		if (num > -1)
		{
			text = text.Remove(num, 6);
		}
		GameVariable variableByName = TheGame.GetVariableByName(text);
		if (variableByName != null && variableByName.vartype == GameVariable.VarType.VT_DATETIME && ((Selector)cbCommandStep3).SelectedItem.ToString() == "Equals")
		{
			Command command = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
			if (command.CommandPart4 == string.Empty)
			{
				txtStep4.Text = variableByName.dtDateTime.ToString();
				ad(null, null);
			}
			else
			{
				txtStep4.Text = command.CommandPart4;
			}
		}
	}

	private void ad(object A_0, RoutedEventArgs A_1)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		Command.CommandType ctindex = ((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex;
		if (ctindex == Command.CommandType.CT_SETVARIABLE || ctindex == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			if (cbCommandStep2.Text == string.Empty)
			{
				return;
			}
			string text = TheGame.PerformTextReplacements(cbCommandStep2.Text, null);
			int num = text.IndexOf("Array:");
			if (num > -1)
			{
				text = text.Remove(num, 6);
			}
			GameVariable variableByName = TheGame.GetVariableByName(text);
			if (variableByName != null)
			{
				switch (variableByName.vartype)
				{
				case GameVariable.VarType.VT_DATETIME:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					if (((Selector)cbCommandStep3).SelectedItem.ToString() == "Equals")
					{
						try
						{
							Convert.ToDateTime(TheGame.PerformTextReplacements(txtStep4.Text, null));
						}
						catch
						{
							MessageBox.Show("Please enter a properly formatted datetime value in step 4.");
							((UIElement)txtStep4).Focus();
							return;
						}
					}
					else
					{
						try
						{
							Convert.ToInt32(TheGame.PerformTextReplacements(txtStep4.Text, null));
						}
						catch
						{
							MessageBox.Show("Warning: Step 4 did not contain a valid number.");
						}
					}
					break;
				case GameVariable.VarType.VT_NUMBER:
				case GameVariable.VarType.VT_NUMBERARRAY:
					try
					{
						if (((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex != Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
						{
							Convert.ToDouble(TheGame.PerformTextReplacements(txtStep4.Text, null));
						}
					}
					catch
					{
						MessageBox.Show("Warning: Step 4 did not contain a valid number.");
					}
					break;
				}
			}
		}
		Command command = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
		command.CommandPart4 = txtStep4.Text;
		((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(a(command), "pack://application:,,/Images/command.png");
		SaveLoad.ValidateText(txtStep4.Text, ref TheGame);
	}

	private void c(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		RagsEditor ragsEditor = new RagsEditor(A_0, TheGame);
		Window window = Window.GetWindow((DependencyObject)(object)this);
		((Window)ragsEditor).Owner = window;
		if (A_0 is TextBox)
		{
			ragsEditor.TBDATA = ((TextBox)A_0).Text;
		}
		else if (A_0 is ComboBox)
		{
			ragsEditor.TBDATA = ((ComboBox)A_0).Text;
		}
		((Window)ragsEditor).ShowDialog();
	}

	private void ac(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem == null)
		{
			return;
		}
		Command command = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
		if (((Selector)cbCommandStep2).SelectedItem is RoomComboItem roomComboItem)
		{
			command.CommandPart2 = roomComboItem.UniqueID.ToString();
		}
		else
		{
			if (command == null)
			{
				return;
			}
			command.CommandPart2 = cbCommandStep2.Text;
			SaveLoad.ValidateText(cbCommandStep2.Text, ref TheGame);
		}
		((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(a(command), "pack://application:,,/Images/command.png");
	}

	private void e(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((Selector)lbChecks).SelectedIndex <= -1)
		{
			return;
		}
		Condition condition = q();
		Check check = condition.Checks[((Selector)lbChecks).SelectedIndex];
		if (check == null)
		{
			return;
		}
		((Selector)cbConditionStep1).SelectedItem = SaveLoad.GetConditionItem(((ItemsControl)cbConditionStep1).Items, check.CondType);
		d((object)null, (SelectionChangedEventArgs)null);
		try
		{
			Guid guid = new Guid(check.ConditionStep2);
			foreach (RoomComboItem item in (IEnumerable)((ItemsControl)cbConditionStep2).Items)
			{
				if (item.UniqueID == guid)
				{
					((Selector)cbConditionStep2).SelectedItem = item;
					break;
				}
			}
		}
		catch
		{
			cbConditionStep2.Text = check.ConditionStep2;
		}
		try
		{
			Guid guid2 = new Guid(check.ConditionStep3);
			foreach (RoomComboItem item2 in (IEnumerable)((ItemsControl)cbConditionStep3).Items)
			{
				if (item2.UniqueID == guid2)
				{
					((Selector)cbConditionStep3).SelectedItem = item2;
					break;
				}
			}
		}
		catch
		{
			cbConditionStep3.Text = check.ConditionStep3;
		}
		txtConditionStep4.Text = check.ConditionStep4;
		cbConditionStep4.Text = check.ConditionStep4;
	}

	private void d(object A_0, SelectionChangedEventArgs A_1)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = q();
		if (condition != null)
		{
			if (((Selector)cbConditionStep1).SelectedItem != null && (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_While || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Rooms || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Characters || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Items) && condition.Checks.Count > 1)
			{
				MessageBox.Show("Sorry, a loop check must be the only check in your condition.");
				((Selector)cbConditionStep1).SelectedItem = SaveLoad.GetConditionItem(((ItemsControl)cbConditionStep1).Items, Condition.ConditionType.CT_Character_In_Room);
			}
			else
			{
				l();
			}
		}
	}

	private void c(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Room_CustomPropertyCheck || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Player_CustomPropertyCheck || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Item_CustomPropertyCheck || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Character_CustomPropertyCheck || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Timer_CustomPropertyCheck || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Variable_CustomPropertyCheck)
		{
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((ItemsControl)cbConditionStep3).Items.Clear();
			((ItemsControl)cbConditionStep3).Items.Add((object)"Equals");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Not Equals");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Contains");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than or Equals");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than or Equals");
		}
		else if (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Variable_Comparison || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_While)
		{
			GameVariable variableByName = TheGame.GetVariableByName(TheGame.PerformTextReplacements(cbConditionStep2.Text, null));
			if (variableByName != null)
			{
				switch (variableByName.vartype)
				{
				case GameVariable.VarType.VT_DATETIME:
				case GameVariable.VarType.VT_DATETIMEARRAY:
					((UIElement)lblConditionStep3).Visibility = (Visibility)0;
					((UIElement)cbConditionStep3).Visibility = (Visibility)0;
					((UIElement)lblConditionStep4).Visibility = (Visibility)0;
					((UIElement)txtConditionStep4).Visibility = (Visibility)0;
					((ContentControl)lblConditionStep4).Content = "Value:";
					((ItemsControl)cbConditionStep3).Items.Clear();
					((ItemsControl)cbConditionStep3).Items.Add((object)"Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Not Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than or Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than or Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"DayOfWeek Is");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Hour Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Hour Is Greater Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Hour Is Less Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Minute Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Minute Is Greater Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Minute Is Less Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Seconds Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Seconds Is Greater Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Seconds Is Less Than");
					break;
				case GameVariable.VarType.VT_NUMBER:
				case GameVariable.VarType.VT_NUMBERARRAY:
					((UIElement)lblConditionStep3).Visibility = (Visibility)0;
					((UIElement)cbConditionStep3).Visibility = (Visibility)0;
					((UIElement)lblConditionStep4).Visibility = (Visibility)0;
					((UIElement)txtConditionStep4).Visibility = (Visibility)0;
					((ContentControl)lblConditionStep4).Content = "Value:";
					((ItemsControl)cbConditionStep3).Items.Clear();
					((ItemsControl)cbConditionStep3).Items.Add((object)"Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Not Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than or Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than or Equals");
					break;
				case GameVariable.VarType.VT_STRING:
				case GameVariable.VarType.VT_STRINGARRAY:
					((UIElement)lblConditionStep3).Visibility = (Visibility)0;
					((UIElement)cbConditionStep3).Visibility = (Visibility)0;
					((UIElement)lblConditionStep4).Visibility = (Visibility)0;
					((UIElement)txtConditionStep4).Visibility = (Visibility)0;
					((ContentControl)lblConditionStep4).Content = "Value:";
					((ItemsControl)cbConditionStep3).Items.Clear();
					((ItemsControl)cbConditionStep3).Items.Add((object)"Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Not Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Contains");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than");
					break;
				}
			}
		}
		else
		{
			if (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex != Condition.ConditionType.CT_Variable_To_Variable_Comparison)
			{
				return;
			}
			GameVariable variableByName2 = TheGame.GetVariableByName(TheGame.PerformTextReplacements(cbConditionStep2.Text, null));
			if (variableByName2 != null)
			{
				switch (variableByName2.vartype)
				{
				case GameVariable.VarType.VT_NUMBER:
				case GameVariable.VarType.VT_NUMBERARRAY:
					((UIElement)lblConditionStep3).Visibility = (Visibility)0;
					((UIElement)cbConditionStep3).Visibility = (Visibility)0;
					((UIElement)lblConditionStep4).Visibility = (Visibility)0;
					((UIElement)txtConditionStep4).Visibility = (Visibility)1;
					((UIElement)cbConditionStep4).Visibility = (Visibility)0;
					((ItemsControl)cbConditionStep3).Items.Clear();
					((ItemsControl)cbConditionStep3).Items.Add((object)"Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Not Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Less Than or Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Greater Than or Equals");
					break;
				case GameVariable.VarType.VT_STRING:
				case GameVariable.VarType.VT_STRINGARRAY:
					((UIElement)lblConditionStep3).Visibility = (Visibility)0;
					((UIElement)cbConditionStep3).Visibility = (Visibility)0;
					((UIElement)lblConditionStep4).Visibility = (Visibility)0;
					((UIElement)txtConditionStep4).Visibility = (Visibility)1;
					((UIElement)cbConditionStep4).Visibility = (Visibility)0;
					((ItemsControl)cbConditionStep3).Items.Clear();
					((ItemsControl)cbConditionStep3).Items.Add((object)"Equals");
					((ItemsControl)cbConditionStep3).Items.Add((object)"Not Equals");
					break;
				case GameVariable.VarType.VT_DATETIME:
					break;
				}
			}
		}
	}

	private void b(object A_0, SelectionChangedEventArgs A_1)
	{
		if (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex != Condition.ConditionType.CT_Variable_Comparison && ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex != Condition.ConditionType.CT_Loop_While)
		{
			return;
		}
		GameVariable variableByName = TheGame.GetVariableByName(TheGame.PerformTextReplacements(cbConditionStep2.Text, null));
		if (variableByName == null)
		{
			return;
		}
		GameVariable.VarType vartype = variableByName.vartype;
		if (vartype != GameVariable.VarType.VT_DATETIME)
		{
			return;
		}
		if (q().Checks[((Selector)lbChecks).SelectedIndex].ConditionStep4 == string.Empty)
		{
			switch (TheGame.PerformTextReplacements(cbConditionStep3.Text, null))
			{
			case "Equals":
			case "Not Equals":
			case "Greater Than":
			case "Less Than":
				txtConditionStep4.Text = variableByName.dtDateTime.ToString();
				break;
			case "DayOfWeek Is":
				txtConditionStep4.Text = "Monday";
				break;
			default:
				txtConditionStep4.Text = "1";
				break;
			}
		}
		else
		{
			txtConditionStep4.Text = q().Checks[((Selector)lbChecks).SelectedIndex].ConditionStep4;
		}
		aa(null, null);
	}

	private void ab(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Condition;
		if (condition == null)
		{
			condition = ((FrameworkElement)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Tag as Condition;
		}
		s();
		condition.Checks[((Selector)lbChecks).SelectedIndex].ConditionStep4 = cbConditionStep4.Text;
	}

	private void aa(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Condition;
		if (condition == null)
		{
			condition = ((FrameworkElement)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Tag as Condition;
		}
		if (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Variable_Comparison || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_While)
		{
			GameVariable variableByName = TheGame.GetVariableByName(TheGame.PerformTextReplacements(cbConditionStep2.Text, null));
			if (variableByName != null && variableByName.vartype == GameVariable.VarType.VT_NUMBER)
			{
				try
				{
					Convert.ToDouble(TheGame.PerformTextReplacements(txtConditionStep4.Text, null));
				}
				catch
				{
					MessageBox.Show("Warning: Step 4 did not contain a valid number.");
				}
			}
		}
		if (condition != null)
		{
			condition.Checks[((Selector)lbChecks).SelectedIndex].ConditionStep4 = txtConditionStep4.Text;
			SaveLoad.ValidateText(txtConditionStep4.Text, ref TheGame);
		}
	}

	private void l()
	{
		//IL_1335: Unknown result type (might be due to invalid IL or missing references)
		//IL_133b: Invalid comparison between Unknown and I4
		((UIElement)cbConditionStep4).Visibility = (Visibility)1;
		switch (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex)
		{
		case Condition.ConditionType.CT_Item_InGroup:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Item Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			aa(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_MultiMedia_InGroup:
			((ContentControl)lblConditionStep2).Content = "Choose Media:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			ac(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Media Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			ab(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_Held_By_Player:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Character_In_Room:
		{
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			d(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			u(ref cbConditionStep3);
			RoomComboItem roomComboItem = new RoomComboItem();
			roomComboItem.UniqueID = Room.CurrentRoomGuid;
			roomComboItem.RoomName = "<CurrentRoom>";
			((ItemsControl)cbConditionStep3).Items.Insert(0, (object)roomComboItem);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		}
		case Condition.ConditionType.CT_Character_In_RoomGroup:
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			d(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Room Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			t(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Character_Gender:
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			d(ref cbConditionStep2);
			((ItemsControl)cbConditionStep3).Items.Clear();
			((ItemsControl)cbConditionStep3).Items.Add((object)"Male");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Female");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Other");
			((ContentControl)lblConditionStep3).Content = "Is Gender:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_Held_By_Character:
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			d(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Carryable Item:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			w(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_Not_In_Object:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep3).Content = "Not Inside object:";
			y(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_In_Object:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep3).Content = "Inside object:";
			y(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Player_Gender:
			((ContentControl)lblConditionStep2).Content = "Is Gender:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			((ItemsControl)cbConditionStep2).Items.Clear();
			((ItemsControl)cbConditionStep2).Items.Add((object)"Male");
			((ItemsControl)cbConditionStep2).Items.Add((object)"Female");
			((ItemsControl)cbConditionStep2).Items.Add((object)"Other");
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((ContentControl)lblConditionStep3).Content = "Inside object:";
			y(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Player_In_Same_Room_As:
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			d(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_In_Room:
		{
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			u(ref cbConditionStep3);
			RoomComboItem roomComboItem2 = new RoomComboItem();
			roomComboItem2.UniqueID = Room.CurrentRoomGuid;
			roomComboItem2.RoomName = "<CurrentRoom>";
			((ItemsControl)cbConditionStep3).Items.Insert(0, (object)roomComboItem2);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		}
		case Condition.ConditionType.CT_Item_In_RoomGroup:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			t(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Player_In_Room:
			((ContentControl)lblConditionStep2).Content = "Choose Room:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			u(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Loop_Exits:
			((ContentControl)lblConditionStep2).Content = "Choose Room:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			u(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Player_In_RoomGroup:
			((ContentControl)lblConditionStep2).Content = "Choose Room Group:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			t(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Player_Moving:
			((ContentControl)lblConditionStep2).Content = "Moving In Which Direction:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			v(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_State_Check:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			z(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "State Must Be:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			((ItemsControl)cbConditionStep3).Items.Clear();
			((ItemsControl)cbConditionStep3).Items.Add((object)"Open");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Closed");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Locked");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Unlocked");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Worn");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Removed");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Read");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Unread");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Visible");
			((ItemsControl)cbConditionStep3).Items.Add((object)"Invisible");
			break;
		case Condition.ConditionType.CT_Loop_Characters:
		case Condition.ConditionType.CT_Loop_Items:
		case Condition.ConditionType.CT_Loop_Rooms:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)1;
			((UIElement)cbConditionStep2).Visibility = (Visibility)1;
			z(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "State Must Be:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Loop_While:
			((ContentControl)lblConditionStep2).Content = "Choose Variable:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			m(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Loop_Item_Group:
			((ContentControl)lblConditionStep2).Content = "Choose Item Group:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			aa(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Loop_Item_Container:
			((ContentControl)lblConditionStep2).Content = "Choose Container:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			y(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Loop_Item_Room:
			((ContentControl)lblConditionStep2).Content = "Choose Room:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			u(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Loop_Item_Char_Inventory:
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			d(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Loop_Item_Inventory:
			((ContentControl)lblConditionStep2).Content = "Choose Item Group:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)1;
			((UIElement)cbConditionStep2).Visibility = (Visibility)1;
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Room_CustomPropertyCheck:
			((ContentControl)lblConditionStep2).Content = "Choose Property:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			s(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Timer_CustomPropertyCheck:
			((ContentControl)lblConditionStep2).Content = "Choose Property:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			q(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Variable_CustomPropertyCheck:
			((ContentControl)lblConditionStep2).Content = "Choose Property:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			p(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Character_CustomPropertyCheck:
			((ContentControl)lblConditionStep2).Content = "Choose Property:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			r(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Item_CustomPropertyCheck:
			((ContentControl)lblConditionStep2).Content = "Choose Property:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			o(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Player_CustomPropertyCheck:
			((ContentControl)lblConditionStep2).Content = "Choose Property:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			n(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Variable_Comparison:
			((ContentControl)lblConditionStep2).Content = "Choose Variable:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			m(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Value:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_Variable_To_Variable_Comparison:
			((ContentControl)lblConditionStep2).Content = "Choose Variable:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Compared to Variable:";
			i(ref cbConditionStep2);
			i(ref cbConditionStep4);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Compared to Variable:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			((UIElement)cbConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_AdditionalDataCheck:
			if (s().InputType == Rags.Action.ActionInputType.None)
			{
				if ((int)MessageBox.Show("This action is currently not defined to accept additional input.  Would you like to define the additional input now?", "No Additional Input", (MessageBoxButton)4) != 6)
				{
					if (((CollectionView)((ItemsControl)cbConditionStep1).Items).Count > 0)
					{
						((Selector)cbConditionStep1).SelectedIndex = 0;
					}
					break;
				}
				k().IsSelected = true;
				((UIElement)gbAddInput).Focus();
			}
			switch (s().InputType)
			{
			case Rags.Action.ActionInputType.Text:
				((ContentControl)lblConditionStep2).Content = "Choose Item:";
				((UIElement)lblConditionStep2).Visibility = (Visibility)1;
				((UIElement)cbConditionStep2).Visibility = (Visibility)1;
				((ContentControl)lblConditionStep3).Content = "State Must Be:";
				((UIElement)lblConditionStep3).Visibility = (Visibility)1;
				((UIElement)cbConditionStep3).Visibility = (Visibility)1;
				((UIElement)lblConditionStep4).Visibility = (Visibility)0;
				((UIElement)txtConditionStep4).Visibility = (Visibility)0;
				((ContentControl)lblConditionStep4).Content = "What should the user enter or select:";
				break;
			case Rags.Action.ActionInputType.Character:
				((ContentControl)lblConditionStep2).Content = "Which character should the player choose:";
				((UIElement)lblConditionStep2).Visibility = (Visibility)0;
				((UIElement)cbConditionStep2).Visibility = (Visibility)0;
				d(ref cbConditionStep2);
				((ContentControl)lblConditionStep3).Content = "State Must Be:";
				((UIElement)lblConditionStep3).Visibility = (Visibility)1;
				((UIElement)cbConditionStep3).Visibility = (Visibility)1;
				((UIElement)lblConditionStep4).Visibility = (Visibility)1;
				((UIElement)txtConditionStep4).Visibility = (Visibility)1;
				((ContentControl)lblConditionStep4).Content = "What should the user enter or select:";
				break;
			case Rags.Action.ActionInputType.Object:
				((ContentControl)lblConditionStep2).Content = "Which object should the player choose:";
				((UIElement)lblConditionStep2).Visibility = (Visibility)0;
				((UIElement)cbConditionStep2).Visibility = (Visibility)0;
				z(ref cbConditionStep2);
				((ContentControl)lblConditionStep3).Content = "State Must Be:";
				((UIElement)lblConditionStep3).Visibility = (Visibility)1;
				((UIElement)cbConditionStep3).Visibility = (Visibility)1;
				((UIElement)lblConditionStep4).Visibility = (Visibility)1;
				((UIElement)txtConditionStep4).Visibility = (Visibility)1;
				((ContentControl)lblConditionStep4).Content = "What should the user enter or select:";
				break;
			case Rags.Action.ActionInputType.Inventory:
				((ContentControl)lblConditionStep2).Content = "Which object should the player choose:";
				((UIElement)lblConditionStep2).Visibility = (Visibility)0;
				((UIElement)cbConditionStep2).Visibility = (Visibility)0;
				w(ref cbConditionStep2);
				((ContentControl)lblConditionStep3).Content = "State Must Be:";
				((UIElement)lblConditionStep3).Visibility = (Visibility)1;
				((UIElement)cbConditionStep3).Visibility = (Visibility)1;
				((UIElement)lblConditionStep4).Visibility = (Visibility)1;
				((UIElement)txtConditionStep4).Visibility = (Visibility)1;
				((ContentControl)lblConditionStep4).Content = "What should the user enter or select:";
				break;
			case Rags.Action.ActionInputType.ObjectOrCharacter:
				((ContentControl)lblConditionStep2).Content = "Which object or character should the player choose:";
				((UIElement)lblConditionStep2).Visibility = (Visibility)0;
				((UIElement)cbConditionStep2).Visibility = (Visibility)0;
				x(ref cbConditionStep2);
				((ContentControl)lblConditionStep3).Content = "State Must Be:";
				((UIElement)lblConditionStep3).Visibility = (Visibility)1;
				((UIElement)cbConditionStep3).Visibility = (Visibility)1;
				((UIElement)lblConditionStep4).Visibility = (Visibility)1;
				((UIElement)txtConditionStep4).Visibility = (Visibility)1;
				((ContentControl)lblConditionStep4).Content = "What should the user enter or select:";
				break;
			case Rags.Action.ActionInputType.Custom:
				((ContentControl)lblConditionStep2).Content = "Which choice should the user make:";
				((UIElement)lblConditionStep2).Visibility = (Visibility)0;
				((UIElement)cbConditionStep2).Visibility = (Visibility)0;
				((ItemsControl)cbConditionStep2).Items.Clear();
				foreach (string item in (IEnumerable)((ItemsControl)lbActionCustomChoices).Items)
				{
					((ItemsControl)cbConditionStep2).Items.Add((object)item);
				}
				((ContentControl)lblConditionStep3).Content = "State Must Be:";
				((UIElement)lblConditionStep3).Visibility = (Visibility)1;
				((UIElement)cbConditionStep3).Visibility = (Visibility)1;
				((UIElement)lblConditionStep4).Visibility = (Visibility)1;
				((UIElement)txtConditionStep4).Visibility = (Visibility)1;
				((ContentControl)lblConditionStep4).Content = "What should the user enter or select:";
				break;
			}
			break;
		}
	}

	private TreeViewItem k()
	{
		object selectedItem = tvActionsConditions.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		while (((FrameworkElement)val).Parent is TreeViewItem)
		{
			DependencyObject parent = ((FrameworkElement)val).Parent;
			val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		return val;
	}

	private void z(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Condition;
		if (condition == null && ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent != null && ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent is TreeViewItem)
		{
			condition = ((FrameworkElement)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Tag as Condition;
		}
		if (condition != null)
		{
			int selectedIndex = ((Selector)lbChecks).SelectedIndex;
			condition.Checks[((Selector)lbChecks).SelectedIndex].CondType = ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex;
			if (((Selector)lbChecks).SelectedIndex > 0)
			{
				((ItemsControl)lbChecks).Items[((Selector)lbChecks).SelectedIndex] = condition.Checks[((Selector)lbChecks).SelectedIndex].CkType.ToString() + " " + cbConditionStep1.Text;
			}
			else
			{
				((ItemsControl)lbChecks).Items[((Selector)lbChecks).SelectedIndex] = cbConditionStep1.Text;
			}
			((Selector)lbChecks).SelectedIndex = selectedIndex;
		}
	}

	private void y(object A_0, RoutedEventArgs A_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem == null)
		{
			return;
		}
		Condition condition = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Condition;
		if (condition == null)
		{
			condition = ((FrameworkElement)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Tag as Condition;
		}
		if (condition != null)
		{
			if (((Selector)cbConditionStep2).SelectedItem is RoomComboItem roomComboItem)
			{
				condition.Checks[((Selector)lbChecks).SelectedIndex].ConditionStep2 = roomComboItem.UniqueID.ToString();
				return;
			}
			condition.Checks[((Selector)lbChecks).SelectedIndex].ConditionStep2 = cbConditionStep2.Text;
			SaveLoad.ValidateText(cbConditionStep2.Text, ref TheGame);
		}
	}

	private void x(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Condition;
		if (condition == null)
		{
			condition = ((FrameworkElement)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Tag as Condition;
		}
		if (((Selector)cbConditionStep3).SelectedItem is RoomComboItem roomComboItem)
		{
			condition.Checks[((Selector)lbChecks).SelectedIndex].ConditionStep3 = roomComboItem.UniqueID.ToString();
			return;
		}
		condition.Checks[((Selector)lbChecks).SelectedIndex].ConditionStep3 = cbConditionStep3.Text;
		SaveLoad.ValidateText(cbConditionStep3.Text, ref TheGame);
	}

	private void b(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		startPoint = ((MouseEventArgs)A_1).GetPosition((IInputElement)null);
	}

	private void j()
	{
		MemoryStream memoryStream = new MemoryStream();
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		switch (ThePageType)
		{
		case PageType.objects:
		{
			GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
			if (objectByName != null)
			{
				sharpSerializer.Serialize(objectByName.Actions, memoryStream);
			}
			break;
		}
		case PageType.player:
			sharpSerializer.Serialize(TheGame.ThePlayer.Actions, memoryStream);
			break;
		case PageType.room:
		{
			Room roomByID = TheGame.GetRoomByID(new Guid(TheCurrentObject));
			if (roomByID != null)
			{
				sharpSerializer.Serialize(roomByID.Actions, memoryStream);
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = TheGame.GetCharacterByName(TheCurrentObject);
			if (characterByName != null)
			{
				sharpSerializer.Serialize(characterByName.Actions, memoryStream);
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = TheGame.GetTimerByName(TheCurrentObject);
			if (timerByName != null)
			{
				sharpSerializer.Serialize(timerByName.Actions, memoryStream);
			}
			break;
		}
		case PageType.quickcommand:
		{
			QuickMenuItem menuItemByName = TheGame.GetMenuItemByName(TheCurrentObject);
			if (menuItemByName != null)
			{
				sharpSerializer.Serialize(menuItemByName.Actions, memoryStream);
			}
			break;
		}
		}
		memoryStream.Seek(0L, SeekOrigin.Begin);
		UndoActions = (List<Rags.Action>)sharpSerializer.Deserialize(memoryStream);
	}

	private void w(object A_0, RoutedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		MenuItem val = (MenuItem)A_0;
		if (((FrameworkElement)val).Tag != null && ((FrameworkElement)val).Tag is QuickMenuItem)
		{
			this.j();
			QuickMenuItem quickMenuItem = ((FrameworkElement)val).Tag as QuickMenuItem;
			{
				foreach (Rags.Action action2 in quickMenuItem.Actions)
				{
					if (quickMenuItem.bOverwrite)
					{
						List<Rags.Action> list = n();
						for (int i = 0; i < list.Count; i++)
						{
							if (action2.name == list[i].name)
							{
								list.RemoveAt(i);
								RefreshActions();
								break;
							}
						}
					}
					if (b(ThePageType, action2.name))
					{
						SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
						MemoryStream memoryStream = new MemoryStream();
						sharpSerializer.Serialize(action2, memoryStream);
						memoryStream.Seek(0L, SeekOrigin.Begin);
						if (!(sharpSerializer.Deserialize(memoryStream) is Rags.Action action))
						{
							continue;
						}
						for (int j = 0; j < action.PassCommands.Count; j++)
						{
							Command A_2 = action.PassCommands[j] as Command;
							Condition A_3 = action.PassCommands[j] as Condition;
							if (A_2 != null)
							{
								a(ref A_2);
							}
							if (A_3 != null)
							{
								a(ref A_3);
							}
						}
						for (int k = 0; k < action.FailCommands.Count; k++)
						{
							Command A_4 = action.FailCommands[k] as Command;
							Condition A_5 = action.FailCommands[k] as Condition;
							if (A_4 != null)
							{
								a(ref A_4);
							}
							if (A_5 != null)
							{
								a(ref A_5);
							}
						}
						for (int l = 0; l < action.Conditions.Count; l++)
						{
							Condition A_6 = action.Conditions[l];
							a(ref A_6);
						}
						n().Add(action);
						a(action, -1, A_2: false);
						if (ThePageType != PageType.objects)
						{
							continue;
						}
						GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
						if (objectByName != null)
						{
							string text = string.Empty;
							if (quickMenuItem.bCarryable && !objectByName.bCarryable)
							{
								objectByName.bCarryable = true;
								text += "The object attribute carryable has been set.\r\n";
							}
							if (quickMenuItem.bContainer && !objectByName.bContainer)
							{
								objectByName.bContainer = true;
								text += "The object attribute container has been set.\r\n";
							}
							if (quickMenuItem.bEnterable && !objectByName.bEnterable)
							{
								objectByName.bEnterable = true;
								text += "The object attribute enterable has been set.\r\n";
							}
							if (quickMenuItem.bLockable && !objectByName.bLockable)
							{
								objectByName.bLockable = true;
								text += "The object attribute lockable has been set.\r\n";
							}
							if (quickMenuItem.bOpenable && !objectByName.bOpenable)
							{
								objectByName.bOpenable = true;
								text += "The object attribute openable has been set.\r\n";
							}
							if (quickMenuItem.bReadable && !objectByName.bReadable)
							{
								objectByName.bReadable = true;
								text += "The object attribute readable has been set.\r\n";
							}
							if (quickMenuItem.bWearable && !objectByName.bWearable)
							{
								objectByName.bWearable = true;
								text += "The object attribute wearable has been set.\r\n";
							}
							if (text != string.Empty)
							{
								MessageBox.Show(text, "Attributes Changed");
							}
						}
					}
					else
					{
						MessageBox.Show("There is already an action called " + action2.name + ".  No action was taken.");
					}
				}
				return;
			}
		}
		this.j();
		a(ThePageType, ((HeaderedItemsControl)val).Header.ToString());
	}

	private string i()
	{
		string result = string.Empty;
		switch (ThePageType)
		{
		case PageType.characters:
			result = TheGame.GetCharacterByName(TheCurrentObject).Charname;
			break;
		case PageType.objects:
			result = TheGame.GetObjectByName(TheCurrentObject).name;
			break;
		case PageType.room:
			result = TheGame.GetRoomByID(new Guid(TheCurrentObject)).Name;
			break;
		}
		return result;
	}

	private string h()
	{
		string result = string.Empty;
		switch (ThePageType)
		{
		case PageType.characters:
			result = TheGame.GetCharacterByName(TheCurrentObject).ToString();
			break;
		case PageType.objects:
			result = TheGame.GetObjectByName(TheCurrentObject).GetDisplayStringNameOnly();
			break;
		case PageType.room:
			result = TheGame.GetRoomByID(new Guid(TheCurrentObject)).Name;
			break;
		}
		return result;
	}

	private void a(ref Command A_0)
	{
		string text = string.Empty;
		if (A_0.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY || A_0.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
		{
			GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
			text = ((objectByName == null) ? string.Empty : objectByName.name);
		}
		else if (A_0.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY || A_0.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
		{
			text = TheGame.GetRoomByID(new Guid(TheCurrentObject)).Name;
		}
		else if (A_0.cmdtype == Command.CommandType.CT_SETVARIABLE || A_0.cmdtype == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			text = i();
		}
		for (int num = A_0.CommandPart2.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandPart2.ToUpper().IndexOf("[SELF]"))
		{
			A_0.CommandPart2 = A_0.CommandPart2.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandPart2 = A_0.CommandPart2.Insert(num, text);
			}
			else
			{
				A_0.CommandPart2 = A_0.CommandPart2.Insert(num, i());
			}
		}
		for (int num = A_0.CommandPart2.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandPart2.ToUpper().IndexOf("[NAME]"))
		{
			A_0.CommandPart2 = A_0.CommandPart2.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandPart2 = A_0.CommandPart2.Insert(num, text);
			}
			else
			{
				A_0.CommandPart2 = A_0.CommandPart2.Insert(num, i());
			}
		}
		for (int num = A_0.CommandPart3.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandPart3.ToUpper().IndexOf("[SELF]"))
		{
			A_0.CommandPart3 = A_0.CommandPart3.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandPart3 = A_0.CommandPart3.Insert(num, text);
			}
			else
			{
				A_0.CommandPart3 = A_0.CommandPart3.Insert(num, i());
			}
		}
		for (int num = A_0.CommandPart3.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandPart3.ToUpper().IndexOf("[NAME]"))
		{
			A_0.CommandPart3 = A_0.CommandPart3.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandPart3 = A_0.CommandPart3.Insert(num, text);
			}
			else
			{
				A_0.CommandPart3 = A_0.CommandPart3.Insert(num, i());
			}
		}
		for (int num = A_0.CommandPart4.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandPart4.ToUpper().IndexOf("[SELF]"))
		{
			A_0.CommandPart4 = A_0.CommandPart4.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandPart4 = A_0.CommandPart4.Insert(num, text);
			}
			else
			{
				A_0.CommandPart4 = A_0.CommandPart4.Insert(num, i());
			}
		}
		for (int num = A_0.CommandPart4.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandPart4.ToUpper().IndexOf("[NAME]"))
		{
			A_0.CommandPart4 = A_0.CommandPart4.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandPart4 = A_0.CommandPart4.Insert(num, text);
			}
			else
			{
				A_0.CommandPart4 = A_0.CommandPart4.Insert(num, i());
			}
		}
		for (int num = A_0.CommandText.ToUpper().IndexOf("[SELF]"); num > -1; num = A_0.CommandText.ToUpper().IndexOf("[SELF]"))
		{
			A_0.CommandText = A_0.CommandText.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandText = A_0.CommandText.Insert(num, text);
			}
			else
			{
				A_0.CommandText = A_0.CommandText.Insert(num, h());
			}
		}
		for (int num = A_0.CommandText.ToUpper().IndexOf("[NAME]"); num > -1; num = A_0.CommandText.ToUpper().IndexOf("[NAME]"))
		{
			A_0.CommandText = A_0.CommandText.Remove(num, 6);
			if (text != string.Empty)
			{
				A_0.CommandText = A_0.CommandText.Insert(num, text);
			}
			else
			{
				A_0.CommandText = A_0.CommandText.Insert(num, i());
			}
		}
	}

	private void a(ref Condition A_0)
	{
		for (int i = 0; i < A_0.Checks.Count; i++)
		{
			Check check = A_0.Checks[i];
			string text = string.Empty;
			if (check.CondType == Condition.ConditionType.CT_Item_CustomPropertyCheck)
			{
				text = TheGame.GetObjectByName(TheCurrentObject).name;
			}
			else if (check.CondType == Condition.ConditionType.CT_Room_CustomPropertyCheck)
			{
				text = TheGame.GetRoomByID(new Guid(TheCurrentObject)).Name;
			}
			int num = check.ConditionStep2.ToUpper().IndexOf("[SELF]");
			if (num > -1)
			{
				check.ConditionStep2 = check.ConditionStep2.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, text);
				}
				else
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, this.i());
				}
			}
			num = check.ConditionStep2.ToUpper().IndexOf("[NAME]");
			if (num > -1)
			{
				check.ConditionStep2 = check.ConditionStep2.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, text);
				}
				else
				{
					check.ConditionStep2 = check.ConditionStep2.Insert(num, this.i());
				}
			}
			num = check.ConditionStep3.ToUpper().IndexOf("[SELF]");
			if (num > -1)
			{
				check.ConditionStep3 = check.ConditionStep3.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, text);
				}
				else
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, this.i());
				}
			}
			num = check.ConditionStep3.ToUpper().IndexOf("[NAME]");
			if (num > -1)
			{
				check.ConditionStep3 = check.ConditionStep3.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, text);
				}
				else
				{
					check.ConditionStep3 = check.ConditionStep3.Insert(num, this.i());
				}
			}
			num = check.ConditionStep4.ToUpper().IndexOf("[SELF]");
			if (num > -1)
			{
				check.ConditionStep4 = check.ConditionStep4.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, text);
				}
				else
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, this.i());
				}
			}
			num = check.ConditionStep4.ToUpper().IndexOf("[NAME]");
			if (num > -1)
			{
				check.ConditionStep4 = check.ConditionStep4.Remove(num, 6);
				if (text != string.Empty)
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, text);
				}
				else
				{
					check.ConditionStep4 = check.ConditionStep4.Insert(num, this.i());
				}
			}
		}
		for (int j = 0; j < A_0.PassCommands.Count; j++)
		{
			Command A_1 = A_0.PassCommands[j] as Command;
			Condition A_2 = A_0.PassCommands[j] as Condition;
			if (A_1 != null)
			{
				a(ref A_1);
			}
			if (A_2 != null)
			{
				a(ref A_2);
			}
		}
		for (int k = 0; k < A_0.FailCommands.Count; k++)
		{
			Command A_3 = A_0.FailCommands[k] as Command;
			Condition A_4 = A_0.FailCommands[k] as Condition;
			if (A_3 != null)
			{
				a(ref A_3);
			}
			if (A_4 != null)
			{
				a(ref A_4);
			}
		}
	}

	private MenuItem a(string A_0, string A_1)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected Obj, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		RoutedEventHandler val = w;
		MenuItem val2 = new MenuItem();
		((HeaderedItemsControl)val2).Header = A_0;
		val2.Click += val;
		if (A_1 == string.Empty)
		{
			return val2;
		}
		Image val3 = new Image();
		val3.Source = (ImageSource)new BitmapImage(new Uri(A_1));
		val2.Icon = val3;
		return val2;
	}

	private void b(TreeViewItem A_0)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0649: Expected Obj, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected Obj, but got Unknown
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Expected Obj, but got Unknown
		//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Unknown result type (might be due to invalid IL or missing references)
		if (TheGame == null)
		{
			return;
		}
		RoutedEventHandler val = w;
		((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Clear();
		if (A_0 == null)
		{
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Action", "pack://application:,,/Images/run.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)new Separator());
			MenuItem val2 = new MenuItem();
			Image val3 = new Image();
			val3.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,/Images/command.png"));
			val2.Icon = val3;
			((HeaderedItemsControl)val2).Header = "Paste Action";
			val2.Click += val;
			SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Rags.Action action = null;
			if (ClipboardMS.Length > 0)
			{
				action = sharpSerializer.Deserialize(ClipboardMS) as Rags.Action;
			}
			((UIElement)val2).IsEnabled = action != null;
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val2);
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Expand All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Collapse All", "pack://application:,,/Images/command.png"));
		}
		else if (((FrameworkElement)A_0).Parent == null)
		{
			A_0.IsSelected = true;
			if (ThePageType != PageType.timers)
			{
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Rename Action", "pack://application:,,/Images/cancel.png"));
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Action", "pack://application:,,/Images/run.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Delete Action", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Condition", "pack://application:,,/Images/question.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Delete Condition", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Command On Success", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Command On Failure", "pack://application:,,/Images/command.png"));
			bool flag = false;
			if (((FrameworkElement)A_0).Tag is Command)
			{
				flag = true;
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Delete Command", "pack://application:,,/Images/cancel.png"));
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Expand All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Collapse All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)new Separator());
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Copy Action", "pack://application:,,/Images/command.png"));
			MenuItem val4 = a("Paste Action", "pack://application:,,/Images/command.png");
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val4);
			SharpSerializer sharpSerializer2 = new SharpSerializer(binarySerialization: true);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Rags.Action action2 = sharpSerializer2.Deserialize(ClipboardMS) as Rags.Action;
			((UIElement)val4).IsEnabled = action2 != null;
			val4 = a("Paste Condition", "pack://application:,,/Images/question.png");
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val4);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Condition condition = sharpSerializer2.Deserialize(ClipboardMS) as Condition;
			((UIElement)val4).IsEnabled = condition != null;
			if (flag)
			{
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Copy Command", "pack://application:,,/Images/command.png"));
				val4 = a("Paste Command", "pack://application:,,/Images/command.png");
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val4);
				ClipboardMS.Seek(0L, SeekOrigin.Begin);
				Command command = sharpSerializer2.Deserialize(ClipboardMS) as Command;
				((UIElement)val4).IsEnabled = command != null;
			}
		}
		else
		{
			A_0.IsSelected = true;
			if (ThePageType != PageType.timers)
			{
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Rename Action", "pack://application:,,/Images/run.png"));
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Action", "pack://application:,,/Images/run.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Delete Action", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Condition", "pack://application:,,/Images/question.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Delete Condition", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Command On Success", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Command On Failure", "pack://application:,,/Images/command.png"));
			bool flag2 = false;
			if (((FrameworkElement)A_0).Tag is Command)
			{
				flag2 = true;
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Delete Command", "pack://application:,,/Images/cancel.png"));
				flag2 = true;
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Expand All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Collapse All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)new Separator());
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Copy Action", "pack://application:,,/Images/run.png"));
			MenuItem val5 = a("Paste Action", "pack://application:,,/Images/run.png");
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val5);
			SharpSerializer sharpSerializer3 = new SharpSerializer(binarySerialization: true);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Rags.Action action3 = null;
			if (ClipboardMS.Length > 0)
			{
				action3 = sharpSerializer3.Deserialize(ClipboardMS) as Rags.Action;
			}
			((UIElement)val5).IsEnabled = action3 != null;
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Copy Condition", "pack://application:,,/Images/question.png"));
			val5 = a("Paste Condition", "pack://application:,,/Images/question.png");
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val5);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Condition condition2 = null;
			if (ClipboardMS.Length > 0)
			{
				condition2 = sharpSerializer3.Deserialize(ClipboardMS) as Condition;
			}
			((UIElement)val5).IsEnabled = condition2 != null;
			if (flag2)
			{
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Copy Command", "pack://application:,,/Images/command.png"));
			}
			string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)A_0).Header).Children[1]).Content.ToString();
			string text2 = string.Empty;
			if (((FrameworkElement)A_0).Parent is TreeViewItem)
			{
				text2 = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)A_0).Parent).Header).Children[1]).Content.ToString();
			}
			if (text2 == "Commands on Success" || text == "Commands on Success" || text2 == "Commands on Failure" || text == "Commands on Failure")
			{
				val5 = a("Paste Command", "pack://application:,,/Images/command.png");
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val5);
				ClipboardMS.Seek(0L, SeekOrigin.Begin);
				Command command2 = null;
				if (ClipboardMS.Length > 0)
				{
					command2 = sharpSerializer3.Deserialize(ClipboardMS) as Command;
				}
				((UIElement)val5).IsEnabled = command2 != null;
			}
		}
		if (ThePageType != PageType.timers)
		{
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)new Separator());
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)a("Add Default Actions:", ""));
			if (TheGame.QuickCommands == null)
			{
				return;
			}
			for (int i = 0; i < TheGame.QuickCommands.Count; i++)
			{
				QuickMenuItem quickMenuItem = TheGame.QuickCommands[i];
				switch (ThePageType)
				{
				case PageType.characters:
					if (quickMenuItem.bCharacters)
					{
						MenuItem val9 = a(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val9).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val9);
					}
					break;
				case PageType.objects:
					if (quickMenuItem.bObjects)
					{
						MenuItem val7 = a(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val7).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val7);
					}
					break;
				case PageType.player:
					if (quickMenuItem.bPlayer)
					{
						MenuItem val8 = a(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val8).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val8);
					}
					break;
				case PageType.room:
					if (quickMenuItem.bRooms)
					{
						MenuItem val6 = a(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val6).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val6);
					}
					break;
				}
			}
		}
		((FrameworkElement)tvActionsConditions).ContextMenu.IsOpen = true;
	}

	private void a(object A_0, MouseButtonEventArgs A_1)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)tvActionsConditions).Focus();
		if (((UIElement)tvActionsConditions).IsEnabled)
		{
			TreeViewItem val = null;
			if (((RoutedEventArgs)A_1).Source is Label)
			{
				DependencyObject parent = ((FrameworkElement)(StackPanel)((FrameworkElement)(Label)((RoutedEventArgs)A_1).Source).Parent).Parent;
				val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			}
			else if (((RoutedEventArgs)A_1).Source is Image)
			{
				DependencyObject parent2 = ((FrameworkElement)(StackPanel)((FrameworkElement)(Image)((RoutedEventArgs)A_1).Source).Parent).Parent;
				val = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
			}
			if (val != null)
			{
				val.IsSelected = true;
			}
			b(val);
		}
	}

	private void a(object A_0, MouseEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem != null && ((UIElement)(TreeViewItem)tvActionsConditions.SelectedItem).IsMouseOver)
		{
			Point position = A_1.GetPosition((IInputElement)null);
			Vector val = startPoint - position;
			if ((int)A_1.LeftButton == 1 && (Math.Abs(val.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(val.Y) > SystemParameters.MinimumVerticalDragDistance))
			{
				object selectedItem = tvActionsConditions.SelectedItem;
				DataObject val2 = new DataObject("tvNode", (selectedItem is TreeViewItem) ? selectedItem : null);
				DragDrop.DoDragDrop((DependencyObject)(object)tvActionsConditions, (object)val2, (DragDropEffects)1);
			}
		}
	}

	private bool b(PageType A_0, string A_1)
	{
		bool result = true;
		switch (A_0)
		{
		case PageType.objects:
		{
			GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
			if (objectByName != null)
			{
				for (int l = 0; l < objectByName.Actions.Count; l++)
				{
					if (string.Compare(A_1, objectByName.Actions[l].name) == 0)
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
			break;
		}
		case PageType.player:
		{
			for (int k = 0; k < TheGame.ThePlayer.Actions.Count; k++)
			{
				if (string.Compare(A_1, TheGame.ThePlayer.Actions[k].name) == 0)
				{
					result = false;
					break;
				}
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = TheGame.GetCharacterByName(TheCurrentObject);
			if (characterByName != null)
			{
				for (int j = 0; j < characterByName.Actions.Count; j++)
				{
					if (string.Compare(A_1, characterByName.Actions[j].name) == 0)
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
			break;
		}
		case PageType.room:
		{
			Room roomByID = TheGame.GetRoomByID(new Guid(TheCurrentObject));
			if (roomByID != null)
			{
				for (int m = 0; m < roomByID.Actions.Count; m++)
				{
					if (string.Compare(A_1, roomByID.Actions[m].name) == 0)
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = TheGame.GetTimerByName(TheCurrentObject);
			if (timerByName != null)
			{
				for (int i = 0; i < timerByName.Actions.Count; i++)
				{
					if (string.Compare(A_1, timerByName.Actions[i].name) == 0)
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
			break;
		}
		}
		return result;
	}

	public void ExpandCollapseAll(ItemCollection itms, bool bExpand)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected Obj, but got Unknown
		foreach (TreeViewItem item in (IEnumerable)itms)
		{
			TreeViewItem val = item;
			val.IsExpanded = bExpand;
			if (((CollectionView)((ItemsControl)val).Items).Count > 0)
			{
				ExpandCollapseAll(((ItemsControl)val).Items, bExpand);
			}
		}
	}

	private int a(TreeViewItem A_0)
	{
		int num = 0;
		if (A_0 == null)
		{
			return num;
		}
		while (((FrameworkElement)A_0).Parent is TreeViewItem)
		{
			num++;
			DependencyObject parent = ((FrameworkElement)A_0).Parent;
			A_0 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		return num;
	}

	private void g()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		TreeViewItem val = null;
		List<Condition> list = null;
		List<object> list2 = null;
		int num = 0;
		Rags.Action action = s();
		object selectedItem = tvActionsConditions.SelectedItem;
		if (a((TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null)) <= 1)
		{
			list = action.Conditions;
			val = k();
			num = 0;
		}
		else
		{
			TreeViewItem val2 = null;
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag != null)
			{
				object selectedItem2 = tvActionsConditions.SelectedItem;
				val2 = (TreeViewItem)((selectedItem2 is TreeViewItem) ? selectedItem2 : null);
				((TreeViewItem)((FrameworkElement)val2).Parent).IsSelected = true;
			}
			list2 = c(e());
			if (val2 != null)
			{
				val2.IsSelected = true;
			}
			val = f();
			num = 0;
		}
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		ClipboardMS.Seek(0L, SeekOrigin.Begin);
		Condition condition = sharpSerializer.Deserialize(ClipboardMS) as Condition;
		if (list != null)
		{
			if (list.Count == 0)
			{
				list.Add(condition);
			}
			else
			{
				list.Insert(num, condition);
			}
		}
		else if (list2 != null)
		{
			if (list2.Count == 0)
			{
				list2.Add(condition);
			}
			else
			{
				list2.Insert(num, condition);
			}
		}
		a(condition, val, num);
	}

	private TreeViewItem f()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		object selectedItem = tvActionsConditions.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.ToString();
		while (((FrameworkElement)val).Parent != null && !(text == "Commands on Success") && !(text == "Commands on Failure"))
		{
			DependencyObject parent = ((FrameworkElement)val).Parent;
			val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.ToString();
		}
		return val;
	}

	private List<object> c(bool A_0)
	{
		List<object> result = null;
		if (o())
		{
			result = ((!A_0) ? s().FailCommands : s().PassCommands);
		}
		else
		{
			Condition condition = q();
			if (condition != null)
			{
				result = ((!A_0) ? condition.FailCommands : condition.PassCommands);
			}
		}
		return result;
	}

	private bool e()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		object selectedItem = tvActionsConditions.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.ToString();
		while (text != "Commands on Success" && text != "Commands on Failure" && ((FrameworkElement)val).Parent is TreeViewItem)
		{
			DependencyObject parent = ((FrameworkElement)val).Parent;
			val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.ToString();
		}
		if (text == "Commands on Success")
		{
			result = true;
		}
		return result;
	}

	private TreeViewItem d()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		object selectedItem = tvActionsConditions.SelectedItem;
		TreeViewItem val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
		if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content.ToString().IndexOf("Commands on") > -1)
		{
			return val;
		}
		DependencyObject parent = ((FrameworkElement)val).Parent;
		return (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
	}

	private void a(PageType A_0, string A_1)
	{
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected Obj, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected Obj, but got Unknown
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Invalid comparison between Unknown and I4
		//IL_098c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected Obj, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected Obj, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected Obj, but got Unknown
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0624: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4d: Expected Obj, but got Unknown
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f44: Invalid comparison between Unknown and I4
		//IL_0b9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba3: Expected Obj, but got Unknown
		//IL_0bc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd0: Expected Obj, but got Unknown
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1214: Unknown result type (might be due to invalid IL or missing references)
		//IL_1242: Unknown result type (might be due to invalid IL or missing references)
		//IL_1248: Invalid comparison between Unknown and I4
		//IL_1839: Unknown result type (might be due to invalid IL or missing references)
		//IL_183f: Invalid comparison between Unknown and I4
		//IL_1b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba4: Invalid comparison between Unknown and I4
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		ClipboardMS.Seek(0L, SeekOrigin.Begin);
		switch (A_1)
		{
		case "Rename Action":
		{
			GetNameWindow getNameWindow2 = new GetNameWindow();
			((ContentControl)getNameWindow2.lblTitle).Content = "Please Enter New Action Name:";
			((Window)getNameWindow2).Owner = Window.GetWindow((DependencyObject)(object)this);
			if (((Window)getNameWindow2).ShowDialog() == true)
			{
				if (b(ThePageType, getNameWindow2.txtEntry.Text))
				{
					Rags.Action action3 = s();
					TreeViewItem val = k();
					action3.name = getNameWindow2.txtEntry.Text;
					((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val).Header).Children[1]).Content = getNameWindow2.txtEntry.Text;
				}
				else
				{
					MessageBox.Show("Sorry, that action name is already taken.  Please choose a different action name.");
				}
			}
			break;
		}
		case "Add Action":
		{
			Rags.Action action4 = null;
			if (ThePageType != PageType.timers)
			{
				GetNameWindow getNameWindow3 = new GetNameWindow();
				((ContentControl)getNameWindow3.lblTitle).Content = "Please Enter Action Name:";
				((Window)getNameWindow3).Owner = Window.GetWindow((DependencyObject)(object)this);
				if (((Window)getNameWindow3).ShowDialog() == true)
				{
					if (b(A_0, getNameWindow3.txtEntry.Text))
					{
						action4 = new Rags.Action();
						action4.name = getNameWindow3.txtEntry.Text;
						n().Add(action4);
						TreeViewItem val2 = new TreeViewItem();
						((HeaderedItemsControl)val2).Header = b(action4.name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val2).Tag = action4;
						((ItemsControl)tvActionsConditions).Items.Add((object)val2);
						TreeViewItem val3 = new TreeViewItem();
						((HeaderedItemsControl)val3).Header = b("Commands on Success", "pack://application:,,/Images/Green.png");
						((ItemsControl)val2).Items.Add((object)val3);
						TreeViewItem val4 = new TreeViewItem();
						((HeaderedItemsControl)val4).Header = b("Commands on Failure", "pack://application:,,/Images/Red.png");
						((ItemsControl)val2).Items.Add((object)val4);
						val2.IsSelected = true;
					}
					else
					{
						MessageBox.Show("Sorry, that action name already exists.");
					}
					break;
				}
				return;
			}
			if (TheGame.GetTimerByName(TheCurrentObject).TType == Timer.TimerType.TT_RUNALWAYS)
			{
				MessageBox.Show("There are no more available actions for a timer set to run always.  If you'd like to change the timer type, please go to the timer's general page.");
				break;
			}
			AddTimerActionsWindow addTimerActionsWindow = new AddTimerActionsWindow(TheGame.GetTimerByName(TheCurrentObject).Length);
			if (((Window)addTimerActionsWindow).ShowDialog() != true)
			{
				break;
			}
			foreach (string selectedItem5 in addTimerActionsWindow.b.SelectedItems)
			{
				action4 = new Rags.Action();
				action4.name = selectedItem5;
				n().Add(action4);
				TreeViewItem val5 = new TreeViewItem();
				((HeaderedItemsControl)val5).Header = b(action4.name, "pack://application:,,/Images/run.png");
				((FrameworkElement)val5).Tag = action4;
				((ItemsControl)tvActionsConditions).Items.Add((object)val5);
				TreeViewItem val6 = new TreeViewItem();
				((HeaderedItemsControl)val6).Header = b("Commands on Success", "pack://application:,,/Images/Green.png");
				((ItemsControl)val5).Items.Add((object)val6);
				TreeViewItem val7 = new TreeViewItem();
				((HeaderedItemsControl)val7).Header = b("Commands on Failure", "pack://application:,,/Images/Red.png");
				((ItemsControl)val5).Items.Add((object)val7);
				val5.IsSelected = true;
			}
			break;
		}
		case "Copy Action":
		{
			Rags.Action action2 = s();
			if (action2 != null)
			{
				sharpSerializer.Serialize(action2, ClipboardMS);
			}
			break;
		}
		case "Expand All":
			ExpandCollapseAll(((ItemsControl)tvActionsConditions).Items, bExpand: true);
			break;
		case "Collapse All":
			ExpandCollapseAll(((ItemsControl)tvActionsConditions).Items, bExpand: false);
			break;
		case "Paste Action":
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			if (!(sharpSerializer.Deserialize(ClipboardMS) is Rags.Action action))
			{
				break;
			}
			if (b(A_0, action.name))
			{
				n().Add(action);
				a(action, -1, A_2: true);
			}
			else
			{
				if ((int)MessageBox.Show("There is already an action name " + action.name + ".  Would you like to rename this action?", "Duplicate Name", (MessageBoxButton)4) != 6)
				{
					break;
				}
				GetNameWindow getNameWindow = new GetNameWindow();
				((ContentControl)getNameWindow.lblTitle).Content = "Please Enter Action Name:";
				((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
				if (((Window)getNameWindow).ShowDialog() == true)
				{
					if (b(A_0, getNameWindow.txtEntry.Text))
					{
						action.name = getNameWindow.txtEntry.Text;
						n().Add(action);
						a(action, -1, A_2: true);
					}
					else
					{
						MessageBox.Show("Sorry, that action name already exists.");
					}
				}
			}
			break;
		case "Copy Condition":
		{
			Condition condition2 = q();
			if (condition2 != null)
			{
				sharpSerializer.Serialize(condition2, ClipboardMS);
			}
			break;
		}
		case "Paste Condition":
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			if (sharpSerializer.Deserialize(ClipboardMS) is Condition)
			{
				g();
			}
			break;
		case "Copy Command":
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command data)
			{
				sharpSerializer.Serialize(data, ClipboardMS);
			}
			break;
		case "Paste Command":
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition || ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action)
			{
				MessageBox.Show("Sorry, you can't paste a command here.");
				return;
			}
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			if (sharpSerializer.Deserialize(ClipboardMS) is Command command)
			{
				List<object> list = c(((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Header).Children[1]).Content.ToString() == "Commands on Success" || ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header).Children[1]).Content.ToString() == "Commands on Success");
				if (list != null)
				{
					list.Add(command);
					a(command, d());
				}
			}
			break;
		case "Delete Action":
			switch (A_0)
			{
			case PageType.objects:
			{
				GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
				if (objectByName != null)
				{
					Rags.Action item4 = s();
					objectByName.Actions.Remove(item4);
				}
				break;
			}
			case PageType.player:
			{
				Rags.Action item = s();
				TheGame.ThePlayer.Actions.Remove(item);
				break;
			}
			case PageType.characters:
			{
				Character characterByName = TheGame.GetCharacterByName(TheCurrentObject);
				if (characterByName != null)
				{
					Rags.Action item2 = s();
					characterByName.Actions.Remove(item2);
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID = TheGame.GetRoomByID(new Guid(TheCurrentObject));
				if (roomByID != null)
				{
					Rags.Action item5 = s();
					roomByID.Actions.Remove(item5);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName = TheGame.GetTimerByName(TheCurrentObject);
				if (timerByName != null)
				{
					Rags.Action item3 = s();
					timerByName.Actions.Remove(item3);
				}
				break;
			}
			case PageType.quickcommand:
			{
				QuickMenuItem menuItemByName = TheGame.GetMenuItemByName(TheCurrentObject);
				if (menuItemByName != null)
				{
					Rags.Action actionByName = menuItemByName.GetActionByName(((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header).Children[1]).Content.ToString());
					if (actionByName != null)
					{
						menuItemByName.Actions.Remove(actionByName);
					}
				}
				break;
			}
			}
			((ItemsControl)tvActionsConditions).Items.Remove((object)k());
			break;
		}
		switch (A_1)
		{
		case "Delete Condition":
		{
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag == null || !(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition))
			{
				break;
			}
			object selectedItem2 = tvActionsConditions.SelectedItem;
			int num = a((TreeViewItem)((selectedItem2 is TreeViewItem) ? selectedItem2 : null));
			if (num <= 1)
			{
				s().Conditions.Remove(q());
				ItemCollection items = ((ItemsControl)k()).Items;
				object selectedItem3 = tvActionsConditions.SelectedItem;
				items.Remove((selectedItem3 is TreeViewItem) ? selectedItem3 : null);
				break;
			}
			object selectedItem4 = tvActionsConditions.SelectedItem;
			TreeViewItem val12 = (TreeViewItem)((selectedItem4 is TreeViewItem) ? selectedItem4 : null);
			object tag = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag;
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition && num != 2)
			{
				((TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).IsSelected = true;
			}
			List<object> list5 = c(e());
			if (list5 != null)
			{
				val12.IsSelected = true;
				list5.Remove(tag);
				((ItemsControl)f()).Items.Remove(tvActionsConditions.SelectedItem);
			}
			break;
		}
		case "Add Condition":
		{
			GetNameWindow getNameWindow4 = new GetNameWindow();
			((ContentControl)getNameWindow4.lblTitle).Content = "Please Enter Condition Name:";
			((Window)getNameWindow4).Owner = Window.GetWindow((DependencyObject)(object)this);
			if (((Window)getNameWindow4).ShowDialog() != true)
			{
				break;
			}
			Condition condition3 = null;
			TreeViewItem val8 = null;
			object selectedItem = tvActionsConditions.SelectedItem;
			if (a((TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null)) == 0)
			{
				val8 = k();
				Rags.Action action7 = s();
				if (action7 != null)
				{
					condition3 = new Condition(getNameWindow4.txtEntry.Text);
					condition3.Checks.Add(new Check());
					condition3.Checks[0].CondType = Condition.ConditionType.CT_Item_Held_By_Player;
					action7.Conditions.Add(condition3);
				}
			}
			else
			{
				List<object> list3 = c(e());
				condition3 = new Condition(getNameWindow4.txtEntry.Text);
				condition3.Checks.Add(new Check());
				condition3.Checks[0].CondType = Condition.ConditionType.CT_Item_Held_By_Player;
				list3.Add(condition3);
				val8 = f();
			}
			TreeViewItem val9 = new TreeViewItem();
			((HeaderedItemsControl)val9).Header = b(getNameWindow4.txtEntry.Text, "pack://application:,,/Images/Question.png");
			((FrameworkElement)val9).Tag = condition3;
			if (o())
			{
				((ItemsControl)val8).Items.Insert(0, (object)val9);
			}
			else
			{
				((ItemsControl)val8).Items.Add((object)val9);
			}
			TreeViewItem val10 = new TreeViewItem();
			((HeaderedItemsControl)val10).Header = b("Commands on Success", "pack://application:,,/Images/Green.png");
			((ItemsControl)val9).Items.Add((object)val10);
			TreeViewItem val11 = new TreeViewItem();
			((HeaderedItemsControl)val11).Header = b("Commands on Failure", "pack://application:,,/Images/Red.png");
			((ItemsControl)val9).Items.Add((object)val11);
			val9.IsSelected = true;
			((FrameworkElement)val9).BringIntoView();
			break;
		}
		case "Add Command On Success":
			a(A_0: true);
			break;
		case "Add Command On Failure":
			a(A_0: false);
			break;
		case "Delete Command":
			c();
			break;
		case "Examine":
		{
			Rags.Action action12 = null;
			switch (A_0)
			{
			case PageType.characters:
			{
				Character characterByName2 = TheGame.GetCharacterByName(TheCurrentObject);
				if (characterByName2 != null && b(A_0, "Examine"))
				{
					action12 = new Rags.Action();
					characterByName2.Actions.Add(action12);
					action12.name = "Examine";
					action12.bActive = true;
					Command command9 = new Command();
					action12.PassCommands.Add(command9);
					command9.CommandName = "Display Char Data";
					command9.cmdtype = Command.CommandType.CT_DISPLAYCHARDESC;
					command9.CommandPart2 = characterByName2.Charname;
				}
				break;
			}
			case PageType.objects:
			{
				GameObject objectByName5 = TheGame.GetObjectByName(TheCurrentObject);
				if (objectByName5 != null && b(A_0, "Examine"))
				{
					action12 = new Rags.Action();
					objectByName5.Actions.Add(action12);
					action12.name = "Examine";
					action12.bActive = true;
					Command command10 = new Command();
					action12.PassCommands.Add(command10);
					command10.CommandName = "Display Item Data";
					command10.cmdtype = Command.CommandType.CT_DISPLAYITEMDESC;
					command10.CommandPart2 = objectByName5.name;
				}
				break;
			}
			case PageType.player:
				if (b(A_0, "Examine"))
				{
					action12 = new Rags.Action();
					TheGame.ThePlayer.Actions.Add(action12);
					action12.name = "Examine";
					action12.bActive = true;
					Command command11 = new Command();
					action12.PassCommands.Add(command11);
					command11.CommandName = "Display Player Description";
					command11.cmdtype = Command.CommandType.CT_DISPLAYPLAYERDESC;
				}
				break;
			case PageType.room:
			{
				Room roomByID2 = TheGame.GetRoomByID(new Guid(TheCurrentObject));
				if (roomByID2 != null && b(A_0, "Examine"))
				{
					action12 = new Rags.Action();
					roomByID2.Actions.Add(action12);
					action12.name = "Examine";
					action12.bActive = true;
					Command command8 = new Command();
					action12.PassCommands.Add(command8);
					command8.CommandName = "Display Room Data";
					command8.cmdtype = Command.CommandType.CT_DISPLAYROOMDESCRIPTION;
					command8.CommandPart2 = Room.CurrentRoomGuid.ToString();
					command8 = new Command();
					action12.PassCommands.Add(command8);
					command8.CommandName = "Display Room Pic";
					command8.cmdtype = Command.CommandType.CT_DISPLAYROOMPICTURE;
					command8.CommandPart2 = Room.CurrentRoomGuid.ToString();
				}
				break;
			}
			}
			a(action12, -1, A_2: true);
			break;
		}
		case "Open/Close":
		{
			List<Rags.Action> list6 = n();
			string theCurrentObject = TheCurrentObject;
			if (ThePageType == PageType.objects)
			{
				GameObject objectByName4 = TheGame.GetObjectByName(TheCurrentObject);
				if (!objectByName4.bOpenable)
				{
					if ((int)MessageBox.Show("This object is not currently marked as openable.  Would you like to make this object openable?", "Not Openable", (MessageBoxButton)4) != 6)
					{
						break;
					}
					objectByName4.bOpenable = true;
				}
			}
			if (b(A_0, "Open"))
			{
				Rags.Action action10 = new Rags.Action();
				list6.Add(action10);
				action10.name = "Open";
				action10.bActive = true;
				Command command6 = new Command();
				action10.PassCommands.Add(command6);
				command6.CommandName = "Set Item To Open";
				command6.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
				command6.CommandPart2 = theCurrentObject;
				command6.CommandPart3 = "Open";
				command6 = new Command();
				command6.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command6.CommandName = "Display Result";
				command6.CommandText = "The " + theCurrentObject + " is now open.";
				action10.PassCommands.Add(command6);
				Condition condition6 = new Condition("Check For Open");
				action10.Conditions.Add(condition6);
				Check check3 = condition6.Checks[0];
				check3.CondType = Condition.ConditionType.CT_Item_State_Check;
				check3.ConditionStep2 = theCurrentObject;
				check3.ConditionStep3 = "Closed";
				command6 = new Command();
				command6.CommandName = "Display already open";
				command6.CommandText = "The " + theCurrentObject + " is already open.";
				command6.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition6.FailCommands.Add(command6);
				a(action10, -1, A_2: true);
			}
			if (b(A_0, "Close"))
			{
				Rags.Action action11 = new Rags.Action();
				list6.Add(action11);
				action11.name = "Close";
				action11.bActive = true;
				Command command7 = new Command();
				action11.PassCommands.Add(command7);
				command7.CommandName = "Set Item To Closed";
				command7.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
				command7.CommandPart2 = theCurrentObject;
				command7.CommandPart3 = "Closed";
				command7 = new Command();
				command7.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command7.CommandName = "Display Result";
				command7.CommandText = "The " + theCurrentObject + " is now closed.";
				action11.PassCommands.Add(command7);
				Condition condition7 = new Condition("Check For Closed");
				action11.Conditions.Add(condition7);
				Check check4 = condition7.Checks[0];
				check4.CondType = Condition.ConditionType.CT_Item_State_Check;
				check4.ConditionStep2 = theCurrentObject;
				check4.ConditionStep3 = "Open";
				command7 = new Command();
				command7.CommandName = "Display already closed";
				command7.CommandText = "The " + theCurrentObject + " is already closed.";
				command7.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition7.FailCommands.Add(command7);
				a(action11, -1, A_2: true);
			}
			break;
		}
		case "Action Wizard...":
			break;
		case "Wear/Remove":
		{
			List<Rags.Action> list4 = null;
			string text2 = "";
			if (A_0 != PageType.objects)
			{
				MessageBox.Show("You may only wear object types.");
				break;
			}
			GameObject objectByName3 = TheGame.GetObjectByName(TheCurrentObject);
			if (!objectByName3.bWearable)
			{
				if ((int)MessageBox.Show("This object is not currently marked as wearable.  Would you like to make this object wearable?", "Not Wearable", (MessageBoxButton)4) != 6)
				{
					break;
				}
				objectByName3.bWearable = true;
			}
			list4 = objectByName3.Actions;
			text2 = objectByName3.name;
			if (b(A_0, "Wear"))
			{
				Rags.Action action8 = new Rags.Action();
				list4.Add(action8);
				action8.name = "Wear";
				action8.bActive = true;
				Command command4 = new Command();
				action8.PassCommands.Add(command4);
				command4.CommandName = "Set Item To Worn";
				command4.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
				command4.CommandPart2 = text2;
				command4.CommandPart3 = "Worn";
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command4.CommandName = "Enable Remove";
				command4.CommandPart2 = TheCurrentObject;
				command4.CommandPart3 = "Remove-Active";
				action8.PassCommands.Add(command4);
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command4.CommandName = "Disable Wear";
				command4.CommandPart2 = TheCurrentObject;
				command4.CommandPart3 = "Wear-Inactive";
				action8.PassCommands.Add(command4);
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command4.CommandName = "Display Result";
				if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).preposition != string.Empty)
				{
					command4.CommandText = "You are now wearing " + TheGame.GetObjectByName(TheCurrentObject).preposition + " " + text2 + ".";
				}
				else
				{
					command4.CommandText = "You are now wearing the " + text2 + ".";
				}
				action8.PassCommands.Add(command4);
				Condition condition4 = new Condition("Item must be in inventory");
				action8.Conditions.Add(condition4);
				Check check = condition4.Checks[0];
				check.CondType = Condition.ConditionType.CT_Item_Held_By_Player;
				check.ConditionStep2 = text2;
				check.ConditionStep3 = "Open";
				command4 = new Command();
				command4.CommandName = "Display not held";
				if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).preposition != string.Empty)
				{
					command4.CommandText = "You must get " + TheGame.GetObjectByName(TheCurrentObject).preposition + " " + text2 + ".";
				}
				else
				{
					command4.CommandText = "You must get the " + text2 + " first.";
				}
				command4.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition4.FailCommands.Add(command4);
				a(action8, -1, A_2: true);
			}
			if (b(A_0, "Remove"))
			{
				Rags.Action action9 = new Rags.Action();
				list4.Add(action9);
				action9.name = "Remove";
				action9.bActive = false;
				Command command5 = new Command();
				action9.PassCommands.Add(command5);
				command5.CommandName = "Set Item To Removed";
				command5.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
				command5.CommandPart2 = text2;
				command5.CommandPart3 = "Removed";
				command5 = new Command();
				command5.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command5.CommandName = "Enable Wear";
				command5.CommandPart2 = TheCurrentObject;
				command5.CommandPart3 = "Wear-Active";
				action9.PassCommands.Add(command5);
				command5 = new Command();
				command5.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command5.CommandName = "Disable Remove";
				command5.CommandPart2 = TheCurrentObject;
				command5.CommandPart3 = "Remove-Inactive";
				action9.PassCommands.Add(command5);
				command5 = new Command();
				command5.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command5.CommandName = "Display Result";
				if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).preposition != string.Empty)
				{
					command5.CommandText = "You have now removed " + TheGame.GetObjectByName(TheCurrentObject).preposition + " " + text2 + ".";
				}
				else
				{
					command5.CommandText = "You have now removed " + text2 + ".";
				}
				action9.PassCommands.Add(command5);
				Condition condition5 = new Condition("Item must be currently worn");
				action9.Conditions.Add(condition5);
				Check check2 = condition5.Checks[0];
				check2.CondType = Condition.ConditionType.CT_Item_State_Check;
				check2.ConditionStep2 = text2;
				check2.ConditionStep3 = "Worn";
				command5 = new Command();
				command5.CommandName = "Display not worn";
				if (ThePageType == PageType.objects && TheGame.GetObjectByName(TheCurrentObject).preposition != string.Empty)
				{
					command5.CommandText = "You are not wearing " + TheGame.GetObjectByName(TheCurrentObject).preposition + " " + text2 + ".";
				}
				else
				{
					command5.CommandText = "You are not wearing " + text2 + ".";
				}
				command5.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition5.FailCommands.Add(command5);
				a(action9, -1, A_2: true);
			}
			break;
		}
		case "Lock/Unlock":
		{
			if (ThePageType == PageType.objects)
			{
				GameObject objectByName6 = TheGame.GetObjectByName(TheCurrentObject);
				if (!objectByName6.bLockable)
				{
					if ((int)MessageBox.Show("This object is not currently marked as lockable.  Would you like to make this object lockable?", "Not Lockable", (MessageBoxButton)4) != 6)
					{
						break;
					}
					objectByName6.bLockable = true;
				}
			}
			List<Rags.Action> list7 = null;
			string text3 = "";
			switch (A_0)
			{
			case PageType.objects:
				list7 = TheGame.GetObjectByName(TheCurrentObject).Actions;
				text3 = TheGame.GetObjectByName(TheCurrentObject).name;
				break;
			case PageType.characters:
				list7 = TheGame.GetCharacterByName(TheCurrentObject).Actions;
				text3 = TheGame.GetCharacterByName(TheCurrentObject).Charname;
				break;
			}
			if (b(A_0, "Lock"))
			{
				Rags.Action action13 = new Rags.Action();
				list7.Add(action13);
				action13.name = "Lock";
				action13.bActive = true;
				Command command12 = new Command();
				action13.PassCommands.Add(command12);
				command12.CommandName = "Set Item To Locked";
				command12.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
				command12.CommandPart2 = text3;
				command12.CommandPart3 = "Locked";
				command12 = new Command();
				command12.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command12.CommandName = "Display Result";
				command12.CommandText = "The " + text3 + " is now locked.";
				action13.PassCommands.Add(command12);
				Condition condition8 = new Condition("Check For Locked");
				action13.Conditions.Add(condition8);
				Check check5 = condition8.Checks[0];
				check5.CondType = Condition.ConditionType.CT_Item_State_Check;
				check5.ConditionStep2 = text3;
				check5.ConditionStep3 = "Unlocked";
				command12 = new Command();
				command12.CommandName = "Display already locked";
				command12.CommandText = "The " + text3 + " is already locked.";
				command12.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition8.FailCommands.Add(command12);
				a(action13, -1, A_2: true);
			}
			if (b(A_0, "Unlock"))
			{
				Rags.Action action14 = new Rags.Action();
				list7.Add(action14);
				action14.name = "Unlock";
				action14.bActive = true;
				Command command13 = new Command();
				action14.PassCommands.Add(command13);
				command13.CommandName = "Set Item To Unlocked";
				command13.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
				command13.CommandPart2 = text3;
				command13.CommandPart3 = "Unlocked";
				command13 = new Command();
				command13.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command13.CommandName = "Display Result";
				command13.CommandText = "The " + text3 + " is now unlocked.";
				action14.PassCommands.Add(command13);
				Condition condition9 = new Condition("Check For Unlocked");
				action14.Conditions.Add(condition9);
				Check check6 = condition9.Checks[0];
				check6.CondType = Condition.ConditionType.CT_Item_State_Check;
				check6.ConditionStep2 = text3;
				check6.ConditionStep3 = "Locked";
				command13 = new Command();
				command13.CommandName = "Display already unlocked";
				command13.CommandText = "The " + text3 + " is already unlocked.";
				command13.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition9.FailCommands.Add(command13);
				a(action14, -1, A_2: true);
			}
			break;
		}
		case "Take/Drop":
		{
			if (ThePageType == PageType.objects)
			{
				GameObject objectByName2 = TheGame.GetObjectByName(TheCurrentObject);
				if (!objectByName2.bCarryable)
				{
					if ((int)MessageBox.Show("This object is not currently marked as carryable.  Would you like to make this object carryable?", "Not Carryable", (MessageBoxButton)4) != 6)
					{
						break;
					}
					objectByName2.bCarryable = true;
				}
			}
			List<Rags.Action> list2 = null;
			string text = "";
			switch (A_0)
			{
			case PageType.objects:
				list2 = TheGame.GetObjectByName(TheCurrentObject).Actions;
				text = TheGame.GetObjectByName(TheCurrentObject).name;
				break;
			case PageType.characters:
				list2 = TheGame.GetCharacterByName(TheCurrentObject).Actions;
				text = TheGame.GetCharacterByName(TheCurrentObject).Charname;
				break;
			}
			if (b(A_0, "Take"))
			{
				Rags.Action action5 = new Rags.Action();
				list2.Add(action5);
				action5.name = "Take";
				action5.bActive = true;
				Command command2 = new Command();
				action5.PassCommands.Add(command2);
				command2.CommandName = "Pick Item Up";
				command2.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
				command2.CommandPart2 = text;
				command2 = new Command();
				command2.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command2.CommandName = "Display Result";
				command2.CommandText = "You pick up the " + text + ".";
				action5.PassCommands.Add(command2);
				command2 = new Command();
				command2.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command2.CommandName = "Enable Drop";
				command2.CommandPart2 = TheCurrentObject;
				command2.CommandPart3 = "Drop-Active";
				action5.PassCommands.Add(command2);
				command2 = new Command();
				command2.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command2.CommandName = "Disable Take";
				command2.CommandPart2 = TheCurrentObject;
				command2.CommandPart3 = "Take-Inactive";
				action5.PassCommands.Add(command2);
				a(action5, -1, A_2: true);
			}
			if (b(A_0, "Drop"))
			{
				Rags.Action action6 = new Rags.Action();
				list2.Add(action6);
				action6.name = "Drop";
				action6.bActive = false;
				Command command3 = new Command();
				action6.PassCommands.Add(command3);
				command3.CommandName = "Drop Item";
				command3.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
				command3.CommandPart2 = text;
				command3.CommandPart3 = Room.CurrentRoomGuid.ToString();
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command3.CommandName = "Display Result";
				command3.CommandText = "You dropped the " + text + ".";
				action6.PassCommands.Add(command3);
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command3.CommandName = "Enable Take";
				command3.CommandPart2 = text;
				command3.CommandPart3 = "Take-Active";
				action6.PassCommands.Add(command3);
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command3.CommandName = "Disable Drop";
				command3.CommandPart2 = text;
				command3.CommandPart3 = "Drop-Inactive";
				action6.PassCommands.Add(command3);
				a(action6, -1, A_2: true);
			}
			break;
		}
		}
	}

	private TreeViewItem b(bool A_0)
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		TreeViewItem val = null;
		if (o())
		{
			object selectedItem = tvActionsConditions.SelectedItem;
			val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
			while (((FrameworkElement)val).Parent is TreeViewItem)
			{
				DependencyObject parent = ((FrameworkElement)val).Parent;
				val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			}
			if (A_0)
			{
				foreach (TreeViewItem item in (IEnumerable)((ItemsControl)val).Items)
				{
					TreeViewItem val2 = item;
					if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val2).Header).Children[1]).Content.ToString() == "Commands on Success")
					{
						val = val2;
						break;
					}
				}
			}
			else
			{
				foreach (TreeViewItem item2 in (IEnumerable)((ItemsControl)val).Items)
				{
					TreeViewItem val3 = item2;
					if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val3).Header).Children[1]).Content.ToString() == "Commands on Failure")
					{
						val = val3;
						break;
					}
				}
			}
		}
		else
		{
			object selectedItem2 = tvActionsConditions.SelectedItem;
			if (a((TreeViewItem)((selectedItem2 is TreeViewItem) ? selectedItem2 : null)) >= 1)
			{
				if (!(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition))
				{
					object selectedItem3 = tvActionsConditions.SelectedItem;
					TreeViewItem val4 = (TreeViewItem)((selectedItem3 is TreeViewItem) ? selectedItem3 : null);
					while (!(((FrameworkElement)val4).Tag is Condition))
					{
						DependencyObject parent2 = ((FrameworkElement)val4).Parent;
						val4 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
					}
					val = val4;
				}
				else
				{
					object selectedItem4 = tvActionsConditions.SelectedItem;
					val = (TreeViewItem)((selectedItem4 is TreeViewItem) ? selectedItem4 : null);
				}
			}
			if (A_0)
			{
				foreach (TreeViewItem item3 in (IEnumerable)((ItemsControl)val).Items)
				{
					TreeViewItem val5 = item3;
					if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val5).Header).Children[1]).Content.ToString() == "Commands on Success")
					{
						val = val5;
						break;
					}
				}
			}
			else
			{
				foreach (TreeViewItem item4 in (IEnumerable)((ItemsControl)val).Items)
				{
					TreeViewItem val6 = item4;
					if (((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val6).Header).Children[1]).Content.ToString() == "Commands on Failure")
					{
						val = val6;
						break;
					}
				}
			}
		}
		return val;
	}

	private void c()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		List<object> list = c(((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Header).Children[1]).Content.ToString() == "Commands on Success");
		list.Remove(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag);
		ItemCollection items = ((ItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Items;
		object selectedItem = tvActionsConditions.SelectedItem;
		items.Remove((selectedItem is TreeViewItem) ? selectedItem : null);
		a((object)null, (RoutedPropertyChangedEventArgs<object>)null);
	}

	private void a(bool A_0)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition)
		{
			((TreeViewItem)((ItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Items[0]).IsSelected = true;
		}
		List<object> list = c(A_0);
		Command command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		list.Add(command);
		TreeViewItem val = b(A_0);
		TreeViewItem val2 = new TreeViewItem();
		((HeaderedItemsControl)val2).Header = b(SaveLoad.GetCommandName(Command.CommandType.CT_DISPLAYTEXT), "pack://application:,,/Images/command.png");
		((FrameworkElement)val2).Tag = command;
		((ItemsControl)val).Items.Add((object)val2);
		val2.IsSelected = true;
		((FrameworkElement)val2).BringIntoView();
		((Selector)cbCommandStep1).SelectedItem = SaveLoad.GetCommandItem(((ItemsControl)cbCommandStep1).Items, Command.CommandType.CT_DISPLAYTEXT);
		h((object)null, (SelectionChangedEventArgs)null);
	}

	private void a(object A_0, DragEventArgs A_1)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected Obj, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		if (!A_1.Data.GetDataPresent("tvNode"))
		{
			return;
		}
		object data = A_1.Data.GetData("tvNode");
		TreeViewItem val = (TreeViewItem)((data is TreeViewItem) ? data : null);
		TreeViewItem val2 = null;
		if (((RoutedEventArgs)A_1).Source is Label)
		{
			DependencyObject parent = ((FrameworkElement)(StackPanel)((FrameworkElement)(Label)((RoutedEventArgs)A_1).Source).Parent).Parent;
			val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		else if (((RoutedEventArgs)A_1).Source is Image)
		{
			DependencyObject parent2 = ((FrameworkElement)(StackPanel)((FrameworkElement)(Image)((RoutedEventArgs)A_1).Source).Parent).Parent;
			val2 = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
		}
		if (val2 == null)
		{
			return;
		}
		if (((FrameworkElement)val).Tag is Command command)
		{
			Command command2 = ((FrameworkElement)val2).Tag as Command;
			if (command2 == command)
			{
				return;
			}
			if (command2 != null || ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val2).Header).Children[1]).Content.ToString() == "Commands on Success" || ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)val2).Header).Children[1]).Content.ToString() == "Commands on Failure")
			{
				a(ThePageType, "Copy Command");
				a(ThePageType, "Delete Command");
				val2.IsSelected = true;
				int i = 0;
				List<object> list = c(((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Header).Children[1]).Content.ToString() == "Commands on Success" || ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header).Children[1]).Content.ToString() == "Commands on Success");
				if (command2 != null)
				{
					for (i = 0; i < list.Count && (list[i] as Command != command2 || !(list[i] is Command)); i++)
					{
					}
				}
				ClipboardMS.Seek(0L, SeekOrigin.Begin);
				Command command3 = sharpSerializer.Deserialize(ClipboardMS) as Command;
				list.Insert(i, command3);
				TreeViewItem val3 = new TreeViewItem();
				((HeaderedItemsControl)val3).Header = b(a(command3), "pack://application:,,/Images/command.png");
				((FrameworkElement)val3).Tag = command3;
				if (command2 != null)
				{
					((ItemsControl)(TreeViewItem)((FrameworkElement)val2).Parent).Items.Insert(i, (object)val3);
				}
				else
				{
					((ItemsControl)val2).Items.Insert(i, (object)val3);
				}
			}
		}
		if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition condition)
		{
			Condition condition2 = ((FrameworkElement)val2).Tag as Condition;
			if (condition2 == condition)
			{
				return;
			}
			Command command4 = ((FrameworkElement)val2).Tag as Command;
			TreeViewItem val4 = null;
			List<Condition> list2 = null;
			List<object> list3 = null;
			a(ThePageType, "Copy Condition");
			a(ThePageType, "Delete Condition");
			val2.IsSelected = true;
			int num = 0;
			Rags.Action action = s();
			int num2 = a(val2);
			if (num2 <= 1)
			{
				list2 = action.Conditions;
				val4 = k();
				if (command4 == null && condition2 == null)
				{
					num = 0;
				}
				else
				{
					for (num = 0; num < list2.Count && action.Conditions[num] != condition2; num++)
					{
					}
				}
			}
			else
			{
				TreeViewItem val5 = null;
				if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag != null)
				{
					object selectedItem = tvActionsConditions.SelectedItem;
					val5 = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
					((TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).IsSelected = true;
				}
				list3 = c(e());
				if (val5 != null)
				{
					val5.IsSelected = true;
				}
				val4 = f();
				if (command4 == null && condition2 == null)
				{
					num = 0;
				}
				else if (num2 <= 1)
				{
					for (num = 0; num < list2.Count && (list2[num] != condition2 || list2[num] == null); num++)
					{
					}
				}
				else
				{
					for (num = 0; num < list3.Count && (list3[num] as Command != command4 || !(list3[num] is Command)) && (list3[num] as Condition != condition2 || !(list3[num] is Condition)); num++)
					{
					}
				}
			}
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Condition condition3 = sharpSerializer.Deserialize(ClipboardMS) as Condition;
			if (num2 <= 1)
			{
				if (list2.Count == 0)
				{
					list2.Add(condition3);
				}
				else
				{
					list2.Insert(num, condition3);
				}
			}
			else if (list3.Count == 0)
			{
				list3.Add(condition3);
			}
			else
			{
				list3.Insert(num, condition3);
			}
			a(condition3, val4, num);
		}
		if (!(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action action2))
		{
			return;
		}
		Rags.Action action3 = ((FrameworkElement)val2).Tag as Rags.Action;
		if (action3 != action2)
		{
			a(ThePageType, "Copy Action");
			a(ThePageType, "Delete Action");
			val2.IsSelected = true;
			int num3 = 0;
			List<Rags.Action> list4 = n();
			for (num3 = 0; num3 < list4.Count && list4[num3] != action3; num3++)
			{
			}
			num3++;
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Rags.Action action4 = sharpSerializer.Deserialize(ClipboardMS) as Rags.Action;
			if (num3 > list4.Count)
			{
				num3 = list4.Count;
			}
			list4.Insert(num3, action4);
			a(action4, num3, A_2: true);
		}
	}

	private void b()
	{
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		ClipboardMS.Seek(0L, SeekOrigin.Begin);
		object obj = sharpSerializer.Deserialize(ClipboardMS);
		if (obj.GetType() == typeof(Command))
		{
			a(ThePageType, "Paste Command");
		}
		else if (obj.GetType() == typeof(Condition))
		{
			a(ThePageType, "Paste Condition");
		}
		else if (obj.GetType() == typeof(Rags.Action))
		{
			a(ThePageType, "Paste Action");
		}
	}

	private void a()
	{
		if (UndoActions == null)
		{
			return;
		}
		MemoryStream memoryStream = new MemoryStream();
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		sharpSerializer.Serialize(UndoActions, memoryStream);
		memoryStream.Seek(0L, SeekOrigin.Begin);
		switch (ThePageType)
		{
		case PageType.objects:
		{
			GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
			if (objectByName != null)
			{
				objectByName.Actions = (List<Rags.Action>)sharpSerializer.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.player:
			TheGame.ThePlayer.Actions = (List<Rags.Action>)sharpSerializer.Deserialize(memoryStream);
			break;
		case PageType.room:
		{
			Room roomByID = TheGame.GetRoomByID(new Guid(TheCurrentObject));
			if (roomByID != null)
			{
				roomByID.Actions = (List<Rags.Action>)sharpSerializer.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.characters:
		{
			Character characterByName = TheGame.GetCharacterByName(TheCurrentObject);
			if (characterByName != null)
			{
				characterByName.Actions = (List<Rags.Action>)sharpSerializer.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.timers:
		{
			Timer timerByName = TheGame.GetTimerByName(TheCurrentObject);
			if (timerByName != null)
			{
				timerByName.Actions = (List<Rags.Action>)sharpSerializer.Deserialize(memoryStream);
			}
			break;
		}
		case PageType.quickcommand:
		{
			QuickMenuItem menuItemByName = TheGame.GetMenuItemByName(TheCurrentObject);
			if (menuItemByName != null)
			{
				menuItemByName.Actions = (List<Rags.Action>)sharpSerializer.Deserialize(memoryStream);
			}
			break;
		}
		}
		RefreshActions();
	}

	private void b(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Invalid comparison between Unknown and I4
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.Key == 65 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			j();
			b();
		}
		if ((int)A_1.Key == 69 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			a();
		}
		if ((int)A_1.Key == 46 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command)
			{
				a(ThePageType, "Copy Command");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition)
			{
				a(ThePageType, "Copy Condition");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action)
			{
				a(ThePageType, "Copy Action");
			}
		}
		if ((int)A_1.Key == 67 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			j();
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command)
			{
				a(ThePageType, "Copy Command");
				a(ThePageType, "Delete Command");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition)
			{
				a(ThePageType, "Copy Condition");
				a(ThePageType, "Delete Condition");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action)
			{
				a(ThePageType, "Copy Action");
				a(ThePageType, "Delete Action");
			}
		}
		if ((int)A_1.Key == 32 && tvActionsConditions.SelectedItem != null && ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag != null)
		{
			j();
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command)
			{
				a(ThePageType, "Delete Command");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition)
			{
				a(ThePageType, "Delete Condition");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action)
			{
				a(ThePageType, "Delete Action");
			}
		}
	}

	private void v(object A_0, RoutedEventArgs A_1)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem != null && ((Selector)cbCommandStep1).SelectedItem != null)
		{
			Command command = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
			if (command != null)
			{
				command.cmdtype = ((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex;
			}
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(a(command), "pack://application:,,/Images/command.png");
		}
	}

	private void u(object A_0, RoutedEventArgs A_1)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = q();
		if (condition == null)
		{
			return;
		}
		bool flag = false;
		foreach (Check check2 in condition.Checks)
		{
			if (check2.CondType == Condition.ConditionType.CT_Loop_While || check2.CondType == Condition.ConditionType.CT_Loop_Rooms || check2.CondType == Condition.ConditionType.CT_Loop_Characters || check2.CondType == Condition.ConditionType.CT_Loop_Items)
			{
				flag = true;
				MessageBox.Show("Sorry, you can not add additional checks to a loop.");
				break;
			}
		}
		if (!flag)
		{
			Check check = new Check();
			check.CkType = CheckType.And;
			q().Checks.Add(check);
			a(q());
			((Selector)lbChecks).SelectedIndex = q().Checks.Count - 1;
		}
	}

	private void t(object A_0, RoutedEventArgs A_1)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = q();
		if (condition == null)
		{
			return;
		}
		bool flag = false;
		foreach (Check check2 in condition.Checks)
		{
			if (check2.CondType == Condition.ConditionType.CT_Loop_While || check2.CondType == Condition.ConditionType.CT_Loop_Rooms || check2.CondType == Condition.ConditionType.CT_Loop_Characters || check2.CondType == Condition.ConditionType.CT_Loop_Items)
			{
				flag = true;
				MessageBox.Show("Sorry, you can not add additional checks to a loop.");
				break;
			}
		}
		if (!flag)
		{
			Check check = new Check();
			check.CkType = CheckType.Or;
			q().Checks.Add(check);
			a(q());
			((Selector)lbChecks).SelectedIndex = q().Checks.Count - 1;
		}
	}

	private void s(object A_0, RoutedEventArgs A_1)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem != null && ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command command)
		{
			command.CommandText = txtCommandText.Text;
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(a(command), "pack://application:,,/Images/command.png");
		}
	}

	private void r(object A_0, RoutedEventArgs A_1)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem != null)
		{
			Command command = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
			if (((Selector)cbCommandStep4).SelectedItem is RoomComboItem roomComboItem)
			{
				command.CommandPart4 = roomComboItem.UniqueID.ToString();
			}
			else
			{
				command.CommandPart4 = cbCommandStep4.Text;
			}
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(a(command), "pack://application:,,/Images/command.png");
		}
	}

	private void q(object A_0, RoutedEventArgs A_1)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition condition)
		{
			condition.conditionname = txtConditionName.Text;
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = b(txtConditionName.Text, "pack://application:,,/Images/Question.png");
		}
	}

	private void p(object A_0, RoutedEventArgs A_1)
	{
		Rags.Action action = s();
		if (action != null)
		{
			action.bActive = ((ToggleButton)cbActionActive).IsChecked.Value;
		}
	}

	private void a(object A_0, KeyEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if ((int)A_1.SystemKey != 65 || (!Keyboard.IsKeyDown((Key)120) && !Keyboard.IsKeyDown((Key)121)))
		{
			return;
		}
		((RoutedEventArgs)A_1).Handled = true;
		TextBox val = (TextBox)((A_0 is TextBox) ? A_0 : null);
		ComboBox val2 = (ComboBox)((A_0 is ComboBox) ? A_0 : null);
		int startIndex = 0;
		if (val2 != null)
		{
			startIndex = 0;
		}
		if (val != null)
		{
			startIndex = val.SelectionStart;
		}
		InsertVariableWindow insertVariableWindow = new InsertVariableWindow(ref TheGame);
		Window window = Window.GetWindow((DependencyObject)(object)this);
		((Window)insertVariableWindow).Owner = window;
		string text = string.Empty;
		if (((Window)insertVariableWindow).ShowDialog() == true)
		{
			switch (((Selector)insertVariableWindow.thetabctrl).SelectedIndex)
			{
			case 0:
				if (((Selector)insertVariableWindow.sysvars).SelectedItem != null)
				{
					text = ((ContentControl)(ListBoxItem)((Selector)insertVariableWindow.sysvars).SelectedItem).Content.ToString();
				}
				break;
			case 1:
				if (((Selector)insertVariableWindow.vars).SelectedItem != null)
				{
					text = ((Selector)insertVariableWindow.vars).SelectedItem.ToString();
				}
				break;
			case 2:
				if (((Selector)insertVariableWindow.custprop).SelectedItem != null)
				{
					text = ((Selector)insertVariableWindow.custprop).SelectedItem.ToString();
				}
				break;
			case 3:
				text = insertVariableWindow.thetext.Text;
				break;
			}
		}
		if (text != string.Empty)
		{
			if (val != null)
			{
				val.Text = val.Text.Insert(startIndex, text);
			}
			else if (val2 != null)
			{
				val2.Text = val2.Text.Insert(startIndex, text);
			}
		}
	}

	private void o(object A_0, RoutedEventArgs A_1)
	{
		Rags.Action action = s();
		if (action != null)
		{
			action.overridename = tbActionNameOverride.Text;
		}
	}

	private void a(object A_0, SelectionChangedEventArgs A_1)
	{
		Rags.Action action = s();
		if (((Selector)cbActionParent).SelectedItem != null)
		{
			action.actionparent = ((Selector)cbActionParent).SelectedItem.ToString();
		}
	}

	private void n(object A_0, RoutedEventArgs A_1)
	{
		Rags.Action action = s();
		if (action != null)
		{
			action.bConditionFailOnFirst = ((ToggleButton)rbFailOnFirst).IsChecked.Value;
		}
	}

	private void m(object A_0, RoutedEventArgs A_1)
	{
		if (((ToggleButton)rbaddinputCustom).IsChecked == true)
		{
			((UIElement)gbCustomChoices).IsEnabled = true;
			((UIElement)lbActionCustomChoices).IsEnabled = true;
			((UIElement)tbCustomChoiceTitle).IsEnabled = true;
			((UIElement)btnActionCustomAdd).IsEnabled = true;
			((UIElement)btnActionCustomUpdate).IsEnabled = true;
			((UIElement)btnActionCustomDelete).IsEnabled = true;
		}
	}

	private void l(object A_0, RoutedEventArgs A_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		RadioButton val = (RadioButton)A_0;
		if (val != null && ((ToggleButton)val).IsChecked == true)
		{
			((UIElement)gbCustomChoices).IsEnabled = true;
			((UIElement)lbActionCustomChoices).IsEnabled = false;
			((UIElement)tbCustomChoiceTitle).IsEnabled = true;
			((UIElement)btnActionCustomAdd).IsEnabled = false;
			((UIElement)btnActionCustomUpdate).IsEnabled = false;
			((UIElement)btnActionCustomDelete).IsEnabled = false;
		}
	}

	private void k(object A_0, RoutedEventArgs A_1)
	{
		if (((ToggleButton)rbaddinputnone).IsChecked == true)
		{
			((UIElement)gbCustomChoices).IsEnabled = false;
			((UIElement)lbActionCustomChoices).IsEnabled = false;
			((UIElement)tbCustomChoiceTitle).IsEnabled = false;
			((UIElement)btnActionCustomAdd).IsEnabled = false;
			((UIElement)btnActionCustomUpdate).IsEnabled = false;
			((UIElement)btnActionCustomDelete).IsEnabled = false;
		}
	}

	private void j(object A_0, RoutedEventArgs A_1)
	{
		Rags.Action action = s();
		if (action != null)
		{
			if (((ToggleButton)rbaddinputnone).IsChecked == true)
			{
				action.InputType = Rags.Action.ActionInputType.None;
			}
			else if (((ToggleButton)rbaddinputCharacter).IsChecked == true)
			{
				action.InputType = Rags.Action.ActionInputType.Character;
			}
			else if (((ToggleButton)rbaddinputObjectorCharacter).IsChecked == true)
			{
				action.InputType = Rags.Action.ActionInputType.ObjectOrCharacter;
			}
			else if (((ToggleButton)rbaddinputText).IsChecked == true)
			{
				action.InputType = Rags.Action.ActionInputType.Text;
			}
			else if (((ToggleButton)rbaddinputObject).IsChecked == true)
			{
				action.InputType = Rags.Action.ActionInputType.Object;
			}
			else if (((ToggleButton)rbaddinputCustom).IsChecked == true)
			{
				action.InputType = Rags.Action.ActionInputType.Custom;
			}
			else if (((ToggleButton)rbAddInputInventory).IsChecked == true)
			{
				action.InputType = Rags.Action.ActionInputType.Inventory;
			}
		}
	}

	private void i(object A_0, RoutedEventArgs A_1)
	{
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Enter choice:";
		((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
		bool? flag = ((Window)getNameWindow).ShowDialog();
		if (flag == true && flag.HasValue && getNameWindow.b.Text != string.Empty)
		{
			((ItemsControl)lbActionCustomChoices).Items.Add((object)getNameWindow.txtEntry.Text);
			s()?.CustomChoices.Add(getNameWindow.txtEntry.Text);
		}
	}

	private void h(object A_0, RoutedEventArgs A_1)
	{
		if (((Selector)lbActionCustomChoices).SelectedIndex <= -1)
		{
			return;
		}
		int selectedIndex = ((Selector)lbActionCustomChoices).SelectedIndex;
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Update Custom Choice:";
		((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
		getNameWindow.txtEntry.Text = ((Selector)lbActionCustomChoices).SelectedItem.ToString();
		bool? flag = ((Window)getNameWindow).ShowDialog();
		if (flag == true && flag.HasValue && getNameWindow.txtEntry.Text.Trim() != string.Empty)
		{
			Rags.Action action = s();
			if (action != null)
			{
				action.CustomChoices.RemoveAt(selectedIndex);
				action.CustomChoices.Insert(selectedIndex, getNameWindow.txtEntry.Text);
			}
			r();
		}
	}

	private void g(object A_0, RoutedEventArgs A_1)
	{
		for (int num = lbActionCustomChoices.SelectedItems.Count - 1; num >= 0; num--)
		{
			string text = lbActionCustomChoices.SelectedItems[num].ToString();
			s()?.CustomChoices.Remove(text);
			((ItemsControl)lbActionCustomChoices).Items.Remove((object)text);
		}
	}

	private void f(object A_0, RoutedEventArgs A_1)
	{
		Rags.Action action = s();
		if (action != null)
		{
			action.CustomChoiceTitle = tbCustomChoiceTitle.Text;
		}
	}

	private void e(object A_0, RoutedEventArgs A_1)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Enter Choice:";
		((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
		bool? flag = ((Window)getNameWindow).ShowDialog();
		if (flag != true || !flag.HasValue || !(getNameWindow.txtEntry.Text.Trim() != string.Empty) || !(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command command))
		{
			return;
		}
		if (command.cmdtype == Command.CommandType.CT_SETVARIABLE_NUMERIC_BYINPUT)
		{
			try
			{
				Convert.ToDouble(getNameWindow.txtEntry.Text);
				((ItemsControl)lbCustomChoices).Items.Add((object)getNameWindow.txtEntry.Text);
				command.CustomChoices.Add(getNameWindow.txtEntry.Text);
				return;
			}
			catch
			{
				MessageBox.Show("Sorry, you must enter a valid number.");
				return;
			}
		}
		((ItemsControl)lbCustomChoices).Items.Add((object)getNameWindow.txtEntry.Text);
		command.CustomChoices.Add(getNameWindow.txtEntry.Text);
	}

	private void d(object A_0, RoutedEventArgs A_1)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		if (((Selector)lbCustomChoices).SelectedIndex <= -1)
		{
			return;
		}
		int selectedIndex = ((Selector)lbCustomChoices).SelectedIndex;
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Update Custom Choice:";
		((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
		getNameWindow.txtEntry.Text = ((Selector)lbCustomChoices).SelectedItem.ToString();
		bool? flag = ((Window)getNameWindow).ShowDialog();
		if (flag == true && flag.HasValue && getNameWindow.txtEntry.Text.Trim() != string.Empty)
		{
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command command)
			{
				command.CustomChoices.RemoveAt(selectedIndex);
				command.CustomChoices.Insert(selectedIndex, getNameWindow.txtEntry.Text);
			}
			r();
		}
	}

	private void c(object A_0, RoutedEventArgs A_1)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		for (int num = lbCustomChoices.SelectedItems.Count - 1; num >= 0; num--)
		{
			string text = lbCustomChoices.SelectedItems[num].ToString();
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command command)
			{
				command.CustomChoices.Remove(text);
			}
			((ItemsControl)lbCustomChoices).Items.Remove((object)text);
		}
	}

	private void b(object A_0, RoutedEventArgs A_1)
	{
	}

	private void a(object A_0, RoutedEventArgs A_1)
	{
		Condition condition = q();
		if (condition != null)
		{
			Check check = condition.Checks[((Selector)lbChecks).SelectedIndex];
			if (check != null)
			{
				condition.Checks.Remove(check);
				a(q());
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Obj, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected Obj, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected Obj, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected Obj, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected Obj, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Obj, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected Obj, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected Obj, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Obj, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected Obj, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected Obj, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected Obj, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected Obj, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected Obj, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected Obj, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected Obj, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected Obj, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected Obj, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected Obj, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected Obj, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected Obj, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected Obj, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected Obj, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected Obj, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected Obj, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected Obj, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected Obj, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected Obj, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected Obj, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected Obj, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected Obj, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected Obj, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected Obj, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected Obj, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected Obj, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected Obj, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected Obj, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected Obj, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected Obj, but got Unknown
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Expected Obj, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected Obj, but got Unknown
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected Obj, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected Obj, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Expected Obj, but got Unknown
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Expected Obj, but got Unknown
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Expected Obj, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected Obj, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected Obj, but got Unknown
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected Obj, but got Unknown
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected Obj, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected Obj, but got Unknown
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Expected Obj, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected Obj, but got Unknown
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Expected Obj, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected Obj, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055d: Expected Obj, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected Obj, but got Unknown
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected Obj, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected Obj, but got Unknown
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Expected Obj, but got Unknown
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Expected Obj, but got Unknown
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Expected Obj, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected Obj, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Expected Obj, but got Unknown
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected Obj, but got Unknown
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected Obj, but got Unknown
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Expected Obj, but got Unknown
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Expected Obj, but got Unknown
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Expected Obj, but got Unknown
		//IL_066d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Expected Obj, but got Unknown
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Expected Obj, but got Unknown
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Expected Obj, but got Unknown
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b2: Expected Obj, but got Unknown
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Expected Obj, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Expected Obj, but got Unknown
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected Obj, but got Unknown
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected Obj, but got Unknown
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Expected Obj, but got Unknown
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Expected Obj, but got Unknown
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_072b: Expected Obj, but got Unknown
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Expected Obj, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Expected Obj, but got Unknown
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Expected Obj, but got Unknown
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Expected Obj, but got Unknown
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Expected Obj, but got Unknown
		//IL_0783: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Expected Obj, but got Unknown
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a4: Expected Obj, but got Unknown
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected Obj, but got Unknown
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected Obj, but got Unknown
		//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ec: Expected Obj, but got Unknown
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Expected Obj, but got Unknown
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_0812: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Expected Obj, but got Unknown
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0829: Expected Obj, but got Unknown
		//IL_082c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0836: Expected Obj, but got Unknown
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Expected Obj, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected Obj, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Expected Obj, but got Unknown
		//IL_0874: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Expected Obj, but got Unknown
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0895: Expected Obj, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ac: Expected Obj, but got Unknown
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected Obj, but got Unknown
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Expected Obj, but got Unknown
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Expected Obj, but got Unknown
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Expected Obj, but got Unknown
		//IL_0901: Unknown result type (might be due to invalid IL or missing references)
		//IL_090b: Expected Obj, but got Unknown
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Expected Obj, but got Unknown
		//IL_092f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0939: Expected Obj, but got Unknown
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Expected Obj, but got Unknown
		//IL_0953: Unknown result type (might be due to invalid IL or missing references)
		//IL_095d: Expected Obj, but got Unknown
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_096a: Expected Obj, but got Unknown
		//IL_0977: Unknown result type (might be due to invalid IL or missing references)
		//IL_0981: Expected Obj, but got Unknown
		//IL_098e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0998: Expected Obj, but got Unknown
		//IL_09a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Expected Obj, but got Unknown
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bc: Expected Obj, but got Unknown
		//IL_09c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d3: Expected Obj, but got Unknown
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ea: Expected Obj, but got Unknown
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Expected Obj, but got Unknown
		switch (connectionId)
		{
		case 1:
			TreeControl = (Grid)target;
			break;
		case 2:
			tvActionsConditions = (TreeView)target;
			tvActionsConditions.SelectedItemChanged += a;
			((UIElement)tvActionsConditions).MouseLeftButtonDown += b;
			((UIElement)tvActionsConditions).MouseRightButtonDown += a;
			((UIElement)tvActionsConditions).MouseMove += a;
			((UIElement)tvActionsConditions).Drop += a;
			((UIElement)tvActionsConditions).KeyDown += b;
			break;
		case 3:
			gbActionAttributes = (GroupBox)target;
			break;
		case 4:
			tbActionNameOverride = (TextBox)target;
			((Control)tbActionNameOverride).MouseDoubleClick += c;
			((UIElement)tbActionNameOverride).LostFocus += o;
			break;
		case 5:
			cbActionActive = (CheckBox)target;
			((UIElement)cbActionActive).LostFocus += p;
			break;
		case 6:
			cbActionParent = (ComboBox)target;
			((Selector)cbActionParent).SelectionChanged += a;
			break;
		case 7:
			gbCondBehavior = (GroupBox)target;
			((UIElement)gbCondBehavior).LostFocus += n;
			break;
		case 8:
			rbFailOnFirst = (RadioButton)target;
			break;
		case 9:
			rbRunAll = (RadioButton)target;
			break;
		case 10:
			gbAddInput = (GroupBox)target;
			((UIElement)gbAddInput).LostFocus += j;
			break;
		case 11:
			rbaddinputnone = (RadioButton)target;
			((ButtonBase)rbaddinputnone).Click += k;
			break;
		case 12:
			rbaddinputObject = (RadioButton)target;
			((ButtonBase)rbaddinputObject).Click += l;
			break;
		case 13:
			rbaddinputCharacter = (RadioButton)target;
			((ButtonBase)rbaddinputCharacter).Click += l;
			break;
		case 14:
			rbaddinputText = (RadioButton)target;
			((ButtonBase)rbaddinputText).Click += l;
			break;
		case 15:
			rbaddinputObjectorCharacter = (RadioButton)target;
			((ButtonBase)rbaddinputObjectorCharacter).Click += l;
			break;
		case 16:
			rbaddinputCustom = (RadioButton)target;
			((ButtonBase)rbaddinputCustom).Click += m;
			break;
		case 17:
			rbAddInputInventory = (RadioButton)target;
			((ButtonBase)rbAddInputInventory).Click += l;
			break;
		case 18:
			btnAdvancedOptions = (Button)target;
			break;
		case 19:
			gbCustomChoices = (GroupBox)target;
			break;
		case 20:
			tbCustomChoiceTitle = (TextBox)target;
			((UIElement)tbCustomChoiceTitle).LostFocus += f;
			break;
		case 21:
			lbActionCustomChoices = (ListBox)target;
			break;
		case 22:
			btnActionCustomAdd = (Button)target;
			((ButtonBase)btnActionCustomAdd).Click += i;
			break;
		case 23:
			btnActionCustomUpdate = (Button)target;
			((ButtonBase)btnActionCustomUpdate).Click += h;
			break;
		case 24:
			btnActionCustomDelete = (Button)target;
			((ButtonBase)btnActionCustomDelete).Click += g;
			break;
		case 25:
			gbCommands = (GroupBox)target;
			break;
		case 26:
			grdCommandGrid = (Grid)target;
			break;
		case 27:
			grdCommandSteps = (Grid)target;
			break;
		case 28:
			cbCommandStep1 = (ComboBox)target;
			((Selector)cbCommandStep1).SelectionChanged += h;
			((UIElement)cbCommandStep1).LostFocus += v;
			break;
		case 29:
			lblCommandStep2 = (Label)target;
			((UIElement)lblCommandStep2).KeyDown += a;
			break;
		case 30:
			cbCommandStep2 = (ComboBox)target;
			((Selector)cbCommandStep2).SelectionChanged += g;
			((Control)cbCommandStep2).MouseDoubleClick += c;
			((UIElement)cbCommandStep2).LostFocus += ac;
			break;
		case 31:
			lblCommandStep3 = (Label)target;
			break;
		case 32:
			lblCommandText = (Label)target;
			break;
		case 33:
			cbCommandStep3 = (ComboBox)target;
			((UIElement)cbCommandStep3).KeyDown += a;
			((UIElement)cbCommandStep3).LostFocus += ae;
			((Selector)cbCommandStep3).SelectionChanged += f;
			((Control)cbCommandStep3).MouseDoubleClick += c;
			break;
		case 34:
			txtCommandText = (TextBox)target;
			((Control)txtCommandText).MouseDoubleClick += c;
			((UIElement)txtCommandText).LostFocus += s;
			((UIElement)txtCommandText).KeyDown += a;
			break;
		case 35:
			lblCommandStep4 = (Label)target;
			break;
		case 36:
			cbCommandStep4 = (ComboBox)target;
			((Control)cbCommandStep4).MouseDoubleClick += c;
			((UIElement)cbCommandStep4).LostFocus += r;
			((UIElement)cbCommandStep4).KeyDown += a;
			break;
		case 37:
			txtStep4 = (TextBox)target;
			((UIElement)txtStep4).LostFocus += ad;
			((Control)txtStep4).MouseDoubleClick += c;
			((UIElement)txtStep4).KeyDown += a;
			break;
		case 38:
			gbCommandChoices = (GroupBox)target;
			break;
		case 39:
			lbCustomChoices = (ListBox)target;
			break;
		case 40:
			CmdAddCustomChoice = (Button)target;
			((ButtonBase)CmdAddCustomChoice).Click += e;
			break;
		case 41:
			CmdUpdateCustomChoice = (Button)target;
			((ButtonBase)CmdUpdateCustomChoice).Click += d;
			break;
		case 42:
			CmdDelCustomChoice = (Button)target;
			((ButtonBase)CmdDelCustomChoice).Click += c;
			break;
		case 43:
			CmdAdvCustomChoice = (Button)target;
			((ButtonBase)CmdAdvCustomChoice).Click += b;
			break;
		case 44:
			gbConditionData = (GroupBox)target;
			break;
		case 45:
			txtConditionName = (TextBox)target;
			((UIElement)txtConditionName).LostFocus += q;
			break;
		case 46:
			lbChecks = (ListBox)target;
			((Selector)lbChecks).SelectionChanged += e;
			break;
		case 47:
			((ButtonBase)(Button)target).Click += u;
			break;
		case 48:
			((ButtonBase)(Button)target).Click += t;
			break;
		case 49:
			((ButtonBase)(Button)target).Click += a;
			break;
		case 50:
			((ButtonBase)(Button)target).Click += u;
			break;
		case 51:
			((ButtonBase)(Button)target).Click += t;
			break;
		case 52:
			lblConditionStep1 = (Label)target;
			break;
		case 53:
			cbConditionStep1 = (ComboBox)target;
			((Selector)cbConditionStep1).SelectionChanged += d;
			((UIElement)cbConditionStep1).LostFocus += z;
			break;
		case 54:
			lblConditionStep2 = (Label)target;
			break;
		case 55:
			cbConditionStep2 = (ComboBox)target;
			((UIElement)cbConditionStep2).KeyDown += a;
			((Control)cbConditionStep2).MouseDoubleClick += c;
			((Selector)cbConditionStep2).SelectionChanged += c;
			((UIElement)cbConditionStep2).LostFocus += y;
			break;
		case 56:
			lblConditionStep3 = (Label)target;
			break;
		case 57:
			cbConditionStep3 = (ComboBox)target;
			((UIElement)cbConditionStep3).KeyDown += a;
			((Control)cbConditionStep3).MouseDoubleClick += c;
			((Selector)cbConditionStep3).SelectionChanged += b;
			((UIElement)cbConditionStep3).LostFocus += x;
			break;
		case 58:
			lblConditionStep4 = (Label)target;
			break;
		case 59:
			cbConditionStep4 = (ComboBox)target;
			((UIElement)cbConditionStep4).KeyDown += a;
			((Control)cbConditionStep4).MouseDoubleClick += c;
			((UIElement)cbConditionStep4).LostFocus += ab;
			break;
		case 60:
			txtConditionStep4 = (TextBox)target;
			((UIElement)txtConditionStep4).KeyDown += a;
			((Control)txtConditionStep4).MouseDoubleClick += c;
			((UIElement)txtConditionStep4).LostFocus += aa;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
