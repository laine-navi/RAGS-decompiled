using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(IsWrapped = false)]
public class HelloWorldRequest
{
	[MessageBodyMember(Name = "HelloWorld", Namespace = "http://tempuri.org/", Order = 0)]
	public HelloWorldRequestBody Body;

	public HelloWorldRequest()
	{
	}

	public HelloWorldRequest(HelloWorldRequestBody Body)
	{
		this.Body = Body;
	}
}
