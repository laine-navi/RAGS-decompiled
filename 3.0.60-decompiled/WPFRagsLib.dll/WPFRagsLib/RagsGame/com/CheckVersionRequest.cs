using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsLib.RagsGame.com;

[MessageContract(IsWrapped = false)]
[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
public class CheckVersionRequest
{
	[MessageBodyMember(Name = "CheckVersion", Namespace = "http://tempuri.org/", Order = 0)]
	public CheckVersionRequestBody Body;

	public CheckVersionRequest()
	{
	}

	public CheckVersionRequest(CheckVersionRequestBody Body)
	{
		this.Body = Body;
	}
}
