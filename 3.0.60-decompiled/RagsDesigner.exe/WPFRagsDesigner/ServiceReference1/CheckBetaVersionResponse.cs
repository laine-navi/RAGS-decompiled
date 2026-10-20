using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class CheckBetaVersionResponse
{
	[MessageBodyMember(Name = "CheckBetaVersionResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public CheckBetaVersionResponseBody Body;

	public CheckBetaVersionResponse()
	{
	}

	public CheckBetaVersionResponse(CheckBetaVersionResponseBody Body)
	{
		this.Body = Body;
	}
}
