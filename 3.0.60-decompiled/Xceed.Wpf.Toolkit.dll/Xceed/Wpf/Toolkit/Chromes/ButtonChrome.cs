using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.Chromes;

public class ButtonChrome : ContentControl
{
	public static readonly DependencyProperty CornerRadiusProperty;

	public static readonly DependencyProperty InnerCornerRadiusProperty;

	public static readonly DependencyProperty RenderCheckedProperty;

	public static readonly DependencyProperty RenderEnabledProperty;

	public static readonly DependencyProperty RenderFocusedProperty;

	public static readonly DependencyProperty RenderMouseOverProperty;

	public static readonly DependencyProperty RenderNormalProperty;

	public static readonly DependencyProperty RenderPressedProperty;

	public CornerRadius CornerRadius
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (CornerRadius)((DependencyObject)this).GetValue(CornerRadiusProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(CornerRadiusProperty, (object)value);
		}
	}

	public CornerRadius InnerCornerRadius
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (CornerRadius)((DependencyObject)this).GetValue(InnerCornerRadiusProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(InnerCornerRadiusProperty, (object)value);
		}
	}

	public bool RenderChecked
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderCheckedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderCheckedProperty, (object)value);
		}
	}

	public bool RenderEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderEnabledProperty, (object)value);
		}
	}

	public bool RenderFocused
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderFocusedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderFocusedProperty, (object)value);
		}
	}

	public bool RenderMouseOver
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderMouseOverProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderMouseOverProperty, (object)value);
		}
	}

	public bool RenderNormal
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderNormalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderNormalProperty, (object)value);
		}
	}

	public bool RenderPressed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderPressedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderPressedProperty, (object)value);
		}
	}

	private static void OnCornerRadiusChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnCornerRadiusChanged((CornerRadius)e.OldValue, (CornerRadius)e.NewValue);
		}
	}

	protected virtual void OnCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		CornerRadius innerCornerRadius = new CornerRadius(Math.Max(0.0, newValue.TopLeft - 1.0), Math.Max(0.0, newValue.TopRight - 1.0), Math.Max(0.0, newValue.BottomRight - 1.0), Math.Max(0.0, newValue.BottomLeft - 1.0));
		InnerCornerRadius = innerCornerRadius;
	}

	private static void OnInnerCornerRadiusChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnInnerCornerRadiusChanged((CornerRadius)e.OldValue, (CornerRadius)e.NewValue);
		}
	}

	protected virtual void OnInnerCornerRadiusChanged(CornerRadius oldValue, CornerRadius newValue)
	{
	}

	private static void OnRenderCheckedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderCheckedChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnRenderCheckedChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderEnabledChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnRenderEnabledChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderFocusedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderFocusedChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnRenderFocusedChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderMouseOverChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderMouseOverChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnRenderMouseOverChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderNormalChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderNormalChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnRenderNormalChanged(bool oldValue, bool newValue)
	{
	}

	private static void OnRenderPressedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ButtonChrome buttonChrome)
		{
			buttonChrome.OnRenderPressedChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnRenderPressedChanged(bool oldValue, bool newValue)
	{
	}

	static ButtonChrome()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Obj, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected Obj, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected Obj, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected Obj, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected Obj, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected Obj, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected Obj, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Obj, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected Obj, but got Unknown
		CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)default(CornerRadius), (PropertyChangedCallback)OnCornerRadiusChanged));
		InnerCornerRadiusProperty = DependencyProperty.Register("InnerCornerRadius", typeof(CornerRadius), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)default(CornerRadius), (PropertyChangedCallback)OnInnerCornerRadiusChanged));
		RenderCheckedProperty = DependencyProperty.Register("RenderChecked", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnRenderCheckedChanged));
		RenderEnabledProperty = DependencyProperty.Register("RenderEnabled", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)OnRenderEnabledChanged));
		RenderFocusedProperty = DependencyProperty.Register("RenderFocused", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnRenderFocusedChanged));
		RenderMouseOverProperty = DependencyProperty.Register("RenderMouseOver", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnRenderMouseOverChanged));
		RenderNormalProperty = DependencyProperty.Register("RenderNormal", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)OnRenderNormalChanged));
		RenderPressedProperty = DependencyProperty.Register("RenderPressed", typeof(bool), typeof(ButtonChrome), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnRenderPressedChanged));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonChrome), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(ButtonChrome)));
	}
}
