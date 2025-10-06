### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.ChangePasswordWithIdentityId\(string, string, CancellationToken\) Method

Change the password for a user identified by the provided identityId\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> ChangePasswordWithIdentityId(string identityId, string newPassword, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.ChangePasswordWithIdentityId(string,string,System.Threading.CancellationToken).identityId'></a>

`identityId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='global__Auth0Client.Auth0Client.ChangePasswordWithIdentityId(string,string,System.Threading.CancellationToken).newPassword'></a>

`newPassword` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='global__Auth0Client.Auth0Client.ChangePasswordWithIdentityId(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [ChangePasswordWithIdentityId\(string, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.changepasswordwithidentityid#abstractions-iuserservice-changepasswordwithidentityid(system-string-system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.ChangePasswordWithIdentityId\(System\.String,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')