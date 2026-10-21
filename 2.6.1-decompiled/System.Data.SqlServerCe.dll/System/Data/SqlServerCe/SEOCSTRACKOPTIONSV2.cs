namespace System.Data.SqlServerCe;

[Flags]
internal enum SEOCSTRACKOPTIONSV2
{
	NONE = 0xF0,
	INSERT = 0x10,
	UPDATE = 0x20,
	DELETE = 0x40
}
