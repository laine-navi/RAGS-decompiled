namespace System.Data.SqlServerCe;

[Flags]
internal enum SEOPENFLAGS
{
	MODE_READ = 1,
	MODE_WRITE = 2,
	MODE_SHARE_DENY_READ = 4,
	MODE_SHARE_DENY_WRITE = 8
}
