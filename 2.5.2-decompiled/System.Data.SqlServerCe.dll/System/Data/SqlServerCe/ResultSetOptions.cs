namespace System.Data.SqlServerCe;

[Flags]
public enum ResultSetOptions
{
	None = 0,
	Updatable = 1,
	Scrollable = 2,
	Sensitive = 4,
	Insensitive = 8
}
