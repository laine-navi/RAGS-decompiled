using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit;

public class SingleUpDown : CommonNumericUpDown<float>
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

	static SingleUpDown()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		AllowInputSpecialValuesProperty = DependencyProperty.Register("AllowInputSpecialValues", typeof(AllowedSpecialValues), typeof(SingleUpDown), (PropertyMetadata)new UIPropertyMetadata((object)AllowedSpecialValues.None));
		CommonNumericUpDown<float>.UpdateMetadata(typeof(SingleUpDown), 1f, float.NegativeInfinity, float.PositiveInfinity);
	}

	public SingleUpDown()
		: base((FromText)float.Parse, (FromDecimal)decimal.ToSingle, (Func<float, float, bool>)((float v1, float v2) => v1 < v2), (Func<float, float, bool>)((float v1, float v2) => v1 > v2))
	{
	}

	protected override float? OnCoerceIncrement(float? baseValue)
	{
		if (baseValue.HasValue && float.IsNaN(baseValue.Value))
		{
			throw new ArgumentException("NaN is invalid for Increment.");
		}
		return base.OnCoerceIncrement(baseValue);
	}

	protected override float? OnCoerceMaximum(float? baseValue)
	{
		if (baseValue.HasValue && float.IsNaN(baseValue.Value))
		{
			throw new ArgumentException("NaN is invalid for Maximum.");
		}
		return base.OnCoerceMaximum(baseValue);
	}

	protected override float? OnCoerceMinimum(float? baseValue)
	{
		if (baseValue.HasValue && float.IsNaN(baseValue.Value))
		{
			throw new ArgumentException("NaN is invalid for Minimum.");
		}
		return base.OnCoerceMinimum(baseValue);
	}

	protected override float IncrementValue(float value, float increment)
	{
		return value + increment;
	}

	protected override float DecrementValue(float value, float increment)
	{
		return value - increment;
	}

	protected override void SetValidSpinDirection()
	{
		if (Value.HasValue && float.IsInfinity(Value.Value) && Spinner != null)
		{
			Spinner.ValidSpinDirection = ValidSpinDirections.None;
		}
		else
		{
			base.SetValidSpinDirection();
		}
	}

	protected override float? ConvertTextToValue(string text)
	{
		float? result = base.ConvertTextToValue(text);
		if (result.HasValue)
		{
			if (float.IsNaN(result.Value))
			{
				TestInputSpecialValue(AllowInputSpecialValues, AllowedSpecialValues.NaN);
			}
			else if (float.IsPositiveInfinity(result.Value))
			{
				TestInputSpecialValue(AllowInputSpecialValues, AllowedSpecialValues.PositiveInfinity);
			}
			else if (float.IsNegativeInfinity(result.Value))
			{
				TestInputSpecialValue(AllowInputSpecialValues, AllowedSpecialValues.NegativeInfinity);
			}
		}
		return result;
	}
}
