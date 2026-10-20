using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class VisibilityToBoolConverter : IValueConverter
{
	private bool _inverted;

	private bool _not;

	public bool Inverted
	{
		get
		{
			return _inverted;
		}
		set
		{
			_inverted = value;
		}
	}

	public bool Not
	{
		get
		{
			return _not;
		}
		set
		{
			_not = value;
		}
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!Inverted)
		{
			return VisibilityToBool(value);
		}
		return BoolToVisibility(value);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!Inverted)
		{
			return BoolToVisibility(value);
		}
		return VisibilityToBool(value);
	}

	private object VisibilityToBool(object value)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		if (!(value is Visibility))
		{
			throw new InvalidOperationException(ErrorMessages.GetMessage("SuppliedValueWasNotVisibility"));
		}
		return ((int)(Visibility)value == 0) ^ Not;
	}

	private object BoolToVisibility(object value)
	{
		if (!(value is bool))
		{
			throw new InvalidOperationException(ErrorMessages.GetMessage("SuppliedValueWasNotBool"));
		}
		return (object)(Visibility)((!((bool)value ^ Not)) ? 2 : 0);
	}
}
