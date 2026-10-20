using System.IO;
using System.Reflection;

namespace System.Data.SqlServerCe;

internal static class RemoteProviderHelper
{
	private static readonly string RemoteDataProviderAssembly = "Microsoft.SqlServerCe.Client";

	private static bool isFirst = true;

	private static Assembly rdp = null;

	internal static bool IsRemoteProviderLoaded => (object)null != rdp;

	internal static Type GetRemoteProviderType(string typeName)
	{
		if (isFirst)
		{
			try
			{
				string assemblyString = ConstructFullAssemblyName(RemoteDataProviderAssembly);
				rdp = Assembly.Load(assemblyString);
			}
			catch (FileNotFoundException)
			{
			}
			catch (FileLoadException)
			{
			}
			catch (BadImageFormatException)
			{
			}
			isFirst = false;
		}
		if ((object)rdp != null)
		{
			return rdp.GetType(typeName, throwOnError: false);
		}
		return null;
	}

	internal static bool CompareObjectEqualsToType(object obj, string typeName)
	{
		Type remoteProviderType = GetRemoteProviderType(typeName);
		if ((object)remoteProviderType != null)
		{
			return (object)obj.GetType() == remoteProviderType;
		}
		return false;
	}

	internal static object CreateRemoteProviderType(string typeName)
	{
		Type remoteProviderType = GetRemoteProviderType(typeName);
		if ((object)remoteProviderType != null)
		{
			return Activator.CreateInstance(remoteProviderType);
		}
		throw ADP1.InvalidOperation(typeName);
	}

	private static string ConstructFullAssemblyName(string assemblyName)
	{
		if (assemblyName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
		{
			assemblyName = Path.GetFileNameWithoutExtension(assemblyName);
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string fullName = executingAssembly.FullName;
		fullName = fullName.Replace(executingAssembly.GetName().Name, assemblyName);
		if (assemblyName == RemoteProvider.NameSpace)
		{
			fullName = fullName.Replace("3.5.1.0", "3.5.0.0");
		}
		return fullName;
	}
}
