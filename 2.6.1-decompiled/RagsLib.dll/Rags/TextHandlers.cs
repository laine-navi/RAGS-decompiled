using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;

namespace Rags;

public class TextHandlers
{
	public static Rectangle ScaleToFit(Rectangle targetArea, Image img)
	{
		Rectangle result = new Rectangle(targetArea.Location, targetArea.Size);
		if (result.Height * img.Width > result.Width * img.Height)
		{
			result.Height = result.Width * img.Height / img.Width;
			result.Y += (targetArea.Height - result.Height) / 2;
		}
		else
		{
			result.Width = result.Height * img.Width / img.Height;
			result.X += (targetArea.Width - result.Width) / 2;
		}
		return result;
	}

	public static string Compress(string text)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		MemoryStream memoryStream = new MemoryStream();
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
		{
			gZipStream.Write(bytes, 0, bytes.Length);
		}
		memoryStream.Position = 0L;
		new MemoryStream();
		byte[] array = new byte[memoryStream.Length];
		memoryStream.Read(array, 0, array.Length);
		byte[] array2 = new byte[array.Length + 4];
		Buffer.BlockCopy(array, 0, array2, 4, array.Length);
		Buffer.BlockCopy(BitConverter.GetBytes(bytes.Length), 0, array2, 0, 4);
		return Convert.ToBase64String(array2);
	}

	public static string Decompress(string compressedText)
	{
		try
		{
			byte[] array = Convert.FromBase64String(compressedText);
			using MemoryStream memoryStream = new MemoryStream();
			int num = BitConverter.ToInt32(array, 0);
			memoryStream.Write(array, 4, array.Length - 4);
			byte[] array2 = new byte[num];
			memoryStream.Position = 0L;
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
			{
				gZipStream.Read(array2, 0, array2.Length);
			}
			return Encoding.UTF8.GetString(array2);
		}
		catch (Exception)
		{
			return compressedText;
		}
	}

	public static void AddTextToRTF(ref RichTextBox rtcontrol, ref Game TheGame, string text, Color clr, FontStyle fontst)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected Obj, but got Unknown
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		int length = ((Control)rtcontrol).Text.Length;
		text = text.Replace("\r\n", "\n");
		if (TheGame != null)
		{
			string text2 = string.Empty;
			while (!text2.Equals(text))
			{
				text2 = text;
				text = TheGame.PerformTextReplacements(text, null);
			}
		}
		text = text.Replace("\r\n", "\n");
		string text3 = text;
		if ((int)fontst == 0 && clr == Color.Black)
		{
			ArrayList arrayList = new ArrayList();
			text = f(text);
			for (int num = text.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf("[c", 0, StringComparison.OrdinalIgnoreCase))
			{
				int num2 = text.IndexOf("]", num);
				num += 2;
				string text4 = text.Substring(num, num2 - num).Trim();
				Color color = default;
				if (text4.IndexOf(",") > -1)
				{
					int result = 0;
					string s = text4.Substring(0, text4.IndexOf(","));
					text4 = text4.Remove(0, text4.IndexOf(",") + 1).Trim();
					int.TryParse(s, out var result2);
					string s2 = text4.Substring(0, text4.IndexOf(","));
					text4 = text4.Remove(0, text4.IndexOf(",") + 1).Trim();
					int.TryParse(s2, out var result3);
					int.TryParse(text4, out result);
					color = Color.FromArgb(result2, result3, result);
				}
				else
				{
					color = Color.FromName(text4);
				}
				num -= 2;
				text = text.Remove(num, num2 - num + 1);
				num2 = text.IndexOf("[/c]", num, StringComparison.OrdinalIgnoreCase);
				if (num2 >= 0)
				{
					text = text.Remove(num2, 4);
					arrayList.Add(new ColorFormat(text.Substring(num, num2 - num), color, num));
				}
			}
			ArrayList arrayList2 = new ArrayList();
			text = e(text3);
			for (int num = text.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf("[f", 0, StringComparison.OrdinalIgnoreCase))
			{
				int num3 = text.IndexOf("]", num);
				num += 2;
				string[] array = text.Substring(num, num3 - num).Trim().Split(new string[1] { "," }, StringSplitOptions.None);
				num -= 2;
				text = text.Remove(num, num3 - num + 1);
				num3 = text.IndexOf("[/f]", num, StringComparison.OrdinalIgnoreCase);
				if (num3 >= 0)
				{
					text = text.Remove(num3, 4);
					if (array.Length > 1)
					{
						double num4 = 0.0;
						try
						{
							num4 = Convert.ToDouble(array[1]);
						}
						catch
						{
							num4 = 0.0;
						}
						if (num4 != 0.0)
						{
							arrayList2.Add(new StyleFormat(num, text.Substring(num, num3 - num), array[0], Convert.ToDouble(array[1])));
						}
					}
				}
			}
			text = d(text3);
			for (int num = text.IndexOf("[b]", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf("[b]", 0, StringComparison.OrdinalIgnoreCase))
			{
				text = text.Remove(num, 3);
				int num5 = text.IndexOf("[/b]", num, StringComparison.OrdinalIgnoreCase);
				if (num5 >= 0)
				{
					text = text.Remove(num5, 4);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num5 - num), (FontStyle)1));
				}
			}
			text = c(text3);
			for (int num = text.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf("[i]", 0, StringComparison.OrdinalIgnoreCase))
			{
				text = text.Remove(num, 3);
				int num6 = text.IndexOf("[/i]", num, StringComparison.OrdinalIgnoreCase);
				if (num6 >= 0)
				{
					text = text.Remove(num6, 4);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num6 - num), (FontStyle)2));
				}
			}
			text = a(text3);
			for (int num = text.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf("[u]", 0, StringComparison.OrdinalIgnoreCase))
			{
				text = text.Remove(num, 3);
				int num7 = text.IndexOf("[/u]", num, StringComparison.OrdinalIgnoreCase);
				if (num7 >= 0)
				{
					text = text.Remove(num7, 4);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num7 - num), (FontStyle)4));
				}
			}
			text = b(text3);
			for (int num = text.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf("[Middle]", 0, StringComparison.OrdinalIgnoreCase))
			{
				text = text.Remove(num, 8);
				int num8 = text.IndexOf("[/Middle]", num, StringComparison.OrdinalIgnoreCase);
				if (num8 >= 0)
				{
					text = text.Remove(num8, 9);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num8 - num), (FontStyle)8));
				}
			}
			((TextBoxBase)rtcontrol).AppendText(TextOnly(text3));
			foreach (ColorFormat item in arrayList)
			{
				a(ref rtcontrol, length, item.text, item.colorval, length + item.beginningindex);
			}
			arrayList2.Sort();
			foreach (StyleFormat item2 in arrayList2)
			{
				a(ref rtcontrol, length, item2.text, item2.style, length + item2.theindex, item2.FontName, item2.FontSize);
			}
		}
		else
		{
			((TextBoxBase)rtcontrol).AppendText(text);
			((TextBoxBase)rtcontrol).Select(length, text.Length);
			rtcontrol.SelectionColor = clr;
			RichTextBox obj2 = rtcontrol;
			obj2.SelectionFont = new Font(((Control)obj2).Font, fontst);
		}
		RichTextBox obj3 = rtcontrol;
		((TextBoxBase)obj3).Select(((Control)obj3).Text.Length, 0);
		((TextBoxBase)rtcontrol).ScrollToCaret();
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

	private static void a(ref RichTextBox A_0, int A_1, string A_2, Color A_3, int A_4)
	{
		((TextBoxBase)A_0).Select(A_4, A_2.Length);
		A_0.SelectionColor = A_3;
	}

	private static void a(ref RichTextBox A_0, int A_1, string A_2, FontStyle A_3, int A_4, string A_5, double A_6)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected Obj, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		if (A_0 == null)
		{
			return;
		}
		((TextBoxBase)A_0).Select(A_4, A_2.Length);
		if ((int)A_3 == 8)
		{
			A_0.SelectionAlignment = (HorizontalAlignment)2;
			return;
		}
		if (A_5 != string.Empty && A_6 > 0.0)
		{
			try
			{
				A_0.SelectionFont = new Font(A_5, (float)A_6, A_0.SelectionFont.Style);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
		}
		if (A_5 == string.Empty && A_6 > 0.0)
		{
			RichTextBox obj = A_0;
			obj.SelectionFont = new Font(obj.SelectionFont.Name, (float)A_6, A_0.SelectionFont.Style);
		}
		else if (A_0.SelectionFont != null)
		{
			RichTextBox obj2 = A_0;
			obj2.SelectionFont = new Font(obj2.SelectionFont, (FontStyle)(A_0.SelectionFont.Style ^ A_3));
		}
	}

	public static string insertVariableToolStripMenuItem(Game TheGame)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		string result = string.Empty;
		InsertVariableFrm tempfrm = new InsertVariableFrm(ref TheGame);
		PopulateVariableMenu(ref tempfrm, ref TheGame);
		if ((int)((Form)tempfrm).ShowDialog() == 1)
		{
			switch (tempfrm.tabControl1.SelectedIndex)
			{
			case 0:
				if (tempfrm.lbSysVariables.SelectedItem != null)
				{
					result = tempfrm.lbSysVariables.SelectedItem.ToString();
				}
				break;
			case 1:
				if (tempfrm.lbVariables.SelectedItem != null)
				{
					result = tempfrm.lbVariables.SelectedItem.ToString();
				}
				break;
			case 2:
				if (tempfrm.lbCustProp.SelectedItem != null)
				{
					result = tempfrm.lbCustProp.SelectedItem.ToString();
				}
				break;
			case 3:
				result = ((Control)tempfrm.tbText).Text;
				break;
			}
		}
		return result;
	}

	public static void PopulateVariableMenu(ref InsertVariableFrm tempfrm, ref Game TheGame)
	{
		tempfrm.lbSysVariables.Items.Clear();
		tempfrm.lbVariables.Items.Clear();
		tempfrm.lbCustProp.Items.Clear();
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[playername]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[inputdata]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[maxcarry]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[currentcarry]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[turns]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[man/woman]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[male/female]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[boy/girl]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[len(<variablename>)]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[a/an]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[char.name]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[item.name]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[item.id]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[room.name]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[room.id]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.active]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.direction]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.destname]");
		tempfrm.lbSysVariables.Items.Insert(0, (object)"[exit.destid]");
		List<string> list = new List<string>();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			GameVariable gameVariable = (GameVariable)TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				for (int j = 0; j < gameVariable.VarArray.Count; j++)
				{
					if (gameVariable.VarArray[j] is ArrayList)
					{
						list.Add("[v: " + gameVariable.varname + "(" + j + ")(0.." + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + ")]");
					}
					else
					{
						list.Add("[v: " + gameVariable.varname + "(" + j + ")]");
					}
				}
			}
			else
			{
				list.Add("[v: " + gameVariable.varname + "]");
			}
		}
		list.Sort();
		foreach (string item in list)
		{
			tempfrm.lbVariables.Items.Add((object)item);
		}
		list.Clear();
		for (int k = 0; k < TheGame.VariableList.Count; k++)
		{
			GameVariable gameVariable2 = (GameVariable)TheGame.VariableList[k];
			if (gameVariable2.vartype == GameVariable.VarType.VT_DATETIMEARRAY || gameVariable2.vartype == GameVariable.VarType.VT_NUMBERARRAY || gameVariable2.vartype == GameVariable.VarType.VT_STRINGARRAY)
			{
				list.Add("[jsa: " + gameVariable2.varname + "]");
			}
		}
		list.Sort();
		foreach (string item2 in list)
		{
			tempfrm.lbVariables.Items.Add((object)item2);
		}
		list.Clear();
		foreach (Room room in TheGame.RoomList)
		{
			if (room.CustomProperties.Count <= 0)
			{
				continue;
			}
			int num = 0;
			foreach (Room room2 in TheGame.RoomList)
			{
				if (room2.Name == room.Name)
				{
					num++;
				}
			}
			if (num > 1)
			{
				foreach (CustomProperty customProperty9 in room.CustomProperties)
				{
					list.Add("[rp: " + room.UniqueID.ToString() + "(" + room.Name + "):" + customProperty9.Name + "]");
				}
				continue;
			}
			foreach (CustomProperty customProperty10 in room.CustomProperties)
			{
				list.Add("[rp: " + room.Name + ":" + customProperty10.Name + "]");
			}
		}
		list.Sort();
		foreach (string item3 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item3);
		}
		list.Clear();
		foreach (CustomProperty customProperty11 in TheGame.ThePlayer.CustomProperties)
		{
			list.Add("[pp: " + customProperty11.Name + "]");
		}
		list.Sort();
		foreach (string item4 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item4);
		}
		list.Clear();
		foreach (GameObject @object in TheGame.ObjectList)
		{
			if (@object.CustomProperties.Count <= 0)
			{
				continue;
			}
			int num2 = 0;
			foreach (GameObject object2 in TheGame.ObjectList)
			{
				if (object2.name == @object.name)
				{
					num2++;
				}
			}
			if (num2 > 1)
			{
				foreach (CustomProperty customProperty12 in @object.CustomProperties)
				{
					list.Add("[ip: " + @object.UniqueIdentifier.ToString() + "(" + @object.name + ") : " + customProperty12.Name + "]");
				}
				continue;
			}
			foreach (CustomProperty customProperty13 in @object.CustomProperties)
			{
				list.Add("[ip: " + @object.name + " : " + customProperty13.Name + "]");
			}
		}
		list.Sort();
		foreach (string item5 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item5);
		}
		list.Clear();
		foreach (Character character in TheGame.CharacterList)
		{
			if (character.CustomProperties.Count <= 0)
			{
				continue;
			}
			foreach (CustomProperty customProperty14 in character.CustomProperties)
			{
				list.Add("[cp: " + character.Charname + " : " + customProperty14.Name + "]");
			}
		}
		list.Sort();
		foreach (string item6 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item6);
		}
		list.Clear();
		foreach (GameVariable variable in TheGame.VariableList)
		{
			if (variable.CustomProperties.Count <= 0)
			{
				continue;
			}
			foreach (CustomProperty customProperty15 in variable.CustomProperties)
			{
				list.Add("[vp: " + variable.varname + " : " + customProperty15.Name + "]");
			}
		}
		list.Sort();
		foreach (string item7 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item7);
		}
		list.Clear();
		foreach (Timer timer in TheGame.TimerList)
		{
			if (timer.CustomProperties.Count <= 0)
			{
				continue;
			}
			foreach (CustomProperty customProperty16 in timer.CustomProperties)
			{
				list.Add("[tp: " + timer.Name + " : " + customProperty16.Name + "]");
			}
		}
		list.Sort();
		foreach (string item8 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item8);
		}
		list.Clear();
	}
}
