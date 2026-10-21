namespace System.Data.SqlServerCe.SqlGen;

internal interface ISqlFragment
{
	void WriteSql(SqlWriter writer, SqlGenerator sqlGenerator);
}
