#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IAuthService](index.md 'Abstractions\.IAuthService')

## IAuthService\.GetClientCredentialsToken\(string, string, string, CancellationToken\) Method

Retrieves an OAuth2 Client Credentials token as defined in RFC 6749 Section 4\.4\.

```csharp
System.Threading.Tasks.Task<Result<Abstractions.ClientCredentialsToken>> GetClientCredentialsToken(string clientId, string clientSecret, string audience, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IAuthService.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).clientId'></a>

`clientId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The client identifier issued to the client\.

<a name='Abstractions.IAuthService.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).clientSecret'></a>

`clientSecret` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The client secret\.

<a name='Abstractions.IAuthService.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).audience'></a>

`audience` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The target audience for the token\.

<a name='Abstractions.IAuthService.GetClientCredentialsToken(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Innago\.Shared\.TryHelpers\.Result](https://learn.microsoft.com/en-us/dotnet/api/innago.shared.tryhelpers.result 'Innago\.Shared\.TryHelpers\.Result')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A result containing the client credentials token response or an error\.