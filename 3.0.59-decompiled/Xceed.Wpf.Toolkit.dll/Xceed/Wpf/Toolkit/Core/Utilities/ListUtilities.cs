using System;
using System.Collections.Generic;
using System.Linq;

namespace Xceed.Wpf.Toolkit.Core.Utilities;

internal class ListUtilities
{
	internal static Type GetListItemType(Type listType)
	{
		Type type = listType.GetInterfaces().FirstOrDefault((Type i) => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>));
		if (!(type != null))
		{
			return null;
		}
		return type.GetGenericArguments()[0];
	}
}
