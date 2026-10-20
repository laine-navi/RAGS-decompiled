using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class CustomPropertyItem : PropertyItemBase
{
	public static readonly DependencyProperty CategoryProperty = DependencyProperty.Register("Category", typeof(string), typeof(CustomPropertyItem), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(CustomPropertyItem), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnValueChanged, (CoerceValueCallback)OnCoerceValueChanged));

	public string Category
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CategoryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CategoryProperty, (object)value);
		}
	}

	public object Value
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

	internal CustomPropertyItem()
	{
	}

	private static object OnCoerceValueChanged(DependencyObject o, object baseValue)
	{
		if (o is CustomPropertyItem customPropertyItem)
		{
			return customPropertyItem.OnCoerceValueChanged(baseValue);
		}
		return baseValue;
	}

	protected virtual object OnCoerceValueChanged(object baseValue)
	{
		return baseValue;
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is CustomPropertyItem customPropertyItem)
		{
			customPropertyItem.OnValueChanged(e.OldValue, e.NewValue);
		}
	}

	protected virtual void OnValueChanged(object oldValue, object newValue)
	{
		if (((FrameworkElement)this).IsInitialized)
		{
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new PropertyValueChangedEventArgs(PropertyGrid.PropertyValueChangedEvent, this, oldValue, newValue));
		}
	}

	static CustomPropertyItem()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0060: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
	}
}
