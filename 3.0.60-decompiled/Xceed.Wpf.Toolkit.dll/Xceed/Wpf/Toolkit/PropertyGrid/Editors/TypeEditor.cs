using System.Windows;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public abstract class TypeEditor<T> : ITypeEditor where T : FrameworkElement, new()
{
	protected T Editor { get; set; }

	protected DependencyProperty ValueProperty { get; set; }

	public virtual FrameworkElement ResolveEditor(PropertyItem propertyItem)
	{
		Editor = CreateEditor();
		SetValueDependencyProperty();
		SetControlProperties();
		ResolveValueBinding(propertyItem);
		return (FrameworkElement)(object)Editor;
	}

	protected virtual T CreateEditor()
	{
		return new T();
	}

	protected virtual IValueConverter CreateValueConverter()
	{
		return null;
	}

	protected virtual void ResolveValueBinding(PropertyItem propertyItem)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		Binding val = new Binding("Value");
		val.Source = propertyItem;
		val.UpdateSourceTrigger = (UpdateSourceTrigger)(Editor is InputBase);
		val.Mode = (BindingMode)(propertyItem.IsReadOnly ? 1 : 0);
		val.Converter = CreateValueConverter();
		BindingOperations.SetBinding((DependencyObject)(object)Editor, ValueProperty, (BindingBase)(object)val);
	}

	protected virtual void SetControlProperties()
	{
	}

	protected abstract void SetValueDependencyProperty();
}
