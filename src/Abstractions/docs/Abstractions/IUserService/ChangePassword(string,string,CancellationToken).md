#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.ChangePassword\(string, string, CancellationToken\) Method

Changes the password for a user identified by the provided email\.

```csharp
ITask<Abstractions.OkError> ChangePassword(string email, string newPassword, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.ChangePassword(string,string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user whose password needs to be changed\.

<a name='Abstractions.IUserService.ChangePassword(string,string,System.Threading.CancellationToken).newPassword'></a>

`newPassword` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new password to set for the user\.

<a name='Abstractions.IUserService.ChangePassword(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
An [OkError](../OkError/index.md 'Abstractions\.OkError') object indicating success or containing an error message if the operation fails\.