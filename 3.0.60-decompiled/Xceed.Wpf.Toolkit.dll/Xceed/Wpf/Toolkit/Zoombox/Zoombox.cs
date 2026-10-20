using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Security;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

public sealed class Zoombox : ContentControl
{
	private sealed class ViewFinderSelectionConverter : IValueConverter
	{
		private readonly Zoombox _zoombox;

		public ViewFinderSelectionConverter(Zoombox zoombox)
		{
			_zoombox = zoombox;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			Rect val = (Rect)value;
			if (val.IsEmpty)
			{
				return val;
			}
			double num = _zoombox._viewFinderDisplay.Scale * _zoombox._viewboxFactor;
			Rect val2 = new Rect(val.Left * num, val.Top * num, val.Width * num, val.Height * num);
			Rect contentBounds = _zoombox._viewFinderDisplay.ContentBounds;
			double left = contentBounds.Left;
			Rect contentBounds2 = _zoombox._viewFinderDisplay.ContentBounds;
			val2.Offset(left, contentBounds2.Top);
			return val2;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}

	internal sealed class DragAdorner : Adorner
	{
		public static readonly DependencyProperty BrushProperty = DependencyProperty.Register("Brush", typeof(Brush), typeof(DragAdorner), (PropertyMetadata)new FrameworkPropertyMetadata((object)Brushes.Transparent, (FrameworkPropertyMetadataOptions)16));

		public static readonly DependencyProperty PenProperty = DependencyProperty.Register("Pen", typeof(Pen), typeof(DragAdorner), (PropertyMetadata)new FrameworkPropertyMetadata((object)new Pen((Brush)new SolidColorBrush(Color.FromArgb((byte)127, (byte)63, (byte)63, (byte)63)), 2.0), (FrameworkPropertyMetadataOptions)16));

		public static readonly DependencyProperty RectProperty = DependencyProperty.Register("Rect", typeof(Rect), typeof(DragAdorner), (PropertyMetadata)new FrameworkPropertyMetadata((object)Rect.Empty, (FrameworkPropertyMetadataOptions)16, (PropertyChangedCallback)OnRectChanged));

		private Point _cachedPosition;

		private Size _cachedSize;

		public Brush Brush
		{
			get
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Expected Obj, but got Unknown
				return (Brush)((DependencyObject)this).GetValue(BrushProperty);
			}
			set
			{
				((DependencyObject)this).SetValue(BrushProperty, (object)value);
			}
		}

		public Pen Pen
		{
			get
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Expected Obj, but got Unknown
				return (Pen)((DependencyObject)this).GetValue(PenProperty);
			}
			set
			{
				((DependencyObject)this).SetValue(PenProperty, (object)value);
			}
		}

		public Rect Rect
		{
			get
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				return (Rect)((DependencyObject)this).GetValue(RectProperty);
			}
			set
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				((DependencyObject)this).SetValue(RectProperty, (object)value);
			}
		}

		public Point LastPosition
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _cachedPosition;
			}
		}

		public Size LastSize
		{
			get
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				return _cachedSize;
			}
		}

		public DragAdorner(UIElement adornedElement)
			: base(adornedElement)
		{
			((UIElement)this).ClipToBounds = true;
		}

		private static void OnRectChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			DragAdorner dragAdorner = (DragAdorner)(object)d;
			Rect val = (Rect)e.NewValue;
			if (!val.IsEmpty)
			{
				Rect val2 = (Rect)e.NewValue;
				dragAdorner._cachedPosition = val2.TopLeft;
				Rect val3 = (Rect)e.NewValue;
				dragAdorner._cachedSize = val3.Size;
			}
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			drawingContext.DrawRectangle(Brush, Pen, Rect);
		}

		static DragAdorner()
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected Obj, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected Obj, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected Obj, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected Obj, but got Unknown
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected Obj, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected Obj, but got Unknown
		}
	}

	private enum CacheBits
	{
		IsUpdatingView = 1,
		IsUpdatingViewport = 2,
		IsDraggingViewport = 4,
		IsResizingViewport = 8,
		IsMonitoringInput = 0x10,
		IsContentWrapped = 0x20,
		HasArrangedContentPresenter = 0x40,
		HasRenderedFirstView = 0x80,
		RefocusViewOnFirstRender = 0x100,
		HasUIPermission = 0x200
	}

	private enum ResizeEdge
	{
		None,
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight,
		Left,
		Top,
		Right,
		Bottom
	}

	public static readonly DependencyProperty AnimationAccelerationRatioProperty;

	public static readonly DependencyProperty AnimationDecelerationRatioProperty;

	public static readonly DependencyProperty AnimationDurationProperty;

	private static readonly DependencyPropertyKey AreDragModifiersActivePropertyKey;

	public static readonly DependencyProperty AreDragModifiersActiveProperty;

	private static readonly DependencyPropertyKey AreRelativeZoomModifiersActivePropertyKey;

	public static readonly DependencyProperty AreRelativeZoomModifiersActiveProperty;

	private static readonly DependencyPropertyKey AreZoomModifiersActivePropertyKey;

	public static readonly DependencyProperty AreZoomModifiersActiveProperty;

	private static readonly DependencyPropertyKey AreZoomToSelectionModifiersActivePropertyKey;

	public static readonly DependencyProperty AreZoomToSelectionModifiersActiveProperty;

	public static readonly DependencyProperty AutoWrapContentWithViewboxProperty;

	private UIElement _trueContent;

	private static readonly DependencyPropertyKey CurrentViewPropertyKey;

	public static readonly DependencyProperty CurrentViewProperty;

	private static readonly DependencyPropertyKey CurrentViewIndexPropertyKey;

	public static readonly DependencyProperty CurrentViewIndexProperty;

	public static readonly DependencyProperty DragModifiersProperty;

	public static readonly DependencyProperty DragOnPreviewProperty;

	private static readonly DependencyPropertyKey EffectiveViewStackModePropertyKey;

	public static readonly DependencyProperty EffectiveViewStackModeProperty;

	private static readonly DependencyPropertyKey HasBackStackPropertyKey;

	public static readonly DependencyProperty HasBackStackProperty;

	private static readonly DependencyPropertyKey HasForwardStackPropertyKey;

	public static readonly DependencyProperty HasForwardStackProperty;

	public static readonly DependencyProperty IsAnimatedProperty;

	private static readonly DependencyPropertyKey IsDraggingContentPropertyKey;

	public static readonly DependencyProperty IsDraggingContentProperty;

	private static readonly DependencyPropertyKey IsSelectingRegionPropertyKey;

	public static readonly DependencyProperty IsSelectingRegionProperty;

	public static readonly DependencyProperty MaxScaleProperty;

	public static readonly DependencyProperty MinScaleProperty;

	public static readonly DependencyProperty NavigateOnPreviewProperty;

	public static readonly DependencyProperty PanDistanceProperty;

	public static readonly DependencyProperty PositionProperty;

	public static readonly DependencyProperty RelativeZoomModifiersProperty;

	public static readonly DependencyProperty ScaleProperty;

	private static readonly DependencyPropertyKey ViewFinderPropertyKey;

	public static readonly DependencyProperty ViewFinderProperty;

	public static readonly DependencyProperty ViewFinderVisibilityProperty;

	private static readonly DependencyPropertyKey ViewportPropertyKey;

	public static readonly DependencyProperty ViewportProperty;

	private static readonly DependencyPropertyKey ViewStackCountPropertyKey;

	public static readonly DependencyProperty ViewStackCountProperty;

	public static readonly DependencyProperty ViewStackIndexProperty;

	public static readonly DependencyProperty ViewStackModeProperty;

	public static readonly DependencyProperty ViewStackSourceProperty;

	public static readonly DependencyProperty ZoomModifiersProperty;

	public static readonly DependencyProperty ZoomOnPreviewProperty;

	public static readonly DependencyProperty ZoomOriginProperty;

	public static readonly DependencyProperty ZoomPercentageProperty;

	public static readonly DependencyProperty ZoomOnProperty;

	public static readonly DependencyProperty ZoomToSelectionModifiersProperty;

	public static readonly DependencyProperty KeepContentInBoundsProperty;

	public static readonly RoutedEvent AnimationBeginningEvent;

	public static readonly RoutedEvent AnimationCompletedEvent;

	public static readonly RoutedEvent CurrentViewChangedEvent;

	public static readonly RoutedEvent ViewStackIndexChangedEvent;

	public static RoutedUICommand Back;

	public static RoutedUICommand Center;

	public static RoutedUICommand Fill;

	public static RoutedUICommand Fit;

	public static RoutedUICommand Forward;

	public static RoutedUICommand Home;

	public static RoutedUICommand PanDown;

	public static RoutedUICommand PanLeft;

	public static RoutedUICommand PanRight;

	public static RoutedUICommand PanUp;

	public static RoutedUICommand Refocus;

	public static RoutedUICommand ZoomIn;

	public static RoutedUICommand ZoomOut;

	private static int MOUSE_WHEEL_DELTA;

	private ContentPresenter _contentPresenter;

	private UIElement _content;

	private DragAdorner _dragAdorner;

	private ZoomboxViewStack _viewStack;

	private ZoomboxViewFinderDisplay _viewFinderDisplay;

	private Rect _resizeViewportBounds = Rect.Empty;

	private Point _resizeAnchorPoint = new Point(0.0, 0.0);

	private Point _resizeDraggingPoint = new Point(0.0, 0.0);

	private Point _originPoint = new Point(0.0, 0.0);

	private double _viewboxFactor = 1.0;

	private double _relativeScale = 1.0;

	private Point _relativePosition = default;

	private Point _basePosition = default;

	private DateTime _lastStackAddition;

	private int _lastViewIndex = -1;

	private BitVector32 _cacheBits = new BitVector32(0);

	public double AnimationAccelerationRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AnimationAccelerationRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnimationAccelerationRatioProperty, (object)value);
		}
	}

	public double AnimationDecelerationRatio
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AnimationDecelerationRatioProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AnimationDecelerationRatioProperty, (object)value);
		}
	}

	public Duration AnimationDuration
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Duration)((DependencyObject)this).GetValue(AnimationDurationProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(AnimationDurationProperty, (object)value);
		}
	}

	public bool AreDragModifiersActive => (bool)((DependencyObject)this).GetValue(AreDragModifiersActiveProperty);

	public bool AreRelativeZoomModifiersActive => (bool)((DependencyObject)this).GetValue(AreRelativeZoomModifiersActiveProperty);

	public bool AreZoomModifiersActive => (bool)((DependencyObject)this).GetValue(AreZoomModifiersActiveProperty);

	public bool AreZoomToSelectionModifiersActive => (bool)((DependencyObject)this).GetValue(AreZoomToSelectionModifiersActiveProperty);

	public bool AutoWrapContentWithViewbox
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoWrapContentWithViewboxProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoWrapContentWithViewboxProperty, (object)value);
		}
	}

	public ZoomboxView CurrentView => (ZoomboxView)((DependencyObject)this).GetValue(CurrentViewProperty);

	public int CurrentViewIndex => (int)((DependencyObject)this).GetValue(CurrentViewIndexProperty);

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection DragModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(DragModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragModifiersProperty, (object)value);
		}
	}

	public bool DragOnPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DragOnPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragOnPreviewProperty, (object)value);
		}
	}

	public ZoomboxViewStackMode EffectiveViewStackMode => (ZoomboxViewStackMode)((DependencyObject)this).GetValue(EffectiveViewStackModeProperty);

	public bool HasBackStack => (bool)((DependencyObject)this).GetValue(HasBackStackProperty);

	public bool HasForwardStack => (bool)((DependencyObject)this).GetValue(HasForwardStackProperty);

	public bool IsAnimated
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsAnimatedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsAnimatedProperty, (object)value);
		}
	}

	public bool IsDraggingContent => (bool)((DependencyObject)this).GetValue(IsDraggingContentProperty);

	public bool IsSelectingRegion => (bool)((DependencyObject)this).GetValue(IsSelectingRegionProperty);

	public double MaxScale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MaxScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MaxScaleProperty, (object)value);
		}
	}

	public double MinScale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinScaleProperty, (object)value);
		}
	}

	public bool NavigateOnPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(NavigateOnPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NavigateOnPreviewProperty, (object)value);
		}
	}

	public double PanDistance
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PanDistanceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PanDistanceProperty, (object)value);
		}
	}

	public Point Position
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Point)((DependencyObject)this).GetValue(PositionProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(PositionProperty, (object)value);
		}
	}

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection RelativeZoomModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(RelativeZoomModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RelativeZoomModifiersProperty, (object)value);
		}
	}

	public double Scale
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ScaleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScaleProperty, (object)value);
		}
	}

	public FrameworkElement ViewFinder
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (FrameworkElement)((DependencyObject)this).GetValue(ViewFinderProperty);
		}
	}

	public Rect Viewport
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Rect)((DependencyObject)this).GetValue(ViewportProperty);
		}
	}

	public int ViewStackCount => (int)((DependencyObject)this).GetValue(ViewStackCountProperty);

	public int ViewStackIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ViewStackIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewStackIndexProperty, (object)value);
		}
	}

	public ZoomboxViewStackMode ViewStackMode
	{
		get
		{
			return (ZoomboxViewStackMode)((DependencyObject)this).GetValue(ViewStackModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewStackModeProperty, (object)value);
		}
	}

	[Bindable(true)]
	public IEnumerable ViewStackSource
	{
		get
		{
			if (_viewStack != null)
			{
				return ViewStack.Source;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				((DependencyObject)this).ClearValue(ViewStackSourceProperty);
			}
			else
			{
				((DependencyObject)this).SetValue(ViewStackSourceProperty, (object)value);
			}
		}
	}

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection ZoomModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(ZoomModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomModifiersProperty, (object)value);
		}
	}

	public bool ZoomOnPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ZoomOnPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomOnPreviewProperty, (object)value);
		}
	}

	public Point ZoomOrigin
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Point)((DependencyObject)this).GetValue(ZoomOriginProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(ZoomOriginProperty, (object)value);
		}
	}

	public double ZoomPercentage
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomPercentageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomPercentageProperty, (object)value);
		}
	}

	public ZoomboxZoomOn ZoomOn
	{
		get
		{
			return (ZoomboxZoomOn)((DependencyObject)this).GetValue(ZoomOnProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomOnProperty, (object)value);
		}
	}

	[TypeConverter(typeof(KeyModifierCollectionConverter))]
	public KeyModifierCollection ZoomToSelectionModifiers
	{
		get
		{
			return (KeyModifierCollection)((DependencyObject)this).GetValue(ZoomToSelectionModifiersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomToSelectionModifiersProperty, (object)value);
		}
	}

	public bool KeepContentInBounds
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(KeepContentInBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(KeepContentInBoundsProperty, (object)value);
		}
	}

	public ZoomboxViewStack ViewStack
	{
		get
		{
			if (_viewStack == null && EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
			{
				_viewStack = new ZoomboxViewStack(this);
			}
			return _viewStack;
		}
	}

	internal bool HasArrangedContentPresenter
	{
		get
		{
			return _cacheBits[64];
		}
		set
		{
			_cacheBits[64] = value;
		}
	}

	internal bool IsUpdatingView
	{
		get
		{
			return _cacheBits[1];
		}
		set
		{
			_cacheBits[1] = value;
		}
	}

	private Vector ContentOffset
	{
		get
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected I4, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Expected I4, but got Unknown
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			if (IsContentWrapped || _content == null || !(_content is FrameworkElement))
			{
				return new Vector(0.0, 0.0);
			}
			double num = 0.0;
			double num2 = 0.0;
			Rect contentRect = ContentRect;
			Size size = contentRect.Size;
			UIElement content = _content;
			HorizontalAlignment horizontalAlignment = ((FrameworkElement)((content is FrameworkElement) ? content : null)).HorizontalAlignment;
			switch (horizontalAlignment - 1)
			{
			case 0:
			case 2:
			{
				Size renderSize2 = ((UIElement)this).RenderSize;
				num = (renderSize2.Width - size.Width) / 2.0;
				break;
			}
			case 1:
			{
				Size renderSize = ((UIElement)this).RenderSize;
				num = renderSize.Width - size.Width;
				break;
			}
			}
			UIElement content2 = _content;
			VerticalAlignment verticalAlignment = ((FrameworkElement)((content2 is FrameworkElement) ? content2 : null)).VerticalAlignment;
			switch (verticalAlignment - 1)
			{
			case 0:
			case 2:
			{
				Size renderSize4 = ((UIElement)this).RenderSize;
				num2 = (renderSize4.Height - size.Height) / 2.0;
				break;
			}
			case 1:
			{
				Size renderSize3 = ((UIElement)this).RenderSize;
				num2 = renderSize3.Height - size.Height;
				break;
			}
			}
			return new Vector(num, num2);
		}
	}

	private Rect ContentRect
	{
		get
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			if (_content != null)
			{
				Size renderSize = _content.RenderSize;
				double num = renderSize.Width / _viewboxFactor;
				Size renderSize2 = _content.RenderSize;
				return new Rect(new Size(num, renderSize2.Height / _viewboxFactor));
			}
			return Rect.Empty;
		}
	}

	private bool HasRenderedFirstView
	{
		get
		{
			return _cacheBits[128];
		}
		set
		{
			_cacheBits[128] = value;
		}
	}

	private bool HasUIPermission => _cacheBits[512];

	private bool IsContentWrapped
	{
		get
		{
			return _cacheBits[32];
		}
		set
		{
			_cacheBits[32] = value;
		}
	}

	private bool IsDraggingViewport
	{
		get
		{
			return _cacheBits[4];
		}
		set
		{
			_cacheBits[4] = value;
		}
	}

	private bool IsMonitoringInput
	{
		get
		{
			return _cacheBits[16];
		}
		set
		{
			_cacheBits[16] = value;
		}
	}

	private bool IsResizingViewport
	{
		get
		{
			return _cacheBits[8];
		}
		set
		{
			_cacheBits[8] = value;
		}
	}

	private bool IsUpdatingViewport
	{
		get
		{
			return _cacheBits[2];
		}
		set
		{
			_cacheBits[2] = value;
		}
	}

	private bool RefocusViewOnFirstRender
	{
		get
		{
			return _cacheBits[256];
		}
		set
		{
			_cacheBits[256] = value;
		}
	}

	private Rect ViewFinderDisplayRect
	{
		get
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			if (_viewFinderDisplay != null)
			{
				Point val = new Point(0.0, 0.0);
				Size renderSize = ((UIElement)_viewFinderDisplay).RenderSize;
				double width = renderSize.Width;
				Size renderSize2 = ((UIElement)_viewFinderDisplay).RenderSize;
				return new Rect(val, new Point(width, renderSize2.Height));
			}
			return Rect.Empty;
		}
	}

	public event RoutedEventHandler AnimationBeginning
	{
		add
		{
			((UIElement)this).AddHandler(AnimationBeginningEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(AnimationBeginningEvent, (Delegate)(object)value);
		}
	}

	public event RoutedEventHandler AnimationCompleted
	{
		add
		{
			((UIElement)this).AddHandler(AnimationCompletedEvent, (Delegate)(object)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(AnimationCompletedEvent, (Delegate)(object)value);
		}
	}

	public event ZoomboxViewChangedEventHandler CurrentViewChanged
	{
		add
		{
			((UIElement)this).AddHandler(CurrentViewChangedEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(CurrentViewChangedEvent, (Delegate)value);
		}
	}

	public event IndexChangedEventHandler ViewStackIndexChanged
	{
		add
		{
			((UIElement)this).AddHandler(ViewStackIndexChangedEvent, (Delegate)value);
		}
		remove
		{
			((UIElement)this).RemoveHandler(ViewStackIndexChangedEvent, (Delegate)value);
		}
	}

	static Zoombox()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_003d: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_007f: Expected Obj, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Obj, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected Obj, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected Obj, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected Obj, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected Obj, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected Obj, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected Obj, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Obj, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected Obj, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected Obj, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected Obj, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Expected Obj, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected Obj, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected Obj, but got Unknown
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected Obj, but got Unknown
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected Obj, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected Obj, but got Unknown
		//IL_0483: Expected Obj, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected Obj, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Expected Obj, but got Unknown
		//IL_04d2: Expected Obj, but got Unknown
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Expected Obj, but got Unknown
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected Obj, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected Obj, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected Obj, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected Obj, but got Unknown
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Expected Obj, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Expected Obj, but got Unknown
		//IL_05ef: Expected Obj, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected Obj, but got Unknown
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Expected Obj, but got Unknown
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected Obj, but got Unknown
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Expected Obj, but got Unknown
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Expected Obj, but got Unknown
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Expected Obj, but got Unknown
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Expected Obj, but got Unknown
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		//IL_0731: Expected Obj, but got Unknown
		//IL_0731: Expected Obj, but got Unknown
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Expected Obj, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_076d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0777: Expected Obj, but got Unknown
		//IL_0777: Expected Obj, but got Unknown
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_077c: Expected Obj, but got Unknown
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected Obj, but got Unknown
		//IL_07a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Expected Obj, but got Unknown
		//IL_07d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07de: Expected Obj, but got Unknown
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected Obj, but got Unknown
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0846: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Expected Obj, but got Unknown
		//IL_087c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Expected Obj, but got Unknown
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Expected Obj, but got Unknown
		//IL_08d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected Obj, but got Unknown
		//IL_090c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0916: Expected Obj, but got Unknown
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Expected Obj, but got Unknown
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Expected Obj, but got Unknown
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ec: Expected Obj, but got Unknown
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Expected Obj, but got Unknown
		//IL_0a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a28: Expected Obj, but got Unknown
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Expected Obj, but got Unknown
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Expected Obj, but got Unknown
		//IL_0a78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a82: Expected Obj, but got Unknown
		//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa0: Expected Obj, but got Unknown
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Expected Obj, but got Unknown
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adc: Expected Obj, but got Unknown
		//IL_0af0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afa: Expected Obj, but got Unknown
		//IL_0b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Expected Obj, but got Unknown
		//IL_0b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b36: Expected Obj, but got Unknown
		//IL_0b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b60: Expected Obj, but got Unknown
		//IL_0b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7f: Expected Obj, but got Unknown
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9e: Expected Obj, but got Unknown
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc4: Expected Obj, but got Unknown
		//IL_0bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc9: Expected Obj, but got Unknown
		//IL_0be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bef: Expected Obj, but got Unknown
		//IL_0bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Expected Obj, but got Unknown
		//IL_0c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c15: Expected Obj, but got Unknown
		//IL_0c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Expected Obj, but got Unknown
		AnimationAccelerationRatioProperty = DependencyProperty.Register("AnimationAccelerationRatio", typeof(double), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)0.0), (ValidateValueCallback)ValidateAccelerationRatio);
		AnimationDecelerationRatioProperty = DependencyProperty.Register("AnimationDecelerationRatio", typeof(double), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)0.0), (ValidateValueCallback)ValidateDecelerationRatio);
		AnimationDurationProperty = DependencyProperty.Register("AnimationDuration", typeof(Duration), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)new Duration(TimeSpan.FromMilliseconds(300.0))));
		AreDragModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreDragModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		AreDragModifiersActiveProperty = AreDragModifiersActivePropertyKey.DependencyProperty;
		AreRelativeZoomModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreRelativeZoomModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		AreRelativeZoomModifiersActiveProperty = AreRelativeZoomModifiersActivePropertyKey.DependencyProperty;
		AreZoomModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreZoomModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		AreZoomModifiersActiveProperty = AreZoomModifiersActivePropertyKey.DependencyProperty;
		AreZoomToSelectionModifiersActivePropertyKey = DependencyProperty.RegisterReadOnly("AreZoomToSelectionModifiersActive", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		AreZoomToSelectionModifiersActiveProperty = AreZoomToSelectionModifiersActivePropertyKey.DependencyProperty;
		AutoWrapContentWithViewboxProperty = DependencyProperty.Register("AutoWrapContentWithViewbox", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)OnAutoWrapContentWithViewboxChanged));
		CurrentViewPropertyKey = DependencyProperty.RegisterReadOnly("CurrentView", typeof(ZoomboxView), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)ZoomboxView.Empty, (PropertyChangedCallback)OnCurrentViewChanged));
		CurrentViewProperty = CurrentViewPropertyKey.DependencyProperty;
		CurrentViewIndexPropertyKey = DependencyProperty.RegisterReadOnly("CurrentViewIndex", typeof(int), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)(-1)));
		CurrentViewIndexProperty = CurrentViewIndexPropertyKey.DependencyProperty;
		DragModifiersProperty = DependencyProperty.Register("DragModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)GetDefaultDragModifiers()));
		DragOnPreviewProperty = DependencyProperty.Register("DragOnPreview", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		EffectiveViewStackModePropertyKey = DependencyProperty.RegisterReadOnly("EffectiveViewStackMode", typeof(ZoomboxViewStackMode), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)ZoomboxViewStackMode.Auto));
		EffectiveViewStackModeProperty = EffectiveViewStackModePropertyKey.DependencyProperty;
		HasBackStackPropertyKey = DependencyProperty.RegisterReadOnly("HasBackStack", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		HasBackStackProperty = HasBackStackPropertyKey.DependencyProperty;
		HasForwardStackPropertyKey = DependencyProperty.RegisterReadOnly("HasForwardStack", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		HasForwardStackProperty = HasForwardStackPropertyKey.DependencyProperty;
		IsAnimatedProperty = DependencyProperty.Register("IsAnimated", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)null, (CoerceValueCallback)CoerceIsAnimatedValue));
		IsDraggingContentPropertyKey = DependencyProperty.RegisterReadOnly("IsDraggingContent", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		IsDraggingContentProperty = IsDraggingContentPropertyKey.DependencyProperty;
		IsSelectingRegionPropertyKey = DependencyProperty.RegisterReadOnly("IsSelectingRegion", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		IsSelectingRegionProperty = IsSelectingRegionPropertyKey.DependencyProperty;
		MaxScaleProperty = DependencyProperty.Register("MaxScale", typeof(double), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)100.0, (FrameworkPropertyMetadataOptions)1, (PropertyChangedCallback)OnMaxScaleChanged, (CoerceValueCallback)CoerceMaxScaleValue));
		MinScaleProperty = DependencyProperty.Register("MinScale", typeof(double), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)0.01, (FrameworkPropertyMetadataOptions)1, (PropertyChangedCallback)OnMinScaleChanged, (CoerceValueCallback)CoerceMinScaleValue));
		NavigateOnPreviewProperty = DependencyProperty.Register("NavigateOnPreview", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false));
		PanDistanceProperty = DependencyProperty.Register("PanDistance", typeof(double), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)5.0));
		PositionProperty = DependencyProperty.Register("Position", typeof(Point), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)PointHelper.Empty, (PropertyChangedCallback)OnPositionChanged));
		RelativeZoomModifiersProperty = DependencyProperty.Register("RelativeZoomModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)GetDefaultRelativeZoomModifiers()));
		ScaleProperty = DependencyProperty.Register("Scale", typeof(double), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)double.NaN, (PropertyChangedCallback)OnScaleChanged, (CoerceValueCallback)CoerceScaleValue));
		ViewFinderPropertyKey = DependencyProperty.RegisterReadOnly("ViewFinder", typeof(FrameworkElement), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)null));
		ViewFinderProperty = ViewFinderPropertyKey.DependencyProperty;
		ViewFinderVisibilityProperty = DependencyProperty.RegisterAttached("ViewFinderVisibility", typeof(Visibility), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)(Visibility)0));
		ViewportPropertyKey = DependencyProperty.RegisterReadOnly("Viewport", typeof(Rect), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)Rect.Empty, (PropertyChangedCallback)OnViewportChanged));
		ViewportProperty = ViewportPropertyKey.DependencyProperty;
		ViewStackCountPropertyKey = DependencyProperty.RegisterReadOnly("ViewStackCount", typeof(int), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)(-1), (PropertyChangedCallback)OnViewStackCountChanged));
		ViewStackCountProperty = ViewStackCountPropertyKey.DependencyProperty;
		ViewStackIndexProperty = DependencyProperty.Register("ViewStackIndex", typeof(int), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)(-1), (PropertyChangedCallback)OnViewStackIndexChanged, (CoerceValueCallback)CoerceViewStackIndexValue));
		ViewStackModeProperty = DependencyProperty.Register("ViewStackMode", typeof(ZoomboxViewStackMode), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)ZoomboxViewStackMode.Default, (PropertyChangedCallback)OnViewStackModeChanged, (CoerceValueCallback)CoerceViewStackModeValue));
		ViewStackSourceProperty = DependencyProperty.Register("ViewStackSource", typeof(IEnumerable), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)OnViewStackSourceChanged));
		ZoomModifiersProperty = DependencyProperty.Register("ZoomModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)GetDefaultZoomModifiers()));
		ZoomOnPreviewProperty = DependencyProperty.Register("ZoomOnPreview", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)true));
		ZoomOriginProperty = DependencyProperty.Register("ZoomOrigin", typeof(Point), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)new Point(0.5, 0.5)));
		ZoomPercentageProperty = DependencyProperty.Register("ZoomPercentage", typeof(double), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)5.0));
		ZoomOnProperty = DependencyProperty.Register("ZoomOn", typeof(ZoomboxZoomOn), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)ZoomboxZoomOn.Content));
		ZoomToSelectionModifiersProperty = DependencyProperty.Register("ZoomToSelectionModifiers", typeof(KeyModifierCollection), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)GetDefaultZoomToSelectionModifiers()));
		KeepContentInBoundsProperty = DependencyProperty.Register("KeepContentInBounds", typeof(bool), typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)OnKeepContentInBoundsChanged));
		AnimationBeginningEvent = EventManager.RegisterRoutedEvent("AnimationBeginning", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(Zoombox));
		AnimationCompletedEvent = EventManager.RegisterRoutedEvent("AnimationCompleted", (RoutingStrategy)1, typeof(RoutedEventHandler), typeof(Zoombox));
		CurrentViewChangedEvent = EventManager.RegisterRoutedEvent("CurrentViewChanged", (RoutingStrategy)1, typeof(ZoomboxViewChangedEventHandler), typeof(Zoombox));
		ViewStackIndexChangedEvent = EventManager.RegisterRoutedEvent("ViewStackIndexChanged", (RoutingStrategy)1, typeof(IndexChangedEventHandler), typeof(Zoombox));
		Back = new RoutedUICommand("Go Back", "GoBack", typeof(Zoombox));
		Center = new RoutedUICommand("Center Content", "Center", typeof(Zoombox));
		Fill = new RoutedUICommand("Fill Bounds with Content", "FillToBounds", typeof(Zoombox));
		Fit = new RoutedUICommand("Fit Content within Bounds", "FitToBounds", typeof(Zoombox));
		Forward = new RoutedUICommand("Go Forward", "GoForward", typeof(Zoombox));
		Home = new RoutedUICommand("Go Home", "GoHome", typeof(Zoombox));
		PanDown = new RoutedUICommand("Pan Down", "PanDown", typeof(Zoombox));
		PanLeft = new RoutedUICommand("Pan Left", "PanLeft", typeof(Zoombox));
		PanRight = new RoutedUICommand("Pan Right", "PanRight", typeof(Zoombox));
		PanUp = new RoutedUICommand("Pan Up", "PanUp", typeof(Zoombox));
		Refocus = new RoutedUICommand("Refocus View", "Refocus", typeof(Zoombox));
		ZoomIn = new RoutedUICommand("Zoom In", "ZoomIn", typeof(Zoombox));
		ZoomOut = new RoutedUICommand("Zoom Out", "ZoomOut", typeof(Zoombox));
		MOUSE_WHEEL_DELTA = 28;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(Zoombox)));
		UIElement.ClipToBoundsProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)true));
		UIElement.FocusableProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)true));
		Control.HorizontalContentAlignmentProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)(HorizontalAlignment)1, (PropertyChangedCallback)RefocusView));
		Control.VerticalContentAlignmentProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((object)(VerticalAlignment)1, (PropertyChangedCallback)RefocusView));
		ContentControl.ContentProperty.OverrideMetadata(typeof(Zoombox), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)null, (CoerceValueCallback)CoerceContentValue));
	}

	public Zoombox()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		try
		{
			((CodeAccessPermission)new UIPermission(PermissionState.Unrestricted)).Demand();
			_cacheBits[512] = true;
		}
		catch (SecurityException)
		{
		}
		InitCommands();
		((UIElement)this).LayoutUpdated += OnLayoutUpdated;
		((UIElement)this).AddHandler(FrameworkElement.SizeChangedEvent, (Delegate)new SizeChangedEventHandler(OnSizeChanged), true);
		((DependencyObject)this).CoerceValue(ViewStackModeProperty);
	}

	private static bool ValidateAccelerationRatio(object value)
	{
		double num = (double)value;
		if (num < 0.0 || num > 1.0 || DoubleHelper.IsNaN(num))
		{
			throw new ArgumentException(ErrorMessages.GetMessage("AnimationAccelerationRatioOOR"));
		}
		return true;
	}

	private static bool ValidateDecelerationRatio(object value)
	{
		double num = (double)value;
		if (num < 0.0 || num > 1.0 || DoubleHelper.IsNaN(num))
		{
			throw new ArgumentException(ErrorMessages.GetMessage("AnimationDecelerationRatioOOR"));
		}
		return true;
	}

	private void SetAreDragModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreDragModifiersActivePropertyKey, (object)value);
	}

	private void SetAreRelativeZoomModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreRelativeZoomModifiersActivePropertyKey, (object)value);
	}

	private void SetAreZoomModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreZoomModifiersActivePropertyKey, (object)value);
	}

	private void SetAreZoomToSelectionModifiersActive(bool value)
	{
		((DependencyObject)this).SetValue(AreZoomToSelectionModifiersActivePropertyKey, (object)value);
	}

	private static void OnAutoWrapContentWithViewboxChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		o.CoerceValue(ContentControl.ContentProperty);
	}

	private static object CoerceContentValue(DependencyObject d, object value)
	{
		return ((Zoombox)(object)d).CoerceContentValue(value);
	}

	private object CoerceContentValue(object value)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected Obj, but got Unknown
		if (value != null && !(value is UIElement) && !(bool)((DependencyObject)this).GetValue(DesignerProperties.IsInDesignModeProperty))
		{
			throw new InvalidContentException(ErrorMessages.GetMessage("ZoomboxContentMustBeUIElement"));
		}
		object content = _content;
		if (value != _trueContent || IsContentWrapped != AutoWrapContentWithViewbox)
		{
			if (IsContentWrapped && _content is Viewbox && _content != _trueContent)
			{
				Viewbox val = (Viewbox)_content;
				BindingOperations.ClearAllBindings((DependencyObject)(object)val);
				((Decorator)val).Child = null;
				((FrameworkElement)this).RemoveLogicalChild((object)val);
			}
			if (_viewFinderDisplay != null && _viewFinderDisplay.VisualBrush != null)
			{
				_viewFinderDisplay.VisualBrush.Visual = null;
				_viewFinderDisplay.VisualBrush = null;
			}
			_content = (UIElement)((value is UIElement) ? value : null);
			_trueContent = (UIElement)((value is UIElement) ? value : null);
			if (_contentPresenter != null && _contentPresenter.Content != null)
			{
				_contentPresenter.Content = null;
			}
			IsContentWrapped = false;
			if (AutoWrapContentWithViewbox)
			{
				Viewbox val2 = new Viewbox();
				((FrameworkElement)this).AddLogicalChild((object)val2);
				((Decorator)val2).Child = (UIElement)((value is UIElement) ? value : null);
				_content = (UIElement)(object)val2;
				((FrameworkElement)val2).HorizontalAlignment = (HorizontalAlignment)0;
				((FrameworkElement)val2).VerticalAlignment = (VerticalAlignment)0;
				IsContentWrapped = true;
			}
			if (_contentPresenter != null)
			{
				_contentPresenter.Content = _content;
			}
			if (_viewFinderDisplay != null)
			{
				CreateVisualBrushForViewFinder((Visual)(object)_content);
			}
			UpdateViewFinderDisplayContentBounds();
		}
		if (content != _content && HasArrangedContentPresenter && HasRenderedFirstView)
		{
			HasArrangedContentPresenter = false;
			HasRenderedFirstView = false;
			RefocusViewOnFirstRender = true;
			((UIElement)_contentPresenter).LayoutUpdated += ContentPresenterFirstArranged;
		}
		return _content;
	}

	private void SetCurrentView(ZoomboxView value)
	{
		((DependencyObject)this).SetValue(CurrentViewPropertyKey, (object)value);
	}

	private static void OnCurrentViewChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)o;
		if (!zoombox.IsUpdatingView)
		{
			zoombox.ZoomTo(zoombox.CurrentView);
		}
		((UIElement)zoombox).RaiseEvent((RoutedEventArgs)(object)new ZoomboxViewChangedEventArgs(e.OldValue as ZoomboxView, e.NewValue as ZoomboxView, zoombox._lastViewIndex, zoombox.CurrentViewIndex));
	}

	internal void SetCurrentViewIndex(int value)
	{
		((DependencyObject)this).SetValue(CurrentViewIndexPropertyKey, (object)value);
	}

	private static KeyModifierCollection GetDefaultDragModifiers()
	{
		KeyModifierCollection keyModifierCollection = new KeyModifierCollection();
		keyModifierCollection.Add(KeyModifier.Ctrl);
		keyModifierCollection.Add(KeyModifier.Exact);
		return keyModifierCollection;
	}

	private void SetEffectiveViewStackMode(ZoomboxViewStackMode value)
	{
		((DependencyObject)this).SetValue(EffectiveViewStackModePropertyKey, (object)value);
	}

	private static object CoerceIsAnimatedValue(DependencyObject d, object value)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		bool flag = (bool)value;
		if (!((FrameworkElement)zoombox).IsInitialized)
		{
			flag = false;
		}
		return flag;
	}

	private void SetIsDraggingContent(bool value)
	{
		((DependencyObject)this).SetValue(IsDraggingContentPropertyKey, (object)value);
	}

	private void SetIsSelectingRegion(bool value)
	{
		((DependencyObject)this).SetValue(IsSelectingRegionPropertyKey, (object)value);
	}

	private static void OnMaxScaleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)o;
		((DependencyObject)zoombox).CoerceValue(MinScaleProperty);
		((DependencyObject)zoombox).CoerceValue(ScaleProperty);
	}

	private static object CoerceMaxScaleValue(DependencyObject d, object value)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		double num = (double)value;
		if (num < zoombox.MinScale)
		{
			num = zoombox.MinScale;
		}
		return num;
	}

	private static void OnMinScaleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)o;
		((DependencyObject)zoombox).CoerceValue(MinScaleProperty);
		((DependencyObject)zoombox).CoerceValue(ScaleProperty);
	}

	private static object CoerceMinScaleValue(DependencyObject d, object value)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		double num = (double)value;
		if (num > zoombox.MaxScale)
		{
			num = zoombox.MaxScale;
		}
		return num;
	}

	private static void OnPositionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		Zoombox zoombox = (Zoombox)(object)o;
		if (!zoombox.IsUpdatingViewport)
		{
			Point val = (Point)e.NewValue;
			double scale = zoombox.Scale;
			if (scale > 0.0)
			{
				zoombox.ZoomTo(new Point(0.0 - val.X, 0.0 - val.Y));
			}
		}
	}

	private static KeyModifierCollection GetDefaultRelativeZoomModifiers()
	{
		KeyModifierCollection keyModifierCollection = new KeyModifierCollection();
		keyModifierCollection.Add(KeyModifier.Ctrl);
		keyModifierCollection.Add(KeyModifier.Alt);
		keyModifierCollection.Add(KeyModifier.Exact);
		return keyModifierCollection;
	}

	private static void OnScaleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)o;
		if (!zoombox.IsUpdatingView)
		{
			double scale = (double)e.NewValue;
			zoombox.ZoomTo(scale);
		}
	}

	private static object CoerceScaleValue(DependencyObject d, object value)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		double num = (double)value;
		if (num < zoombox.MinScale)
		{
			num = zoombox.MinScale;
		}
		if (num > zoombox.MaxScale)
		{
			num = zoombox.MaxScale;
		}
		return num;
	}

	public static Visibility GetViewFinderVisibility(DependencyObject d)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return (Visibility)d.GetValue(ViewFinderVisibilityProperty);
	}

	public static void SetViewFinderVisibility(DependencyObject d, Visibility value)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		d.SetValue(ViewFinderVisibilityProperty, (object)value);
	}

	private static void OnViewportChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		Zoombox zoombox = (Zoombox)(object)o;
		Rect viewport = zoombox.Viewport;
		double num = (0.0 - viewport.Left) * zoombox.Scale / zoombox._viewboxFactor;
		Rect viewport2 = zoombox.Viewport;
		zoombox.Position = new Point(num, (0.0 - viewport2.Top) * zoombox.Scale / zoombox._viewboxFactor);
	}

	internal void SetViewStackCount(int value)
	{
		((DependencyObject)this).SetValue(ViewStackCountPropertyKey, (object)value);
	}

	private static void OnViewStackCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnViewStackCountChanged(e);
	}

	private void OnViewStackCountChanged(DependencyPropertyChangedEventArgs e)
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
		{
			UpdateStackProperties();
		}
	}

	private static void OnViewStackIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnViewStackIndexChanged(e);
	}

	private void OnViewStackIndexChanged(DependencyPropertyChangedEventArgs e)
	{
		if (EffectiveViewStackMode == ZoomboxViewStackMode.Disabled)
		{
			return;
		}
		if (!IsUpdatingView)
		{
			int viewStackIndex = ViewStackIndex;
			if (viewStackIndex >= 0 && viewStackIndex < ViewStack.Count)
			{
				UpdateView(ViewStack[viewStackIndex], allowAnimation: true, allowStackAddition: false, viewStackIndex);
			}
		}
		UpdateStackProperties();
		((UIElement)this).RaiseEvent((RoutedEventArgs)(object)new IndexChangedEventArgs(ViewStackIndexChangedEvent, (int)e.OldValue, (int)e.NewValue));
	}

	private static object CoerceViewStackIndexValue(DependencyObject d, object value)
	{
		Zoombox zoombox = d as Zoombox;
		if (zoombox.EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
		{
			return value;
		}
		return -1;
	}

	private static void OnViewStackModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnViewStackModeChanged(e);
	}

	private void OnViewStackModeChanged(DependencyPropertyChangedEventArgs e)
	{
		if ((ZoomboxViewStackMode)e.NewValue == ZoomboxViewStackMode.Disabled && _viewStack != null)
		{
			_viewStack.ClearViewStackSource();
			_viewStack = null;
		}
	}

	private static object CoerceViewStackModeValue(DependencyObject d, object value)
	{
		Zoombox zoombox = d as Zoombox;
		ZoomboxViewStackMode zoomboxViewStackMode = (ZoomboxViewStackMode)value;
		if (zoombox.EffectiveViewStackMode == ZoomboxViewStackMode.Disabled)
		{
			zoombox.SetEffectiveViewStackMode(zoomboxViewStackMode);
		}
		if (zoomboxViewStackMode != ZoomboxViewStackMode.Disabled)
		{
			if (zoomboxViewStackMode == ZoomboxViewStackMode.Default)
			{
				zoomboxViewStackMode = (zoombox.ViewStack.AreViewsFromSource ? ZoomboxViewStackMode.Manual : ZoomboxViewStackMode.Auto);
			}
			if (zoombox.ViewStack.AreViewsFromSource && zoomboxViewStackMode != ZoomboxViewStackMode.Manual)
			{
				throw new InvalidOperationException(ErrorMessages.GetMessage("ViewModeInvalidForSource"));
			}
		}
		zoombox.SetEffectiveViewStackMode(zoomboxViewStackMode);
		return value;
	}

	private static void OnViewStackSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = (Zoombox)(object)d;
		_ = (IEnumerable)e.OldValue;
		IEnumerable viewStackSource = (IEnumerable)e.NewValue;
		if (e.NewValue == null && !BindingOperations.IsDataBound(d, ViewStackSourceProperty))
		{
			if (zoombox.ViewStack != null)
			{
				zoombox.ViewStack.ClearViewStackSource();
			}
		}
		else
		{
			zoombox.ViewStack.SetViewStackSource(viewStackSource);
		}
		((DependencyObject)zoombox).CoerceValue(ViewStackModeProperty);
	}

	private static KeyModifierCollection GetDefaultZoomModifiers()
	{
		KeyModifierCollection keyModifierCollection = new KeyModifierCollection();
		keyModifierCollection.Add(KeyModifier.Shift);
		keyModifierCollection.Add(KeyModifier.Exact);
		return keyModifierCollection;
	}

	private static KeyModifierCollection GetDefaultZoomToSelectionModifiers()
	{
		KeyModifierCollection keyModifierCollection = new KeyModifierCollection();
		keyModifierCollection.Add(KeyModifier.Alt);
		keyModifierCollection.Add(KeyModifier.Exact);
		return keyModifierCollection;
	}

	private static void OnKeepContentInBoundsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Zoombox)(object)d).OnKeepContentInBoundsChanged(e);
	}

	private void OnKeepContentInBoundsChanged(DependencyPropertyChangedEventArgs e)
	{
		bool isAnimated = IsAnimated;
		IsAnimated = false;
		try
		{
			UpdateView(CurrentView, allowAnimation: false, allowStackAddition: false, ViewStackIndex);
		}
		finally
		{
			IsAnimated = isAnimated;
		}
	}

	private void CanGoBack(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex > 0;
	}

	private void GoBack(object sender, ExecutedRoutedEventArgs e)
	{
		GoBack();
	}

	private void CenterContent(object sender, ExecutedRoutedEventArgs e)
	{
		CenterContent();
	}

	private void FillToBounds(object sender, ExecutedRoutedEventArgs e)
	{
		FillToBounds();
	}

	private void FitToBounds(object sender, ExecutedRoutedEventArgs e)
	{
		FitToBounds();
	}

	private void CanGoForward(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex < ViewStack.Count - 1;
	}

	private void GoForward(object sender, ExecutedRoutedEventArgs e)
	{
		GoForward();
	}

	private void CanGoHome(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStack.Count > 0 && ViewStackIndex != 0;
	}

	private void GoHome(object sender, ExecutedRoutedEventArgs e)
	{
		GoHome();
	}

	private void PanDownExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(_basePosition.X, _basePosition.Y + PanDistance);
	}

	private void PanLeftExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(_basePosition.X - PanDistance, _basePosition.Y);
	}

	private void PanRightExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(_basePosition.X + PanDistance, _basePosition.Y);
	}

	private void PanUpExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		Position = new Point(_basePosition.X, _basePosition.Y - PanDistance);
	}

	private void CanRefocusView(object sender, CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = EffectiveViewStackMode == ZoomboxViewStackMode.Manual && ViewStackIndex >= 0 && ViewStackIndex < ViewStack.Count && CurrentView != ViewStack[ViewStackIndex];
	}

	private void RefocusView(object sender, ExecutedRoutedEventArgs e)
	{
		RefocusView();
	}

	private void ZoomInExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		Zoom(ZoomPercentage / 100.0);
	}

	private void ZoomOutExecuted(object sender, ExecutedRoutedEventArgs e)
	{
		Zoom((0.0 - ZoomPercentage) / 100.0);
	}

	public void CenterContent()
	{
		if (_content != null)
		{
			ZoomTo(ZoomboxView.Center);
		}
	}

	public void FillToBounds()
	{
		if (_content != null)
		{
			ZoomTo(ZoomboxView.Fill);
		}
	}

	public void FitToBounds()
	{
		if (_content != null)
		{
			ZoomTo(ZoomboxView.Fit);
		}
	}

	public void GoBack()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex > 0)
		{
			ViewStackIndex--;
		}
	}

	public void GoForward()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex < ViewStack.Count - 1)
		{
			ViewStackIndex++;
		}
	}

	public void GoHome()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex > 0)
		{
			ViewStackIndex = 0;
		}
	}

	public override void OnApplyTemplate()
	{
		AttachToVisualTree();
		((FrameworkElement)this).OnApplyTemplate();
	}

	public void RefocusView()
	{
		if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled && ViewStackIndex >= 0 && ViewStackIndex < ViewStack.Count && CurrentView != ViewStack[ViewStackIndex])
		{
			UpdateView(ViewStack[ViewStackIndex], allowAnimation: true, allowStackAddition: false, ViewStackIndex);
		}
	}

	public void Zoom(double percentage)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			Zoom(percentage, GetZoomRelativePoint());
		}
	}

	public void Zoom(double percentage, Point relativeTo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			double scale = Scale * (1.0 + percentage);
			ZoomTo(scale, relativeTo);
		}
	}

	public void ZoomTo(Point position)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			ZoomTo(new ZoomboxView(new Point(0.0 - position.X, 0.0 - position.Y)));
		}
	}

	public void ZoomTo(Rect region)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			UpdateView(new ZoomboxView(region), allowAnimation: true, allowStackAddition: true);
		}
	}

	public void ZoomTo(double scale)
	{
		if (_content != null)
		{
			ZoomTo(scale, allowStackAddition: true);
		}
	}

	public void ZoomTo(double scale, Point relativeTo)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		ZoomTo(scale, relativeTo, restrictRelativePointToContent: true, allowStackAddition: true);
	}

	public void ZoomTo(ZoomboxView view)
	{
		UpdateView(view, allowAnimation: true, allowStackAddition: true);
	}

	internal void UpdateStackProperties()
	{
		((DependencyObject)this).SetValue(HasBackStackPropertyKey, (object)(ViewStackIndex > 0));
		((DependencyObject)this).SetValue(HasForwardStackPropertyKey, (object)(ViewStack.Count > ViewStackIndex + 1));
		CommandManager.InvalidateRequerySuggested();
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			((Control)this).MeasureOverride(constraint);
			_content.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
		}
		if (double.IsInfinity(constraint.Height))
		{
			constraint.Height = 0.0;
		}
		if (double.IsInfinity(constraint.Width))
		{
			constraint.Width = 0.0;
		}
		return constraint;
	}

	protected override void OnContentChanged(object oldContent, object newContent)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		if (oldContent is FrameworkElement)
		{
			((UIElement)((oldContent is FrameworkElement) ? oldContent : null)).RemoveHandler(FrameworkElement.SizeChangedEvent, (Delegate)new SizeChangedEventHandler(OnContentSizeChanged));
		}
		else
		{
			((UIElement)this).RemoveHandler(FrameworkElement.SizeChangedEvent, (Delegate)new SizeChangedEventHandler(OnContentSizeChanged));
		}
		if (_content is FrameworkElement)
		{
			UIElement content = _content;
			((content is FrameworkElement) ? content : null).AddHandler(FrameworkElement.SizeChangedEvent, (Delegate)new SizeChangedEventHandler(OnContentSizeChanged), true);
		}
		else
		{
			((UIElement)this).AddHandler(FrameworkElement.SizeChangedEvent, (Delegate)new SizeChangedEventHandler(OnContentSizeChanged), true);
		}
		if (_viewFinderDisplay != null && _viewFinderDisplay.VisualBrush != null)
		{
			_viewFinderDisplay.VisualBrush.Visual = (Visual)(object)_content;
		}
	}

	protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		MonitorInput();
		((UIElement)this).OnGotKeyboardFocus(e);
	}

	protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
	{
		MonitorInput();
		((UIElement)this).OnLostKeyboardFocus(e);
	}

	protected override void OnInitialized(EventArgs e)
	{
		((FrameworkElement)this).OnInitialized(e);
		((DependencyObject)this).CoerceValue(IsAnimatedProperty);
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		if (HasArrangedContentPresenter && !HasRenderedFirstView)
		{
			HasRenderedFirstView = true;
			if (RefocusViewOnFirstRender)
			{
				RefocusViewOnFirstRender = false;
				bool isAnimated = IsAnimated;
				IsAnimated = false;
				try
				{
					RefocusView();
				}
				finally
				{
					IsAnimated = isAnimated;
				}
			}
		}
		((UIElement)this).OnRender(drawingContext);
	}

	private static void RefocusView(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		Zoombox zoombox = o as Zoombox;
		zoombox.UpdateView(zoombox.CurrentView, allowAnimation: true, allowStackAddition: false, zoombox.ViewStackIndex);
	}

	private void AttachToVisualTree()
	{
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected Obj, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected Obj, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected Obj, but got Unknown
		DetachFromVisualTree();
		_dragAdorner = new DragAdorner((UIElement)(object)this);
		if (((FrameworkTemplate)((Control)this).Template).Resources.Contains((object)"SelectionBrush"))
		{
			DragAdorner dragAdorner = _dragAdorner;
			object obj = ((FrameworkTemplate)((Control)this).Template).Resources[(object)"SelectionBrush"];
			dragAdorner.Brush = (Brush)((obj is Brush) ? obj : null);
		}
		if (((FrameworkTemplate)((Control)this).Template).Resources.Contains((object)"SelectionPen"))
		{
			DragAdorner dragAdorner2 = _dragAdorner;
			object obj2 = ((FrameworkTemplate)((Control)this).Template).Resources[(object)"SelectionPen"];
			dragAdorner2.Pen = (Pen)((obj2 is Pen) ? obj2 : null);
		}
		if (((FrameworkTemplate)((Control)this).Template).Resources.Contains((object)"InputBindings"))
		{
			object obj3 = ((FrameworkTemplate)((Control)this).Template).Resources[(object)"InputBindings"];
			InputBindingCollection val = (InputBindingCollection)((obj3 is InputBindingCollection) ? obj3 : null);
			if (val != null)
			{
				((UIElement)this).InputBindings.AddRange((ICollection)val);
			}
		}
		Visual val2 = VisualTreeHelperEx.FindDescendantByType((Visual)(object)this, typeof(ContentPresenter));
		_contentPresenter = (ContentPresenter)(object)((val2 is ContentPresenter) ? val2 : null);
		if (_contentPresenter == null)
		{
			throw new InvalidTemplateException(ErrorMessages.GetMessage("ZoomboxTemplateNeedsContent"));
		}
		AdornerLayer val3 = null;
		Visual val4 = VisualTreeHelperEx.FindDescendantByType((Visual)(object)this, typeof(AdornerDecorator));
		AdornerDecorator val5 = (AdornerDecorator)(object)((val4 is AdornerDecorator) ? val4 : null);
		if (val5 != null)
		{
			val3 = val5.AdornerLayer;
		}
		else
		{
			try
			{
				val3 = AdornerLayer.GetAdornerLayer((Visual)(object)this);
			}
			catch (Exception)
			{
			}
		}
		if (val3 != null)
		{
			val3.Add((Adorner)(object)_dragAdorner);
		}
		VisualTreeHelperEx.FindDescendantWithPropertyValue((Visual)(object)this, ButtonBase.IsPressedProperty, true);
		DependencyPropertyKey viewFinderPropertyKey = ViewFinderPropertyKey;
		object obj4 = ((FrameworkTemplate)((Control)this).Template).FindName("ViewFinder", (FrameworkElement)(object)this);
		((DependencyObject)this).SetValue(viewFinderPropertyKey, (obj4 is FrameworkElement) ? obj4 : null);
		_viewFinderDisplay = VisualTreeHelperEx.FindDescendantByType((Visual)(object)this, typeof(ZoomboxViewFinderDisplay)) as ZoomboxViewFinderDisplay;
		if (ViewFinder != null && _viewFinderDisplay == null)
		{
			throw new InvalidTemplateException(ErrorMessages.GetMessage("ZoomboxHasViewFinderButNotDisplay"));
		}
		if (_viewFinderDisplay != null)
		{
			CreateVisualBrushForViewFinder((Visual)(object)_content);
			((UIElement)_viewFinderDisplay).MouseMove += ViewFinderDisplayMouseMove;
			((UIElement)_viewFinderDisplay).MouseLeftButtonDown += ViewFinderDisplayBeginCapture;
			((UIElement)_viewFinderDisplay).MouseLeftButtonUp += ViewFinderDisplayEndCapture;
			Binding val6 = new Binding("Viewport");
			val6.Mode = (BindingMode)1;
			val6.Converter = (IValueConverter)(object)new ViewFinderSelectionConverter(this);
			val6.Source = this;
			((FrameworkElement)_viewFinderDisplay).SetBinding(ZoomboxViewFinderDisplay.ViewportRectProperty, (BindingBase)(object)val6);
		}
		((UIElement)_contentPresenter).LayoutUpdated += ContentPresenterFirstArranged;
	}

	private void CreateVisualBrushForViewFinder(Visual visual)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		_viewFinderDisplay.VisualBrush = new VisualBrush(visual);
		((TileBrush)_viewFinderDisplay.VisualBrush).Stretch = (Stretch)2;
		((TileBrush)_viewFinderDisplay.VisualBrush).AlignmentX = (AlignmentX)0;
		((TileBrush)_viewFinderDisplay.VisualBrush).AlignmentY = (AlignmentY)0;
	}

	private void ContentPresenterFirstArranged(object sender, EventArgs e)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)_contentPresenter).LayoutUpdated -= ContentPresenterFirstArranged;
		HasArrangedContentPresenter = true;
		((UIElement)this).InvalidateVisual();
		bool isAnimated = IsAnimated;
		IsAnimated = false;
		try
		{
			double scale = Scale;
			Point position = Position;
			if (EffectiveViewStackMode != ZoomboxViewStackMode.Disabled)
			{
				bool flag = false;
				if (ViewStack.Count > 0)
				{
					if (ViewStackIndex >= 0)
					{
						if (ViewStackIndex > ViewStack.Count - 1)
						{
							ViewStackIndex = ViewStack.Count - 1;
						}
						else
						{
							UpdateView(ViewStack[ViewStackIndex], allowAnimation: false, allowStackAddition: false, ViewStackIndex);
						}
					}
					else if (EffectiveViewStackMode != ZoomboxViewStackMode.Auto && ViewStackIndex < 0)
					{
						ViewStackIndex = 0;
					}
					if (ViewStackIndex >= 0)
					{
						flag = true;
						if (!DoubleHelper.IsNaN(scale) || !PointHelper.IsEmpty(position))
						{
							UpdateView(new ZoomboxView(scale, position), allowAnimation: false, allowStackAddition: false);
						}
					}
				}
				if (!flag)
				{
					ZoomboxView view = new ZoomboxView(DoubleHelper.IsNaN(Scale) ? 1.0 : Scale, PointHelper.IsEmpty(position) ? default(Point) : position);
					if (EffectiveViewStackMode == ZoomboxViewStackMode.Auto)
					{
						ViewStack.PushView(view);
						ViewStackIndex = 0;
					}
					else
					{
						UpdateView(view, allowAnimation: false, allowStackAddition: false);
					}
				}
			}
			else
			{
				ZoomboxView view2 = new ZoomboxView(DoubleHelper.IsNaN(Scale) ? 1.0 : Scale, position);
				UpdateView(view2, allowAnimation: false, allowStackAddition: false);
			}
		}
		finally
		{
			IsAnimated = isAnimated;
		}
	}

	private void DetachFromVisualTree()
	{
		if (_dragAdorner != null)
		{
			AdornerLayer.GetAdornerLayer((Visual)(object)this).Remove((Adorner)(object)_dragAdorner);
		}
		if (_contentPresenter != null)
		{
			((UIElement)_contentPresenter).LayoutUpdated -= ContentPresenterFirstArranged;
		}
		if (_viewFinderDisplay != null)
		{
			_viewFinderDisplay = null;
		}
		_contentPresenter = null;
	}

	private void DragDisplayViewport(DragDeltaEventArgs e, bool end)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		double scale = _viewFinderDisplay.Scale;
		Rect viewportRect = _viewFinderDisplay.ViewportRect;
		Rect contentBounds = _viewFinderDisplay.ContentBounds;
		if (!viewportRect.Contains(contentBounds))
		{
			double num = e.HorizontalChange;
			double num2 = e.VerticalChange;
			if (viewportRect.Left < contentBounds.Left)
			{
				num = Math.Max(0.0, num);
			}
			else if (viewportRect.Left + num < contentBounds.Left)
			{
				num = contentBounds.Left - viewportRect.Left;
			}
			if (viewportRect.Right > contentBounds.Right)
			{
				num = Math.Min(0.0, num);
			}
			else if (viewportRect.Right + num > contentBounds.Left + contentBounds.Width)
			{
				num = contentBounds.Left + contentBounds.Width - viewportRect.Right;
			}
			if (viewportRect.Top < contentBounds.Top)
			{
				num2 = Math.Max(0.0, num2);
			}
			else if (viewportRect.Top + num2 < contentBounds.Top)
			{
				num2 = contentBounds.Top - viewportRect.Top;
			}
			if (viewportRect.Bottom > contentBounds.Bottom)
			{
				num2 = Math.Min(0.0, num2);
			}
			else if (viewportRect.Bottom + num2 > contentBounds.Top + contentBounds.Height)
			{
				num2 = contentBounds.Top + contentBounds.Height - viewportRect.Bottom;
			}
			OnDrag(new DragDeltaEventArgs((0.0 - num) / scale / _viewboxFactor, (0.0 - num2) / scale / _viewboxFactor), end);
			_originPoint += new Vector(num, num2);
		}
	}

	private void InitCommands()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		//IL_0022: Expected Obj, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00be: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00ee: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected Obj, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Obj, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected Obj, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected Obj, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected Obj, but got Unknown
		//IL_01ae: Expected Obj, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected Obj, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected Obj, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected Obj, but got Unknown
		CommandBinding val = new CommandBinding((ICommand)Back, (ExecutedRoutedEventHandler)GoBack, (CanExecuteRoutedEventHandler)CanGoBack);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)Center, (ExecutedRoutedEventHandler)CenterContent);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)Fill, (ExecutedRoutedEventHandler)FillToBounds);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)Fit, (ExecutedRoutedEventHandler)FitToBounds);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)Forward, (ExecutedRoutedEventHandler)GoForward, (CanExecuteRoutedEventHandler)CanGoForward);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)Home, (ExecutedRoutedEventHandler)GoHome, (CanExecuteRoutedEventHandler)CanGoHome);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)PanDown, (ExecutedRoutedEventHandler)PanDownExecuted);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)PanLeft, (ExecutedRoutedEventHandler)PanLeftExecuted);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)PanRight, (ExecutedRoutedEventHandler)PanRightExecuted);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)PanUp, (ExecutedRoutedEventHandler)PanUpExecuted);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)Refocus, (ExecutedRoutedEventHandler)RefocusView, (CanExecuteRoutedEventHandler)CanRefocusView);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)ZoomIn, (ExecutedRoutedEventHandler)ZoomInExecuted);
		((UIElement)this).CommandBindings.Add(val);
		val = new CommandBinding((ICommand)ZoomOut, (ExecutedRoutedEventHandler)ZoomOutExecuted);
		((UIElement)this).CommandBindings.Add(val);
	}

	private void MonitorInput()
	{
		if (HasUIPermission)
		{
			PreProcessInput();
		}
	}

	private void OnContentSizeChanged(object sender, SizeChangedEventArgs e)
	{
		UpdateViewFinderDisplayContentBounds();
		if (HasArrangedContentPresenter)
		{
			if (HasRenderedFirstView)
			{
				UpdateView(CurrentView, allowAnimation: true, allowStackAddition: false, CurrentViewIndex);
				return;
			}
			RefocusViewOnFirstRender = true;
			((UIElement)this).InvalidateVisual();
		}
	}

	private void OnDrag(DragDeltaEventArgs e, bool end)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		Point relativePosition = _relativePosition;
		double scale = Scale;
		Point position = relativePosition + ContentOffset * scale + new Vector(e.HorizontalChange * scale, e.VerticalChange * scale);
		UpdateView(new ZoomboxView(scale, position), allowAnimation: false, end);
	}

	private void OnLayoutUpdated(object sender, EventArgs e)
	{
		UpdateViewport();
	}

	private void OnSelectRegion(DragDeltaEventArgs e, bool end)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if (end)
		{
			_dragAdorner.Rect = Rect.Empty;
			if (_trueContent != null)
			{
				Point val = ((UIElement)this).TranslatePoint(_dragAdorner.LastPosition, _trueContent);
				Point lastPosition = _dragAdorner.LastPosition;
				Size lastSize = _dragAdorner.LastSize;
				double width = lastSize.Width;
				Size lastSize2 = _dragAdorner.LastSize;
				Rect region = new Rect(val, ((UIElement)this).TranslatePoint(lastPosition + new Vector(width, lastSize2.Height), _trueContent));
				ZoomTo(region);
			}
		}
		else
		{
			DragAdorner dragAdorner = _dragAdorner;
			Rect val2 = new Rect(_originPoint, new Vector(e.HorizontalChange, e.VerticalChange));
			Point val3 = new Point(0.0, 0.0);
			Size renderSize = ((UIElement)this).RenderSize;
			double width2 = renderSize.Width;
			Size renderSize2 = ((UIElement)this).RenderSize;
			dragAdorner.Rect = Rect.Intersect(val2, new Rect(val3, new Point(width2, renderSize2.Height)));
		}
	}

	private void OnSizeChanged(object sender, SizeChangedEventArgs e)
	{
		if (!HasArrangedContentPresenter)
		{
			return;
		}
		UpdateViewboxFactor();
		bool isAnimated = IsAnimated;
		IsAnimated = false;
		try
		{
			UpdateView(CurrentView, allowAnimation: false, allowStackAddition: false, ViewStackIndex);
		}
		finally
		{
			IsAnimated = isAnimated;
		}
	}

	private void PreProcessInput()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		if (((UIElement)this).IsMouseOver || ((UIElement)this).IsKeyboardFocusWithin)
		{
			if (!IsMonitoringInput)
			{
				IsMonitoringInput = true;
				InputManager.Current.PreNotifyInput += PreProcessInput;
				UpdateKeyModifierTriggerProperties();
			}
		}
		else if (IsMonitoringInput)
		{
			IsMonitoringInput = false;
			InputManager.Current.PreNotifyInput -= PreProcessInput;
			SetAreDragModifiersActive(value: false);
			SetAreRelativeZoomModifiersActive(value: false);
			SetAreZoomModifiersActive(value: false);
			SetAreZoomToSelectionModifiersActive(value: false);
		}
	}

	private void PreProcessInput(object sender, NotifyInputEventArgs e)
	{
		if (e.StagingItem.Input is KeyEventArgs)
		{
			UpdateKeyModifierTriggerProperties();
		}
	}

	private void ProcessMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		if (ZoomToSelectionModifiers.AreActive)
		{
			SetIsDraggingContent(value: false);
			SetIsSelectingRegion(value: true);
		}
		else if (DragModifiers.AreActive)
		{
			SetIsSelectingRegion(value: false);
			SetIsDraggingContent(value: true);
		}
		else
		{
			SetIsSelectingRegion(value: false);
			SetIsDraggingContent(value: false);
		}
		if (IsSelectingRegion || IsDraggingContent)
		{
			_originPoint = ((MouseEventArgs)e).GetPosition((IInputElement)(object)this);
			((UIElement)_contentPresenter).CaptureMouse();
			((RoutedEventArgs)e).Handled = true;
			if (IsDraggingContent)
			{
				OnDrag(new DragDeltaEventArgs(0.0, 0.0), end: false);
			}
			else if (IsSelectingRegion)
			{
				OnSelectRegion(new DragDeltaEventArgs(0.0, 0.0), end: false);
			}
		}
	}

	private void ProcessMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		if (IsDraggingContent || IsSelectingRegion)
		{
			bool isDraggingContent = IsDraggingContent;
			SetIsDraggingContent(value: false);
			SetIsSelectingRegion(value: false);
			_originPoint = default;
			((UIElement)_contentPresenter).ReleaseMouseCapture();
			((RoutedEventArgs)e).Handled = true;
			if (isDraggingContent)
			{
				OnDrag(new DragDeltaEventArgs(0.0, 0.0), end: true);
			}
			else
			{
				OnSelectRegion(new DragDeltaEventArgs(0.0, 0.0), end: true);
			}
		}
	}

	private void ProcessMouseMove(MouseEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		if ((int)e.MouseDevice.LeftButton == 1 && (IsDraggingContent || IsSelectingRegion))
		{
			Point position = e.GetPosition((IInputElement)(object)this);
			((RoutedEventArgs)e).Handled = true;
			if (IsDraggingContent)
			{
				Vector val = (position - _originPoint) / Scale;
				OnDrag(new DragDeltaEventArgs(val.X, val.Y), end: false);
				_originPoint = position;
			}
			else if (IsSelectingRegion)
			{
				Vector val2 = position - _originPoint;
				OnSelectRegion(new DragDeltaEventArgs(val2.X, val2.Y), end: false);
			}
		}
	}

	private void ProcessMouseWheelZoom(MouseWheelEventArgs e)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		if (_content == null)
		{
			return;
		}
		bool flag = ZoomModifiers.AreActive;
		bool areActive = RelativeZoomModifiers.AreActive;
		if (flag && areActive)
		{
			flag = false;
		}
		if (flag || areActive)
		{
			((RoutedEventArgs)e).Handled = true;
			double percentage = (double)(e.Delta / MOUSE_WHEEL_DELTA) * ZoomPercentage / 100.0;
			if (areActive)
			{
				Zoom(percentage, Mouse.GetPosition((IInputElement)(object)_content));
			}
			else
			{
				Zoom(percentage);
			}
		}
	}

	private void ProcessNavigationButton(RoutedEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Invalid comparison between Unknown and I4
		if (e is MouseButtonEventArgs)
		{
			MouseButtonEventArgs e2 = (MouseButtonEventArgs)(object)((e is MouseButtonEventArgs) ? e : null);
			if ((int)e2.ChangedButton == 3 || (int)e2.ChangedButton == 4)
			{
				if ((int)e2.ChangedButton == 4)
				{
					GoForward();
				}
				else
				{
					GoBack();
				}
				((RoutedEventArgs)e2).Handled = true;
			}
		}
		else
		{
			if (!(e is KeyEventArgs))
			{
				return;
			}
			KeyEventArgs e3 = (KeyEventArgs)(object)((e is KeyEventArgs) ? e : null);
			if ((int)e3.Key == 2 || (int)e3.Key == 122 || (int)e3.Key == 123)
			{
				if ((int)e3.Key == 123)
				{
					GoForward();
				}
				else
				{
					GoBack();
				}
				((RoutedEventArgs)e3).Handled = true;
			}
		}
	}

	private void ResizeDisplayViewport(DragDeltaEventArgs e, ResizeEdge relativeTo)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		_ = _viewFinderDisplay.ViewportRect;
		double scale = _viewFinderDisplay.Scale;
		double num = Math.Max(_resizeViewportBounds.Left, Math.Min(_resizeDraggingPoint.X + e.HorizontalChange, _resizeViewportBounds.Right));
		double num2 = Math.Max(_resizeViewportBounds.Top, Math.Min(_resizeDraggingPoint.Y + e.VerticalChange, _resizeViewportBounds.Bottom));
		Point val = new Point(_resizeAnchorPoint.X / scale, _resizeAnchorPoint.Y / scale);
		Vector val2 = new Vector((num - _resizeAnchorPoint.X) / scale / _viewboxFactor, (num2 - _resizeAnchorPoint.Y) / scale / _viewboxFactor);
		Rect val3 = new Rect(val, val2);
		val3 = new Rect(_content.TranslatePoint(val3.TopLeft, (UIElement)(object)_contentPresenter), _content.TranslatePoint(val3.BottomRight, (UIElement)(object)_contentPresenter));
		Size renderSize = ((UIElement)this).RenderSize;
		double num3 = renderSize.Width / val3.Width;
		Size renderSize2 = ((UIElement)this).RenderSize;
		double num4 = renderSize2.Height / val3.Height;
		scale = ((num3 < num4) ? num3 : num4);
		ZoomTo(scale, val, restrictRelativePointToContent: false, allowStackAddition: false);
	}

	private void UpdateKeyModifierTriggerProperties()
	{
		SetAreDragModifiersActive(DragModifiers.AreActive);
		SetAreRelativeZoomModifiersActive(RelativeZoomModifiers.AreActive);
		SetAreZoomModifiersActive(ZoomModifiers.AreActive);
		SetAreZoomToSelectionModifiersActive(ZoomToSelectionModifiers.AreActive);
	}

	private void UpdateView(ZoomboxView view, bool allowAnimation, bool allowStackAddition)
	{
		UpdateView(view, allowAnimation, allowStackAddition, -1);
	}

	private void UpdateView(ZoomboxView view, bool allowAnimation, bool allowStackAddition, int stackIndex)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected Obj, but got Unknown
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected Obj, but got Unknown
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected Obj, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected Obj, but got Unknown
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Expected Obj, but got Unknown
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected Obj, but got Unknown
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Expected Obj, but got Unknown
		if (_contentPresenter == null || _content == null || !HasArrangedContentPresenter)
		{
			return;
		}
		if (view.ViewKind == ZoomboxViewKind.Absolute && PointHelper.IsEmpty(view.Position))
		{
			ZoomTo(view.Scale, allowStackAddition);
		}
		else
		{
			if (IsUpdatingView)
			{
				return;
			}
			IsUpdatingView = true;
			try
			{
				double newRelativeScale = _viewboxFactor;
				Point newRelativePosition = default;
				Rect region = Rect.Empty;
				switch (view.ViewKind)
				{
				case ZoomboxViewKind.Absolute:
				{
					newRelativeScale = (DoubleHelper.IsNaN(view.Scale) ? _relativeScale : view.Scale);
					Point val4;
					if (!PointHelper.IsEmpty(view.Position))
					{
						Point position = view.Position;
						double x = position.X;
						Point position2 = view.Position;
						val4 = new Point(x, position2.Y) - ContentOffset * newRelativeScale;
					}
					else
					{
						val4 = _relativePosition;
					}
					newRelativePosition = val4;
					break;
				}
				case ZoomboxViewKind.Region:
					region = view.Region;
					break;
				case ZoomboxViewKind.Center:
				{
					UIElement content = _content;
					Rect contentRect = ContentRect;
					Point val = content.TranslatePoint(contentRect.TopLeft, (UIElement)(object)this);
					UIElement content2 = _content;
					Rect contentRect2 = ContentRect;
					Rect val2 = new Rect(val, content2.TranslatePoint(contentRect2.BottomRight, (UIElement)(object)this));
					Rect val3 = val2;
					Size renderSize = ((UIElement)this).RenderSize;
					double num = (renderSize.Width / _viewboxFactor - val2.Width) / 2.0;
					Size renderSize2 = ((UIElement)this).RenderSize;
					region = Rect.Inflate(val3, num, (renderSize2.Height / _viewboxFactor - val2.Height) / 2.0);
					region = new Rect(((UIElement)this).TranslatePoint(region.TopLeft, _content), ((UIElement)this).TranslatePoint(region.BottomRight, _content));
					break;
				}
				case ZoomboxViewKind.Fit:
					region = ContentRect;
					break;
				case ZoomboxViewKind.Fill:
					region = CalculateFillRect();
					break;
				}
				if (view.ViewKind != ZoomboxViewKind.Empty)
				{
					if (!region.IsEmpty)
					{
						CalculatePositionAndScale(region, ref newRelativePosition, ref newRelativeScale);
					}
					else if (view != ZoomboxView.Empty)
					{
						if (newRelativeScale > MaxScale)
						{
							newRelativeScale = MaxScale;
						}
						else if (newRelativeScale < MinScale)
						{
							newRelativeScale = MinScale;
						}
					}
					double num2 = _relativeScale;
					double x2 = _relativePosition.X;
					double y = _relativePosition.Y;
					ScaleTransform val5 = null;
					TranslateTransform val6 = null;
					TransformGroup val7 = null;
					if (((UIElement)_contentPresenter).RenderTransform != Transform.Identity)
					{
						Transform renderTransform = ((UIElement)_contentPresenter).RenderTransform;
						val7 = (TransformGroup)(object)((renderTransform is TransformGroup) ? renderTransform : null);
						Transform val8 = val7.Children[0];
						val5 = (ScaleTransform)(object)((val8 is ScaleTransform) ? val8 : null);
						Transform val9 = val7.Children[1];
						val6 = (TranslateTransform)(object)((val9 is TranslateTransform) ? val9 : null);
						num2 = val5.ScaleX;
						x2 = val6.X;
						y = val6.Y;
					}
					if (KeepContentInBounds)
					{
						Rect contentRect3 = ContentRect;
						double num3 = contentRect3.Width * newRelativeScale;
						Rect contentRect4 = ContentRect;
						Rect val10 = new Rect(new Size(num3, contentRect4.Height * newRelativeScale));
						Point val11 = new Point(0.0 - newRelativePosition.X, 0.0 - newRelativePosition.Y);
						Rect val12 = new Rect(val11, ((UIElement)_contentPresenter).RenderSize);
						if (DoubleHelper.AreVirtuallyEqual(_relativeScale, newRelativeScale))
						{
							if (IsGreaterThanOrClose(val10.Width, val12.Width))
							{
								if (val10.Right < val12.Right)
								{
									newRelativePosition.X = 0.0 - (val10.Width - val12.Width);
								}
								if (val10.Left > val12.Left)
								{
									newRelativePosition.X = 0.0;
								}
							}
							else if (IsGreaterThanOrClose(val12.Width, val10.Width))
							{
								if (val12.Right < val10.Right)
								{
									newRelativePosition.X = val12.Width - val10.Width;
								}
								if (val12.Left > val10.Left)
								{
									newRelativePosition.X = 0.0;
								}
							}
							if (IsGreaterThanOrClose(val10.Height, val12.Height))
							{
								if (val10.Bottom < val12.Bottom)
								{
									newRelativePosition.Y = 0.0 - (val10.Height - val12.Height);
								}
								if (val10.Top > val12.Top)
								{
									newRelativePosition.Y = 0.0;
								}
							}
							else if (IsGreaterThanOrClose(val12.Height, val10.Height))
							{
								if (val12.Bottom < val10.Bottom)
								{
									newRelativePosition.Y = val12.Height - val10.Height;
								}
								if (val12.Top > val10.Top)
								{
									newRelativePosition.Y = 0.0;
								}
							}
						}
					}
					val5 = new ScaleTransform(newRelativeScale / _viewboxFactor, newRelativeScale / _viewboxFactor);
					val6 = new TranslateTransform(newRelativePosition.X, newRelativePosition.Y);
					val7 = new TransformGroup();
					val7.Children.Add((Transform)(object)val5);
					val7.Children.Add((Transform)(object)val6);
					((UIElement)_contentPresenter).RenderTransform = (Transform)(object)val7;
					if (allowAnimation && IsAnimated)
					{
						DoubleAnimation val13 = new DoubleAnimation(num2, newRelativeScale / _viewboxFactor, AnimationDuration);
						((Timeline)val13).AccelerationRatio = AnimationAccelerationRatio;
						((Timeline)val13).DecelerationRatio = AnimationDecelerationRatio;
						DoubleAnimation val14 = new DoubleAnimation(x2, newRelativePosition.X, AnimationDuration);
						((Timeline)val14).AccelerationRatio = AnimationAccelerationRatio;
						((Timeline)val14).DecelerationRatio = AnimationDecelerationRatio;
						DoubleAnimation val15 = new DoubleAnimation(y, newRelativePosition.Y, AnimationDuration);
						((Timeline)val15).AccelerationRatio = AnimationAccelerationRatio;
						((Timeline)val15).DecelerationRatio = AnimationDecelerationRatio;
						((Timeline)val15).CurrentTimeInvalidated += UpdateViewport;
						((Timeline)val15).CurrentStateInvalidated += ZoomAnimationCompleted;
						((UIElement)this).RaiseEvent(new RoutedEventArgs(AnimationBeginningEvent, (object)this));
						((Animatable)val5).BeginAnimation(ScaleTransform.ScaleXProperty, (AnimationTimeline)(object)val13);
						((Animatable)val5).BeginAnimation(ScaleTransform.ScaleYProperty, (AnimationTimeline)(object)val13);
						((Animatable)val6).BeginAnimation(TranslateTransform.XProperty, (AnimationTimeline)(object)val14);
						((Animatable)val6).BeginAnimation(TranslateTransform.YProperty, (AnimationTimeline)(object)val15);
					}
					_relativePosition = newRelativePosition;
					_relativeScale = newRelativeScale;
					Scale = newRelativeScale;
					_basePosition = newRelativePosition + ContentOffset * newRelativeScale;
					UpdateViewport();
				}
				if (EffectiveViewStackMode == ZoomboxViewStackMode.Auto && allowStackAddition)
				{
					if (ViewStack.Count > 1 && Math.Abs(DateTime.Now.Ticks - _lastStackAddition.Ticks) < TimeSpan.FromMilliseconds(300.0).Ticks)
					{
						ViewStack.RemoveAt(ViewStack.Count - 1);
						_lastStackAddition = DateTime.Now - TimeSpan.FromMilliseconds(300.0);
					}
					if (ViewStack.Count <= 0 || !(view == ViewStack.SelectedView))
					{
						ViewStack.PushView(view);
						ViewStackIndex++;
						stackIndex = ViewStackIndex;
						_lastStackAddition = DateTime.Now;
					}
				}
				_lastViewIndex = CurrentViewIndex;
				SetCurrentViewIndex(stackIndex);
				SetCurrentView(view);
			}
			finally
			{
				IsUpdatingView = false;
			}
		}
	}

	private bool IsGreaterThanOrClose(double value1, double value2)
	{
		if (!(value1 <= value2))
		{
			return true;
		}
		return DoubleHelper.AreVirtuallyEqual(value1, value2);
	}

	private Rect CalculateFillRect()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		Size renderSize = ((UIElement)this).RenderSize;
		double width = renderSize.Width;
		Size renderSize2 = ((UIElement)this).RenderSize;
		double num = width / renderSize2.Height;
		double num2 = 0.0;
		double num3 = 0.0;
		Rect contentRect = ContentRect;
		double num4 = contentRect.Width;
		Rect contentRect2 = ContentRect;
		double num5 = contentRect2.Height;
		if (num > num4 / num5)
		{
			num5 = num4 / num;
			Rect contentRect3 = ContentRect;
			num3 = (contentRect3.Height - num5) / 2.0;
		}
		else
		{
			num4 = num5 * num;
			Rect contentRect4 = ContentRect;
			num2 = (contentRect4.Width - num4) / 2.0;
		}
		return new Rect(num2, num3, num4, num5);
	}

	private void CalculatePositionAndScale(Rect region, ref Point newRelativePosition, ref double newRelativeScale)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected I4, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected I4, but got Unknown
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		if (region.Width == 0.0 || region.Height == 0.0)
		{
			return;
		}
		Rect contentRect = ContentRect;
		if (contentRect.IntersectsWith(region))
		{
			region = new Rect(_content.TranslatePoint(region.TopLeft, (UIElement)(object)_contentPresenter), _content.TranslatePoint(region.BottomRight, (UIElement)(object)_contentPresenter));
			Size renderSize = ((UIElement)this).RenderSize;
			double num = renderSize.Width / region.Width;
			Size renderSize2 = ((UIElement)this).RenderSize;
			double num2 = renderSize2.Height / region.Height;
			newRelativeScale = ((num < num2) ? num : num2);
			if (newRelativeScale > MaxScale)
			{
				newRelativeScale = MaxScale;
			}
			else if (newRelativeScale < MinScale)
			{
				newRelativeScale = MinScale;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			HorizontalAlignment horizontalContentAlignment = ((Control)this).HorizontalContentAlignment;
			switch (horizontalContentAlignment - 1)
			{
			case 0:
			case 2:
			{
				Size renderSize4 = ((UIElement)this).RenderSize;
				num3 = (renderSize4.Width - region.Width * newRelativeScale) / 2.0;
				break;
			}
			case 1:
			{
				Size renderSize3 = ((UIElement)this).RenderSize;
				num3 = renderSize3.Width - region.Width * newRelativeScale;
				break;
			}
			}
			VerticalAlignment verticalContentAlignment = ((Control)this).VerticalContentAlignment;
			switch (verticalContentAlignment - 1)
			{
			case 0:
			case 2:
			{
				Size renderSize6 = ((UIElement)this).RenderSize;
				num4 = (renderSize6.Height - region.Height * newRelativeScale) / 2.0;
				break;
			}
			case 1:
			{
				Size renderSize5 = ((UIElement)this).RenderSize;
				num4 = renderSize5.Height - region.Height * newRelativeScale;
				break;
			}
			}
			Point topLeft = region.TopLeft;
			double num5 = (0.0 - topLeft.X) * newRelativeScale;
			Point topLeft2 = region.TopLeft;
			newRelativePosition = new Point(num5, (0.0 - topLeft2.Y) * newRelativeScale) + new Vector(num3, num4);
		}
	}

	private void UpdateViewFinderDisplayContentBounds()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null && _trueContent != null && _viewFinderDisplay != null)
		{
			UpdateViewboxFactor();
			Size renderSize = _content.RenderSize;
			Size val = _viewFinderDisplay.AvailableSize;
			if (val.Width > 0.0 && DoubleHelper.AreVirtuallyEqual(val.Height, 0.0))
			{
				val = new Size(val.Width, renderSize.Height * val.Width / renderSize.Width);
			}
			else if (val.Height > 0.0 && DoubleHelper.AreVirtuallyEqual(val.Width, 0.0))
			{
				val = new Size(renderSize.Width * val.Height / renderSize.Height, val.Width);
			}
			double num = val.Width / renderSize.Width;
			double num2 = val.Height / renderSize.Height;
			double num3 = ((num < num2) ? num : num2);
			double num4 = renderSize.Width * num3;
			double num5 = renderSize.Height * num3;
			_viewFinderDisplay.Scale = num3;
			_viewFinderDisplay.ContentBounds = new Rect(new Size(num4, num5));
		}
	}

	private void UpdateViewboxFactor()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null && _trueContent != null)
		{
			Size renderSize = _content.RenderSize;
			double width = renderSize.Width;
			Size renderSize2 = _trueContent.RenderSize;
			double width2 = renderSize2.Width;
			if (DoubleHelper.AreVirtuallyEqual(width, 0.0) || DoubleHelper.AreVirtuallyEqual(width2, 0.0))
			{
				_viewboxFactor = 1.0;
			}
			else
			{
				_viewboxFactor = width / width2;
			}
		}
	}

	private void UpdateViewport()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (_contentPresenter == null || _trueContent == null)
		{
			return;
		}
		IsUpdatingViewport = true;
		try
		{
			Point val = ((UIElement)this).TranslatePoint(new Point(0.0, 0.0), _trueContent);
			Size renderSize = ((UIElement)this).RenderSize;
			double width = renderSize.Width;
			Size renderSize2 = ((UIElement)this).RenderSize;
			Rect val2 = new Rect(val, ((UIElement)this).TranslatePoint(new Point(width, renderSize2.Height), _trueContent));
			if (!DoubleHelper.AreVirtuallyEqual(val2, Viewport))
			{
				((DependencyObject)this).SetValue(ViewportPropertyKey, (object)val2);
			}
		}
		finally
		{
			IsUpdatingViewport = false;
		}
	}

	private void UpdateViewport(object sender, EventArgs e)
	{
		UpdateViewport();
	}

	private void ViewFinderDisplayBeginCapture(object sender, MouseButtonEventArgs e)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		if (!(((FrameworkElement)_viewFinderDisplay).Tag is ResizeEdge))
		{
			return;
		}
		if ((ResizeEdge)((FrameworkElement)_viewFinderDisplay).Tag == ResizeEdge.None)
		{
			IsDraggingViewport = true;
		}
		else
		{
			IsResizingViewport = true;
			Vector val = default;
			switch ((ResizeEdge)((FrameworkElement)_viewFinderDisplay).Tag)
			{
			case ResizeEdge.TopLeft:
			{
				Rect viewportRect31 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = viewportRect31.TopLeft;
				Rect viewportRect32 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = viewportRect32.BottomRight;
				val = new Vector(-1.0, -1.0);
				break;
			}
			case ResizeEdge.TopRight:
			{
				Rect viewportRect29 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = viewportRect29.TopRight;
				Rect viewportRect30 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = viewportRect30.BottomLeft;
				val = new Vector(1.0, -1.0);
				break;
			}
			case ResizeEdge.BottomLeft:
			{
				Rect viewportRect27 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = viewportRect27.BottomLeft;
				Rect viewportRect28 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = viewportRect28.TopRight;
				val = new Vector(-1.0, 1.0);
				break;
			}
			case ResizeEdge.BottomRight:
			{
				Rect viewportRect25 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = viewportRect25.BottomRight;
				Rect viewportRect26 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = viewportRect26.TopLeft;
				val = new Vector(1.0, 1.0);
				break;
			}
			case ResizeEdge.Left:
			{
				Rect viewportRect19 = _viewFinderDisplay.ViewportRect;
				double left6 = viewportRect19.Left;
				Rect viewportRect20 = _viewFinderDisplay.ViewportRect;
				double top3 = viewportRect20.Top;
				Rect viewportRect21 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(left6, top3 + viewportRect21.Height / 2.0);
				Rect viewportRect22 = _viewFinderDisplay.ViewportRect;
				double right2 = viewportRect22.Right;
				Rect viewportRect23 = _viewFinderDisplay.ViewportRect;
				double top4 = viewportRect23.Top;
				Rect viewportRect24 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(right2, top4 + viewportRect24.Height / 2.0);
				val = new Vector(-1.0, 0.0);
				break;
			}
			case ResizeEdge.Top:
			{
				Rect viewportRect13 = _viewFinderDisplay.ViewportRect;
				double left4 = viewportRect13.Left;
				Rect viewportRect14 = _viewFinderDisplay.ViewportRect;
				double num3 = left4 + viewportRect14.Width / 2.0;
				Rect viewportRect15 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(num3, viewportRect15.Top);
				Rect viewportRect16 = _viewFinderDisplay.ViewportRect;
				double left5 = viewportRect16.Left;
				Rect viewportRect17 = _viewFinderDisplay.ViewportRect;
				double num4 = left5 + viewportRect17.Width / 2.0;
				Rect viewportRect18 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(num4, viewportRect18.Bottom);
				val = new Vector(0.0, -1.0);
				break;
			}
			case ResizeEdge.Right:
			{
				Rect viewportRect7 = _viewFinderDisplay.ViewportRect;
				double right = viewportRect7.Right;
				Rect viewportRect8 = _viewFinderDisplay.ViewportRect;
				double top = viewportRect8.Top;
				Rect viewportRect9 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(right, top + viewportRect9.Height / 2.0);
				Rect viewportRect10 = _viewFinderDisplay.ViewportRect;
				double left3 = viewportRect10.Left;
				Rect viewportRect11 = _viewFinderDisplay.ViewportRect;
				double top2 = viewportRect11.Top;
				Rect viewportRect12 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(left3, top2 + viewportRect12.Height / 2.0);
				val = new Vector(1.0, 0.0);
				break;
			}
			case ResizeEdge.Bottom:
			{
				Rect viewportRect = _viewFinderDisplay.ViewportRect;
				double left = viewportRect.Left;
				Rect viewportRect2 = _viewFinderDisplay.ViewportRect;
				double num = left + viewportRect2.Width / 2.0;
				Rect viewportRect3 = _viewFinderDisplay.ViewportRect;
				_resizeDraggingPoint = new Point(num, viewportRect3.Bottom);
				Rect viewportRect4 = _viewFinderDisplay.ViewportRect;
				double left2 = viewportRect4.Left;
				Rect viewportRect5 = _viewFinderDisplay.ViewportRect;
				double num2 = left2 + viewportRect5.Width / 2.0;
				Rect viewportRect6 = _viewFinderDisplay.ViewportRect;
				_resizeAnchorPoint = new Point(num2, viewportRect6.Top);
				val = new Vector(0.0, 1.0);
				break;
			}
			}
			_ = _viewFinderDisplay.Scale;
			Rect contentBounds = _viewFinderDisplay.ContentBounds;
			Vector val2 = new Vector(val.X * 10000000000.0, val.Y * 10000000000.0);
			Vector val3 = new Vector(val.X * contentBounds.Width / MaxScale, val.Y * contentBounds.Height / MaxScale);
			_resizeViewportBounds = new Rect(_resizeAnchorPoint + val2, _resizeAnchorPoint + val3);
		}
		_originPoint = ((MouseEventArgs)e).GetPosition((IInputElement)(object)_viewFinderDisplay);
		((UIElement)_viewFinderDisplay).CaptureMouse();
		((RoutedEventArgs)e).Handled = true;
	}

	private void ViewFinderDisplayEndCapture(object sender, MouseButtonEventArgs e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (IsDraggingViewport || IsResizingViewport)
		{
			DragDisplayViewport(new DragDeltaEventArgs(0.0, 0.0), end: true);
			IsDraggingViewport = false;
			IsResizingViewport = false;
			_originPoint = default;
			((UIElement)_viewFinderDisplay).ReleaseMouseCapture();
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void ViewFinderDisplayMouseMove(object sender, MouseEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.MouseDevice.LeftButton == 1 && (IsDraggingViewport || IsResizingViewport))
		{
			Point position = e.GetPosition((IInputElement)(object)_viewFinderDisplay);
			Vector val = position - _originPoint;
			if (IsDraggingViewport)
			{
				DragDisplayViewport(new DragDeltaEventArgs(val.X, val.Y), end: false);
			}
			else
			{
				ResizeDisplayViewport(new DragDeltaEventArgs(val.X, val.Y), (ResizeEdge)((FrameworkElement)_viewFinderDisplay).Tag);
			}
			((RoutedEventArgs)e).Handled = true;
			return;
		}
		Point position2 = e.GetPosition((IInputElement)(object)_viewFinderDisplay);
		Rect viewportRect = _viewFinderDisplay.ViewportRect;
		double num = ((viewportRect.Width * viewportRect.Height > 100.0) ? 5.0 : (Math.Sqrt(viewportRect.Width * viewportRect.Height) / 2.0));
		if (viewportRect.Contains(position2) && !DoubleHelper.AreVirtuallyEqual(Rect.Intersect(viewportRect, _viewFinderDisplay.ContentBounds), _viewFinderDisplay.ContentBounds))
		{
			if (PointHelper.DistanceBetween(position2, viewportRect.TopLeft) < num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.TopLeft;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeNWSE;
			}
			else if (PointHelper.DistanceBetween(position2, viewportRect.BottomRight) < num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.BottomRight;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeNWSE;
			}
			else if (PointHelper.DistanceBetween(position2, viewportRect.TopRight) < num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.TopRight;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeNESW;
			}
			else if (PointHelper.DistanceBetween(position2, viewportRect.BottomLeft) < num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.BottomLeft;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeNESW;
			}
			else if (position2.X <= viewportRect.Left + num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.Left;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeWE;
			}
			else if (position2.Y <= viewportRect.Top + num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.Top;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeNS;
			}
			else if (position2.X >= viewportRect.Right - num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.Right;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeWE;
			}
			else if (position2.Y >= viewportRect.Bottom - num)
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.Bottom;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeNS;
			}
			else
			{
				((FrameworkElement)_viewFinderDisplay).Tag = ResizeEdge.None;
				((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.SizeAll;
			}
		}
		else
		{
			((FrameworkElement)_viewFinderDisplay).Tag = null;
			((FrameworkElement)_viewFinderDisplay).Cursor = Cursors.Arrow;
		}
	}

	private void ZoomAnimationCompleted(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		if ((int)((Clock)((sender is AnimationClock) ? sender : null)).CurrentState != 0)
		{
			((Clock)((sender is AnimationClock) ? sender : null)).CurrentStateInvalidated -= ZoomAnimationCompleted;
			((Clock)((sender is AnimationClock) ? sender : null)).CurrentTimeInvalidated -= UpdateViewport;
			((UIElement)this).RaiseEvent(new RoutedEventArgs(AnimationCompletedEvent, (object)this));
		}
	}

	private void ZoomTo(double scale, bool allowStackAddition)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (_content != null)
		{
			ZoomTo(scale, GetZoomRelativePoint(), restrictRelativePointToContent: true, allowStackAddition);
		}
	}

	private void ZoomTo(double scale, Point relativeTo, bool restrictRelativePointToContent, bool allowStackAddition)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		if (_content == null)
		{
			return;
		}
		if (restrictRelativePointToContent)
		{
			Rect val = new Rect(_content.RenderSize);
			if (!val.Contains(relativeTo))
			{
				return;
			}
		}
		if (scale > MaxScale)
		{
			scale = MaxScale;
		}
		else if (scale < MinScale)
		{
			scale = MinScale;
		}
		Point val2 = relativeTo;
		if (HasRenderedFirstView)
		{
			relativeTo = _content.TranslatePoint(relativeTo, (UIElement)(object)this);
			val2 = ((UIElement)this).TranslatePoint(relativeTo, (UIElement)(object)_contentPresenter);
		}
		else
		{
			if (((UIElement)_contentPresenter).RenderTransform == Transform.Identity)
			{
				UpdateView(new ZoomboxView(1.0, new Point(0.0, 0.0)), allowAnimation: false, allowStackAddition: false);
			}
			relativeTo = ((GeneralTransform)((UIElement)_contentPresenter).RenderTransform).Transform(relativeTo);
		}
		Point position = new Point(relativeTo.X - val2.X * scale / _viewboxFactor, relativeTo.Y - val2.Y * scale / _viewboxFactor) + ContentOffset * scale / _viewboxFactor;
		UpdateView(new ZoomboxView(scale, position), !IsResizingViewport, allowStackAddition);
	}

	private Point GetZoomRelativePoint()
	{
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		if (ZoomOn == ZoomboxZoomOn.View)
		{
			Point val = default;
			Rect viewport = Viewport;
			double x = viewport.X;
			Rect viewport2 = Viewport;
			double width = viewport2.Width;
			Point zoomOrigin = ZoomOrigin;
			val.X = x + width * zoomOrigin.X;
			Rect viewport3 = Viewport;
			double y = viewport3.Y;
			Rect viewport4 = Viewport;
			double height = viewport4.Height;
			Point zoomOrigin2 = ZoomOrigin;
			val.Y = y + height * zoomOrigin2.Y;
			Point result = _trueContent.TranslatePoint(val, _content);
			if (result.X < 0.0)
			{
				result.X = 0.0;
			}
			else
			{
				double x2 = result.X;
				Size renderSize = _content.RenderSize;
				if (x2 > renderSize.Width)
				{
					Size renderSize2 = _content.RenderSize;
					result.X = renderSize2.Width;
				}
			}
			if (result.Y < 0.0)
			{
				result.Y = 0.0;
			}
			else
			{
				double y2 = result.Y;
				Size renderSize3 = _content.RenderSize;
				if (y2 > renderSize3.Height)
				{
					Size renderSize4 = _content.RenderSize;
					result.Y = renderSize4.Height;
				}
			}
			return result;
		}
		Size renderSize5 = _content.RenderSize;
		double width2 = renderSize5.Width;
		Point zoomOrigin3 = ZoomOrigin;
		double num = width2 * zoomOrigin3.X;
		Size renderSize6 = _content.RenderSize;
		double height2 = renderSize6.Height;
		Point zoomOrigin4 = ZoomOrigin;
		Point result2 = new Point(num, height2 * zoomOrigin4.Y);
		return result2;
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		if (NavigateOnPreview && !((RoutedEventArgs)e).Handled)
		{
			ProcessNavigationButton((RoutedEventArgs)(object)e);
		}
		((UIElement)this).OnPreviewKeyDown(e);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (!NavigateOnPreview && !((RoutedEventArgs)e).Handled)
		{
			ProcessNavigationButton((RoutedEventArgs)(object)e);
		}
		((UIElement)this).OnKeyDown(e);
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		if (NavigateOnPreview && !((RoutedEventArgs)e).Handled)
		{
			ProcessNavigationButton((RoutedEventArgs)(object)e);
		}
		((UIElement)this).OnPreviewMouseDown(e);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		if (!NavigateOnPreview && !((RoutedEventArgs)e).Handled)
		{
			ProcessNavigationButton((RoutedEventArgs)(object)e);
		}
		((UIElement)this).OnMouseDown(e);
	}

	protected override void OnMouseEnter(MouseEventArgs e)
	{
		MonitorInput();
		((UIElement)this).OnMouseEnter(e);
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		MonitorInput();
		((UIElement)this).OnMouseLeave(e);
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (DragOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonDown(e);
		}
		((UIElement)this).OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (!DragOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonDown(e);
		}
		((UIElement)this).OnMouseLeftButtonDown(e);
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (DragOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonUp(e);
		}
		((UIElement)this).OnPreviewMouseLeftButtonUp(e);
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (!DragOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseLeftButtonUp(e);
		}
		((UIElement)this).OnMouseLeftButtonUp(e);
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		if (DragOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseMove(e);
		}
		((UIElement)this).OnPreviewMouseMove(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		if (!DragOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseMove(e);
		}
		((UIElement)this).OnMouseMove(e);
	}

	protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
	{
		if (ZoomOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseWheelZoom(e);
		}
		((UIElement)this).OnPreviewMouseWheel(e);
	}

	protected override void OnMouseWheel(MouseWheelEventArgs e)
	{
		if (!ZoomOnPreview && !((RoutedEventArgs)e).Handled && _contentPresenter != null)
		{
			ProcessMouseWheelZoom(e);
		}
		((UIElement)this).OnMouseWheel(e);
	}
}
