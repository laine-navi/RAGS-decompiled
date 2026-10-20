using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[DebuggerStepThrough]
[MessageContract(IsWrapped = false)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
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
