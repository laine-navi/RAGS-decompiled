using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal class ValueChangeHelper : DependencyObject
{
	private class BlankMultiValueConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return new object();
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException();
		}
	}

	private static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(ValueChangeHelper), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnValueChanged));

	private object Value
	{
		get
		{
			return ((DependencyObject)this).GetValue(ValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ValueProperty, value);
		}
	}

	public event EventHandler ValueChanged;

	private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
	{
		((ValueChangeHelper)(object)sender).RaiseValueChanged();
	}

	public ValueChangeHelper(Action changeCallback)
	{
		if (changeCallback == null)
		{
			throw new ArgumentNullException("changeCallback");
		}
		ValueChanged += (object s, EventArgs args) =>
		{
			changeCallback();
		};
	}

	public void UpdateValueSource(object sourceItem, string path)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		BindingBase binding = null;
		if (sourceItem != null && path != null)
		{
			Binding val = new Binding(path);
			val.Source = sourceItem;
			binding = (BindingBase)(object)val;
		}
		UpdateBinding(binding);
	}

	public void UpdateValueSource(IEnumerable sourceItems, string path)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		BindingBase binding = null;
		if (sourceItems != null && path != null)
		{
			MultiBinding val = new MultiBinding();
			val.Converter = (IMultiValueConverter)(object)new BlankMultiValueConverter();
			foreach (object sourceItem in sourceItems)
			{
				Collection<BindingBase> bindings = val.Bindings;
				Binding val2 = new Binding(path);
				val2.Source = sourceItem;
				bindings.Add((BindingBase)(object)val2);
			}
			binding = (BindingBase)(object)val;
		}
		UpdateBinding(binding);
	}

	private void UpdateBinding(BindingBase binding)
	{
		if (binding != null)
		{
			BindingOperations.SetBinding((DependencyObject)(object)this, ValueProperty, binding);
		}
		else
		{
			ClearBinding();
		}
	}

	private void ClearBinding()
	{
		BindingOperations.ClearBinding((DependencyObject)(object)this, ValueProperty);
	}

	private void RaiseValueChanged()
	{
		if (ValueChanged != null)
		{
			ValueChanged(this, EventArgs.Empty);
		}
	}

	static ValueChangeHelper()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
	}
}
