using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace WPFRagsDesigner.ServiceReference1;

[MessageContract(IsWrapped = false)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
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
