using System.Windows.Input;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal class KeyboardUtilities
{
	internal static bool IsKeyModifyingPopupState(KeyEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		if ((Keyboard.Modifiers & 1) != 1 || ((int)e.SystemKey != 26 && (int)e.SystemKey != 24))
		{
			return (int)e.Key == 93;
		}
		return true;
	}
}
