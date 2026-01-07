### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.UnblockBruteforceLockedUser\(string, CancellationToken\) Method

Attempts to remove a brute\-force lock from the user account associated with the specified email address\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> UnblockBruteforceLockedUser(string email, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.UnblockBruteforceLockedUser(string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user whose brute\-force lock should be removed\. Cannot be null or empty\.

<a name='global__Auth0Client.Auth0Client.UnblockBruteforceLockedUser(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the unblock operation\.

Implements [UnblockBruteforceLockedUser\(string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.unblockbruteforcelockeduser#abstractions-iuserservice-unblockbruteforcelockeduser(system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.UnblockBruteforceLockedUser\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation\. The result indicates whether the unblock action succeeded or
            failed\.