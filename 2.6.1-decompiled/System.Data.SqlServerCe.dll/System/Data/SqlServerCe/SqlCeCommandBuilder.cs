using System.Data.Common;
using System.Globalization;
using System.Text;

namespace System.Data.SqlServerCe;

public sealed class SqlCeCommandBuilder : DbCommandBuilder
{
	private SqlCeRowUpdatingEventHandler _rowUpdatingHandler;

	public override ConflictOption ConflictOption
	{
		get
		{
			return base.ConflictOption;
		}
		set
		{
			if (value == ConflictOption.CompareAllSearchableValues)
			{
				throw new NotSupportedException();
			}
			base.ConflictOption = value;
		}
	}

	public override CatalogLocation CatalogLocation
	{
		get
		{
			return CatalogLocation.Start;
		}
		set
		{
			if (CatalogLocation.Start != value)
			{
				string message = string.Format(CultureInfo.InvariantCulture, "CatalogLocation", new object[0]);
				throw new ArgumentException(message);
			}
		}
	}

	public override string CatalogSeparator
	{
		get
		{
			return ".";
		}
		set
		{
			if ("." != value)
			{
				string message = string.Format(CultureInfo.InvariantCulture, "CatalogSeparator", new object[0]);
				throw new ArgumentException(message);
			}
		}
	}

	public new SqlCeDataAdapter DataAdapter
	{
		get
		{
			return (SqlCeDataAdapter)base.DataAdapter;
		}
		set
		{
			SqlCeDataAdapter sqlCeDataAdapter = (SqlCeDataAdapter)base.DataAdapter;
			if (sqlCeDataAdapter != value)
			{
				if (sqlCeDataAdapter != null)
				{
					sqlCeDataAdapter.RowUpdating -= _rowUpdatingHandler;
					_rowUpdatingHandler = null;
				}
				base.DataAdapter = value;
			}
		}
	}

	public override string QuotePrefix
	{
		get
		{
			return base.QuotePrefix;
		}
		set
		{
			if ("[" != value && "\"" != value && value.Length != 0)
			{
				string message = Res.GetString("ADP_InvalidQuotePrefix");
				string paramName = string.Format(CultureInfo.InvariantCulture, "QuotePrefix", new object[0]);
				throw new ArgumentException(message, paramName);
			}
			base.QuotePrefix = value;
		}
	}

	public override string QuoteSuffix
	{
		get
		{
			return base.QuoteSuffix;
		}
		set
		{
			if ("]" != value && "\"" != value && value.Length != 0)
			{
				string message = Res.GetString("ADP_InvalidQuoteSuffix");
				string paramName = string.Format(CultureInfo.InvariantCulture, "QuoteSuffix", new object[0]);
				throw new ArgumentException(message, paramName);
			}
			base.QuoteSuffix = value;
		}
	}

	public override string SchemaSeparator
	{
		get
		{
			return ".";
		}
		set
		{
			if ("." != value)
			{
				string message = Res.GetString("ADP_InvalidSchemaSeparator");
				string paramName = string.Format(CultureInfo.InvariantCulture, "SchemaSeparator", new object[0]);
				throw new ArgumentException(message, paramName);
			}
		}
	}

	public SqlCeCommandBuilder()
	{
		GC.SuppressFinalize(this);
		base.QuotePrefix = "[";
		base.QuoteSuffix = "]";
	}

	public SqlCeCommandBuilder(SqlCeDataAdapter adapter)
		: this()
	{
		DataAdapter = adapter;
	}

	private void SqlCeRowUpdatingHandler(object sender, SqlCeRowUpdatingEventArgs ruevent)
	{
		RowUpdatingHandler(ruevent);
	}

	public new SqlCeCommand GetInsertCommand()
	{
		return (SqlCeCommand)base.GetInsertCommand();
	}

	public new SqlCeCommand GetUpdateCommand()
	{
		return (SqlCeCommand)base.GetUpdateCommand();
	}

	public new SqlCeCommand GetDeleteCommand()
	{
		return (SqlCeCommand)base.GetDeleteCommand();
	}

	protected override void ApplyParameterInfo(DbParameter param, DataRow row, StatementType statementType, bool whereClause)
	{
		SqlCeParameter sqlCeParameter = (SqlCeParameter)param;
		sqlCeParameter.SqlDbType = ((SqlCeType)row["ProviderType"]).SqlDbType;
		sqlCeParameter.IsNullable = (bool)row["AllowDBNull"];
		if (DBNull.Value != row["NumericPrecision"])
		{
			sqlCeParameter.Precision = (byte)(short)row["NumericPrecision"];
		}
		if (DBNull.Value != row["NumericScale"])
		{
			sqlCeParameter.Scale = (byte)(short)row["NumericScale"];
		}
		sqlCeParameter.Size = 0;
	}

	protected override string GetParameterName(int parameterOrdinal)
	{
		return "@p" + parameterOrdinal.ToString(CultureInfo.InvariantCulture);
	}

	protected override string GetParameterName(string parameterName)
	{
		throw new NotSupportedException();
	}

	protected override string GetParameterPlaceholder(int parameterOrdinal)
	{
		return "@p" + parameterOrdinal.ToString(CultureInfo.InvariantCulture);
	}

	protected override void SetRowUpdatingHandler(DbDataAdapter adapter)
	{
		SqlCeDataAdapter sqlCeDataAdapter = (SqlCeDataAdapter)adapter;
		if (sqlCeDataAdapter != null)
		{
			_rowUpdatingHandler = SqlCeRowUpdatingHandler;
			sqlCeDataAdapter.RowUpdating += _rowUpdatingHandler;
		}
	}

	private void ConsistentQuoteDelimiters(string quotePrefix, string quoteSuffix)
	{
		if (("\"" == quotePrefix && "\"" != quoteSuffix) || ("[" == quotePrefix && "]" != quoteSuffix))
		{
			throw new ArgumentException(Res.GetString("ADP_InvalidPrefixSuffix", quotePrefix, quoteSuffix));
		}
	}

	private static string BuildQuotedString(string quotePrefix, string quoteSuffix, string unQuotedString)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!ADP.IsEmpty(quotePrefix))
		{
			stringBuilder.Append(quotePrefix);
		}
		if (!ADP.IsEmpty(quoteSuffix))
		{
			stringBuilder.Append(unQuotedString.Replace(quoteSuffix, quoteSuffix + quoteSuffix));
			stringBuilder.Append(quoteSuffix);
		}
		else
		{
			stringBuilder.Append(unQuotedString);
		}
		return stringBuilder.ToString();
	}

	private static bool RemoveStringQuotes(string quotePrefix, string quoteSuffix, string quotedString, out string unquotedString)
	{
		int num = quotePrefix?.Length ?? 0;
		int num2 = quoteSuffix?.Length ?? 0;
		if (num2 + num == 0)
		{
			unquotedString = quotedString;
			return true;
		}
		if (quotedString == null)
		{
			unquotedString = quotedString;
			return false;
		}
		int length = quotedString.Length;
		if (length < num + num2)
		{
			unquotedString = quotedString;
			return false;
		}
		if (num > 0 && !quotedString.StartsWith(quotePrefix, StringComparison.Ordinal))
		{
			unquotedString = quotedString;
			return false;
		}
		if (num2 > 0)
		{
			if (!quotedString.EndsWith(quoteSuffix, StringComparison.Ordinal))
			{
				unquotedString = quotedString;
				return false;
			}
			unquotedString = quotedString.Substring(num, length - (num + num2)).Replace(quoteSuffix + quoteSuffix, quoteSuffix);
		}
		else
		{
			unquotedString = quotedString.Substring(num, length - num);
		}
		return true;
	}

	public override string QuoteIdentifier(string unquotedIdentifier)
	{
		if (unquotedIdentifier == null)
		{
			throw new ArgumentNullException("unquotedIdentifier");
		}
		string quoteSuffix = QuoteSuffix;
		string quotePrefix = QuotePrefix;
		ConsistentQuoteDelimiters(quotePrefix, quoteSuffix);
		return BuildQuotedString(quotePrefix, quoteSuffix, unquotedIdentifier);
	}

	public override string UnquoteIdentifier(string quotedIdentifier)
	{
		if (quotedIdentifier == null)
		{
			throw new ArgumentNullException("quotedIdentifier");
		}
		string quoteSuffix = QuoteSuffix;
		string quotePrefix = QuotePrefix;
		ConsistentQuoteDelimiters(quotePrefix, quoteSuffix);
		RemoveStringQuotes(quotePrefix, quoteSuffix, quotedIdentifier, out var unquotedString);
		return unquotedString;
	}
}
