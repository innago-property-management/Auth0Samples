#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.EnableMfa\(string, CancellationToken\) Method

Disables Multi\-Factor Authentication \(MFA\) for a user for next login

```csharp
ITask<Abstractions.OkError> EnableMfa(string email, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.EnableMfa(string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IUserService.EnableMfa(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
An [OkError](../OkError/index.md 'Abstractions\.OkError') object indicating success or containing an error message if the operation fails\.