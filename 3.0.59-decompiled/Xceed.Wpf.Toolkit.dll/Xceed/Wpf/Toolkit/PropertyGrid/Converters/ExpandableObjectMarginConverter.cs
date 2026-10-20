using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Converters;

public class ExpandableObjectMarginConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)value;
		return (object)new Thickness((double)(num * 15), 0.0, 0.0, 0.0);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
