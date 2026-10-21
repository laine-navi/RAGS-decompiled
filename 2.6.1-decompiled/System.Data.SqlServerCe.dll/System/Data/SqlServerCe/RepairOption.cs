namespace System.Data.SqlServerCe;

public enum RepairOption
{
	DeleteCorruptedRows = 0,
	[Obsolete("This is deprecated, please use RecoverAllPossibleRows")]
	RecoverCorruptedRows = 1,
	RecoverAllPossibleRows = RecoverCorruptedRows,
	RecoverAllOrFail = 2
}
