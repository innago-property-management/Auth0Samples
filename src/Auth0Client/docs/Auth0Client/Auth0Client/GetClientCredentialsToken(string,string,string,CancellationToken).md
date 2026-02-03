### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.GetClientCredentialsToken\(string, string, string, CancellationToken\) Method

Retrieves an OAuth2 Client Credentials token with full response fields \(RFC 6749 Section 4\.4\)\.

```csharp
public System.Threading.Tasks.Task<Innago.Shared.TryHelpers.Result<Abstractions.ClientCredentialsToken>> GetClientCredentialsToken(string clientId, string clientSecret, string audience, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).clientId'></a>

`clientId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The client identifier issued to the client\.

<a name='global__Auth0Client.Auth0Client.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).clientSecret'></a>

`clientSecret` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The client secret\.

<a name='global__Auth0Client.Auth0Client.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).audience'></a>

`audience` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The target audience for the token\.

<a name='global__Auth0Client.Auth0Client.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token to cancel the operation\.

Implements [GetClientCredentialsToken\(string, string, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iauthservice.getclientcredentialstoken#abstractions-iauthservice-getclientcredentialstoken(system-string-system-string-system-string-system-threading-cancellationtoken) 'Abstractions\.IAuthService\.GetClientCredentialsToken\(System\.String,System\.String,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Innago\.Shared\.TryHelpers\.Result&lt;](https://learn.microsoft.com/en-us/dotnet/api/innago.shared.tryhelpers.result-1 'Innago\.Shared\.TryHelpers\.Result\`1')[Abstractions\.ClientCredentialsToken](https://learn.microsoft.com/en-us/dotnet/api/abstractions.clientcredentialstoken 'Abstractions\.ClientCredentialsToken')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/innago.shared.tryhelpers.result-1 'Innago\.Shared\.TryHelpers\.Result\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A result containing the full client credentials token response or an error\.