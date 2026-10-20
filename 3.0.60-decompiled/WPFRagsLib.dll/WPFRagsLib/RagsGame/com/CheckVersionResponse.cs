using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsLib.RagsGame.com;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DebuggerStepThrough]
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
