using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
public class CheckComboBox : Selector
{
	private const string PART_Popup = "PART_Popup";

	private ValueChangeHelper _displayMemberPathValuesChangeHelper;

	private Popup _popup;

	private List<object> _initialValue = new List<object>();

	public static readonly DependencyProperty TextProperty;

	public static readonly DependencyProperty IsDropDownOpenProperty;

	public static readonly DependencyProperty MaxDropDownHeightProperty;

	public string Text
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextProperty, (object)value);
		}
	}

	public bool IsDropDownOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDropDownOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDropDownOpenProperty, (object)value);
		}
	}

	public double MaxDropDownHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxDropDownHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxDropDownHeightProperty, (object)value);
		}
	}

	static CheckComboBox()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CheckComboBox), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		IsDropDownOpenProperty = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(CheckComboBox), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsDropDownOpenChanged));
		MaxDropDownHeightProperty = DependencyProperty.Register("MaxDropDownHeight", typeof(double), typeof(CheckComboBox), (PropertyMetadata)new UIPropertyMetadata((object)(SystemParameters.PrimaryScreenHeight / 3.0), (PropertyChangedCallback)OnMaxDropDownHeightChanged));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CheckComboBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(CheckComboBox)));
	}

	public CheckComboBox()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, (KeyEventHandler)OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, (MouseButtonEventHandler)OnMouseDownOutsideCapturedElement);
		_displayMemberPathValuesChangeHelper = new ValueChangeHelper(OnDisplayMemberPathValuesChanged);
	}

	private static void OnIsDropDownOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CheckComboBox checkComboBox)
		{
			checkComboBox.OnIsDropDownOpenChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsDropDownOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			_initialValue.Clear();
			{
				foreach (object selectedItem in SelectedItems)
				{
					_initialValue.Add(selectedItem);
				}
				return;
			}
		}
		_initialValue.Clear();
	}

	private static void OnMaxDropDownHeightChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CheckComboBox checkComboBox)
		{
			checkComboBox.OnMaxDropDownHeightChanged((double)e.OldValue, (double)e.NewValue);
		}
	}

	protected virtual void OnMaxDropDownHeightChanged(double oldValue, double newValue)
	{
	}

	protected override void OnSelectedValueChanged(string oldValue, string newValue)
	{
		base.OnSelectedValueChanged(oldValue, newValue);
		UpdateText();
	}

	protected override void OnDisplayMemberPathChanged(string oldDisplayMemberPath, string newDisplayMemberPath)
	{
		((ItemsControl)this).OnDisplayMemberPathChanged(oldDisplayMemberPath, newDisplayMemberPath);
		UpdateDisplayMemberPathValuesBindings();
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		base.OnItemsSourceChanged(oldValue, newValue);
		UpdateDisplayMemberPathValuesBindings();
	}

	public override void OnApplyTemplate()
	{
		((FrameworkElement)this).OnApplyTemplate();
		if (_popup != null)
		{
			_popup.Opened -= Popup_Opened;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_Popup");
		_popup = (Popup)(object)((templateChild is Popup) ? templateChild : null);
		if (_popup != null)
		{
			_popup.Opened += Popup_Opened;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseDropDown(isFocusOnComboBox: false);
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		if (!IsDropDownOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsDropDownOpen = true;
				((RoutedEventArgs)e).Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e))
		{
			CloseDropDown(isFocusOnComboBox: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 6)
		{
			CloseDropDown(isFocusOnComboBox: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else
		{
			if ((int)e.Key != 13)
			{
				return;
			}
			SelectedItems.Clear();
			foreach (object item in _initialValue)
			{
				SelectedItems.Add(item);
			}
			CloseDropDown(isFocusOnComboBox: true);
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		DependencyObject val = ((ItemsControl)this).ItemContainerGenerator.ContainerFromItem(SelectedItem);
		UIElement val2 = (UIElement)(object)((val is UIElement) ? val : null);
		if (val2 == null && ((CollectionView)((ItemsControl)this).Items).Count > 0)
		{
			DependencyObject val3 = ((ItemsControl)this).ItemContainerGenerator.ContainerFromItem(((ItemsControl)this).Items[0]);
			val2 = (UIElement)(object)((val3 is UIElement) ? val3 : null);
		}
		if (val2 != null)
		{
			val2.Focus();
		}
	}

	private void UpdateDisplayMemberPathValuesBindings()
	{
		_displayMemberPathValuesChangeHelper.UpdateValueSource(ItemsCollection, ((ItemsControl)this).DisplayMemberPath);
	}

	private void OnDisplayMemberPathValuesChanged()
	{
		UpdateText();
	}

	private void UpdateText()
	{
		string text = string.Join(Delimiter, from object x in SelectedItems
			select GetItemDisplayValue(x));
		if (string.IsNullOrEmpty(Text) || !Text.Equals(text))
		{
			Text = text;
		}
	}

	protected object GetItemDisplayValue(object item)
	{
		if (!string.IsNullOrEmpty(((ItemsControl)this).DisplayMemberPath))
		{
			PropertyInfo property = item.GetType().GetProperty(((ItemsControl)this).DisplayMemberPath);
			if (property != null)
			{
				return property.GetValue(item, null);
			}
		}
		return item;
	}

	private void CloseDropDown(bool isFocusOnComboBox)
	{
		if (IsDropDownOpen)
		{
			IsDropDownOpen = false;
		}
		((UIElement)this).ReleaseMouseCapture();
		if (isFocusOnComboBox)
		{
			((UIElement)this).Focus();
		}
	}
}
