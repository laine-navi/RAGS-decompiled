using System.Globalization;
using System.Reflection;

namespace System.Data.SqlServerCe;

internal class SqlCeRestriction
{
	private static bool IsWebHosted()
	{
		bool result = false;
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			if (!(assembly.GetName().Name == "System.Web") || !assembly.GlobalAssemblyCache)
			{
				continue;
			}
			Type type = assembly.GetType("System.Web.Hosting.HostingEnvironment");
			if ((object)type == null)
			{
				break;
			}
			PropertyInfo property = type.GetProperty("IsHosted", typeof(bool));
			if ((object)property != null)
			{
				object value = property.GetValue(type, null);
				if (value != null && value is bool)
				{
					result = (bool)value;
				}
			}
			break;
		}
		return result;
	}

	private static bool IsExplicitlyEnabled()
	{
		bool result = false;
		object data = AppDomain.CurrentDomain.GetData("SQLServerCompactEditionUnderWebHosting");
		if (data != null && data is bool)
		{
			result = (bool)data;
		}
		return result;
	}

	public static void CheckExplicitWebHosting()
	{
		if (!IsExplicitlyEnabled() && IsWebHosted())
		{
			string message = Res.GetString(CultureInfo.CurrentCulture, "SQLCE_WebHostingRestriction");
			throw new NotSupportedException(message);
		}
	}
}
