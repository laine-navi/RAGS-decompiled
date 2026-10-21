using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Rags.ragsgame.com;

[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("System.Web.Services", "4.6.1586.0")]
public class DownloadShareCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] a;

	public byte[] Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (byte[])a[0];
		}
	}

	internal DownloadShareCompletedEventArgs(object[] A_0, Exception A_1, bool A_2, object A_3)
		: base(A_1, A_2, A_3)
	{
		a = A_0;
	}
}
