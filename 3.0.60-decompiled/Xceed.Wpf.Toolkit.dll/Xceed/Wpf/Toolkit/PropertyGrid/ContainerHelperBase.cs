using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal abstract class ContainerHelperBase
{
	protected readonly IPropertyContainer PropertyContainer;

	internal static readonly DependencyProperty IsGeneratedProperty = DependencyProperty.RegisterAttached("IsGenerated", typeof(bool), typeof(ContainerHelperBase), new PropertyMetadata((object)false));

	public abstract IList Properties { get; }

	internal ItemsControl ChildrenItemsControl { get; set; }

	public ContainerHelperBase(IPropertyContainer propertyContainer)
	{
		if (propertyContainer == null)
		{
			throw new ArgumentNullException("propertyContainer");
		}
		PropertyContainer = propertyContainer;
		if (propertyContainer is INotifyPropertyChanged notifyPropertyChanged)
		{
			notifyPropertyChanged.PropertyChanged += OnPropertyContainerPropertyChanged;
		}
	}

	internal static bool GetIsGenerated(DependencyObject obj)
	{
		return (bool)obj.GetValue(IsGeneratedProperty);
	}

	internal static void SetIsGenerated(DependencyObject obj, bool value)
	{
		obj.SetValue(IsGeneratedProperty, (object)value);
	}

	public virtual void ClearHelper()
	{
		if (PropertyContainer is INotifyPropertyChanged notifyPropertyChanged)
		{
			notifyPropertyChanged.PropertyChanged -= OnPropertyContainerPropertyChanged;
		}
		if (ChildrenItemsControl != null)
		{
			((IItemContainerGenerator)ChildrenItemsControl.ItemContainerGenerator).RemoveAll();
		}
	}

	public virtual void PrepareChildrenPropertyItem(PropertyItemBase propertyItem, object item)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		propertyItem.ParentNode = PropertyContainer;
		PropertyGrid.RaisePreparePropertyItemEvent((UIElement)PropertyContainer, propertyItem, item);
	}

	public virtual void ClearChildrenPropertyItem(PropertyItemBase propertyItem, object item)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		propertyItem.ParentNode = null;
		PropertyGrid.RaiseClearPropertyItemEvent((UIElement)PropertyContainer, propertyItem, item);
	}

	protected FrameworkElement GenerateCustomEditingElement(Type definitionKey, PropertyItemBase propertyItem)
	{
		if (PropertyContainer.EditorDefinitions == null)
		{
			return null;
		}
		return CreateCustomEditor(PropertyContainer.EditorDefinitions.GetRecursiveBaseTypes(definitionKey), propertyItem);
	}

	protected FrameworkElement GenerateCustomEditingElement(object definitionKey, PropertyItemBase propertyItem)
	{
		if (PropertyContainer.EditorDefinitions == null)
		{
			return null;
		}
		return CreateCustomEditor(PropertyContainer.EditorDefinitions[definitionKey], propertyItem);
	}

	protected FrameworkElement CreateCustomEditor(EditorDefinitionBase customEditor, PropertyItemBase propertyItem)
	{
		return customEditor?.GenerateEditingElementInternal(propertyItem);
	}

	protected virtual void OnPropertyContainerPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		IPropertyContainer ps = null;
		if (propertyName == ReflectionHelper.GetPropertyOrFieldName(() => ps.FilterInfo))
		{
			OnFilterChanged();
		}
		else if (propertyName == ReflectionHelper.GetPropertyOrFieldName(() => ps.IsCategorized))
		{
			OnCategorizationChanged();
		}
		else if (propertyName == ReflectionHelper.GetPropertyOrFieldName(() => ps.AutoGenerateProperties))
		{
			OnAutoGeneratePropertiesChanged();
		}
		else if (propertyName == ReflectionHelper.GetPropertyOrFieldName(() => ps.EditorDefinitions))
		{
			OnEditorDefinitionsChanged();
		}
		else if (propertyName == ReflectionHelper.GetPropertyOrFieldName(() => ps.PropertyDefinitions))
		{
			OnPropertyDefinitionsChanged();
		}
	}

	protected virtual void OnCategorizationChanged()
	{
	}

	protected virtual void OnFilterChanged()
	{
	}

	protected virtual void OnAutoGeneratePropertiesChanged()
	{
	}

	protected virtual void OnEditorDefinitionsChanged()
	{
	}

	protected virtual void OnPropertyDefinitionsChanged()
	{
	}

	public virtual void OnEndInit()
	{
	}

	public abstract PropertyItemBase ContainerFromItem(object item);

	public abstract object ItemFromContainer(PropertyItemBase container);

	public abstract Binding CreateChildrenDefaultBinding(PropertyItemBase propertyItem);

	public virtual void NotifyEditorDefinitionsCollectionChanged()
	{
	}

	public virtual void NotifyPropertyDefinitionsCollectionChanged()
	{
	}

	public abstract void UpdateValuesFromSource();

	static ContainerHelperBase()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
	}
}
