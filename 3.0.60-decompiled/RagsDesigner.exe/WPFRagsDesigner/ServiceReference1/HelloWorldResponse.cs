using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[DebuggerStepThrough]
[MessageContract(IsWrapped = false)]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class HelloWorldResponse
{
	[MessageBodyMember(Name = "HelloWorldResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public HelloWorldResponseBody Body;

	public HelloWorldResponse()
	{
	}

	public HelloWorldResponse(HelloWorldResponseBody Body)
	{
		this.Body = Body;
	}
}
