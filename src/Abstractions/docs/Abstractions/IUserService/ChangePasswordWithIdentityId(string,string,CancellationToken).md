#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.ChangePasswordWithIdentityId\(string, string, CancellationToken\) Method

Change the password for a user identified by the provided identityId\.

```csharp
ITask<Abstractions.OkError> ChangePasswordWithIdentityId(string identityId, string newPassword, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.ChangePasswordWithIdentityId(string,string,System.Threading.CancellationToken).identityId'></a>

`identityId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IUserService.ChangePasswordWithIdentityId(string,string,System.Threading.CancellationToken).newPassword'></a>

`newPassword` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IUserService.ChangePasswordWithIdentityId(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')