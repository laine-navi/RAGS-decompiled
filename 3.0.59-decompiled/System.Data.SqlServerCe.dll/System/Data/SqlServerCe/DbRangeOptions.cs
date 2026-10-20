namespace System.Data.SqlServerCe;

[Flags]
public enum DbRangeOptions
{
	InclusiveStart = 0,
	InclusiveEnd = 0,
	ExclusiveStart = 1,
	ExclusiveEnd = 2,
	ExcludeNulls = 4,
	Prefix = 8,
	Match = 0x10,
	Default = 0
}
