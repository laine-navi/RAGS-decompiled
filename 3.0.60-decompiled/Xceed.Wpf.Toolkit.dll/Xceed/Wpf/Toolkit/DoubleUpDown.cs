using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit;

public class DoubleUpDown : CommonNumericUpDown<double>
{
	public static readonly DependencyProperty AllowInputSpecialValuesProperty;

	public AllowedSpecialValues AllowInputSpecialValues
	{
		get
		{
			return (AllowedSpecialValues)((DependencyObject)this).GetValue(AllowInputSpecialValuesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowInputSpecialValuesProperty, (object)value);
		}
	}

	static DoubleUpDown()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		AllowInputSpecialValuesProperty = DependencyProperty.Register("AllowInputSpecialValues", typeof(AllowedSpecialValues), typeof(DoubleUpDown), (PropertyMetadata)new UIPropertyMetadata((object)AllowedSpecialValues.None));
		CommonNumericUpDown<double>.UpdateMetadata(typeof(DoubleUpDown), 1.0, double.NegativeInfinity, double.PositiveInfinity);
	}

	public DoubleUpDown()
		: base((FromText)double.Parse, (FromDecimal)decimal.ToDouble, (Func<double, double, bool>)((double v1, double v2) => v1 < v2), (Func<double, double, bool>)((double v1, double v2) => v1 > v2))
	{
	}

	protected override double? OnCoerceIncrement(double? baseValue)
	{
		if (baseValue.HasValue && double.IsNaN(baseValue.Value))
		{
			throw new ArgumentException("NaN is invalid for Increment.");
		}
		return base.OnCoerceIncrement(baseValue);
	}

	protected override double? OnCoerceMaximum(double? baseValue)
	{
		if (baseValue.HasValue && double.IsNaN(baseValue.Value))
		{
			throw new ArgumentException("NaN is invalid for Maximum.");
		}
		return base.OnCoerceMaximum(baseValue);
	}

	protected override double? OnCoerceMinimum(double? baseValue)
	{
		if (baseValue.HasValue && double.IsNaN(baseValue.Value))
		{
			throw new ArgumentException("NaN is invalid for Minimum.");
		}
		return base.OnCoerceMinimum(baseValue);
	}

	protected override double IncrementValue(double value, double increment)
	{
		return value + increment;
	}

	protected override double DecrementValue(double value, double increment)
	{
		return value - increment;
	}

	protected override void SetValidSpinDirection()
	{
		if (Value.HasValue && double.IsInfinity(Value.Value) && Spinner != null)
		{
			Spinner.ValidSpinDirection = ValidSpinDirections.None;
		}
		else
		{
			base.SetValidSpinDirection();
		}
	}

	protected override double? ConvertTextToValue(string text)
	{
		double? result = base.ConvertTextToValue(text);
		if (result.HasValue)
		{
			if (double.IsNaN(result.Value))
			{
				TestInputSpecialValue(AllowInputSpecialValues, AllowedSpecialValues.NaN);
			}
			else if (double.IsPositiveInfinity(result.Value))
			{
				TestInputSpecialValue(AllowInputSpecialValues, AllowedSpecialValues.PositiveInfinity);
			}
			else if (double.IsNegativeInfinity(result.Value))
			{
				TestInputSpecialValue(AllowInputSpecialValues, AllowedSpecialValues.NegativeInfinity);
			}
		}
		return result;
	}
}
