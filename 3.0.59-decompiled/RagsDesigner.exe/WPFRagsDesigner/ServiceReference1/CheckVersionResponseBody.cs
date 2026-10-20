using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WPFRagsDesigner.ServiceReference1;

[DataContract(Namespace = "http://tempuri.org/")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
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
