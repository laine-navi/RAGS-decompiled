using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class ColorToSolidColorBrushConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (value != null)
		{
			return (object)new SolidColorBrush((Color)value);
		}
		return value;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (value != null)
		{
			return ((SolidColorBrush)value).Color;
		}
		return value;
	}
}
