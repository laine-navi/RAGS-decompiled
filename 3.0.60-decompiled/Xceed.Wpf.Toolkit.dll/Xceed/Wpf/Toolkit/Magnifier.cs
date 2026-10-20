using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit;

[TemplatePart(Name = "PART_VisualBrush", Type = typeof(VisualBrush))]
public class Magnifier : Control
{
	private const double DEFAULT_SIZE = 100.0;

	private const string PART_VisualBrush = "PART_VisualBrush";

	private VisualBrush _visualBrush = new VisualBrush();

	public static readonly DependencyProperty FrameTypeProperty;

	public static readonly DependencyProperty RadiusProperty;

	public static readonly DependencyProperty TargetProperty;

	public static readonly DependencyProperty ZoomFactorProperty;

	public FrameType FrameType
	{
		get
		{
			return (FrameType)((DependencyObject)this).GetValue(FrameTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FrameTypeProperty, (object)value);
		}
	}

	public double Radius
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(RadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RadiusProperty, (object)value);
		}
	}

	public UIElement Target
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (UIElement)((DependencyObject)this).GetValue(TargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetProperty, (object)value);
		}
	}

	internal Rect ViewBox
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return ((TileBrush)_visualBrush).Viewbox;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((TileBrush)_visualBrush).Viewbox = value;
		}
	}

	public double ZoomFactor
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomFactorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomFactorProperty, (object)value);
		}
	}

	private static void OnFrameTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Magnifier magnifier = (Magnifier)(object)d;
		magnifier.OnFrameTypeChanged((FrameType)e.OldValue, (FrameType)e.NewValue);
	}

	protected virtual void OnFrameTypeChanged(FrameType oldValue, FrameType newValue)
	{
		UpdateSizeFromRadius();
	}

	private static void OnRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Magnifier magnifier = (Magnifier)(object)d;
		magnifier.OnRadiusChanged(e);
	}

	protected virtual void OnRadiusChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateSizeFromRadius();
	}

	private static bool OnValidationCallback(object baseValue)
	{
		double num = (double)baseValue;
		return num >= 0.0;
	}

	private static void OnZoomFactorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Magnifier magnifier = (Magnifier)(object)d;
		magnifier.OnZoomFactorChanged(e);
	}

	protected virtual void OnZoomFactorChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateViewBox();
	}

	static Magnifier()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_00e8: Expected Obj, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected Obj, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Obj, but got Unknown
		FrameTypeProperty = DependencyProperty.Register("FrameType", typeof(FrameType), typeof(Magnifier), (PropertyMetadata)new UIPropertyMetadata((object)FrameType.Circle, (PropertyChangedCallback)OnFrameTypeChanged));
		RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(Magnifier), (PropertyMetadata)new FrameworkPropertyMetadata((object)50.0, (PropertyChangedCallback)OnRadiusPropertyChanged));
		TargetProperty = DependencyProperty.Register("Target", typeof(UIElement), typeof(Magnifier));
		ZoomFactorProperty = DependencyProperty.Register("ZoomFactor", typeof(double), typeof(Magnifier), (PropertyMetadata)new FrameworkPropertyMetadata((object)0.5, (PropertyChangedCallback)OnZoomFactorPropertyChanged), (ValidateValueCallback)OnValidationCallback);
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Magnifier), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(Magnifier)));
		FrameworkElement.HeightProperty.OverrideMetadata(typeof(Magnifier), (PropertyMetadata)new FrameworkPropertyMetadata((object)100.0));
		FrameworkElement.WidthProperty.OverrideMetadata(typeof(Magnifier), (PropertyMetadata)new FrameworkPropertyMetadata((object)100.0));
	}

	public Magnifier()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		((FrameworkElement)this).SizeChanged += OnSizeChangedEvent;
	}

	private void OnSizeChangedEvent(object sender, SizeChangedEventArgs e)
	{
		UpdateViewBox();
	}

	private void UpdateSizeFromRadius()
	{
		if (FrameType == FrameType.Circle)
		{
			double num = Radius * 2.0;
			if (!DoubleHelper.AreVirtuallyEqual(((FrameworkElement)this).Width, num))
			{
				((FrameworkElement)this).Width = num;
			}
			if (!DoubleHelper.AreVirtuallyEqual(((FrameworkElement)this).Height, num))
			{
				((FrameworkElement)this).Height = num;
			}
		}
	}

	public override void OnApplyTemplate()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		((FrameworkElement)this).OnApplyTemplate();
		DependencyObject templateChild = ((FrameworkElement)this).GetTemplateChild("PART_VisualBrush");
		VisualBrush val = (VisualBrush)(object)((templateChild is VisualBrush) ? templateChild : null);
		if (val == null)
		{
			val = new VisualBrush();
		}
		((TileBrush)val).Viewbox = ((TileBrush)_visualBrush).Viewbox;
		_visualBrush = val;
	}

	private void UpdateViewBox()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)this).IsInitialized)
		{
			Rect viewBox = ViewBox;
			ViewBox = new Rect(viewBox.Location, new Size(((FrameworkElement)this).ActualWidth * ZoomFactor, ((FrameworkElement)this).ActualHeight * ZoomFactor));
		}
	}
}
