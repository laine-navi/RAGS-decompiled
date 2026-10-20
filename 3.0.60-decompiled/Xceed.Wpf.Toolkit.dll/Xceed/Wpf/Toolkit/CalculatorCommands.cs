using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public static class CalculatorCommands
{
	private static RoutedCommand _calculatorButtonClickCommand = new RoutedCommand();

	public static RoutedCommand CalculatorButtonClick => _calculatorButtonClickCommand;

	static CalculatorCommands()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected Obj, but got Unknown
	}
}
