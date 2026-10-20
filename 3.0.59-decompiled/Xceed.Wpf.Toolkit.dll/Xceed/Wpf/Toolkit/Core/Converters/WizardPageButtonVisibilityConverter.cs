using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Converters;

public class WizardPageButtonVisibilityConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		if (values == null || values.Length != 2)
		{
			throw new ArgumentException("Wrong number of arguments for WizardPageButtonVisibilityConverter.");
		}
		Visibility val = (Visibility)((values[0] == null || values[0] == DependencyProperty.UnsetValue) ? 1 : ((int)(Visibility)values[0]));
		WizardPageButtonVisibility wizardPageButtonVisibility = ((values[1] == null || values[1] == DependencyProperty.UnsetValue) ? WizardPageButtonVisibility.Hidden : ((WizardPageButtonVisibility)values[1]));
		Visibility val2 = (Visibility)0;
		switch (wizardPageButtonVisibility)
		{
		case WizardPageButtonVisibility.Inherit:
			val2 = val;
			break;
		case WizardPageButtonVisibility.Collapsed:
			val2 = (Visibility)2;
			break;
		case WizardPageButtonVisibility.Hidden:
			val2 = (Visibility)1;
			break;
		case WizardPageButtonVisibility.Visible:
			val2 = (Visibility)0;
			break;
		}
		return val2;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
