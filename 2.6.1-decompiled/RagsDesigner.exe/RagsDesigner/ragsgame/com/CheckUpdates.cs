using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using RagsDesigner.Properties;

namespace RagsDesigner.ragsgame.com;

[DesignerCategory("code")]
[GeneratedCode("System.Web.Services", "4.6.1586.0")]
[WebServiceBinding(Name = "CheckUpdatesSoap", Namespace = "http://tempuri.org/")]
[DebuggerStepThrough]
public class CheckUpdates : SoapHttpClientProtocol
{
	private SendOrPostCallback m_a;

	private SendOrPostCallback m_b;

	private SendOrPostCallback m_c;

	private SendOrPostCallback m_d;

	private bool e;

	[CompilerGenerated]
	private HelloWorldCompletedEventHandler f;

	[CompilerGenerated]
	private CheckVersionCompletedEventHandler g;

	[CompilerGenerated]
	private CheckBetaVersionCompletedEventHandler h;

	[CompilerGenerated]
	private RegisterCompletedEventHandler i;

	public string Url
	{
		get
		{
			return ((WebClientProtocol)this).Url;
		}
		set
		{
			if (a(((WebClientProtocol)this).Url) && !e && !a(value))
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
			e = true;
		}
	}

	public event HelloWorldCompletedEventHandler HelloWorldCompleted
	{
		[CompilerGenerated]
		add
		{
			HelloWorldCompletedEventHandler helloWorldCompletedEventHandler = f;
			HelloWorldCompletedEventHandler helloWorldCompletedEventHandler2;
			do
			{
				helloWorldCompletedEventHandler2 = helloWorldCompletedEventHandler;
				HelloWorldCompletedEventHandler value2 = (HelloWorldCompletedEventHandler)Delegate.Combine(helloWorldCompletedEventHandler2, value);
				helloWorldCompletedEventHandler = Interlocked.CompareExchange(ref f, value2, helloWorldCompletedEventHandler2);
			}
			while ((object)helloWorldCompletedEventHandler != helloWorldCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			HelloWorldCompletedEventHandler helloWorldCompletedEventHandler = f;
			HelloWorldCompletedEventHandler helloWorldCompletedEventHandler2;
			do
			{
				helloWorldCompletedEventHandler2 = helloWorldCompletedEventHandler;
				HelloWorldCompletedEventHandler value2 = (HelloWorldCompletedEventHandler)Delegate.Remove(helloWorldCompletedEventHandler2, value);
				helloWorldCompletedEventHandler = Interlocked.CompareExchange(ref f, value2, helloWorldCompletedEventHandler2);
			}
			while ((object)helloWorldCompletedEventHandler != helloWorldCompletedEventHandler2);
		}
	}

	public event CheckVersionCompletedEventHandler CheckVersionCompleted
	{
		[CompilerGenerated]
		add
		{
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler = g;
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler2;
			do
			{
				checkVersionCompletedEventHandler2 = checkVersionCompletedEventHandler;
				CheckVersionCompletedEventHandler value2 = (CheckVersionCompletedEventHandler)Delegate.Combine(checkVersionCompletedEventHandler2, value);
				checkVersionCompletedEventHandler = Interlocked.CompareExchange(ref g, value2, checkVersionCompletedEventHandler2);
			}
			while ((object)checkVersionCompletedEventHandler != checkVersionCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler = g;
			CheckVersionCompletedEventHandler checkVersionCompletedEventHandler2;
			do
			{
				checkVersionCompletedEventHandler2 = checkVersionCompletedEventHandler;
				CheckVersionCompletedEventHandler value2 = (CheckVersionCompletedEventHandler)Delegate.Remove(checkVersionCompletedEventHandler2, value);
				checkVersionCompletedEventHandler = Interlocked.CompareExchange(ref g, value2, checkVersionCompletedEventHandler2);
			}
			while ((object)checkVersionCompletedEventHandler != checkVersionCompletedEventHandler2);
		}
	}

	public event CheckBetaVersionCompletedEventHandler CheckBetaVersionCompleted
	{
		[CompilerGenerated]
		add
		{
			CheckBetaVersionCompletedEventHandler checkBetaVersionCompletedEventHandler = h;
			CheckBetaVersionCompletedEventHandler checkBetaVersionCompletedEventHandler2;
			do
			{
				checkBetaVersionCompletedEventHandler2 = checkBetaVersionCompletedEventHandler;
				CheckBetaVersionCompletedEventHandler value2 = (CheckBetaVersionCompletedEventHandler)Delegate.Combine(checkBetaVersionCompletedEventHandler2, value);
				checkBetaVersionCompletedEventHandler = Interlocked.CompareExchange(ref h, value2, checkBetaVersionCompletedEventHandler2);
			}
			while ((object)checkBetaVersionCompletedEventHandler != checkBetaVersionCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CheckBetaVersionCompletedEventHandler checkBetaVersionCompletedEventHandler = h;
			CheckBetaVersionCompletedEventHandler checkBetaVersionCompletedEventHandler2;
			do
			{
				checkBetaVersionCompletedEventHandler2 = checkBetaVersionCompletedEventHandler;
				CheckBetaVersionCompletedEventHandler value2 = (CheckBetaVersionCompletedEventHandler)Delegate.Remove(checkBetaVersionCompletedEventHandler2, value);
				checkBetaVersionCompletedEventHandler = Interlocked.CompareExchange(ref h, value2, checkBetaVersionCompletedEventHandler2);
			}
			while ((object)checkBetaVersionCompletedEventHandler != checkBetaVersionCompletedEventHandler2);
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

	public CheckUpdates()
	{
		Url = Settings.Default.RagsDesigner_com_ragsgame_www_CheckUpdates;
		if (a(Url))
		{
			UseDefaultCredentials = true;
			e = false;
		}
		else
		{
			e = true;
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public string HelloWorld()
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("HelloWorld", new object[0])[0];
	}

	public void HelloWorldAsync()
	{
		HelloWorldAsync(null);
	}

	public void HelloWorldAsync(object userState)
	{
		if (this.m_a == null)
		{
			this.m_a = d;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("HelloWorld", new object[0], this.m_a, userState);
	}

	private void d(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (f != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			f(this, new HelloWorldCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
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
		if (this.m_b == null)
		{
			this.m_b = c;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("CheckVersion", new object[0], this.m_b, userState);
	}

	private void c(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (g != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			g(this, new CheckVersionCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public string CheckBetaVersion()
	{
		return (string)((SoapHttpClientProtocol)this).Invoke("CheckBetaVersion", new object[0])[0];
	}

	public void CheckBetaVersionAsync()
	{
		CheckBetaVersionAsync(null);
	}

	public void CheckBetaVersionAsync(object userState)
	{
		if (this.m_c == null)
		{
			this.m_c = b;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("CheckBetaVersion", new object[0], this.m_c, userState);
	}

	private void b(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (h != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			h(this, new CheckBetaVersionCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
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
		if (this.m_d == null)
		{
			this.m_d = a;
		}
		((SoapHttpClientProtocol)this).InvokeAsync("Register", new object[3] { key, email, id }, this.m_d, userState);
	}

	private void a(object A_0)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (i != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)A_0;
			i(this, new RegisterCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
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
