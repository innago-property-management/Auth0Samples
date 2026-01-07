#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services').[AuthService](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.AuthService')

## AuthService\.GetToken\(GetTokenRequest, ServerCallContext\) Method

Handles OAuth2 Client Credentials token requests \(RFC 6749 Section 4\.4\)\.

```csharp
public override System.Threading.Tasks.Task<IdpServiceFacade.GetTokenResponse> GetToken(IdpServiceFacade.GetTokenRequest request, Grpc.Core.ServerCallContext context);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.Services.AuthService.GetToken(IdpServiceFacade.GetTokenRequest,Grpc.Core.ServerCallContext).request'></a>

`request` [GetTokenRequest](../../../../../IdpServiceFacade/GetTokenRequest/index.md 'IdpServiceFacade\.GetTokenRequest')

The token request containing client credentials and audience\.

<a name='Innago.Security.IdpServiceFacade.Services.AuthService.GetToken(IdpServiceFacade.GetTokenRequest,Grpc.Core.ServerCallContext).context'></a>

`context` [Grpc\.Core\.ServerCallContext](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servercallcontext 'Grpc\.Core\.ServerCallContext')

The gRPC server call context\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[GetTokenResponse](../../../../../IdpServiceFacade/GetTokenResponse/index.md 'IdpServiceFacade\.GetTokenResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A response containing the access token and OAuth2 standard fields\.