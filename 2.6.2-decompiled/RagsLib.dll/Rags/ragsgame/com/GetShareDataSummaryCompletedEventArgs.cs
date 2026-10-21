using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Rags.ragsgame.com;

[GeneratedCode("System.Web.Services", "4.6.1586.0")]
[DesignerCategory("code")]
[DebuggerStepThrough]
public class GetShareDataSummaryCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] a;

	public object[] Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (object[])a[0];
		}
	}

	internal GetShareDataSummaryCompletedEventArgs(object[] A_0, Exception A_1, bool A_2, object A_3)
		: base(A_1, A_2, A_3)
	{
		a = A_0;
	}
}
