using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using WPFRagsLib.RagsGame.com;

namespace WPFRagsDesigner.ServiceReference1;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class CheckUpdatesSoapClient : ClientBase<CheckUpdatesSoap>, CheckUpdatesSoap
{
	public CheckUpdatesSoapClient()
	{
	}

	public CheckUpdatesSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public CheckUpdatesSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CheckUpdatesSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public CheckUpdatesSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	HelloWorldResponse CheckUpdatesSoap.HelloWorld(HelloWorldRequest request)
	{
		return base.Channel.HelloWorld(request);
	}

	public string HelloWorld()
	{
		HelloWorldRequest helloWorldRequest = new HelloWorldRequest();
		helloWorldRequest.Body = new HelloWorldRequestBody();
		HelloWorldResponse helloWorldResponse = ((CheckUpdatesSoap)this).HelloWorld(helloWorldRequest);
		return helloWorldResponse.Body.HelloWorldResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<HelloWorldResponse> CheckUpdatesSoap.HelloWorldAsync(HelloWorldRequest request)
	{
		return base.Channel.HelloWorldAsync(request);
	}

	public Task<HelloWorldResponse> HelloWorldAsync()
	{
		HelloWorldRequest helloWorldRequest = new HelloWorldRequest();
		helloWorldRequest.Body = new HelloWorldRequestBody();
		return ((CheckUpdatesSoap)this).HelloWorldAsync(helloWorldRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	CheckVersionResponse CheckUpdatesSoap.CheckVersion(CheckVersionRequest request)
	{
		return base.Channel.CheckVersion(request);
	}

	public string CheckVersion()
	{
		CheckVersionRequest checkVersionRequest = new CheckVersionRequest();
		checkVersionRequest.Body = new CheckVersionRequestBody();
		CheckVersionResponse checkVersionResponse = ((CheckUpdatesSoap)this).CheckVersion(checkVersionRequest);
		return checkVersionResponse.Body.CheckVersionResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<CheckVersionResponse> CheckUpdatesSoap.CheckVersionAsync(CheckVersionRequest request)
	{
		return base.Channel.CheckVersionAsync(request);
	}

	public Task<CheckVersionResponse> CheckVersionAsync()
	{
		CheckVersionRequest checkVersionRequest = new CheckVersionRequest();
		checkVersionRequest.Body = new CheckVersionRequestBody();
		return ((CheckUpdatesSoap)this).CheckVersionAsync(checkVersionRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	CheckBetaVersionResponse CheckUpdatesSoap.CheckBetaVersion(CheckBetaVersionRequest request)
	{
		return base.Channel.CheckBetaVersion(request);
	}

	public string CheckBetaVersion()
	{
		CheckBetaVersionRequest checkBetaVersionRequest = new CheckBetaVersionRequest();
		checkBetaVersionRequest.Body = new CheckBetaVersionRequestBody();
		CheckBetaVersionResponse checkBetaVersionResponse = ((CheckUpdatesSoap)this).CheckBetaVersion(checkBetaVersionRequest);
		return checkBetaVersionResponse.Body.CheckBetaVersionResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<CheckBetaVersionResponse> CheckUpdatesSoap.CheckBetaVersionAsync(CheckBetaVersionRequest request)
	{
		return base.Channel.CheckBetaVersionAsync(request);
	}

	public Task<CheckBetaVersionResponse> CheckBetaVersionAsync()
	{
		CheckBetaVersionRequest checkBetaVersionRequest = new CheckBetaVersionRequest();
		checkBetaVersionRequest.Body = new CheckBetaVersionRequestBody();
		return ((CheckUpdatesSoap)this).CheckBetaVersionAsync(checkBetaVersionRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	RegisterResponse CheckUpdatesSoap.Register(RegisterRequest request)
	{
		return base.Channel.Register(request);
	}

	public RegData Register(string key, string email, string id)
	{
		RegisterRequest registerRequest = new RegisterRequest();
		registerRequest.Body = new RegisterRequestBody();
		registerRequest.Body.key = key;
		registerRequest.Body.email = email;
		registerRequest.Body.id = id;
		RegisterResponse registerResponse = ((CheckUpdatesSoap)this).Register(registerRequest);
		return registerResponse.Body.RegisterResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<RegisterResponse> CheckUpdatesSoap.RegisterAsync(RegisterRequest request)
	{
		return base.Channel.RegisterAsync(request);
	}

	public Task<RegisterResponse> RegisterAsync(string key, string email, string id)
	{
		RegisterRequest registerRequest = new RegisterRequest();
		registerRequest.Body = new RegisterRequestBody();
		registerRequest.Body.key = key;
		registerRequest.Body.email = email;
		registerRequest.Body.id = id;
		return ((CheckUpdatesSoap)this).RegisterAsync(registerRequest);
	}
}
