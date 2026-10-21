using System.Collections;

namespace System.Data.SqlServerCe;

public sealed class SqlCeErrorCollection : ICollection, IEnumerable
{
	private ArrayList items = new ArrayList();

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	public int Count
	{
		get
		{
			if (items == null)
			{
				return 0;
			}
			return items.Count;
		}
	}

	public SqlCeError this[int index]
	{
		get
		{
			if (items == null || items.Count <= index)
			{
				return SqlCeError.GetDefaultError(-2147467259);
			}
			return (SqlCeError)items[index];
		}
	}

	internal SqlCeErrorCollection()
	{
	}

	internal unsafe void FillErrorInformation(int hr, IntPtr pIError)
	{
		int lNativeError = 0;
		int numPar = 0;
		int numPar2 = 0;
		int numPar3 = 0;
		IntPtr pwszMessage = new IntPtr(0);
		IntPtr pwszSource = new IntPtr(0);
		IntPtr pwszErr = new IntPtr(0);
		IntPtr pwszErr2 = new IntPtr(0);
		IntPtr pwszErr3 = new IntPtr(0);
		if (IntPtr.Zero == pIError)
		{
			Add(SqlCeError.GetDefaultError(hr));
			return;
		}
		try
		{
			NativeMethods.GetContextErrorInfo(pIError, ref hr, ref lNativeError, ref pwszMessage, ref pwszSource, ref numPar, ref numPar2, ref numPar3, ref pwszErr, ref pwszErr2, ref pwszErr3);
			string message = new string((char*)(void*)pwszMessage);
			string source = new string((char*)(void*)pwszSource);
			string errorParameter = new string((char*)(void*)pwszErr);
			string errorParameter2 = new string((char*)(void*)pwszErr2);
			string errorParameter3 = new string((char*)(void*)pwszErr3);
			SqlCeError error = new SqlCeError(hr, message, lNativeError, source, numPar, numPar2, numPar3, errorParameter, errorParameter2, errorParameter3);
			Add(error);
		}
		finally
		{
			NativeMethods.SafeDelete(ref pwszSource);
			NativeMethods.SafeDelete(ref pwszMessage);
			NativeMethods.SafeDelete(ref pwszErr);
			NativeMethods.SafeDelete(ref pwszErr2);
			NativeMethods.SafeDelete(ref pwszErr3);
		}
	}

	internal unsafe void FillErrorCollection(int hr, IntPtr pISSCEErrors)
	{
		if (pISSCEErrors == IntPtr.Zero)
		{
			Add(SqlCeError.GetDefaultError(hr));
			return;
		}
		int hResult = 0;
		int nativeError = 0;
		int numericParameter = 0;
		int numericParameter2 = 0;
		int numericParameter3 = 0;
		IntPtr message = new IntPtr(0);
		IntPtr source = new IntPtr(0);
		IntPtr errorParameter = new IntPtr(0);
		IntPtr errorParameter2 = new IntPtr(0);
		IntPtr errorParameter3 = new IntPtr(0);
		int num = NativeMethods.uwutil_get_ErrorCount(pISSCEErrors);
		for (int i = 0; i < num; i++)
		{
			hr = NativeMethods.uwutil_get_Error(pISSCEErrors, i, out hResult, out message, out nativeError, out source, out numericParameter, out numericParameter2, out numericParameter3, out errorParameter, out errorParameter2, out errorParameter3);
			if (hr == 0)
			{
				string text = new string((char*)(void*)message);
				string source2 = new string((char*)(void*)source);
				string errorParameter4 = new string((char*)(void*)errorParameter);
				string errorParameter5 = new string((char*)(void*)errorParameter2);
				string errorParameter6 = new string((char*)(void*)errorParameter3);
				if (text != null && text.Equals("Run"))
				{
					text = "SqlCeReplication.Synchronize()";
				}
				SqlCeError error = new SqlCeError(hResult, text, nativeError, source2, numericParameter, numericParameter2, numericParameter3, errorParameter4, errorParameter5, errorParameter6);
				Add(error);
			}
			NativeMethods.uwutil_SysFreeString(source);
			NativeMethods.uwutil_SysFreeString(message);
			NativeMethods.uwutil_SysFreeString(errorParameter);
			NativeMethods.uwutil_SysFreeString(errorParameter2);
			NativeMethods.uwutil_SysFreeString(errorParameter3);
		}
	}

	internal void Add(SqlCeError error)
	{
		items.Add(error);
	}

	public void CopyTo(Array array, int index)
	{
		items.CopyTo(array, index);
	}

	public IEnumerator GetEnumerator()
	{
		return items.GetEnumerator();
	}
}
