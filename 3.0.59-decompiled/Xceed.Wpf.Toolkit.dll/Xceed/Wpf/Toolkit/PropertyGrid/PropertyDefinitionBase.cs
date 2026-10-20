using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;

namespace Xceed.Wpf.Toolkit.PropertyGrid;

public abstract class PropertyDefinitionBase : DefinitionBase
{
	private IList _targetProperties;

	[TypeConverter(typeof(ListConverter))]
	public IList TargetProperties
	{
		get
		{
			return _targetProperties;
		}
		set
		{
			ThrowIfLocked(() => TargetProperties);
			_targetProperties = value;
		}
	}

	internal PropertyDefinitionBase()
	{
		_targetProperties = new List<object>();
	}

	internal override void Lock()
	{
		if (IsLocked)
		{
			return;
		}
		base.Lock();
		List<object> list = new List<object>();
		if (_targetProperties != null)
		{
			foreach (object targetProperty in _targetProperties)
			{
				object obj = targetProperty;
				if (obj is TargetPropertyType targetPropertyType)
				{
					obj = targetPropertyType.Type;
				}
				list.Add(obj);
			}
		}
		_targetProperties = new ReadOnlyCollection<object>(list);
	}
}
