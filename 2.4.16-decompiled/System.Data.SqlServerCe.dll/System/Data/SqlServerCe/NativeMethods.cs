using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Data.SqlServerCe;

internal class NativeMethods
{
	public const string LOADLIB = "kernel32.dll";

	public const string OLEAUT32 = "oleaut32.dll";

	public const string OLE32 = "ole32.dll";

	private const int VersionMismatchKB = 974247;

	private static bool m_fTryLoadingNativeLibraries = true;

	private NativeMethods()
	{
	}

	[DllImport("sqlceme35.dll", EntryPoint = "ME_AbortTransaction")]
	internal static extern int AbortTransaction(IntPtr pTx, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CommitTransaction")]
	internal static extern int CommitTransaction(IntPtr pTx, CommitMode mode, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SetTransactionFlag")]
	internal static extern int SetTransactionFlag(IntPtr pITransact, SeTransactionFlags seTxFlag, bool fEnable, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetTransactionFlags")]
	internal static extern int GetTransactionFlags(IntPtr pITransact, ref SeTransactionFlags seTxFlags);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetTrackingContext")]
	internal static extern int GetTrackingContext(IntPtr pITransact, out IntPtr pGuidTrackingContext, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SetTrackingContext")]
	internal static extern int SetTrackingContext(IntPtr pITransact, ref IntPtr pGuidTrackingContext, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetTransactionBsn")]
	internal static extern int GetTransactionBsn(IntPtr pITransact, ref long pTransactionBsn, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_InitChangeTracking")]
	internal static extern int InitChangeTracking(IntPtr pITransact, ref IntPtr pTracking, ref IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_ExitChangeTracking")]
	internal static extern int ExitChangeTracking(ref IntPtr pTracking, ref IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_EnableChangeTracking")]
	internal static extern int EnableChangeTracking(IntPtr pTracking, [MarshalAs(UnmanagedType.LPWStr)] string TableName, SETRACKINGTYPE seTrackingType, SEOCSTRACKOPTIONS seTrackOpts, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetTrackingOptions")]
	internal static extern int GetTrackingOptions(IntPtr pTracking, [MarshalAs(UnmanagedType.LPWStr)] string TableName, ref SEOCSTRACKOPTIONSV2 iTrackingOptions, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_DisableChangeTracking")]
	internal static extern int DisableChangeTracking(IntPtr pTracking, [MarshalAs(UnmanagedType.LPWStr)] string TableName, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_IsTableChangeTracked")]
	internal static extern int IsTableChangeTracked(IntPtr pTracking, [MarshalAs(UnmanagedType.LPWStr)] string TableName, ref bool fTableTracked, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetChangeTrackingInfo")]
	internal static extern int GetChangeTrackingInfo(IntPtr pTracking, [MarshalAs(UnmanagedType.LPWStr)] string TableName, ref SEOCSTRACKOPTIONS trackOptions, ref SETRACKINGTYPE trackType, ref long trackOrdinal, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CleanupTrackingMetadata")]
	internal static extern int CleanupTrackingMetadata(IntPtr pTracking, [MarshalAs(UnmanagedType.LPWStr)] string TableName, int retentionPeriodInDays, long cutoffTxCsn, long leastTxCsn, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CleanupTransactionData")]
	internal static extern int CleanupTransactionData(IntPtr pTracking, int iRetentionPeriodInDays, long ullCutoffTransactionCsn, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CleanupTombstoneData")]
	internal static extern int CleanupTombstoneData(IntPtr pTracking, [MarshalAs(UnmanagedType.LPWStr)] string TableName, int iRetentionPeriodInDays, long ullCutoffTransactionCsn, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetCurrentTrackingTxCsn")]
	internal static extern int GetCurrentTrackingTxCsn(IntPtr pTracking, ref long txCsn, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetCurrentTrackingTxBsn")]
	internal static extern int GetCurrentTrackingTxBsn(IntPtr pTracking, ref long txBsn, IntPtr pError);

	[DllImport("sqlceme35.dll")]
	internal static extern int DllAddRef();

	[DllImport("sqlceme35.dll")]
	internal static extern int DllRelease();

	[DllImport("sqlceme35.dll", EntryPoint = "ME_ClearErrorInfo")]
	internal static extern int ClearErrorInfo(IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_ExecuteQueryPlan")]
	internal static extern int ExecuteQueryPlan(IntPtr pTx, IntPtr pQpServices, IntPtr pQpCommand, IntPtr pQpPlan, IntPtr prgBinding, int cDbBinding, IntPtr pData, ref int recordsAffected, ref ResultSetOptions cursorCapabilities, ref IntPtr pSeCursor, ref int fIsBaseTableCursor, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SetValues")]
	internal static extern int SetValues(IntPtr pQpServices, IntPtr pSeCursor, IntPtr prgBinding, int cDbBinding, IntPtr pData, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SetValue")]
	internal unsafe static extern int SetValue(IntPtr pSeCursor, int seSetColumn, void* pBuffer, int ordinal, int size, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_Prepare")]
	internal static extern int Prepare(IntPtr pSeCursor, SEPREPAREMODE mode, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_InsertRecord")]
	internal static extern int InsertRecord(int fMoveTo, IntPtr pSeCursor, ref int hBookmark, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_UpdateRecord")]
	internal static extern int UpdateRecord(IntPtr pSeCursor, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_DeleteRecord")]
	internal static extern int DeleteRecord(IntPtr pSeCursor, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GotoBookmark")]
	internal static extern int GotoBookmark(IntPtr pSeCursor, int hBookmark, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetContextErrorInfo")]
	internal static extern int GetContextErrorInfo(IntPtr pError, ref int lNumber, ref int lNativeError, ref IntPtr pwszMessage, ref IntPtr pwszSource, ref int numPar1, ref int numPar2, ref int numPar3, ref IntPtr pwszErr1, ref IntPtr pwszErr2, ref IntPtr pwszErr3);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetContextErrorMessage")]
	internal static extern int GetContextErrorMessage(int dminorError, ref IntPtr pwszMessage);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetMinorError")]
	internal static extern int GetMinorError(IntPtr pError, ref int lMinor);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetBookmark")]
	internal static extern int GetBookmark(IntPtr pSeCursor, ref int hBookmark, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetColumnInfo")]
	internal static extern int GetColumnInfo(IntPtr pIUnknown, ref int columnCount, ref IntPtr prgColumnInfo, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SetColumnInfo")]
	internal static extern int SetColumnInfo(IntPtr pITransact, [MarshalAs(UnmanagedType.LPWStr)] string TableName, [MarshalAs(UnmanagedType.LPWStr)] string ColumnName, SECOLUMNINFO seColumnInfo, SECOLUMNATTRIB seColAttrib, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SetTableInfoAsSystem")]
	internal static extern int SetTableInfoAsSystem(IntPtr pITransact, [MarshalAs(UnmanagedType.LPWStr)] string TableName, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetParameterInfo")]
	internal static extern int GetParameterInfo(IntPtr pQpCommand, ref uint columnCount, ref IntPtr prgParamInfo, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetIndexColumnOrdinals")]
	internal static extern int GetIndexColumnOrdinals(IntPtr pSeCursor, IntPtr pwszIndex, ref uint cColumns, ref IntPtr priOrdinals, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetKeyInfo")]
	internal static extern int GetKeyInfo(IntPtr pIUnknown, IntPtr pTx, [MarshalAs(UnmanagedType.LPWStr)] string pwszBaseTable, IntPtr prgDbKeyInfo, int cDbKeyInfo, IntPtr pError);

	[DllImport("ole32.dll")]
	internal static extern IntPtr CoTaskMemAlloc(int cb);

	[DllImport("ole32.dll")]
	internal static extern void CoTaskMemFree(IntPtr ptr);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CreateCommand")]
	internal static extern int CreateCommand(IntPtr pQpSession, ref IntPtr pQpCommand, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CompileQueryPlan")]
	internal static extern int CompileQueryPlan(IntPtr pQpCommand, [MarshalAs(UnmanagedType.LPWStr)] string pwszCommandText, ResultSetOptions options, IntPtr[] pParamNames, IntPtr prgBinding, int cDbBinding, ref IntPtr pQpPlan, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_Move")]
	internal static extern int Move(IntPtr pSeCursor, DIRECTION direction, IntPtr pError);

	internal static bool Failed(int hr)
	{
		if (hr < 0)
		{
			return true;
		}
		return false;
	}

	[DllImport("sqlceme35.dll", EntryPoint = "ME_OpenCursor")]
	internal static extern int OpenCursor(IntPtr pITransact, IntPtr pwszTableName, IntPtr pwszIndexName, ref IntPtr pSeCursor, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetValues")]
	internal static extern int GetValues(IntPtr pSeCursor, int seGetColumn, IntPtr prgBinding, int cDbBinding, IntPtr pData, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_Read")]
	internal unsafe static extern int Read(IntPtr pSeqStream, void* pBuffer, int bufferIndex, int byteCount, out int bytesRead, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_ReadAt")]
	internal unsafe static extern int ReadAt(IntPtr pLockBytes, int srcIndex, void* pBuffer, int bufferIndex, int byteCount, out int bytesRead, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_Seek")]
	internal static extern int Seek(IntPtr pSeCursor, IntPtr pQpServices, IntPtr prgBinding, int cBinding, IntPtr pData, int cKeyValues, int dbSeekOptions, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SetRange")]
	internal static extern int SetRange(IntPtr pSeCursor, IntPtr pQpServices, IntPtr prgBinding, int cBinding, IntPtr pStartData, int cStartKeyValues, IntPtr pEndData, int cEndKeyValues, int dbRangeOptions, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SafeRelease")]
	internal static extern int SafeRelease(ref IntPtr ppUnknown);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_SafeDelete")]
	internal static extern int SafeDelete(ref IntPtr ppInstance);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_DeleteArray")]
	internal static extern int DeleteArray(ref IntPtr ppInstance);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_OpenStore")]
	internal static extern int OpenStore(IntPtr pOpenInfo, IntPtr pfnOnFlushFailure, ref IntPtr pStoreService, ref IntPtr pStoreServer, ref IntPtr pQpServices, ref IntPtr pSeStore, ref IntPtr pTx, ref IntPtr pQpDatabase, ref IntPtr pQpSession, ref IntPtr pStoreEvents, ref IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CloseStore")]
	internal static extern int CloseStore(IntPtr pSeStore);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_OpenTransaction")]
	internal static extern int OpenTransaction(IntPtr pSeStore, IntPtr pQpDatabase, SEISOLATION isoLevel, ref IntPtr pTx, ref IntPtr pQpSession, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CreateDatabase")]
	internal static extern int CreateDatabase(IntPtr pOpenInfo, ref IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_Rebuild")]
	internal static extern int Rebuild(IntPtr pwszSrc, IntPtr pwszDst, IntPtr pwszTemp, IntPtr pwszPwd, IntPtr pwszPwdNew, int fEncrypt, SEFIXOPTION tyOption, int fSafeRepair, int lcid, int dstEncryptionMode, int localeFlags, ref IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_CreateErrorInstance")]
	internal static extern int CreateErrorInstance(ref IntPtr pError);

	public static void CheckHRESULT(IntPtr pISSCEErrors, int hr)
	{
		if ((0x80000000u & hr) != 0)
		{
			SqlCeException ex = SqlCeException.FillErrorCollection(hr, pISSCEErrors);
			if (ex != null)
			{
				throw ex;
			}
		}
	}

	[DllImport("sqlceme35.dll")]
	public static extern int uwutil_ConvertToDBTIMESTAMP(ref DBTIMESTAMP pDbTimestamp, uint dtTime, int dtDay);

	[DllImport("sqlceme35.dll")]
	public static extern int uwutil_ConvertFromDBTIMESTAMP(DBTIMESTAMP pDbTimestamp, ref uint dtTime, ref int dtDay);

	[DllImport("sqlceme35.dll")]
	public static extern void uwutil_SysFreeString(IntPtr p);

	[DllImport("sqlceme35.dll")]
	public static extern uint uwutil_ReleaseCOMPtr(IntPtr p);

	[DllImport("sqlceme35.dll")]
	internal static extern int uwutil_get_ErrorCount(IntPtr pIRDA);

	[DllImport("sqlceme35.dll")]
	internal static extern int uwutil_get_Error(IntPtr pIError, int errno, out int hResult, out IntPtr message, out int nativeError, out IntPtr source, out int numericParameter1, out int numericParameter2, out int numericParameter3, out IntPtr errorParameter1, out IntPtr errorParameter2, out IntPtr errorParameter3);

	[DllImport("sqlceme35.dll")]
	internal static extern void uwutil_ZeroMemory(IntPtr dest, int length);

	internal static IntPtr MarshalStringToLPWSTR(string source)
	{
		if (source != null)
		{
			int length = source.Length;
			int num = (length + 1) * 2;
			IntPtr intPtr = CoTaskMemAlloc(num);
			if (IntPtr.Zero == intPtr)
			{
				throw new OutOfMemoryException();
			}
			uwutil_ZeroMemory(intPtr, num);
			Marshal.Copy(source.ToCharArray(), 0, intPtr, length);
			return intPtr;
		}
		return IntPtr.Zero;
	}

	internal unsafe static string GetMinorErrorMessage(int minorError)
	{
		IntPtr pwszMessage = new IntPtr(0);
		string result = null;
		if (GetContextErrorMessage(minorError, ref pwszMessage) == 0)
		{
			result = new string((char*)(void*)pwszMessage);
		}
		SafeDelete(ref pwszMessage);
		return result;
	}

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetSqlCeVersionInfo")]
	internal static extern int GetSqlCeVersionInfo(ref IntPtr pwszVersion);

	[DllImport("kernel32.dll")]
	internal static extern IntPtr LoadLibrary(string lpLibName);

	internal static bool CompareVersion(string modulePath, ref int moduleVersion)
	{
		if (string.IsNullOrEmpty(modulePath))
		{
			return false;
		}
		if (!File.Exists(modulePath))
		{
			return false;
		}
		FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(modulePath);
		moduleVersion = versionInfo.ProductBuildPart;
		return versionInfo.ProductBuildPart == 8080;
	}

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetNativeVersionInfo")]
	internal static extern int GetNativeVersionInfo(ref int bldMajor, ref int bldMinor);

	internal unsafe static void LoadValidLibrary(string modulePath, int moduleVersion)
	{
		IntPtr intPtr = IntPtr.Zero;
		if (!string.IsNullOrEmpty(modulePath))
		{
			intPtr = LoadLibrary(modulePath);
		}
		int num = 0;
		IntPtr pwszVersion = IntPtr.Zero;
		GetSqlCeVersionInfo(ref pwszVersion);
		string text = new string((char*)(void*)pwszVersion);
		SafeDelete(ref pwszVersion);
		if (string.IsNullOrEmpty(text))
		{
			if (intPtr != IntPtr.Zero)
			{
				DllRelease();
			}
			throw SqlCeException.CreateException(string.Format(Res.GetString("ADP_LoadNativeBinaryFail"), 8080, 974247));
		}
		num = new Version(text).Build;
		if (num != 8080 || (num != moduleVersion && moduleVersion != 0))
		{
			if (intPtr != IntPtr.Zero)
			{
				DllRelease();
			}
			throw SqlCeException.CreateException(string.Format(Res.GetString("ADP_FileVersionMismatch"), num, 8080, 974247));
		}
	}

	internal static void LoadNativeBinaries()
	{
		try
		{
			if (!m_fTryLoadingNativeLibraries)
			{
				return;
			}
			lock (typeof(NativeMethods))
			{
				if (!m_fTryLoadingNativeLibraries)
				{
					return;
				}
				int moduleVersion = 0;
				if (Assembly.GetExecutingAssembly().GlobalAssemblyCache)
				{
					string moduleInstallPath = SqlCeUtil.GetModuleInstallPath("sqlceme35.dll");
					if (CompareVersion(moduleInstallPath, ref moduleVersion))
					{
						LoadValidLibrary(moduleInstallPath, moduleVersion);
						m_fTryLoadingNativeLibraries = false;
						return;
					}
				}
				Assembly entryAssembly = Assembly.GetEntryAssembly();
				string text = (((object)entryAssembly == null) ? string.Empty : Path.GetDirectoryName(entryAssembly.Location));
				string modulePath = Path.Combine(text, "sqlceme35.dll");
				if (!string.IsNullOrEmpty(text))
				{
					SqlCeServicing.DoBreadcrumbServicing(modulePath);
				}
				if (CompareVersion(modulePath, ref moduleVersion))
				{
					LoadValidLibrary(modulePath, moduleVersion);
					m_fTryLoadingNativeLibraries = false;
					return;
				}
				string environmentVariable = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
				string modulePath2 = Path.Combine(Path.Combine(text, environmentVariable), "sqlceme35.dll");
				if (CompareVersion(modulePath2, ref moduleVersion))
				{
					LoadValidLibrary(modulePath2, moduleVersion);
					m_fTryLoadingNativeLibraries = false;
					return;
				}
				moduleVersion = 0;
				try
				{
					LoadValidLibrary("sqlceme35.dll", moduleVersion);
				}
				catch (DllNotFoundException inner)
				{
					throw SqlCeException.CreateException(string.Format(Res.GetString("ADP_LoadNativeBinaryFail"), 8080, 974247), inner);
				}
				m_fTryLoadingNativeLibraries = false;
			}
		}
		catch (SqlCeException)
		{
			throw;
		}
		catch (Exception)
		{
		}
	}

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetDatabaseInstanceID")]
	internal static extern int GetDatabaseInstanceID(IntPtr pStore, out IntPtr pwszGuidString, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetEncryptionMode")]
	internal static extern int GetEncryptionMode(IntPtr pStore, ref int encryptionMode, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetLocale")]
	internal static extern int GetLocale(IntPtr pStore, ref int locale, IntPtr pError);

	[DllImport("sqlceme35.dll", EntryPoint = "ME_GetLocaleFlags")]
	internal static extern int GetLocaleFlags(IntPtr pStore, ref int sortFlags, IntPtr pError);
}
