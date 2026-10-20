using System;

namespace Xceed.Wpf.Toolkit;

public class ByteUpDown : CommonNumericUpDown<byte>
{
	static ByteUpDown()
	{
		CommonNumericUpDown<byte>.UpdateMetadata(typeof(ByteUpDown), 1, 0, byte.MaxValue);
	}

	public ByteUpDown()
		: base((FromText)byte.Parse, (FromDecimal)decimal.ToByte, (Func<byte, byte, bool>)((byte v1, byte v2) => v1 < v2), (Func<byte, byte, bool>)((byte v1, byte v2) => v1 > v2))
	{
	}

	protected override byte IncrementValue(byte value, byte increment)
	{
		return (byte)(value + increment);
	}

	protected override byte DecrementValue(byte value, byte increment)
	{
		return (byte)(value - increment);
	}
}
