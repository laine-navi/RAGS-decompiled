namespace System.Data.SqlServerCe;

[Flags]
internal enum DbColumnFlags
{
	ISBOOKMARK = 1,
	MAYDEFER = 2,
	WRITE = 4,
	WRITEUNKNOWN = 8,
	ISFIXEDLENGTH = 0x10,
	ISNULLABLE = 0x20,
	MAYBENULL = 0x40,
	ISLONG = 0x80,
	ISROWID = 0x100,
	ISROWVER = 0x200,
	CACHEDEFERRED = 0x1000
}
