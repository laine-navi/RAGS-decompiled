using System;
using System.Collections;

namespace Polenter.Serialization.Core;

internal static class Tools
{
	public static bool IsSimple(Type type)
	{
		if ((object)type == typeof(string))
		{
			return true;
		}
		if ((object)type == typeof(DateTime))
		{
			return true;
		}
		if ((object)type == typeof(TimeSpan))
		{
			return true;
		}
		if ((object)type == typeof(decimal))
		{
			return true;
		}
		if ((object)type == typeof(Guid))
		{
			return true;
		}
		if ((object)type == typeof(Type) || type.IsSubclassOf(typeof(Type)))
		{
			return true;
		}
		if (type.IsEnum)
		{
			return true;
		}
		if ((object)type == typeof(byte[]))
		{
			return true;
		}
		return type.IsPrimitive;
	}

	public static bool IsEnumerable(Type type)
	{
		Type typeFromHandle = typeof(IEnumerable);
		return typeFromHandle.IsAssignableFrom(type);
	}

	public static bool IsCollection(Type type)
	{
		Type typeFromHandle = typeof(ICollection);
		return typeFromHandle.IsAssignableFrom(type);
	}

	public static bool IsDictionary(Type type)
	{
		Type typeFromHandle = typeof(IDictionary);
		return typeFromHandle.IsAssignableFrom(type);
	}

	public static bool IsArray(Type type)
	{
		return type.IsArray;
	}

	public static object CreateInstance(Type type)
	{
		if ((object)type == null)
		{
			return null;
		}
		try
		{
			return Activator.CreateInstance(type);
		}
		catch (Exception innerException)
		{
			throw new CreatingInstanceException($"Error during creating an object. Please check if the type \"{type.AssemblyQualifiedName}\" has public parameterless constructor, or if the settings IncludeAssemblyVersionInTypeName, IncludeCultureInTypeName, IncludePublicKeyTokenInTypeName are set to true. Details are in the inner exception.", innerException);
		}
	}
}
