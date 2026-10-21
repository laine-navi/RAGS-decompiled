using System.Drawing;

namespace Rags;

public class ColorFormat
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
