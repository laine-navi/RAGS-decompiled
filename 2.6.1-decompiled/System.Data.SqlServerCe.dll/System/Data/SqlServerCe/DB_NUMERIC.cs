namespace System.Data.SqlServerCe;

internal struct DB_NUMERIC
{
	public byte precision;

	public byte scale;

	public byte sign;

	public unsafe fixed byte val[16];
}
