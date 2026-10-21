namespace System.Data.SqlServerCe;

internal struct MEDBKEYINFO
{
	public IntPtr pwszBaseColumnName;

	public uint iOrdinal;

	public int isUnique;

	public int isKey;

	public int isReadOnly;

	public int isIdentity;
}
