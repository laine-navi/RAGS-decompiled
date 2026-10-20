using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class WindowControlBackgroundConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected Obj, but got Unknown
		Brush val = (Brush)values[0];
		double opacity = (double)values[1];
		if (val != null && ((DependencyObject)val).ReadLocalValue(Brush.OpacityProperty) == DependencyProperty.UnsetValue)
		{
			val = val.Clone();
			val.Opacity = opacity;
		}
		return val;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
