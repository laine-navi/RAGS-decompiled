using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace Xceed.Wpf.Toolkit;

public class RtfFormatter : ITextFormatter
{
	public string GetText(FlowDocument document)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		TextRange val = new TextRange(document.ContentStart, document.ContentEnd);
		using MemoryStream memoryStream = new MemoryStream();
		val.Save((Stream)memoryStream, DataFormats.Rtf);
		return Encoding.Default.GetString(memoryStream.ToArray());
	}

	public void SetText(FlowDocument document, string text)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				((TextElementCollection<Block>)(object)document.Blocks).Clear();
				return;
			}
			TextRange val = new TextRange(document.ContentStart, document.ContentEnd);
			using MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(text));
			val.Load((Stream)memoryStream, DataFormats.Rtf);
		}
		catch
		{
			throw new InvalidDataException("Data provided is not in the correct RTF format.");
		}
	}
}
