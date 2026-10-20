using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal abstract class ObjectContainerHelperBase : ContainerHelperBase
{
	private bool _isPreparingItemFlag;

	private PropertyItemCollection _propertyItemCollection;

	public override IList Properties => _propertyItemCollection;

	private PropertyItem DefaultProperty
	{
		get
		{
			PropertyItem result = null;
			string defaultName = GetDefaultPropertyName();
			if (defaultName != null)
			{
				result = _propertyItemCollection.FirstOrDefault((PropertyItem prop) => object.Equals(defaultName, prop.PropertyDescriptor.Name));
			}
			return result;
		}
	}

	protected PropertyItemCollection PropertyItems => _propertyItemCollection;

	public ObjectContainerHelperBase(IPropertyContainer propertyContainer)
		: base(propertyContainer)
	{
		_propertyItemCollection = new PropertyItemCollection(new ObservableCollection<PropertyItem>());
		UpdateFilter();
		UpdateCategorization();
	}

	public override PropertyItemBase ContainerFromItem(object item)
	{
		if (item == null)
		{
			return null;
		}
		if (item is PropertyItem result)
		{
			return result;
		}
		string propertyStr = item as string;
		if (propertyStr != null)
		{
			return PropertyItems.FirstOrDefault((PropertyItem prop) => propertyStr == prop.PropertyDescriptor.Name);
		}
		return null;
	}

	public override object ItemFromContainer(PropertyItemBase container)
	{
		if (!(container is PropertyItem propertyItem))
		{
			return null;
		}
		return propertyItem.PropertyDescriptor.Name;
	}

	public override void UpdateValuesFromSource()
	{
		foreach (PropertyItem propertyItem in PropertyItems)
		{
			propertyItem.DescriptorDefinition.UpdateValueFromSource();
			propertyItem.ContainerHelper.UpdateValuesFromSource();
		}
	}

	public void GenerateProperties()
	{
		if (PropertyItems.Count == 0)
		{
			RegenerateProperties();
		}
	}

	protected override void OnFilterChanged()
	{
		UpdateFilter();
	}

	protected override void OnCategorizationChanged()
	{
		UpdateCategorization();
	}

	protected override void OnAutoGeneratePropertiesChanged()
	{
		RegenerateProperties();
	}

	protected override void OnEditorDefinitionsChanged()
	{
		RegenerateProperties();
	}

	protected override void OnPropertyDefinitionsChanged()
	{
		RegenerateProperties();
	}

	private void UpdateFilter()
	{
		FilterInfo filterInfo = PropertyContainer.FilterInfo;
		PropertyItems.FilterPredicate = filterInfo.Predicate ?? PropertyItemCollection.CreateFilter(filterInfo.InputString);
	}

	private void UpdateCategorization()
	{
		_propertyItemCollection.UpdateCategorization(ComputeCategoryGroupDescription(), PropertyContainer.IsCategorized);
	}

	private GroupDescription ComputeCategoryGroupDescription()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		if (!PropertyContainer.IsCategorized)
		{
			return null;
		}
		return (GroupDescription)new PropertyGroupDescription(PropertyItemCollection.CategoryPropertyName);
	}

	private string GetCategoryGroupingPropertyName()
	{
		GroupDescription val = ComputeCategoryGroupDescription();
		PropertyGroupDescription val2 = (PropertyGroupDescription)(object)((val is PropertyGroupDescription) ? val : null);
		if (val2 == null)
		{
			return null;
		}
		return val2.PropertyName;
	}

	private void OnChildrenPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		if ((IsItemOrderingProperty(e.PropertyName) || GetCategoryGroupingPropertyName() == e.PropertyName) && (int)ChildrenItemsControl.ItemContainerGenerator.Status != 1 && !_isPreparingItemFlag)
		{
			PropertyItems.RefreshView();
		}
	}

	protected abstract string GetDefaultPropertyName();

	protected abstract IEnumerable<PropertyItem> GenerateSubPropertiesCore();

	private void RegenerateProperties()
	{
		IEnumerable<PropertyItem> enumerable = GenerateSubPropertiesCore();
		_ = PropertyContainer;
		foreach (PropertyItem item in enumerable)
		{
			InitializePropertyItem(item);
		}
		foreach (PropertyItem propertyItem in PropertyItems)
		{
			propertyItem.PropertyChanged -= OnChildrenPropertyChanged;
		}
		PropertyItems.UpdateItems(enumerable);
		foreach (PropertyItem propertyItem2 in PropertyItems)
		{
			propertyItem2.PropertyChanged += OnChildrenPropertyChanged;
		}
		if (PropertyContainer is PropertyGrid propertyGrid)
		{
			propertyGrid.SelectedPropertyItem = DefaultProperty;
		}
	}

	protected static List<PropertyDescriptor> GetPropertyDescriptors(object instance)
	{
		TypeConverter converter = TypeDescriptor.GetConverter(instance);
		return ((converter != null && converter.GetPropertiesSupported()) ? converter.GetProperties(instance) : ((!(instance is ICustomTypeDescriptor)) ? TypeDescriptor.GetProperties(instance.GetType()) : ((ICustomTypeDescriptor)instance).GetProperties()))?.Cast<PropertyDescriptor>().ToList();
	}

	internal void InitializeDescriptorDefinition(DescriptorPropertyDefinitionBase descriptorDef, PropertyDefinition propertyDefinition)
	{
		if (descriptorDef == null)
		{
			throw new ArgumentNullException("descriptorDef");
		}
		if (propertyDefinition != null && propertyDefinition != null)
		{
			if (propertyDefinition.Category != null)
			{
				descriptorDef.Category = propertyDefinition.Category;
				descriptorDef.CategoryValue = propertyDefinition.Category;
			}
			if (propertyDefinition.Description != null)
			{
				descriptorDef.Description = propertyDefinition.Description;
			}
			if (propertyDefinition.DisplayName != null)
			{
				descriptorDef.DisplayName = propertyDefinition.DisplayName;
			}
			if (propertyDefinition.DisplayOrder.HasValue)
			{
				descriptorDef.DisplayOrder = propertyDefinition.DisplayOrder.Value;
			}
			if (propertyDefinition.IsExpandable.HasValue)
			{
				descriptorDef.ExpandableAttribute = propertyDefinition.IsExpandable.Value;
			}
		}
	}

	private void InitializePropertyItem(PropertyItem propertyItem)
	{
		DescriptorPropertyDefinitionBase pd = propertyItem.DescriptorDefinition;
		propertyItem.PropertyDescriptor = pd.PropertyDescriptor;
		propertyItem.IsReadOnly = pd.IsReadOnly;
		propertyItem.DisplayName = pd.DisplayName;
		propertyItem.Description = pd.Description;
		propertyItem.Category = pd.Category;
		propertyItem.PropertyOrder = pd.DisplayOrder;
		SetupDefinitionBinding(propertyItem, PropertyItemBase.IsExpandableProperty, pd, () => pd.IsExpandable, (BindingMode)1);
		SetupDefinitionBinding(propertyItem, PropertyItemBase.AdvancedOptionsIconProperty, pd, () => pd.AdvancedOptionsIcon, (BindingMode)1);
		SetupDefinitionBinding(propertyItem, PropertyItemBase.AdvancedOptionsTooltipProperty, pd, () => pd.AdvancedOptionsTooltip, (BindingMode)1);
		SetupDefinitionBinding(propertyItem, CustomPropertyItem.ValueProperty, pd, () => pd.Value, (BindingMode)0);
		if (pd.CommandBindings == null)
		{
			return;
		}
		foreach (CommandBinding commandBinding in pd.CommandBindings)
		{
			((UIElement)propertyItem).CommandBindings.Add(commandBinding);
		}
	}

	private void SetupDefinitionBinding<T>(PropertyItem propertyItem, DependencyProperty itemProperty, DescriptorPropertyDefinitionBase pd, Expression<Func<T>> definitionProperty, BindingMode bindingMode)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		string propertyOrFieldName = ReflectionHelper.GetPropertyOrFieldName(definitionProperty);
		Binding val = new Binding(propertyOrFieldName);
		val.Source = pd;
		val.Mode = bindingMode;
		Binding val2 = val;
		((FrameworkElement)propertyItem).SetBinding(itemProperty, (BindingBase)(object)val2);
	}

	private FrameworkElement GenerateChildrenEditorElement(PropertyItem propertyItem)
	{
		FrameworkElement val = null;
		DescriptorPropertyDefinitionBase descriptorDefinition = propertyItem.DescriptorDefinition;
		object obj = null;
		Type type = obj as Type;
		ITypeEditor typeEditor = descriptorDefinition.CreateAttributeEditor();
		if (typeEditor != null)
		{
			val = typeEditor.ResolveEditor(propertyItem);
		}
		if (val == null && obj == null)
		{
			val = GenerateCustomEditingElement(propertyItem.PropertyDescriptor.Name, propertyItem);
		}
		if (val == null && type == null)
		{
			val = GenerateCustomEditingElement(propertyItem.PropertyType, propertyItem);
		}
		if (val == null)
		{
			if (descriptorDefinition.IsReadOnly)
			{
				typeEditor = new TextBlockEditor();
			}
			if (typeEditor == null)
			{
				typeEditor = ((type != null) ? PropertyGridUtilities.CreateDefaultEditor(type, null) : descriptorDefinition.CreateDefaultEditor());
			}
			val = typeEditor.ResolveEditor(propertyItem);
		}
		return val;
	}

	internal PropertyDefinition GetPropertyDefinition(PropertyDescriptor descriptor)
	{
		PropertyDefinition propertyDefinition = null;
		PropertyDefinitionCollection propertyDefinitions = PropertyContainer.PropertyDefinitions;
		if (propertyDefinitions != null)
		{
			propertyDefinition = propertyDefinitions[descriptor.Name];
			if (propertyDefinition == null)
			{
				propertyDefinition = propertyDefinitions.GetRecursiveBaseTypes(descriptor.PropertyType);
			}
		}
		return propertyDefinition;
	}

	public override void PrepareChildrenPropertyItem(PropertyItemBase propertyItem, object item)
	{
		_isPreparingItemFlag = true;
		base.PrepareChildrenPropertyItem(propertyItem, item);
		if (propertyItem.Editor == null)
		{
			FrameworkElement val = GenerateChildrenEditorElement((PropertyItem)propertyItem);
			if (val != null)
			{
				ContainerHelperBase.SetIsGenerated((DependencyObject)(object)val, value: true);
				propertyItem.Editor = val;
			}
		}
		_isPreparingItemFlag = false;
	}

	public override void ClearChildrenPropertyItem(PropertyItemBase propertyItem, object item)
	{
		if (propertyItem.Editor != null && ContainerHelperBase.GetIsGenerated((DependencyObject)(object)propertyItem.Editor))
		{
			propertyItem.Editor = null;
		}
		base.ClearChildrenPropertyItem(propertyItem, item);
	}

	public override Binding CreateChildrenDefaultBinding(PropertyItemBase propertyItem)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		Binding val = new Binding("Value");
		val.Mode = (BindingMode)(((PropertyItem)propertyItem).IsReadOnly ? 1 : 0);
		return val;
	}

	protected static string GetDefaultPropertyName(object instance)
	{
		AttributeCollection attributes = TypeDescriptor.GetAttributes(instance);
		return ((DefaultPropertyAttribute)attributes[typeof(DefaultPropertyAttribute)])?.Name;
	}

	private static bool IsItemOrderingProperty(string propertyName)
	{
		if (!string.Equals(propertyName, PropertyItemCollection.DisplayNamePropertyName) && !string.Equals(propertyName, PropertyItemCollection.CategoryOrderPropertyName))
		{
			return string.Equals(propertyName, PropertyItemCollection.PropertyOrderPropertyName);
		}
		return true;
	}
}
