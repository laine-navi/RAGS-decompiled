using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class SolidColorBrushToColorConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		SolidColorBrush val = (SolidColorBrush)((value is SolidColorBrush) ? value : null);
		if (val != null)
		{
			return val.Color;
		}
		return (object)default(Color);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		if (value != null)
		{
			Color val = (Color)value;
			return (object)new SolidColorBrush(val);
		}
		return null;
	}
}
