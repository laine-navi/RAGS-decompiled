using System.Windows;

namespace Xceed.Wpf.Toolkit;

public class ItemEventArgs : RoutedEventArgs
{
	private object _item;

	public object Item => _item;

	internal ItemEventArgs(RoutedEvent routedEvent, object newItem)
		: base(routedEvent)
	{
		_item = newItem;
	}
}
