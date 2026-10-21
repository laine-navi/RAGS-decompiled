using System.Drawing;
using A;

namespace Rags;

public sealed class ColorFormat
{
	public int start;

	public int length;

	public int beginningindex;

	public Color colorval = Color.Black;

	public string text = string.Empty;

	public ColorFormat(int x, int y, Color clr)
	{
		start = x;
		length = y;
		colorval = clr;
	}

	public ColorFormat(string txt, Color clr, int startindex)
	{
		beginningindex = startindex;
		for (int num = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926)); num > -1; num = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1926)))
		{
			__ldtoken(ColorFormat._002Ector(string, Color, int));
			int num2 = txt.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			if (num2 <= -1)
			{
				__ldtoken(ColorFormat._002Ector(string, Color, int));
				break;
			}
			txt = txt.Remove(num, num2 - num + 1);
			if (num != 0)
			{
				__ldtoken(ColorFormat._002Ector(string, Color, int));
			}
			else if (beginningindex > num2 - num + 1)
			{
				beginningindex -= num2 - num + 1;
			}
		}
		text = txt;
		colorval = clr;
	}
}
