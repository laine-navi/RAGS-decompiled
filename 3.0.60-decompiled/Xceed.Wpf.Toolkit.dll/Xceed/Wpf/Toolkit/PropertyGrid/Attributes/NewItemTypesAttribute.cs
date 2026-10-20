using System;
using System.Collections.Generic;

namespace Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class NewItemTypesAttribute : Attribute
{
	public IList<Type> Types { get; set; }

	public NewItemTypesAttribute(params Type[] types)
	{
		Types = new List<Type>(types);
	}

	public NewItemTypesAttribute()
	{
	}
}
