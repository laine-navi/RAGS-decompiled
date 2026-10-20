using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using A;
using Rags.Properties;

namespace Rags.ragsgame.com;

[DesignerCategory("code")]
[GeneratedCode("System.Web.Services", "4.0.30319.1")]
[WebServiceBinding(Name = "CheckUpdatesSoap", Namespace = "http://tempuri.org/")]
[DebuggerStepThrough]
[XmlInclude(typeof(object[]))]
public sealed class CheckUpdates : SoapHttpClientProtocol
{
	private SendOrPostCallback ce141ef675c49651805fd3a2ffec4d073;

	private SendOrPostCallback cfbcd72984154829ea413b5c74650cdca;

	private SendOrPostCallback c0d19650fe0692ba75d3eb051ed052db5;

	private SendOrPostCallback cf4558facb90046bc47a57c017d559d8c;

	private SendOrPostCallback c63b12a21ee3665fcb739851b9e3f189c;

	private SendOrPostCallback cf449e2c1d71ceed3788d82c55d0e1441;

	private bool c48cb13480daa01dbcac6b738f9b223bc;

	private CheckVersionCompletedEventHandler cb5f1db8cd9a1ae94a4fffc5908c8ef40;

	private RegisterCompletedEventHandler ce8491f4c59aab3e04e6ea20c39e363c2;

	private GetShareDataSummaryCompletedEventHandler cf2ead3d3327d6ce01c6c1e2a47c656b9;

	private DownloadShareCompletedEventHandler c586897bc779b265de3b532e1247e9f9a;

	private UploadShareCompletedEventHandler c324589b9ccecb3b5b439c9e86eacc3eb;

	private RemoveShareCompletedEventHandler cf106599ee30257046e51b29e408b6c2d;

	public string Url
	{
		get
		{
			return ((WebClientProtocol)this).Url;
		}
		set
		{
			if (!c8b171de9f4a2e057be795c6174a15a5a(((WebClientProtocol)this).Url))
			{
				__ldtoken(CheckUpdates.set_Url(string));
			}
			else if (c48cb13480daa01dbcac6b738f9b223bc)
			{
				__ldtoken(CheckUpdates.set_Url(string));
			}
			else if (c8b171de9f4a2e057be795c6174a15a5a(value))
			{
				__ldtoken(CheckUpdates.set_Url(string));
			}
			else
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
			c48cb13480daa01dbcac6b738f9b223bc = true;
		}
	}

	public event CheckVersionCompletedEventHandler CheckVersionCompleted
	{
		add
		{
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler = cb5f1db8cd9a1ae94a4fffc5908c8ef40;
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler2;
			do
			{
				checkVersionCompletedEventHandler2 = checkVersionCompletedEventHandler;
				CheckVersionCompletedEventHandler value2 = (CheckVersionCompletedEventHandler)Delegate.Combine(checkVersionCompletedEventHandler2, value);
				checkVersionCompletedEventHandler = Interlocked.CompareExchange(ref cb5f1db8cd9a1ae94a4fffc5908c8ef40, value2, checkVersionCompletedEventHandler2);
			}
			while ((object)checkVersionCompletedEventHandler != checkVersionCompletedEventHandler2);
		}
		remove
		{
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler = cb5f1db8cd9a1ae94a4fffc5908c8ef40;
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler2;
			do
			{
				checkVersionCompletedEventHandler2 = checkVersionCompletedEventHandler;
				CheckVersionCompletedEventHandler value2 = (CheckVersionCompletedEventHandler)Delegate.Remove(checkVersionCompletedEventHandler2, value);
				checkVersionCompletedEventHandler = Interlocked.CompareExchange(ref cb5f1db8cd9a1ae94a4fffc5908c8ef40, value2, checkVersionCompletedEventHandler2);
			}
			while ((object)checkVersionCompletedEventHandler != checkVersionCompletedEventHandler2);
		}
	}

	public event RegisterCompletedEventHandler RegisterCompleted
	{
		add
		{
			RegisterCompletedEventHandler registerCompletedEventHandler = ce8491f4c59aab3e04e6ea20c39e363c2;
			while (true)
			{
				RegisterCompletedEventHandler registerCompletedEventHandler2 = registerCompletedEventHandler;
				RegisterCompletedEventHandler value2 = (RegisterCompletedEventHandler)Delegate.Combine(registerCompletedEventHandler2, value);
				registerCompletedEventHandler = Interlocked.CompareExchange(ref ce8491f4c59aab3e04e6ea20c39e363c2, value2, registerCompletedEventHandler2);
				if ((object)registerCompletedEventHandler == registerCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.add_RegisterCompleted(RegisterCompletedEventHandler));
			}
		}
		remove
		{
			RegisterCompletedEventHandler registerCompletedEventHandler = ce8491f4c59aab3e04e6ea20c39e363c2;
			while (true)
			{
				RegisterCompletedEventHandler registerCompletedEventHandler2 = registerCompletedEventHandler;
				RegisterCompletedEventHandler value2 = (RegisterCompletedEventHandler)Delegate.Remove(registerCompletedEventHandler2, value);
				registerCompletedEventHandler = Interlocked.CompareExchange(ref ce8491f4c59aab3e04e6ea20c39e363c2, value2, registerCompletedEventHandler2);
				if ((object)registerCompletedEventHandler == registerCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.remove_RegisterCompleted(RegisterCompletedEventHandler));
			}
		}
	}

	public event GetShareDataSummaryCompletedEventHandler GetShareDataSummaryCompleted
	{
		add
		{
			GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler = cf2ead3d3327d6ce01c6c1e2a47c656b9;
			while (true)
			{
				GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler2 = getShareDataSummaryCompletedEventHandler;
				GetShareDataSummaryCompletedEventHandler value2 = (GetShareDataSummaryCompletedEventHandler)Delegate.Combine(getShareDataSummaryCompletedEventHandler2, value);
				getShareDataSummaryCompletedEventHandler = Interlocked.CompareExchange(ref cf2ead3d3327d6ce01c6c1e2a47c656b9, value2, getShareDataSummaryCompletedEventHandler2);
				if ((object)getShareDataSummaryCompletedEventHandler == getShareDataSummaryCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.add_GetShareDataSummaryCompleted(GetShareDataSummaryCompletedEventHandler));
			}
		}
		remove
		{
			GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler = cf2ead3d3327d6ce01c6c1e2a47c656b9;
			GetShareDataSummaryCompletedEventHandler getShareDataSummaryCompletedEventHandler2;
			do
			{
				getShareDataSummaryCompletedEventHandler2 = getShareDataSummaryCompletedEventHandler;
				GetShareDataSummaryCompletedEventHandler value2 = (GetShareDataSummaryCompletedEventHandler)Delegate.Remove(getShareDataSummaryCompletedEventHandler2, value);
				getShareDataSummaryCompletedEventHandler = Interlocked.CompareExchange(ref cf2ead3d3327d6ce01c6c1e2a47c656b9, value2, getShareDataSummaryCompletedEventHandler2);
			}
			while ((object)getShareDataSummaryCompletedEventHandler != getShareDataSummaryCompletedEventHandler2);
		}
	}

	public event DownloadShareCompletedEventHandler DownloadShareCompleted
	{
		add
		{
			DownloadShareCompletedEventHandler downloadShareCompletedEventHandler = c586897bc779b265de3b532e1247e9f9a;
			while (true)
			{
				DownloadShareCompletedEventHandler downloadShareCompletedEventHandler2 = downloadShareCompletedEventHandler;
				DownloadShareCompletedEventHandler value2 = (DownloadShareCompletedEventHandler)Delegate.Combine(downloadShareCompletedEventHandler2, value);
				downloadShareCompletedEventHandler = Interlocked.CompareExchange(ref c586897bc779b265de3b532e1247e9f9a, value2, downloadShareCompletedEventHandler2);
				if ((object)downloadShareCompletedEventHandler == downloadShareCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.add_DownloadShareCompleted(DownloadShareCompletedEventHandler));
			}
		}
		remove
		{
			DownloadShareCompletedEventHandler downloadShareCompletedEventHandler = c586897bc779b265de3b532e1247e9f9a;
			while (true)
			{
				DownloadShareCompletedEventHandler downloadShareCompletedEventHandler2 = downloadShareCompletedEventHandler;
				DownloadShareCompletedEventHandler value2 = (DownloadShareCompletedEventHandler)Delegate.Remove(downloadShareCompletedEventHandler2, value);
				downloadShareCompletedEventHandler = Interlocked.CompareExchange(ref c586897bc779b265de3b532e1247e9f9a, value2, downloadShareCompletedEventHandler2);
				if ((object)downloadShareCompletedEventHandler == downloadShareCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.remove_DownloadShareCompleted(DownloadShareCompletedEventHandler));
			}
		}
	}

	public event UploadShareCompletedEventHandler UploadShareCompleted
	{
		add
		{
			UploadShareCompletedEventHandler uploadShareCompletedEventHandler = c324589b9ccecb3b5b439c9e86eacc3eb;
			while (true)
			{
				UploadShareCompletedEventHandler uploadShareCompletedEventHandler2 = uploadShareCompletedEventHandler;
				UploadShareCompletedEventHandler value2 = (UploadShareCompletedEventHandler)Delegate.Combine(uploadShareCompletedEventHandler2, value);
				uploadShareCompletedEventHandler = Interlocked.CompareExchange(ref c324589b9ccecb3b5b439c9e86eacc3eb, value2, uploadShareCompletedEventHandler2);
				if ((object)uploadShareCompletedEventHandler == uploadShareCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.add_UploadShareCompleted(UploadShareCompletedEventHandler));
			}
		}
		remove
		{
			UploadShareCompletedEventHandler uploadShareCompletedEventHandler = c324589b9ccecb3b5b439c9e86eacc3eb;
			while (true)
			{
				UploadShareCompletedEventHandler uploadShareCompletedEventHandler2 = uploadShareCompletedEventHandler;
				UploadShareCompletedEventHandler value2 = (UploadShareCompletedEventHandler)Delegate.Remove(uploadShareCompletedEventHandler2, value);
				uploadShareCompletedEventHandler = Interlocked.CompareExchange(ref c324589b9ccecb3b5b439c9e86eacc3eb, value2, uploadShareCompletedEventHandler2);
				if ((object)uploadShareCompletedEventHandler == uploadShareCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.remove_UploadShareCompleted(UploadShareCompletedEventHandler));
			}
		}
	}

	public event RemoveShareCompletedEventHandler RemoveShareCompleted
	{
		add
		{
			RemoveShareCompletedEventHandler removeShareCompletedEventHandler = cf106599ee30257046e51b29e408b6c2d;
			while (true)
			{
				RemoveShareCompletedEventHandler removeShareCompletedEventHandler2 = removeShareCompletedEventHandler;
				RemoveShareCompletedEventHandler value2 = (RemoveShareCompletedEventHandler)Delegate.Combine(removeShareCompletedEventHandler2, value);
				removeShareCompletedEventHandler = Interlocked.CompareExchange(ref cf106599ee30257046e51b29e408b6c2d, value2, removeShareCompletedEventHandler2);
				if ((object)removeShareCompletedEventHandler == removeShareCompletedEventHandler2)
				{
					break;
				}
				__ldtoken(CheckUpdates.add_RemoveShareCompleted(RemoveShareCompletedEventHandler));
			}
		}
		remove
		{
			RemoveShareCompletedEventHandler removeShareCompletedEventHandler = cf106599ee30257046e51b29e408b6c2d;
			RemoveShareCompletedEventHandler removeShareCompletedEventHandler2;
			do
			{
				removeShareCompletedEventHandler2 = removeShareCompletedEventHandler;
				RemoveShareCompletedEventHandler value2 = (RemoveShareCompletedEventHandler)Delegate.Remove(removeShareCompletedEventHandler2, value);
				removeShareCompletedEventHandler = Interlocked.CompareExchange(ref cf106599ee30257046e51b29e408b6c2d, value2, removeShareCompletedEventHandler2);
			}
			while ((object)removeShareCompletedEventHandler != removeShareCompletedEventHandler2);
		}
	}

	public CheckUpdates()
	{
		Url = Settings.Default.Rags_ragsgame_com_CheckUpdates;
		if (!c8b171de9f4a2e057be795c6174a15a5a(Url))
		{
			__ldtoken(CheckUpdates._002Ector());
			c48cb13480daa01dbcac6b738f9b223bc = true;
		}
		else
		{
			UseDefaultCredentials = true;
			c48cb13480daa01dbcac6b738f9b223bc = false;
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public string CheckVersion()
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1547), new object[0]);
		return (string)array[0];
	}

	public void CheckVersionAsync()
	{
		CheckVersionAsync(null);
	}

	public void CheckVersionAsync(object userState)
	{
		if (ce141ef675c49651805fd3a2ffec4d073 == null)
		{
			ce141ef675c49651805fd3a2ffec4d073 = c85307dca56c35480e2418b93667eb102;
		}
		((SoapHttpClientProtocol)this).InvokeAsync(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1547), new object[0], ce141ef675c49651805fd3a2ffec4d073, userState);
	}

	private void c85307dca56c35480e2418b93667eb102(object P_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (cb5f1db8cd9a1ae94a4fffc5908c8ef40 == null)
		{
			__ldtoken(CheckUpdates.c85307dca56c35480e2418b93667eb102(object));
			return;
		}
		InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)P_0;
		cb5f1db8cd9a1ae94a4fffc5908c8ef40(this, new CheckVersionCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public RegData Register(string key, string email, string id)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1572), new object[3] { key, email, id });
		return (RegData)array[0];
	}

	public void RegisterAsync(string key, string email, string id)
	{
		RegisterAsync(key, email, id, null);
	}

	public void RegisterAsync(string key, string email, string id, object userState)
	{
		if (cfbcd72984154829ea413b5c74650cdca == null)
		{
			cfbcd72984154829ea413b5c74650cdca = cab9493f86ffd79f603520e1a96543369;
		}
		((SoapHttpClientProtocol)this).InvokeAsync(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1572), new object[3] { key, email, id }, cfbcd72984154829ea413b5c74650cdca, userState);
	}

	private void cab9493f86ffd79f603520e1a96543369(object P_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (ce8491f4c59aab3e04e6ea20c39e363c2 == null)
		{
			__ldtoken(CheckUpdates.cab9493f86ffd79f603520e1a96543369(object));
			return;
		}
		InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)P_0;
		ce8491f4c59aab3e04e6ea20c39e363c2(this, new RegisterCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public object[] GetShareDataSummary()
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1589), new object[0]);
		return (object[])array[0];
	}

	public void GetShareDataSummaryAsync()
	{
		GetShareDataSummaryAsync(null);
	}

	public void GetShareDataSummaryAsync(object userState)
	{
		if (c0d19650fe0692ba75d3eb051ed052db5 == null)
		{
			c0d19650fe0692ba75d3eb051ed052db5 = cea682fc745b2b0bf757ea6eb60635336;
		}
		((SoapHttpClientProtocol)this).InvokeAsync(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1589), new object[0], c0d19650fe0692ba75d3eb051ed052db5, userState);
	}

	private void cea682fc745b2b0bf757ea6eb60635336(object P_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (cf2ead3d3327d6ce01c6c1e2a47c656b9 == null)
		{
			__ldtoken(CheckUpdates.cea682fc745b2b0bf757ea6eb60635336(object));
			return;
		}
		InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)P_0;
		cf2ead3d3327d6ce01c6c1e2a47c656b9(this, new GetShareDataSummaryCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(DataType = "base64Binary")]
	public byte[] DownloadShare(int index)
	{
		object[] array = ((SoapHttpClientProtocol)this).Invoke(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1628), new object[1] { index });
		return (byte[])array[0];
	}

	public void DownloadShareAsync(int index)
	{
		DownloadShareAsync(index, null);
	}

	public void DownloadShareAsync(int index, object userState)
	{
		if (cf4558facb90046bc47a57c017d559d8c != null)
		{
			__ldtoken(CheckUpdates.DownloadShareAsync(int, object));
		}
		else
		{
			cf4558facb90046bc47a57c017d559d8c = cd1a23a48f65a2c82fa3b05a01bf90fa6;
		}
		((SoapHttpClientProtocol)this).InvokeAsync(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1628), new object[1] { index }, cf4558facb90046bc47a57c017d559d8c, userState);
	}

	private void cd1a23a48f65a2c82fa3b05a01bf90fa6(object P_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (c586897bc779b265de3b532e1247e9f9a == null)
		{
			__ldtoken(CheckUpdates.cd1a23a48f65a2c82fa3b05a01bf90fa6(object));
			return;
		}
		InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)P_0;
		c586897bc779b265de3b532e1247e9f9a(this, new DownloadShareCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void UploadShare(ShareData TheShare, [XmlElement(DataType = "base64Binary")] byte[] TheData, string key)
	{
		((SoapHttpClientProtocol)this).Invoke(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1655), new object[3] { TheShare, TheData, key });
	}

	public void UploadShareAsync(ShareData TheShare, byte[] TheData, string key)
	{
		UploadShareAsync(TheShare, TheData, key, null);
	}

	public void UploadShareAsync(ShareData TheShare, byte[] TheData, string key, object userState)
	{
		if (c63b12a21ee3665fcb739851b9e3f189c != null)
		{
			__ldtoken(CheckUpdates.UploadShareAsync(ShareData, byte[], string, object));
		}
		else
		{
			c63b12a21ee3665fcb739851b9e3f189c = c2387c7763ab7861e94dc80bc26801d0b;
		}
		((SoapHttpClientProtocol)this).InvokeAsync(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1655), new object[3] { TheShare, TheData, key }, c63b12a21ee3665fcb739851b9e3f189c, userState);
	}

	private void c2387c7763ab7861e94dc80bc26801d0b(object P_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (c324589b9ccecb3b5b439c9e86eacc3eb == null)
		{
			__ldtoken(CheckUpdates.c2387c7763ab7861e94dc80bc26801d0b(object));
			return;
		}
		InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)P_0;
		c324589b9ccecb3b5b439c9e86eacc3eb(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void RemoveShare(int index, string useremail, string key)
	{
		((SoapHttpClientProtocol)this).Invoke(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1678), new object[3] { index, useremail, key });
	}

	public void RemoveShareAsync(int index, string useremail, string key)
	{
		RemoveShareAsync(index, useremail, key, null);
	}

	public void RemoveShareAsync(int index, string useremail, string key, object userState)
	{
		if (cf449e2c1d71ceed3788d82c55d0e1441 != null)
		{
			__ldtoken(CheckUpdates.RemoveShareAsync(int, string, string, object));
		}
		else
		{
			cf449e2c1d71ceed3788d82c55d0e1441 = c7b2b0df8bb95370d9a94e5838e4d8ab3;
		}
		((SoapHttpClientProtocol)this).InvokeAsync(cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1678), new object[3] { index, useremail, key }, cf449e2c1d71ceed3788d82c55d0e1441, userState);
	}

	private void c7b2b0df8bb95370d9a94e5838e4d8ab3(object P_0)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		if (cf106599ee30257046e51b29e408b6c2d == null)
		{
			__ldtoken(CheckUpdates.c7b2b0df8bb95370d9a94e5838e4d8ab3(object));
			return;
		}
		InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)P_0;
		cf106599ee30257046e51b29e408b6c2d(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
	}

	public void CancelAsync(object userState)
	{
		((HttpWebClientProtocol)this).CancelAsync(userState);
	}

	private bool c8b171de9f4a2e057be795c6174a15a5a(string P_0)
	{
		if (P_0 == null)
		{
			__ldtoken(CheckUpdates.c8b171de9f4a2e057be795c6174a15a5a(string));
		}
		else if (!(P_0 == string.Empty))
		{
			__ldtoken(CheckUpdates.c8b171de9f4a2e057be795c6174a15a5a(string));
			Uri uri = new Uri(P_0);
			if (uri.Port < 1024)
			{
				__ldtoken(CheckUpdates.c8b171de9f4a2e057be795c6174a15a5a(string));
			}
			else
			{
				if (string.Compare(uri.Host, cad404c1fb42ece56868c101a14679d0a.cd2153e78b9a71234f45fec6fab6c38be(1701), StringComparison.OrdinalIgnoreCase) == 0)
				{
					return true;
				}
				__ldtoken(CheckUpdates.c8b171de9f4a2e057be795c6174a15a5a(string));
			}
			return false;
		}
		return false;
	}
}
