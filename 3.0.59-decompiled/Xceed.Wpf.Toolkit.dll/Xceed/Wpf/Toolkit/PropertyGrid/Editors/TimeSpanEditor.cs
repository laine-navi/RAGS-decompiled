using System.Windows.Data;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class TimeSpanEditor : DateTimeUpDownEditor
{
	protected override void SetControlProperties()
	{
		base.SetControlProperties();
		Editor.Format = DateTimeFormat.LongTime;
	}

	protected override IValueConverter CreateValueConverter()
	{
		return (IValueConverter)(object)new EditorTimeSpanConverter();
	}
}
