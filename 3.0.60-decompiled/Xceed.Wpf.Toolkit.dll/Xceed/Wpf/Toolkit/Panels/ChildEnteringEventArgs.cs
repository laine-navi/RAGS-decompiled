using System.Windows;

namespace Xceed.Wpf.Toolkit.Panels;

public class ChildEnteringEventArgs : RoutedEventArgs
{
	private readonly Rect _arrangeRect;

	private readonly UIElement _child;

	private Rect? _enterFrom;

	public Rect ArrangeRect
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _arrangeRect;
		}
	}

	public UIElement Child => _child;

	public Rect? EnterFrom
	{
		get
		{
			return _enterFrom;
		}
		set
		{
			_enterFrom = value;
		}
	}

	public ChildEnteringEventArgs(UIElement child, Rect? enterFrom, Rect arrangeRect)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		_child = child;
		_enterFrom = enterFrom;
		_arrangeRect = arrangeRect;
	}
}
