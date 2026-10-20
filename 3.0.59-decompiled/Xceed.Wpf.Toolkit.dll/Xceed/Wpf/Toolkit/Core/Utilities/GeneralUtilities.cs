using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal sealed class GeneralUtilities : DependencyObject
{
	internal static readonly DependencyProperty StubValueProperty = DependencyProperty.RegisterAttached("StubValue", typeof(object), typeof(GeneralUtilities), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)256));

	private GeneralUtilities()
	{
	}

	internal static object GetStubValue(DependencyObject obj)
	{
		return obj.GetValue(StubValueProperty);
	}

	internal static void SetStubValue(DependencyObject obj, object value)
	{
		obj.SetValue(StubValueProperty, value);
	}

	public static object GetPathValue(object sourceObject, string path)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected Obj, but got Unknown
		GeneralUtilities generalUtilities = new GeneralUtilities();
		DependencyProperty stubValueProperty = StubValueProperty;
		Binding val = new Binding(path);
		val.Source = sourceObject;
		BindingOperations.SetBinding((DependencyObject)(object)generalUtilities, stubValueProperty, (BindingBase)(object)val);
		object stubValue = GetStubValue((DependencyObject)(object)generalUtilities);
		BindingOperations.ClearBinding((DependencyObject)(object)generalUtilities, StubValueProperty);
		return stubValue;
	}

	public static object GetBindingValue(object sourceObject, Binding binding)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		Binding val = new Binding();
		val.BindsDirectlyToSource = binding.BindsDirectlyToSource;
		val.Converter = binding.Converter;
		val.ConverterCulture = binding.ConverterCulture;
		val.ConverterParameter = binding.ConverterParameter;
		((BindingBase)val).FallbackValue = ((BindingBase)binding).FallbackValue;
		val.Mode = (BindingMode)2;
		val.Path = binding.Path;
		((BindingBase)val).StringFormat = ((BindingBase)binding).StringFormat;
		((BindingBase)val).TargetNullValue = ((BindingBase)binding).TargetNullValue;
		val.XPath = binding.XPath;
		Binding val2 = val;
		val2.Source = sourceObject;
		GeneralUtilities generalUtilities = new GeneralUtilities();
		BindingOperations.SetBinding((DependencyObject)(object)generalUtilities, StubValueProperty, (BindingBase)(object)val2);
		object stubValue = GetStubValue((DependencyObject)(object)generalUtilities);
		BindingOperations.ClearBinding((DependencyObject)(object)generalUtilities, StubValueProperty);
		return stubValue;
	}

	internal static bool CanConvertValue(object value, object targetType)
	{
		if (value != null && !object.Equals(value.GetType(), targetType))
		{
			return !object.Equals(targetType, typeof(object));
		}
		return false;
	}

	static GeneralUtilities()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
	}
}
