using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal static class RectHelper
{
	public static Point Center(Rect rect)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		return new Point(rect.Left + rect.Width / 2.0, rect.Top + rect.Height / 2.0);
	}

	public static Point? GetNearestPointOfIntersectionBetweenRectAndSegment(Rect rect, Segment segment, Point point)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		Point? result = null;
		double distance = double.PositiveInfinity;
		Segment intersection = segment.Intersection(new Segment(rect.BottomLeft, rect.TopLeft));
		Segment intersection2 = segment.Intersection(new Segment(rect.TopLeft, rect.TopRight));
		Segment intersection3 = segment.Intersection(new Segment(rect.TopRight, rect.BottomRight));
		Segment intersection4 = segment.Intersection(new Segment(rect.BottomRight, rect.BottomLeft));
		AdjustResultForIntersectionWithSide(ref result, ref distance, intersection, point);
		AdjustResultForIntersectionWithSide(ref result, ref distance, intersection2, point);
		AdjustResultForIntersectionWithSide(ref result, ref distance, intersection3, point);
		AdjustResultForIntersectionWithSide(ref result, ref distance, intersection4, point);
		return result;
	}

	public static Rect GetRectCenteredOnPoint(Point center, Size size)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		return new Rect(new Point(center.X - size.Width / 2.0, center.Y - size.Height / 2.0), size);
	}

	private static void AdjustResultForIntersectionWithSide(ref Point? result, ref double distance, Segment intersection, Point point)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		if (intersection.IsEmpty)
		{
			return;
		}
		if (intersection.Contains(point))
		{
			distance = 0.0;
			result = point;
			return;
		}
		double num = PointHelper.DistanceBetween(point, intersection.P1);
		double num2 = double.PositiveInfinity;
		if (!intersection.IsPoint)
		{
			num2 = PointHelper.DistanceBetween(point, intersection.P2);
		}
		if (Math.Min(num, num2) < distance)
		{
			if (num < num2)
			{
				distance = num;
				result = intersection.P1;
			}
			else
			{
				distance = num2;
				result = intersection.P2;
			}
		}
	}
}
