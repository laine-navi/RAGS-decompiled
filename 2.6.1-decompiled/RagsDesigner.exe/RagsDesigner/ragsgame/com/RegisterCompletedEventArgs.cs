using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace RagsDesigner.ragsgame.com;

[DesignerCategory("code")]
[GeneratedCode("System.Web.Services", "4.6.1586.0")]
[DebuggerStepThrough]
public class RegisterCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] a;

	public RegData Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (RegData)a[0];
		}
	}

	internal RegisterCompletedEventArgs(object[] A_0, Exception A_1, bool A_2, object A_3)
		: base(A_1, A_2, A_3)
	{
		a = A_0;
	}
}
