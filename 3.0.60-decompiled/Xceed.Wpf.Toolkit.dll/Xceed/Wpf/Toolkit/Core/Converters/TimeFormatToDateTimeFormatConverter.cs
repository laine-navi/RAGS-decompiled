using System;
using System.Globalization;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class TimeFormatToDateTimeFormatConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (TimeFormat)value switch
		{
			TimeFormat.Custom => (object)DateTimeFormat.Custom, 
			TimeFormat.ShortTime => DateTimeFormat.ShortTime, 
			TimeFormat.LongTime => DateTimeFormat.LongTime, 
			_ => DateTimeFormat.ShortTime, 
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
