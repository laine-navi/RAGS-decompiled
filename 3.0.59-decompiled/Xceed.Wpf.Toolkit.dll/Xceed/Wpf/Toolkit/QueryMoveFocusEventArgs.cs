using System.Windows;
using System.Windows.Input;

namespace Xceed.Wpf.Toolkit;

public class QueryMoveFocusEventArgs : RoutedEventArgs
{
	private FocusNavigationDirection m_navigationDirection;

	private bool m_reachedMaxLength;

	private bool m_canMove = true;

	public FocusNavigationDirection FocusNavigationDirection
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return m_navigationDirection;
		}
	}

	public bool ReachedMaxLength => m_reachedMaxLength;

	public bool CanMoveFocus
	{
		get
		{
			return m_canMove;
		}
		set
		{
			m_canMove = value;
		}
	}

	private QueryMoveFocusEventArgs()
	{
	}

	internal QueryMoveFocusEventArgs(FocusNavigationDirection direction, bool reachedMaxLength)
		: base(AutoSelectTextBox.QueryMoveFocusEvent)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		m_navigationDirection = direction;
		m_reachedMaxLength = reachedMaxLength;
	}
}
