using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class RoundedValueConverter : IValueConverter
{
	private int _precision;

	public int Precision
	{
		get
		{
			return _precision;
		}
		set
		{
			_precision = value;
		}
	}

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		if (value is double)
		{
			return Math.Round((double)value, _precision);
		}
		if (value is Point val)
		{
			double num = Math.Round(val.X, _precision);
			Point val2 = (Point)value;
			return (object)new Point(num, Math.Round(val2.Y, _precision));
		}
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return value;
	}
}
