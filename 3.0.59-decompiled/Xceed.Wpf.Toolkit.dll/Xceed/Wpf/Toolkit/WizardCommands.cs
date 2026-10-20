using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public static class WizardCommands
{
	private static RoutedCommand _cancelCommand = new RoutedCommand();

	private static RoutedCommand _finishCommand = new RoutedCommand();

	private static RoutedCommand _helpCommand = new RoutedCommand();

	private static RoutedCommand _nextPageCommand = new RoutedCommand();

	private static RoutedCommand _previousPageCommand = new RoutedCommand();

	private static RoutedCommand _selectPageCommand = new RoutedCommand();

	public static RoutedCommand Cancel => _cancelCommand;

	public static RoutedCommand Finish => _finishCommand;

	public static RoutedCommand Help => _helpCommand;

	public static RoutedCommand NextPage => _nextPageCommand;

	public static RoutedCommand PreviousPage => _previousPageCommand;

	public static RoutedCommand SelectPage => _selectPageCommand;

	static WizardCommands()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected Obj, but got Unknown
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected Obj, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected Obj, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
	}
}
