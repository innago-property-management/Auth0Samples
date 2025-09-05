### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.ToggleMFA\(string, bool, CancellationToken\) Method

Enables or disables Multi\-Factor Authentication for the specified user\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> ToggleMFA(string email, bool enable, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.ToggleMFA(string,bool,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user\.

<a name='global__Auth0Client.Auth0Client.ToggleMFA(string,bool,System.Threading.CancellationToken).enable'></a>

`enable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True to enable MFA, false to disable it\.

<a name='global__Auth0Client.Auth0Client.ToggleMFA(string,bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [ToggleMFA\(string, bool, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.togglemfa#abstractions-iuserservice-togglemfa(system-string-system-boolean-system-threading-cancellationtoken) 'Abstractions\.IUserService\.ToggleMFA\(System\.String,System\.Boolean,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing the result of the MFA toggle\.