namespace System.Data.SqlServerCe;

internal enum SEPREPAREMODE
{
	PREP_INSERT = 0,
	PREP_UPDATE = 1,
	PREP_DELETE = 2,
	PREP_CANCEL = 3,
	PREP_NONE = PREP_CANCEL
}
