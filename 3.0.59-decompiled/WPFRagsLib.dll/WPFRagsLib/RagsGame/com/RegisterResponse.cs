using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsLib.RagsGame.com;

[MessageContract(IsWrapped = false)]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class RegisterResponse
{
	[MessageBodyMember(Name = "RegisterResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public RegisterResponseBody Body;

	public RegisterResponse()
	{
	}

	public RegisterResponse(RegisterResponseBody Body)
	{
		this.Body = Body;
	}
}
