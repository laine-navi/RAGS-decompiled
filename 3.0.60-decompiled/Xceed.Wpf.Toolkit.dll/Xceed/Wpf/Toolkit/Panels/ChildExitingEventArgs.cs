using System.Windows;

namespace Xceed.Wpf.Toolkit.Panels;

public class ChildExitingEventArgs : RoutedEventArgs
{
	private readonly Rect _arrangeRect;

	private readonly UIElement _child;

	private Rect? _exitTo;

	public Rect ArrangeRect
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _arrangeRect;
		}
	}

	public UIElement Child => _child;

	public Rect? ExitTo
	{
		get
		{
			return _exitTo;
		}
		set
		{
			_exitTo = value;
		}
	}

	public ChildExitingEventArgs(UIElement child, Rect? exitTo, Rect arrangeRect)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		_child = child;
		_exitTo = exitTo;
		_arrangeRect = arrangeRect;
	}
}
