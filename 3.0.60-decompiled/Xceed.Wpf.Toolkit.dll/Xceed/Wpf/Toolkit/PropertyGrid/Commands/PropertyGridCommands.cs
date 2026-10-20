using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Commands;

public class PropertyGridCommands
{
	private static RoutedCommand _clearFilterCommand = new RoutedCommand();

	public static RoutedCommand ClearFilter => _clearFilterCommand;

	static PropertyGridCommands()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected Obj, but got Unknown
	}
}
