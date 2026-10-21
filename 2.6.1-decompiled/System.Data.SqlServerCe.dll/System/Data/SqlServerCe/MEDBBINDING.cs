namespace System.Data.SqlServerCe;

internal struct MEDBBINDING
{
	public int iOrdinal;

	public int obValue;

	public int obSize;

	public int obStatus;

	public IntPtr pObject;

	public int cbMaxLen;

	public uint dwFlags;

	public SETYPE type;

	public uint bPrecision;

	public uint bScale;

	public int minor_pError;
}
