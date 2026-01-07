#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.UnblockBruteforceLockedUser\(string, CancellationToken\) Method

Attempts to remove a brute\-force lock from the user account associated with the specified email address\.

```csharp
ITask<Abstractions.OkError> UnblockBruteforceLockedUser(string email, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.UnblockBruteforceLockedUser(string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user whose brute\-force lock should be removed\. Cannot be null or empty\.

<a name='Abstractions.IUserService.UnblockBruteforceLockedUser(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the unblock operation\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that represents the asynchronous operation\. The result indicates whether the unblock action succeeded or
            failed\.