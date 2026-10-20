namespace System.Data.SqlServerCe;

[Flags]
public enum DbSeekOptions
{
	FirstEqual = 1,
	LastEqual = 2,
	AfterEqual = 4,
	After = 8,
	BeforeEqual = 0x10,
	Before = 0x20
}
