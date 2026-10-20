using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Editors;

public interface ITypeEditor
{
	FrameworkElement ResolveEditor(PropertyItem propertyItem);
}
