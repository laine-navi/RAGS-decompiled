using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WPFRagsDesigner.ServiceReference1;

[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class HelloWorldResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string HelloWorldResult;

	public HelloWorldResponseBody()
	{
	}

	public HelloWorldResponseBody(string HelloWorldResult)
	{
		this.HelloWorldResult = HelloWorldResult;
	}
}
