namespace System.Data.SqlServerCe;

internal struct MEOPENINFO
{
	internal IntPtr pwszFileName;

	internal IntPtr pwszPassword;

	internal IntPtr pwszTempPath;

	internal int lcidLocale;

	internal int cbBufferPool;

	internal int fEncrypt;

	internal int dwAutoShrinkPercent;

	internal int dwFlushInterval;

	internal int cMaxPages;

	internal int cMaxTmpPages;

	internal int dwDefaultTimeout;

	internal int dwDefaultEscalation;

	internal SEOPENFLAGS dwFlags;

	internal int dwEncryptionMode;

	internal int dwLocaleFlags;
}
