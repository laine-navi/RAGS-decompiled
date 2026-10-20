using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsLib.RagsGame.com;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class RegisterRequest
{
	[MessageBodyMember(Name = "Register", Namespace = "http://tempuri.org/", Order = 0)]
	public RegisterRequestBody Body;

	public RegisterRequest()
	{
	}

	public RegisterRequest(RegisterRequestBody Body)
	{
		this.Body = Body;
	}
}
