using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WPFRagsLib.RagsGame.com;

[DataContract(Namespace = "http://tempuri.org/")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DebuggerStepThrough]
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
