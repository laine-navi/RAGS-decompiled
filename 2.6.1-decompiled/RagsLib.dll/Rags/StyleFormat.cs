using System;
using System.Drawing;

namespace Rags;

public class StyleFormat : IComparable
{
	public FontStyle style;

	public string text = string.Empty;

	public int theindex;

	public string FontName = string.Empty;

	public double FontSize;

	public StyleFormat(int tempindex, string txt, FontStyle sty)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
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
