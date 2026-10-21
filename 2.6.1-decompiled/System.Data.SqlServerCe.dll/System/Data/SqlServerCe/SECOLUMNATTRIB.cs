namespace System.Data.SqlServerCe;

[Flags]
internal enum SECOLUMNATTRIB
{
	NAME = 1,
	IDCOL = 2,
	IDRANGE = 4,
	WRITEABLE = 0x10,
	NULLABLE = 0x20,
	TYPE = 0x40,
	IDENTITY = 0x80,
	IDNEXT = 0x100,
	SYSCOL = 0x200,
	IDRANGE1 = 0x400,
	IDRANGE2 = 0x800
}
