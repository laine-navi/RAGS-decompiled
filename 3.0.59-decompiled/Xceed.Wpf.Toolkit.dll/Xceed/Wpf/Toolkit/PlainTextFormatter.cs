using System.Windows.Documents;

namespace Xceed.Wpf.Toolkit;

public class PlainTextFormatter : ITextFormatter
{
	public string GetText(FlowDocument document)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return new TextRange(document.ContentStart, document.ContentEnd).Text;
	}

	public void SetText(FlowDocument document, string text)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		new TextRange(document.ContentStart, document.ContentEnd).Text = text;
	}
}
