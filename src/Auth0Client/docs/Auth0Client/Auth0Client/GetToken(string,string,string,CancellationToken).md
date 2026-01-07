### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.GetToken\(string, string, string, CancellationToken\) Method

```csharp
public System.Threading.Tasks.Task<Innago.Shared.TryHelpers.Result<string>> GetToken(string clientId, string clientSecret, string audience, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.GetToken(string,string,string,System.Threading.CancellationToken).clientId'></a>

`clientId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='global__Auth0Client.Auth0Client.GetToken(string,string,string,System.Threading.CancellationToken).clientSecret'></a>

`clientSecret` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='global__Auth0Client.Auth0Client.GetToken(string,string,string,System.Threading.CancellationToken).audience'></a>

`audience` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='global__Auth0Client.Auth0Client.GetToken(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [GetToken\(string, string, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iauthservice.gettoken#abstractions-iauthservice-gettoken(system-string-system-string-system-string-system-threading-cancellationtoken) 'Abstractions\.IAuthService\.GetToken\(System\.String,System\.String,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Innago\.Shared\.TryHelpers\.Result&lt;](https://learn.microsoft.com/en-us/dotnet/api/innago.shared.tryhelpers.result-1 'Innago\.Shared\.TryHelpers\.Result\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/innago.shared.tryhelpers.result-1 'Innago\.Shared\.TryHelpers\.Result\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')