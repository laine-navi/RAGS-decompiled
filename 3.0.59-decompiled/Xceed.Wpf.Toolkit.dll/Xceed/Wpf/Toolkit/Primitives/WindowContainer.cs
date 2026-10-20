using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Primitives;

public class WindowContainer : Canvas
{
	private Brush _defaultBackgroundBrush;

	private bool _isModalBackgroundApplied;

	public static readonly DependencyProperty ModalBackgroundBrushProperty;

	public Brush ModalBackgroundBrush
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(ModalBackgroundBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ModalBackgroundBrushProperty, (object)value);
		}
	}

	static WindowContainer()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Obj, but got Unknown
		SolidColorBrush val = new SolidColorBrush(Colors.Transparent);
		((Freezable)val).Freeze();
		ModalBackgroundBrushProperty = DependencyProperty.Register("ModalBackgroundBrush", typeof(Brush), typeof(WindowContainer), (PropertyMetadata)new UIPropertyMetadata((object)val, (PropertyChangedCallback)OnModalBackgroundBrushChanged));
	}

	public WindowContainer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		((FrameworkElement)this).SizeChanged += WindowContainer_SizeChanged;
		((UIElement)this).LayoutUpdated += WindowContainer_LayoutUpdated;
		((FrameworkElement)this).Loaded += WindowContainer_Loaded;
		((UIElement)this).ClipToBounds = true;
	}

	private void WindowContainer_Loaded(object sender, RoutedEventArgs e)
	{
		SetNextActiveWindow(null);
	}

	private static void OnModalBackgroundBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0028: Expected Obj, but got Unknown
		((WindowContainer)(object)d)?.OnModalBackgroundBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
	}

	protected virtual void OnModalBackgroundBrushChanged(Brush oldValue, Brush newValue)
	{
		SetModalBackground();
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		Size result = ((Canvas)this).MeasureOverride(constraint);
		if (((Panel)this).Children.Count > 0)
		{
			double val = (double.IsNaN(((FrameworkElement)this).Width) ? ((IEnumerable)((Panel)this).Children).OfType<WindowControl>().Max((WindowControl w) =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				double left = w.Left;
				Size desiredSize = ((UIElement)w).DesiredSize;
				return left + desiredSize.Width;
			}) : ((FrameworkElement)this).Width);
			double val2 = (double.IsNaN(((FrameworkElement)this).Height) ? ((IEnumerable)((Panel)this).Children).OfType<WindowControl>().Max((WindowControl w) =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				double top = w.Top;
				Size desiredSize = ((UIElement)w).DesiredSize;
				return top + desiredSize.Height;
			}) : ((FrameworkElement)this).Height);
			return new Size(Math.Min(val, constraint.Width), Math.Min(val2, constraint.Height));
		}
		return result;
	}

	protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected Obj, but got Unknown
		((Panel)this).OnVisualChildrenChanged(visualAdded, visualRemoved);
		if (visualAdded != null && !(visualAdded is WindowControl))
		{
			throw new InvalidOperationException("WindowContainer can only contain WindowControl types.");
		}
		if (visualRemoved != null)
		{
			WindowControl windowControl = (WindowControl)(object)visualRemoved;
			windowControl.LeftChanged -= Child_LeftChanged;
			windowControl.TopChanged -= Child_TopChanged;
			((UIElement)windowControl).PreviewMouseLeftButtonDown -= Child_PreviewMouseLeftButtonDown;
			((UIElement)windowControl).IsVisibleChanged -= Child_IsVisibleChanged;
			((UIElement)windowControl).IsKeyboardFocusWithinChanged -= Child_IsKeyboardFocusWithinChanged;
			if (windowControl is ChildWindow)
			{
				((ChildWindow)windowControl).IsModalChanged -= Child_IsModalChanged;
			}
		}
		if (visualAdded != null)
		{
			WindowControl windowControl2 = (WindowControl)(object)visualAdded;
			windowControl2.LeftChanged += Child_LeftChanged;
			windowControl2.TopChanged += Child_TopChanged;
			((UIElement)windowControl2).PreviewMouseLeftButtonDown += Child_PreviewMouseLeftButtonDown;
			((UIElement)windowControl2).IsVisibleChanged += Child_IsVisibleChanged;
			((UIElement)windowControl2).IsKeyboardFocusWithinChanged += Child_IsKeyboardFocusWithinChanged;
			if (windowControl2 is ChildWindow)
			{
				((ChildWindow)windowControl2).IsModalChanged += Child_IsModalChanged;
			}
		}
	}

	private void Child_LeftChanged(object sender, EventArgs e)
	{
		WindowControl windowControl = (WindowControl)sender;
		if (windowControl != null)
		{
			windowControl.Left = GetRestrictedLeft(windowControl);
		}
		Canvas.SetLeft((UIElement)(object)windowControl, windowControl.Left);
	}

	private void Child_TopChanged(object sender, EventArgs e)
	{
		WindowControl windowControl = (WindowControl)sender;
		if (windowControl != null)
		{
			windowControl.Top = GetRestrictedTop(windowControl);
		}
		Canvas.SetTop((UIElement)(object)windowControl, windowControl.Top);
	}

	private void Child_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
	{
		WindowControl nextActiveWindow = (WindowControl)sender;
		WindowControl modalWindow = GetModalWindow();
		if (modalWindow == null)
		{
			SetNextActiveWindow(nextActiveWindow);
		}
	}

	private void Child_IsModalChanged(object sender, EventArgs e)
	{
		SetModalBackground();
	}

	private void Child_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		WindowControl windowControl = (WindowControl)sender;
		WindowControl windowControl2 = ((IEnumerable)((Panel)this).Children).OfType<WindowControl>().FirstOrDefault((WindowControl x) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			return (int)((UIElement)x).Visibility == 0;
		});
		((UIElement)this).IsHitTestVisible = windowControl2 != null;
		if ((bool)e.NewValue)
		{
			SetChildPos(windowControl);
			SetNextActiveWindow(windowControl);
		}
		else
		{
			SetNextActiveWindow(null);
		}
		WindowControl modalWindow = GetModalWindow();
		foreach (WindowControl child in ((Panel)this).Children)
		{
			child.IsBlockMouseInputsPanelActive = modalWindow != null && !object.Equals(modalWindow, child);
		}
		SetModalBackground();
	}

	private void Child_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		WindowControl nextActiveWindow = (WindowControl)sender;
		if ((bool)e.NewValue)
		{
			SetNextActiveWindow(nextActiveWindow);
		}
	}

	private void WindowContainer_LayoutUpdated(object sender, EventArgs e)
	{
		foreach (WindowControl child in ((Panel)this).Children)
		{
			if (!child.IsStartupPositionInitialized && ((FrameworkElement)child).ActualWidth != 0.0 && ((FrameworkElement)child).ActualHeight != 0.0)
			{
				SetChildPos(child);
				child.IsStartupPositionInitialized = true;
			}
		}
	}

	private void WindowContainer_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		foreach (WindowControl child in ((Panel)this).Children)
		{
			child.Left = GetRestrictedLeft(child);
			child.Top = GetRestrictedTop(child);
		}
	}

	private void ExpandWindowControl(WindowControl windowControl)
	{
		if (windowControl != null)
		{
			windowControl.Left = 0.0;
			windowControl.Top = 0.0;
			((FrameworkElement)windowControl).Width = Math.Min(((FrameworkElement)this).ActualWidth, ((FrameworkElement)windowControl).MaxWidth);
			((FrameworkElement)windowControl).Height = Math.Min(((FrameworkElement)this).ActualHeight, ((FrameworkElement)windowControl).MaxHeight);
		}
	}

	private void SetChildPos(WindowControl windowControl)
	{
		if ((windowControl is MessageBox && windowControl.Left == 0.0 && windowControl.Top == 0.0) || (windowControl is ChildWindow && ((ChildWindow)windowControl).WindowStartupLocation == WindowStartupLocation.Center))
		{
			CenterChild(windowControl);
			return;
		}
		Canvas.SetLeft((UIElement)(object)windowControl, windowControl.Left);
		Canvas.SetTop((UIElement)(object)windowControl, windowControl.Top);
	}

	private void CenterChild(WindowControl windowControl)
	{
		if (((FrameworkElement)windowControl).ActualWidth != 0.0 && ((FrameworkElement)windowControl).ActualHeight != 0.0)
		{
			windowControl.Left = (((FrameworkElement)this).ActualWidth - ((FrameworkElement)windowControl).ActualWidth) / 2.0;
			windowControl.Top = (((FrameworkElement)this).ActualHeight - ((FrameworkElement)windowControl).ActualHeight) / 2.0;
		}
	}

	private void SetNextActiveWindow(WindowControl windowControl)
	{
		if (!((FrameworkElement)this).IsLoaded)
		{
			return;
		}
		if (IsModalWindow(windowControl))
		{
			BringToFront(windowControl);
			return;
		}
		WindowControl modalWindow = GetModalWindow();
		if (modalWindow != null)
		{
			BringToFront(modalWindow);
			return;
		}
		if (windowControl != null)
		{
			BringToFront(windowControl);
			return;
		}
		BringToFront((from x in ((IEnumerable)((Panel)this).Children).OfType<WindowControl>()
			orderby Panel.GetZIndex((UIElement)(object)x) descending
			select x).FirstOrDefault((WindowControl x) =>
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			return (int)((UIElement)x).Visibility == 0;
		}));
	}

	private void BringToFront(WindowControl windowControl)
	{
		if (windowControl != null)
		{
			int num = ((IEnumerable)((Panel)this).Children).OfType<WindowControl>().Max((WindowControl x) => Panel.GetZIndex((UIElement)(object)x));
			Panel.SetZIndex((UIElement)(object)windowControl, num + 1);
			SetActiveWindow(windowControl);
		}
	}

	private void SetActiveWindow(WindowControl windowControl)
	{
		foreach (WindowControl child in ((Panel)this).Children)
		{
			child.SetIsActiveInternal(isActive: false);
		}
		windowControl.SetIsActiveInternal(isActive: true);
	}

	private bool IsModalWindow(WindowControl windowControl)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		if (!(windowControl is MessageBox) || (int)((UIElement)windowControl).Visibility != 0)
		{
			if (windowControl is ChildWindow && ((ChildWindow)windowControl).IsModal)
			{
				return ((ChildWindow)windowControl).WindowState == WindowState.Open;
			}
			return false;
		}
		return true;
	}

	private WindowControl GetModalWindow()
	{
		return (from x in ((IEnumerable)((Panel)this).Children).OfType<WindowControl>()
			orderby Panel.GetZIndex((UIElement)(object)x) descending
			select x).FirstOrDefault((WindowControl x) =>
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Invalid comparison between Unknown and I4
			return IsModalWindow(x) && (int)((UIElement)x).Visibility == 0;
		});
	}

	private double GetRestrictedLeft(WindowControl windowControl)
	{
		if (windowControl.Left < 0.0)
		{
			return 0.0;
		}
		if (windowControl.Left + ((FrameworkElement)windowControl).ActualWidth > ((FrameworkElement)this).ActualWidth && ((FrameworkElement)this).ActualWidth != 0.0)
		{
			double num = ((FrameworkElement)this).ActualWidth - ((FrameworkElement)windowControl).ActualWidth;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return windowControl.Left;
	}

	private double GetRestrictedTop(WindowControl windowControl)
	{
		if (windowControl.Top < 0.0)
		{
			return 0.0;
		}
		if (windowControl.Top + ((FrameworkElement)windowControl).ActualHeight > ((FrameworkElement)this).ActualHeight && ((FrameworkElement)this).ActualHeight != 0.0)
		{
			double num = ((FrameworkElement)this).ActualHeight - ((FrameworkElement)windowControl).ActualHeight;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return windowControl.Top;
	}

	private void SetModalBackground()
	{
		if (GetModalWindow() != null && ModalBackgroundBrush != null)
		{
			if (!_isModalBackgroundApplied)
			{
				_defaultBackgroundBrush = ((Panel)this).Background;
				_isModalBackgroundApplied = true;
			}
			((Panel)this).Background = ModalBackgroundBrush;
		}
		else if (_isModalBackgroundApplied)
		{
			((Panel)this).Background = _defaultBackgroundBrush;
			_defaultBackgroundBrush = null;
			_isModalBackgroundApplied = false;
		}
	}
}
