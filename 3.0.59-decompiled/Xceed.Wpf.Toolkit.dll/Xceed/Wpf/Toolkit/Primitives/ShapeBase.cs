using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.Primitives;

public abstract class ShapeBase : Shape
{
	private Pen _pen;

	internal bool IsPenEmptyOrUndefined
	{
		get
		{
			double strokeThickness = ((Shape)this).StrokeThickness;
			if (((Shape)this).Stroke != null && !DoubleHelper.IsNaN(strokeThickness))
			{
				return DoubleHelper.AreVirtuallyEqual(0.0, strokeThickness);
			}
			return true;
		}
	}

	protected abstract override Geometry DefiningGeometry { get; }

	static ShapeBase()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected Obj, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected Obj, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Obj, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Obj, but got Unknown
		Shape.StrokeDashArrayProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeDashCapProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeDashOffsetProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeEndLineCapProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeLineJoinProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeMiterLimitProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeStartLineCapProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
		Shape.StrokeThicknessProperty.OverrideMetadata(typeof(ShapeBase), (PropertyMetadata)new FrameworkPropertyMetadata((PropertyChangedCallback)OnStrokeChanged));
	}

	internal virtual Rect GetDefiningGeometryBounds()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Geometry definingGeometry = ((Shape)this).DefiningGeometry;
		return definingGeometry.Bounds;
	}

	internal virtual Size GetNaturalSize()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		Geometry definingGeometry = ((Shape)this).DefiningGeometry;
		Rect renderBounds = definingGeometry.GetRenderBounds(GetPen());
		return new Size(Math.Max(renderBounds.Right, 0.0), Math.Max(renderBounds.Bottom, 0.0));
	}

	internal Pen GetPen()
	{
		if (IsPenEmptyOrUndefined)
		{
			return null;
		}
		if (_pen == null)
		{
			_pen = MakePen();
		}
		return _pen;
	}

	internal double GetStrokeThickness()
	{
		if (IsPenEmptyOrUndefined)
		{
			return 0.0;
		}
		return Math.Abs(((Shape)this).StrokeThickness);
	}

	internal bool IsSizeEmptyOrUndefined(Size size)
	{
		if (!DoubleHelper.IsNaN(size.Width) && !DoubleHelper.IsNaN(size.Height))
		{
			return size.IsEmpty;
		}
		return true;
	}

	private static void OnStrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ShapeBase)(object)d)._pen = null;
	}

	private Pen MakePen()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		Pen val = new Pen();
		val.Brush = ((Shape)this).Stroke;
		val.DashCap = ((Shape)this).StrokeDashCap;
		if (((Shape)this).StrokeDashArray != null || ((Shape)this).StrokeDashOffset != 0.0)
		{
			val.DashStyle = new DashStyle((IEnumerable<double>)((Shape)this).StrokeDashArray, ((Shape)this).StrokeDashOffset);
		}
		val.EndLineCap = ((Shape)this).StrokeEndLineCap;
		val.LineJoin = ((Shape)this).StrokeLineJoin;
		val.MiterLimit = ((Shape)this).StrokeMiterLimit;
		val.StartLineCap = ((Shape)this).StrokeStartLineCap;
		val.Thickness = Math.Abs(((Shape)this).StrokeThickness);
		return val;
	}
}
