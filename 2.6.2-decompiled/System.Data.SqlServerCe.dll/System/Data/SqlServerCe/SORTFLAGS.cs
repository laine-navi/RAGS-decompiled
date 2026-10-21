namespace System.Data.SqlServerCe;

[Flags]
internal enum SORTFLAGS
{
	NORM_IGNORECASE = 1,
	NORM_IGNOREKANATYPE = 0x10000,
	NORM_IGNOREWIDTH = 0x20000
}
