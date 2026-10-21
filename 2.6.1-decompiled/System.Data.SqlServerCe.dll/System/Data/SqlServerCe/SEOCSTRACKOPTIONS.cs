namespace System.Data.SqlServerCe;

[Flags]
internal enum SEOCSTRACKOPTIONS
{
	NONE = 0,
	UPSERT = 1,
	INSERTUPDATE = 2,
	DELETE = 4,
	COLUMNS = 8,
	ALL = UPSERT | INSERTUPDATE | DELETE | COLUMNS
}
