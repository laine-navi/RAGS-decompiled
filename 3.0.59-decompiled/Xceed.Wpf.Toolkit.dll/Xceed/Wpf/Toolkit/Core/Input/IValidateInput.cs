namespace Xceed.Wpf.Toolkit.Core.Input;

public interface IValidateInput
{
	event InputValidationErrorEventHandler InputValidationError;

	bool CommitInput();
}
