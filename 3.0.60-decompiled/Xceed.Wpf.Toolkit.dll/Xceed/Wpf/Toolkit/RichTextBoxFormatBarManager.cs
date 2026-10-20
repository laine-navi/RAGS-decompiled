using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

public class RichTextBoxFormatBarManager : DependencyObject
{
	private const double _hideAdornerDistance = 150.0;

	private RichTextBox _richTextBox;

	private UIElementAdorner<Control> _adorner;

	private IRichTextBoxFormatBar _toolbar;

	private Window _parentWindow;

	public static readonly DependencyProperty FormatBarProperty = DependencyProperty.RegisterAttached("FormatBar", typeof(IRichTextBoxFormatBar), typeof(RichTextBox), new PropertyMetadata((object)null, (PropertyChangedCallback)OnFormatBarPropertyChanged));

	public bool IsAdornerVisible
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			return (int)((UIElement)_adorner).Visibility == 0;
		}
	}

	public static void SetFormatBar(UIElement element, IRichTextBoxFormatBar value)
	{
		((DependencyObject)element).SetValue(FormatBarProperty, (object)value);
	}

	public static IRichTextBoxFormatBar GetFormatBar(UIElement element)
	{
		return (IRichTextBoxFormatBar)((DependencyObject)element).GetValue(FormatBarProperty);
	}

	private static void OnFormatBarPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		RichTextBox val = (RichTextBox)(object)((d is RichTextBox) ? d : null);
		if (val == null)
		{
			throw new Exception("A FormatBar can only be applied to a RichTextBox.");
		}
		RichTextBoxFormatBarManager richTextBoxFormatBarManager = new RichTextBoxFormatBarManager();
		richTextBoxFormatBarManager.AttachFormatBarToRichtextBox(val, e.NewValue as IRichTextBoxFormatBar);
	}

	private void RichTextBox_MouseButtonUp(object sender, MouseButtonEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		if ((int)e.ChangedButton == 0 && (int)((MouseEventArgs)e).LeftButton == 0)
		{
			TextRange val = new TextRange(((TextRange)_richTextBox.Selection).Start, ((TextRange)_richTextBox.Selection).End);
			if (val.Text.Length > 0 && !string.IsNullOrWhiteSpace(val.Text))
			{
				ShowAdorner();
			}
			else
			{
				HideAdorner();
			}
			((RoutedEventArgs)e).Handled = true;
		}
		else
		{
			HideAdorner();
		}
	}

	private void OnPreviewMouseMoveParentWindow(object sender, MouseEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition((IInputElement)(object)_adorner);
		double val = 0.0;
		if ((_adorner.Child != null && _adorner.Child is IRichTextBoxFormatBar && ((IRichTextBoxFormatBar)_adorner.Child).PreventDisplayFadeOut) || (position.X >= 0.0 && position.X <= ((FrameworkElement)_adorner).ActualWidth && position.Y >= 0.0 && position.Y <= ((FrameworkElement)_adorner).ActualHeight))
		{
			return;
		}
		if (position.X < -150.0 || position.X > ((FrameworkElement)_adorner).ActualWidth + 150.0 || position.Y < -150.0 || position.Y > ((FrameworkElement)_adorner).ActualHeight + 150.0)
		{
			HideAdorner();
			return;
		}
		if (position.X < 0.0)
		{
			val = 0.0 - position.X;
		}
		else if (position.X > ((FrameworkElement)_adorner).ActualWidth)
		{
			val = position.X - ((FrameworkElement)_adorner).ActualWidth;
		}
		if (position.Y < 0.0)
		{
			val = Math.Max(val, 0.0 - position.Y);
		}
		else if (position.Y > ((FrameworkElement)_adorner).ActualHeight)
		{
			val = Math.Max(val, position.Y - ((FrameworkElement)_adorner).ActualHeight);
		}
		((UIElement)_adorner).Opacity = 1.0 - Math.Min(val, 100.0) / 100.0;
	}

	private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (!((UIElement)_richTextBox).IsFocused && !((TextRange)_richTextBox.Selection).IsEmpty)
		{
			((UIElement)_richTextBox).Focus();
		}
	}

	private void AttachFormatBarToRichtextBox(RichTextBox richTextBox, IRichTextBoxFormatBar formatBar)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected Obj, but got Unknown
		_richTextBox = richTextBox;
		((UIElement)_richTextBox).AddHandler(Mouse.MouseUpEvent, (Delegate)new MouseButtonEventHandler(RichTextBox_MouseButtonUp), true);
		((TextBoxBase)_richTextBox).TextChanged += RichTextBox_TextChanged;
		_adorner = new UIElementAdorner<Control>((UIElement)(object)_richTextBox);
		formatBar.Target = _richTextBox;
		_toolbar = formatBar;
	}

	private void ShowAdorner()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		if ((int)((UIElement)_adorner).Visibility != 0)
		{
			VerifyAdornerLayer();
			IRichTextBoxFormatBar toolbar = _toolbar;
			Control val = (Control)((toolbar is Control) ? toolbar : null);
			if (_adorner.Child == null)
			{
				_adorner.Child = val;
			}
			((FrameworkElement)val).ApplyTemplate();
			_toolbar.Update();
			((UIElement)_adorner).Visibility = (Visibility)0;
			PositionFormatBar(val);
			_parentWindow = TreeHelper.FindParent<Window>((DependencyObject)(object)_adorner);
			if (_parentWindow != null)
			{
				Mouse.AddMouseMoveHandler((DependencyObject)(object)_parentWindow, (MouseEventHandler)OnPreviewMouseMoveParentWindow);
			}
		}
	}

	private void PositionFormatBar(Control adorningEditor)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition((IInputElement)(object)_richTextBox);
		double num = position.X;
		double num2 = position.Y - 15.0 - ((FrameworkElement)adorningEditor).ActualHeight;
		if (num2 < 0.0)
		{
			num2 = position.Y + 10.0;
		}
		if (num + ((FrameworkElement)adorningEditor).ActualWidth > ((FrameworkElement)_richTextBox).ActualWidth - 20.0)
		{
			num -= ((FrameworkElement)adorningEditor).ActualWidth - (((FrameworkElement)_richTextBox).ActualWidth - num);
		}
		_adorner.SetOffsets(num, num2);
	}

	private bool VerifyAdornerLayer()
	{
		if (((FrameworkElement)_adorner).Parent != null)
		{
			return true;
		}
		AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual)(object)_richTextBox);
		if (adornerLayer == null)
		{
			return false;
		}
		adornerLayer.Add((Adorner)(object)_adorner);
		return true;
	}

	private void HideAdorner()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		if (IsAdornerVisible)
		{
			((UIElement)_adorner).Visibility = (Visibility)2;
			if (_parentWindow != null)
			{
				Mouse.RemoveMouseMoveHandler((DependencyObject)(object)_parentWindow, (MouseEventHandler)OnPreviewMouseMoveParentWindow);
			}
		}
	}

	static RichTextBoxFormatBarManager()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
	}
}
