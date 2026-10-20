using System;
using System.Linq.Expressions;
using System.Windows;
using Xceed.Wpf.Toolkit.Core.Utilities;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public abstract class DefinitionBase : DependencyObject
{
	private bool _isLocked;

	internal bool IsLocked => _isLocked;

	internal void ThrowIfLocked<TMember>(Expression<Func<TMember>> propertyExpression)
	{
		if (IsLocked)
		{
			string propertyOrFieldName = ReflectionHelper.GetPropertyOrFieldName(propertyExpression);
			string message = $"Cannot modify {propertyOrFieldName} once the definition has beed added to a collection.";
			throw new InvalidOperationException(message);
		}
	}

	internal virtual void Lock()
	{
		if (!_isLocked)
		{
			_isLocked = true;
		}
	}
}
