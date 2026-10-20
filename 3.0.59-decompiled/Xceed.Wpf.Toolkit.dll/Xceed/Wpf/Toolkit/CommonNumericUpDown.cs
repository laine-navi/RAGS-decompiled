using System;
using System.Globalization;
using System.IO;
using System.Windows;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public abstract class CommonNumericUpDown<T> : NumericUpDown<T?> where T : struct, IFormattable, IComparable<T>
{
	protected delegate T FromText(string s, NumberStyles style, IFormatProvider provider);

	protected delegate T FromDecimal(decimal d);

	private FromText _fromText;

	private FromDecimal _fromDecimal;

	private Func<T, T, bool> _fromLowerThan;

	private Func<T, T, bool> _fromGreaterThan;

	public static readonly DependencyProperty ParsingNumberStyleProperty = DependencyProperty.Register("ParsingNumberStyle", typeof(NumberStyles), typeof(CommonNumericUpDown<T>), (PropertyMetadata)new UIPropertyMetadata((object)NumberStyles.Any));

	public NumberStyles ParsingNumberStyle
	{
		get
		{
			return (NumberStyles)((DependencyObject)this).GetValue(ParsingNumberStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ParsingNumberStyleProperty, (object)value);
		}
	}

	protected CommonNumericUpDown(FromText fromText, FromDecimal fromDecimal, Func<T, T, bool> fromLowerThan, Func<T, T, bool> fromGreaterThan)
	{
		if (fromText == null)
		{
			throw new ArgumentNullException("parseMethod");
		}
		if (fromDecimal == null)
		{
			throw new ArgumentNullException("fromDecimal");
		}
		if (fromLowerThan == null)
		{
			throw new ArgumentNullException("fromLowerThan");
		}
		if (fromGreaterThan == null)
		{
			throw new ArgumentNullException("fromGreaterThan");
		}
		_fromText = fromText;
		_fromDecimal = fromDecimal;
		_fromLowerThan = fromLowerThan;
		_fromGreaterThan = fromGreaterThan;
	}

	protected static void UpdateMetadata(Type type, T? increment, T? minValue, T? maxValue)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(type, (PropertyMetadata)new FrameworkPropertyMetadata((object)type));
		UpdateMetadataCommon(type, increment, minValue, maxValue);
	}

	private static void UpdateMetadataCommon(Type type, T? increment, T? minValue, T? maxValue)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		NumericUpDown<T?>.IncrementProperty.OverrideMetadata(type, (PropertyMetadata)new FrameworkPropertyMetadata((object)increment));
		UpDownBase<T?>.MaximumProperty.OverrideMetadata(type, (PropertyMetadata)new FrameworkPropertyMetadata((object)maxValue));
		UpDownBase<T?>.MinimumProperty.OverrideMetadata(type, (PropertyMetadata)new FrameworkPropertyMetadata((object)minValue));
	}

	protected void TestInputSpecialValue(AllowedSpecialValues allowedValues, AllowedSpecialValues valueToCompare)
	{
		if ((allowedValues & valueToCompare) != valueToCompare)
		{
			switch (valueToCompare)
			{
			case AllowedSpecialValues.NaN:
				throw new InvalidDataException("Value to parse shouldn't be NaN.");
			case AllowedSpecialValues.PositiveInfinity:
				throw new InvalidDataException("Value to parse shouldn't be Positive Infinity.");
			case AllowedSpecialValues.NegativeInfinity:
				throw new InvalidDataException("Value to parse shouldn't be Negative Infinity.");
			case AllowedSpecialValues.NaN | AllowedSpecialValues.PositiveInfinity:
				break;
			}
		}
	}

	private bool IsLowerThan(T? value1, T? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return _fromLowerThan(value1.Value, value2.Value);
	}

	private bool IsGreaterThan(T? value1, T? value2)
	{
		if (!value1.HasValue || !value2.HasValue)
		{
			return false;
		}
		return _fromGreaterThan(value1.Value, value2.Value);
	}

	private bool HandleNullSpin()
	{
		if (!Value.HasValue)
		{
			T value = (DefaultValue.HasValue ? DefaultValue.Value : default(T));
			Value = CoerceValueMinMax(value);
			return true;
		}
		if (!Increment.HasValue)
		{
			return true;
		}
		return false;
	}

	internal bool IsValid(T? value)
	{
		if (!IsLowerThan(value, Minimum))
		{
			return !IsGreaterThan(value, Maximum);
		}
		return false;
	}

	private T? CoerceValueMinMax(T value)
	{
		if (IsLowerThan(value, Minimum))
		{
			return Minimum;
		}
		if (IsGreaterThan(value, Maximum))
		{
			return Maximum;
		}
		return value;
	}

	protected override void OnIncrement()
	{
		if (!HandleNullSpin())
		{
			T value = IncrementValue(Value.Value, Increment.Value);
			Value = CoerceValueMinMax(value);
		}
	}

	protected override void OnDecrement()
	{
		if (!HandleNullSpin())
		{
			T value = DecrementValue(Value.Value, Increment.Value);
			Value = CoerceValueMinMax(value);
		}
	}

	protected override T? ConvertTextToValue(string text)
	{
		T? val = null;
		if (string.IsNullOrEmpty(text))
		{
			return val;
		}
		string objA = ConvertValueToText();
		if (object.Equals(objA, text))
		{
			return Value;
		}
		val = (FormatString.Contains("P") ? _fromDecimal(NumericUpDown<T?>.ParsePercent(text, CultureInfo)) : _fromText(text, ParsingNumberStyle, CultureInfo));
		if (ClipValueToMinMax)
		{
			return GetClippedMinMaxValue();
		}
		ValidateDefaultMinMax(val);
		return val;
	}

	protected override string ConvertValueToText()
	{
		if (!Value.HasValue)
		{
			return string.Empty;
		}
		return Value.Value.ToString(FormatString, CultureInfo);
	}

	protected override void SetValidSpinDirection()
	{
		ValidSpinDirections validSpinDirections = ValidSpinDirections.None;
		if (Increment.HasValue && !IsReadOnly)
		{
			if (IsLowerThan(Value, Maximum) || !Value.HasValue)
			{
				validSpinDirections |= ValidSpinDirections.Increase;
			}
			if (IsGreaterThan(Value, Minimum) || !Value.HasValue)
			{
				validSpinDirections |= ValidSpinDirections.Decrease;
			}
		}
		if (Spinner != null)
		{
			Spinner.ValidSpinDirection = validSpinDirections;
		}
	}

	private T? GetClippedMinMaxValue()
	{
		T? val = (FormatString.Contains("P") ? _fromDecimal(NumericUpDown<T?>.ParsePercent(Text, CultureInfo)) : _fromText(Text, ParsingNumberStyle, CultureInfo));
		if (IsGreaterThan(val, Maximum))
		{
			return Maximum;
		}
		if (IsLowerThan(val, Minimum))
		{
			return Minimum;
		}
		return val;
	}

	private void ValidateDefaultMinMax(T? value)
	{
		if (!object.Equals(value, DefaultValue))
		{
			if (IsLowerThan(value, Minimum))
			{
				throw new ArgumentOutOfRangeException("Minimum", $"Value must be greater than MinValue of {Minimum}");
			}
			if (IsGreaterThan(value, Maximum))
			{
				throw new ArgumentOutOfRangeException("Maximum", $"Value must be less than MaxValue of {Maximum}");
			}
		}
	}

	protected abstract T IncrementValue(T value, T increment);

	protected abstract T DecrementValue(T value, T increment);

	static CommonNumericUpDown()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected Obj, but got Unknown
	}
}
