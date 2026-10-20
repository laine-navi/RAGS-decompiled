using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WPFRagsDesigner.ServiceReference1;

[ServiceContract(ConfigurationName = "ServiceReference1.CheckUpdatesSoap")]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public interface CheckUpdatesSoap
{
	[OperationContract(Action = "http://tempuri.org/HelloWorld", ReplyAction = "*")]
	HelloWorldResponse HelloWorld(HelloWorldRequest request);

	[OperationContract(Action = "http://tempuri.org/HelloWorld", ReplyAction = "*")]
	Task<HelloWorldResponse> HelloWorldAsync(HelloWorldRequest request);

	[OperationContract(Action = "http://tempuri.org/CheckVersion", ReplyAction = "*")]
	CheckVersionResponse CheckVersion(CheckVersionRequest request);

	[OperationContract(Action = "http://tempuri.org/CheckVersion", ReplyAction = "*")]
	Task<CheckVersionResponse> CheckVersionAsync(CheckVersionRequest request);

	[OperationContract(Action = "http://tempuri.org/CheckBetaVersion", ReplyAction = "*")]
	CheckBetaVersionResponse CheckBetaVersion(CheckBetaVersionRequest request);

	[OperationContract(Action = "http://tempuri.org/CheckBetaVersion", ReplyAction = "*")]
	Task<CheckBetaVersionResponse> CheckBetaVersionAsync(CheckBetaVersionRequest request);

	[OperationContract(Action = "http://tempuri.org/Register", ReplyAction = "*")]
	RegisterResponse Register(RegisterRequest request);

	[OperationContract(Action = "http://tempuri.org/Register", ReplyAction = "*")]
	Task<RegisterResponse> RegisterAsync(RegisterRequest request);
}
