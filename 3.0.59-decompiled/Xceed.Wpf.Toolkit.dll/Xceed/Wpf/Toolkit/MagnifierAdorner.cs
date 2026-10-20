using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit;

public class MagnifierAdorner : Adorner
{
	private Magnifier _magnifier;

	private Point _currentMousePosition;

	protected override int VisualChildrenCount => 1;

	public MagnifierAdorner(UIElement element, Magnifier magnifier)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		RoutedEventHandler val = null;
		RoutedEventHandler val2 = null;
		((Adorner)this)._002Ector(element);
		_magnifier = magnifier;
		UpdateViewBox();
		((Visual)this).AddVisualChild((Visual)(object)_magnifier);
		if (val == null)
		{
			val = (object s, RoutedEventArgs e) =>
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Expected Obj, but got Unknown
				InputManager.Current.PostProcessInput += OnProcessInput;
			};
		}
		((FrameworkElement)this).Loaded += val;
		if (val2 == null)
		{
			val2 = (object s, RoutedEventArgs e) =>
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Expected Obj, but got Unknown
				InputManager.Current.PostProcessInput -= OnProcessInput;
			};
		}
		((FrameworkElement)this).Unloaded += val2;
	}

	private void OnProcessInput(object sender, ProcessInputEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition((IInputElement)(object)this);
		if (!(_currentMousePosition == position))
		{
			_currentMousePosition = position;
			UpdateViewBox();
			((UIElement)this).InvalidateArrange();
		}
	}

	internal void UpdateViewBox()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Point val = CalculateViewBoxLocation();
		Magnifier magnifier = _magnifier;
		Rect viewBox = _magnifier.ViewBox;
		magnifier.ViewBox = new Rect(val, viewBox.Size);
	}

	private Point CalculateViewBoxLocation()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		double num2 = 0.0;
		Point position = Mouse.GetPosition((IInputElement)(object)this);
		Point position2 = Mouse.GetPosition((IInputElement)(object)((Adorner)this).AdornedElement);
		num = position2.X - position.X;
		num2 = position2.Y - position.Y;
		Vector offset = VisualTreeHelper.GetOffset((Visual)(object)_magnifier.Target);
		Point val = new Point(offset.X, offset.Y);
		double x = _currentMousePosition.X;
		Rect viewBox = _magnifier.ViewBox;
		double num3 = x - (viewBox.Width / 2.0 + num) + val.X;
		double y = _currentMousePosition.Y;
		Rect viewBox2 = _magnifier.ViewBox;
		double num4 = y - (viewBox2.Height / 2.0 + num2) + val.Y;
		return new Point(num3, num4);
	}

	protected override Visual GetVisualChild(int index)
	{
		return (Visual)(object)_magnifier;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)_magnifier).Measure(constraint);
		return ((Adorner)this).MeasureOverride(constraint);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		double num = _currentMousePosition.X - ((FrameworkElement)_magnifier).Width / 2.0;
		double num2 = _currentMousePosition.Y - ((FrameworkElement)_magnifier).Height / 2.0;
		((UIElement)_magnifier).Arrange(new Rect(num, num2, ((FrameworkElement)_magnifier).Width, ((FrameworkElement)_magnifier).Height));
		return ((FrameworkElement)this).ArrangeOverride(finalSize);
	}
}
