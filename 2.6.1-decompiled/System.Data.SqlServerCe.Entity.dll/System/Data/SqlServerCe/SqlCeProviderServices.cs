using System.Collections.Generic;
using System.Data.Common;
using System.Data.Common.CommandTrees;
using System.Data.Metadata.Edm;
using System.Data.SqlServerCe.SqlGen;
using System.Reflection;

namespace System.Data.SqlServerCe;

internal sealed class SqlCeProviderServices : DbProviderServices
{
	internal static readonly SqlCeProviderServices Instance = new SqlCeProviderServices();

	internal bool _isLocalProvider = true;

	protected override DbCommandDefinition CreateDbCommandDefinition(DbProviderManifest providerManifest, DbCommandTree commandTree)
	{
		DbCommand dbCommand = CreateCommand(providerManifest, commandTree);
		return ((DbProviderServices)this).CreateCommandDefinition(dbCommand);
	}

	private DbCommand CreateCommand(DbProviderManifest providerManifest, DbCommandTree commandTree)
	{
		ADP1.CheckArgumentNull<DbProviderManifest>(providerManifest, "providerManifest");
		ADP1.CheckArgumentNull<DbCommandTree>(commandTree, "commandTree");
		if (commandTree is DbFunctionCommandTree)
		{
			throw ADP1.NotSupported(Res.GetString("StoredProceduresNotSupported"));
		}
		DbCommand dbCommand = (_isLocalProvider ? new SqlCeCommand() : ((DbCommand)RemoteProviderHelper.CreateRemoteProviderType(RemoteProvider.SqlCeCommand)));
		dbCommand.Connection = null;
		dbCommand.CommandText = SqlGenerator.GenerateSql(commandTree, out var parameters, out var commandType, _isLocalProvider);
		dbCommand.CommandType = commandType;
		foreach (KeyValuePair<string, TypeUsage> parameter in commandTree.Parameters)
		{
			DbParameter value = CreateSqlCeParameter(parameter.Key, parameter.Value, (ParameterMode)0, DBNull.Value, ignoreMaxLengthFacet: false, _isLocalProvider);
			dbCommand.Parameters.Add(value);
		}
		if (parameters != null && 0 < parameters.Count)
		{
			if (!(commandTree is DbDeleteCommandTree) && !(commandTree is DbInsertCommandTree) && !(commandTree is DbUpdateCommandTree))
			{
				throw ADP1.InternalError(ADP1.InternalErrorCode.SqlGenParametersNotPermitted);
			}
			foreach (DbParameter item in parameters)
			{
				dbCommand.Parameters.Add(item);
			}
		}
		return dbCommand;
	}

	protected override string GetDbProviderManifestToken(DbConnection connection)
	{
		ADP1.CheckArgumentNull(connection, "connection");
		if ((object)connection.GetType() == typeof(SqlCeConnection))
		{
			_isLocalProvider = true;
		}
		else
		{
			if (!RemoteProviderHelper.CompareObjectEqualsToType(connection, RemoteProvider.SqlCeConnection))
			{
				throw ADP1.Argument(Res.GetString("Mapping_Provider_WrongConnectionType", "SqlCeConnection"));
			}
			_isLocalProvider = false;
		}
		return "3.5";
	}

	protected override DbProviderManifest GetDbProviderManifest(string versionHint)
	{
		if (string.IsNullOrEmpty(versionHint))
		{
			throw ADP1.Argument(Res.GetString("UnableToDetermineStoreVersion"));
		}
		return (DbProviderManifest)(object)new SqlCeProviderManifest(versionHint, _isLocalProvider);
	}

	internal static DbParameter CreateSqlCeParameter(string name, TypeUsage type, ParameterMode mode, object value, bool ignoreMaxLengthFacet, bool isLocalProvider)
	{
		Type.GetType(RemoteProvider.SqlCeParameter);
		DbParameter dbParameter = (isLocalProvider ? new SqlCeParameter() : ((DbParameter)RemoteProviderHelper.CreateRemoteProviderType(RemoteProvider.SqlCeParameter)));
		dbParameter.ParameterName = name;
		dbParameter.Value = value;
		dbParameter.Direction = ParameterDirection.Input;
		SqlDbType sqlDbType = GetSqlDbType(type, out var size, out var precision, out var scale);
		if (size.HasValue || (!TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)12) && !TypeSemantics.IsPrimitiveType(type, (PrimitiveTypeKind)0)))
		{
			if (isLocalProvider)
			{
				if (((SqlCeParameter)dbParameter).SqlDbType != sqlDbType)
				{
					((SqlCeParameter)dbParameter).SqlDbType = sqlDbType;
				}
			}
			else
			{
				Type remoteProviderType = RemoteProviderHelper.GetRemoteProviderType(RemoteProvider.SqlCeParameter);
				PropertyInfo property = remoteProviderType.GetProperty("SqlDbType");
				property.SetValue(dbParameter, sqlDbType, null);
			}
		}
		if (!ignoreMaxLengthFacet && size.HasValue && dbParameter.Size != size.Value)
		{
			dbParameter.Size = size.Value;
		}
		if (precision.HasValue && ((IDbDataParameter)dbParameter).Precision != precision.Value)
		{
			((IDbDataParameter)dbParameter).Precision = precision.Value;
		}
		if (scale.HasValue && ((IDbDataParameter)dbParameter).Scale != scale.Value)
		{
			((IDbDataParameter)dbParameter).Scale = scale.Value;
		}
		bool flag = TypeSemantics.IsNullable(type);
		if (flag != dbParameter.IsNullable)
		{
			dbParameter.IsNullable = flag;
		}
		return dbParameter;
	}

	private static SqlDbType GetSqlDbType(TypeUsage type, out int? size, out byte? precision, out byte? scale)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected I4, but got Unknown
		PrimitiveTypeKind primitiveTypeKind = TypeSemantics.GetPrimitiveTypeKind(type);
		size = null;
		precision = null;
		scale = null;
		PrimitiveTypeKind val = primitiveTypeKind;
		switch ((int)val)
		{
		case 0:
			size = GetParameterSize(type);
			return GetBinaryDbType(type);
		case 1:
			return SqlDbType.Bit;
		case 2:
			return SqlDbType.TinyInt;
		case 13:
			throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", "Time"));
		case 14:
			throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", "DateTimeOffset"));
		case 3:
			return SqlDbType.DateTime;
		case 4:
			precision = GetParameterPrecision(type, null);
			scale = GetScale(type);
			return SqlDbType.Decimal;
		case 5:
			return SqlDbType.Float;
		case 6:
			return SqlDbType.UniqueIdentifier;
		case 9:
			return SqlDbType.SmallInt;
		case 10:
			return SqlDbType.Int;
		case 11:
			return SqlDbType.BigInt;
		case 8:
			return SqlDbType.SmallInt;
		case 7:
			return SqlDbType.Real;
		case 12:
			size = GetParameterSize(type);
			return GetStringDbType(type);
		default:
			return SqlDbType.Variant;
		}
	}

	private static int? GetParameterSize(TypeUsage type)
	{
		if (TypeHelpers.TryGetMaxLength(type, out var maxLength))
		{
			return maxLength;
		}
		return null;
	}

	private static byte? GetParameterPrecision(TypeUsage type, byte? defaultIfUndefined)
	{
		if (TypeHelpers.TryGetPrecision(type, out var precision))
		{
			return precision;
		}
		return defaultIfUndefined;
	}

	private static byte? GetScale(TypeUsage type)
	{
		if (TypeHelpers.TryGetScale(type, out var scale))
		{
			return scale;
		}
		return null;
	}

	private static SqlDbType GetStringDbType(TypeUsage type)
	{
		if (type.EdmType.Name.ToLowerInvariant() == "xml")
		{
			throw ADP1.NotSupported(Res.GetString("ProviderDoesNotSupportType", "XML"));
		}
		bool flag = false;
		if (!TypeHelpers.TryGetIsFixedLength(type, out var isFixedLength))
		{
			isFixedLength = false;
		}
		if (!TypeHelpers.TryGetIsUnicode(type, out var isUnicode))
		{
			isUnicode = true;
		}
		if (!TypeHelpers.TryGetMaxLength(type, out var _))
		{
			flag = true;
		}
		if (isFixedLength)
		{
			return SqlDbType.NChar;
		}
		return flag ? SqlDbType.NText : SqlDbType.NVarChar;
	}

	private static SqlDbType GetBinaryDbType(TypeUsage type)
	{
		bool flag = false;
		if (!TypeHelpers.TryGetIsFixedLength(type, out var isFixedLength))
		{
			isFixedLength = false;
		}
		if (!TypeHelpers.TryGetMaxLength(type, out var _))
		{
			flag = true;
		}
		if (isFixedLength)
		{
			return SqlDbType.Binary;
		}
		return flag ? SqlDbType.Image : SqlDbType.VarBinary;
	}
}
