using System;
using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public class PropertyItemsControl : ItemsControl
{
	internal static readonly RoutedEvent PreparePropertyItemEvent = EventManager.RegisterRoutedEvent("PreparePropertyItem", (RoutingStrategy)1, typeof(PropertyItemEventHandler), typeof(PropertyItemsControl));

	internal static readonly RoutedEvent ClearPropertyItemEvent = EventManager.RegisterRoutedEvent("ClearPropertyItem", (RoutingStrategy)1, typeof(PropertyItemEventHandler), typeof(PropertyItemsControl));

	internal event PropertyItemEventHandler PreparePropertyItem
	{
		add
		{
			((UIElement)this).AddHandler(PreparePropertyItemEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(PreparePropertyItemEvent, (Delegate)value);
		}
	}

	internal event PropertyItemEventHandler ClearPropertyItem
	{
		add
		{
			((UIElement)this).AddHandler(ClearPropertyItemEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ClearPropertyItemEvent, (Delegate)value);
		}
	}

	private void RaisePreparePropertyItemEvent(PropertyItemBase propertyItem, object item)
	{
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new PropertyItemEventArgs(PreparePropertyItemEvent, this, propertyItem, item));
	}

	private void RaiseClearPropertyItemEvent(PropertyItemBase propertyItem, object item)
	{
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new PropertyItemEventArgs(ClearPropertyItemEvent, this, propertyItem, item));
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		return item is PropertyItemBase;
	}

	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
	{
		((ItemsControl)this).PrepareContainerForItemOverride(element, item);
		RaisePreparePropertyItemEvent((PropertyItemBase)(object)element, item);
	}

	protected override void ClearContainerForItemOverride(DependencyObject element, object item)
	{
		RaiseClearPropertyItemEvent((PropertyItemBase)(object)element, item);
		((ItemsControl)this).ClearContainerForItemOverride(element, item);
	}
}
