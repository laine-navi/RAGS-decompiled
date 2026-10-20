using System;

namespace Xceed.Wpf.Toolkit;

public class ShortUpDown : CommonNumericUpDown<short>
{
	static ShortUpDown()
	{
		CommonNumericUpDown<short>.UpdateMetadata(typeof(ShortUpDown), 1, short.MinValue, short.MaxValue);
	}

	public ShortUpDown()
		: base((FromText)short.Parse, (FromDecimal)decimal.ToInt16, (Func<short, short, bool>)((short v1, short v2) => v1 < v2), (Func<short, short, bool>)((short v1, short v2) => v1 > v2))
	{
	}

	protected override short IncrementValue(short value, short increment)
	{
		return (short)(value + increment);
	}

	protected override short DecrementValue(short value, short increment)
	{
		return (short)(value - increment);
	}
}
