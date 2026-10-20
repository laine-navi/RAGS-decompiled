using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using WPFRagsLib.RagsGame.com;

namespace WPFRagsDesigner.ServiceReference1;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class RegisterResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public RegData RegisterResult;

	public RegisterResponseBody()
	{
	}

	public RegisterResponseBody(RegData RegisterResult)
	{
		this.RegisterResult = RegisterResult;
	}
}
