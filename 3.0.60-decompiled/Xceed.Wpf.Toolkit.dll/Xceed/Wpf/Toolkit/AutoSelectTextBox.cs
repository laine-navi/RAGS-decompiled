using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

public class AutoSelectTextBox : TextBox
{
	public static readonly DependencyProperty AutoSelectBehaviorProperty;

	public static readonly DependencyProperty AutoMoveFocusProperty;

	public static readonly RoutedEvent QueryMoveFocusEvent;

	public AutoSelectBehavior AutoSelectBehavior
	{
		get
		{
			return (AutoSelectBehavior)((DependencyObject)this).GetValue(AutoSelectBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoSelectBehaviorProperty, (object)value);
		}
	}

	public bool AutoMoveFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoMoveFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoMoveFocusProperty, (object)value);
		}
	}

	static AutoSelectTextBox()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected Obj, but got Unknown
		AutoSelectBehaviorProperty = DependencyProperty.Register("AutoSelectBehavior", typeof(AutoSelectBehavior), typeof(AutoSelectTextBox), (PropertyMetadata)new UIPropertyMetadata((object)AutoSelectBehavior.Never));
		AutoMoveFocusProperty = DependencyProperty.Register("AutoMoveFocus", typeof(bool), typeof(AutoSelectTextBox), (PropertyMetadata)new UIPropertyMetadata((object)false));
		QueryMoveFocusEvent = EventManager.RegisterRoutedEvent("QueryMoveFocus", (RoutingStrategy)1, typeof(QueryMoveFocusEventHandler), typeof(AutoSelectTextBox));
		AutomationProperties.AutomationIdProperty.OverrideMetadata(typeof(AutoSelectTextBox), (PropertyMetadata)new UIPropertyMetadata((object)"AutoSelectTextBox"));
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Invalid comparison between Unknown and I4
		if (!AutoMoveFocus)
		{
			((TextBoxBase)this).OnPreviewKeyDown(e);
			return;
		}
		if ((int)e.Key == 23 && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			((RoutedEventArgs)e).Handled = MoveFocusLeft();
		}
		if ((int)e.Key == 25 && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			((RoutedEventArgs)e).Handled = MoveFocusRight();
		}
		if (((int)e.Key == 24 || (int)e.Key == 19) && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			((RoutedEventArgs)e).Handled = MoveFocusUp();
		}
		if (((int)e.Key == 26 || (int)e.Key == 20) && ((int)Keyboard.Modifiers == 0 || (int)Keyboard.Modifiers == 2))
		{
			((RoutedEventArgs)e).Handled = MoveFocusDown();
		}
		((TextBoxBase)this).OnPreviewKeyDown(e);
	}

	protected override void OnPreviewGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		((UIElement)this).OnPreviewGotKeyboardFocus(e);
		if (AutoSelectBehavior == AutoSelectBehavior.OnFocus)
		{
			IInputElement oldFocus = e.OldFocus;
			if (!TreeHelper.IsDescendantOf((DependencyObject)(object)((oldFocus is DependencyObject) ? oldFocus : null), (DependencyObject)(object)this))
			{
				((TextBoxBase)this).SelectAll();
			}
		}
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		((UIElement)this).OnPreviewMouseLeftButtonDown(e);
		if (AutoSelectBehavior != AutoSelectBehavior.Never && !((UIElement)this).IsKeyboardFocusWithin)
		{
			((UIElement)this).Focus();
			((RoutedEventArgs)e).Handled = true;
		}
	}

	protected override void OnTextChanged(TextChangedEventArgs e)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		((TextBoxBase)this).OnTextChanged(e);
		if (AutoMoveFocus && ((TextBox)this).Text.Length != 0 && ((TextBox)this).Text.Length == ((TextBox)this).MaxLength && ((TextBox)this).CaretIndex == ((TextBox)this).MaxLength && CanMoveFocus((FocusNavigationDirection)5, reachedMax: true))
		{
			FocusNavigationDirection val = (FocusNavigationDirection)(((int)((FrameworkElement)this).FlowDirection == 0) ? 5 : 4);
			((UIElement)this).MoveFocus(new TraversalRequest(val));
		}
	}

	private bool CanMoveFocus(FocusNavigationDirection direction, bool reachedMax)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		QueryMoveFocusEventArgs e = new QueryMoveFocusEventArgs(direction, reachedMax);
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e);
		return e.CanMoveFocus;
	}

	private bool MoveFocusLeft()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		if ((int)((FrameworkElement)this).FlowDirection == 0)
		{
			if (((TextBox)this).CaretIndex == 0 && ((TextBox)this).SelectionLength == 0)
			{
				if (((RoutedCommand)ComponentCommands.MoveFocusBack).CanExecute((object)null, (IInputElement)(object)this))
				{
					((RoutedCommand)ComponentCommands.MoveFocusBack).Execute((object)null, (IInputElement)(object)this);
					return true;
				}
				if (CanMoveFocus((FocusNavigationDirection)4, reachedMax: false))
				{
					((UIElement)this).MoveFocus(new TraversalRequest((FocusNavigationDirection)4));
					return true;
				}
			}
		}
		else if (((TextBox)this).CaretIndex == ((TextBox)this).Text.Length && ((TextBox)this).SelectionLength == 0)
		{
			if (((RoutedCommand)ComponentCommands.MoveFocusBack).CanExecute((object)null, (IInputElement)(object)this))
			{
				((RoutedCommand)ComponentCommands.MoveFocusBack).Execute((object)null, (IInputElement)(object)this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)4, reachedMax: false))
			{
				((UIElement)this).MoveFocus(new TraversalRequest((FocusNavigationDirection)4));
				return true;
			}
		}
		return false;
	}

	private bool MoveFocusRight()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		if ((int)((FrameworkElement)this).FlowDirection == 0)
		{
			if (((TextBox)this).CaretIndex == ((TextBox)this).Text.Length && ((TextBox)this).SelectionLength == 0)
			{
				if (((RoutedCommand)ComponentCommands.MoveFocusForward).CanExecute((object)null, (IInputElement)(object)this))
				{
					((RoutedCommand)ComponentCommands.MoveFocusForward).Execute((object)null, (IInputElement)(object)this);
					return true;
				}
				if (CanMoveFocus((FocusNavigationDirection)5, reachedMax: false))
				{
					((UIElement)this).MoveFocus(new TraversalRequest((FocusNavigationDirection)5));
					return true;
				}
			}
		}
		else if (((TextBox)this).CaretIndex == 0 && ((TextBox)this).SelectionLength == 0)
		{
			if (((RoutedCommand)ComponentCommands.MoveFocusForward).CanExecute((object)null, (IInputElement)(object)this))
			{
				((RoutedCommand)ComponentCommands.MoveFocusForward).Execute((object)null, (IInputElement)(object)this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)5, reachedMax: false))
			{
				((UIElement)this).MoveFocus(new TraversalRequest((FocusNavigationDirection)5));
				return true;
			}
		}
		return false;
	}

	private bool MoveFocusUp()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		if (((TextBox)this).GetLineIndexFromCharacterIndex(((TextBox)this).SelectionStart) == 0)
		{
			if (((RoutedCommand)ComponentCommands.MoveFocusUp).CanExecute((object)null, (IInputElement)(object)this))
			{
				((RoutedCommand)ComponentCommands.MoveFocusUp).Execute((object)null, (IInputElement)(object)this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)6, reachedMax: false))
			{
				((UIElement)this).MoveFocus(new TraversalRequest((FocusNavigationDirection)6));
				return true;
			}
		}
		return false;
	}

	private bool MoveFocusDown()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		int lineIndexFromCharacterIndex = ((TextBox)this).GetLineIndexFromCharacterIndex(((TextBox)this).SelectionStart);
		if (lineIndexFromCharacterIndex == ((TextBox)this).LineCount - 1)
		{
			if (((RoutedCommand)ComponentCommands.MoveFocusDown).CanExecute((object)null, (IInputElement)(object)this))
			{
				((RoutedCommand)ComponentCommands.MoveFocusDown).Execute((object)null, (IInputElement)(object)this);
				return true;
			}
			if (CanMoveFocus((FocusNavigationDirection)7, reachedMax: false))
			{
				((UIElement)this).MoveFocus(new TraversalRequest((FocusNavigationDirection)7));
				return true;
			}
		}
		return false;
	}
}
