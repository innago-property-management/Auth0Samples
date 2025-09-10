### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.DisableMfa\(string, CancellationToken\) Method

Disables Multi\-Factor Authentication for the specified user\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> DisableMfa(string email, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.DisableMfa(string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user\.

<a name='global__Auth0Client.Auth0Client.DisableMfa(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [DisableMfa\(string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.disablemfa#abstractions-iuserservice-disablemfa(system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.DisableMfa\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing the result of the MFA toggle\.