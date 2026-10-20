using System.Windows;

namespace Xceed.Wpf.Toolkit.Panels;

public class ChildExitedEventArgs : RoutedEventArgs
{
	private readonly UIElement _child;

	public UIElement Child => _child;

	public ChildExitedEventArgs(UIElement child)
	{
		_child = child;
	}
}
