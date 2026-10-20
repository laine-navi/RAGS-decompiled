using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_Root", Type = typeof(Grid))]
[TemplatePart(Name = "PART_WindowRoot", Type = typeof(Grid))]
[TemplatePart(Name = "PART_WindowControl", Type = typeof(WindowControl))]
public class ChildWindow : WindowControl
{
	private const string PART_WindowRoot = "PART_WindowRoot";

	private const string PART_Root = "PART_Root";

	private const string PART_WindowControl = "PART_WindowControl";

	private const int _horizontalOffset = 3;

	private const int _verticalOffset = 3;

	private Grid _root;

	private TranslateTransform _moveTransform = new TranslateTransform();

	private bool _startupPositionInitialized;

	private FrameworkElement _parentContainer;

	private Rectangle _modalLayer = new Rectangle();

	private Canvas _modalLayerPanel = new Canvas();

	private Grid _windowRoot;

	private WindowControl _windowControl;

	private bool _ignorePropertyChanged;

	private bool _hasWindowContainer;

	private bool? _dialogResult;

	public static readonly DependencyProperty DesignerWindowStateProperty;

	public static readonly DependencyProperty FocusedElementProperty;

	public static readonly DependencyProperty IsModalProperty;

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public static readonly DependencyProperty OverlayBrushProperty;

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public static readonly DependencyProperty OverlayOpacityProperty;

	public static readonly DependencyProperty WindowStartupLocationProperty;

	public static readonly DependencyProperty WindowStateProperty;

	[TypeConverter(typeof(NullableBoolConverter))]
	public bool? DialogResult
	{
		get
		{
			return _dialogResult;
		}
		set
		{
			if (_dialogResult != value)
			{
				_dialogResult = value;
				Close();
			}
		}
	}

	public WindowState DesignerWindowState
	{
		get
		{
			return (WindowState)((DependencyObject)this).GetValue(DesignerWindowStateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DesignerWindowStateProperty, (object)value);
		}
	}

	public FrameworkElement FocusedElement
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (FrameworkElement)((DependencyObject)this).GetValue(FocusedElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FocusedElementProperty, (object)value);
		}
	}

	public bool IsModal
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsModalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsModalProperty, (object)value);
		}
	}

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public Brush OverlayBrush
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(OverlayBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayBrushProperty, (object)value);
		}
	}

	[Obsolete("This property is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	public double OverlayOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(OverlayOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverlayOpacityProperty, (object)value);
		}
	}

	public WindowStartupLocation WindowStartupLocation
	{
		get
		{
			return (WindowStartupLocation)((DependencyObject)this).GetValue(WindowStartupLocationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowStartupLocationProperty, (object)value);
		}
	}

	public WindowState WindowState
	{
		get
		{
			return (WindowState)((DependencyObject)this).GetValue(WindowStateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowStateProperty, (object)value);
		}
	}

	internal override bool AllowPublicIsActiveChange => false;

	internal event EventHandler<EventArgs> IsModalChanged;

	public event EventHandler Closed;

	public event EventHandler<CancelEventArgs> Closing;

	private static void OnDesignerWindowStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnDesignerWindowStatePropertyChanged((WindowState)e.OldValue, (WindowState)e.NewValue);
		}
	}

	protected virtual void OnDesignerWindowStatePropertyChanged(WindowState oldValue, WindowState newValue)
	{
		if (DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			((UIElement)this).Visibility = (Visibility)((newValue != WindowState.Open) ? 2 : 0);
		}
	}

	private static void OnIsModalPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnIsModalChanged((bool)e.OldValue, (bool)e.NewValue);
		}
	}

	private void OnIsModalChanged(bool oldValue, bool newValue)
	{
		IsModalChanged?.Invoke(this, EventArgs.Empty);
		if (!_hasWindowContainer)
		{
			if (newValue)
			{
				KeyboardNavigation.SetTabNavigation((DependencyObject)(object)this, (KeyboardNavigationMode)2);
				ShowModalLayer();
			}
			else
			{
				KeyboardNavigation.SetTabNavigation((DependencyObject)(object)this, (KeyboardNavigationMode)0);
				HideModalLayer();
			}
		}
	}

	private static void OnOverlayBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0028: Expected Obj, but got Unknown
		if (d is ChildWindow childWindow)
		{
			childWindow.OnOverlayBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
		}
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	protected virtual void OnOverlayBrushChanged(Brush oldValue, Brush newValue)
	{
		((Shape)_modalLayer).Fill = newValue;
	}

	private static void OnOverlayOpacityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnOverlayOpacityChanged((double)e.OldValue, (double)e.NewValue);
		}
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.ModalBackgroundBrushProperty instead.")]
	protected virtual void OnOverlayOpacityChanged(double oldValue, double newValue)
	{
		((UIElement)_modalLayer).Opacity = newValue;
	}

	private static void OnWindowStartupLocationChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		if (o is ChildWindow childWindow)
		{
			childWindow.OnWindowStartupLocationChanged((WindowStartupLocation)e.OldValue, (WindowStartupLocation)e.NewValue);
		}
	}

	protected virtual void OnWindowStartupLocationChanged(WindowStartupLocation oldValue, WindowStartupLocation newValue)
	{
	}

	private static void OnWindowStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ChildWindow childWindow)
		{
			childWindow.OnWindowStatePropertyChanged((WindowState)e.OldValue, (WindowState)e.NewValue);
		}
	}

	protected virtual void OnWindowStatePropertyChanged(WindowState oldValue, WindowState newValue)
	{
		if (!DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			if (!_ignorePropertyChanged)
			{
				SetWindowState(newValue);
			}
		}
		else
		{
			((UIElement)this).Visibility = (Visibility)((DesignerWindowState != WindowState.Open) ? 2 : 0);
		}
	}

	static ChildWindow()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected Obj, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected Obj, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		DesignerWindowStateProperty = DependencyProperty.Register("DesignerWindowState", typeof(WindowState), typeof(ChildWindow), new PropertyMetadata((object)WindowState.Closed, (PropertyChangedCallback)OnDesignerWindowStatePropertyChanged));
		FocusedElementProperty = DependencyProperty.Register("FocusedElement", typeof(FrameworkElement), typeof(ChildWindow), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		IsModalProperty = DependencyProperty.Register("IsModal", typeof(bool), typeof(ChildWindow), (PropertyMetadata)new UIPropertyMetadata((object)false, (PropertyChangedCallback)OnIsModalPropertyChanged));
		OverlayBrushProperty = DependencyProperty.Register("OverlayBrush", typeof(Brush), typeof(ChildWindow), new PropertyMetadata((object)Brushes.Gray, (PropertyChangedCallback)OnOverlayBrushChanged));
		OverlayOpacityProperty = DependencyProperty.Register("OverlayOpacity", typeof(double), typeof(ChildWindow), new PropertyMetadata((object)0.5, (PropertyChangedCallback)OnOverlayOpacityChanged));
		WindowStartupLocationProperty = DependencyProperty.Register("WindowStartupLocation", typeof(WindowStartupLocation), typeof(ChildWindow), (PropertyMetadata)new UIPropertyMetadata((object)WindowStartupLocation.Manual, (PropertyChangedCallback)OnWindowStartupLocationChanged));
		WindowStateProperty = DependencyProperty.Register("WindowState", typeof(WindowState), typeof(ChildWindow), (PropertyMetadata)new FrameworkPropertyMetadata((object)WindowState.Closed, (FrameworkPropertyMetadataOptions)256, (PropertyChangedCallback)OnWindowStatePropertyChanged));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ChildWindow), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(ChildWindow)));
	}

	public ChildWindow()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		DesignerWindowState = WindowState.Open;
		((Shape)_modalLayer).Fill = OverlayBrush;
		((UIElement)_modalLayer).Opacity = OverlayOpacity;
	}

	public override void OnApplyTemplate()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected Obj, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected Obj, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected Obj, but got Unknown
		DragDeltaEventHandler val = null;
		MouseButtonEventHandler val2 = null;
		RoutedEventHandler val3 = null;
		DragDeltaEventHandler val4 = null;
		MouseButtonEventHandler val5 = null;
		RoutedEventHandler val6 = null;
		RoutedEventHandler val7 = null;
		base.OnApplyTemplate();
		if (_windowControl != null)
		{
			WindowControl windowControl = _windowControl;
			if (val == null)
			{
				val = (object o, DragDeltaEventArgs e) =>
				{
					OnHeaderDragDelta(e);
				};
			}
			windowControl.HeaderDragDelta -= val;
			WindowControl windowControl2 = _windowControl;
			if (val2 == null)
			{
				val2 = (object o, MouseButtonEventArgs e) =>
				{
					OnHeaderIconDoubleClick(e);
				};
			}
			windowControl2.HeaderIconDoubleClicked -= val2;
			WindowControl windowControl3 = _windowControl;
			if (val3 == null)
			{
				val3 = (object o, RoutedEventArgs e) =>
				{
					OnCloseButtonClicked(e);
				};
			}
			windowControl3.CloseButtonClicked -= val3;
		}
		_windowControl = ((FrameworkElement)this).GetTemplateChild("PART_WindowControl") as WindowControl;
		if (_windowControl != null)
		{
			WindowControl windowControl4 = _windowControl;
			if (val4 == null)
			{
				val4 = (object o, DragDeltaEventArgs e) =>
				{
					OnHeaderDragDelta(e);
				};
			}
			windowControl4.HeaderDragDelta += val4;
			WindowControl windowControl5 = _windowControl;
			if (val5 == null)
			{
				val5 = (object o, MouseButtonEventArgs e) =>
				{
					OnHeaderIconDoubleClick(e);
				};
			}
			windowControl5.HeaderIconDoubleClicked += val5;
			WindowControl windowControl6 = _windowControl;
			if (val6 == null)
			{
				val6 = (object o, RoutedEventArgs e) =>
				{
					OnCloseButtonClicked(e);
				};
			}
			windowControl6.CloseButtonClicked += val6;
		}
		UpdateBlockMouseInputsPanel();
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_WindowRoot");
		_windowRoot = (Grid)(object)((templateChild is Grid) ? templateChild : null);
		if (_windowRoot != null)
		{
			((UIElement)_windowRoot).RenderTransform = (Transform)(object)_moveTransform;
		}
		_hasWindowContainer = VisualTreeHelper.GetParent((DependencyObject)(object)this) is WindowContainer;
		if (_hasWindowContainer)
		{
			return;
		}
		DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)(object)this);
		_parentContainer = (FrameworkElement)(object)((parent is FrameworkElement) ? parent : null);
		if (_parentContainer != null)
		{
			((UIElement)_parentContainer).LayoutUpdated += ParentContainer_LayoutUpdated;
			_parentContainer.SizeChanged += ParentContainer_SizeChanged;
			if (BrowserInteropHelper.IsBrowserHosted)
			{
				FrameworkElement parentContainer = _parentContainer;
				if (val7 == null)
				{
					val7 = (object o, RoutedEventArgs e) =>
					{
						ExecuteOpen();
					};
				}
				parentContainer.Loaded += val7;
			}
		}
		((FrameworkElement)this).Unloaded += ChildWindow_Unloaded;
		((FrameworkElement)_modalLayer).Height = _parentContainer.ActualHeight;
		((FrameworkElement)_modalLayer).Width = _parentContainer.ActualWidth;
		DependencyObject templateChild2 = ((FrameworkElement)this).GetTemplateChild("PART_Root");
		_root = (Grid)(object)((templateChild2 is Grid) ? templateChild2 : null);
		object obj;
		if (_root == null)
		{
			obj = null;
		}
		else
		{
			object obj2 = ((FrameworkElement)_root).Resources[(object)"FocusVisualStyle"];
			obj = ((obj2 is Style) ? obj2 : null);
		}
		Style val8 = (Style)obj;
		if (val8 != null)
		{
			Setter item = new Setter(FrameworkElement.DataContextProperty, (object)this);
			((Collection<SetterBase>)(object)val8.Setters).Add((SetterBase)(object)item);
			((FrameworkElement)this).FocusVisualStyle = val8;
		}
		if (_root != null)
		{
			((Panel)_root).Children.Add((UIElement)(object)_modalLayerPanel);
		}
	}

	protected override void OnGotFocus(RoutedEventArgs e)
	{
		((FrameworkElement)this).OnGotFocus(e);
		Action action = () =>
		{
			if (FocusedElement != null)
			{
				((UIElement)FocusedElement).Focus();
			}
		};
		((DispatcherObject)this).Dispatcher.BeginInvoke((DispatcherPriority)2, (Delegate)action);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected I4, but got Unknown
		((UIElement)this).OnKeyDown(e);
		if (WindowState == WindowState.Open)
		{
			Key key = e.Key;
			switch (key - 23)
			{
			case 0:
				Left -= 3.0;
				((RoutedEventArgs)e).Handled = true;
				break;
			case 2:
				Left += 3.0;
				((RoutedEventArgs)e).Handled = true;
				break;
			case 3:
				Top += 3.0;
				((RoutedEventArgs)e).Handled = true;
				break;
			case 1:
				Top -= 3.0;
				((RoutedEventArgs)e).Handled = true;
				break;
			}
		}
	}

	protected override void OnLeftPropertyChanged(double oldValue, double newValue)
	{
		base.OnLeftPropertyChanged(oldValue, newValue);
		_hasWindowContainer = VisualTreeHelper.GetParent((DependencyObject)(object)this) is WindowContainer;
		if (!_hasWindowContainer)
		{
			Left = GetRestrictedLeft();
			ProcessMove(newValue - oldValue, 0.0);
		}
	}

	protected override void OnTopPropertyChanged(double oldValue, double newValue)
	{
		base.OnTopPropertyChanged(oldValue, newValue);
		_hasWindowContainer = VisualTreeHelper.GetParent((DependencyObject)(object)this) is WindowContainer;
		if (!_hasWindowContainer)
		{
			Top = GetRestrictedTop();
			ProcessMove(0.0, newValue - oldValue);
		}
	}

	internal override void UpdateBlockMouseInputsPanel()
	{
		if (_windowControl != null)
		{
			_windowControl.IsBlockMouseInputsPanelActive = IsBlockMouseInputsPanelActive;
		}
	}

	protected virtual void OnHeaderDragDelta(DragDeltaEventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Invalid comparison between Unknown and I4
		if (IsCurrentWindow(((RoutedEventArgs)e).OriginalSource))
		{
			((RoutedEventArgs)e).Handled = true;
			DragDeltaEventArgs e2 = new DragDeltaEventArgs(e.HorizontalChange, e.VerticalChange);
			((RoutedEventArgs)e2).RoutedEvent = WindowControl.HeaderDragDeltaEvent;
			((RoutedEventArgs)e2).Source = this;
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
			if (!((RoutedEventArgs)e2).Handled && object.Equals(((RoutedEventArgs)e).OriginalSource, _windowControl))
			{
				double num = 0.0;
				num = (((int)((FrameworkElement)this).FlowDirection != 1) ? (Left + e.HorizontalChange) : (Left - e.HorizontalChange));
				Left = num;
				Top += e.VerticalChange;
			}
		}
	}

	protected virtual void OnHeaderIconDoubleClick(MouseButtonEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		if (IsCurrentWindow(((RoutedEventArgs)e).OriginalSource))
		{
			((RoutedEventArgs)e).Handled = true;
			MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, (MouseButton)0);
			((RoutedEventArgs)e2).RoutedEvent = WindowControl.HeaderIconDoubleClickedEvent;
			((RoutedEventArgs)e2).Source = this;
			((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
			if (!((RoutedEventArgs)e2).Handled)
			{
				Close();
			}
		}
	}

	protected virtual void OnCloseButtonClicked(RoutedEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		if (IsCurrentWindow(e.OriginalSource))
		{
			e.Handled = true;
			RoutedEventArgs e2 = new RoutedEventArgs(WindowControl.CloseButtonClickedEvent, (object)this);
			((UIElement)this).RaiseEvent(e2);
			if (!e2.Handled)
			{
				Close();
			}
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ParentContainer_LayoutUpdated(object sender, EventArgs e)
	{
		if (!DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this) && !_startupPositionInitialized)
		{
			ExecuteOpen();
			_startupPositionInitialized = true;
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ChildWindow_Unloaded(object sender, RoutedEventArgs e)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		RoutedEventHandler val = null;
		if (_parentContainer == null)
		{
			return;
		}
		((UIElement)_parentContainer).LayoutUpdated -= ParentContainer_LayoutUpdated;
		_parentContainer.SizeChanged -= ParentContainer_SizeChanged;
		if (!BrowserInteropHelper.IsBrowserHosted)
		{
			return;
		}
		FrameworkElement parentContainer = _parentContainer;
		if (val == null)
		{
			val = (object o, RoutedEventArgs ev) =>
			{
				ExecuteOpen();
			};
		}
		parentContainer.Loaded -= val;
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ParentContainer_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		Rectangle modalLayer = _modalLayer;
		Size newSize = e.NewSize;
		((FrameworkElement)modalLayer).Height = newSize.Height;
		Rectangle modalLayer2 = _modalLayer;
		Size newSize2 = e.NewSize;
		((FrameworkElement)modalLayer2).Width = newSize2.Width;
		Left = GetRestrictedLeft();
		Top = GetRestrictedTop();
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.GetRestrictedLeft() instead.")]
	private double GetRestrictedLeft()
	{
		if (Left < 0.0)
		{
			return 0.0;
		}
		if (_parentContainer != null && _windowRoot != null && Left + ((FrameworkElement)_windowRoot).ActualWidth > _parentContainer.ActualWidth && _parentContainer.ActualWidth != 0.0)
		{
			double num = _parentContainer.ActualWidth - ((FrameworkElement)_windowRoot).ActualWidth;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return Left;
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.GetRestrictedTop() instead.")]
	private double GetRestrictedTop()
	{
		if (Top < 0.0)
		{
			return 0.0;
		}
		if (_parentContainer != null && _windowRoot != null && Top + ((FrameworkElement)_windowRoot).ActualHeight > _parentContainer.ActualHeight && _parentContainer.ActualHeight != 0.0)
		{
			double num = _parentContainer.ActualHeight - ((FrameworkElement)_windowRoot).ActualHeight;
			if (!(num < 0.0))
			{
				return num;
			}
			return 0.0;
		}
		return Top;
	}

	private void SetWindowState(WindowState state)
	{
		switch (state)
		{
		case WindowState.Closed:
			ExecuteClose();
			break;
		case WindowState.Open:
			ExecuteOpen();
			break;
		}
	}

	private void ExecuteClose()
	{
		CancelEventArgs e = new CancelEventArgs();
		OnClosing(e);
		if (!e.Cancel)
		{
			if (!_dialogResult.HasValue)
			{
				_dialogResult = false;
			}
			OnClosed(EventArgs.Empty);
		}
		else
		{
			CancelClose();
		}
	}

	private void CancelClose()
	{
		_dialogResult = null;
		_ignorePropertyChanged = true;
		WindowState = WindowState.Open;
		_ignorePropertyChanged = false;
	}

	private void ExecuteOpen()
	{
		_dialogResult = null;
		if (!_hasWindowContainer && WindowStartupLocation == WindowStartupLocation.Center)
		{
			CenterChildWindow();
		}
		if (!_hasWindowContainer)
		{
			BringToFront();
		}
	}

	private bool IsCurrentWindow(object windowtoTest)
	{
		return object.Equals(_windowControl, windowtoTest);
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.BringToFront() instead.")]
	private void BringToFront()
	{
		int num = 0;
		if (_parentContainer != null)
		{
			num = (int)((DependencyObject)_parentContainer).GetValue(Panel.ZIndexProperty);
		}
		((DependencyObject)this).SetValue(Panel.ZIndexProperty, (object)(++num));
		if (IsModal)
		{
			Panel.SetZIndex((UIElement)(object)_modalLayerPanel, num - 2);
		}
	}

	[Obsolete("This method is obsolete and should no longer be used. Use WindowContainer.CenterChild() instead.")]
	private void CenterChildWindow()
	{
		if (_parentContainer != null && _windowRoot != null)
		{
			Left = (_parentContainer.ActualWidth - ((FrameworkElement)_windowRoot).ActualWidth) / 2.0;
			Top = (_parentContainer.ActualHeight - ((FrameworkElement)_windowRoot).ActualHeight) / 2.0;
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void ShowModalLayer()
	{
		if (!DesignerProperties.GetIsInDesignMode((DependencyObject)(object)this))
		{
			if (!((Panel)_modalLayerPanel).Children.Contains((UIElement)(object)_modalLayer))
			{
				((Panel)_modalLayerPanel).Children.Add((UIElement)(object)_modalLayer);
			}
			((UIElement)_modalLayer).Visibility = (Visibility)0;
		}
	}

	[Obsolete("This method is obsolete and should no longer be used.")]
	private void HideModalLayer()
	{
		((UIElement)_modalLayer).Visibility = (Visibility)2;
	}

	[Obsolete("This method is obsolete and should no longer be used. Use the ChildWindow in a WindowContainer instead.")]
	private void ProcessMove(double x, double y)
	{
		TranslateTransform moveTransform = _moveTransform;
		moveTransform.X += x;
		TranslateTransform moveTransform2 = _moveTransform;
		moveTransform2.Y += y;
		((UIElement)this).InvalidateArrange();
	}

	public void Show()
	{
		WindowState = WindowState.Open;
	}

	public void Close()
	{
		WindowState = WindowState.Closed;
	}

	protected virtual void OnClosed(EventArgs e)
	{
		if (Closed != null)
		{
			Closed(this, e);
		}
	}

	protected virtual void OnClosing(CancelEventArgs e)
	{
		if (Closing != null)
		{
			Closing(this, e);
		}
	}
}
