using System.Windows;

namespace Xceed.Wpf.Toolkit.Panels;

public class ChildEnteredEventArgs : RoutedEventArgs
{
	private readonly Rect _arrangeRect;

	private readonly UIElement _child;

	public Rect ArrangeRect
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _arrangeRect;
		}
	}

	public UIElement Child => _child;

	public ChildEnteredEventArgs(UIElement child, Rect arrangeRect)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		_child = child;
		_arrangeRect = arrangeRect;
	}
}
