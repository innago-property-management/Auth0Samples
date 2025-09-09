### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.UnblockUser\(string, CancellationToken\) Method

Unblocks a user in the Auth0 system\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> UnblockUser(string email, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.UnblockUser(string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user to unblock\.

<a name='global__Auth0Client.Auth0Client.UnblockUser(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the unblock operation\.

Implements [UnblockUser\(string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.unblockuser#abstractions-iuserservice-unblockuser(system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.UnblockUser\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
An asynchronous task containing the result of the unblock operation\.