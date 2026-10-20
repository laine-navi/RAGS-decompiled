using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class BorderThicknessToStrokeThicknessConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Thickness val = (Thickness)value;
		return (val.Bottom + val.Left + val.Right + val.Top) / 4.0;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		int? num = (int?)value;
		int num2 = (num.HasValue ? num.Value : 0);
		return (object)new Thickness((double)num2, (double)num2, (double)num2, (double)num2);
	}
}
