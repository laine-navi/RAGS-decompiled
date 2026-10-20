using System;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public abstract class PropertyDefinitionBaseCollection<T> : DefinitionCollectionBase<T> where T : PropertyDefinitionBase
{
	public T this[object propertyId]
	{
		get
		{
			foreach (T item in Items)
			{
				T current = item;
				if (current.TargetProperties.Contains(propertyId))
				{
					return current;
				}
			}
			return null;
		}
	}

	internal PropertyDefinitionBaseCollection()
	{
	}

	internal T GetRecursiveBaseTypes(Type type)
	{
		T val = null;
		while (val == null && type != null)
		{
			val = this[type];
			type = type.BaseType;
		}
		return val;
	}
}
