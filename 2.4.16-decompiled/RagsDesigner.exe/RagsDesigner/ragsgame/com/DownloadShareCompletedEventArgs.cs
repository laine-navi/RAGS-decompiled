using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace RagsDesigner.ragsgame.com;

[DebuggerStepThrough]
[DesignerCategory("code")]
[GeneratedCode("System.Web.Services", "4.0.30319.1")]
public sealed class DownloadShareCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] c1937ac6e4430d5026bdce2bd0562f5ec;

	public byte[] Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (byte[])c1937ac6e4430d5026bdce2bd0562f5ec[0];
		}
	}

	internal DownloadShareCompletedEventArgs(object[] P_0, Exception P_1, bool P_2, object P_3)
		: base(P_1, P_2, P_3)
	{
		c1937ac6e4430d5026bdce2bd0562f5ec = P_0;
	}
}
