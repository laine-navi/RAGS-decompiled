using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_ResizeThumb", Type = typeof(Thumb))]
public class MultiLineTextEditor : ContentControl
{
	private const string PART_ResizeThumb = "PART_ResizeThumb";

	private Thumb _resizeThumb;

	public static readonly DependencyProperty DropDownHeightProperty;

	public static readonly DependencyProperty DropDownWidthProperty;

	public static readonly DependencyProperty IsOpenProperty;

	public static readonly DependencyProperty IsSpellCheckEnabledProperty;

	public static readonly DependencyProperty IsReadOnlyProperty;

	public static readonly DependencyProperty TextProperty;

	public static readonly DependencyProperty TextAlignmentProperty;

	public static readonly DependencyProperty TextWrappingProperty;

	public double DropDownHeight
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DropDownHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownHeightProperty, (object)value);
		}
	}

	public double DropDownWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(DropDownWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropDownWidthProperty, (object)value);
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

	public bool IsSpellCheckEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSpellCheckEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSpellCheckEnabledProperty, (object)value);
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsReadOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsReadOnlyProperty, (object)value);
		}
	}

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

	public TextAlignment TextAlignment
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (TextAlignment)((DependencyObject)this).GetValue(TextAlignmentProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(TextAlignmentProperty, (object)value);
		}
	}

	public TextWrapping TextWrapping
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (TextWrapping)((DependencyObject)this).GetValue(TextWrappingProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(TextWrappingProperty, (object)value);
		}
	}

	private static void OnIsOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MultiLineTextEditor multiLineTextEditor)
		{
			multiLineTextEditor.OnIsOpenChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsOpenChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnTextChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is MultiLineTextEditor multiLineTextEditor)
		{
			multiLineTextEditor.OnTextChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnTextChanged(string oldValue, string newValue)
	{
	}

	static MultiLineTextEditor()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected Obj, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected Obj, but got Unknown
		DropDownHeightProperty = DependencyProperty.Register("DropDownHeight", typeof(double), typeof(MultiLineTextEditor), (PropertyMetadata)new UIPropertyMetadata((object)150.0));
		DropDownWidthProperty = DependencyProperty.Register("DropDownWidth", typeof(double), typeof(MultiLineTextEditor), (PropertyMetadata)new UIPropertyMetadata((object)200.0));
		IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(MultiLineTextEditor), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsOpenChanged));
		IsSpellCheckEnabledProperty = DependencyProperty.Register("IsSpellCheckEnabled", typeof(bool), typeof(MultiLineTextEditor), (PropertyMetadata)new UIPropertyMetadata((object)false));
		IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(MultiLineTextEditor), (PropertyMetadata)new UIPropertyMetadata((object)false));
		TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MultiLineTextEditor), (PropertyMetadata)new FrameworkPropertyMetadata((object)string.Empty, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnTextChanged));
		TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(TextAlignment), typeof(MultiLineTextEditor), (PropertyMetadata)new UIPropertyMetadata((object)(TextAlignment)0));
		TextWrappingProperty = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(MultiLineTextEditor), (PropertyMetadata)new UIPropertyMetadata((object)(TextWrapping)1));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MultiLineTextEditor), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(MultiLineTextEditor)));
	}

	public MultiLineTextEditor()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected Obj, but got Unknown
		Keyboard.AddKeyDownHandler((DependencyObject)(object)this, (KeyEventHandler)OnKeyDown);
		Mouse.AddPreviewMouseDownOutsideCapturedElementHandler((DependencyObject)(object)this, (MouseButtonEventHandler)OnMouseDownOutsideCapturedElement);
	}

	public override void OnApplyTemplate()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_resizeThumb != null)
		{
			_resizeThumb.DragDelta -= ResizeThumb_DragDelta;
		}
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_ResizeThumb");
		_resizeThumb = (Thumb)(object)((templateChild is Thumb) ? templateChild : null);
		if (_resizeThumb != null)
		{
			_resizeThumb.DragDelta += ResizeThumb_DragDelta;
		}
	}

	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		if (!IsOpen)
		{
			if (KeyboardUtilities.IsKeyModifyingPopupState(e))
			{
				IsOpen = true;
				((RoutedEventArgs)e).Handled = true;
			}
		}
		else if (KeyboardUtilities.IsKeyModifyingPopupState(e) || (int)e.Key == 13 || (int)e.Key == 3)
		{
			CloseEditor();
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void OnMouseDownOutsideCapturedElement(object sender, MouseButtonEventArgs e)
	{
		CloseEditor();
	}

	private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
	{
		double num = DropDownHeight + e.VerticalChange;
		double num2 = DropDownWidth + e.HorizontalChange;
		if (num2 >= 0.0 && num >= 0.0)
		{
			DropDownWidth = num2;
			DropDownHeight = num;
		}
	}

	private void CloseEditor()
	{
		if (IsOpen)
		{
			IsOpen = false;
		}
		((UIElement)this).ReleaseMouseCapture();
	}
}
