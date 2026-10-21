using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace Rags.ragsgame.com;

[DebuggerStepThrough]
[GeneratedCode("System.Web.Services", "4.0.30319.1")]
[DesignerCategory("code")]
public sealed class GetShareDataSummaryCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] c1937ac6e4430d5026bdce2bd0562f5ec;

	public object[] Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (object[])c1937ac6e4430d5026bdce2bd0562f5ec[0];
		}
	}

	internal GetShareDataSummaryCompletedEventArgs(object[] P_0, Exception P_1, bool P_2, object P_3)
		: base(P_1, P_2, P_3)
	{
		c1937ac6e4430d5026bdce2bd0562f5ec = P_0;
	}
}
