using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Converters;

public class StylableWindowClippingBorderConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		value.GetType();
		parameter.GetType();
		double num = (double)value - double.Parse((string)parameter);
		return (object)new Thickness(num, num, num, num);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
