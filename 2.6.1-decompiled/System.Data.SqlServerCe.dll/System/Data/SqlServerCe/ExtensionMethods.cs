using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Security.Permissions;

namespace System.Data.SqlServerCe;

internal static class ExtensionMethods
{
	private static readonly string DataSqlServerCeEntityAssembly = "System.Data.SqlServerCe.Entity";

	private static readonly string DataEntityAssembly = "System.Data.Entity";

	private static string SystemDataCommonDbProviderServices_TypeName = Assembly.CreateQualifiedName(GetFullAssemblyName(DataEntityAssembly), "System.Data.Common.DbProviderServices");

	internal static Type SystemDataCommonDbProviderServices_Type = Type.GetType(SystemDataCommonDbProviderServices_TypeName, throwOnError: false);

	private static string SqlCeProviderServices_TypeName = "System.Data.SqlServerCe.SqlCeProviderServices";

	private static FieldInfo SqlCeProviderServices_Instance_FieldInfo;

	internal static object SystemDataSqlServerCeSqlCeProviderServices_Instance()
	{
		if ((object)SqlCeProviderServices_Instance_FieldInfo == null)
		{
			string text = ConstructFullAssemblyName(DataSqlServerCeEntityAssembly);
			string typeName = Assembly.CreateQualifiedName(text, SqlCeProviderServices_TypeName);
			try
			{
				Assembly.Load(text);
			}
			catch (FileNotFoundException innerException)
			{
				throw new FileNotFoundException(Res.GetString("SQLCE_CantLoadEntityDll"), innerException);
			}
			catch (FileLoadException inner)
			{
				throw new FileLoadException(Res.GetString("SQLCE_CantLoadEntityDll"), inner);
			}
			catch (BadImageFormatException inner2)
			{
				throw new BadImageFormatException(Res.GetString("SQLCE_CantLoadEntityDll"), inner2);
			}
			Type type = Type.GetType(typeName, throwOnError: false);
			if ((object)type != null)
			{
				SqlCeProviderServices_Instance_FieldInfo = type.GetField("Instance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
			}
		}
		return SystemDataSqlServerCeSqlCeProviderServices_Instance_GetValue();
	}

	[SuppressMessage("Microsoft.Security", "CA2106:SecureAsserts")]
	[ReflectionPermission(SecurityAction.Assert, MemberAccess = true)]
	private static object SystemDataSqlServerCeSqlCeProviderServices_Instance_GetValue()
	{
		object result = null;
		if ((object)SqlCeProviderServices_Instance_FieldInfo != null)
		{
			result = SqlCeProviderServices_Instance_FieldInfo.GetValue(null);
		}
		return result;
	}

	private static string ConstructFullAssemblyName(string assemblyName)
	{
		if (assemblyName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
		{
			assemblyName = Path.GetFileNameWithoutExtension(assemblyName);
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string fullName = executingAssembly.FullName;
		return fullName.Replace(executingAssembly.GetName().Name, assemblyName);
	}

	private static string GetFullAssemblyName(string assemblyName)
	{
		if (assemblyName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
		{
			assemblyName = Path.GetFileNameWithoutExtension(assemblyName);
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			AssemblyName assemblyName2 = new AssemblyName(assemblies[i].FullName);
			if (string.Compare(assemblyName2.Name, assemblyName) == 0)
			{
				return assemblyName2.FullName;
			}
		}
		throw new ArgumentException(assemblyName);
	}
}
