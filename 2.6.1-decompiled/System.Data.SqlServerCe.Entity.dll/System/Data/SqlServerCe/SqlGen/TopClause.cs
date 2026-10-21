using System.Globalization;

namespace System.Data.SqlServerCe.SqlGen;

internal class TopClause : ISqlFragment
{
	private ISqlFragment topCount;

	private bool withTies;

	internal bool WithTies => withTies;

	internal ISqlFragment TopCount => topCount;

	internal TopClause(ISqlFragment topCount, bool withTies)
	{
		this.topCount = topCount;
		this.withTies = withTies;
	}

	internal TopClause(int topCount, bool withTies)
	{
		SqlBuilder sqlBuilder = new SqlBuilder();
		sqlBuilder.Append(topCount.ToString(CultureInfo.InvariantCulture));
		this.topCount = sqlBuilder;
		this.withTies = withTies;
	}

	public void WriteSql(SqlWriter writer, SqlGenerator sqlGenerator)
	{
		writer.Write("TOP ");
		writer.Write("(");
		TopCount.WriteSql(writer, sqlGenerator);
		writer.Write(")");
		writer.Write(" ");
	}
}
