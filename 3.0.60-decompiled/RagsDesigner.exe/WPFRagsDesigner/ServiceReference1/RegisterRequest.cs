using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
[MessageContract(IsWrapped = false)]
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
