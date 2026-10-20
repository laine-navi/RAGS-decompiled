using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Commands;

public static class PropertyItemCommands
{
	private static RoutedCommand _resetValueCommand = new RoutedCommand();

	public static RoutedCommand ResetValue => _resetValueCommand;

	static PropertyItemCommands()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected Obj, but got Unknown
	}
}
