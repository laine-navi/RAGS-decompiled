using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.Toolkit.Primitives;

public class SelectorItem : ContentControl
{
	public static readonly DependencyProperty IsSelectedProperty;

	public static readonly RoutedEvent SelectedEvent;

	public static readonly RoutedEvent UnselectedEvent;

	public bool IsSelected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	internal Selector ParentSelector => ItemsControl.ItemsControlFromItemContainer((DependencyObject)(object)this) as Selector;

	static SelectorItem()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(SelectorItem), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsSelectedChanged));
		SelectedEvent = Selector.SelectedEvent.AddOwner(typeof(SelectorItem));
		UnselectedEvent = Selector.UnSelectedEvent.AddOwner(typeof(SelectorItem));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectorItem), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(SelectorItem)));
	}

	private static void OnIsSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is SelectorItem selectorItem)
		{
			selectorItem.OnIsSelectedChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	protected virtual void OnIsSelectedChanged(bool oldValue, bool newValue)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected Obj, but got Unknown
		if (newValue)
		{
			((UIElement)this).RaiseEvent(new RoutedEventArgs(Selector.SelectedEvent, (object)this));
		}
		else
		{
			((UIElement)this).RaiseEvent(new RoutedEventArgs(Selector.UnSelectedEvent, (object)this));
		}
	}
}
