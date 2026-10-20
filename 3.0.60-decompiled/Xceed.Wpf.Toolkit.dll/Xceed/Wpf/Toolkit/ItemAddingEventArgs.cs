using System.Windows;
using Xceed.Wpf.Toolkit.Core;

namespace Xceed.Wpf.Toolkit;

public class ItemAddingEventArgs : CancelRoutedEventArgs
{
	public object Item { get; set; }

	public ItemAddingEventArgs(RoutedEvent itemAddingEvent, object itemAdding)
		: base(itemAddingEvent)
	{
		Item = itemAdding;
	}
}
