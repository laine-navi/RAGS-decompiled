namespace System.Data.SqlServerCe;

[Flags]
public enum DbInsertOptions
{
	KeepCurrentPosition = 1,
	PositionOnInsertedRow = 2
}
