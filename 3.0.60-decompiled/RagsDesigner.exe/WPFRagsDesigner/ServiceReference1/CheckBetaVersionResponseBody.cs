using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WPFRagsDesigner.ServiceReference1;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DataContract(Namespace = "http://tempuri.org/")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
public class CheckBetaVersionResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string CheckBetaVersionResult;

	public CheckBetaVersionResponseBody()
	{
	}

	public CheckBetaVersionResponseBody(string CheckBetaVersionResult)
	{
		this.CheckBetaVersionResult = CheckBetaVersionResult;
	}
}
