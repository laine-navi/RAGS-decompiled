using System.IO;
using Microsoft.Win32;

namespace System.Data.SqlServerCe;

internal static class SqlCeUtil
{
	internal const string ProductName = "Microsoft SQL Server Compact";

	internal const string ProductRootRegKey = "Software\\Microsoft\\Microsoft SQL Server Compact Edition\\v3.5";

	internal const string Product35RootRegKey = "SOFTWARE\\Microsoft\\Microsoft SQL Server Compact Edition\\v3.5";

	internal const string ProductProxyPortsRegKey = "Software\\Microsoft\\Windows CE Services\\ProxyPorts";

	internal const string NetCFKey = "Software\\Microsoft\\.NetCompactFramework\\Installer\\Assemblies\\Global";

	internal const string ProviderName = "Sql Server Compact ADO.NET Data Provider";

	internal const string ProductServicingFile = "Microsoft.SqlServer.Compact.351.{0}.bc";

	internal const string ModuleStorageEngine = "sqlcese35.dll";

	internal const string ModuleStorageEngineSys = "sqlcese35.sys.dll";

	internal const string ModuleQueryProcessor = "sqlceqp35.dll";

	internal const string ModuleClientAgent = "sqlceca35.dll";

	internal const string ModuleOleDbProvider = "sqlceoledb35.dll";

	internal const string ModuleManagedExtentions = "sqlceme35.dll";

	internal const string ModuleDbCompact = "sqlcecompact35.dll";

	internal const string ModuleErrRes = "sqlceer35{0}.dll";

	internal const string ModuleServerAgent = "sqlcesa35.dll";

	internal const string ModuleReplicationProvider = "sqlcerp35.dll";

	internal const string ModuleTdsServer = "tdsserver35.exe";

	internal static RegistryKey RegistryOpenSubKey(RegistryKey rootKey, string subKeyName, bool writable)
	{
		return rootKey.OpenSubKey(subKeyName, writable);
	}

	internal static RegistryKey RegistryOpenProductRootKey(RegistryKey sysRootKey, bool writable)
	{
		return RegistryOpenSubKey(sysRootKey, "Software\\Microsoft\\Microsoft SQL Server Compact Edition\\v3.5", writable);
	}

	internal static RegistryKey RegistryOpenProductRootSubKey(RegistryKey sysRootKey, string subKeyName, bool writable)
	{
		RegistryKey registryKey = RegistryOpenSubKey(sysRootKey, "Software\\Microsoft\\Microsoft SQL Server Compact Edition\\v3.5", writable);
		RegistryKey result = null;
		if (registryKey != null)
		{
			result = RegistryOpenSubKey(registryKey, subKeyName, writable);
			registryKey.Close();
		}
		return result;
	}

	internal static RegistryKey RegistryCreateProductRootKey(RegistryKey sysRootKey)
	{
		return sysRootKey.CreateSubKey("Software\\Microsoft\\Microsoft SQL Server Compact Edition\\v3.5");
	}

	internal static RegistryKey RegistryCreateProductRootSubKey(RegistryKey sysRootKey, string subKeyName)
	{
		RegistryKey registryKey = RegistryCreateProductRootKey(sysRootKey);
		RegistryKey result = null;
		if (registryKey != null)
		{
			result = registryKey.CreateSubKey(subKeyName);
			registryKey.Close();
		}
		return result;
	}

	internal static string GetModuleInstallPath(string moduleName)
	{
		string empty = string.Empty;
		RegistryKey registryKey = RegistryOpenProductRootKey(Registry.LocalMachine, writable: false);
		if (registryKey == null)
		{
			return string.Empty;
		}
		empty = (string)registryKey.GetValue("NativeDir");
		registryKey.Close();
		if (string.IsNullOrEmpty(empty))
		{
			return string.Empty;
		}
		return Path.Combine(empty, moduleName);
	}
}
