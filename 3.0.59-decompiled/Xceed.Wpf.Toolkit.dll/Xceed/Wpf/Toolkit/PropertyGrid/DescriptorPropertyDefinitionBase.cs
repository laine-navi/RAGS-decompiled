using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal abstract class DescriptorPropertyDefinitionBase : DependencyObject
{
	private string _category;

	private string _categoryValue;

	private string _description;

	private string _displayName;

	private int _displayOrder;

	private bool _expandableAttribute;

	private bool _isReadOnly;

	private IList<Type> _newItemTypes;

	private IEnumerable<CommandBinding> _commandBindings;

	public static readonly DependencyProperty AdvancedOptionsIconProperty = DependencyProperty.Register("AdvancedOptionsIcon", typeof(ImageSource), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty AdvancedOptionsTooltipProperty = DependencyProperty.Register("AdvancedOptionsTooltip", typeof(object), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty IsExpandableProperty = DependencyProperty.Register("IsExpandable", typeof(bool), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)new UIPropertyMetadata((object)false));

	public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(DescriptorPropertyDefinitionBase), (PropertyMetadata)new UIPropertyMetadata((object)null, (PropertyChangedCallback)OnValueChanged));

	internal abstract PropertyDescriptor PropertyDescriptor { get; }

	public ImageSource AdvancedOptionsIcon
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (ImageSource)((DependencyObject)this).GetValue(AdvancedOptionsIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsIconProperty, (object)value);
		}
	}

	public object AdvancedOptionsTooltip
	{
		get
		{
			return ((DependencyObject)this).GetValue(AdvancedOptionsTooltipProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AdvancedOptionsTooltipProperty, value);
		}
	}

	public bool IsExpandable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsExpandableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsExpandableProperty, (object)value);
		}
	}

	public string Category
	{
		get
		{
			return _category;
		}
		internal set
		{
			_category = value;
		}
	}

	public string CategoryValue
	{
		get
		{
			return _categoryValue;
		}
		internal set
		{
			_categoryValue = value;
		}
	}

	public IEnumerable<CommandBinding> CommandBindings => _commandBindings;

	public string DisplayName
	{
		get
		{
			return _displayName;
		}
		internal set
		{
			_displayName = value;
		}
	}

	public string Description
	{
		get
		{
			return _description;
		}
		internal set
		{
			_description = value;
		}
	}

	public int DisplayOrder
	{
		get
		{
			return _displayOrder;
		}
		internal set
		{
			_displayOrder = value;
		}
	}

	public bool IsReadOnly => _isReadOnly;

	public IList<Type> NewItemTypes => _newItemTypes;

	public string PropertyName => PropertyDescriptor.Name;

	public Type PropertyType => PropertyDescriptor.PropertyType;

	internal bool ExpandableAttribute
	{
		get
		{
			return _expandableAttribute;
		}
		set
		{
			_expandableAttribute = value;
			UpdateIsExpandable();
		}
	}

	internal bool IsPropertyGridCategorized { get; set; }

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

	public event EventHandler ContainerHelperInvalidated;

	internal DescriptorPropertyDefinitionBase(bool isPropertyGridCategorized)
	{
		IsPropertyGridCategorized = isPropertyGridCategorized;
	}

	protected virtual string ComputeCategory()
	{
		return null;
	}

	protected virtual string ComputeCategoryValue()
	{
		return null;
	}

	protected virtual string ComputeDescription()
	{
		return null;
	}

	protected virtual int ComputeDisplayOrder(bool isPropertyGridCategorized)
	{
		return int.MaxValue;
	}

	protected virtual bool ComputeExpandableAttribute()
	{
		return false;
	}

	protected abstract bool ComputeIsExpandable();

	protected virtual IList<Type> ComputeNewItemTypes()
	{
		return null;
	}

	protected virtual bool ComputeIsReadOnly()
	{
		return false;
	}

	protected virtual bool ComputeCanResetValue()
	{
		return false;
	}

	protected virtual object ComputeAdvancedOptionsTooltip()
	{
		return null;
	}

	protected virtual void ResetValue()
	{
	}

	protected abstract BindingBase CreateValueBinding();

	internal abstract ObjectContainerHelperBase CreateContainerHelper(IPropertyContainer parent);

	internal void RaiseContainerHelperInvalidated()
	{
		if (ContainerHelperInvalidated != null)
		{
			ContainerHelperInvalidated(this, EventArgs.Empty);
		}
	}

	internal virtual ITypeEditor CreateDefaultEditor()
	{
		return null;
	}

	internal virtual ITypeEditor CreateAttributeEditor()
	{
		return null;
	}

	internal void UpdateAdvanceOptionsForItem(MarkupObject markupObject, DependencyObject dependencyObject, DependencyPropertyDescriptor dpDescriptor, out object tooltip)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected I4, but got Unknown
		tooltip = StringConstants.AdvancedProperties;
		bool flag = false;
		bool flag2 = false;
		MarkupProperty val = markupObject.Properties.Where((MarkupProperty p) => p.Name == PropertyName).FirstOrDefault();
		if (val != null && val.PropertyType != typeof(object) && !val.PropertyType.IsEnum)
		{
			flag = val.Value is Style;
			flag2 = val.Value is DynamicResourceExtension;
		}
		if (flag || flag2)
		{
			tooltip = StringConstants.Resource;
		}
		else
		{
			if (dependencyObject == null || dpDescriptor == null)
			{
				return;
			}
			if (BindingOperations.GetBindingExpressionBase(dependencyObject, dpDescriptor.DependencyProperty) != null)
			{
				tooltip = StringConstants.Databinding;
				return;
			}
			ValueSource valueSource = DependencyPropertyHelper.GetValueSource(dependencyObject, dpDescriptor.DependencyProperty);
			BaseValueSource baseValueSource = valueSource.BaseValueSource;
			BaseValueSource val2 = baseValueSource;
			switch (val2 - 2)
			{
			case 0:
			case 1:
			case 6:
				tooltip = StringConstants.Inheritance;
				break;
			case 3:
				tooltip = StringConstants.StyleSetter;
				break;
			case 9:
				tooltip = StringConstants.Local;
				break;
			case 2:
			case 4:
			case 5:
			case 7:
			case 8:
				break;
			}
		}
	}

	internal void UpdateAdvanceOptions()
	{
		AdvancedOptionsTooltip = ComputeAdvancedOptionsTooltip();
	}

	internal void UpdateIsExpandable()
	{
		IsExpandable = ExpandableAttribute && ComputeIsExpandable();
	}

	internal void UpdateValueFromSource()
	{
		BindingOperations.GetBindingExpressionBase((DependencyObject)(object)this, ValueProperty).UpdateTarget();
	}

	internal object ComputeDescriptionForItem(object item)
	{
		PropertyDescriptor propertyDescriptor = item as PropertyDescriptor;
		DescriptionAttribute attribute = PropertyGridUtilities.GetAttribute<DescriptionAttribute>(propertyDescriptor);
		if (attribute == null)
		{
			return propertyDescriptor.Description;
		}
		return attribute.Description;
	}

	internal object ComputeNewItemTypesForItem(object item)
	{
		PropertyDescriptor property = item as PropertyDescriptor;
		return PropertyGridUtilities.GetAttribute<NewItemTypesAttribute>(property)?.Types;
	}

	internal object ComputeDisplayOrderForItem(object item)
	{
		PropertyDescriptor propertyDescriptor = item as PropertyDescriptor;
		List<PropertyOrderAttribute> list = propertyDescriptor.Attributes.OfType<PropertyOrderAttribute>().ToList();
		if (list.Count > 0)
		{
			ValidatePropertyOrderAttributes(list);
			if (IsPropertyGridCategorized)
			{
				PropertyOrderAttribute propertyOrderAttribute = list.FirstOrDefault((PropertyOrderAttribute x) => x.UsageContext == UsageContextEnum.Categorized || x.UsageContext == UsageContextEnum.Both);
				if (propertyOrderAttribute != null)
				{
					return propertyOrderAttribute.Order;
				}
			}
			else
			{
				PropertyOrderAttribute propertyOrderAttribute2 = list.FirstOrDefault((PropertyOrderAttribute x) => x.UsageContext == UsageContextEnum.Alphabetical || x.UsageContext == UsageContextEnum.Both);
				if (propertyOrderAttribute2 != null)
				{
					return propertyOrderAttribute2.Order;
				}
			}
		}
		return int.MaxValue;
	}

	internal object ComputeExpandableAttributeForItem(object item)
	{
		PropertyDescriptor property = (PropertyDescriptor)item;
		ExpandableObjectAttribute attribute = PropertyGridUtilities.GetAttribute<ExpandableObjectAttribute>(property);
		return attribute != null;
	}

	internal int ComputeDisplayOrderInternal(bool isPropertyGridCategorized)
	{
		return ComputeDisplayOrder(isPropertyGridCategorized);
	}

	private void ExecuteResetValueCommand(object sender, ExecutedRoutedEventArgs e)
	{
		if (ComputeCanResetValue())
		{
			ResetValue();
		}
	}

	private void CanExecuteResetValueCommand(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = ComputeCanResetValue();
	}

	private string ComputeDisplayName()
	{
		string text = PropertyDescriptor.DisplayName;
		ParenthesizePropertyNameAttribute attribute = PropertyGridUtilities.GetAttribute<ParenthesizePropertyNameAttribute>(PropertyDescriptor);
		if (attribute != null && attribute.NeedParenthesis)
		{
			text = "(" + text + ")";
		}
		return text;
	}

	private void ValidatePropertyOrderAttributes(List<PropertyOrderAttribute> list)
	{
		if (list.Count > 0)
		{
			PropertyOrderAttribute propertyOrderAttribute = list.FirstOrDefault((PropertyOrderAttribute x) => x.UsageContext == UsageContextEnum.Both);
			if (propertyOrderAttribute != null)
			{
				_ = list.Count;
				_ = 1;
			}
		}
	}

	private static void OnValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((DescriptorPropertyDefinitionBase)(object)o).OnValueChanged(e.OldValue, e.NewValue);
	}

	internal virtual void OnValueChanged(object oldValue, object newValue)
	{
		UpdateIsExpandable();
		UpdateAdvanceOptions();
		CommandManager.InvalidateRequerySuggested();
	}

	public virtual void InitProperties()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_0092: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		_isReadOnly = ComputeIsReadOnly();
		_category = ComputeCategory();
		_categoryValue = ComputeCategoryValue();
		_description = ComputeDescription();
		_displayName = ComputeDisplayName();
		_displayOrder = ComputeDisplayOrder(IsPropertyGridCategorized);
		_expandableAttribute = ComputeExpandableAttribute();
		_newItemTypes = ComputeNewItemTypes();
		_commandBindings = new CommandBinding[1]
		{
			new CommandBinding((ICommand)PropertyItemCommands.ResetValue, (ExecutedRoutedEventHandler)ExecuteResetValueCommand, (CanExecuteRoutedEventHandler)CanExecuteResetValueCommand)
		};
		UpdateIsExpandable();
		UpdateAdvanceOptions();
		BindingBase val = CreateValueBinding();
		BindingOperations.SetBinding((DependencyObject)(object)this, ValueProperty, val);
	}

	static DescriptorPropertyDefinitionBase()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
	}
}
