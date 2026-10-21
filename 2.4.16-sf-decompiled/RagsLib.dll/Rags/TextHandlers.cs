using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using A;

namespace Rags;

public sealed class TextHandlers
{
	public static Rectangle ScaleToFit(Rectangle targetArea, Image img)
	{
		Rectangle result = new Rectangle(targetArea.Location, targetArea.Size);
		if (result.Height * img.Width <= result.Width * img.Height)
		{
			__ldtoken(TextHandlers.ScaleToFit(Rectangle, Image));
			result.Width = result.Height * img.Width / img.Height;
			result.X += (targetArea.Width - result.Width) / 2;
		}
		else
		{
			result.Height = result.Width * img.Height / img.Width;
			result.Y += (targetArea.Height - result.Height) / 2;
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
			MemoryStream memoryStream = new MemoryStream();
			try
			{
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
			finally
			{
				if (memoryStream == null)
				{
					__ldtoken(TextHandlers.Decompress(string));
				}
				else
				{
					((IDisposable)memoryStream).Dispose();
				}
			}
		}
		catch (Exception)
		{
			return compressedText;
		}
	}

	public static void AddTextToRTF(ref RichTextBox rtcontrol, ref Game TheGame, string text, Color clr, FontStyle fontst)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected Obj, but got Unknown
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		int length = ((Control)rtcontrol).Text.Length;
		text = text.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292));
		if (TheGame == null)
		{
			__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
		}
		else
		{
			string text2 = string.Empty;
			while (!text2.Equals(text))
			{
				__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				text2 = text;
				text = TheGame.PerformTextReplacements(text, null);
			}
		}
		text = text.Replace(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22287), cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22292));
		string text3 = text;
		if ((int)fontst != 0)
		{
			__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
		}
		else if (clr == Color.Black)
		{
			ArrayList arrayList = new ArrayList();
			text = cf373e6999114481748132f4c271bcc51(text);
			for (int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase))
			{
				int num2 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
				num += 2;
				string text4 = text.Substring(num, num2 - num).Trim();
				Color color = default;
				if (text4.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243)) > -1)
				{
					int result = 0;
					string s = text4.Substring(0, text4.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243)));
					text4 = text4.Remove(0, text4.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243)) + 1).Trim();
					int.TryParse(s, out var result2);
					s = text4.Substring(0, text4.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243)));
					text4 = text4.Remove(0, text4.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243)) + 1).Trim();
					int.TryParse(s, out var result3);
					s = text4;
					int.TryParse(s, out result);
					color = Color.FromArgb(result2, result3, result);
				}
				else
				{
					color = Color.FromName(text4);
				}
				num -= 2;
				text = text.Remove(num, num2 - num + 1);
				num2 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300), num, StringComparison.OrdinalIgnoreCase);
				if (num2 < 0)
				{
					__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				}
				else
				{
					text = text.Remove(num2, 4);
					arrayList.Add(new ColorFormat(text.Substring(num, num2 - num), color, num));
				}
			}
			ArrayList arrayList2 = new ArrayList();
			text = cbdf8bd9dddac83e148cd0d58a0b6acdf(text3);
			for (int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase))
			{
				int num3 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
				num += 2;
				string text5 = text.Substring(num, num3 - num).Trim();
				string[] array = text5.Split(new string[1] { cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22243) }, StringSplitOptions.None);
				num -= 2;
				text = text.Remove(num, num3 - num + 1);
				num3 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314), num, StringComparison.OrdinalIgnoreCase);
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
						if (num4 == 0.0)
						{
							__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
						}
						else
						{
							arrayList2.Add(new StyleFormat(num, text.Substring(num, num3 - num), array[0], Convert.ToDouble(array[1])));
						}
					}
				}
			}
			text = c79125ec39109934ec7f629eb10d4ad24(text3);
			for (int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), 0, StringComparison.OrdinalIgnoreCase))
			{
				text = text.Remove(num, 3);
				int num5 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), num, StringComparison.OrdinalIgnoreCase);
				if (num5 < 0)
				{
					__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				}
				else
				{
					text = text.Remove(num5, 4);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num5 - num), (FontStyle)1));
				}
			}
			text = c8b67d98d9bbc13750dec9c422400cb5d(text3);
			for (int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase))
			{
				__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				text = text.Remove(num, 3);
				int num6 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), num, StringComparison.OrdinalIgnoreCase);
				if (num6 < 0)
				{
					__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				}
				else
				{
					text = text.Remove(num6, 4);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num6 - num), (FontStyle)2));
				}
			}
			text = c163f1dc4e486011c060a95945359a0ff(text3);
			for (int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase))
			{
				__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				text = text.Remove(num, 3);
				int num7 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), num, StringComparison.OrdinalIgnoreCase);
				if (num7 < 0)
				{
					__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				}
				else
				{
					text = text.Remove(num7, 4);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num7 - num), (FontStyle)4));
				}
			}
			text = c1c85f6831c352a7a288358b756d09914(text3);
			for (int num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase))
			{
				__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				text = text.Remove(num, 8);
				int num8 = text.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), num, StringComparison.OrdinalIgnoreCase);
				if (num8 < 0)
				{
					__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
				}
				else
				{
					text = text.Remove(num8, 9);
					arrayList2.Add(new StyleFormat(num, text.Substring(num, num8 - num), (FontStyle)8));
				}
			}
			((TextBoxBase)rtcontrol).AppendText(TextOnly(text3));
			{
				IEnumerator enumerator = arrayList.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						__ldtoken(TextHandlers.AddTextToRTF(ref RichTextBox, ref Game, string, Color, FontStyle));
						ColorFormat colorFormat = (ColorFormat)enumerator.Current;
						c23c65a0e66d6a92f304efa376923123c(ref rtcontrol, length, colorFormat.text, colorFormat.colorval, length + colorFormat.beginningindex);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			arrayList2.Sort();
			foreach (StyleFormat item in arrayList2)
			{
				c75e54ceb8b8b336bb8fb4856a42f24da(ref rtcontrol, length, item.text, item.style, length + item.theindex, item.FontName, item.FontSize);
			}
			goto IL_07d8;
		}
		((TextBoxBase)rtcontrol).AppendText(text);
		((TextBoxBase)rtcontrol).Select(length, text.Length);
		rtcontrol.SelectionColor = clr;
		rtcontrol.SelectionFont = new Font(((Control)rtcontrol).Font, fontst);
		goto IL_07d8;
		IL_07d8:
		((TextBoxBase)rtcontrol).Select(((Control)rtcontrol).Text.Length, 0);
		((TextBoxBase)rtcontrol).ScrollToCaret();
	}

	private static string cf373e6999114481748132f4c271bcc51(string P_0)
	{
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num2 - num + 1);
			num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314), num, StringComparison.OrdinalIgnoreCase);
			if (num2 < 0)
			{
				__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			}
			else
			{
				P_0 = P_0.Remove(num2, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22407), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22407), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22414), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22414), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 8);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 9);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cf373e6999114481748132f4c271bcc51(string));
			P_0 = P_0.Remove(num, 4);
		}
		return P_0;
	}

	private static string cbdf8bd9dddac83e148cd0d58a0b6acdf(string P_0)
	{
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num2 - num + 1);
			num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300), num, StringComparison.OrdinalIgnoreCase);
			if (num2 < 0)
			{
				__ldtoken(TextHandlers.cbdf8bd9dddac83e148cd0d58a0b6acdf(string));
			}
			else
			{
				P_0 = P_0.Remove(num2, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22407), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22407), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cbdf8bd9dddac83e148cd0d58a0b6acdf(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22414), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22414), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cbdf8bd9dddac83e148cd0d58a0b6acdf(string));
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 8);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 9);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cbdf8bd9dddac83e148cd0d58a0b6acdf(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cbdf8bd9dddac83e148cd0d58a0b6acdf(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.cbdf8bd9dddac83e148cd0d58a0b6acdf(string));
			P_0 = P_0.Remove(num, 4);
		}
		return P_0;
	}

	private static string c79125ec39109934ec7f629eb10d4ad24(string P_0)
	{
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num2 - num + 1);
			num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314), num, StringComparison.OrdinalIgnoreCase);
			if (num2 < 0)
			{
				__ldtoken(TextHandlers.c79125ec39109934ec7f629eb10d4ad24(string));
			}
			else
			{
				P_0 = P_0.Remove(num2, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase))
		{
			int num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num3 - num + 1);
			num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300), num, StringComparison.OrdinalIgnoreCase);
			if (num3 >= 0)
			{
				P_0 = P_0.Remove(num3, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c79125ec39109934ec7f629eb10d4ad24(string));
			P_0 = P_0.Remove(num, 8);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 9);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c79125ec39109934ec7f629eb10d4ad24(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c79125ec39109934ec7f629eb10d4ad24(string));
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c79125ec39109934ec7f629eb10d4ad24(string));
			P_0 = P_0.Remove(num, 4);
		}
		return P_0;
	}

	private static string c8b67d98d9bbc13750dec9c422400cb5d(string P_0)
	{
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num2 - num + 1);
			num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314), num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				P_0 = P_0.Remove(num2, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			int num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num3 - num + 1);
			num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300), num, StringComparison.OrdinalIgnoreCase);
			if (num3 < 0)
			{
				__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			}
			else
			{
				P_0 = P_0.Remove(num3, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			P_0 = P_0.Remove(num, 8);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			P_0 = P_0.Remove(num, 9);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c8b67d98d9bbc13750dec9c422400cb5d(string));
			P_0 = P_0.Remove(num, 4);
		}
		return P_0;
	}

	private static string c1c85f6831c352a7a288358b756d09914(string P_0)
	{
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase))
		{
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num2 - num + 1);
			num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314), num, StringComparison.OrdinalIgnoreCase);
			if (num2 >= 0)
			{
				P_0 = P_0.Remove(num2, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase))
		{
			int num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num3 - num + 1);
			num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300), num, StringComparison.OrdinalIgnoreCase);
			if (num3 < 0)
			{
				__ldtoken(TextHandlers.c1c85f6831c352a7a288358b756d09914(string));
			}
			else
			{
				P_0 = P_0.Remove(num3, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c1c85f6831c352a7a288358b756d09914(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c1c85f6831c352a7a288358b756d09914(string));
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c1c85f6831c352a7a288358b756d09914(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c1c85f6831c352a7a288358b756d09914(string));
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c1c85f6831c352a7a288358b756d09914(string));
			P_0 = P_0.Remove(num, 4);
		}
		return P_0;
	}

	private static string c163f1dc4e486011c060a95945359a0ff(string P_0)
	{
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c163f1dc4e486011c060a95945359a0ff(string));
			int num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num2 - num + 1);
			num2 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314), num, StringComparison.OrdinalIgnoreCase);
			if (num2 < 0)
			{
				__ldtoken(TextHandlers.c163f1dc4e486011c060a95945359a0ff(string));
			}
			else
			{
				P_0 = P_0.Remove(num2, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c163f1dc4e486011c060a95945359a0ff(string));
			int num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			P_0 = P_0.Remove(num, num3 - num + 1);
			num3 = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300), num, StringComparison.OrdinalIgnoreCase);
			if (num3 < 0)
			{
				__ldtoken(TextHandlers.c163f1dc4e486011c060a95945359a0ff(string));
			}
			else
			{
				P_0 = P_0.Remove(num3, 4);
			}
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 8);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 9);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c163f1dc4e486011c060a95945359a0ff(string));
			P_0 = P_0.Remove(num, 4);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), num, StringComparison.OrdinalIgnoreCase))
		{
			P_0 = P_0.Remove(num, 3);
		}
		for (int num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = P_0.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.c163f1dc4e486011c060a95945359a0ff(string));
			P_0 = P_0.Remove(num, 4);
		}
		return P_0;
	}

	public static string TextOnly(string temptext)
	{
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22309), 0, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.TextOnly(string));
			int num2 = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			temptext = temptext.Remove(num, num2 - num + 1);
			num2 = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22314), num, StringComparison.OrdinalIgnoreCase);
			if (num2 < 0)
			{
				__ldtoken(TextHandlers.TextOnly(string));
			}
			else
			{
				temptext = temptext.Remove(num2, 4);
			}
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase); num >= 0; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22295), 0, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.TextOnly(string));
			int num3 = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932), num);
			temptext = temptext.Remove(num, num3 - num + 1);
			num3 = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22300), num, StringComparison.OrdinalIgnoreCase);
			if (num3 < 0)
			{
				__ldtoken(TextHandlers.TextOnly(string));
			}
			else
			{
				temptext = temptext.Remove(num3, 4);
			}
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22371), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.TextOnly(string));
			temptext = temptext.Remove(num, 8);
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22388), num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 9);
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22339), num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 3);
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22346), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.TextOnly(string));
			temptext = temptext.Remove(num, 4);
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22323), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.TextOnly(string));
			temptext = temptext.Remove(num, 3);
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22330), num, StringComparison.OrdinalIgnoreCase))
		{
			temptext = temptext.Remove(num, 4);
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22355), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.TextOnly(string));
			temptext = temptext.Remove(num, 3);
		}
		for (int num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), 0, StringComparison.OrdinalIgnoreCase); num > -1; num = temptext.IndexOf(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22362), num, StringComparison.OrdinalIgnoreCase))
		{
			__ldtoken(TextHandlers.TextOnly(string));
			temptext = temptext.Remove(num, 4);
		}
		return temptext;
	}

	private static void c23c65a0e66d6a92f304efa376923123c(ref RichTextBox P_0, int P_1, string P_2, Color P_3, int P_4)
	{
		((TextBoxBase)P_0).Select(P_4, P_2.Length);
		P_0.SelectionColor = P_3;
	}

	private static void c75e54ceb8b8b336bb8fb4856a42f24da(ref RichTextBox P_0, int P_1, string P_2, FontStyle P_3, int P_4, string P_5, double P_6)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected Obj, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected Obj, but got Unknown
		if (P_0 == null)
		{
			return;
		}
		__ldtoken(TextHandlers.c75e54ceb8b8b336bb8fb4856a42f24da(ref RichTextBox, int, string, FontStyle, int, string, double));
		((TextBoxBase)P_0).Select(P_4, P_2.Length);
		if ((int)P_3 != 8)
		{
			__ldtoken(TextHandlers.c75e54ceb8b8b336bb8fb4856a42f24da(ref RichTextBox, int, string, FontStyle, int, string, double));
			if (!(P_5 != string.Empty))
			{
				__ldtoken(TextHandlers.c75e54ceb8b8b336bb8fb4856a42f24da(ref RichTextBox, int, string, FontStyle, int, string, double));
			}
			else
			{
				if (P_6 > 0.0)
				{
					try
					{
						P_0.SelectionFont = new Font(P_5, (float)P_6, P_0.SelectionFont.Style);
						return;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						return;
					}
				}
				__ldtoken(TextHandlers.c75e54ceb8b8b336bb8fb4856a42f24da(ref RichTextBox, int, string, FontStyle, int, string, double));
			}
			if (!(P_5 == string.Empty))
			{
				__ldtoken(TextHandlers.c75e54ceb8b8b336bb8fb4856a42f24da(ref RichTextBox, int, string, FontStyle, int, string, double));
			}
			else
			{
				if (P_6 > 0.0)
				{
					P_0.SelectionFont = new Font(P_0.SelectionFont.Name, (float)P_6, P_0.SelectionFont.Style);
					return;
				}
				__ldtoken(TextHandlers.c75e54ceb8b8b336bb8fb4856a42f24da(ref RichTextBox, int, string, FontStyle, int, string, double));
			}
			if (P_0.SelectionFont != null)
			{
				P_0.SelectionFont = new Font(P_0.SelectionFont, (FontStyle)(P_0.SelectionFont.Style ^ P_3));
			}
		}
		else
		{
			P_0.SelectionAlignment = (HorizontalAlignment)2;
		}
	}

	public static string insertVariableToolStripMenuItem(Game TheGame)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		string result = string.Empty;
		InsertVariableFrm tempfrm = new InsertVariableFrm(ref TheGame);
		PopulateVariableMenu(ref tempfrm, ref TheGame);
		if ((int)((Form)tempfrm).ShowDialog() != 1)
		{
			__ldtoken(TextHandlers.insertVariableToolStripMenuItem(Game));
		}
		else
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
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22423));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22448));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22471));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22492));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22521));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22536));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22559));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22586));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22607));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22650));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22663));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22686));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22709));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22728));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22751));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22770));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22797));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22830));
		tempfrm.lbSysVariables.Items.Insert(0, (object)cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22861));
		List<string> list = new List<string>();
		for (int i = 0; i < TheGame.VariableList.Count; i++)
		{
			__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			GameVariable gameVariable = (GameVariable)TheGame.VariableList[i];
			if (gameVariable.vartype == GameVariable.VarType.VT_DATETIMEARRAY)
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else if (gameVariable.vartype != GameVariable.VarType.VT_NUMBERARRAY && gameVariable.vartype != GameVariable.VarType.VT_STRINGARRAY)
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22888) + gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
				continue;
			}
			for (int j = 0; j < gameVariable.VarArray.Count; j++)
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				if (!(gameVariable.VarArray[j] is ArrayList))
				{
					__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22888) + gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22897));
				}
				else
				{
					list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22888) + gameVariable.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + j + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7846) + (((ArrayList)gameVariable.VarArray[j]).Count - 1) + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22897));
				}
			}
		}
		list.Sort();
		using (List<string>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				string current = enumerator.Current;
				tempfrm.lbVariables.Items.Add((object)current);
			}
		}
		list.Clear();
		for (int k = 0; k < TheGame.VariableList.Count; k++)
		{
			GameVariable gameVariable2 = (GameVariable)TheGame.VariableList[k];
			if (gameVariable2.vartype == GameVariable.VarType.VT_DATETIMEARRAY)
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else if (gameVariable2.vartype == GameVariable.VarType.VT_NUMBERARRAY)
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else if (gameVariable2.vartype != GameVariable.VarType.VT_STRINGARRAY)
			{
				continue;
			}
			list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22902) + gameVariable2.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
		}
		list.Sort();
		using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				string current2 = enumerator2.Current;
				tempfrm.lbVariables.Items.Add((object)current2);
			}
		}
		list.Clear();
		IEnumerator enumerator3 = TheGame.RoomList.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				Room room = (Room)enumerator3.Current;
				if (room.CustomProperties.Count <= 0)
				{
					__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					continue;
				}
				int num = 0;
				foreach (Room room2 in TheGame.RoomList)
				{
					if (!(room2.Name == room.Name))
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					}
					else
					{
						num++;
					}
				}
				if (num <= 1)
				{
					__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					IEnumerator enumerator5 = room.CustomProperties.GetEnumerator();
					try
					{
						while (enumerator5.MoveNext())
						{
							__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
							CustomProperty customProperty = (CustomProperty)enumerator5.Current;
							list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22915) + room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1929) + customProperty.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
						}
					}
					finally
					{
						if (!(enumerator5 is IDisposable disposable))
						{
							__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
						}
						else
						{
							disposable.Dispose();
						}
					}
					continue;
				}
				IEnumerator enumerator6 = room.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator6.MoveNext())
					{
						CustomProperty customProperty2 = (CustomProperty)enumerator6.Current;
						list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22915) + room.UniqueID.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + room.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22926) + customProperty2.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
					}
				}
				finally
				{
					if (!(enumerator6 is IDisposable disposable2))
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					}
					else
					{
						disposable2.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable3))
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else
			{
				disposable3.Dispose();
			}
		}
		list.Sort();
		foreach (string item in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item);
		}
		list.Clear();
		IEnumerator enumerator8 = TheGame.ThePlayer.CustomProperties.GetEnumerator();
		try
		{
			while (enumerator8.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				CustomProperty customProperty3 = (CustomProperty)enumerator8.Current;
				list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22931) + customProperty3.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
			}
		}
		finally
		{
			if (!(enumerator8 is IDisposable disposable4))
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else
			{
				disposable4.Dispose();
			}
		}
		list.Sort();
		using (List<string>.Enumerator enumerator9 = list.GetEnumerator())
		{
			while (enumerator9.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				string current4 = enumerator9.Current;
				tempfrm.lbCustProp.Items.Add((object)current4);
			}
		}
		list.Clear();
		IEnumerator enumerator10 = TheGame.ObjectList.GetEnumerator();
		try
		{
			while (enumerator10.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				GameObject gameObject = (GameObject)enumerator10.Current;
				if (gameObject.CustomProperties.Count <= 0)
				{
					continue;
				}
				int num2 = 0;
				IEnumerator enumerator11 = TheGame.ObjectList.GetEnumerator();
				try
				{
					while (enumerator11.MoveNext())
					{
						GameObject gameObject2 = (GameObject)enumerator11.Current;
						if (!(gameObject2.name == gameObject.name))
						{
							__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
						}
						else
						{
							num2++;
						}
					}
				}
				finally
				{
					if (!(enumerator11 is IDisposable disposable5))
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					}
					else
					{
						disposable5.Dispose();
					}
				}
				if (num2 <= 1)
				{
					__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					IEnumerator enumerator12 = gameObject.CustomProperties.GetEnumerator();
					try
					{
						while (enumerator12.MoveNext())
						{
							__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
							CustomProperty customProperty4 = (CustomProperty)enumerator12.Current;
							list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22942) + gameObject.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22962) + customProperty4.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
						}
					}
					finally
					{
						if (!(enumerator12 is IDisposable disposable6))
						{
							__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
						}
						else
						{
							disposable6.Dispose();
						}
					}
					continue;
				}
				IEnumerator enumerator13 = gameObject.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator13.MoveNext())
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
						CustomProperty customProperty5 = (CustomProperty)enumerator13.Current;
						list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22942) + gameObject.UniqueIdentifier.ToString() + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(7843) + gameObject.name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22953) + customProperty5.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
					}
				}
				finally
				{
					if (!(enumerator13 is IDisposable disposable7))
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					}
					else
					{
						disposable7.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator10 is IDisposable disposable8))
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else
			{
				disposable8.Dispose();
			}
		}
		list.Sort();
		foreach (string item2 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item2);
		}
		list.Clear();
		enumerator3 = TheGame.CharacterList.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				Character character = (Character)enumerator3.Current;
				if (character.CustomProperties.Count <= 0)
				{
					__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					continue;
				}
				IEnumerator enumerator15 = character.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator15.MoveNext())
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
						CustomProperty customProperty6 = (CustomProperty)enumerator15.Current;
						list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22969) + character.Charname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22962) + customProperty6.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
					}
				}
				finally
				{
					if (!(enumerator15 is IDisposable disposable9))
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					}
					else
					{
						disposable9.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable10))
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else
			{
				disposable10.Dispose();
			}
		}
		list.Sort();
		using (List<string>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				string current6 = enumerator.Current;
				tempfrm.lbCustProp.Items.Add((object)current6);
			}
		}
		list.Clear();
		enumerator3 = TheGame.VariableList.GetEnumerator();
		try
		{
			while (enumerator3.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				GameVariable gameVariable3 = (GameVariable)enumerator3.Current;
				if (gameVariable3.CustomProperties.Count <= 0)
				{
					__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					continue;
				}
				IEnumerator enumerator15 = gameVariable3.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator15.MoveNext())
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
						CustomProperty customProperty7 = (CustomProperty)enumerator15.Current;
						list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22980) + gameVariable3.varname + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22962) + customProperty7.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
					}
				}
				finally
				{
					if (!(enumerator15 is IDisposable disposable11))
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					}
					else
					{
						disposable11.Dispose();
					}
				}
			}
		}
		finally
		{
			if (!(enumerator3 is IDisposable disposable12))
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
			}
			else
			{
				disposable12.Dispose();
			}
		}
		list.Sort();
		using (List<string>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				string current7 = enumerator.Current;
				tempfrm.lbCustProp.Items.Add((object)current7);
			}
		}
		list.Clear();
		IEnumerator enumerator16 = TheGame.TimerList.GetEnumerator();
		try
		{
			while (enumerator16.MoveNext())
			{
				__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
				Timer timer = (Timer)enumerator16.Current;
				if (timer.CustomProperties.Count <= 0)
				{
					continue;
				}
				IEnumerator enumerator15 = timer.CustomProperties.GetEnumerator();
				try
				{
					while (enumerator15.MoveNext())
					{
						CustomProperty customProperty8 = (CustomProperty)enumerator15.Current;
						list.Add(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22991) + timer.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(22962) + customProperty8.Name + cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1932));
					}
				}
				finally
				{
					if (!(enumerator15 is IDisposable disposable13))
					{
						__ldtoken(TextHandlers.PopulateVariableMenu(ref InsertVariableFrm, ref Game));
					}
					else
					{
						disposable13.Dispose();
					}
				}
			}
		}
		finally
		{
			IDisposable disposable14 = enumerator16 as IDisposable;
			if (disposable14 != null)
			{
				disposable14.Dispose();
			}
		}
		list.Sort();
		foreach (string item3 in list)
		{
			tempfrm.lbCustProp.Items.Add((object)item3);
		}
		list.Clear();
	}
}
