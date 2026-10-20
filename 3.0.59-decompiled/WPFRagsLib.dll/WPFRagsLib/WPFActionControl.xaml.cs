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
		List<Rags.Action> actionList = GetActionList();
		if (actionList != null)
		{
			for (int i = 0; i < actionList.Count; i++)
			{
				Rags.Action tempact = actionList[i];
				AddActionToTreeNode(tempact, -1, bSelect: false);
			}
			RefreshActionPage();
		}
	}

	private Rags.Action GetAction()
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

	private void RefreshActionPage()
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
			if (IsAction() && !(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition))
			{
				Rags.Action action = GetAction();
				tbCustomChoiceTitle.Text = action.CustomChoiceTitle;
				tbActionNameOverride.Text = action.overridename;
				PopulateActionParent();
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
				Condition condition = GetCondition();
				if (condition != null)
				{
					RefreshConditionChecks(condition);
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
			cbCommandStep1_SelectionChanged(null, null);
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

	private void RefreshConditionChecks(Condition tempcond)
	{
		((ItemsControl)lbChecks).Items.Clear();
		foreach (Check check in tempcond.Checks)
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

	private Condition GetCondition()
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

	private void PopulateActionParent()
	{
		Rags.Action action = GetAction();
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
		List<Rags.Action> actionList = GetActionList();
		for (int i = 0; i < actionList.Count; i++)
		{
			Rags.Action action2 = actionList[i];
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

	private bool IsAction()
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

	private void AddActionToTreeNode(Rags.Action tempact, int position, bool bSelect)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		if (tempact == null)
		{
			return;
		}
		TreeViewItem val = new TreeViewItem();
		((HeaderedItemsControl)val).Header = CreateTreeViewHeader(tempact.name, "pack://application:,,/Images/run.png");
		((FrameworkElement)val).Tag = tempact;
		for (int i = 0; i < tempact.Conditions.Count; i++)
		{
			AddConditionToTreeNode(tempact.Conditions[i], val, -1);
		}
		TreeViewItem val2 = new TreeViewItem();
		((HeaderedItemsControl)val2).Header = CreateTreeViewHeader("Commands on Success", "pack://application:,,/Images/Green.png");
		((ItemsControl)val).Items.Add((object)val2);
		TreeViewItem val3 = new TreeViewItem();
		((HeaderedItemsControl)val3).Header = CreateTreeViewHeader("Commands on Failure", "pack://application:,,/Images/Red.png");
		((ItemsControl)val).Items.Add((object)val3);
		for (int j = 0; j < tempact.PassCommands.Count; j++)
		{
			Command command = tempact.PassCommands[j] as Command;
			Condition condition = tempact.PassCommands[j] as Condition;
			if (command != null)
			{
				AddCommandToTreeNode(command, val2);
			}
			else if (condition != null)
			{
				AddConditionToTreeNode(condition, val2, -1);
			}
		}
		for (int k = 0; k < tempact.FailCommands.Count; k++)
		{
			Command command2 = tempact.FailCommands[k] as Command;
			Condition condition2 = tempact.FailCommands[k] as Condition;
			if (command2 != null)
			{
				AddCommandToTreeNode(command2, val3);
			}
			else if (condition2 != null)
			{
				AddConditionToTreeNode(condition2, val3, -1);
			}
		}
		if (position == -1)
		{
			((ItemsControl)tvActionsConditions).Items.Add((object)val);
		}
		else
		{
			((ItemsControl)tvActionsConditions).Items.Insert(position, (object)val);
		}
	}

	private string SetCommandNodeText(Command cm)
	{
		string text = string.Empty;
		if (cm != null)
		{
			text = SaveLoad.GetCommandName(cm.cmdtype);
			if (cm.CommandPart2 != string.Empty)
			{
				try
				{
					Guid guid = new Guid(cm.CommandPart2);
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
					text = text + ": " + cm.CommandPart2;
				}
			}
			if (cm.CommandPart3 != string.Empty)
			{
				try
				{
					Guid guid2 = new Guid(cm.CommandPart3);
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
					text = text + ", " + cm.CommandPart3;
				}
			}
			if (cm.CommandPart4 != string.Empty)
			{
				try
				{
					Guid guid3 = new Guid(cm.CommandPart4);
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
					text = text + ", " + cm.CommandPart4;
				}
			}
			if (cm.CommandText != string.Empty)
			{
				text = ((cm.CommandText.Length <= 20) ? (text + ", " + cm.CommandText) : (text + ", " + cm.CommandText.Substring(0, 20) + "..."));
			}
		}
		return text;
	}

	private void AddCommandToTreeNode(Command cmd, TreeViewItem parent)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		TreeViewItem val = new TreeViewItem();
		((HeaderedItemsControl)val).Header = CreateTreeViewHeader(SetCommandNodeText(cmd), "pack://application:,,/Images/command.png");
		((FrameworkElement)val).Tag = cmd;
		((ItemsControl)parent).Items.Add((object)val);
	}

	private StackPanel CreateTreeViewHeader(string name, string imageuri)
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
		val2.Source = (ImageSource)new BitmapImage(new Uri(imageuri));
		((FrameworkElement)val2).Width = 16.0;
		((FrameworkElement)val2).Height = 16.0;
		Label val3 = new Label();
		((ContentControl)val3).Content = name;
		((FrameworkElement)val3).VerticalAlignment = (VerticalAlignment)1;
		((FrameworkElement)val2).VerticalAlignment = (VerticalAlignment)1;
		((Control)val3).FontSize = 9.0;
		((Panel)val).Children.Add((UIElement)(object)val2);
		((Panel)val).Children.Add((UIElement)(object)val3);
		return val;
	}

	private void AddConditionToTreeNode(Condition cond, TreeViewItem ActionNode, int position)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		TreeViewItem val = new TreeViewItem();
		((FrameworkElement)val).Tag = cond;
		((HeaderedItemsControl)val).Header = CreateTreeViewHeader(cond.conditionname, "pack://application:,,/Images/Question.png");
		((FrameworkElement)val).Tag = cond;
		TreeViewItem val2 = new TreeViewItem();
		((HeaderedItemsControl)val2).Header = CreateTreeViewHeader("Commands on Success", "pack://application:,,/Images/Green.png");
		((ItemsControl)val).Items.Add((object)val2);
		TreeViewItem val3 = new TreeViewItem();
		((HeaderedItemsControl)val3).Header = CreateTreeViewHeader("Commands on Failure", "pack://application:,,/Images/Red.png");
		((ItemsControl)val).Items.Add((object)val3);
		for (int i = 0; i < cond.PassCommands.Count; i++)
		{
			if (cond.PassCommands[i] is Command cmd)
			{
				AddCommandToTreeNode(cmd, val2);
			}
			else if (cond.PassCommands[i] is Condition cond2)
			{
				AddConditionToTreeNode(cond2, val2, -1);
			}
		}
		for (int j = 0; j < cond.FailCommands.Count; j++)
		{
			if (cond.FailCommands[j] is Command cmd2)
			{
				AddCommandToTreeNode(cmd2, val3);
			}
			else if (cond.FailCommands[j] is Condition cond3)
			{
				AddConditionToTreeNode(cond3, val3, -1);
			}
		}
		if (position == -1)
		{
			((ItemsControl)ActionNode).Items.Add((object)val);
		}
		else
		{
			((ItemsControl)ActionNode).Items.Insert(position, (object)val);
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

	private List<Rags.Action> GetActionList()
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

	private void cbCommandStep1_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		Command commandNodeText = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Command;
		SetCommandDisplay();
		if (tvActionsConditions.SelectedItem != null)
		{
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(SetCommandNodeText(commandNodeText), "pack://application:,,/Images/command.png");
		}
	}

	private void PopulateComboWithWearableItems(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bWearable)
			{
				GameObject gameObject = TheGame.ObjectList[i];
				((ItemsControl)cb).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void PopulateComboWithPictures(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.PictureList.Count; i++)
		{
			((ItemsControl)cb).Items.Add((object)TheGame.PictureList[i].TheName);
		}
	}

	private void PopulateComboWithMultimediaGroups(ref ComboBox cb)
	{
		try
		{
			((ItemsControl)cb).Items.Clear();
			SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from MediaGroups", dBConnection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				((ItemsControl)cb).Items.Add((object)sqlCeDataReader["Name"].ToString());
			}
		}
		catch
		{
		}
	}

	private void PopulateComboWithItemGroups(ref ComboBox cb)
	{
		try
		{
			((ItemsControl)cb).Items.Clear();
			SqlCeConnection dBConnection = SaveLoad.GetDBConnection();
			SqlCeCommand sqlCeCommand = new SqlCeCommand("select Name from ItemGroups", dBConnection);
			SqlCeDataReader sqlCeDataReader = sqlCeCommand.ExecuteReader();
			while (sqlCeDataReader.Read())
			{
				((ItemsControl)cb).Items.Add((object)sqlCeDataReader["Name"].ToString());
			}
		}
		catch
		{
		}
	}

	private void PopulateComboWithItems(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			GameObject gameObject = TheGame.ObjectList[i];
			((ItemsControl)cb).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
	}

	private void PopulateComboWithContainerItems(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (@object.bContainer)
			{
				((ItemsControl)cb).Items.Add((object)new RoomComboItem(@object.UniqueIdentifier, @object.name));
			}
		}
	}

	private void PopulateComboWithItemsAndCharacters(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			GameObject gameObject = TheGame.ObjectList[i];
			((ItemsControl)cb).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
		}
		for (int j = 0; j < TheGame.CharacterList.Count; j++)
		{
			((ItemsControl)cb).Items.Add((object)TheGame.CharacterList[j].Charname);
		}
	}

	private void PopulateComboWithCarryableItems(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bCarryable)
			{
				((ItemsControl)cb).Items.Add((object)new RoomComboItem(TheGame.ObjectList[i].UniqueIdentifier, TheGame.ObjectList[i].name));
			}
		}
	}

	private void PopulateComboWithPlainDirections(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		((ItemsControl)cb).Items.Add((object)"North");
		((ItemsControl)cb).Items.Add((object)"South");
		((ItemsControl)cb).Items.Add((object)"East");
		((ItemsControl)cb).Items.Add((object)"West");
		((ItemsControl)cb).Items.Add((object)"Up");
		((ItemsControl)cb).Items.Add((object)"Down");
		((ItemsControl)cb).Items.Add((object)"NorthEast");
		((ItemsControl)cb).Items.Add((object)"NorthWest");
		((ItemsControl)cb).Items.Add((object)"SouthEast");
		((ItemsControl)cb).Items.Add((object)"SouthWest");
		((ItemsControl)cb).Items.Add((object)"In");
		((ItemsControl)cb).Items.Add((object)"Out");
	}

	private void PopulateComboWithRooms(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
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
			((ItemsControl)cb).Items.Add((object)roomComboItem);
		}
	}

	private void PopulateComboWithRoomGroups(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		foreach (string roomGroup in TheGame.RoomGroups)
		{
			((ItemsControl)cb).Items.Add((object)roomGroup);
		}
	}

	private void PopulateComboWithRoomCustomProperties(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
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
					((ItemsControl)cb).Items.Add((object)("<CurrentRoom>:" + customProperty.Name));
					num++;
				}
			}
			foreach (CustomProperty customProperty2 in room.CustomProperties)
			{
				((ItemsControl)cb).Items.Add((object)(room.Name + ":" + customProperty2.Name));
			}
		}
	}

	private void PopulateComboWithCharCustomProperties(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		if (TheGame.CharacterList.Count <= 0)
		{
			return;
		}
		foreach (Character character in TheGame.CharacterList)
		{
			foreach (CustomProperty customProperty in character.CustomProperties)
			{
				((ItemsControl)cb).Items.Add((object)(character.Charname + ":" + customProperty.Name));
			}
		}
	}

	private void PopulateComboWithTimerCustomProperties(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		if (TheGame.TimerList.Count <= 0)
		{
			return;
		}
		foreach (Timer timer in TheGame.TimerList)
		{
			foreach (CustomProperty customProperty in timer.CustomProperties)
			{
				((ItemsControl)cb).Items.Add((object)(timer.Name + ":" + customProperty.Name));
			}
		}
	}

	private void PopulateComboWithVariableCustomProperties(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		if (TheGame.VariableList.Count <= 0)
		{
			return;
		}
		foreach (GameVariable variable in TheGame.VariableList)
		{
			foreach (CustomProperty customProperty in variable.CustomProperties)
			{
				((ItemsControl)cb).Items.Add((object)(variable.varname + ":" + customProperty.Name));
			}
		}
	}

	private void PopulateComboWithItemCustomProperties(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
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
					((ItemsControl)cb).Items.Add((object)("<Self>:" + customProperty.Name));
					num++;
				}
			}
			foreach (CustomProperty customProperty2 in @object.CustomProperties)
			{
				((ItemsControl)cb).Items.Add((object)(@object.name + ":" + customProperty2.Name));
			}
		}
	}

	private void PopulateComboWithPlayerCustomProperties(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		foreach (CustomProperty customProperty in TheGame.ThePlayer.CustomProperties)
		{
			((ItemsControl)cb).Items.Add((object)customProperty.Name);
		}
	}

	private void PopulateComboWithVariables(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						((ItemsControl)cb).Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)cb).Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
			else
			{
				((ItemsControl)cb).Items.Add((object)gameVariable.varname);
			}
		}
	}

	private void PopulateComboWithVariablesNoArray(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			((ItemsControl)cb).Items.Add((object)gameVariable.varname);
		}
	}

	private void PopulateComboWithMDAVariables(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.VarArray != null && gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				((ItemsControl)cb).Items.Add((object)gameVariable.varname);
			}
		}
	}

	private void PopulateComboWithNumericAndDateTimeVariables(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		foreach (GameVariable variable in TheGame.VariableList)
		{
			if (variable.vartype == GameVariable.VarType.VT_DATETIME || variable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				((ItemsControl)cb).Items.Add((object)variable.varname);
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
						((ItemsControl)cb).Items.Add((object)(variable.varname + "(" + i + ")(0.." + (((ArrayList)variable.VarArray[i]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)cb).Items.Add((object)(variable.varname + "(" + i + ")"));
					}
				}
			}
		}
	}

	private void PopulateComboWithNumericAndStringVariables(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		foreach (GameVariable variable in TheGame.VariableList)
		{
			if (variable.vartype == GameVariable.VarType.VT_STRING || variable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				((ItemsControl)cb).Items.Add((object)variable.varname);
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
						((ItemsControl)cb).Items.Add((object)(variable.varname + "(" + i + ")(0.." + (((ArrayList)variable.VarArray[i]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)cb).Items.Add((object)(variable.varname + "(" + i + ")"));
					}
				}
			}
		}
	}

	private void PopulateComboWithTextVariables(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_STRING)
			{
				((ItemsControl)cb).Items.Add((object)gameVariable.varname);
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
						((ItemsControl)cb).Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)cb).Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
		}
	}

	private void PopulateComboWithNumericVariables(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_NUMBER)
			{
				((ItemsControl)cb).Items.Add((object)gameVariable.varname);
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
						((ItemsControl)cb).Items.Add((object)(gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")"));
					}
					else
					{
						((ItemsControl)cb).Items.Add((object)(gameVariable.varname + "(" + j + ")"));
					}
				}
			}
		}
	}

	private void PopulateComboWithCustomCommands(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
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
					((ItemsControl)cb).Items.Add((object)("Obj:" + @object.name + ":" + action2.name));
				}
			}
		}
		foreach (Rags.Action action3 in TheGame.ThePlayer.Actions)
		{
			if (action3.InputType == Rags.Action.ActionInputType.Custom)
			{
				((ItemsControl)cb).Items.Add((object)("Player:" + action3.name));
			}
		}
		foreach (Room room in TheGame.RoomList)
		{
			foreach (Rags.Action action4 in room.Actions)
			{
				if (action4.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)cb).Items.Add((object)("Room:" + room.Name + ":" + action4.name));
				}
			}
		}
	}

	private void PopulateComboWithCustomActions(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		foreach (Character character in TheGame.CharacterList)
		{
			foreach (Rags.Action action in character.Actions)
			{
				if (action.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)cb).Items.Add((object)("Chr:" + character.Charname + ":" + action.name));
				}
			}
		}
		foreach (GameObject @object in TheGame.ObjectList)
		{
			foreach (Rags.Action action2 in @object.Actions)
			{
				if (action2.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)cb).Items.Add((object)("Obj:" + @object.name + ":" + action2.name));
				}
			}
		}
		foreach (Rags.Action action3 in TheGame.ThePlayer.Actions)
		{
			if (action3.InputType == Rags.Action.ActionInputType.Custom)
			{
				((ItemsControl)cb).Items.Add((object)("Player:" + action3.name));
			}
		}
		foreach (Room room in TheGame.RoomList)
		{
			foreach (Rags.Action action4 in room.Actions)
			{
				if (action4.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)cb).Items.Add((object)("Room:" + room.Name + ":" + action4.name));
				}
			}
		}
		foreach (Timer timer in TheGame.TimerList)
		{
			foreach (Rags.Action action5 in timer.Actions)
			{
				if (action5.InputType == Rags.Action.ActionInputType.Custom)
				{
					((ItemsControl)cb).Items.Add((object)("Timer:" + timer.Name + ":" + action5.name));
				}
			}
		}
	}

	private void PopulateComboWithCharacters(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.CharacterList.Count; i++)
		{
			((ItemsControl)cb).Items.Add((object)TheGame.CharacterList[i].Charname);
		}
	}

	private void PopulateComboWithTimers(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.TimerList.Count; i++)
		{
			((ItemsControl)cb).Items.Add((object)TheGame.TimerList[i].Name);
		}
	}

	private void PopulateComboWithLockableItems(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bLockable)
			{
				GameObject gameObject = TheGame.ObjectList[i];
				((ItemsControl)cb).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void PopulateComboWithOpenableItems(ref ComboBox cb)
	{
		((ItemsControl)cb).Items.Clear();
		for (int i = 0; i < TheGame.ObjectList.Count; i++)
		{
			if (TheGame.ObjectList[i].bOpenable)
			{
				GameObject gameObject = TheGame.ObjectList[i];
				((ItemsControl)cb).Items.Add((object)new RoomComboItem(gameObject.UniqueIdentifier, gameObject.name));
			}
		}
	}

	private void PopulateComboWithDirections(ref ComboBox cb, Guid roomid)
	{
		((ItemsControl)cb).Items.Clear();
		Room roomByID = TheGame.GetRoomByID(roomid);
		if (roomByID == null)
		{
			return;
		}
		foreach (Exit exit in roomByID.Exits)
		{
			if (exit.DestinationRoom != string.Empty)
			{
				((ItemsControl)cb).Items.Add((object)(exit.Direction.ToString() + "-Active-To:" + TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
				((ItemsControl)cb).Items.Add((object)(exit.Direction.ToString() + "-InActive-To:" + TheGame.GetRoomByID(new Guid(exit.DestinationRoom)).Name));
			}
		}
	}

	private void SetCommandDisplay()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_221d: Unknown result type (might be due to invalid IL or missing references)
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
			PopulateComboWithTextVariables(ref cbCommandStep2);
			((UIElement)lblCommandStep3).Visibility = (Visibility)0;
			((UIElement)cbCommandStep3).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep3).Content = "Select Item Group:";
			PopulateComboWithItemGroups(ref cbCommandStep3);
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
			PopulateComboWithTextVariables(ref cbCommandStep2);
			PopulateComboWithMultimediaGroups(ref cbCommandStep3);
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
			PopulateComboWithCustomActions(ref cbCommandStep2);
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
			PopulateComboWithCustomActions(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
			PopulateComboWithPictures(ref cbCommandStep3);
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
			PopulateComboWithPictures(ref cbCommandStep2);
			PopulateComboWithPictures(ref cbCommandStep3);
			PopulateComboWithPictures(ref cbCommandStep4);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
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
			PopulateComboWithWearableItems(ref cbCommandStep2);
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
			PopulateComboWithWearableItems(ref cbCommandStep2);
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
			PopulateComboWithContainerItems(ref cbCommandStep2);
			PopulateComboWithContainerItems(ref cbCommandStep3);
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
			PopulateComboWithNumericVariables(ref cbCommandStep2);
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
			PopulateComboWithCustomActions(ref cbCommandStep2);
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
			PopulateComboWithMDAVariables(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithRooms(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
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
			PopulateComboWithTimers(ref cbCommandStep2);
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
			PopulateComboWithTimers(ref cbCommandStep2);
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
			PopulateComboWithTimers(ref cbCommandStep2);
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
			PopulateComboWithTextVariables(ref cbCommandStep3);
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
			PopulateComboWithNumericVariables(ref cbCommandStep3);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithRooms(ref cbCommandStep2);
			RoomComboItem roomComboItem9 = new RoomComboItem();
			roomComboItem9.UniqueID = Room.CurrentRoomGuid;
			roomComboItem9.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem9);
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
			PopulateComboWithRooms(ref cbCommandStep2);
			RoomComboItem roomComboItem10 = new RoomComboItem();
			roomComboItem10.UniqueID = Room.CurrentRoomGuid;
			roomComboItem10.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem10);
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
			PopulateComboWithRooms(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
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
			PopulateComboWithNumericAndStringVariables(ref cbCommandStep2);
			PopulateComboWithRoomCustomProperties(ref cbCommandStep3);
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
			PopulateComboWithNumericAndStringVariables(ref cbCommandStep2);
			PopulateComboWithCharCustomProperties(ref cbCommandStep3);
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
			PopulateComboWithNumericAndStringVariables(ref cbCommandStep2);
			PopulateComboWithTimerCustomProperties(ref cbCommandStep3);
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
			PopulateComboWithNumericAndStringVariables(ref cbCommandStep2);
			PopulateComboWithVariableCustomProperties(ref cbCommandStep3);
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
			PopulateComboWithNumericAndStringVariables(ref cbCommandStep2);
			PopulateComboWithItemCustomProperties(ref cbCommandStep3);
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
			PopulateComboWithNumericAndStringVariables(ref cbCommandStep2);
			PopulateComboWithPlayerCustomProperties(ref cbCommandStep3);
			break;
		case Command.CommandType.CT_VARIABLE_SET_WITH_VARIABLE:
			((ContentControl)lblCommandStep2).Content = "Variable to set:";
			((ContentControl)lblCommandStep3).Content = "Set Type";
			((UIElement)lblCommandStep2).Visibility = (Visibility)0;
			((UIElement)cbCommandStep2).Visibility = (Visibility)0;
			((ContentControl)lblCommandStep4).Content = "Select Numeric Variable:";
			if (txtStep4.Text.Trim() != "")
			{
				((UIElement)lblCommandStep3).Visibility = (Visibility)0;
				((UIElement)cbCommandStep3).Visibility = (Visibility)0;
				((ContentControl)lblCommandText).Content = "Variable data:";
				((UIElement)lblCommandText).Visibility = (Visibility)1;
				((UIElement)txtCommandText).Visibility = (Visibility)1;
				((UIElement)lblCommandStep4).Visibility = (Visibility)0;
				((UIElement)cbCommandStep4).Visibility = (Visibility)0;
				((UIElement)txtStep4).Visibility = (Visibility)1;
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
			PopulateComboWithNumericAndDateTimeVariables(ref cbCommandStep2);
			PopulateComboWithNumericVariables(ref cbCommandStep4);
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command command)
			{
				cbCommandStep4.Text = command.CommandPart4;
			}
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
			PopulateComboWithVariables(ref cbCommandStep2);
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
			PopulateComboWithRoomCustomProperties(ref cbCommandStep2);
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
			PopulateComboWithTimerCustomProperties(ref cbCommandStep2);
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
			PopulateComboWithVariableCustomProperties(ref cbCommandStep2);
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
			PopulateComboWithCharCustomProperties(ref cbCommandStep2);
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
			PopulateComboWithItemCustomProperties(ref cbCommandStep2);
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
			PopulateComboWithPlayerCustomProperties(ref cbCommandStep2);
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
			PopulateComboWithVariables(ref cbCommandStep2);
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
			PopulateComboWithVariablesNoArray(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
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
			PopulateComboWithCarryableItems(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			PopulateComboWithContainerItems(ref cbCommandStep3);
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
			PopulateComboWithRooms(ref cbCommandStep2);
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
			PopulateComboWithRooms(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			PopulateComboWithRooms(ref cbCommandStep3);
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
			PopulateComboWithItems(ref cbCommandStep2);
			if (ThePageType == PageType.objects)
			{
				((ItemsControl)cbCommandStep2).Items.Insert(0, (object)new RoomComboItem(GameObject.SelfObjectGuid, "<<Self>>"));
			}
			PopulateComboWithCharacters(ref cbCommandStep3);
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
			PopulateComboWithRooms(ref cbCommandStep2);
			((Selector)cbCommandStep2).SelectedIndex = 0;
			PopulateComboWithDirections(ref cbCommandStep3, ((RoomComboItem)((Selector)cbCommandStep2).SelectedItem).UniqueID);
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
			PopulateComboWithRooms(ref cbCommandStep2);
			PopulateComboWithPlainDirections(ref cbCommandStep3);
			PopulateComboWithRooms(ref cbCommandStep4);
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
			PopulateComboWithVariables(ref cbCommandStep2);
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
			PopulateComboWithRooms(ref cbCommandStep2);
			RoomComboItem roomComboItem4 = new RoomComboItem();
			roomComboItem4.UniqueID = Room.CurrentRoomGuid;
			roomComboItem4.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem4);
			PopulateComboWithPictures(ref cbCommandStep3);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
			PopulateComboWithPictures(ref cbCommandStep3);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithRooms(ref cbCommandStep2);
			RoomComboItem roomComboItem3 = new RoomComboItem();
			roomComboItem3.UniqueID = Room.CurrentRoomGuid;
			roomComboItem3.RoomName = "<CurrentRoom>";
			((ItemsControl)cbCommandStep2).Items.Insert(0, (object)roomComboItem3);
			PopulateComboWithPictures(ref cbCommandStep3);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithPictures(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithRooms(ref cbCommandStep2);
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
			PopulateComboWithLockableItems(ref cbCommandStep2);
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
			PopulateComboWithOpenableItems(ref cbCommandStep2);
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
			PopulateComboWithWearableItems(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
			PopulateComboWithRooms(ref cbCommandStep3);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
			PopulateComboWithRooms(ref cbCommandStep3);
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
			PopulateComboWithRooms(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
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
			PopulateComboWithItems(ref cbCommandStep2);
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
			PopulateComboWithCharacters(ref cbCommandStep2);
			PopulateComboWithItems(ref cbCommandStep3);
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
		}
	}

	private void tvActionsConditions_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
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
			else if (IsAction() && !(((FrameworkElement)val).Tag is Condition))
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
			RefreshActionPage();
		}
	}

	private void cbCommandStep2_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
				cbCommandStep3_LostFocus(null, null);
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
			PopulateComboWithDirections(ref cbCommandStep3, ((RoomComboItem)((Selector)cbCommandStep2).SelectedItem).UniqueID);
			break;
		}
		_ = ((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex;
		_ = 87;
		_ = ((CommandConditionComboItem)((Selector)cbCommandStep1).SelectedItem).ctindex;
		_ = 41;
	}

	private void cbCommandStep3_LostFocus(object sender, RoutedEventArgs e)
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
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(SetCommandNodeText(command), "pack://application:,,/Images/command.png");
		}
	}

	private void cbCommandStep3_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
				txtStep4_LostFocus(null, null);
			}
			else
			{
				txtStep4.Text = command.CommandPart4;
			}
		}
	}

	private void txtStep4_LostFocus(object sender, RoutedEventArgs e)
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
		((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(SetCommandNodeText(command), "pack://application:,,/Images/command.png");
		SaveLoad.ValidateText(txtStep4.Text, ref TheGame);
	}

	private void General_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		RagsEditor ragsEditor = new RagsEditor(sender, TheGame);
		Window window = Window.GetWindow((DependencyObject)(object)this);
		((Window)ragsEditor).Owner = window;
		if (sender is TextBox)
		{
			ragsEditor.TBDATA = ((TextBox)sender).Text;
		}
		else if (sender is ComboBox)
		{
			ragsEditor.TBDATA = ((ComboBox)sender).Text;
		}
		((Window)ragsEditor).ShowDialog();
	}

	private void cbCommandStep2_LostFocus(object sender, RoutedEventArgs e)
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
		((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(SetCommandNodeText(command), "pack://application:,,/Images/command.png");
	}

	private void lbChecks_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (((Selector)lbChecks).SelectedIndex <= -1)
		{
			return;
		}
		Condition condition = GetCondition();
		Check check = condition.Checks[((Selector)lbChecks).SelectedIndex];
		if (check == null)
		{
			return;
		}
		((Selector)cbConditionStep1).SelectedItem = SaveLoad.GetConditionItem(((ItemsControl)cbConditionStep1).Items, check.CondType);
		cbConditionStep1_SelectionChanged(null, null);
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

	private void cbConditionStep1_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = GetCondition();
		if (condition != null)
		{
			if (((Selector)cbConditionStep1).SelectedItem != null && (((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_While || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Rooms || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Characters || ((CommandConditionComboItem)((Selector)cbConditionStep1).SelectedItem).cndindex == Condition.ConditionType.CT_Loop_Items) && condition.Checks.Count > 1)
			{
				MessageBox.Show("Sorry, a loop check must be the only check in your condition.");
				((Selector)cbConditionStep1).SelectedItem = SaveLoad.GetConditionItem(((ItemsControl)cbConditionStep1).Items, Condition.ConditionType.CT_Character_In_Room);
			}
			else
			{
				SetConditionDisplay();
			}
		}
	}

	private void cbConditionStep2_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

	private void cbConditionStep3_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
		if (GetCondition().Checks[((Selector)lbChecks).SelectedIndex].ConditionStep4 == string.Empty)
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
			txtConditionStep4.Text = GetCondition().Checks[((Selector)lbChecks).SelectedIndex].ConditionStep4;
		}
		txtConditionStep4_LostFocus(null, null);
	}

	private void cbConditionStep4_LostFocus(object sender, RoutedEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag as Condition;
		if (condition == null)
		{
			condition = ((FrameworkElement)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Tag as Condition;
		}
		GetAction();
		condition.Checks[((Selector)lbChecks).SelectedIndex].ConditionStep4 = cbConditionStep4.Text;
	}

	private void txtConditionStep4_LostFocus(object sender, RoutedEventArgs e)
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

	private void SetConditionDisplay()
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
			PopulateComboWithItems(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Item Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			PopulateComboWithItemGroups(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_MultiMedia_InGroup:
			((ContentControl)lblConditionStep2).Content = "Choose Media:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			PopulateComboWithPictures(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Media Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			PopulateComboWithMultimediaGroups(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_Held_By_Player:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			PopulateComboWithItems(ref cbConditionStep2);
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
			PopulateComboWithCharacters(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			PopulateComboWithRooms(ref cbConditionStep3);
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
			PopulateComboWithCharacters(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Room Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			PopulateComboWithRoomGroups(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Character_Gender:
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			PopulateComboWithCharacters(ref cbConditionStep2);
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
			PopulateComboWithCharacters(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "Choose Carryable Item:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			PopulateComboWithCarryableItems(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_Not_Held_By_Player:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			PopulateComboWithItems(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)1;
			((UIElement)cbConditionStep3).Visibility = (Visibility)1;
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_Not_In_Object:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			PopulateComboWithItems(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep3).Content = "Not Inside object:";
			PopulateComboWithContainerItems(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Item_In_Object:
			((ContentControl)lblConditionStep2).Content = "Choose Item:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			PopulateComboWithItems(ref cbConditionStep2);
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep3).Content = "Inside object:";
			PopulateComboWithContainerItems(ref cbConditionStep3);
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
			PopulateComboWithContainerItems(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Player_In_Same_Room_As:
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep2).Content = "Choose Character:";
			PopulateComboWithCharacters(ref cbConditionStep2);
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
			PopulateComboWithItems(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			PopulateComboWithRooms(ref cbConditionStep3);
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
			PopulateComboWithItems(ref cbConditionStep2);
			((ContentControl)lblConditionStep3).Content = "In Room Group:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			PopulateComboWithRoomGroups(ref cbConditionStep3);
			((UIElement)lblConditionStep4).Visibility = (Visibility)1;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			break;
		case Condition.ConditionType.CT_Player_In_Room:
			((ContentControl)lblConditionStep2).Content = "Choose Room:";
			((UIElement)lblConditionStep2).Visibility = (Visibility)0;
			((UIElement)cbConditionStep2).Visibility = (Visibility)0;
			PopulateComboWithRooms(ref cbConditionStep2);
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
			PopulateComboWithRooms(ref cbConditionStep2);
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
			PopulateComboWithRoomGroups(ref cbConditionStep2);
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
			PopulateComboWithPlainDirections(ref cbConditionStep2);
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
			PopulateComboWithItems(ref cbConditionStep2);
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
			PopulateComboWithItems(ref cbConditionStep2);
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
			PopulateComboWithVariables(ref cbConditionStep2);
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
			PopulateComboWithItemGroups(ref cbConditionStep2);
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
			PopulateComboWithContainerItems(ref cbConditionStep2);
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
			PopulateComboWithRooms(ref cbConditionStep2);
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
			PopulateComboWithCharacters(ref cbConditionStep2);
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
			PopulateComboWithRoomCustomProperties(ref cbConditionStep2);
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
			PopulateComboWithTimerCustomProperties(ref cbConditionStep2);
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
			PopulateComboWithVariableCustomProperties(ref cbConditionStep2);
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
			PopulateComboWithCharCustomProperties(ref cbConditionStep2);
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
			PopulateComboWithItemCustomProperties(ref cbConditionStep2);
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
			PopulateComboWithPlayerCustomProperties(ref cbConditionStep2);
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
			PopulateComboWithVariables(ref cbConditionStep2);
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
			PopulateComboWithNumericAndStringVariables(ref cbConditionStep2);
			PopulateComboWithNumericAndStringVariables(ref cbConditionStep4);
			((ContentControl)lblConditionStep3).Content = "Comparison Type:";
			((UIElement)lblConditionStep3).Visibility = (Visibility)0;
			((UIElement)cbConditionStep3).Visibility = (Visibility)0;
			((ContentControl)lblConditionStep4).Content = "Compared to Variable:";
			((UIElement)lblConditionStep4).Visibility = (Visibility)0;
			((UIElement)txtConditionStep4).Visibility = (Visibility)1;
			((UIElement)cbConditionStep4).Visibility = (Visibility)0;
			break;
		case Condition.ConditionType.CT_AdditionalDataCheck:
			if (GetAction().InputType == Rags.Action.ActionInputType.None)
			{
				if ((int)MessageBox.Show("This action is currently not defined to accept additional input.  Would you like to define the additional input now?", "No Additional Input", (MessageBoxButton)4) != 6)
				{
					if (((CollectionView)((ItemsControl)cbConditionStep1).Items).Count > 0)
					{
						((Selector)cbConditionStep1).SelectedIndex = 0;
					}
					break;
				}
				GetActionNode().IsSelected = true;
				((UIElement)gbAddInput).Focus();
			}
			switch (GetAction().InputType)
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
				PopulateComboWithCharacters(ref cbConditionStep2);
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
				PopulateComboWithItems(ref cbConditionStep2);
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
				PopulateComboWithCarryableItems(ref cbConditionStep2);
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
				PopulateComboWithItemsAndCharacters(ref cbConditionStep2);
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

	private TreeViewItem GetActionNode()
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

	private void cbConditionStep1_LostFocus(object sender, RoutedEventArgs e)
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

	private void cbConditionStep2_LostFocus(object sender, RoutedEventArgs e)
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

	private void cbConditionStep3_LostFocus(object sender, RoutedEventArgs e)
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

	private void tvActionsConditions_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		startPoint = ((MouseEventArgs)e).GetPosition((IInputElement)null);
	}

	private void SaveUndo()
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

	private void cmActionsConditions_Selection(object sender, RoutedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		MenuItem val = (MenuItem)sender;
		if (((FrameworkElement)val).Tag != null && ((FrameworkElement)val).Tag is QuickMenuItem)
		{
			SaveUndo();
			QuickMenuItem quickMenuItem = ((FrameworkElement)val).Tag as QuickMenuItem;
			{
				foreach (Rags.Action action2 in quickMenuItem.Actions)
				{
					if (quickMenuItem.bOverwrite)
					{
						List<Rags.Action> actionList = GetActionList();
						for (int i = 0; i < actionList.Count; i++)
						{
							if (action2.name == actionList[i].name)
							{
								actionList.RemoveAt(i);
								RefreshActions();
								break;
							}
						}
					}
					if (ActionDuplicateNameCheck(ThePageType, action2.name))
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
							Command thecommand = action.PassCommands[j] as Command;
							Condition thecondition = action.PassCommands[j] as Condition;
							if (thecommand != null)
							{
								QuickCommandReplaceCommand(ref thecommand);
							}
							if (thecondition != null)
							{
								QuickCommandReplaceCondition(ref thecondition);
							}
						}
						for (int k = 0; k < action.FailCommands.Count; k++)
						{
							Command thecommand2 = action.FailCommands[k] as Command;
							Condition thecondition2 = action.FailCommands[k] as Condition;
							if (thecommand2 != null)
							{
								QuickCommandReplaceCommand(ref thecommand2);
							}
							if (thecondition2 != null)
							{
								QuickCommandReplaceCondition(ref thecondition2);
							}
						}
						for (int l = 0; l < action.Conditions.Count; l++)
						{
							Condition thecondition3 = action.Conditions[l];
							QuickCommandReplaceCondition(ref thecondition3);
						}
						GetActionList().Add(action);
						AddActionToTreeNode(action, -1, bSelect: false);
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
		SaveUndo();
		ProcessActionConditionSelection(ThePageType, ((HeaderedItemsControl)val).Header.ToString());
	}

	private string GetCorrectObjectName()
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

	private string GetCorrectObjectDescription()
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

	private void QuickCommandReplaceCommand(ref Command thecommand)
	{
		string text = string.Empty;
		if (thecommand.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY || thecommand.cmdtype == Command.CommandType.CT_ITEM_SET_CUSTOM_PROPERTY_JS)
		{
			GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
			text = ((objectByName == null) ? string.Empty : objectByName.name);
		}
		else if (thecommand.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY || thecommand.cmdtype == Command.CommandType.CT_ROOM_SET_CUSTOM_PROPERTY_JS)
		{
			text = TheGame.GetRoomByID(new Guid(TheCurrentObject)).Name;
		}
		else if (thecommand.cmdtype == Command.CommandType.CT_SETVARIABLE || thecommand.cmdtype == Command.CommandType.CT_VARIABLE_SET_JAVASCRIPT)
		{
			text = GetCorrectObjectName();
		}
		for (int num = thecommand.CommandPart2.ToUpper().IndexOf("[SELF]"); num > -1; num = thecommand.CommandPart2.ToUpper().IndexOf("[SELF]"))
		{
			thecommand.CommandPart2 = thecommand.CommandPart2.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandPart2 = thecommand.CommandPart2.Insert(num, text);
			}
			else
			{
				thecommand.CommandPart2 = thecommand.CommandPart2.Insert(num, GetCorrectObjectName());
			}
		}
		for (int num = thecommand.CommandPart2.ToUpper().IndexOf("[NAME]"); num > -1; num = thecommand.CommandPart2.ToUpper().IndexOf("[NAME]"))
		{
			thecommand.CommandPart2 = thecommand.CommandPart2.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandPart2 = thecommand.CommandPart2.Insert(num, text);
			}
			else
			{
				thecommand.CommandPart2 = thecommand.CommandPart2.Insert(num, GetCorrectObjectName());
			}
		}
		for (int num = thecommand.CommandPart3.ToUpper().IndexOf("[SELF]"); num > -1; num = thecommand.CommandPart3.ToUpper().IndexOf("[SELF]"))
		{
			thecommand.CommandPart3 = thecommand.CommandPart3.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandPart3 = thecommand.CommandPart3.Insert(num, text);
			}
			else
			{
				thecommand.CommandPart3 = thecommand.CommandPart3.Insert(num, GetCorrectObjectName());
			}
		}
		for (int num = thecommand.CommandPart3.ToUpper().IndexOf("[NAME]"); num > -1; num = thecommand.CommandPart3.ToUpper().IndexOf("[NAME]"))
		{
			thecommand.CommandPart3 = thecommand.CommandPart3.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandPart3 = thecommand.CommandPart3.Insert(num, text);
			}
			else
			{
				thecommand.CommandPart3 = thecommand.CommandPart3.Insert(num, GetCorrectObjectName());
			}
		}
		for (int num = thecommand.CommandPart4.ToUpper().IndexOf("[SELF]"); num > -1; num = thecommand.CommandPart4.ToUpper().IndexOf("[SELF]"))
		{
			thecommand.CommandPart4 = thecommand.CommandPart4.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandPart4 = thecommand.CommandPart4.Insert(num, text);
			}
			else
			{
				thecommand.CommandPart4 = thecommand.CommandPart4.Insert(num, GetCorrectObjectName());
			}
		}
		for (int num = thecommand.CommandPart4.ToUpper().IndexOf("[NAME]"); num > -1; num = thecommand.CommandPart4.ToUpper().IndexOf("[NAME]"))
		{
			thecommand.CommandPart4 = thecommand.CommandPart4.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandPart4 = thecommand.CommandPart4.Insert(num, text);
			}
			else
			{
				thecommand.CommandPart4 = thecommand.CommandPart4.Insert(num, GetCorrectObjectName());
			}
		}
		for (int num = thecommand.CommandText.ToUpper().IndexOf("[SELF]"); num > -1; num = thecommand.CommandText.ToUpper().IndexOf("[SELF]"))
		{
			thecommand.CommandText = thecommand.CommandText.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandText = thecommand.CommandText.Insert(num, text);
			}
			else
			{
				thecommand.CommandText = thecommand.CommandText.Insert(num, GetCorrectObjectDescription());
			}
		}
		for (int num = thecommand.CommandText.ToUpper().IndexOf("[NAME]"); num > -1; num = thecommand.CommandText.ToUpper().IndexOf("[NAME]"))
		{
			thecommand.CommandText = thecommand.CommandText.Remove(num, 6);
			if (text != string.Empty)
			{
				thecommand.CommandText = thecommand.CommandText.Insert(num, text);
			}
			else
			{
				thecommand.CommandText = thecommand.CommandText.Insert(num, GetCorrectObjectName());
			}
		}
	}

	private void QuickCommandReplaceCondition(ref Condition thecondition)
	{
		for (int i = 0; i < thecondition.Checks.Count; i++)
		{
			Check check = thecondition.Checks[i];
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
					check.ConditionStep2 = check.ConditionStep2.Insert(num, GetCorrectObjectName());
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
					check.ConditionStep2 = check.ConditionStep2.Insert(num, GetCorrectObjectName());
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
					check.ConditionStep3 = check.ConditionStep3.Insert(num, GetCorrectObjectName());
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
					check.ConditionStep3 = check.ConditionStep3.Insert(num, GetCorrectObjectName());
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
					check.ConditionStep4 = check.ConditionStep4.Insert(num, GetCorrectObjectName());
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
					check.ConditionStep4 = check.ConditionStep4.Insert(num, GetCorrectObjectName());
				}
			}
		}
		for (int j = 0; j < thecondition.PassCommands.Count; j++)
		{
			Command thecommand = thecondition.PassCommands[j] as Command;
			Condition thecondition2 = thecondition.PassCommands[j] as Condition;
			if (thecommand != null)
			{
				QuickCommandReplaceCommand(ref thecommand);
			}
			if (thecondition2 != null)
			{
				QuickCommandReplaceCondition(ref thecondition2);
			}
		}
		for (int k = 0; k < thecondition.FailCommands.Count; k++)
		{
			Command thecommand2 = thecondition.FailCommands[k] as Command;
			Condition thecondition3 = thecondition.FailCommands[k] as Condition;
			if (thecommand2 != null)
			{
				QuickCommandReplaceCommand(ref thecommand2);
			}
			if (thecondition3 != null)
			{
				QuickCommandReplaceCondition(ref thecondition3);
			}
		}
	}

	private MenuItem AddContextItem(string hdr, string iconpath)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected Obj, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		RoutedEventHandler val = cmActionsConditions_Selection;
		MenuItem val2 = new MenuItem();
		((HeaderedItemsControl)val2).Header = hdr;
		val2.Click += val;
		if (iconpath == string.Empty)
		{
			return val2;
		}
		Image val3 = new Image();
		val3.Source = (ImageSource)new BitmapImage(new Uri(iconpath));
		val2.Icon = val3;
		return val2;
	}

	private void DisplayActionConditionMenu(TreeViewItem theitem)
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
		RoutedEventHandler val = cmActionsConditions_Selection;
		((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Clear();
		if (theitem == null)
		{
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Action", "pack://application:,,/Images/run.png"));
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
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Expand All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Collapse All", "pack://application:,,/Images/command.png"));
		}
		else if (((FrameworkElement)theitem).Parent == null)
		{
			theitem.IsSelected = true;
			if (ThePageType != PageType.timers)
			{
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Rename Action", "pack://application:,,/Images/cancel.png"));
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Action", "pack://application:,,/Images/run.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Delete Action", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Condition", "pack://application:,,/Images/question.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Delete Condition", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Command On Success", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Command On Failure", "pack://application:,,/Images/command.png"));
			bool flag = false;
			if (((FrameworkElement)theitem).Tag is Command)
			{
				flag = true;
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Delete Command", "pack://application:,,/Images/cancel.png"));
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Expand All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Collapse All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)new Separator());
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Copy Action", "pack://application:,,/Images/command.png"));
			MenuItem val4 = AddContextItem("Paste Action", "pack://application:,,/Images/command.png");
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val4);
			SharpSerializer sharpSerializer2 = new SharpSerializer(binarySerialization: true);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Rags.Action action2 = sharpSerializer2.Deserialize(ClipboardMS) as Rags.Action;
			((UIElement)val4).IsEnabled = action2 != null;
			val4 = AddContextItem("Paste Condition", "pack://application:,,/Images/question.png");
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val4);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Condition condition = sharpSerializer2.Deserialize(ClipboardMS) as Condition;
			((UIElement)val4).IsEnabled = condition != null;
			if (flag)
			{
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Copy Command", "pack://application:,,/Images/command.png"));
				val4 = AddContextItem("Paste Command", "pack://application:,,/Images/command.png");
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val4);
				ClipboardMS.Seek(0L, SeekOrigin.Begin);
				Command command = sharpSerializer2.Deserialize(ClipboardMS) as Command;
				((UIElement)val4).IsEnabled = command != null;
			}
		}
		else
		{
			theitem.IsSelected = true;
			if (ThePageType != PageType.timers)
			{
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Rename Action", "pack://application:,,/Images/run.png"));
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Action", "pack://application:,,/Images/run.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Delete Action", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Condition", "pack://application:,,/Images/question.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Delete Condition", "pack://application:,,/Images/cancel.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Command On Success", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Command On Failure", "pack://application:,,/Images/command.png"));
			bool flag2 = false;
			if (((FrameworkElement)theitem).Tag is Command)
			{
				flag2 = true;
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Delete Command", "pack://application:,,/Images/cancel.png"));
				flag2 = true;
			}
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Expand All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Collapse All", "pack://application:,,/Images/command.png"));
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)new Separator());
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Copy Action", "pack://application:,,/Images/run.png"));
			MenuItem val5 = AddContextItem("Paste Action", "pack://application:,,/Images/run.png");
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val5);
			SharpSerializer sharpSerializer3 = new SharpSerializer(binarySerialization: true);
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Rags.Action action3 = null;
			if (ClipboardMS.Length > 0)
			{
				action3 = sharpSerializer3.Deserialize(ClipboardMS) as Rags.Action;
			}
			((UIElement)val5).IsEnabled = action3 != null;
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Copy Condition", "pack://application:,,/Images/question.png"));
			val5 = AddContextItem("Paste Condition", "pack://application:,,/Images/question.png");
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
				((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Copy Command", "pack://application:,,/Images/command.png"));
			}
			string text = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)theitem).Header).Children[1]).Content.ToString();
			string text2 = string.Empty;
			if (((FrameworkElement)theitem).Parent is TreeViewItem)
			{
				text2 = ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)theitem).Parent).Header).Children[1]).Content.ToString();
			}
			if (text2 == "Commands on Success" || text == "Commands on Success" || text2 == "Commands on Failure" || text == "Commands on Failure")
			{
				val5 = AddContextItem("Paste Command", "pack://application:,,/Images/command.png");
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
			((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)AddContextItem("Add Default Actions:", ""));
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
						MenuItem val9 = AddContextItem(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val9).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val9);
					}
					break;
				case PageType.objects:
					if (quickMenuItem.bObjects)
					{
						MenuItem val7 = AddContextItem(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val7).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val7);
					}
					break;
				case PageType.player:
					if (quickMenuItem.bPlayer)
					{
						MenuItem val8 = AddContextItem(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val8).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val8);
					}
					break;
				case PageType.room:
					if (quickMenuItem.bRooms)
					{
						MenuItem val6 = AddContextItem(quickMenuItem.Name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val6).Tag = quickMenuItem;
						((ItemsControl)((FrameworkElement)tvActionsConditions).ContextMenu).Items.Add((object)val6);
					}
					break;
				}
			}
		}
		((FrameworkElement)tvActionsConditions).ContextMenu.IsOpen = true;
	}

	private void tvActionsConditions_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)tvActionsConditions).Focus();
		if (((UIElement)tvActionsConditions).IsEnabled)
		{
			TreeViewItem val = null;
			if (((RoutedEventArgs)e).Source is Label)
			{
				DependencyObject parent = ((FrameworkElement)(StackPanel)((FrameworkElement)(Label)((RoutedEventArgs)e).Source).Parent).Parent;
				val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			}
			else if (((RoutedEventArgs)e).Source is Image)
			{
				DependencyObject parent2 = ((FrameworkElement)(StackPanel)((FrameworkElement)(Image)((RoutedEventArgs)e).Source).Parent).Parent;
				val = (TreeViewItem)(object)((parent2 is TreeViewItem) ? parent2 : null);
			}
			if (val != null)
			{
				val.IsSelected = true;
			}
			DisplayActionConditionMenu(val);
		}
	}

	private void tvActionsConditions_MouseMove(object sender, MouseEventArgs e)
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
			Point position = e.GetPosition((IInputElement)null);
			Vector val = startPoint - position;
			if ((int)e.LeftButton == 1 && (Math.Abs(val.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(val.Y) > SystemParameters.MinimumVerticalDragDistance))
			{
				object selectedItem = tvActionsConditions.SelectedItem;
				DataObject val2 = new DataObject("tvNode", (selectedItem is TreeViewItem) ? selectedItem : null);
				DragDrop.DoDragDrop((DependencyObject)(object)tvActionsConditions, (object)val2, (DragDropEffects)1);
			}
		}
	}

	private bool ActionDuplicateNameCheck(PageType pt, string actionname)
	{
		bool result = true;
		switch (pt)
		{
		case PageType.objects:
		{
			GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
			if (objectByName != null)
			{
				for (int l = 0; l < objectByName.Actions.Count; l++)
				{
					if (string.Compare(actionname, objectByName.Actions[l].name) == 0)
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
				if (string.Compare(actionname, TheGame.ThePlayer.Actions[k].name) == 0)
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
					if (string.Compare(actionname, characterByName.Actions[j].name) == 0)
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
					if (string.Compare(actionname, roomByID.Actions[m].name) == 0)
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
					if (string.Compare(actionname, timerByName.Actions[i].name) == 0)
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

	private int GetNodeLevel(TreeViewItem itm)
	{
		int num = 0;
		if (itm == null)
		{
			return num;
		}
		while (((FrameworkElement)itm).Parent is TreeViewItem)
		{
			num++;
			DependencyObject parent = ((FrameworkElement)itm).Parent;
			itm = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		return num;
	}

	private void PasteCondition()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		TreeViewItem val = null;
		List<Condition> list = null;
		List<object> list2 = null;
		int num = 0;
		Rags.Action action = GetAction();
		object selectedItem = tvActionsConditions.SelectedItem;
		if (GetNodeLevel((TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null)) <= 1)
		{
			list = action.Conditions;
			val = GetActionNode();
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
			list2 = GetCommandList(IsPassCommands());
			if (val2 != null)
			{
				val2.IsSelected = true;
			}
			val = GetPassFailNode();
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
		AddConditionToTreeNode(condition, val, num);
	}

	private TreeViewItem GetPassFailNode()
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

	private List<object> GetCommandList(bool bPassCommands)
	{
		List<object> result = null;
		if (IsAction())
		{
			result = ((!bPassCommands) ? GetAction().FailCommands : GetAction().PassCommands);
		}
		else
		{
			Condition condition = GetCondition();
			if (condition != null)
			{
				result = ((!bPassCommands) ? condition.FailCommands : condition.PassCommands);
			}
		}
		return result;
	}

	private bool IsPassCommands()
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

	private TreeViewItem GetCommandNode()
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

	private void ProcessActionConditionSelection(PageType pt, string selection)
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
		switch (selection)
		{
		case "Rename Action":
		{
			GetNameWindow getNameWindow2 = new GetNameWindow();
			((ContentControl)getNameWindow2.lblTitle).Content = "Please Enter New Action Name:";
			((Window)getNameWindow2).Owner = Window.GetWindow((DependencyObject)(object)this);
			if (((Window)getNameWindow2).ShowDialog() == true)
			{
				if (ActionDuplicateNameCheck(ThePageType, getNameWindow2.txtEntry.Text))
				{
					Rags.Action action8 = GetAction();
					TreeViewItem actionNode = GetActionNode();
					action8.name = getNameWindow2.txtEntry.Text;
					((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)actionNode).Header).Children[1]).Content = getNameWindow2.txtEntry.Text;
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
			Rags.Action action9 = null;
			if (ThePageType != PageType.timers)
			{
				GetNameWindow getNameWindow3 = new GetNameWindow();
				((ContentControl)getNameWindow3.lblTitle).Content = "Please Enter Action Name:";
				((Window)getNameWindow3).Owner = Window.GetWindow((DependencyObject)(object)this);
				if (((Window)getNameWindow3).ShowDialog() == true)
				{
					if (ActionDuplicateNameCheck(pt, getNameWindow3.txtEntry.Text))
					{
						action9 = new Rags.Action();
						action9.name = getNameWindow3.txtEntry.Text;
						GetActionList().Add(action9);
						TreeViewItem val = new TreeViewItem();
						((HeaderedItemsControl)val).Header = CreateTreeViewHeader(action9.name, "pack://application:,,/Images/run.png");
						((FrameworkElement)val).Tag = action9;
						((ItemsControl)tvActionsConditions).Items.Add((object)val);
						TreeViewItem val2 = new TreeViewItem();
						((HeaderedItemsControl)val2).Header = CreateTreeViewHeader("Commands on Success", "pack://application:,,/Images/Green.png");
						((ItemsControl)val).Items.Add((object)val2);
						TreeViewItem val3 = new TreeViewItem();
						((HeaderedItemsControl)val3).Header = CreateTreeViewHeader("Commands on Failure", "pack://application:,,/Images/Red.png");
						((ItemsControl)val).Items.Add((object)val3);
						val.IsSelected = true;
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
			foreach (string selectedItem5 in addTimerActionsWindow.lbTimerActions.SelectedItems)
			{
				action9 = new Rags.Action();
				action9.name = selectedItem5;
				GetActionList().Add(action9);
				TreeViewItem val4 = new TreeViewItem();
				((HeaderedItemsControl)val4).Header = CreateTreeViewHeader(action9.name, "pack://application:,,/Images/run.png");
				((FrameworkElement)val4).Tag = action9;
				((ItemsControl)tvActionsConditions).Items.Add((object)val4);
				TreeViewItem val5 = new TreeViewItem();
				((HeaderedItemsControl)val5).Header = CreateTreeViewHeader("Commands on Success", "pack://application:,,/Images/Green.png");
				((ItemsControl)val4).Items.Add((object)val5);
				TreeViewItem val6 = new TreeViewItem();
				((HeaderedItemsControl)val6).Header = CreateTreeViewHeader("Commands on Failure", "pack://application:,,/Images/Red.png");
				((ItemsControl)val4).Items.Add((object)val6);
				val4.IsSelected = true;
			}
			break;
		}
		case "Copy Action":
		{
			Rags.Action action7 = GetAction();
			if (action7 != null)
			{
				sharpSerializer.Serialize(action7, ClipboardMS);
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
			if (!(sharpSerializer.Deserialize(ClipboardMS) is Rags.Action action6))
			{
				break;
			}
			if (ActionDuplicateNameCheck(pt, action6.name))
			{
				GetActionList().Add(action6);
				AddActionToTreeNode(action6, -1, bSelect: true);
			}
			else
			{
				if ((int)MessageBox.Show("There is already an action name " + action6.name + ".  Would you like to rename this action?", "Duplicate Name", (MessageBoxButton)4) != 6)
				{
					break;
				}
				GetNameWindow getNameWindow = new GetNameWindow();
				((ContentControl)getNameWindow.lblTitle).Content = "Please Enter Action Name:";
				((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
				if (((Window)getNameWindow).ShowDialog() == true)
				{
					if (ActionDuplicateNameCheck(pt, getNameWindow.txtEntry.Text))
					{
						action6.name = getNameWindow.txtEntry.Text;
						GetActionList().Add(action6);
						AddActionToTreeNode(action6, -1, bSelect: true);
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
			Condition condition2 = GetCondition();
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
				PasteCondition();
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
				List<object> commandList = GetCommandList(((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Header).Children[1]).Content.ToString() == "Commands on Success" || ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header).Children[1]).Content.ToString() == "Commands on Success");
				if (commandList != null)
				{
					commandList.Add(command);
					AddCommandToTreeNode(command, GetCommandNode());
				}
			}
			break;
		case "Delete Action":
			switch (pt)
			{
			case PageType.objects:
			{
				GameObject objectByName = TheGame.GetObjectByName(TheCurrentObject);
				if (objectByName != null)
				{
					Rags.Action action4 = GetAction();
					objectByName.Actions.Remove(action4);
				}
				break;
			}
			case PageType.player:
			{
				Rags.Action action = GetAction();
				TheGame.ThePlayer.Actions.Remove(action);
				break;
			}
			case PageType.characters:
			{
				Character characterByName = TheGame.GetCharacterByName(TheCurrentObject);
				if (characterByName != null)
				{
					Rags.Action action2 = GetAction();
					characterByName.Actions.Remove(action2);
				}
				break;
			}
			case PageType.room:
			{
				Room roomByID = TheGame.GetRoomByID(new Guid(TheCurrentObject));
				if (roomByID != null)
				{
					Rags.Action action5 = GetAction();
					roomByID.Actions.Remove(action5);
				}
				break;
			}
			case PageType.timers:
			{
				Timer timerByName = TheGame.GetTimerByName(TheCurrentObject);
				if (timerByName != null)
				{
					Rags.Action action3 = GetAction();
					timerByName.Actions.Remove(action3);
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
			((ItemsControl)tvActionsConditions).Items.Remove((object)GetActionNode());
			break;
		}
		switch (selection)
		{
		case "Delete Condition":
		{
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag == null || !(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition))
			{
				break;
			}
			object selectedItem2 = tvActionsConditions.SelectedItem;
			int nodeLevel = GetNodeLevel((TreeViewItem)((selectedItem2 is TreeViewItem) ? selectedItem2 : null));
			if (nodeLevel <= 1)
			{
				GetAction().Conditions.Remove(GetCondition());
				ItemCollection items = ((ItemsControl)GetActionNode()).Items;
				object selectedItem3 = tvActionsConditions.SelectedItem;
				items.Remove((selectedItem3 is TreeViewItem) ? selectedItem3 : null);
				break;
			}
			object selectedItem4 = tvActionsConditions.SelectedItem;
			TreeViewItem val11 = (TreeViewItem)((selectedItem4 is TreeViewItem) ? selectedItem4 : null);
			object tag = ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag;
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition && nodeLevel != 2)
			{
				((TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).IsSelected = true;
			}
			List<object> commandList3 = GetCommandList(IsPassCommands());
			if (commandList3 != null)
			{
				val11.IsSelected = true;
				commandList3.Remove(tag);
				((ItemsControl)GetPassFailNode()).Items.Remove(tvActionsConditions.SelectedItem);
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
			TreeViewItem val7 = null;
			object selectedItem = tvActionsConditions.SelectedItem;
			if (GetNodeLevel((TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null)) == 0)
			{
				val7 = GetActionNode();
				Rags.Action action12 = GetAction();
				if (action12 != null)
				{
					condition3 = new Condition(getNameWindow4.txtEntry.Text);
					condition3.Checks.Add(new Check());
					condition3.Checks[0].CondType = Condition.ConditionType.CT_Item_Held_By_Player;
					action12.Conditions.Add(condition3);
				}
			}
			else
			{
				List<object> commandList2 = GetCommandList(IsPassCommands());
				condition3 = new Condition(getNameWindow4.txtEntry.Text);
				condition3.Checks.Add(new Check());
				condition3.Checks[0].CondType = Condition.ConditionType.CT_Item_Held_By_Player;
				commandList2.Add(condition3);
				val7 = GetPassFailNode();
			}
			TreeViewItem val8 = new TreeViewItem();
			((HeaderedItemsControl)val8).Header = CreateTreeViewHeader(getNameWindow4.txtEntry.Text, "pack://application:,,/Images/Question.png");
			((FrameworkElement)val8).Tag = condition3;
			if (IsAction())
			{
				((ItemsControl)val7).Items.Insert(0, (object)val8);
			}
			else
			{
				((ItemsControl)val7).Items.Add((object)val8);
			}
			TreeViewItem val9 = new TreeViewItem();
			((HeaderedItemsControl)val9).Header = CreateTreeViewHeader("Commands on Success", "pack://application:,,/Images/Green.png");
			((ItemsControl)val8).Items.Add((object)val9);
			TreeViewItem val10 = new TreeViewItem();
			((HeaderedItemsControl)val10).Header = CreateTreeViewHeader("Commands on Failure", "pack://application:,,/Images/Red.png");
			((ItemsControl)val8).Items.Add((object)val10);
			val8.IsSelected = true;
			((FrameworkElement)val8).BringIntoView();
			break;
		}
		case "Add Command On Success":
			addCommand(bPassCommands: true);
			break;
		case "Add Command On Failure":
			addCommand(bPassCommands: false);
			break;
		case "Delete Command":
			deleteCommand();
			break;
		case "Examine":
		{
			Rags.Action action17 = null;
			switch (pt)
			{
			case PageType.characters:
			{
				Character characterByName2 = TheGame.GetCharacterByName(TheCurrentObject);
				if (characterByName2 != null && ActionDuplicateNameCheck(pt, "Examine"))
				{
					action17 = new Rags.Action();
					characterByName2.Actions.Add(action17);
					action17.name = "Examine";
					action17.bActive = true;
					Command command9 = new Command();
					action17.PassCommands.Add(command9);
					command9.CommandName = "Display Char Data";
					command9.cmdtype = Command.CommandType.CT_DISPLAYCHARDESC;
					command9.CommandPart2 = characterByName2.Charname;
				}
				break;
			}
			case PageType.objects:
			{
				GameObject objectByName5 = TheGame.GetObjectByName(TheCurrentObject);
				if (objectByName5 != null && ActionDuplicateNameCheck(pt, "Examine"))
				{
					action17 = new Rags.Action();
					objectByName5.Actions.Add(action17);
					action17.name = "Examine";
					action17.bActive = true;
					Command command10 = new Command();
					action17.PassCommands.Add(command10);
					command10.CommandName = "Display Item Data";
					command10.cmdtype = Command.CommandType.CT_DISPLAYITEMDESC;
					command10.CommandPart2 = objectByName5.name;
				}
				break;
			}
			case PageType.player:
				if (ActionDuplicateNameCheck(pt, "Examine"))
				{
					action17 = new Rags.Action();
					TheGame.ThePlayer.Actions.Add(action17);
					action17.name = "Examine";
					action17.bActive = true;
					Command command11 = new Command();
					action17.PassCommands.Add(command11);
					command11.CommandName = "Display Player Description";
					command11.cmdtype = Command.CommandType.CT_DISPLAYPLAYERDESC;
				}
				break;
			case PageType.room:
			{
				Room roomByID2 = TheGame.GetRoomByID(new Guid(TheCurrentObject));
				if (roomByID2 != null && ActionDuplicateNameCheck(pt, "Examine"))
				{
					action17 = new Rags.Action();
					roomByID2.Actions.Add(action17);
					action17.name = "Examine";
					action17.bActive = true;
					Command command8 = new Command();
					action17.PassCommands.Add(command8);
					command8.CommandName = "Display Room Data";
					command8.cmdtype = Command.CommandType.CT_DISPLAYROOMDESCRIPTION;
					command8.CommandPart2 = Room.CurrentRoomGuid.ToString();
					command8 = new Command();
					action17.PassCommands.Add(command8);
					command8.CommandName = "Display Room Pic";
					command8.cmdtype = Command.CommandType.CT_DISPLAYROOMPICTURE;
					command8.CommandPart2 = Room.CurrentRoomGuid.ToString();
				}
				break;
			}
			}
			AddActionToTreeNode(action17, -1, bSelect: true);
			break;
		}
		case "Open/Close":
		{
			List<Rags.Action> actionList = GetActionList();
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
			if (ActionDuplicateNameCheck(pt, "Open"))
			{
				Rags.Action action15 = new Rags.Action();
				actionList.Add(action15);
				action15.name = "Open";
				action15.bActive = true;
				Command command6 = new Command();
				action15.PassCommands.Add(command6);
				command6.CommandName = "Set Item To Open";
				command6.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
				command6.CommandPart2 = theCurrentObject;
				command6.CommandPart3 = "Open";
				command6 = new Command();
				command6.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command6.CommandName = "Display Result";
				command6.CommandText = "The " + theCurrentObject + " is now open.";
				action15.PassCommands.Add(command6);
				Condition condition6 = new Condition("Check For Open");
				action15.Conditions.Add(condition6);
				Check check3 = condition6.Checks[0];
				check3.CondType = Condition.ConditionType.CT_Item_State_Check;
				check3.ConditionStep2 = theCurrentObject;
				check3.ConditionStep3 = "Closed";
				command6 = new Command();
				command6.CommandName = "Display already open";
				command6.CommandText = "The " + theCurrentObject + " is already open.";
				command6.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition6.FailCommands.Add(command6);
				AddActionToTreeNode(action15, -1, bSelect: true);
			}
			if (ActionDuplicateNameCheck(pt, "Close"))
			{
				Rags.Action action16 = new Rags.Action();
				actionList.Add(action16);
				action16.name = "Close";
				action16.bActive = true;
				Command command7 = new Command();
				action16.PassCommands.Add(command7);
				command7.CommandName = "Set Item To Closed";
				command7.cmdtype = Command.CommandType.CT_SETOPENCLOSED;
				command7.CommandPart2 = theCurrentObject;
				command7.CommandPart3 = "Closed";
				command7 = new Command();
				command7.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command7.CommandName = "Display Result";
				command7.CommandText = "The " + theCurrentObject + " is now closed.";
				action16.PassCommands.Add(command7);
				Condition condition7 = new Condition("Check For Closed");
				action16.Conditions.Add(condition7);
				Check check4 = condition7.Checks[0];
				check4.CondType = Condition.ConditionType.CT_Item_State_Check;
				check4.ConditionStep2 = theCurrentObject;
				check4.ConditionStep3 = "Open";
				command7 = new Command();
				command7.CommandName = "Display already closed";
				command7.CommandText = "The " + theCurrentObject + " is already closed.";
				command7.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition7.FailCommands.Add(command7);
				AddActionToTreeNode(action16, -1, bSelect: true);
			}
			break;
		}
		case "Action Wizard...":
			break;
		case "Wear/Remove":
		{
			List<Rags.Action> list2 = null;
			string text2 = "";
			if (pt != PageType.objects)
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
			list2 = objectByName3.Actions;
			text2 = objectByName3.name;
			if (ActionDuplicateNameCheck(pt, "Wear"))
			{
				Rags.Action action13 = new Rags.Action();
				list2.Add(action13);
				action13.name = "Wear";
				action13.bActive = true;
				Command command4 = new Command();
				action13.PassCommands.Add(command4);
				command4.CommandName = "Set Item To Worn";
				command4.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
				command4.CommandPart2 = text2;
				command4.CommandPart3 = "Worn";
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command4.CommandName = "Enable Remove";
				command4.CommandPart2 = TheCurrentObject;
				command4.CommandPart3 = "Remove-Active";
				action13.PassCommands.Add(command4);
				command4 = new Command();
				command4.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command4.CommandName = "Disable Wear";
				command4.CommandPart2 = TheCurrentObject;
				command4.CommandPart3 = "Wear-Inactive";
				action13.PassCommands.Add(command4);
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
				action13.PassCommands.Add(command4);
				Condition condition4 = new Condition("Item must be in inventory");
				action13.Conditions.Add(condition4);
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
				AddActionToTreeNode(action13, -1, bSelect: true);
			}
			if (ActionDuplicateNameCheck(pt, "Remove"))
			{
				Rags.Action action14 = new Rags.Action();
				list2.Add(action14);
				action14.name = "Remove";
				action14.bActive = false;
				Command command5 = new Command();
				action14.PassCommands.Add(command5);
				command5.CommandName = "Set Item To Removed";
				command5.cmdtype = Command.CommandType.CT_SETITEMTOWORN;
				command5.CommandPart2 = text2;
				command5.CommandPart3 = "Removed";
				command5 = new Command();
				command5.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command5.CommandName = "Enable Wear";
				command5.CommandPart2 = TheCurrentObject;
				command5.CommandPart3 = "Wear-Active";
				action14.PassCommands.Add(command5);
				command5 = new Command();
				command5.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command5.CommandName = "Disable Remove";
				command5.CommandPart2 = TheCurrentObject;
				command5.CommandPart3 = "Remove-Inactive";
				action14.PassCommands.Add(command5);
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
				action14.PassCommands.Add(command5);
				Condition condition5 = new Condition("Item must be currently worn");
				action14.Conditions.Add(condition5);
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
				AddActionToTreeNode(action14, -1, bSelect: true);
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
			List<Rags.Action> list3 = null;
			string text3 = "";
			switch (pt)
			{
			case PageType.objects:
				list3 = TheGame.GetObjectByName(TheCurrentObject).Actions;
				text3 = TheGame.GetObjectByName(TheCurrentObject).name;
				break;
			case PageType.characters:
				list3 = TheGame.GetCharacterByName(TheCurrentObject).Actions;
				text3 = TheGame.GetCharacterByName(TheCurrentObject).Charname;
				break;
			}
			if (ActionDuplicateNameCheck(pt, "Lock"))
			{
				Rags.Action action18 = new Rags.Action();
				list3.Add(action18);
				action18.name = "Lock";
				action18.bActive = true;
				Command command12 = new Command();
				action18.PassCommands.Add(command12);
				command12.CommandName = "Set Item To Locked";
				command12.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
				command12.CommandPart2 = text3;
				command12.CommandPart3 = "Locked";
				command12 = new Command();
				command12.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command12.CommandName = "Display Result";
				command12.CommandText = "The " + text3 + " is now locked.";
				action18.PassCommands.Add(command12);
				Condition condition8 = new Condition("Check For Locked");
				action18.Conditions.Add(condition8);
				Check check5 = condition8.Checks[0];
				check5.CondType = Condition.ConditionType.CT_Item_State_Check;
				check5.ConditionStep2 = text3;
				check5.ConditionStep3 = "Unlocked";
				command12 = new Command();
				command12.CommandName = "Display already locked";
				command12.CommandText = "The " + text3 + " is already locked.";
				command12.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition8.FailCommands.Add(command12);
				AddActionToTreeNode(action18, -1, bSelect: true);
			}
			if (ActionDuplicateNameCheck(pt, "Unlock"))
			{
				Rags.Action action19 = new Rags.Action();
				list3.Add(action19);
				action19.name = "Unlock";
				action19.bActive = true;
				Command command13 = new Command();
				action19.PassCommands.Add(command13);
				command13.CommandName = "Set Item To Unlocked";
				command13.cmdtype = Command.CommandType.CT_SETLOCKEDUNLOCKED;
				command13.CommandPart2 = text3;
				command13.CommandPart3 = "Unlocked";
				command13 = new Command();
				command13.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command13.CommandName = "Display Result";
				command13.CommandText = "The " + text3 + " is now unlocked.";
				action19.PassCommands.Add(command13);
				Condition condition9 = new Condition("Check For Unlocked");
				action19.Conditions.Add(condition9);
				Check check6 = condition9.Checks[0];
				check6.CondType = Condition.ConditionType.CT_Item_State_Check;
				check6.ConditionStep2 = text3;
				check6.ConditionStep3 = "Locked";
				command13 = new Command();
				command13.CommandName = "Display already unlocked";
				command13.CommandText = "The " + text3 + " is already unlocked.";
				command13.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				condition9.FailCommands.Add(command13);
				AddActionToTreeNode(action19, -1, bSelect: true);
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
			List<Rags.Action> list = null;
			string text = "";
			switch (pt)
			{
			case PageType.objects:
				list = TheGame.GetObjectByName(TheCurrentObject).Actions;
				text = TheGame.GetObjectByName(TheCurrentObject).name;
				break;
			case PageType.characters:
				list = TheGame.GetCharacterByName(TheCurrentObject).Actions;
				text = TheGame.GetCharacterByName(TheCurrentObject).Charname;
				break;
			}
			if (ActionDuplicateNameCheck(pt, "Take"))
			{
				Rags.Action action10 = new Rags.Action();
				list.Add(action10);
				action10.name = "Take";
				action10.bActive = true;
				Command command2 = new Command();
				action10.PassCommands.Add(command2);
				command2.CommandName = "Pick Item Up";
				command2.cmdtype = Command.CommandType.CT_MOVEITEMTOINV;
				command2.CommandPart2 = text;
				command2 = new Command();
				command2.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command2.CommandName = "Display Result";
				command2.CommandText = "You pick up the " + text + ".";
				action10.PassCommands.Add(command2);
				command2 = new Command();
				command2.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command2.CommandName = "Enable Drop";
				command2.CommandPart2 = TheCurrentObject;
				command2.CommandPart3 = "Drop-Active";
				action10.PassCommands.Add(command2);
				command2 = new Command();
				command2.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command2.CommandName = "Disable Take";
				command2.CommandPart2 = TheCurrentObject;
				command2.CommandPart3 = "Take-Inactive";
				action10.PassCommands.Add(command2);
				AddActionToTreeNode(action10, -1, bSelect: true);
			}
			if (ActionDuplicateNameCheck(pt, "Drop"))
			{
				Rags.Action action11 = new Rags.Action();
				list.Add(action11);
				action11.name = "Drop";
				action11.bActive = false;
				Command command3 = new Command();
				action11.PassCommands.Add(command3);
				command3.CommandName = "Drop Item";
				command3.cmdtype = Command.CommandType.CT_MOVEITEMTOROOM;
				command3.CommandPart2 = text;
				command3.CommandPart3 = Room.CurrentRoomGuid.ToString();
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
				command3.CommandName = "Display Result";
				command3.CommandText = "You dropped the " + text + ".";
				action11.PassCommands.Add(command3);
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command3.CommandName = "Enable Take";
				command3.CommandPart2 = text;
				command3.CommandPart3 = "Take-Active";
				action11.PassCommands.Add(command3);
				command3 = new Command();
				command3.cmdtype = Command.CommandType.CT_SETOBJECTACTION;
				command3.CommandName = "Disable Drop";
				command3.CommandPart2 = text;
				command3.CommandPart3 = "Drop-Inactive";
				action11.PassCommands.Add(command3);
				AddActionToTreeNode(action11, -1, bSelect: true);
			}
			break;
		}
		}
	}

	private TreeViewItem GetTreeNode(bool bPassCommands)
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
		if (IsAction())
		{
			object selectedItem = tvActionsConditions.SelectedItem;
			val = (TreeViewItem)((selectedItem is TreeViewItem) ? selectedItem : null);
			while (((FrameworkElement)val).Parent is TreeViewItem)
			{
				DependencyObject parent = ((FrameworkElement)val).Parent;
				val = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
			}
			if (bPassCommands)
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
			if (GetNodeLevel((TreeViewItem)((selectedItem2 is TreeViewItem) ? selectedItem2 : null)) >= 1)
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
			if (bPassCommands)
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

	private void deleteCommand()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		List<object> commandList = GetCommandList(((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Header).Children[1]).Content.ToString() == "Commands on Success");
		commandList.Remove(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag);
		ItemCollection items = ((ItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Items;
		object selectedItem = tvActionsConditions.SelectedItem;
		items.Remove((selectedItem is TreeViewItem) ? selectedItem : null);
		tvActionsConditions_SelectedItemChanged(null, null);
	}

	private void addCommand(bool bPassCommands)
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
		List<object> commandList = GetCommandList(bPassCommands);
		Command command = new Command();
		command.cmdtype = Command.CommandType.CT_DISPLAYTEXT;
		commandList.Add(command);
		TreeViewItem treeNode = GetTreeNode(bPassCommands);
		TreeViewItem val = new TreeViewItem();
		((HeaderedItemsControl)val).Header = CreateTreeViewHeader(SaveLoad.GetCommandName(Command.CommandType.CT_DISPLAYTEXT), "pack://application:,,/Images/command.png");
		((FrameworkElement)val).Tag = command;
		((ItemsControl)treeNode).Items.Add((object)val);
		val.IsSelected = true;
		((FrameworkElement)val).BringIntoView();
		((Selector)cbCommandStep1).SelectedItem = SaveLoad.GetCommandItem(((ItemsControl)cbCommandStep1).Items, Command.CommandType.CT_DISPLAYTEXT);
		cbCommandStep1_SelectionChanged(null, null);
	}

	private void tvActionsConditions_Drop(object sender, DragEventArgs e)
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
		if (!e.Data.GetDataPresent("tvNode"))
		{
			return;
		}
		object data = e.Data.GetData("tvNode");
		TreeViewItem val = (TreeViewItem)((data is TreeViewItem) ? data : null);
		TreeViewItem val2 = null;
		if (((RoutedEventArgs)e).Source is Label)
		{
			DependencyObject parent = ((FrameworkElement)(StackPanel)((FrameworkElement)(Label)((RoutedEventArgs)e).Source).Parent).Parent;
			val2 = (TreeViewItem)(object)((parent is TreeViewItem) ? parent : null);
		}
		else if (((RoutedEventArgs)e).Source is Image)
		{
			DependencyObject parent2 = ((FrameworkElement)(StackPanel)((FrameworkElement)(Image)((RoutedEventArgs)e).Source).Parent).Parent;
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
				ProcessActionConditionSelection(ThePageType, "Copy Command");
				ProcessActionConditionSelection(ThePageType, "Delete Command");
				val2.IsSelected = true;
				int i = 0;
				List<object> commandList = GetCommandList(((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Parent).Header).Children[1]).Content.ToString() == "Commands on Success" || ((ContentControl)(Label)((Panel)(StackPanel)((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header).Children[1]).Content.ToString() == "Commands on Success");
				if (command2 != null)
				{
					for (i = 0; i < commandList.Count && (commandList[i] as Command != command2 || !(commandList[i] is Command)); i++)
					{
					}
				}
				ClipboardMS.Seek(0L, SeekOrigin.Begin);
				Command command3 = sharpSerializer.Deserialize(ClipboardMS) as Command;
				commandList.Insert(i, command3);
				TreeViewItem val3 = new TreeViewItem();
				((HeaderedItemsControl)val3).Header = CreateTreeViewHeader(SetCommandNodeText(command3), "pack://application:,,/Images/command.png");
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
			List<Condition> list = null;
			List<object> list2 = null;
			ProcessActionConditionSelection(ThePageType, "Copy Condition");
			ProcessActionConditionSelection(ThePageType, "Delete Condition");
			val2.IsSelected = true;
			int num = 0;
			Rags.Action action = GetAction();
			int nodeLevel = GetNodeLevel(val2);
			if (nodeLevel <= 1)
			{
				list = action.Conditions;
				val4 = GetActionNode();
				if (command4 == null && condition2 == null)
				{
					num = 0;
				}
				else
				{
					for (num = 0; num < list.Count && action.Conditions[num] != condition2; num++)
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
				list2 = GetCommandList(IsPassCommands());
				if (val5 != null)
				{
					val5.IsSelected = true;
				}
				val4 = GetPassFailNode();
				if (command4 == null && condition2 == null)
				{
					num = 0;
				}
				else if (nodeLevel <= 1)
				{
					for (num = 0; num < list.Count && (list[num] != condition2 || list[num] == null); num++)
					{
					}
				}
				else
				{
					for (num = 0; num < list2.Count && (list2[num] as Command != command4 || !(list2[num] is Command)) && (list2[num] as Condition != condition2 || !(list2[num] is Condition)); num++)
					{
					}
				}
			}
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Condition condition3 = sharpSerializer.Deserialize(ClipboardMS) as Condition;
			if (nodeLevel <= 1)
			{
				if (list.Count == 0)
				{
					list.Add(condition3);
				}
				else
				{
					list.Insert(num, condition3);
				}
			}
			else if (list2.Count == 0)
			{
				list2.Add(condition3);
			}
			else
			{
				list2.Insert(num, condition3);
			}
			AddConditionToTreeNode(condition3, val4, num);
		}
		if (!(((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action action2))
		{
			return;
		}
		Rags.Action action3 = ((FrameworkElement)val2).Tag as Rags.Action;
		if (action3 != action2)
		{
			ProcessActionConditionSelection(ThePageType, "Copy Action");
			ProcessActionConditionSelection(ThePageType, "Delete Action");
			val2.IsSelected = true;
			int num2 = 0;
			List<Rags.Action> actionList = GetActionList();
			for (num2 = 0; num2 < actionList.Count && actionList[num2] != action3; num2++)
			{
			}
			num2++;
			ClipboardMS.Seek(0L, SeekOrigin.Begin);
			Rags.Action action4 = sharpSerializer.Deserialize(ClipboardMS) as Rags.Action;
			if (num2 > actionList.Count)
			{
				num2 = actionList.Count;
			}
			actionList.Insert(num2, action4);
			AddActionToTreeNode(action4, num2, bSelect: true);
		}
	}

	private void PasteClipboardData()
	{
		SharpSerializer sharpSerializer = new SharpSerializer(binarySerialization: true);
		ClipboardMS.Seek(0L, SeekOrigin.Begin);
		object obj = sharpSerializer.Deserialize(ClipboardMS);
		if (obj.GetType() == typeof(Command))
		{
			ProcessActionConditionSelection(ThePageType, "Paste Command");
		}
		else if (obj.GetType() == typeof(Condition))
		{
			ProcessActionConditionSelection(ThePageType, "Paste Condition");
		}
		else if (obj.GetType() == typeof(Rags.Action))
		{
			ProcessActionConditionSelection(ThePageType, "Paste Action");
		}
	}

	private void PerformUndo()
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

	private void tvActionsConditions_KeyDown(object sender, KeyEventArgs e)
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
		if ((int)e.Key == 65 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			SaveUndo();
			PasteClipboardData();
		}
		if ((int)e.Key == 69 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			PerformUndo();
		}
		if ((int)e.Key == 46 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command)
			{
				ProcessActionConditionSelection(ThePageType, "Copy Command");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition)
			{
				ProcessActionConditionSelection(ThePageType, "Copy Condition");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action)
			{
				ProcessActionConditionSelection(ThePageType, "Copy Action");
			}
		}
		if ((int)e.Key == 67 && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)))
		{
			SaveUndo();
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command)
			{
				ProcessActionConditionSelection(ThePageType, "Copy Command");
				ProcessActionConditionSelection(ThePageType, "Delete Command");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition)
			{
				ProcessActionConditionSelection(ThePageType, "Copy Condition");
				ProcessActionConditionSelection(ThePageType, "Delete Condition");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action)
			{
				ProcessActionConditionSelection(ThePageType, "Copy Action");
				ProcessActionConditionSelection(ThePageType, "Delete Action");
			}
		}
		if ((int)e.Key == 32 && tvActionsConditions.SelectedItem != null && ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag != null)
		{
			SaveUndo();
			if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command)
			{
				ProcessActionConditionSelection(ThePageType, "Delete Command");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition)
			{
				ProcessActionConditionSelection(ThePageType, "Delete Condition");
			}
			else if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Rags.Action)
			{
				ProcessActionConditionSelection(ThePageType, "Delete Action");
			}
		}
	}

	private void cbCommandStep1_LostFocus(object sender, RoutedEventArgs e)
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
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(SetCommandNodeText(command), "pack://application:,,/Images/command.png");
		}
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = GetCondition();
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
			GetCondition().Checks.Add(check);
			RefreshConditionChecks(GetCondition());
			((Selector)lbChecks).SelectedIndex = GetCondition().Checks.Count - 1;
		}
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		Condition condition = GetCondition();
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
			GetCondition().Checks.Add(check);
			RefreshConditionChecks(GetCondition());
			((Selector)lbChecks).SelectedIndex = GetCondition().Checks.Count - 1;
		}
	}

	private void txtCommandText_LostFocus(object sender, RoutedEventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (tvActionsConditions.SelectedItem != null && ((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Command command)
		{
			command.CommandText = txtCommandText.Text;
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(SetCommandNodeText(command), "pack://application:,,/Images/command.png");
		}
	}

	private void cbCommandStep4_LostFocus(object sender, RoutedEventArgs e)
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
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(SetCommandNodeText(command), "pack://application:,,/Images/command.png");
		}
	}

	private void txtConditionName_LostFocus(object sender, RoutedEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)(TreeViewItem)tvActionsConditions.SelectedItem).Tag is Condition condition)
		{
			condition.conditionname = txtConditionName.Text;
			((HeaderedItemsControl)(TreeViewItem)tvActionsConditions.SelectedItem).Header = CreateTreeViewHeader(txtConditionName.Text, "pack://application:,,/Images/Question.png");
		}
	}

	private void cbActionActive_LostFocus(object sender, RoutedEventArgs e)
	{
		Rags.Action action = GetAction();
		if (action != null)
		{
			action.bActive = ((ToggleButton)cbActionActive).IsChecked.Value;
		}
	}

	private void txtStep4_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.SystemKey != 65 || (!Keyboard.IsKeyDown((Key)120) && !Keyboard.IsKeyDown((Key)121)))
		{
			return;
		}
		((RoutedEventArgs)e).Handled = true;
		TextBox val = (TextBox)((sender is TextBox) ? sender : null);
		ComboBox val2 = (ComboBox)((sender is ComboBox) ? sender : null);
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

	private void tbActionNameOverride_LostFocus(object sender, RoutedEventArgs e)
	{
		Rags.Action action = GetAction();
		if (action != null)
		{
			action.overridename = tbActionNameOverride.Text;
		}
	}

	private void cbActionParent_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Rags.Action action = GetAction();
		if (((Selector)cbActionParent).SelectedItem != null)
		{
			action.actionparent = ((Selector)cbActionParent).SelectedItem.ToString();
		}
	}

	private void gbCondBehavior_LostFocus(object sender, RoutedEventArgs e)
	{
		Rags.Action action = GetAction();
		if (action != null)
		{
			action.bConditionFailOnFirst = ((ToggleButton)rbFailOnFirst).IsChecked.Value;
		}
	}

	private void rbaddinputCustom_Click(object sender, RoutedEventArgs e)
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

	private void rbaddinputCharacter_Click(object sender, RoutedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected Obj, but got Unknown
		RadioButton val = (RadioButton)sender;
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

	private void rbaddinputnone_Click(object sender, RoutedEventArgs e)
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

	private void gbAddInput_LostFocus(object sender, RoutedEventArgs e)
	{
		Rags.Action action = GetAction();
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

	private void btnActionCustomAdd_Click(object sender, RoutedEventArgs e)
	{
		GetNameWindow getNameWindow = new GetNameWindow();
		((ContentControl)getNameWindow.lblTitle).Content = "Enter choice:";
		((Window)getNameWindow).Owner = Window.GetWindow((DependencyObject)(object)this);
		bool? flag = ((Window)getNameWindow).ShowDialog();
		if (flag == true && flag.HasValue && getNameWindow.txEntry.Text != string.Empty)
		{
			((ItemsControl)lbActionCustomChoices).Items.Add((object)getNameWindow.txtEntry.Text);
			GetAction()?.CustomChoices.Add(getNameWindow.txtEntry.Text);
		}
	}

	private void btnActionCustomUpdate_Click(object sender, RoutedEventArgs e)
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
			Rags.Action action = GetAction();
			if (action != null)
			{
				action.CustomChoices.RemoveAt(selectedIndex);
				action.CustomChoices.Insert(selectedIndex, getNameWindow.txtEntry.Text);
			}
			RefreshActionPage();
		}
	}

	private void btnActionCustomDelete_Click(object sender, RoutedEventArgs e)
	{
		for (int num = lbActionCustomChoices.SelectedItems.Count - 1; num >= 0; num--)
		{
			string text = lbActionCustomChoices.SelectedItems[num].ToString();
			GetAction()?.CustomChoices.Remove(text);
			((ItemsControl)lbActionCustomChoices).Items.Remove((object)text);
		}
	}

	private void tbCustomChoiceTitle_LostFocus(object sender, RoutedEventArgs e)
	{
		Rags.Action action = GetAction();
		if (action != null)
		{
			action.CustomChoiceTitle = tbCustomChoiceTitle.Text;
		}
	}

	private void CmdAddCustomChoice_Click(object sender, RoutedEventArgs e)
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

	private void CmdUpdateCustomChoice_Click(object sender, RoutedEventArgs e)
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
			RefreshActionPage();
		}
	}

	private void CmdDelCustomChoice_Click(object sender, RoutedEventArgs e)
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

	private void CmdAdvCustomChoice_Click(object sender, RoutedEventArgs e)
	{
	}

	private void DeleteCheck_Click(object sender, RoutedEventArgs e)
	{
		Condition condition = GetCondition();
		if (condition != null)
		{
			Check check = condition.Checks[((Selector)lbChecks).SelectedIndex];
			if (check != null)
			{
				condition.Checks.Remove(check);
				RefreshConditionChecks(GetCondition());
			}
		}
	}

	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerNonUserCode]
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
			tvActionsConditions.SelectedItemChanged += tvActionsConditions_SelectedItemChanged;
			((UIElement)tvActionsConditions).MouseLeftButtonDown += tvActionsConditions_MouseLeftButtonDown;
			((UIElement)tvActionsConditions).MouseRightButtonDown += tvActionsConditions_MouseRightButtonDown;
			((UIElement)tvActionsConditions).MouseMove += tvActionsConditions_MouseMove;
			((UIElement)tvActionsConditions).Drop += tvActionsConditions_Drop;
			((UIElement)tvActionsConditions).KeyDown += tvActionsConditions_KeyDown;
			break;
		case 3:
			gbActionAttributes = (GroupBox)target;
			break;
		case 4:
			tbActionNameOverride = (TextBox)target;
			((Control)tbActionNameOverride).MouseDoubleClick += General_MouseDoubleClick;
			((UIElement)tbActionNameOverride).LostFocus += tbActionNameOverride_LostFocus;
			break;
		case 5:
			cbActionActive = (CheckBox)target;
			((UIElement)cbActionActive).LostFocus += cbActionActive_LostFocus;
			break;
		case 6:
			cbActionParent = (ComboBox)target;
			((Selector)cbActionParent).SelectionChanged += cbActionParent_SelectionChanged;
			break;
		case 7:
			gbCondBehavior = (GroupBox)target;
			((UIElement)gbCondBehavior).LostFocus += gbCondBehavior_LostFocus;
			break;
		case 8:
			rbFailOnFirst = (RadioButton)target;
			break;
		case 9:
			rbRunAll = (RadioButton)target;
			break;
		case 10:
			gbAddInput = (GroupBox)target;
			((UIElement)gbAddInput).LostFocus += gbAddInput_LostFocus;
			break;
		case 11:
			rbaddinputnone = (RadioButton)target;
			((ButtonBase)rbaddinputnone).Click += rbaddinputnone_Click;
			break;
		case 12:
			rbaddinputObject = (RadioButton)target;
			((ButtonBase)rbaddinputObject).Click += rbaddinputCharacter_Click;
			break;
		case 13:
			rbaddinputCharacter = (RadioButton)target;
			((ButtonBase)rbaddinputCharacter).Click += rbaddinputCharacter_Click;
			break;
		case 14:
			rbaddinputText = (RadioButton)target;
			((ButtonBase)rbaddinputText).Click += rbaddinputCharacter_Click;
			break;
		case 15:
			rbaddinputObjectorCharacter = (RadioButton)target;
			((ButtonBase)rbaddinputObjectorCharacter).Click += rbaddinputCharacter_Click;
			break;
		case 16:
			rbaddinputCustom = (RadioButton)target;
			((ButtonBase)rbaddinputCustom).Click += rbaddinputCustom_Click;
			break;
		case 17:
			rbAddInputInventory = (RadioButton)target;
			((ButtonBase)rbAddInputInventory).Click += rbaddinputCharacter_Click;
			break;
		case 18:
			btnAdvancedOptions = (Button)target;
			break;
		case 19:
			gbCustomChoices = (GroupBox)target;
			break;
		case 20:
			tbCustomChoiceTitle = (TextBox)target;
			((UIElement)tbCustomChoiceTitle).LostFocus += tbCustomChoiceTitle_LostFocus;
			break;
		case 21:
			lbActionCustomChoices = (ListBox)target;
			break;
		case 22:
			btnActionCustomAdd = (Button)target;
			((ButtonBase)btnActionCustomAdd).Click += btnActionCustomAdd_Click;
			break;
		case 23:
			btnActionCustomUpdate = (Button)target;
			((ButtonBase)btnActionCustomUpdate).Click += btnActionCustomUpdate_Click;
			break;
		case 24:
			btnActionCustomDelete = (Button)target;
			((ButtonBase)btnActionCustomDelete).Click += btnActionCustomDelete_Click;
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
			((Selector)cbCommandStep1).SelectionChanged += cbCommandStep1_SelectionChanged;
			((UIElement)cbCommandStep1).LostFocus += cbCommandStep1_LostFocus;
			break;
		case 29:
			lblCommandStep2 = (Label)target;
			((UIElement)lblCommandStep2).KeyDown += txtStep4_KeyDown;
			break;
		case 30:
			cbCommandStep2 = (ComboBox)target;
			((Selector)cbCommandStep2).SelectionChanged += cbCommandStep2_SelectionChanged;
			((Control)cbCommandStep2).MouseDoubleClick += General_MouseDoubleClick;
			((UIElement)cbCommandStep2).LostFocus += cbCommandStep2_LostFocus;
			break;
		case 31:
			lblCommandStep3 = (Label)target;
			break;
		case 32:
			lblCommandText = (Label)target;
			break;
		case 33:
			cbCommandStep3 = (ComboBox)target;
			((UIElement)cbCommandStep3).KeyDown += txtStep4_KeyDown;
			((UIElement)cbCommandStep3).LostFocus += cbCommandStep3_LostFocus;
			((Selector)cbCommandStep3).SelectionChanged += cbCommandStep3_SelectionChanged;
			((Control)cbCommandStep3).MouseDoubleClick += General_MouseDoubleClick;
			break;
		case 34:
			txtCommandText = (TextBox)target;
			((Control)txtCommandText).MouseDoubleClick += General_MouseDoubleClick;
			((UIElement)txtCommandText).LostFocus += txtCommandText_LostFocus;
			((UIElement)txtCommandText).KeyDown += txtStep4_KeyDown;
			break;
		case 35:
			lblCommandStep4 = (Label)target;
			break;
		case 36:
			cbCommandStep4 = (ComboBox)target;
			((Control)cbCommandStep4).MouseDoubleClick += General_MouseDoubleClick;
			((UIElement)cbCommandStep4).LostFocus += cbCommandStep4_LostFocus;
			((UIElement)cbCommandStep4).KeyDown += txtStep4_KeyDown;
			break;
		case 37:
			txtStep4 = (TextBox)target;
			((UIElement)txtStep4).LostFocus += txtStep4_LostFocus;
			((Control)txtStep4).MouseDoubleClick += General_MouseDoubleClick;
			((UIElement)txtStep4).KeyDown += txtStep4_KeyDown;
			break;
		case 38:
			gbCommandChoices = (GroupBox)target;
			break;
		case 39:
			lbCustomChoices = (ListBox)target;
			break;
		case 40:
			CmdAddCustomChoice = (Button)target;
			((ButtonBase)CmdAddCustomChoice).Click += CmdAddCustomChoice_Click;
			break;
		case 41:
			CmdUpdateCustomChoice = (Button)target;
			((ButtonBase)CmdUpdateCustomChoice).Click += CmdUpdateCustomChoice_Click;
			break;
		case 42:
			CmdDelCustomChoice = (Button)target;
			((ButtonBase)CmdDelCustomChoice).Click += CmdDelCustomChoice_Click;
			break;
		case 43:
			CmdAdvCustomChoice = (Button)target;
			((ButtonBase)CmdAdvCustomChoice).Click += CmdAdvCustomChoice_Click;
			break;
		case 44:
			gbConditionData = (GroupBox)target;
			break;
		case 45:
			txtConditionName = (TextBox)target;
			((UIElement)txtConditionName).LostFocus += txtConditionName_LostFocus;
			break;
		case 46:
			lbChecks = (ListBox)target;
			((Selector)lbChecks).SelectionChanged += lbChecks_SelectionChanged;
			break;
		case 47:
			((ButtonBase)(Button)target).Click += Button_Click;
			break;
		case 48:
			((ButtonBase)(Button)target).Click += Button_Click_1;
			break;
		case 49:
			((ButtonBase)(Button)target).Click += DeleteCheck_Click;
			break;
		case 50:
			((ButtonBase)(Button)target).Click += Button_Click;
			break;
		case 51:
			((ButtonBase)(Button)target).Click += Button_Click_1;
			break;
		case 52:
			lblConditionStep1 = (Label)target;
			break;
		case 53:
			cbConditionStep1 = (ComboBox)target;
			((Selector)cbConditionStep1).SelectionChanged += cbConditionStep1_SelectionChanged;
			((UIElement)cbConditionStep1).LostFocus += cbConditionStep1_LostFocus;
			break;
		case 54:
			lblConditionStep2 = (Label)target;
			break;
		case 55:
			cbConditionStep2 = (ComboBox)target;
			((UIElement)cbConditionStep2).KeyDown += txtStep4_KeyDown;
			((Control)cbConditionStep2).MouseDoubleClick += General_MouseDoubleClick;
			((Selector)cbConditionStep2).SelectionChanged += cbConditionStep2_SelectionChanged;
			((UIElement)cbConditionStep2).LostFocus += cbConditionStep2_LostFocus;
			break;
		case 56:
			lblConditionStep3 = (Label)target;
			break;
		case 57:
			cbConditionStep3 = (ComboBox)target;
			((UIElement)cbConditionStep3).KeyDown += txtStep4_KeyDown;
			((Control)cbConditionStep3).MouseDoubleClick += General_MouseDoubleClick;
			((Selector)cbConditionStep3).SelectionChanged += cbConditionStep3_SelectionChanged;
			((UIElement)cbConditionStep3).LostFocus += cbConditionStep3_LostFocus;
			break;
		case 58:
			lblConditionStep4 = (Label)target;
			break;
		case 59:
			cbConditionStep4 = (ComboBox)target;
			((UIElement)cbConditionStep4).KeyDown += txtStep4_KeyDown;
			((Control)cbConditionStep4).MouseDoubleClick += General_MouseDoubleClick;
			((UIElement)cbConditionStep4).LostFocus += cbConditionStep4_LostFocus;
			break;
		case 60:
			txtConditionStep4 = (TextBox)target;
			((UIElement)txtConditionStep4).KeyDown += txtStep4_KeyDown;
			((Control)txtConditionStep4).MouseDoubleClick += General_MouseDoubleClick;
			((UIElement)txtConditionStep4).LostFocus += txtConditionStep4_LostFocus;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
