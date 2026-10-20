using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class WindowContentBorderMarginConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		double num = (double)values[0];
		double num2 = (double)values[1];
		return (string)parameter switch
		{
			"0" => (object)new Thickness(num, 0.0, num, num2), 
			"1" => (object)new Thickness(0.0, 0.0, num, num2), 
			"2" => (object)new Thickness(0.0, 0.0, num, 0.0), 
			_ => throw new NotSupportedException("'parameter' for WindowContentBorderMarginConverter is not valid."), 
		};
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
