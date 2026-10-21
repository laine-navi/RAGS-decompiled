using System;
using System.Drawing;
using System.Windows.Forms;

internal class a
{
	private const double m_a = 14.4;

	internal static int a(TextBoxBase A_0, int A_1, int A_2)
	{
		RichTextBox val = (RichTextBox)(object)((A_0 is RichTextBox) ? A_0 : null);
		if (val == null)
		{
			return ((Control)A_0).Font.Height;
		}
		d.b b2 = default;
		b2.a = A_1;
		b2.b = A_1 + A_2;
		d.a a2 = default;
		a2.b = 0;
		a2.d = 14;
		a2.a = 0;
		a2.c = (int)((double)((Control)val).ClientSize.Width * 14.4);
		d.a a3 = default;
		a3.b = 0;
		a3.d = 14;
		a3.a = 0;
		a3.c = (int)((double)((Control)val).ClientSize.Width * 14.4);
		Graphics val2 = Graphics.FromHwnd(((Control)val).Handle);
		IntPtr hdc = val2.GetHdc();
		d.c A_3 = default;
		A_3.e = b2;
		A_3.a = hdc;
		A_3.b = hdc;
		A_3.c = a2;
		A_3.d = a3;
		d.SendMessage(((Control)val).Handle, 1081u, IntPtr.Zero, ref A_3);
		val2.ReleaseHdc(hdc);
		val2.Dispose();
		return (int)((double)(A_3.c.c - A_3.c.a) / 14.4);
	}

	internal static int c(TextBoxBase A_0, int A_1)
	{
		RichTextBox val = (RichTextBox)(object)((A_0 is RichTextBox) ? A_0 : null);
		if (val == null)
		{
			return ((Control)A_0).Font.Height;
		}
		int lineFromCharIndex = ((TextBoxBase)val).GetLineFromCharIndex(A_1);
		int num = d.SendMessageInt(((Control)val).Handle, 187u, new IntPtr(lineFromCharIndex), IntPtr.Zero).ToInt32();
		int num2 = d.SendMessageInt(((Control)val).Handle, 193u, new IntPtr(lineFromCharIndex), IntPtr.Zero).ToInt32();
		d.b b2 = default;
		b2.a = num;
		b2.b = num + num2;
		d.a a2 = default;
		a2.b = 0;
		a2.d = 14;
		a2.a = 0;
		a2.c = 10000000;
		d.a a3 = default;
		a3.b = 0;
		a3.d = 14;
		a3.a = 0;
		a3.c = 10000000;
		Graphics val2 = Graphics.FromHwnd(((Control)val).Handle);
		IntPtr hdc = val2.GetHdc();
		d.c A_2 = default;
		A_2.e = b2;
		A_2.a = hdc;
		A_2.b = hdc;
		A_2.c = a2;
		A_2.d = a3;
		d.SendMessage(((Control)val).Handle, 1081u, IntPtr.Zero, ref A_2).ToInt32();
		val2.ReleaseHdc(hdc);
		val2.Dispose();
		return (int)((double)(A_2.c.d - A_2.c.b) / 14.4);
	}

	internal static void a(TextBox A_0)
	{
		bool flag = false;
		int num = 0;
		while (!flag && num < 10)
		{
			flag = d.ShowCaretAPI(((Control)A_0).Handle);
			num++;
		}
	}

	internal static int a(TextBoxBase A_0, Point A_1)
	{
		int value = (A_1.X & 0xFFFF) + ((A_1.Y & 0xFFFF) << 16);
		int num = d.SendMessageInt(((Control)A_0).Handle, 215u, IntPtr.Zero, new IntPtr(value)).ToInt32();
		int value2 = (num & 0xFFFF) >> 16;
		int num2 = num & 0xFFFF;
		int num3 = d.SendMessageInt(((Control)A_0).Handle, 187u, new IntPtr(value2), IntPtr.Zero).ToInt32();
		return num3 + num2;
	}

	internal static Point b(TextBoxBase A_0, int A_1)
	{
		int dw = d.SendMessageInt(((Control)A_0).Handle, 214u, new IntPtr(A_1), IntPtr.Zero).ToInt32();
		return new Point(dw);
	}

	internal static int a(TextBoxBase A_0)
	{
		return d.SendMessageInt(((Control)A_0).Handle, 206u, IntPtr.Zero, IntPtr.Zero).ToInt32();
	}

	internal static int a(TextBoxBase A_0, int A_1)
	{
		return d.SendMessageInt(((Control)A_0).Handle, 187u, new IntPtr(A_1), IntPtr.Zero).ToInt32();
	}

	private a()
	{
	}
}
