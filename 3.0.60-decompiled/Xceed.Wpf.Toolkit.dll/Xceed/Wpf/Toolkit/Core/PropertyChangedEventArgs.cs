using System;
using System.Windows;

namespace Xceed.Wpf.Toolkit.Core;

public class PropertyChangedEventArgs<T> : RoutedEventArgs
{
	private readonly T _newValue;

	private readonly T _oldValue;

	public T NewValue => _newValue;

	public T OldValue => _oldValue;

	public PropertyChangedEventArgs(RoutedEvent Event, T oldValue, T newValue)
	{
		_oldValue = oldValue;
		_newValue = newValue;
		((RoutedEventArgs)this).RoutedEvent = Event;
	}

	protected override void InvokeEventHandler(Delegate genericHandler, object genericTarget)
	{
		PropertyChangedEventHandler<T> propertyChangedEventHandler = (PropertyChangedEventHandler<T>)genericHandler;
		propertyChangedEventHandler(genericTarget, this);
	}
}
