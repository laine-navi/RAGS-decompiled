using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core;

public class IndexChangedEventArgs : PropertyChangedEventArgs<int>
{
	public IndexChangedEventArgs(RoutedEvent routedEvent, int oldIndex, int newIndex)
		: base(routedEvent, oldIndex, newIndex)
	{
	}

	protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
	{
		((IndexChangedEventHandler)genericHandler)(genericTarget, this);
	}
}
