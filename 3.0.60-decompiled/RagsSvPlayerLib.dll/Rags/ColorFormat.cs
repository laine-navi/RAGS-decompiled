using System.Runtime.CompilerServices;

namespace Rags;

public class ColorFormat
{
	[CompilerGenerated]
	private int a;

	[CompilerGenerated]
	private int b;

	[CompilerGenerated]
	private int c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private string e;

	public int start
	{
		[CompilerGenerated]
		get
		{
			return a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	public int length
	{
		[CompilerGenerated]
		get
		{
			return b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	public int beginningindex
	{
		[CompilerGenerated]
		get
		{
			return c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	public string colorval
	{
		[CompilerGenerated]
		get
		{
			return d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	public string text
	{
		[CompilerGenerated]
		get
		{
			return e;
		}
		[CompilerGenerated]
		set
		{
			e = value;
		}
	}

	public ColorFormat(int x, int y, string clr)
	{
		beginningindex = 0;
		text = string.Empty;
		start = x;
		length = y;
		colorval = clr;
	}

	public ColorFormat(string txt, string clr, int startindex)
	{
		beginningindex = startindex;
		for (int num = txt.IndexOf("["); num > -1; num = txt.IndexOf("["))
		{
			int num2 = txt.IndexOf("]", num);
			if (num2 <= -1)
			{
				break;
			}
			txt = txt.Remove(num, num2 - num + 1);
			if (num == 0 && beginningindex > num2 - num + 1)
			{
				beginningindex -= num2 - num + 1;
			}
		}
		text = txt;
		colorval = clr;
	}
}
