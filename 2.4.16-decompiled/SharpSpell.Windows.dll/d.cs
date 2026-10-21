using System;
using System.Runtime.InteropServices;

internal class d
{
	internal struct a
	{
		public int a;

		public int b;

		public int c;

		public int d;
	}

	internal struct b
	{
		public int a;

		public int b;
	}

	internal struct c
	{
		public IntPtr a;

		public IntPtr b;

		public a c;

		public a d;

		public b e;
	}

	internal const int a = 1024;

	internal const int b = 1081;

	internal const int c = 187;

	internal const int d = 193;

	internal const int e = 214;

	internal const int f = 215;

	internal const int g = 206;

	[DllImport("user32")]
	internal static extern IntPtr SendMessage(IntPtr A_0, uint A_1, IntPtr A_2, ref c A_3);

	[DllImport("user32", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
	internal static extern IntPtr SendMessageInt(IntPtr A_0, uint A_1, IntPtr A_2, IntPtr A_3);

	[DllImport("user32", EntryPoint = "ShowCaret")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool ShowCaretAPI(IntPtr A_0);

	private d()
	{
	}
}
