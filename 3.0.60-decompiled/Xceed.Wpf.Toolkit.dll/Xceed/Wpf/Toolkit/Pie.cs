using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Primitives;

namespace Xceed.Wpf.Toolkit;

public sealed class Pie : ShapeBase
{
	private enum CacheBits
	{
		IsUpdatingEndAngle = 1,
		IsUpdatingMode = 2,
		IsUpdatingSlice = 4,
		IsUpdatingStartAngle = 8,
		IsUpdatingSweepDirection = 0x10
	}

	public static readonly DependencyProperty EndAngleProperty;

	public static readonly DependencyProperty ModeProperty;

	public static readonly DependencyProperty SliceProperty;

	public static readonly DependencyProperty StartAngleProperty;

	public static readonly DependencyProperty SweepDirectionProperty;

	private Rect _rect = Rect.Empty;

	private BitVector32 _cacheBits = new BitVector32(0);

	public double EndAngle
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(EndAngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndAngleProperty, (object)value);
		}
	}

	public PieMode Mode
	{
		get
		{
			return (PieMode)((DependencyObject)this).GetValue(ModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ModeProperty, (object)value);
		}
	}

	public double Slice
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(SliceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SliceProperty, (object)value);
		}
	}

	public double StartAngle
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(StartAngleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartAngleProperty, (object)value);
		}
	}

	public SweepDirection SweepDirection
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (SweepDirection)((DependencyObject)this).GetValue(SweepDirectionProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(SweepDirectionProperty, (object)value);
		}
	}

	public override Transform GeometryTransform => Transform.Identity;

	public override Geometry RenderedGeometry => ((Shape)this).DefiningGeometry;

	protected override Geometry DefiningGeometry
	{
		get
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Invalid comparison between Unknown and I4
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected Obj, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected Obj, but got Unknown
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Expected Obj, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Expected Obj, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected Obj, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Expected Obj, but got Unknown
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected Obj, but got Unknown
			double slice = Slice;
			if (_rect.IsEmpty || slice <= 0.0)
			{
				return Geometry.Empty;
			}
			if (!(slice >= 1.0))
			{
				double num = (((int)SweepDirection == 1) ? 1.0 : (-1.0));
				double startAngle = StartAngle;
				Point val = EllipseHelper.PointOfRadialIntersection(_rect, startAngle);
				Point point = EllipseHelper.PointOfRadialIntersection(_rect, startAngle + num * slice * 360.0);
				PathSegmentCollection val2 = new PathSegmentCollection();
				val2.Add((PathSegment)new LineSegment(val, true));
				ArcSegment val3 = new ArcSegment();
				val3.Point = point;
				val3.Size = new Size(_rect.Width / 2.0, _rect.Height / 2.0);
				val3.IsLargeArc = slice > 0.5;
				val3.SweepDirection = SweepDirection;
				val2.Add((PathSegment)(object)val3);
				PathFigureCollection val4 = new PathFigureCollection();
				val4.Add(new PathFigure(RectHelper.Center(_rect), (IEnumerable<PathSegment>)val2, true));
				return (Geometry)new PathGeometry((IEnumerable<PathFigure>)val4);
			}
			return (Geometry)new EllipseGeometry(_rect);
		}
	}

	private bool IsUpdatingEndAngle
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

	private bool IsUpdatingMode
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

	private bool IsUpdatingSlice
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

	private bool IsUpdatingStartAngle
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

	private bool IsUpdatingSweepDirection
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

	static Pie()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0049: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00e7: Expected Obj, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected Obj, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected Obj, but got Unknown
		//IL_0171: Expected Obj, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected Obj, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Obj, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected Obj, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected Obj, but got Unknown
		EndAngleProperty = DependencyProperty.Register("EndAngle", typeof(double), typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)360.0, (FrameworkPropertyMetadataOptions)272, (PropertyChangedCallback)OnEndAngleChanged, (CoerceValueCallback)CoerceEndAngleValue));
		ModeProperty = DependencyProperty.Register("Mode", typeof(PieMode), typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)PieMode.Manual, (PropertyChangedCallback)OnModeChanged));
		SliceProperty = DependencyProperty.Register("Slice", typeof(double), typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)1.0, (FrameworkPropertyMetadataOptions)272, (PropertyChangedCallback)OnSliceChanged, (CoerceValueCallback)CoerceSliceValue), (ValidateValueCallback)ValidateSlice);
		StartAngleProperty = DependencyProperty.Register("StartAngle", typeof(double), typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)360.0, (FrameworkPropertyMetadataOptions)272, (PropertyChangedCallback)OnStartAngleChanged));
		SweepDirectionProperty = DependencyProperty.Register("SweepDirection", typeof(SweepDirection), typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)(SweepDirection)1, (FrameworkPropertyMetadataOptions)16, (PropertyChangedCallback)OnSweepDirectionChanged, (CoerceValueCallback)CoerceSweepDirectionValue));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)typeof(Pie)));
		Shape.StretchProperty.OverrideMetadata(typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)(Stretch)1));
		Shape.StrokeLineJoinProperty.OverrideMetadata(typeof(Pie), (PropertyMetadata)new FrameworkPropertyMetadata((object)(PenLineJoin)2));
	}

	public Pie()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
	}

	private static void OnEndAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnEndAngleChanged(e);
	}

	private void OnEndAngleChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingEndAngle)
		{
			return;
		}
		if (!IsUpdatingStartAngle && !IsUpdatingSlice && !IsUpdatingSweepDirection)
		{
			PieMode mode = Mode;
			if (mode == PieMode.Slice)
			{
				throw new InvalidOperationException(ErrorMessages.GetMessage("EndAngleCannotBeSetDirectlyInSlice"));
			}
		}
		IsUpdatingEndAngle = true;
		try
		{
			if (Mode == PieMode.EndAngle)
			{
				((DependencyObject)this).CoerceValue(SweepDirectionProperty);
			}
			((DependencyObject)this).CoerceValue(SliceProperty);
		}
		finally
		{
			IsUpdatingEndAngle = false;
		}
	}

	private static object CoerceEndAngleValue(DependencyObject d, object value)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		Pie pie = (Pie)(object)d;
		if (pie.IsUpdatingSlice || pie.IsUpdatingSweepDirection || (pie.IsUpdatingStartAngle && pie.Mode == PieMode.Slice))
		{
			double num = pie.StartAngle + (((int)pie.SweepDirection == 1) ? 1.0 : (-1.0)) * pie.Slice * 360.0;
			if (!DoubleHelper.AreVirtuallyEqual((double)value, num))
			{
				value = num;
			}
		}
		return value;
	}

	private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnModeChanged(e);
	}

	private void OnModeChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingMode)
		{
			return;
		}
		IsUpdatingMode = true;
		try
		{
			if (Mode == PieMode.EndAngle)
			{
				((DependencyObject)this).CoerceValue(SweepDirectionProperty);
			}
		}
		finally
		{
			IsUpdatingMode = false;
		}
	}

	private static void OnSliceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnSliceChanged(e);
	}

	private void OnSliceChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingSlice)
		{
			return;
		}
		if (!IsUpdatingStartAngle && !IsUpdatingEndAngle && !IsUpdatingSweepDirection && Mode == PieMode.EndAngle)
		{
			throw new InvalidOperationException(ErrorMessages.GetMessage("SliceCannotBeSetDirectlyInEndAngle"));
		}
		IsUpdatingSlice = true;
		try
		{
			if (!IsUpdatingStartAngle && !IsUpdatingEndAngle && (Mode != PieMode.Manual || !IsUpdatingSweepDirection))
			{
				((DependencyObject)this).CoerceValue(EndAngleProperty);
			}
		}
		finally
		{
			IsUpdatingSlice = false;
		}
	}

	private static object CoerceSliceValue(DependencyObject d, object value)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		Pie pie = (Pie)(object)d;
		if (pie.IsUpdatingEndAngle || pie.IsUpdatingStartAngle || pie.IsUpdatingSweepDirection)
		{
			double num = Math.Max(-360.0, Math.Min(360.0, pie.EndAngle - pie.StartAngle)) / (((int)pie.SweepDirection == 1) ? 360.0 : (-360.0));
			double num2;
			if (DoubleHelper.AreVirtuallyEqual(num, 0.0))
			{
				num2 = 0.0;
			}
			else
			{
				num2 = ((num < 0.0) ? (num + 1.0) : num);
			}
			if (!DoubleHelper.AreVirtuallyEqual((double)value, num2))
			{
				value = num2;
			}
		}
		return value;
	}

	private static bool ValidateSlice(object value)
	{
		double num = (double)value;
		if (num < 0.0 || num > 1.0 || DoubleHelper.IsNaN(num))
		{
			throw new ArgumentException(ErrorMessages.GetMessage("SliceOOR"));
		}
		return true;
	}

	private static void OnStartAngleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnStartAngleChanged(e);
	}

	private void OnStartAngleChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingStartAngle)
		{
			return;
		}
		IsUpdatingStartAngle = true;
		try
		{
			switch (Mode)
			{
			case PieMode.Manual:
				((DependencyObject)this).CoerceValue(SliceProperty);
				break;
			case PieMode.EndAngle:
				((DependencyObject)this).CoerceValue(SweepDirectionProperty);
				((DependencyObject)this).CoerceValue(SliceProperty);
				break;
			case PieMode.Slice:
				((DependencyObject)this).CoerceValue(EndAngleProperty);
				break;
			}
		}
		finally
		{
			IsUpdatingStartAngle = false;
		}
	}

	private static void OnSweepDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((Pie)(object)d).OnSweepDirectionChanged(e);
	}

	private void OnSweepDirectionChanged(DependencyPropertyChangedEventArgs e)
	{
		if (IsUpdatingSweepDirection)
		{
			return;
		}
		IsUpdatingSweepDirection = true;
		try
		{
			PieMode mode = Mode;
			if (mode == PieMode.Slice)
			{
				((DependencyObject)this).CoerceValue(EndAngleProperty);
			}
			else
			{
				((DependencyObject)this).CoerceValue(SliceProperty);
			}
		}
		finally
		{
			IsUpdatingSweepDirection = false;
		}
	}

	private static object CoerceSweepDirectionValue(DependencyObject d, object value)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		Pie pie = (Pie)(object)d;
		if (pie.IsUpdatingEndAngle || pie.IsUpdatingStartAngle || pie.IsUpdatingMode)
		{
			value = ((!DoubleHelper.AreVirtuallyEqual(pie.StartAngle, pie.EndAngle)) ? ((object)(SweepDirection)(!(pie.EndAngle < pie.StartAngle))) : ((object)pie.SweepDirection));
		}
		return value;
	}

	internal override Size GetNaturalSize()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		double strokeThickness = GetStrokeThickness();
		return new Size(strokeThickness, strokeThickness);
	}

	internal override Rect GetDefiningGeometryBounds()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return _rect;
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected I4, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		double strokeThickness = GetStrokeThickness();
		double num = strokeThickness / 2.0;
		_rect = new Rect(num, num, Math.Max(0.0, finalSize.Width - strokeThickness), Math.Max(0.0, finalSize.Height - strokeThickness));
		Stretch stretch = ((Shape)this).Stretch;
		switch ((int)stretch)
		{
		case 0:
		{
			ref Rect rect = ref _rect;
			double width = (_rect.Height = 0.0);
			rect.Width = width;
			break;
		}
		case 2:
			if (_rect.Width > _rect.Height)
			{
				_rect.Width = _rect.Height;
			}
			else
			{
				_rect.Height = _rect.Width;
			}
			break;
		case 3:
			if (_rect.Width < _rect.Height)
			{
				_rect.Width = _rect.Height;
			}
			else
			{
				_rect.Height = _rect.Width;
			}
			break;
		}
		return finalSize;
	}

	protected override Size MeasureOverride(Size constraint)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((Shape)this).Stretch == 3)
		{
			double width = constraint.Width;
			double height = constraint.Height;
			if (double.IsInfinity(width) && double.IsInfinity(height))
			{
				return GetNaturalSize();
			}
			width = ((!double.IsInfinity(width) && !double.IsInfinity(height)) ? Math.Max(width, height) : Math.Min(width, height));
			return new Size(width, width);
		}
		return GetNaturalSize();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		if (!_rect.IsEmpty)
		{
			Pen pen = GetPen();
			drawingContext.DrawGeometry(((Shape)this).Fill, pen, ((Shape)this).RenderedGeometry);
		}
	}
}
