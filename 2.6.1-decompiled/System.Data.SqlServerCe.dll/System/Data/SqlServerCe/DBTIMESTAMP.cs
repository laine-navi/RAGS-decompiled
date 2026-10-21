namespace System.Data.SqlServerCe;

internal struct DBTIMESTAMP
{
	public short year;

	public ushort month;

	public ushort day;

	public ushort hour;

	public ushort minute;

	public ushort second;

	public uint fraction;
}
