using System.Windows;
using Xceed.Wpf.Toolkit.Core;

namespace Xceed.Wpf.Toolkit;

public class ItemDeletingEventArgs : CancelRoutedEventArgs
{
	private object _item;

	public object Item => _item;

	public ItemDeletingEventArgs(RoutedEvent itemDeletingEvent, object itemDeleting)
		: base(itemDeletingEvent)
	{
		_item = itemDeleting;
	}
}
