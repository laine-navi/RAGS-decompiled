using System;

namespace Rags;

public class TextHandlers
{
	public static string AddTextToRTF(ref Game TheGame, string text)
	{
		if (TheGame != null)
		{
			string text2 = string.Empty;
			while (!text2.Equals(text))
			{
				text2 = text;
				text = TheGame.PerformTextReplacements(text, null);
			}
		}
		text = text.Replace("\r\n", "<br/>");
		return text;
	}

	private static string f(string A_0)
	{
		for (int num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num2 - num + 1);
			num2 = A_0.IndexOf("[/f]", num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				A_0 = A_0.Remove(num2, 4);
			}
		}
		for (int num = A_0.IndexOf("[B]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[B]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/B]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/B]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 8);
		}
		for (int num = A_0.IndexOf("[/Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 9);
		}
		for (int num = A_0.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		return A_0;
	}

	private static string e(string A_0)
	{
		for (int num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num2 - num + 1);
			num2 = A_0.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				A_0 = A_0.Remove(num2, 4);
			}
		}
		for (int num = A_0.IndexOf("[B]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[B]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/B]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/B]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 8);
		}
		for (int num = A_0.IndexOf("[/Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 9);
		}
		for (int num = A_0.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		return A_0;
	}

	private static string d(string A_0)
	{
		for (int num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num2 - num + 1);
			num2 = A_0.IndexOf("[/f]", num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				A_0 = A_0.Remove(num2, 4);
			}
		}
		for (int num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num3 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num3 - num + 1);
			num3 = A_0.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
			if (num3 >= 0)
			{
				A_0 = A_0.Remove(num3, 4);
			}
		}
		for (int num = A_0.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 8);
		}
		for (int num = A_0.IndexOf("[/Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 9);
		}
		for (int num = A_0.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		return A_0;
	}

	private static string c(string A_0)
	{
		for (int num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num2 - num + 1);
			num2 = A_0.IndexOf("[/f]", num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				A_0 = A_0.Remove(num2, 4);
			}
		}
		for (int num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num3 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num3 - num + 1);
			num3 = A_0.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
			if (num3 >= 0)
			{
				A_0 = A_0.Remove(num3, 4);
			}
		}
		for (int num = A_0.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 8);
		}
		for (int num = A_0.IndexOf("[/Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 9);
		}
		for (int num = A_0.IndexOf("[b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[b]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/b]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		return A_0;
	}

	private static string b(string A_0)
	{
		for (int num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num2 - num + 1);
			num2 = A_0.IndexOf("[/f]", num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				A_0 = A_0.Remove(num2, 4);
			}
		}
		for (int num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num3 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num3 - num + 1);
			num3 = A_0.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
			if (num3 >= 0)
			{
				A_0 = A_0.Remove(num3, 4);
			}
		}
		for (int num = A_0.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[b]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/b]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/u]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		return A_0;
	}

	private static string a(string A_0)
	{
		for (int num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num2 - num + 1);
			num2 = A_0.IndexOf("[/f]", num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				A_0 = A_0.Remove(num2, 4);
			}
		}
		for (int num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = A_0.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num3 = A_0.IndexOf("]", num);
			A_0 = A_0.Remove(num, num3 - num + 1);
			num3 = A_0.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
			if (num3 >= 0)
			{
				A_0 = A_0.Remove(num3, 4);
			}
		}
		for (int num = A_0.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 8);
		}
		for (int num = A_0.IndexOf("[/Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 9);
		}
		for (int num = A_0.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/i]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		for (int num = A_0.IndexOf("[b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[b]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 3);
		}
		for (int num = A_0.IndexOf("[/b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = A_0.IndexOf("[/b]", num, StringComparison.OrdinalIgnoreCase))
		{
			A_0 = A_0.Remove(num, 4);
		}
		return A_0;
	}

	public static string TextOnly(string temptext)
	{
		for (int num = temptext.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = temptext.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = temptext.IndexOf("]", num);
			temptext = temptext.Remove(num, num2 - num + 1);
			num2 = temptext.IndexOf("[/f]", num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				temptext = temptext.Remove(num2, 4);
			}
		}
		for (int num = temptext.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = temptext.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
		{
			int num3 = temptext.IndexOf("]", num);
			temptext = temptext.Remove(num, num3 - num + 1);
			num3 = temptext.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
			if (num3 >= 0)
			{
				temptext = temptext.Remove(num3, 4);
			}
		}
		for (int num = temptext.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 8);
		}
		for (int num = temptext.IndexOf("[/Middle]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[/Middle]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 9);
		}
		for (int num = temptext.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[i]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 3);
		}
		for (int num = temptext.IndexOf("[/i]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[/i]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 4);
		}
		for (int num = temptext.IndexOf("[b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[b]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 3);
		}
		for (int num = temptext.IndexOf("[/b]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[/b]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 4);
		}
		for (int num = temptext.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[u]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 3);
		}
		for (int num = temptext.IndexOf("[/u]", 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf("[/u]", num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 4);
		}
		return temptext;
	}

	public static string insertVariableToolStripMenuItem(Game TheGame)
	{
		return string.Empty;
	}
}
