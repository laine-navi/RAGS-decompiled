using System.Collections;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Core;

internal class UIElementAdorner<TElement>(UIElement adornedElement) : Adorner(adornedElement) where TElement : UIElement
{
	private TElement _child = default;

	private double _offsetLeft;

	private double _offsetTop;

	public TElement Child
	{
		get
		{
			return _child;
		}
		set
		{
			if ((object)value != (object)_child)
			{
				if (_child != null)
				{
					((FrameworkElement)this).RemoveLogicalChild((object)_child);
					((Visual)this).RemoveVisualChild((Visual)(object)_child);
				}
				_child = value;
				if (_child != null)
				{
					((FrameworkElement)this).AddLogicalChild((object)_child);
					((Visual)this).AddVisualChild((Visual)(object)_child);
				}
			}
		}
	}

	public double OffsetLeft
	{
		get
		{
			return _offsetLeft;
		}
		set
		{
			_offsetLeft = value;
			UpdateLocation();
		}
	}

	public double OffsetTop
	{
		get
		{
			return _offsetTop;
		}
		set
		{
			_offsetTop = value;
			UpdateLocation();
		}
	}

	protected override IEnumerator LogicalChildren
	{
		get
		{
			ArrayList arrayList = new ArrayList();
			if (_child != null)
			{
				arrayList.Add(_child);
			}
			return arrayList.GetEnumerator();
		}
	}

	protected override int VisualChildrenCount
	{
		get
		{
			if (_child != null)
			{
				return 1;
			}
			return 0;
		}
	}

	public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		GeneralTransformGroup val = new GeneralTransformGroup();
		val.Children.Add(((Adorner)this).GetDesiredTransform(transform));
		val.Children.Add((GeneralTransform)new TranslateTransform(_offsetLeft, _offsetTop));
		return (GeneralTransform)(object)val;
	}

	public void SetOffsets(double left, double top)
	{
		_offsetLeft = left;
		_offsetTop = top;
		UpdateLocation();
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (_child == null)
		{
			return ((Adorner)this).MeasureOverride(constraint);
		}
		((UIElement)_child/*cast due to constrained. prefix*/).Measure(constraint);
		return ((UIElement)_child).DesiredSize;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (_child == null)
		{
			return ((FrameworkElement)this).ArrangeOverride(finalSize);
		}
		ref TElement child = ref _child;
		Rect val = new Rect(finalSize);
		((UIElement)child/*cast due to constrained. prefix*/).Arrange(val);
		return finalSize;
	}

	protected override Visual GetVisualChild(int index)
	{
		return (Visual)(object)_child;
	}

	private void UpdateLocation()
	{
		DependencyObject parent = ((FrameworkElement)this).Parent;
		AdornerLayer val = (AdornerLayer)(object)((parent is AdornerLayer) ? parent : null);
		if (val != null)
		{
			val.Update(((Adorner)this).AdornedElement);
		}
	}
}
