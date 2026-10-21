using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.SqlServerCe;

public sealed class SqlCeProviderFactory : DbProviderFactory, IServiceProvider
{
	[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
	public static readonly SqlCeProviderFactory Instance = new SqlCeProviderFactory();

	public override DbCommand CreateCommand()
	{
		return new SqlCeCommand();
	}

	public override DbCommandBuilder CreateCommandBuilder()
	{
		return new SqlCeCommandBuilder();
	}

	public override DbConnection CreateConnection()
	{
		return new SqlCeConnection();
	}

	public override DbDataAdapter CreateDataAdapter()
	{
		return new SqlCeDataAdapter();
	}

	public override DbParameter CreateParameter()
	{
		return new SqlCeParameter();
	}

	object IServiceProvider.GetService(Type serviceType)
	{
		object result = null;
		if ((object)serviceType == ExtensionMethods.SystemDataCommonDbProviderServices_Type)
		{
			result = ExtensionMethods.SystemDataSqlServerCeSqlCeProviderServices_Instance();
		}
		return result;
	}
}
