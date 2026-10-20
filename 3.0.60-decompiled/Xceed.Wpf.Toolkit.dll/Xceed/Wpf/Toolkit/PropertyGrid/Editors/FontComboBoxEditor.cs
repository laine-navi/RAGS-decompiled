using System.Collections;
using System.Windows;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public class FontComboBoxEditor : ComboBoxEditor
{
	protected override IEnumerable CreateItemsSource(PropertyItem propertyItem)
	{
		if (propertyItem.PropertyType == typeof(FontFamily))
		{
			return FontUtilities.Families;
		}
		if (propertyItem.PropertyType == typeof(FontWeight))
		{
			return FontUtilities.Weights;
		}
		if (propertyItem.PropertyType == typeof(FontStyle))
		{
			return FontUtilities.Styles;
		}
		if (propertyItem.PropertyType == typeof(FontStretch))
		{
			return FontUtilities.Stretches;
		}
		return null;
	}
}
