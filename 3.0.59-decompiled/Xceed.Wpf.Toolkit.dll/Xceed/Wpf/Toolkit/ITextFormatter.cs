using System.Windows.Documents;

namespace Xceed.Wpf.Toolkit;

public interface ITextFormatter
{
	string GetText(FlowDocument document);

	void SetText(FlowDocument document, string text);
}
