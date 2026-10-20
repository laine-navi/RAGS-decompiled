using System;
using System.Runtime.CompilerServices;

namespace Rags;

public class StyleFormat : IComparable
{
	[CompilerGenerated]
	private string a;

	[CompilerGenerated]
	private string b;

	[CompilerGenerated]
	private int c;

	[CompilerGenerated]
	private string d;

	[CompilerGenerated]
	private double e;

	public string style
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

	public string text
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

	public int theindex
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

	public string FontName
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

	public double FontSize
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

	public StyleFormat(int tempindex, string txt, string sty)
	{
		text = string.Empty;
		theindex = 0;
		FontName = string.Empty;
		FontSize = 0.0;
		theindex = tempindex;
		for (int num = txt.IndexOf("["); num > -1; num = txt.IndexOf("["))
		{
			int num2 = txt.IndexOf("]", num);
			if (num2 <= -1)
			{
				break;
			}
			txt = txt.Remove(num, num2 - num + 1);
		}
		txt = txt.Replace("\r\n", "\n");
		text = txt;
		style = sty;
	}

	public StyleFormat(int tempindex, string txt, string fname, double fsize)
	{
		text = string.Empty;
		theindex = 0;
		FontName = string.Empty;
		FontSize = 0.0;
		theindex = tempindex;
		for (int num = txt.IndexOf("["); num > -1; num = txt.IndexOf("["))
		{
			int num2 = txt.IndexOf("]", num);
			if (num2 <= -1)
			{
				break;
			}
			txt = txt.Remove(num, num2 - num + 1);
		}
		txt = txt.Replace("\r\n", "\n");
		text = txt;
		FontName = fname;
		FontSize = fsize;
	}

	public int CompareTo(object obj)
	{
		if (obj is StyleFormat)
		{
			StyleFormat styleFormat = (StyleFormat)obj;
			return theindex.CompareTo(styleFormat.theindex);
		}
		throw new ArgumentException("object is not a StyleFormat");
	}
}
