using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal struct Segment
{
	private bool _isP1Excluded;

	private bool _isP2Excluded;

	private Point _p1;

	private Point _p2;

	public static Segment Empty
	{
		get
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			Segment result = new Segment(new Point(0.0, 0.0));
			result._isP1Excluded = true;
			result._isP2Excluded = true;
			return result;
		}
	}

	public Point P1
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _p1;
		}
	}

	public Point P2
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _p2;
		}
	}

	public bool IsP1Excluded => _isP1Excluded;

	public bool IsP2Excluded => _isP2Excluded;

	public bool IsEmpty
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			if (DoubleHelper.AreVirtuallyEqual(_p1, _p2))
			{
				if (!_isP1Excluded)
				{
					return _isP2Excluded;
				}
				return true;
			}
			return false;
		}
	}

	public bool IsPoint
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return DoubleHelper.AreVirtuallyEqual(_p1, _p2);
		}
	}

	public double Length
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			Vector val = P2 - P1;
			return val.Length;
		}
	}

	public double Slope
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			Point p = P2;
			double x = p.X;
			Point p2 = P1;
			if (x != p2.X)
			{
				Point p3 = P2;
				double y = p3.Y;
				Point p4 = P1;
				double num = y - p4.Y;
				Point p5 = P2;
				double x2 = p5.X;
				Point p6 = P1;
				return num / (x2 - p6.X);
			}
			return double.NaN;
		}
	}

	public Segment(Point point)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_p1 = point;
		_p2 = point;
		_isP1Excluded = false;
		_isP2Excluded = false;
	}

	public Segment(Point p1, Point p2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_p1 = p1;
		_p2 = p2;
		_isP1Excluded = false;
		_isP2Excluded = false;
	}

	public Segment(Point p1, Point p2, bool excludeP1, bool excludeP2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		_p1 = p1;
		_p2 = p2;
		_isP1Excluded = excludeP1;
		_isP2Excluded = excludeP2;
	}

	public bool Contains(Point point)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (IsEmpty)
		{
			return false;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p1, point))
		{
			return _isP1Excluded;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p2, point))
		{
			return _isP2Excluded;
		}
		bool result = false;
		if (DoubleHelper.AreVirtuallyEqual(Slope, new Segment(_p1, point).Slope))
		{
			result = point.X >= Math.Min(_p1.X, _p2.X) && point.X <= Math.Max(_p1.X, _p2.X) && point.Y >= Math.Min(_p1.Y, _p2.Y) && point.Y <= Math.Max(_p1.Y, _p2.Y);
		}
		return result;
	}

	public bool Contains(Segment segment)
	{
		return segment == Intersection(segment);
	}

	public override bool Equals(object o)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		if (!(o is Segment segment))
		{
			return false;
		}
		if (IsEmpty)
		{
			return segment.IsEmpty;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p1, segment._p1))
		{
			if (DoubleHelper.AreVirtuallyEqual(_p2, segment._p2) && _isP1Excluded == segment._isP1Excluded)
			{
				return _isP2Excluded == segment._isP2Excluded;
			}
			return false;
		}
		if (DoubleHelper.AreVirtuallyEqual(_p1, segment._p2) && DoubleHelper.AreVirtuallyEqual(_p2, segment._p1) && _isP1Excluded == segment._isP2Excluded)
		{
			return _isP2Excluded == segment._isP1Excluded;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((object)_p1/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)_p2/*cast due to constrained. prefix*/).GetHashCode() ^ _isP1Excluded.GetHashCode() ^ _isP2Excluded.GetHashCode();
	}

	public Segment Intersection(Segment segment)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		if (IsEmpty || segment.IsEmpty)
		{
			return Empty;
		}
		if (this == segment)
		{
			return new Segment(_p1, _p2, _isP1Excluded, _isP2Excluded);
		}
		if (IsPoint)
		{
			if (!segment.Contains(_p1))
			{
				return Empty;
			}
			return new Segment(_p1);
		}
		if (segment.IsPoint)
		{
			if (!Contains(segment._p1))
			{
				return Empty;
			}
			return new Segment(segment._p1);
		}
		Point p = _p1;
		Vector val = _p2 - _p1;
		Point p2 = segment._p1;
		Vector val2 = segment._p2 - segment._p1;
		Vector val3 = p2 - p;
		double num = Vector.CrossProduct(val, val2);
		if (!DoubleHelper.AreVirtuallyEqual(Slope, segment.Slope))
		{
			double num2 = Vector.CrossProduct(val3, val) / num;
			if (num2 < 0.0 || num2 > 1.0)
			{
				return Empty;
			}
			num2 = Vector.CrossProduct(val3, val2) / num;
			if (num2 < 0.0 || num2 > 1.0)
			{
				return Empty;
			}
			return new Segment(p + num2 * val);
		}
		num = Vector.CrossProduct(val3, val);
		if (num * num > 1E-06 * val.LengthSquared * val3.LengthSquared)
		{
			return Empty;
		}
		Segment result = default;
		Segment segment2 = new Segment(_p1, _p2);
		Segment segment3 = new Segment(segment._p1, segment._p2);
		bool flag = segment3.Contains(segment2._p1);
		bool flag2 = segment3.Contains(segment2._p2);
		if (flag && flag2)
		{
			result._p1 = _p1;
			result._p2 = _p2;
			result._isP1Excluded = _isP1Excluded || !segment.Contains(_p1);
			result._isP2Excluded = _isP2Excluded || !segment.Contains(_p2);
			return result;
		}
		bool flag3 = segment2.Contains(segment3._p1);
		bool flag4 = segment2.Contains(segment3._p2);
		if (flag3 && flag4)
		{
			result._p1 = segment._p1;
			result._p2 = segment._p2;
			result._isP1Excluded = segment._isP1Excluded || !Contains(segment._p1);
			result._isP2Excluded = segment._isP2Excluded || !Contains(segment._p2);
			return result;
		}
		if (flag)
		{
			result._p1 = _p1;
			result._isP1Excluded = _isP1Excluded || !segment.Contains(_p1);
		}
		else
		{
			result._p1 = _p2;
			result._isP1Excluded = _isP2Excluded || !segment.Contains(_p2);
		}
		if (flag3)
		{
			result._p2 = segment._p1;
			result._isP2Excluded = segment._isP1Excluded || !Contains(segment._p1);
		}
		else
		{
			result._p2 = segment._p2;
			result._isP2Excluded = segment._isP2Excluded || !Contains(segment._p2);
		}
		return result;
	}

	public override string ToString()
	{
		string text = base.ToString();
		if (IsEmpty)
		{
			return text + ": {Empty}";
		}
		if (IsPoint)
		{
			return text + ", Point: " + ((object)_p1/*cast due to constrained. prefix*/).ToString();
		}
		return text + ": " + ((object)_p1/*cast due to constrained. prefix*/).ToString() + (_isP1Excluded ? " (excl)" : " (incl)") + " to " + ((object)_p2/*cast due to constrained. prefix*/).ToString() + (_isP2Excluded ? " (excl)" : " (incl)");
	}

	public static bool operator ==(Segment s1, Segment s2)
	{
		if ((object)s1 == null)
		{
			return (object)s2 == null;
		}
		if ((object)s2 == null)
		{
			return (object)s1 == null;
		}
		return s1.Equals(s2);
	}

	public static bool operator !=(Segment s1, Segment s2)
	{
		return !(s1 == s2);
	}
}
