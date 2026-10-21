using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Rags.ragsgame.com;

[Serializable]
[XmlType(Namespace = "http://tempuri.org/")]
[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("System.Xml", "4.6.1586.0")]
public class RegData
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
