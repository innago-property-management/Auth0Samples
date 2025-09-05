### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.ChangePassword\(string, string, CancellationToken\) Method

Changes the password for the specified user\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> ChangePassword(string email, string newPassword, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.ChangePassword(string,string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user\.

<a name='global__Auth0Client.Auth0Client.ChangePassword(string,string,System.Threading.CancellationToken).newPassword'></a>

`newPassword` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The new password to set\.

<a name='global__Auth0Client.Auth0Client.ChangePassword(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [ChangePassword\(string, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.changepassword#abstractions-iuserservice-changepassword(system-string-system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.ChangePassword\(System\.String,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing the result of the password change\.