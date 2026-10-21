using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Rags.ragsgame.com;

[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("System.Web.Services", "4.6.1586.0")]
public class CheckVersionCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] a;

	public string Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (string)a[0];
		}
	}

	internal CheckVersionCompletedEventArgs(object[] A_0, Exception A_1, bool A_2, object A_3)
		: base(A_1, A_2, A_3)
	{
		a = A_0;
	}
}
