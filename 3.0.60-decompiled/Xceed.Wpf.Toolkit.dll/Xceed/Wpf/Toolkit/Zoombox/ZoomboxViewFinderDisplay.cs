using System;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Zoombox;

public class ZoomboxViewFinderDisplay : FrameworkElement
{
	public static readonly DependencyProperty BackgroundProperty;

	private static readonly DependencyPropertyKey ContentBoundsPropertyKey;

	public static readonly DependencyProperty ContentBoundsProperty;

	public static readonly DependencyProperty ShadowBrushProperty;

	public static readonly DependencyProperty ViewportBrushProperty;

	public static readonly DependencyProperty ViewportPenProperty;

	public static readonly DependencyProperty ViewportRectProperty;

	private static readonly DependencyPropertyKey VisualBrushPropertyKey;

	public static readonly DependencyProperty VisualBrushProperty;

	private Size _availableSize = Size.Empty;

	private double _scale = 1.0;

	public Brush Background
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(BackgroundProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BackgroundProperty, (object)value);
		}
	}

	internal Rect ContentBounds
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Rect)((DependencyObject)this).GetValue(ContentBoundsProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(ContentBoundsPropertyKey, (object)value);
		}
	}

	public Brush ShadowBrush
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(ShadowBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShadowBrushProperty, (object)value);
		}
	}

	public Brush ViewportBrush
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Brush)((DependencyObject)this).GetValue(ViewportBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewportBrushProperty, (object)value);
		}
	}

	public Pen ViewportPen
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (Pen)((DependencyObject)this).GetValue(ViewportPenProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewportPenProperty, (object)value);
		}
	}

	public Rect ViewportRect
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Rect)((DependencyObject)this).GetValue(ViewportRectProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(ViewportRectProperty, (object)value);
		}
	}

	internal VisualBrush VisualBrush
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected Obj, but got Unknown
			return (VisualBrush)((DependencyObject)this).GetValue(VisualBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisualBrushPropertyKey, (object)value);
		}
	}

	internal Size AvailableSize
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _availableSize;
		}
	}

	internal double Scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = value;
		}
	}

	static ZoomboxViewFinderDisplay()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected Obj, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected Obj, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected Obj, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected Obj, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected Obj, but got Unknown
		BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)new SolidColorBrush(Color.FromArgb((byte)192, byte.MaxValue, byte.MaxValue, byte.MaxValue)), (FrameworkPropertyMetadataOptions)16));
		ContentBoundsPropertyKey = DependencyProperty.RegisterReadOnly("ContentBounds", typeof(Rect), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)Rect.Empty, (FrameworkPropertyMetadataOptions)17));
		ContentBoundsProperty = ContentBoundsPropertyKey.DependencyProperty;
		ShadowBrushProperty = DependencyProperty.Register("ShadowBrush", typeof(Brush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)new SolidColorBrush(Color.FromArgb((byte)128, byte.MaxValue, byte.MaxValue, byte.MaxValue)), (FrameworkPropertyMetadataOptions)16));
		ViewportBrushProperty = DependencyProperty.Register("ViewportBrush", typeof(Brush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)Brushes.Transparent, (FrameworkPropertyMetadataOptions)16));
		ViewportPenProperty = DependencyProperty.Register("ViewportPen", typeof(Pen), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)new Pen((Brush)new SolidColorBrush(Color.FromArgb((byte)128, (byte)0, (byte)0, (byte)0)), 1.0), (FrameworkPropertyMetadataOptions)16));
		ViewportRectProperty = DependencyProperty.Register("ViewportRect", typeof(Rect), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)Rect.Empty, (FrameworkPropertyMetadataOptions)16));
		VisualBrushPropertyKey = DependencyProperty.RegisterReadOnly("VisualBrush", typeof(VisualBrush), typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)null));
		VisualBrushProperty = VisualBrushPropertyKey.DependencyProperty;
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ZoomboxViewFinderDisplay), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(ZoomboxViewFinderDisplay)));
	}

	public ZoomboxViewFinderDisplay()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return ((UIElement)this).DesiredSize;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		_availableSize = availableSize;
		Rect contentBounds = ContentBounds;
		double num;
		if (!DoubleHelper.IsNaN(contentBounds.Width))
		{
			Rect contentBounds2 = ContentBounds;
			num = Math.Max(0.0, contentBounds2.Width);
		}
		else
		{
			num = 0.0;
		}
		double num2 = num;
		Rect contentBounds3 = ContentBounds;
		double num3;
		if (!DoubleHelper.IsNaN(contentBounds3.Height))
		{
			Rect contentBounds4 = ContentBounds;
			num3 = Math.Max(0.0, contentBounds4.Height);
		}
		else
		{
			num3 = 0.0;
		}
		double num4 = num3;
		Size result = new Size(num2, num4);
		if (result.Width > availableSize.Width || result.Height > availableSize.Height)
		{
			double num5 = availableSize.Width / result.Width;
			double num6 = availableSize.Height / result.Height;
			double num7 = ((num5 < num6) ? num5 : num6);
			result = new Size(result.Width * num7, result.Height * num7);
		}
		return result;
	}

	protected override void OnRender(DrawingContext dc)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		((UIElement)this).OnRender(dc);
		dc.DrawRectangle(Background, (Pen)null, ContentBounds);
		dc.DrawRectangle((Brush)(object)VisualBrush, (Pen)null, ContentBounds);
		Rect viewportRect = ViewportRect;
		if (viewportRect.IntersectsWith(new Rect(((UIElement)this).RenderSize)))
		{
			Point val = new Point(0.0, 0.0);
			Size renderSize = ((UIElement)this).RenderSize;
			double width = renderSize.Width;
			Rect viewportRect2 = ViewportRect;
			Rect val2 = new Rect(val, new Size(width, Math.Max(0.0, viewportRect2.Top)));
			Rect viewportRect3 = ViewportRect;
			Point val3 = new Point(0.0, viewportRect3.Top);
			Rect viewportRect4 = ViewportRect;
			double num = Math.Max(0.0, viewportRect4.Left);
			Rect viewportRect5 = ViewportRect;
			Rect val4 = new Rect(val3, new Size(num, viewportRect5.Height));
			Rect viewportRect6 = ViewportRect;
			double right = viewportRect6.Right;
			Rect viewportRect7 = ViewportRect;
			Point val5 = new Point(right, viewportRect7.Top);
			Size renderSize2 = ((UIElement)this).RenderSize;
			double width2 = renderSize2.Width;
			Rect viewportRect8 = ViewportRect;
			double num2 = Math.Max(0.0, width2 - viewportRect8.Right);
			Rect viewportRect9 = ViewportRect;
			Rect val6 = new Rect(val5, new Size(num2, viewportRect9.Height));
			Rect viewportRect10 = ViewportRect;
			Point val7 = new Point(0.0, viewportRect10.Bottom);
			Size renderSize3 = ((UIElement)this).RenderSize;
			double width3 = renderSize3.Width;
			Size renderSize4 = ((UIElement)this).RenderSize;
			double height = renderSize4.Height;
			Rect viewportRect11 = ViewportRect;
			Rect val8 = new Rect(val7, new Size(width3, Math.Max(0.0, height - viewportRect11.Bottom)));
			dc.DrawRectangle(ShadowBrush, (Pen)null, val2);
			dc.DrawRectangle(ShadowBrush, (Pen)null, val4);
			dc.DrawRectangle(ShadowBrush, (Pen)null, val6);
			dc.DrawRectangle(ShadowBrush, (Pen)null, val8);
			dc.DrawRectangle(ViewportBrush, ViewportPen, ViewportRect);
		}
		else
		{
			dc.DrawRectangle(ShadowBrush, (Pen)null, new Rect(((UIElement)this).RenderSize));
		}
	}
}
