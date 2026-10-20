using System.Windows;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

internal interface IPropertyContainer
{
	ContainerHelperBase ContainerHelper { get; }

	Style PropertyContainerStyle { get; }

	EditorDefinitionCollection EditorDefinitions { get; }

	PropertyDefinitionCollection PropertyDefinitions { get; }

	bool IsCategorized { get; }

	bool AutoGenerateProperties { get; }

	FilterInfo FilterInfo { get; }
}
