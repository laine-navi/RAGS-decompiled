using System.Text;

namespace System.Data.SqlServerCe.SqlGen;

internal static class Utilities
{
	public static string EscapeSquareBraceNames(string name)
	{
		return EscapeNames(name, ']');
	}

	public static string EscapeNames(string name, char quote)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(quote.ToString());
		stringBuilder.Append(quote.ToString());
		return name.Replace(quote.ToString(), stringBuilder.ToString());
	}
}
