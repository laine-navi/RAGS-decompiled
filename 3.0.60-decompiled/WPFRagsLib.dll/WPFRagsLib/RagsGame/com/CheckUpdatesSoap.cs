using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WPFRagsLib.RagsGame.com;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "RagsGame.com.CheckUpdatesSoap")]
public interface CheckUpdatesSoap
{
	[OperationContract(Action = "http://tempuri.org/CheckVersion", ReplyAction = "*")]
	CheckVersionResponse CheckVersion(CheckVersionRequest request);

	[OperationContract(Action = "http://tempuri.org/CheckVersion", ReplyAction = "*")]
	Task<CheckVersionResponse> CheckVersionAsync(CheckVersionRequest request);

	[OperationContract(Action = "http://tempuri.org/Register", ReplyAction = "*")]
	RegisterResponse Register(RegisterRequest request);

	[OperationContract(Action = "http://tempuri.org/Register", ReplyAction = "*")]
	Task<RegisterResponse> RegisterAsync(RegisterRequest request);
}
