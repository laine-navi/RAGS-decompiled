using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal class CommonPropertyExceptionValidationRule : ValidationRule
{
	private TypeConverter _propertyTypeConverter;

	private Type _type;

	internal CommonPropertyExceptionValidationRule(Type type)
	{
		_propertyTypeConverter = TypeDescriptor.GetConverter(type);
		_type = type;
	}

	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected Obj, but got Unknown
		ValidationResult result = new ValidationResult(true, (object)null);
		if (GeneralUtilities.CanConvertValue(value, _type))
		{
			try
			{
				_propertyTypeConverter.ConvertFrom(value);
			}
			catch (Exception ex)
			{
				result = new ValidationResult(false, (object)ex.Message);
			}
		}
		return result;
	}
}
