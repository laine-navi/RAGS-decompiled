using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace System.Data.SqlServerCe;

public sealed class SqlCeReplication : IDisposable
{
	internal IntPtr pIReplication = IntPtr.Zero;

	internal IntPtr pIErrors = IntPtr.Zero;

	public short PostSyncCleanup
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			short iCleanupType = 0;
			int hr = uwrepl_get_PostSyncCleanup(pIReplication, ref iCleanupType);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return iCleanupType;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_PostSyncCleanup(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string Distributor
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_Distributor(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_Distributor(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public NetworkType DistributorNetwork
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			NetworkType DistributorNetwork = NetworkType.DefaultNetwork;
			int hr = uwrepl_get_DistributorNetwork(pIReplication, ref DistributorNetwork);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return DistributorNetwork;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_DistributorNetwork(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string DistributorAddress
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_DistributorAddress(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_DistributorAddress(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public SecurityType DistributorSecurityMode
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			SecurityType DistributorSecurityMode = SecurityType.DBAuthentication;
			int hr = uwrepl_get_DistributorSecurityMode(pIReplication, ref DistributorSecurityMode);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return DistributorSecurityMode;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_DistributorSecurityMode(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string DistributorLogin
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_DistributorLogin(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_DistributorLogin(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string DistributorPassword
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_DistributorPassword(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_DistributorPassword(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public ExchangeType ExchangeType
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			ExchangeType ExchangeType = ExchangeType.BiDirectional;
			int hr = uwrepl_get_ExchangeType(pIReplication, ref ExchangeType);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ExchangeType;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ExchangeType(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string HostName
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_HostName(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_HostName(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetUrl
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_InternetUrl(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_InternetUrl(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetLogin
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_InternetLogin(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_InternetLogin(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetPassword
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_InternetPassword(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_InternetPassword(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetProxyServer
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_InternetProxyServer(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_InternetProxyServer(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetProxyLogin
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_InternetProxyLogin(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_InternetProxyLogin(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string InternetProxyPassword
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_InternetProxyPassword(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_InternetProxyPassword(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public short LoginTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			ushort LoginTimeout = 0;
			int hr = uwrepl_get_LoginTimeout(pIReplication, ref LoginTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return (short)LoginTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_LoginTimeout(pIReplication, (ushort)value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string ProfileName
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_ProfileName(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ProfileName(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string Publisher
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_Publisher(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_Publisher(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public NetworkType PublisherNetwork
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			NetworkType PublisherNetwork = NetworkType.DefaultNetwork;
			int hr = uwrepl_get_PublisherNetwork(pIReplication, ref PublisherNetwork);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return PublisherNetwork;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_PublisherNetwork(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string PublisherAddress
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_PublisherAddress(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_PublisherAddress(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public SecurityType PublisherSecurityMode
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			SecurityType PublisherSecurityMode = SecurityType.DBAuthentication;
			int hr = uwrepl_get_PublisherSecurityMode(pIReplication, ref PublisherSecurityMode);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return PublisherSecurityMode;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_PublisherSecurityMode(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string PublisherLogin
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_PublisherLogin(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_PublisherLogin(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string PublisherPassword
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_PublisherPassword(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_PublisherPassword(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string PublisherDatabase
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_PublisherDatabase(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_PublisherDatabase(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string Publication
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_Publication(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_Publication(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int PublisherChanges
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int PublisherChanges = 0;
			int hr = uwrepl_get_PublisherChanges(pIReplication, ref PublisherChanges);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return PublisherChanges;
		}
	}

	public int PublisherConflicts
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int PublisherConflicts = 0;
			int hr = uwrepl_get_PublisherConflicts(pIReplication, ref PublisherConflicts);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return PublisherConflicts;
		}
	}

	public short QueryTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			ushort QueryTimeout = 0;
			int hr = uwrepl_get_QueryTimeout(pIReplication, ref QueryTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return (short)QueryTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_QueryTimeout(pIReplication, (ushort)value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string Subscriber
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_Subscriber(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_Subscriber(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public string SubscriberConnectionString
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			IntPtr rbz = new IntPtr(0);
			int hr = uwrepl_get_SubscriberConnectionString(pIReplication, ref rbz);
			string text = null;
			try
			{
				NativeMethods.CheckHRESULT(pIErrors, hr);
				return Marshal.PtrToStringUni(rbz);
			}
			finally
			{
				NativeMethods.uwutil_SysFreeString(rbz);
			}
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			string text = null;
			StringBuilder stringBuilder = new StringBuilder();
			Hashtable hashtable = ConStringUtil.ParseConnectionString(ref value);
			IEnumerator enumerator = hashtable.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				text = (string)enumerator.Current;
				stringBuilder.Append(text);
				stringBuilder.Append("=\"");
				stringBuilder.Append(hashtable[text]);
				stringBuilder.Append("\";");
			}
			int hr = uwrepl_put_SubscriberConnectionString(pIReplication, stringBuilder.ToString());
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int SubscriberChanges
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int SubscriberChanges = 0;
			int hr = uwrepl_get_SubscriberChanges(pIReplication, ref SubscriberChanges);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return SubscriberChanges;
		}
	}

	public int SubscriberConflicts
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int SubscriberConflicts = 0;
			int hr = uwrepl_get_SubscriberConflicts(pIReplication, ref SubscriberConflicts);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return SubscriberConflicts;
		}
	}

	public ValidateType Validate
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			ValidateType Validate = ValidateType.NoValidation;
			int hr = uwrepl_get_Validate(pIReplication, ref Validate);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return Validate;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_Validate(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int ConnectTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int connectTimeout = 0;
			int hr = uwrepl_get_ConnectTimeout(pIReplication, ref connectTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return connectTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ConnectTimeout(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int SendTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int SendTimeout = 0;
			int hr = uwrepl_get_SendTimeout(pIReplication, ref SendTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return SendTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_SendTimeout(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public int ReceiveTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int ReceiveTimeout = 0;
			int hr = uwrepl_get_ReceiveTimeout(pIReplication, ref ReceiveTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ReceiveTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ReceiveTimeout(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int DataSendTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int DataSendTimeout = 0;
			int hr = uwrepl_get_DataSendTimeout(pIReplication, ref DataSendTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return DataSendTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_DataSendTimeout(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int DataReceiveTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int DataReceiveTimeout = 0;
			int hr = uwrepl_get_DataReceiveTimeout(pIReplication, ref DataReceiveTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return DataReceiveTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_DataReceiveTimeout(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int ControlSendTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int ControlSendTimeout = 0;
			int hr = uwrepl_get_ControlSendTimeout(pIReplication, ref ControlSendTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ControlSendTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ControlSendTimeout(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	private int ControlReceiveTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int ControlReceiveTimeout = 0;
			int hr = uwrepl_get_ControlReceiveTimeout(pIReplication, ref ControlReceiveTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ControlReceiveTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ControlReceiveTimeout(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public short ConnectionRetryTimeout
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			ushort ConnectionRetryTimeout = 0;
			int hr = uwrepl_get_ConnectionRetryTimeout(pIReplication, ref ConnectionRetryTimeout);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return (short)ConnectionRetryTimeout;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ConnectionRetryTimeout(pIReplication, (ushort)value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public short CompressionLevel
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			ushort CompressionLevel = 0;
			int hr = uwrepl_get_CompressionLevel(pIReplication, ref CompressionLevel);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return (short)CompressionLevel;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_CompressionLevel(pIReplication, (ushort)value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public bool ConnectionManager
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			bool ConnectionManager = false;
			int hr = uwrepl_get_ConnectionManager(pIReplication, ref ConnectionManager);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return ConnectionManager;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_ConnectionManager(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public SnapshotTransferType SnapshotTransferType
	{
		get
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			SnapshotTransferType SnapshotTransferType = SnapshotTransferType.UNC;
			int hr = uwrepl_get_SnapshotTransferType(pIReplication, ref SnapshotTransferType);
			NativeMethods.CheckHRESULT(pIErrors, hr);
			return SnapshotTransferType;
		}
		set
		{
			if (IntPtr.Zero == pIReplication)
			{
				throw new ObjectDisposedException("SqlCeReplication");
			}
			int hr = uwrepl_put_SnapshotTransferType(pIReplication, value);
			NativeMethods.CheckHRESULT(pIErrors, hr);
		}
	}

	public SqlCeReplication()
	{
		NativeMethods.LoadNativeBinaries();
		pIReplication = new IntPtr(0);
		IntPtr pCreationIError = new IntPtr(0);
		int hr = uwrepl_Replication(ref pIReplication, ref pCreationIError);
		if (NativeMethods.Failed(hr))
		{
			SqlCeException ex = SqlCeException.FillErrorInformation(hr, pCreationIError);
			if (IntPtr.Zero != pCreationIError)
			{
				NativeMethods.uwutil_ReleaseCOMPtr(pCreationIError);
			}
			throw ex;
		}
		hr = uwrepl_get_ErrorPointer(pIReplication, ref pIErrors);
		NativeMethods.CheckHRESULT(pIErrors, hr);
		NativeMethods.DllAddRef();
	}

	public SqlCeReplication(string internetUrl, string internetLogin, string internetPassword, string publisher, string publisherDatabase, string publisherLogin, string publisherPassword, string publication, string subscriber, string subscriberConnectionString)
	{
		NativeMethods.LoadNativeBinaries();
		pIReplication = new IntPtr(0);
		IntPtr pCreationIError = new IntPtr(0);
		int hr = uwrepl_Replication(ref pIReplication, ref pCreationIError);
		if (NativeMethods.Failed(hr))
		{
			SqlCeException ex = SqlCeException.FillErrorInformation(hr, pCreationIError);
			if (IntPtr.Zero != pCreationIError)
			{
				NativeMethods.uwutil_ReleaseCOMPtr(pCreationIError);
			}
			throw ex;
		}
		hr = uwrepl_get_ErrorPointer(pIReplication, ref pIErrors);
		NativeMethods.CheckHRESULT(pIErrors, hr);
		InternetUrl = internetUrl;
		InternetLogin = internetLogin;
		InternetPassword = internetPassword;
		Publisher = publisher;
		PublisherDatabase = publisherDatabase;
		PublisherLogin = publisherLogin;
		PublisherPassword = publisherPassword;
		Publication = publication;
		Subscriber = subscriber;
		SubscriberConnectionString = subscriberConnectionString;
		NativeMethods.DllAddRef();
	}

	public SqlCeReplication(string internetUrl, string internetLogin, string internetPassword, string publisher, string publisherDatabase, string publication, string subscriber, string subscriberConnectionString)
	{
		NativeMethods.LoadNativeBinaries();
		pIReplication = new IntPtr(0);
		IntPtr pCreationIError = new IntPtr(0);
		int hr = uwrepl_Replication(ref pIReplication, ref pCreationIError);
		if (NativeMethods.Failed(hr))
		{
			SqlCeException ex = SqlCeException.FillErrorInformation(hr, pCreationIError);
			if (IntPtr.Zero != pCreationIError)
			{
				NativeMethods.uwutil_ReleaseCOMPtr(pCreationIError);
			}
			throw ex;
		}
		hr = uwrepl_get_ErrorPointer(pIReplication, ref pIErrors);
		NativeMethods.CheckHRESULT(pIErrors, hr);
		InternetUrl = internetUrl;
		InternetLogin = internetLogin;
		InternetPassword = internetPassword;
		Publisher = publisher;
		PublisherDatabase = publisherDatabase;
		Publication = publication;
		Subscriber = subscriber;
		SubscriberConnectionString = subscriberConnectionString;
		PublisherSecurityMode = SecurityType.NTAuthentication;
		NativeMethods.DllAddRef();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~SqlCeReplication()
	{
		Dispose();
	}

	private void Dispose(bool disposing)
	{
		if (IntPtr.Zero != pIReplication)
		{
			NativeMethods.uwutil_ReleaseCOMPtr(pIReplication);
			pIReplication = IntPtr.Zero;
		}
		if (IntPtr.Zero != pIErrors)
		{
			NativeMethods.uwutil_ReleaseCOMPtr(pIErrors);
			pIErrors = IntPtr.Zero;
		}
		GC.KeepAlive(pIReplication);
		GC.KeepAlive(pIErrors);
		if (disposing)
		{
			NativeMethods.DllRelease();
		}
	}

	public void AddSubscription(AddOption addOption)
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		int hr = uwrepl_AddSubscription(pIReplication, addOption);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void DropSubscription(DropOption dropOption)
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		int hr = uwrepl_DropSubscription(pIReplication, dropOption);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void ReinitializeSubscription(bool uploadBeforeReinitialize)
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		int hr = uwrepl_ReinitializeSubscription(pIReplication, uploadBeforeReinitialize);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public void Synchronize()
	{
		int num = 0;
		bool flag = false;
		SqlCeException ex = null;
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		try
		{
			num = uwrepl_Initialize(pIReplication);
			NativeMethods.CheckHRESULT(pIErrors, num);
			num = uwrepl_Run(pIReplication);
			NativeMethods.CheckHRESULT(pIErrors, num);
		}
		catch (SqlCeException ex2)
		{
			flag = true;
			ex = ex2;
		}
		finally
		{
			num = uwrepl_Terminate(pIReplication);
			if (flag)
			{
				throw ex;
			}
			NativeMethods.CheckHRESULT(pIErrors, num);
		}
	}

	public IAsyncResult BeginSynchronize(AsyncCallback onSyncCompletion, object state)
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		SyncAsyncResult syncAsyncResult = new SyncAsyncResult(this, onSyncCompletion, state);
		ThreadStart start = syncAsyncResult.SyncThread;
		Thread thread = new Thread(start);
		thread.Start();
		return syncAsyncResult;
	}

	public IAsyncResult BeginSynchronize(AsyncCallback onSyncCompletion, OnStartTableUpload onStartTableUpload, OnStartTableDownload onStartTableDownload, OnSynchronization onSynchronization, object state)
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		SyncAsyncResult syncAsyncResult = new SyncAsyncResult(this, onSyncCompletion, onStartTableUpload, onStartTableDownload, onSynchronization, state);
		ThreadStart start = syncAsyncResult.SyncThread;
		Thread thread = new Thread(start);
		thread.Start();
		return syncAsyncResult;
	}

	public void EndSynchronize(IAsyncResult ar)
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		SyncAsyncResult syncAsyncResult = (SyncAsyncResult)ar;
		Exception exception = syncAsyncResult.GetException();
		if (exception != null)
		{
			throw exception;
		}
	}

	public void CancelSynchronize()
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		int hr = uwrepl_Cancel(pIReplication);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	public bool LoadProperties()
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		bool PasswordsLoaded = true;
		int hr = uwrepl_LoadProperties(pIReplication, ref PasswordsLoaded);
		NativeMethods.CheckHRESULT(pIErrors, hr);
		return PasswordsLoaded;
	}

	public void SaveProperties()
	{
		if (IntPtr.Zero == pIReplication)
		{
			throw new ObjectDisposedException("SqlCeReplication");
		}
		int hr = uwrepl_SaveProperties(pIReplication);
		NativeMethods.CheckHRESULT(pIErrors, hr);
	}

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_Replication(ref IntPtr pIReplication, ref IntPtr pCreationIError);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ErrorPointer(IntPtr pIReplication, ref IntPtr pIErrors);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_Distributor(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_Distributor(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string Distributor);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PostSyncCleanup(IntPtr pIReplication, ref short iCleanupType);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_PostSyncCleanup(IntPtr pIReplication, short iCleanupType);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_DistributorNetwork(IntPtr pIReplication, ref NetworkType DistributorNetwork);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_DistributorNetwork(IntPtr pIReplication, NetworkType DistributorNetwork);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_DistributorAddress(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_DistributorAddress(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string DistributorAddress);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_DistributorSecurityMode(IntPtr pIReplication, ref SecurityType DistributorSecurityMode);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_DistributorSecurityMode(IntPtr pIReplication, SecurityType DistributorSecurityMode);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_DistributorLogin(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_DistributorLogin(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string DistributorLogin);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_DistributorPassword(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_DistributorPassword(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string DistributorPassword);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ExchangeType(IntPtr pIReplication, ref ExchangeType ExchangeType);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ExchangeType(IntPtr pIReplication, ExchangeType ExchangeType);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_HostName(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_HostName(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string HostName);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_InternetUrl(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_InternetUrl(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string InternetUrl);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_InternetLogin(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_InternetLogin(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string InternetLogin);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_InternetPassword(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_InternetPassword(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string InternetPassword);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_InternetProxyServer(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_InternetProxyServer(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string InternetProxyServer);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_InternetProxyLogin(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_InternetProxyLogin(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string InternetProxyLogin);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_InternetProxyPassword(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_InternetProxyPassword(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string InternetProxyPassword);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_LoginTimeout(IntPtr pIReplication, ref ushort LoginTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_LoginTimeout(IntPtr pIReplication, ushort LoginTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ProfileName(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ProfileName(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string ProfileName);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_Publisher(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_Publisher(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string Publisher);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherNetwork(IntPtr pIReplication, ref NetworkType PublisherNetwork);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_PublisherNetwork(IntPtr pIReplication, NetworkType PublisherNetwork);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherAddress(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_PublisherAddress(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string PublisherAddress);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherSecurityMode(IntPtr pIReplication, ref SecurityType PublisherSecurityMode);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_PublisherSecurityMode(IntPtr pIReplication, SecurityType PublisherSecurityMode);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherLogin(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_PublisherLogin(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string PublisherLogin);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherPassword(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_PublisherPassword(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string PublisherPassword);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherDatabase(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_PublisherDatabase(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string PublisherDatabase);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_Publication(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_Publication(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string Publication);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherChanges(IntPtr pIReplication, ref int PublisherChanges);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_PublisherConflicts(IntPtr pIReplication, ref int PublisherConflicts);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_QueryTimeout(IntPtr pIReplication, ref ushort QueryTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_QueryTimeout(IntPtr pIReplication, ushort QueryTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_Subscriber(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_Subscriber(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string Subscriber);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_SubscriberConnectionString(IntPtr pIReplication, ref IntPtr rbz);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_SubscriberConnectionString(IntPtr pIReplication, [MarshalAs(UnmanagedType.LPWStr)] string SubscriberConnectionString);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_SubscriberChanges(IntPtr pIReplication, ref int SubscriberChanges);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_SubscriberConflicts(IntPtr pIReplication, ref int SubscriberConflicts);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_Validate(IntPtr pIReplication, ref ValidateType Validate);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_Validate(IntPtr pIReplication, ValidateType Validate);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ConnectTimeout(IntPtr pIReplication, ref int connectTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ConnectTimeout(IntPtr pIReplication, int connectTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_SendTimeout(IntPtr pIReplication, ref int SendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_SendTimeout(IntPtr pIReplication, int SendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ReceiveTimeout(IntPtr pIReplication, ref int ReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ReceiveTimeout(IntPtr pIReplication, int ReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_DataSendTimeout(IntPtr pIReplication, ref int DataSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_DataSendTimeout(IntPtr pIReplication, int DataSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_DataReceiveTimeout(IntPtr pIReplication, ref int DataReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_DataReceiveTimeout(IntPtr pIReplication, int DataReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ControlSendTimeout(IntPtr pIReplication, ref int ControlSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ControlSendTimeout(IntPtr pIReplication, int ControlSendTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ControlReceiveTimeout(IntPtr pIReplication, ref int ControlReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ControlReceiveTimeout(IntPtr pIReplication, int ControlReceiveTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ConnectionRetryTimeout(IntPtr pIReplication, ref ushort ConnectionRetryTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ConnectionRetryTimeout(IntPtr pIReplication, ushort ConnectionRetryTimeout);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_CompressionLevel(IntPtr pIReplication, ref ushort CompressionLevel);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_CompressionLevel(IntPtr pIReplication, ushort CompressionLevel);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_ConnectionManager(IntPtr pIReplication, ref bool ConnectionManager);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_ConnectionManager(IntPtr pIReplication, bool ConnectionManager);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_get_SnapshotTransferType(IntPtr pIReplication, ref SnapshotTransferType SnapshotTransferType);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_put_SnapshotTransferType(IntPtr pIReplication, SnapshotTransferType SnapshotTransferType);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_AddSubscription(IntPtr pIReplication, AddOption addOption);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_DropSubscription(IntPtr pIReplication, DropOption dropOption);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_ReinitializeSubscription(IntPtr pIReplication, bool uploadBeforeReinit);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_Initialize(IntPtr pIReplication);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_Run(IntPtr pIReplication);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_Terminate(IntPtr pIReplication);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_Cancel(IntPtr pIReplication);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_LoadProperties(IntPtr pIReplication, ref bool PasswordsLoaded);

	[DllImport("sqlceme35.dll")]
	private static extern int uwrepl_SaveProperties(IntPtr pIReplication);
}
