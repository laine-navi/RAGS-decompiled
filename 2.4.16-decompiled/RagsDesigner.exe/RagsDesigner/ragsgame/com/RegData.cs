using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace RagsDesigner.ragsgame.com;

[Serializable]
[GeneratedCode("System.Xml", "4.0.30319.1")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://tempuri.org/")]
[DebuggerStepThrough]
public sealed class RegData
{
	private int retvalField;

	private DateTime expireField;

	public int retval
	{
		get
		{
			return retvalField;
		}
		set
		{
			retvalField = value;
		}
	}

	public DateTime expire
	{
		get
		{
			return expireField;
		}
		set
		{
			expireField = value;
		}
	}
}
