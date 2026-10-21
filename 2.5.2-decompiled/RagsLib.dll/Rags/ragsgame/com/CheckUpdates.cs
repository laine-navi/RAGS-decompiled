using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Rags.Properties;

namespace Rags.ragsgame.com;

[DesignerCategory("code")]
[GeneratedCode("System.Web.Services", "4.6.1586.0")]
[DebuggerStepThrough]
[XmlInclude(typeof(object[]))]
[WebServiceBinding(Name = "CheckUpdatesSoap", Namespace = "http://tempuri.org/")]
public class CheckUpdates : SoapHttpClientProtocol
{
	private SendOrPostCallback m_a;

	private SendOrPostCallback m_b;

	private SendOrPostCallback m_c;

	private SendOrPostCallback m_d;

	private SendOrPostCallback m_e;

	private SendOrPostCallback m_f;

	private bool g;

	[CompilerGenerated]
	private CheckVersionCompletedEventHandler h;

	[CompilerGenerated]
	private RegisterCompletedEventHandler i;

	[CompilerGenerated]
	private GetShareDataSummaryCompletedEventHandler j;

	[CompilerGenerated]
	private DownloadShareCompletedEventHandler k;

	[CompilerGenerated]
	private UploadShareCompletedEventHandler l;

	[CompilerGenerated]
	private RemoveShareCompletedEventHandler m;

	public string Url
	{
		get
		{
			return ((WebClientProtocol)this).Url;
		}
		set
		{
			if (a(((WebClientProtocol)this).Url) && !g && !a(value))
			{
				((WebClientProtocol)this).UseDefaultCredentials = false;
			}
			((WebClientProtocol)this).Url = value;
		}
	}

	public bool UseDefaultCredentials
	{
		get
		{
			return ((WebClientProtocol)this).UseDefaultCredentials;
		}
		set
		{
			((WebClientProtocol)this).UseDefaultCredentials = value;
			g = true;
		}
	}

	public event CheckVersionCompletedEventHandler CheckVersionCompleted
	{
		[CompilerGenerated]
		add
		{
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler = h;
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler2;
			do
			{
				checkVersionCompletedEventHandler2 = checkVersionCompletedEventHandler;
				CheckVersionCompletedEventHandler value2 = (CheckVersionCompletedEventHandler)Delegate.Combine(checkVersionCompletedEventHandler2, value);
				checkVersionCompletedEventHandler = Interlocked.CompareExchange(ref h, value2, checkVersionCompletedEventHandler2);
			}
			while ((object)checkVersionCompletedEventHandler != checkVersionCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler = h;
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler2;
			do
			{
				checkVersionCompletedEventHandler2 = checkVersionCompletedEventHandler;
				CheckVersionCompletedEventHandler value2 = (CheckVersionCompletedEventHandler)Delegate.Remove(checkVersionCompletedEventHandler2, value);
				checkVersionCompletedEventHandler = Interlocked.CompareExchange(ref h, value2, checkVersionCompletedEventHandler2);
			}
			while ((object)checkVersionCompletedEventHandler != checkVersionCompletedEventHandler2);
		}
	}

	public event RegisterCompletedEventHandler RegisterCompleted
	{
		[CompilerGenerated]
		add
		{
			RegisterCompletedEventHandler registerCompletedEventHandler = i;
			RegisterCompletedEventHandler registerCompletedEventHandler2;
			do
			{
				registerCompletedEventHandler2 = registerCompletedEventHandler;
				RegisterCompletedEventHandler value2 = (RegisterCompletedEventHandler)Delegate.Combine(registerCompletedEventHandler2, value);
				registerCompletedEventHandler = Interlocked.CompareExchange(ref i, value2, registerCompletedEventHandler2);
			}
			while ((object)registerCompletedEventHandler != registerCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RegisterCompletedEventHandler registerCompletedEventHandler = i;
			RegisterCompletedEventHandler registerCompletedEventHandler2;
			do
			{
				registerCompletedEventHandler2 = registerCompletedEventHandler;
				RegisterCompletedEventHandler value2 = (RegisterCompletedEventHandler)Delegate.Remove(registerCompletedEventHandler2, value);
				registerCompletedEventHandler = Interlocked.CompareExchange(ref i, value2, registerCompletedEventHandler2);
			}
			while ((object)registerCompletedEventHandler != registerCompletedEventHandler2);
		}
	}

	public event GetShareDataSummaryCompletedEventHandler GetShareDataSummaryCompleted
	{
		[CompilerGenerated]
		add
		{
			GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler = j;
			GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler2;
			do
			{
				getShareDataSummaryCompletedEventHandler2 = getShareDataSummaryCompletedEventHandler;
				GetShareDataSummaryCompletedEventHandler value2 = (GetShareDataSummaryCompletedEventHandler)Delegate.Combine(getShareDataSummaryCompletedEventHandler2, value);
				getShareDataSummaryCompletedEventHandler = Interlocked.CompareExchange(ref j, value2, getShareDataSummaryCompletedEventHandler2);
			}
			while ((object)getShareDataSummaryCompletedEventHandler != getShareDataSummaryCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler = j;
			GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler2;
			do
			{
				getShareDataSummaryCompletedEventHandler2 = getShareDataSummaryCompletedEventHandler;
				GetShareDataSummaryCompletedEventHandler value2 = (GetShareDataSummaryCompletedEventHandler)Delegate.Remove(getShareDataSummaryCompletedEventHandler2, value);
				getShareDataSummaryCompletedEventHandler = Interlocked.CompareExchange(ref j, value2, getShareDataSummaryCompletedEventHandler2);
			}
			while ((object)getShareDataSummaryCompletedEventHandler != getShareDataSummaryCompletedEventHandler2);
		}
	}

	public event DownloadShareCompletedEventHandler DownloadShareCompleted
	{
		[CompilerGenerated]
		add
		{
			DownloadShareCompletedEventHandler downloadShareCompletedEventHandler = k;
			DownloadShareCompletedEventHandler downloadShareCompletedEventHandler2;
			do
			{
				downloadShareCompletedEventHandler2 = downloadShareCompletedEventHandler;
				DownloadShareCompletedEventHandler value2 = (DownloadShareCompletedEventHandler)Delegate.Combine(downloadShareCompletedEventHandler2, value);
				downloadShareCompletedEventHandler = Interlocked.CompareExchange(ref k, value2, downloadShareCompletedEventHandler2);
			}
			while ((object)downloadShareCompletedEventHandler != downloadShareCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			DownloadShareCompletedEventHandler downloadShareCompletedEventHandler = k;
			DownloadShareCompletedEventHandler downloadShareCompletedEventHandler2;
			do
			{
				downloadShareCompletedEventHandler2 = downloadShareCompletedEventHandler;
				DownloadShareCompletedEventHandler value2 = (DownloadShareCompletedEventHandler)Delegate.Remove(downloadShareCompletedEventHandler2, value);
				downloadShareCompletedEventHandler = Interlocked.CompareExchange(ref k, value2, downloadShareCompletedEventHandler2);
			}
			while ((object)downloadShareCompletedEventHandler != downloadShareCompletedEventHandler2);
		}
	}

	public event UploadShareCompletedEventHandler UploadShareCompleted
	{
		[CompilerGenerated]
		add
		{
			UploadShareCompletedEventHandler uploadShareCompletedEventHandler = l;
			UploadShareCompletedEventHandler uploadShareCompletedEventHandler2;
			do
			{
				uploadShareCompletedEventHandler2 = uploadShareCompletedEventHandler;
				UploadShareCompletedEventHandler value2 = (UploadShareCompletedEventHandler)Delegate.Combine(uploadShareCompletedEventHandler2, value);
				uploadShareCompletedEventHandler = Interlocked.CompareExchange(ref l, value2, uploadShareCompletedEventHandler2);
			}
			while ((object)uploadShareCompletedEventHandler != uploadShareCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			UploadShareCompletedEventHandler uploadShareCompletedEventHandler = l;
			UploadShareCompletedEventHandler uploadShareCompletedEventHandler2;
			do
			{
				uploadShareCompletedEventHandler2 = uploadShareCompletedEventHandler;
				UploadShareCompletedEventHandler value2 = (UploadShareCompletedEventHandler)Delegate.Remove(uploadShareCompletedEventHandler2, value);
				uploadShareCompletedEventHandler = Interlocked.CompareExchange(ref l, value2, uploadShareCompletedEventHandler2);
			}
			while ((object)uploadShareCompletedEventHandler != uploadShareCompletedEventHandler2);
		}
	}

	public event RemoveShareCompletedEventHandler RemoveShareCompleted
	{
		[CompilerGenerated]
		add
		{
			RemoveShareCompletedEventHandler removeShareCompletedEventHandler = m;
			RemoveShareCompletedEventHandler removeShareCompletedEventHandler2;
			do
			{
				removeShareCompletedEventHandler2 = removeShareCompletedEventHandler;
				RemoveShareCompletedEventHandler value2 = (RemoveShareCompletedEventHandler)Delegate.Combine(removeShareCompletedEventHandler2, value);
				removeShareCompletedEventHandler = Interlocked.CompareExchange(ref m, value2, removeShareCompletedEventHandler2);
			}
			while ((object)removeShareCompletedEventHandler != removeShareCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RemoveShareCompletedEventHandler removeShareCompletedEventHandler = m;
			RemoveShareCompletedEventHandler removeShareCompletedEventHandler2;
			do
			{
				removeShareCompletedEventHandler2 = removeShareCompletedEventHandler;
				RemoveShareCompletedEventHandler value2 = (RemoveShareCompletedEventHandler)Delegate.Remove(removeShareCompletedEventHandler2, value);
				removeShareCompletedEventHandler = Interlocked.CompareExchange(ref m, value2, removeShareCompletedEventHandler2);
			}
			while ((object)removeShareCompletedEventHandler != removeShareCompletedEventHandler2);
		}
	}

	public CheckUpdates()
	{
		Url = Settings.Default.RagsLib_www_ragsgame_com_CheckUpdates;
		if (a(Url))
		{
			UseDefaultCredentials = true;
			g = false;
		}
		else
		{
			g = true;
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public string CheckVersion()
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("CheckVersion", new object[0])[0];
	}

	public void CheckVersionAsync()
	{
		CheckVersionAsync(null);
	}

	public void CheckVersionAsync(object userState)
	{
		if (this.m_a == null)
		{
			this.m_a = f;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("CheckVersion", new object[0], this.m_a, userState);
	}

	private void f(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (h != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			h(this, new CheckVersionCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public RegData Register(string key, string email, string id)
	{
		return (RegData)((SoapHttpClientProtocol)this).Invoke("Register", new object[3] { key, email, id })[0];
	}

	public void RegisterAsync(string key, string email, string id)
	{
		RegisterAsync(key, email, id, null);
	}

	public void RegisterAsync(string key, string email, string id, object userState)
	{
		if (this.m_b == null)
		{
			this.m_b = e;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Register", new object[3] { key, email, id }, this.m_b, userState);
	}

	private void e(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (i != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			i(this, new RegisterCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public object[] GetShareDataSummary()
	{
		return (object[])((SoapHttpClientProtocol)this).Invoke("GetShareDataSummary", new object[0])[0];
	}

	public void GetShareDataSummaryAsync()
	{
		GetShareDataSummaryAsync(null);
	}

	public void GetShareDataSummaryAsync(object userState)
	{
		if (this.m_c == null)
		{
			this.m_c = d;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("GetShareDataSummary", new object[0], this.m_c, userState);
	}

	private void d(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (j != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			j(this, new GetShareDataSummaryCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(DataType = "base64Binary")]
	public byte[] DownloadShare(int index)
	{
		return (byte[])((SoapHttpClientProtocol)this).Invoke("DownloadShare", new object[1] { index })[0];
	}

	public void DownloadShareAsync(int index)
	{
		DownloadShareAsync(index, null);
	}

	public void DownloadShareAsync(int index, object userState)
	{
		if (this.m_d == null)
		{
			this.m_d = c;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("DownloadShare", new object[1] { index }, this.m_d, userState);
	}

	private void c(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (k != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			k(this, new DownloadShareCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void UploadShare(ShareData TheShare, [XmlElement(DataType = "base64Binary")] byte[] TheData, string key, string ragsversion)
	{
		((SoapHttpClientProtocol)this).Invoke("UploadShare", new object[4] { TheShare, TheData, key, ragsversion });
	}

	public void UploadShareAsync(ShareData TheShare, byte[] TheData, string key, string ragsversion)
	{
		UploadShareAsync(TheShare, TheData, key, ragsversion, null);
	}

	public void UploadShareAsync(ShareData TheShare, byte[] TheData, string key, string ragsversion, object userState)
	{
		if (this.m_e == null)
		{
			this.m_e = b;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("UploadShare", new object[4] { TheShare, TheData, key, ragsversion }, this.m_e, userState);
	}

	private void b(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (l != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			l(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void RemoveShare(int index, string useremail, string key)
	{
		((SoapHttpClientProtocol)this).Invoke("RemoveShare", new object[3] { index, useremail, key });
	}

	public void RemoveShareAsync(int index, string useremail, string key)
	{
		RemoveShareAsync(index, useremail, key, null);
	}

	public void RemoveShareAsync(int index, string useremail, string key, object userState)
	{
		if (this.m_f == null)
		{
			this.m_f = a;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("RemoveShare", new object[3] { index, useremail, key }, this.m_f, userState);
	}

	private void a(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (m != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			m(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	public void CancelAsync(object userState)
	{
		((HttpWebClientProtocol)this).CancelAsync(userState);
	}

	private bool a(string A_0)
	{
		if (A_0 == null || A_0 == string.Empty)
		{
			return false;
		}
		Uri uri = new Uri(A_0);
		if (uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		return false;
	}
}
