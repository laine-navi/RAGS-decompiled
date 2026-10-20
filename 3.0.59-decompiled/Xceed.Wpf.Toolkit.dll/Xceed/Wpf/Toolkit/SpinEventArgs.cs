using System.Windows;

namespace Xceed.Wpf.Toolkit;

public class SpinEventArgs : RoutedEventArgs
{
	public SpinDirection Direction { get; private set; }

	public bool UsingMouseWheel { get; private set; }

	public SpinEventArgs(SpinDirection direction)
	{
		Direction = direction;
	}

	public SpinEventArgs(SpinDirection direction, bool usingMouseWheel)
	{
		Direction = direction;
		UsingMouseWheel = usingMouseWheel;
	}
}
