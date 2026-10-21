using System;
using System.Drawing;
using A;

namespace Rags;

public sealed class StyleFormat : IComparable
{
	public FontStyle style;

	public string text = string.Empty;

	public int theindex;

	public string FontName = string.Empty;

	public double FontSize;

	public StyleFormat(int tempindex, string txt, FontStyle sty)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		theindex = tempindex;
		for (int num = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926)); num > -1; num = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926)))
		{
			__ldtoken(StyleFormat._002Ector(int, string, FontStyle));
			int num2 = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			if (num2 <= -1)
			{
				break;
			}
			txt = txt.Remove(num, num2 - num + 1);
		}
		txt = txt.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292));
		text = txt;
		style = sty;
	}

	public StyleFormat(int tempindex, string txt, string fname, double fsize)
	{
		theindex = tempindex;
		for (int num = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926)); num > -1; num = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926)))
		{
			__ldtoken(StyleFormat._002Ector(int, string, string, double));
			int num2 = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			if (num2 <= -1)
			{
				__ldtoken(StyleFormat._002Ector(int, string, string, double));
				break;
			}
			txt = txt.Remove(num, num2 - num + 1);
		}
		txt = txt.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292));
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
		throw new ArgumentException(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(23614));
	}
}
