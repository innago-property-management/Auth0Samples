#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IAuthService](index.md 'Abstractions\.IAuthService')

## IAuthService\.GetToken\(string, string, string, CancellationToken\) Method

Generate token based on ClientId and ClientSecret

```csharp
System.Threading.Tasks.Task<Result<string>> GetToken(string clientId, string clientSecret, string audience, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IAuthService.GetToken(string,string,string,System.Threading.CancellationToken).clientId'></a>

`clientId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IAuthService.GetToken(string,string,string,System.Threading.CancellationToken).clientSecret'></a>

`clientSecret` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IAuthService.GetToken(string,string,string,System.Threading.CancellationToken).audience'></a>

`audience` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IAuthService.GetToken(string,string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Innago\.Shared\.TryHelpers\.Result](https://learn.microsoft.com/en-us/dotnet/api/innago.shared.tryhelpers.result 'Innago\.Shared\.TryHelpers\.Result')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')