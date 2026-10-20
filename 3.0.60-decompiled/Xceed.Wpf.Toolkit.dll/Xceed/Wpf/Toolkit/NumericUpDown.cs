using System;
using System.Globalization;
using System.Windows;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public abstract class NumericUpDown<T> : UpDownBase<T>
{
	public static readonly DependencyProperty AutoMoveFocusProperty = DependencyProperty.Register("AutoMoveFocus", typeof(bool), typeof(NumericUpDown<T>), (PropertyMetadata)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty AutoSelectBehaviorProperty = DependencyProperty.Register("AutoSelectBehavior", typeof(AutoSelectBehavior), typeof(NumericUpDown<T>), (PropertyMetadata)new UIPropertyMetadata((object)AutoSelectBehavior.OnFocus));

	public static readonly DependencyProperty FormatStringProperty = DependencyProperty.Register("FormatString", typeof(string), typeof(NumericUpDown<T>), (PropertyMetadata)new UIPropertyMetadata((object)string.Empty, (PropertyChangedCallback)OnFormatStringChanged));

	public static readonly DependencyProperty IncrementProperty = DependencyProperty.Register("Increment", typeof(T), typeof(NumericUpDown<T>), new PropertyMetadata((object)default(T), (PropertyChangedCallback)OnIncrementChanged, (CoerceValueCallback)OnCoerceIncrement));

	[Obsolete("This property is obsolete and should no longer be used. Use NumericUpDown.AutoSelectBehavior instead.")]
	public static readonly DependencyProperty SelectAllOnGotFocusProperty = DependencyProperty.Register("SelectAllOnGotFocus", typeof(bool), typeof(NumericUpDown<T>), new PropertyMetadata((object)true));

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

	public string FormatString
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(FormatStringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatStringProperty, (object)value);
		}
	}

	public T Increment
	{
		get
		{
			return (T)((DependencyObject)this).GetValue(IncrementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IncrementProperty, (object)value);
		}
	}

	[Obsolete("This property is obsolete and should no longer be used. Use NumericUpDown.AutoSelectBehavior instead.")]
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

	private static void OnFormatStringChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is NumericUpDown<T> numericUpDown)
		{
			numericUpDown.OnFormatStringChanged((string)e.OldValue, (string)e.NewValue);
		}
	}

	protected virtual void OnFormatStringChanged(string oldValue, string newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SyncTextAndValueProperties(updateValueFromText: false, null);
		}
	}

	private static void OnIncrementChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is NumericUpDown<T> numericUpDown)
		{
			numericUpDown.OnIncrementChanged((T)e.OldValue, (T)e.NewValue);
		}
	}

	protected virtual void OnIncrementChanged(T oldValue, T newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			SetValidSpinDirection();
		}
	}

	private static object OnCoerceIncrement(DependencyObject d, object baseValue)
	{
		if (d is NumericUpDown<T> numericUpDown)
		{
			return numericUpDown.OnCoerceIncrement((T)baseValue);
		}
		return baseValue;
	}

	protected virtual T OnCoerceIncrement(T baseValue)
	{
		return baseValue;
	}

	protected static decimal ParsePercent(string text, IFormatProvider cultureInfo)
	{
		NumberFormatInfo instance = NumberFormatInfo.GetInstance(cultureInfo);
		text = text.Replace(instance.PercentSymbol, null);
		decimal num = decimal.Parse(text, NumberStyles.Any, instance);
		return num / 100m;
	}

	static NumericUpDown()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Obj, but got Unknown
	}
}
