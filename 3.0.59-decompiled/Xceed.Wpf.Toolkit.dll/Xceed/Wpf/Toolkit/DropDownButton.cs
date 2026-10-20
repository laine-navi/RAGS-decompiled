using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
[TemplatePart(Name = "PART_ContentPresenter", Type = typeof(ContentPresenter))]
[TemplatePart(Name = "PART_DropDownButton", Type = typeof(ToggleButton))]
public class DropDownButton : ContentControl, ICommandSource
{
	private const string PART_DropDownButton = "PART_DropDownButton";

	private const string PART_ContentPresenter = "PART_ContentPresenter";

	private const string PART_Popup = "PART_Popup";

	private ContentPresenter _contentPresenter;

	private Popup _popup;

	private ButtonBase _button;

	public static readonly DependencyProperty DropDownContentProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly RoutedEvent ClickEvent;

	public static readonly RoutedEvent OpenedEvent;

	public static readonly RoutedEvent ClosedEvent;

	private EventHandler canExecuteChangedHandler;

	public static readonly DependencyProperty CommandProperty;

	public static readonly DependencyProperty CommandParameterProperty;

	public static readonly DependencyProperty CommandTargetProperty;

	protected ButtonBase Button
	{
		get
		{
			return _button;
		}
		set
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected Obj, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected Obj, but got Unknown
			if (_button != null)
			{
				_button.Click -= DropDownButton_Click;
			}
			_button = value;
			if (_button != null)
			{
				_button.Click += DropDownButton_Click;
			}
		}
	}

	public object DropDownContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(DropDownContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownContentProperty, value);
		}
	}

	public bool IsOpen
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsOpenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsOpenProperty, (object)value);
		}
	}

	[TypeConverter(typeof(CommandConverter))]
	public ICommand Command
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandProperty, (object)value);
		}
	}

	public object CommandParameter
	{
		get
		{
			return ((DependencyObject)this).GetValue(CommandParameterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandParameterProperty, value);
		}
	}

	public IInputElement CommandTarget
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (IInputElement)((DependencyObject)this).GetValue(CommandTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CommandTargetProperty, (object)value);
		}
	}

	public event RoutedEventHandler Click
	{
		add
		{
			((UIElement)this).AddHandler(ClickEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ClickEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler Opened
	{
		add
		{
			((UIElement)this).AddHandler(OpenedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(OpenedEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler Closed
	{
		add
		{
			((UIElement)this).AddHandler(ClosedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ClosedEvent, (Delegate)(object)value);
		}
	}

	static DropDownButton()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected Obj, but got Unknown
		DropDownContentProperty = DependencyProperty.Register("DropDownContent", typeof(object), typeof(DropDownButton), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnDropDownContentChanged));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(DropDownButton), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsOpenChanged));
		ClickEvent = EventManager.RegisterRoutedEvent("Click", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(DropDownButton));
		OpenedEvent = EventManager.RegisterRoutedEvent("Opened", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(DropDownButton));
		ClosedEvent = EventManager.RegisterRoutedEvent("Closed", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(DropDownButton));
		CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(DropDownButton), new PropertyMetadata((object)null, (PropertyChangedCallback)OnCommandChanged));
		CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(DropDownButton), new PropertyMetadata((PropertyChangedCallback)null));
		CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(DropDownButton), new PropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownButton), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(DropDownButton)));
	}

	public DropDownButton()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected Obj, but got Unknown
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, (KeyEventHandler)OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, (MouseButtonEventHandler)OnMouseDownOutsideCapturedElement);
	}

	private static void OnDropDownContentChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DropDownButton dropDownButton)
		{
			dropDownButton.OnDropDownContentChanged(e.OldValue, e.NewValue);
		}
	}

	protected virtual void OnDropDownContentChanged(object oldValue, object newValue)
	{
	}

	private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is DropDownButton dropDownButton)
		{
			dropDownButton.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
	{
		if (newValue)
		{
			RaiseRoutedEvent(OpenedEvent);
		}
		else
		{
			RaiseRoutedEvent(ClosedEvent);
		}
	}

	public override void OnApplyTemplate()
	{
		((FrameworkElement)this).OnApplyTemplate();
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_DropDownButton");
		Button = (ButtonBase)(object)((templateChild is ToggleButton) ? templateChild : null);
		DependencyObject templateChild2 = ((FrameworkElement)this).GetTemplateChild("PART_ContentPresenter");
		_contentPresenter = (ContentPresenter)(object)((templateChild2 is ContentPresenter) ? templateChild2 : null);
		if (_popup != null)
		{
			_popup.Opened -= Popup_Opened;
		}
		DependencyObject templateChild3 = ((FrameworkElement)this).GetTemplateChild("PART_Popup");
		_popup = (Popup)(object)((templateChild3 is Popup) ? templateChild3 : null);
		if (_popup != null)
		{
			_popup.Opened += Popup_Opened;
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsOpen = true;
				((RoutedEventArgs)e).Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e))
		{
			CloseDropDown(isFocusOnButton: true);
			((RoutedEventArgs)e).Handled = true;
		}
		else if ((int)e.Key == 13)
		{
			CloseDropDown(isFocusOnButton: true);
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseDropDown(isFocusOnButton: false);
	}

	private void DropDownButton_Click(object sender, RoutedEventArgs e)
	{
		OnClick();
	}

	private void CanExecuteChanged(object sender, EventArgs e)
	{
		CanExecuteChanged();
	}

	private void Popup_Opened(object sender, EventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (_contentPresenter != null)
		{
			((UIElement)_contentPresenter).MoveFocus(new TraversalRequest((FocusNavigationDirection)2));
		}
	}

	private void CanExecuteChanged()
	{
		if (Command != null)
		{
			ICommand command = Command;
			RoutedCommand val = (RoutedCommand)((command is RoutedCommand) ? command : null);
			if (val != null)
			{
				((UIElement)this).IsEnabled = (val.CanExecute(CommandParameter, CommandTarget) ? true : false);
			}
			else
			{
				((UIElement)this).IsEnabled = (Command.CanExecute(CommandParameter) ? true : false);
			}
		}
	}

	private void CloseDropDown(bool isFocusOnButton)
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		((UIElement)this).ReleaseMouseCapture();
		if (isFocusOnButton)
		{
			((UIElement)Button).Focus();
		}
	}

	protected virtual void OnClick()
	{
		RaiseRoutedEvent(ClickEvent);
		RaiseCommand();
	}

	private void RaiseRoutedEvent(RoutedEvent routedEvent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		RoutedEventArgs e = new RoutedEventArgs(routedEvent, (object)this);
		((UIElement)this).RaiseEvent(e);
	}

	private void RaiseCommand()
	{
		if (Command != null)
		{
			ICommand command = Command;
			RoutedCommand val = (RoutedCommand)((command is RoutedCommand) ? command : null);
			if (val == null)
			{
				Command.Execute(CommandParameter);
			}
			else
			{
				val.Execute(CommandParameter, CommandTarget);
			}
		}
	}

	private void UnhookCommand(ICommand oldCommand, ICommand newCommand)
	{
		EventHandler value = CanExecuteChanged;
		oldCommand.CanExecuteChanged -= value;
	}

	private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
	{
		EventHandler eventHandler = CanExecuteChanged;
		canExecuteChangedHandler = eventHandler;
		if (newCommand != null)
		{
			newCommand.CanExecuteChanged += canExecuteChangedHandler;
		}
	}

	private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is DropDownButton dropDownButton)
		{
			dropDownButton.OnCommandChanged((ICommand)e.OldValue, (ICommand)e.NewValue);
		}
	}

	protected virtual void OnCommandChanged(ICommand oldValue, ICommand newValue)
	{
		if (oldValue != null)
		{
			UnhookCommand(oldValue, newValue);
		}
		HookUpCommand(oldValue, newValue);
		CanExecuteChanged();
	}
}
