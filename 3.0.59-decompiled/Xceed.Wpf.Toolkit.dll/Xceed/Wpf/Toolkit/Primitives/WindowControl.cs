using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Xceed.Wpf.Toolkit.Primitives;

[TemplatePart(Name = "PART_ToolWindowCloseButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_CloseButton", Type = typeof(Button))]
[TemplatePart(Name = "PART_HeaderGrid", Type = typeof(Grid))]
[TemplatePart(Name = "PART_Icon", Type = typeof(Image))]
[TemplatePart(Name = "PART_HeaderThumb", Type = typeof(Thumb))]
[TemplatePart(Name = "PART_BlockMouseInputsBorder", Type = typeof(Border))]
public class WindowControl : ContentControl
{
	private const string PART_HeaderThumb = "PART_HeaderThumb";

	private const string PART_Icon = "PART_Icon";

	private const string PART_CloseButton = "PART_CloseButton";

	private const string PART_ToolWindowCloseButton = "PART_ToolWindowCloseButton";

	private const string PART_BlockMouseInputsBorder = "PART_BlockMouseInputsBorder";

	private const string PART_HeaderGrid = "PART_HeaderGrid";

	public static readonly ComponentResourceKey DefaultCloseButtonStyleKey;

	private Thumb _headerThumb;

	private Image _icon;

	private Button _closeButton;

	private Button _windowToolboxCloseButton;

	private bool _setIsActiveInternal;

	internal Border _windowBlockMouseInputsPanel;

	public static readonly DependencyProperty CaptionProperty;

	public static readonly DependencyProperty CaptionForegroundProperty;

	public static readonly DependencyProperty CaptionShadowBrushProperty;

	public static readonly DependencyProperty CaptionIconProperty;

	public static readonly DependencyProperty CloseButtonStyleProperty;

	public static readonly DependencyProperty CloseButtonVisibilityProperty;

	public static readonly DependencyProperty IsActiveProperty;

	public static readonly DependencyProperty LeftProperty;

	public static readonly DependencyProperty TopProperty;

	public static readonly DependencyProperty WindowBackgroundProperty;

	public static readonly DependencyProperty WindowBorderBrushProperty;

	public static readonly DependencyProperty WindowBorderThicknessProperty;

	public static readonly DependencyProperty WindowInactiveBackgroundProperty;

	public static readonly DependencyProperty WindowOpacityProperty;

	public static readonly DependencyProperty WindowStyleProperty;

	public static readonly DependencyProperty WindowThicknessProperty;

	private bool _IsBlockMouseInputsPanelActive;

	public static readonly RoutedEvent HeaderMouseLeftButtonClickedEvent;

	public static readonly RoutedEvent HeaderMouseRightButtonClickedEvent;

	public static readonly RoutedEvent HeaderMouseLeftButtonDoubleClickedEvent;

	public static readonly RoutedEvent HeaderDragDeltaEvent;

	public static readonly RoutedEvent HeaderIconClickedEvent;

	public static readonly RoutedEvent HeaderIconDoubleClickedEvent;

	public static readonly RoutedEvent CloseButtonClickedEvent;

	public string Caption
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CaptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionProperty, (object)value);
		}
	}

	public Brush CaptionForeground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(CaptionForegroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionForegroundProperty, (object)value);
		}
	}

	public Brush CaptionShadowBrush
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(CaptionShadowBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionShadowBrushProperty, (object)value);
		}
	}

	public ImageSource CaptionIcon
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (ImageSource)((DependencyObject)this).GetValue(CaptionIconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaptionIconProperty, (object)value);
		}
	}

	public Style CloseButtonStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Style)((DependencyObject)this).GetValue(CloseButtonStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseButtonStyleProperty, (object)value);
		}
	}

	public Visibility CloseButtonVisibility
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Visibility)((DependencyObject)this).GetValue(CloseButtonVisibilityProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(CloseButtonVisibilityProperty, (object)value);
		}
	}

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public double Left
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(LeftProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LeftProperty, (object)value);
		}
	}

	public double Top
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TopProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TopProperty, (object)value);
		}
	}

	public Brush WindowBackground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(WindowBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowBackgroundProperty, (object)value);
		}
	}

	public Brush WindowBorderBrush
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(WindowBorderBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowBorderBrushProperty, (object)value);
		}
	}

	public Thickness WindowBorderThickness
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Thickness)((DependencyObject)this).GetValue(WindowBorderThicknessProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(WindowBorderThicknessProperty, (object)value);
		}
	}

	public Brush WindowInactiveBackground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(WindowInactiveBackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowInactiveBackgroundProperty, (object)value);
		}
	}

	public double WindowOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(WindowOpacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WindowOpacityProperty, (object)value);
		}
	}

	public WindowStyle WindowStyle
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (WindowStyle)((DependencyObject)this).GetValue(WindowStyleProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(WindowStyleProperty, (object)value);
		}
	}

	public Thickness WindowThickness
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Thickness)((DependencyObject)this).GetValue(WindowThicknessProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(WindowThicknessProperty, (object)value);
		}
	}

	internal bool IsStartupPositionInitialized { get; set; }

	internal bool IsBlockMouseInputsPanelActive
	{
		get
		{
			return _IsBlockMouseInputsPanelActive;
		}
		set
		{
			if (value != _IsBlockMouseInputsPanelActive)
			{
				_IsBlockMouseInputsPanelActive = value;
				UpdateBlockMouseInputsPanel();
			}
		}
	}

	internal virtual bool AllowPublicIsActiveChange => true;

	internal event EventHandler<EventArgs> LeftChanged;

	internal event EventHandler<EventArgs> TopChanged;

	public event MouseButtonEventHandler HeaderMouseLeftButtonClicked
	{
		add
		{
			((UIElement)this).AddHandler(HeaderMouseLeftButtonClickedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(HeaderMouseLeftButtonClickedEvent, (Delegate)(object)value);
		}
	}

	public event MouseButtonEventHandler HeaderMouseRightButtonClicked
	{
		add
		{
			((UIElement)this).AddHandler(HeaderMouseRightButtonClickedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(HeaderMouseRightButtonClickedEvent, (Delegate)(object)value);
		}
	}

	public event MouseButtonEventHandler HeaderMouseLeftButtonDoubleClicked
	{
		add
		{
			((UIElement)this).AddHandler(HeaderMouseLeftButtonDoubleClickedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(HeaderMouseLeftButtonDoubleClickedEvent, (Delegate)(object)value);
		}
	}

	public event DragDeltaEventHandler HeaderDragDelta
	{
		add
		{
			((UIElement)this).AddHandler(HeaderDragDeltaEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(HeaderDragDeltaEvent, (Delegate)(object)value);
		}
	}

	public event MouseButtonEventHandler HeaderIconClicked
	{
		add
		{
			((UIElement)this).AddHandler(HeaderIconClickedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(HeaderIconClickedEvent, (Delegate)(object)value);
		}
	}

	public event MouseButtonEventHandler HeaderIconDoubleClicked
	{
		add
		{
			((UIElement)this).AddHandler(HeaderIconDoubleClickedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(HeaderIconDoubleClickedEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler CloseButtonClicked
	{
		add
		{
			((UIElement)this).AddHandler(CloseButtonClickedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(CloseButtonClickedEvent, (Delegate)(object)value);
		}
	}

	static WindowControl()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected Obj, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected Obj, but got Unknown
		//IL_01c1: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected Obj, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected Obj, but got Unknown
		//IL_020f: Expected Obj, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected Obj, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected Obj, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected Obj, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected Obj, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected Obj, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected Obj, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected Obj, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected Obj, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected Obj, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected Obj, but got Unknown
		DefaultCloseButtonStyleKey = new ComponentResourceKey(typeof(WindowControl), (object)"DefaultCloseButtonStyle");
		CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(WindowControl), (PropertyMetadata)new UIPropertyMetadata((object)string.Empty));
		CaptionForegroundProperty = DependencyProperty.Register("CaptionForeground", typeof(Brush), typeof(WindowControl), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		CaptionShadowBrushProperty = DependencyProperty.Register("CaptionShadowBrush", typeof(Brush), typeof(WindowControl), (PropertyMetadata)new UIPropertyMetadata((object)new SolidColorBrush(Color.FromArgb((byte)179, byte.MaxValue, byte.MaxValue, byte.MaxValue))));
		CaptionIconProperty = DependencyProperty.Register("CaptionIcon", typeof(ImageSource), typeof(WindowControl), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		CloseButtonStyleProperty = DependencyProperty.Register("CloseButtonStyle", typeof(Style), typeof(WindowControl), (PropertyMetadata)new UIPropertyMetadata((PropertyChangedCallback)null));
		CloseButtonVisibilityProperty = DependencyProperty.Register("CloseButtonVisibility", typeof(Visibility), typeof(WindowControl), new PropertyMetadata((object)(Visibility)0, (PropertyChangedCallback)null, (CoerceValueCallback)OnCoerceCloseButtonVisibility));
		IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(WindowControl), (PropertyMetadata)new UIPropertyMetadata((object)true, (PropertyChangedCallback)null, (CoerceValueCallback)OnCoerceIsActive));
		LeftProperty = DependencyProperty.Register("Left", typeof(double), typeof(WindowControl), new PropertyMetadata((object)0.0, (PropertyChangedCallback)OnLeftPropertyChanged, (CoerceValueCallback)OnCoerceLeft));
		TopProperty = DependencyProperty.Register("Top", typeof(double), typeof(WindowControl), new PropertyMetadata((object)0.0, (PropertyChangedCallback)OnTopPropertyChanged, (CoerceValueCallback)OnCoerceTop));
		WindowBackgroundProperty = DependencyProperty.Register("WindowBackground", typeof(Brush), typeof(WindowControl), new PropertyMetadata((PropertyChangedCallback)null));
		WindowBorderBrushProperty = DependencyProperty.Register("WindowBorderBrush", typeof(Brush), typeof(WindowControl), new PropertyMetadata((PropertyChangedCallback)null));
		WindowBorderThicknessProperty = DependencyProperty.Register("WindowBorderThickness", typeof(Thickness), typeof(WindowControl), new PropertyMetadata((object)new Thickness(0.0)));
		WindowInactiveBackgroundProperty = DependencyProperty.Register("WindowInactiveBackground", typeof(Brush), typeof(WindowControl), new PropertyMetadata((PropertyChangedCallback)null));
		WindowOpacityProperty = DependencyProperty.Register("WindowOpacity", typeof(double), typeof(WindowControl), new PropertyMetadata((object)1.0));
		WindowStyleProperty = DependencyProperty.Register("WindowStyle", typeof(WindowStyle), typeof(WindowControl), new PropertyMetadata((object)(WindowStyle)1, (PropertyChangedCallback)null, (CoerceValueCallback)OnCoerceWindowStyle));
		WindowThicknessProperty = DependencyProperty.Register("WindowThickness", typeof(Thickness), typeof(WindowControl), new PropertyMetadata((object)new Thickness(SystemParameters.ResizeFrameVerticalBorderWidth - 3.0, SystemParameters.ResizeFrameHorizontalBorderHeight - 3.0, SystemParameters.ResizeFrameVerticalBorderWidth - 3.0, SystemParameters.ResizeFrameHorizontalBorderHeight - 3.0)));
		HeaderMouseLeftButtonClickedEvent = EventManager.RegisterRoutedEvent("HeaderMouseLeftButtonClicked", (RoutingStrategy)1, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderMouseRightButtonClickedEvent = EventManager.RegisterRoutedEvent("HeaderMouseRightButtonClicked", (RoutingStrategy)1, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderMouseLeftButtonDoubleClickedEvent = EventManager.RegisterRoutedEvent("HeaderMouseLeftButtonDoubleClicked", (RoutingStrategy)1, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderDragDeltaEvent = EventManager.RegisterRoutedEvent("HeaderDragDelta", (RoutingStrategy)1, typeof(DragDeltaEventHandler), typeof(WindowControl));
		HeaderIconClickedEvent = EventManager.RegisterRoutedEvent("HeaderIconClicked", (RoutingStrategy)1, typeof(MouseButtonEventHandler), typeof(WindowControl));
		HeaderIconDoubleClickedEvent = EventManager.RegisterRoutedEvent("HeaderIconDoubleClicked", (RoutingStrategy)1, typeof(MouseButtonEventHandler), typeof(WindowControl));
		CloseButtonClickedEvent = EventManager.RegisterRoutedEvent("CloseButtonClicked", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(WindowControl));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowControl), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(WindowControl)));
	}

	private static object OnCoerceCloseButtonVisibility(DependencyObject d, object basevalue)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		if (!(d is WindowControl windowControl))
		{
			return basevalue;
		}
		return windowControl.OnCoerceCloseButtonVisibility((Visibility)basevalue);
	}

	protected virtual object OnCoerceCloseButtonVisibility(Visibility newValue)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return newValue;
	}

	private static object OnCoerceIsActive(DependencyObject d, object basevalue)
	{
		if (d is WindowControl { _setIsActiveInternal: false, AllowPublicIsActiveChange: false })
		{
			throw new InvalidOperationException("Cannot set IsActive directly. This is handled by the underlying system");
		}
		return basevalue;
	}

	internal void SetIsActiveInternal(bool isActive)
	{
		_setIsActiveInternal = true;
		IsActive = isActive;
		_setIsActiveInternal = false;
	}

	private static object OnCoerceLeft(DependencyObject d, object basevalue)
	{
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		WindowControl windowControl = (WindowControl)(object)d;
		if (windowControl == null)
		{
			return basevalue;
		}
		return windowControl.OnCoerceLeft(basevalue);
	}

	private object OnCoerceLeft(object newValue)
	{
		double num = (double)newValue;
		if (object.Equals(num, double.NaN))
		{
			return 0.0;
		}
		return newValue;
	}

	private static void OnLeftPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		if (obj is WindowControl windowControl)
		{
			windowControl.OnLeftPropertyChanged((double)e.OldValue, (double)e.NewValue);
		}
	}

	protected virtual void OnLeftPropertyChanged(double oldValue, double newValue)
	{
		LeftChanged?.Invoke(this, EventArgs.Empty);
	}

	private static object OnCoerceTop(DependencyObject d, object basevalue)
	{
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		WindowControl windowControl = (WindowControl)(object)d;
		if (windowControl == null)
		{
			return basevalue;
		}
		return windowControl.OnCoerceTop(basevalue);
	}

	private object OnCoerceTop(object newValue)
	{
		double num = (double)newValue;
		if (object.Equals(num, double.NaN))
		{
			return 0.0;
		}
		return newValue;
	}

	private static void OnTopPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		if (obj is WindowControl windowControl)
		{
			windowControl.OnTopPropertyChanged((double)e.OldValue, (double)e.NewValue);
		}
	}

	protected virtual void OnTopPropertyChanged(double oldValue, double newValue)
	{
		TopChanged?.Invoke(this, EventArgs.Empty);
	}

	private static object OnCoerceWindowStyle(DependencyObject d, object basevalue)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (basevalue == DependencyProperty.UnsetValue)
		{
			return basevalue;
		}
		if (!(d is WindowControl windowControl))
		{
			return basevalue;
		}
		return windowControl.OnCoerceWindowStyle((WindowStyle)basevalue);
	}

	protected virtual object OnCoerceWindowStyle(WindowStyle newValue)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return newValue;
	}

	private static void OnWindowStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		((WindowControl)(object)d)?.OnWindowStyleChanged((WindowStyle)e.OldValue, (WindowStyle)e.NewValue);
	}

	protected virtual void OnWindowStyleChanged(WindowStyle oldValue, WindowStyle newValue)
	{
	}

	public override void OnApplyTemplate()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected Obj, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected Obj, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected Obj, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		if (_headerThumb != null)
		{
			((UIElement)_headerThumb).PreviewMouseLeftButtonDown -= HeaderPreviewMouseLeftButtonDown;
			((UIElement)_headerThumb).PreviewMouseRightButtonDown -= HeaderPreviewMouseRightButtonDown;
			_headerThumb.DragDelta -= HeaderThumbDragDelta;
		}
		object obj = ((FrameworkTemplate)((Control)this).Template).FindName("PART_HeaderThumb", (FrameworkElement)(object)this);
		_headerThumb = (Thumb)((obj is Thumb) ? obj : null);
		if (_headerThumb != null)
		{
			((UIElement)_headerThumb).PreviewMouseLeftButtonDown += HeaderPreviewMouseLeftButtonDown;
			((UIElement)_headerThumb).PreviewMouseRightButtonDown += HeaderPreviewMouseRightButtonDown;
			_headerThumb.DragDelta += HeaderThumbDragDelta;
		}
		if (_icon != null)
		{
			((UIElement)_icon).MouseLeftButtonDown -= IconMouseLeftButtonDown;
		}
		object obj2 = ((FrameworkTemplate)((Control)this).Template).FindName("PART_Icon", (FrameworkElement)(object)this);
		_icon = (Image)((obj2 is Image) ? obj2 : null);
		if (_icon != null)
		{
			((UIElement)_icon).MouseLeftButtonDown += IconMouseLeftButtonDown;
		}
		if (_closeButton != null)
		{
			((ButtonBase)_closeButton).Click -= Close;
		}
		object obj3 = ((FrameworkTemplate)((Control)this).Template).FindName("PART_CloseButton", (FrameworkElement)(object)this);
		_closeButton = (Button)((obj3 is Button) ? obj3 : null);
		if (_closeButton != null)
		{
			((ButtonBase)_closeButton).Click += Close;
		}
		if (_windowToolboxCloseButton != null)
		{
			((ButtonBase)_windowToolboxCloseButton).Click -= Close;
		}
		object obj4 = ((FrameworkTemplate)((Control)this).Template).FindName("PART_ToolWindowCloseButton", (FrameworkElement)(object)this);
		_windowToolboxCloseButton = (Button)((obj4 is Button) ? obj4 : null);
		if (_windowToolboxCloseButton != null)
		{
			((ButtonBase)_windowToolboxCloseButton).Click += Close;
		}
		object obj5 = ((FrameworkTemplate)((Control)this).Template).FindName("PART_BlockMouseInputsBorder", (FrameworkElement)(object)this);
		_windowBlockMouseInputsPanel = (Border)((obj5 is Border) ? obj5 : null);
		UpdateBlockMouseInputsPanel();
	}

	private void HeaderPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, (MouseButton)0);
		((RoutedEventArgs)e2).RoutedEvent = ((e.ClickCount == 2) ? HeaderMouseLeftButtonDoubleClickedEvent : HeaderMouseLeftButtonClickedEvent);
		((RoutedEventArgs)e2).Source = this;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
	}

	private void HeaderPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, (MouseButton)2);
		((RoutedEventArgs)e2).RoutedEvent = HeaderMouseRightButtonClickedEvent;
		((RoutedEventArgs)e2).Source = this;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
	}

	private void HeaderThumbDragDelta(object sender, DragDeltaEventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		DragDeltaEventArgs e2 = new DragDeltaEventArgs(e.HorizontalChange, e.VerticalChange);
		((RoutedEventArgs)e2).RoutedEvent = HeaderDragDeltaEvent;
		((RoutedEventArgs)e2).Source = this;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
	}

	private void IconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		MouseButtonEventArgs e2 = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, (MouseButton)0);
		((RoutedEventArgs)e2).RoutedEvent = ((e.ClickCount == 2) ? HeaderIconDoubleClickedEvent : HeaderIconClickedEvent);
		((RoutedEventArgs)e2).Source = this;
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)e2);
	}

	private void Close(object sender, RoutedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		((UIElement)this).RaiseEvent(new RoutedEventArgs(CloseButtonClickedEvent, (object)this));
	}

	internal virtual void UpdateBlockMouseInputsPanel()
	{
		if (_windowBlockMouseInputsPanel != null)
		{
			((UIElement)_windowBlockMouseInputsPanel).Visibility = (Visibility)((!IsBlockMouseInputsPanelActive) ? 2 : 0);
		}
	}

	internal double GetHeaderHeight()
	{
		object obj = ((FrameworkTemplate)((Control)this).Template).FindName("PART_HeaderGrid", (FrameworkElement)(object)this);
		Grid val = (Grid)((obj is Grid) ? obj : null);
		if (val != null)
		{
			return ((FrameworkElement)val).ActualHeight;
		}
		return 0.0;
	}
}
