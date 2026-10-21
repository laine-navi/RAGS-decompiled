using System.Collections;
using System.Runtime.InteropServices;

namespace System.Data.SqlServerCe;

public sealed class SqlCeEngine : IDisposable
{
	private Hashtable connTokens;

	private string connStr;

	private bool isDisposed;

	public string LocalConnectionString
	{
		get
		{
			if (string.IsNullOrEmpty(connStr) || string.IsNullOrEmpty(connStr.Trim()))
			{
				connStr = string.Empty;
			}
			return connStr;
		}
		set
		{
			if (isDisposed)
			{
				throw new ObjectDisposedException("SqlCeEngine");
			}
			connTokens = ConStringUtil.ParseConnectionString(ref value);
			connStr = value;
		}
	}

	public SqlCeEngine()
	{
		NativeMethods.LoadNativeBinaries();
		isDisposed = false;
		NativeMethods.DllAddRef();
		LocalConnectionString = string.Empty;
	}

	public SqlCeEngine(string connectionString)
		: this()
	{
		LocalConnectionString = connectionString;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~SqlCeEngine()
	{
		Dispose(disposing: false);
	}

	private void Dispose(bool disposing)
	{
		if (disposing)
		{
			connStr = null;
			connTokens = null;
			NativeMethods.DllRelease();
			isDisposed = true;
		}
	}

	public void Compact(string connectionString)
	{
		Repair(SEFIXOPTION.SEFIX_OPTION_COMPACT, connectionString, RepairOption.DeleteCorruptedRows);
	}

	public void Shrink()
	{
		Repair(SEFIXOPTION.SEFIX_OPTION_SHRINK, null, RepairOption.DeleteCorruptedRows);
	}

	public void Repair(string connectionString, RepairOption options)
	{
		Repair(SEFIXOPTION.SEFIX_OPTION_REPAIR, connectionString, options);
	}

	public bool Verify()
	{
		return Verify(VerifyOption.Default);
	}

	public bool Verify(VerifyOption option)
	{
		try
		{
			switch (option)
			{
			case VerifyOption.Enhanced:
				Repair(SEFIXOPTION.SEFIX_OPTION_VERIFYEX, null, RepairOption.DeleteCorruptedRows);
				break;
			case VerifyOption.Default:
				Repair(SEFIXOPTION.SEFIX_OPTION_VERIFY, null, RepairOption.DeleteCorruptedRows);
				break;
			}
			return true;
		}
		catch (SqlCeException)
		{
			return false;
		}
	}

	private void Repair(SEFIXOPTION option, string dstConnStr, RepairOption repairOption)
	{
		int num = 0;
		int lcid = 0;
		string value = null;
		object obj = null;
		IntPtr pError = IntPtr.Zero;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		IntPtr intPtr3 = IntPtr.Zero;
		IntPtr intPtr4 = IntPtr.Zero;
		IntPtr intPtr5 = IntPtr.Zero;
		string source = null;
		string source2 = null;
		string source3 = null;
		string source4 = null;
		string source5 = null;
		int fEncrypt = 0;
		bool flag = false;
		bool flag2 = true;
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeEngine");
		}
		if (connTokens == null || string.IsNullOrEmpty(LocalConnectionString))
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_ConnectionStringNotInitialized"));
		}
		try
		{
			obj = connTokens["ssce:database password"];
			if (obj != null)
			{
				string text = ((string)obj).Trim();
				if (text.Length > 0)
				{
					source4 = text;
				}
			}
			if (dstConnStr != null)
			{
				Hashtable hashtable = ConStringUtil.ParseConnectionString(ref dstConnStr);
				obj = hashtable["data source"];
				if (obj != null)
				{
					string text2 = ((string)obj).Trim();
					if (text2.Length > 0)
					{
						source2 = text2;
					}
				}
				obj = hashtable["ssce:database password"];
				if (obj != null)
				{
					string text3 = ((string)obj).Trim();
					if (text3.Length > 0)
					{
						source5 = text3;
					}
				}
				obj = hashtable["ssce:temp file directory"];
				if (obj != null)
				{
					source3 = (string)obj;
				}
				obj = hashtable["locale identifier"];
				if (obj != null)
				{
					lcid = (int)obj;
				}
				obj = hashtable["ssce:encryption mode"];
				if (obj != null)
				{
					value = (string)obj;
				}
				obj = hashtable["ssce:encrypt database"];
				if (obj != null)
				{
					fEncrypt = (((bool)obj) ? 1 : 0);
				}
				obj = hashtable["ssce:case sensitive"];
				if (obj != null)
				{
					flag = (bool)obj;
				}
				else
				{
					flag2 = false;
				}
			}
			else
			{
				source2 = null;
				obj = connTokens["ssce:database password"];
				if (obj != null)
				{
					string text4 = ((string)obj).Trim();
					if (text4.Length > 0)
					{
						source5 = text4;
					}
				}
				obj = connTokens["ssce:temp file directory"];
				if (obj != null)
				{
					source3 = (string)obj;
				}
				obj = connTokens["locale identifier"];
				if (obj != null)
				{
					lcid = (int)obj;
				}
				obj = connTokens["ssce:encrypt database"];
				if (obj != null)
				{
					fEncrypt = (((bool)obj) ? 1 : 0);
				}
				obj = connTokens["ssce:case sensitive"];
				if (obj != null)
				{
					flag = (bool)obj;
				}
				else
				{
					flag2 = false;
				}
			}
			intPtr2 = NativeMethods.MarshalStringToLPWSTR(source2);
			intPtr3 = NativeMethods.MarshalStringToLPWSTR(source3);
			intPtr4 = NativeMethods.MarshalStringToLPWSTR(source4);
			intPtr5 = NativeMethods.MarshalStringToLPWSTR(source5);
			obj = connTokens["data source"];
			if (obj != null)
			{
				source = (string)obj;
			}
			intPtr = NativeMethods.MarshalStringToLPWSTR(source);
			int dstEncryptionMode = ConStringUtil.MapEncryptionMode(value);
			int num2 = 0;
			if (!flag2)
			{
				num2 = -1;
			}
			else if (flag)
			{
				num2 |= 1;
			}
			num = NativeMethods.Rebuild(intPtr, intPtr2, intPtr3, intPtr4, intPtr5, fEncrypt, option, (int)repairOption, lcid, dstEncryptionMode, num2, ref pError);
			if (num != 0)
			{
				ProcessResults(pError, num);
			}
		}
		finally
		{
			NativeMethods.CoTaskMemFree(intPtr);
			NativeMethods.CoTaskMemFree(intPtr2);
			NativeMethods.CoTaskMemFree(intPtr3);
			NativeMethods.CoTaskMemFree(intPtr4);
			NativeMethods.CoTaskMemFree(intPtr5);
			NativeMethods.SafeDelete(ref pError);
		}
	}

	public unsafe void CreateDatabase()
	{
		int num = 0;
		int lcidLocale = -1;
		string value = null;
		bool flag = false;
		object obj = null;
		IntPtr pError = IntPtr.Zero;
		bool flag2 = false;
		string source = null;
		string source2 = null;
		if (isDisposed)
		{
			throw new ObjectDisposedException("SqlCeEngine");
		}
		if (connTokens == null || string.IsNullOrEmpty(LocalConnectionString))
		{
			throw new InvalidOperationException(Res.GetString("SQLCE_ConnectionStringNotInitialized"));
		}
		IntPtr intPtr = IntPtr.Zero;
		MEOPENINFO mEOPENINFO = default;
		try
		{
			intPtr = NativeMethods.CoTaskMemAlloc(sizeof(MEOPENINFO));
			if (IntPtr.Zero == intPtr)
			{
				throw new OutOfMemoryException();
			}
			obj = connTokens["locale identifier"];
			if (obj != null)
			{
				lcidLocale = (int)obj;
			}
			obj = connTokens["ssce:encryption mode"];
			if (obj != null)
			{
				value = (string)obj;
			}
			obj = connTokens["data source"];
			if (obj != null)
			{
				source = (string)obj;
			}
			obj = connTokens["ssce:database password"];
			if (obj != null)
			{
				string text = ((string)obj).Trim();
				if (text.Length > 0)
				{
					source2 = text;
				}
			}
			obj = connTokens["ssce:encrypt database"];
			if (obj != null)
			{
				flag = (bool)obj;
			}
			obj = connTokens["ssce:case sensitive"];
			if (obj != null)
			{
				flag2 = (bool)obj;
			}
			mEOPENINFO.pwszFileName = NativeMethods.MarshalStringToLPWSTR(source);
			mEOPENINFO.pwszPassword = NativeMethods.MarshalStringToLPWSTR(source2);
			mEOPENINFO.lcidLocale = lcidLocale;
			mEOPENINFO.fEncrypt = (flag ? 1 : 0);
			mEOPENINFO.dwEncryptionMode = ConStringUtil.MapEncryptionMode(value);
			mEOPENINFO.dwLocaleFlags = 0;
			if (flag2)
			{
				mEOPENINFO.dwLocaleFlags |= 1;
			}
			Marshal.StructureToPtr((object)mEOPENINFO, intPtr, false);
			num = NativeMethods.CreateDatabase(intPtr, ref pError);
			if (num != 0)
			{
				ProcessResults(pError, num);
			}
		}
		finally
		{
			NativeMethods.CoTaskMemFree(mEOPENINFO.pwszFileName);
			NativeMethods.CoTaskMemFree(mEOPENINFO.pwszPassword);
			NativeMethods.CoTaskMemFree(intPtr);
			NativeMethods.SafeDelete(ref pError);
		}
	}

	internal static void ProcessResults(IntPtr pError, int hr)
	{
		if (NativeMethods.Failed(hr))
		{
			SqlCeException ex = SqlCeException.FillErrorInformation(hr, pError);
			throw ex;
		}
	}

	public void Upgrade()
	{
		Repair(SEFIXOPTION.SEFIX_OPTION_UPGRADE, null, RepairOption.DeleteCorruptedRows);
	}

	public void Upgrade(string destConnectionString)
	{
		Repair(SEFIXOPTION.SEFIX_OPTION_UPGRADE, destConnectionString, RepairOption.DeleteCorruptedRows);
	}
}
