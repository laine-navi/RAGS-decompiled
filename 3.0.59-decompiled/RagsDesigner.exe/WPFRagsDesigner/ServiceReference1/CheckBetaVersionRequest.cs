using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DebuggerStepThrough]
public class CheckBetaVersionRequest
{
	[MessageBodyMember(Name = "CheckBetaVersion", Namespace = "http://tempuri.org/", Order = 0)]
	public CheckBetaVersionRequestBody Body;

	public CheckBetaVersionRequest()
	{
	}

	public CheckBetaVersionRequest(CheckBetaVersionRequestBody Body)
	{
		this.Body = Body;
	}
}
