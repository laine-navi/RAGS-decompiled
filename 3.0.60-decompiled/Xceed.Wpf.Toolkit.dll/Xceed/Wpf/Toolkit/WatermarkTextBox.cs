using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public class WatermarkTextBox : AutoSelectTextBox
{
	[Obsolete("This property is obsolete and should no longer be used. Use AutoSelectTextBox.AutoSelectBehavior instead.")]
	public static readonly DependencyProperty SelectAllOnGotFocusProperty;

	public static readonly DependencyProperty WatermarkProperty;

	public static readonly DependencyProperty WatermarkTemplateProperty;

	[Obsolete("This property is obsolete and should no longer be used. Use AutoSelectTextBox.AutoSelectBehavior instead.")]
	public bool SelectAllOnGotFocus
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SelectAllOnGotFocusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAllOnGotFocusProperty, (object)value);
		}
	}

	public object Watermark
	{
		get
		{
			return ((DependencyObject)this).GetValue(WatermarkProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkProperty, value);
		}
	}

	public DataTemplate WatermarkTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (DataTemplate)((DependencyObject)this).GetValue(WatermarkTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WatermarkTemplateProperty, (object)value);
		}
	}

	static WatermarkTextBox()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		SelectAllOnGotFocusProperty = DependencyProperty.Register("SelectAllOnGotFocus", typeof(bool), typeof(WatermarkTextBox), new PropertyMetadata((object)false));
		WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(WatermarkTextBox), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		WatermarkTemplateProperty = DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(WatermarkTextBox), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WatermarkTextBox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(WatermarkTextBox)));
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		((FrameworkElement)this).OnGotFocus(e);
		if (SelectAllOnGotFocus)
		{
			((TextBoxBase)this).SelectAll();
		}
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (!((UIElement)this).IsKeyboardFocused && SelectAllOnGotFocus)
		{
			((RoutedEventArgs)e).Handled = true;
			((UIElement)this).Focus();
		}
		base.OnPreviewMouseLeftButtonDown(e);
	}
}
