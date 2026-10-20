using System.Windows;

namespace Xceed.Wpf.Toolkit.Core;

public class CancelRoutedEventArgs : RoutedEventArgs
{
	public bool Cancel { get; set; }

	public CancelRoutedEventArgs()
	{
	}

	public CancelRoutedEventArgs(RoutedEvent routedEvent)
		: base(routedEvent)
	{
	}

	public CancelRoutedEventArgs(RoutedEvent routedEvent, object source)
		: base(routedEvent, source)
	{
	}
}
