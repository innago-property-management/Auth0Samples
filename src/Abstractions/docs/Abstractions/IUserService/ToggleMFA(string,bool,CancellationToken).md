#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.ToggleMFA\(string, bool, CancellationToken\) Method

Enables or disables Multi\-Factor Authentication \(MFA\) for a user\.

```csharp
ITask<Abstractions.OkError> ToggleMFA(string email, bool enable, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.ToggleMFA(string,bool,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user for whom to toggle MFA\.

<a name='Abstractions.IUserService.ToggleMFA(string,bool,System.Threading.CancellationToken).enable'></a>

`enable` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True to enable MFA, false to disable it\.

<a name='Abstractions.IUserService.ToggleMFA(string,bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
An [OkError](../OkError/index.md 'Abstractions\.OkError') object indicating success or containing an error message if the operation fails\.