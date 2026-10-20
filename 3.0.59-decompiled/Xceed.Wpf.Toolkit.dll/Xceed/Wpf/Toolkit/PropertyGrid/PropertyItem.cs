using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

[TemplatePart(Name = "content", Type = typeof(ContentControl))]
public class PropertyItem : CustomPropertyItem
{
	private int _categoryOrder;

	public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PropertyItem), (PropertyMetadata)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty PropertyOrderProperty = DependencyProperty.Register("PropertyOrder", typeof(int), typeof(PropertyItem), (PropertyMetadata)new UIPropertyMetadata((object)0));

	public int CategoryOrder
	{
		get
		{
			return _categoryOrder;
		}
		internal set
		{
			if (_categoryOrder != value)
			{
				_categoryOrder = value;
				RaisePropertyChanged(() => CategoryOrder);
			}
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsReadOnlyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsReadOnlyProperty, (object)value);
		}
	}

	public int PropertyOrder
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(PropertyOrderProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyOrderProperty, (object)value);
		}
	}

	public PropertyDescriptor PropertyDescriptor { get; internal set; }

	public Type PropertyType
	{
		get
		{
			if (PropertyDescriptor == null)
			{
				return null;
			}
			return PropertyDescriptor.PropertyType;
		}
	}

	internal DescriptorPropertyDefinitionBase DescriptorDefinition { get; private set; }

	public object Instance { get; internal set; }

	protected override void OnIsExpandedChanged(bool oldValue, bool newValue)
	{
		if (newValue && ContainerHelper is ObjectContainerHelperBase objectContainerHelperBase)
		{
			objectContainerHelperBase.GenerateProperties();
		}
	}

	protected override void OnEditorChanged(FrameworkElement oldValue, FrameworkElement newValue)
	{
		if (oldValue != null)
		{
			oldValue.DataContext = null;
		}
		if (newValue != null)
		{
			newValue.DataContext = this;
		}
	}

	protected override object OnCoerceValueChanged(object baseValue)
	{
		BindingExpression bindingExpression = ((FrameworkElement)this).GetBindingExpression(CustomPropertyItem.ValueProperty);
		if (bindingExpression != null && bindingExpression.DataItem is DescriptorPropertyDefinitionBase)
		{
			DescriptorPropertyDefinitionBase descriptorPropertyDefinitionBase = bindingExpression.DataItem as DescriptorPropertyDefinitionBase;
			if (Validation.GetHasError((DependencyObject)(object)descriptorPropertyDefinitionBase))
			{
				ReadOnlyObservableCollection<ValidationError> errors = Validation.GetErrors((DependencyObject)(object)descriptorPropertyDefinitionBase);
				Validation.MarkInvalid((BindingExpressionBase)(object)bindingExpression, errors[0]);
			}
		}
		return baseValue;
	}

	protected override void OnValueChanged(object oldValue, object newValue)
	{
		base.OnValueChanged(oldValue, newValue);
	}

	private void OnDefinitionContainerHelperInvalidated(object sender, EventArgs e)
	{
		ObjectContainerHelperBase objectContainerHelperBase = (ObjectContainerHelperBase)(ContainerHelper = DescriptorDefinition.CreateContainerHelper(this));
		if (IsExpanded)
		{
			objectContainerHelperBase.GenerateProperties();
		}
	}

	internal PropertyItem(DescriptorPropertyDefinitionBase definition)
	{
		if (definition == null)
		{
			throw new ArgumentNullException("definition");
		}
		DescriptorDefinition = definition;
		ContainerHelper = definition.CreateContainerHelper(this);
		definition.ContainerHelperInvalidated += OnDefinitionContainerHelperInvalidated;
	}

	static PropertyItem()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
	}
}
