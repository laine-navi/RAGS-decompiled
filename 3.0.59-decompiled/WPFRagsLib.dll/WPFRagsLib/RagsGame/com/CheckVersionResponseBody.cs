using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WPFRagsLib.RagsGame.com;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class CheckVersionResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string CheckVersionResult;

	public CheckVersionResponseBody()
	{
	}

	public CheckVersionResponseBody(string CheckVersionResult)
	{
		this.CheckVersionResult = CheckVersionResult;
	}
}
