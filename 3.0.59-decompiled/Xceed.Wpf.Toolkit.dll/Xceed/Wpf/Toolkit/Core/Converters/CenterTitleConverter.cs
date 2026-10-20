using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class CenterTitleConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		Size val = (Size)values[0];
		double width = val.Width;
		double num = (double)values[1];
		ColumnDefinitionCollection val2 = (ColumnDefinitionCollection)values[2];
		double actualWidth = val2[2].ActualWidth;
		double actualWidth2 = val2[3].ActualWidth;
		if (width + actualWidth2 * 2.0 < num)
		{
			return 1;
		}
		if (width < actualWidth)
		{
			return 2;
		}
		return 3;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
