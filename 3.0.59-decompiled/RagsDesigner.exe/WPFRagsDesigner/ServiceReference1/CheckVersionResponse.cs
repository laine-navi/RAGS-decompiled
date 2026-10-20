using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
[MessageContract(IsWrapped = false)]
[EditorBrowsable(EditorBrowsableState.Advanced)]
public class CheckVersionResponse
{
	[MessageBodyMember(Name = "CheckVersionResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public CheckVersionResponseBody Body;

	public CheckVersionResponse()
	{
	}

	public CheckVersionResponse(CheckVersionResponseBody Body)
	{
		this.Body = Body;
	}
}
