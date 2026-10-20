using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace WPFRagsDesigner.ServiceReference1;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DataContract(Namespace = "http://tempuri.org/")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DebuggerStepThrough]
public class RegisterRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string key;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string email;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string id;

	public RegisterRequestBody()
	{
	}

	public RegisterRequestBody(string key, string email, string id)
	{
		this.key = key;
		this.email = email;
		this.id = id;
	}
}
