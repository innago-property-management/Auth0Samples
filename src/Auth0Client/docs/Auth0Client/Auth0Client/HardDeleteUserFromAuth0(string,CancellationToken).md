### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.HardDeleteUserFromAuth0\(string, CancellationToken\) Method

Permanently deletes a user from Auth0 based on their email address\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> HardDeleteUserFromAuth0(string email, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.HardDeleteUserFromAuth0(string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user to delete\.

<a name='global__Auth0Client.Auth0Client.HardDeleteUserFromAuth0(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used to cancel the delete operation\.

Implements [HardDeleteUserFromAuth0\(string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.harddeleteuserfromauth0#abstractions-iuserservice-harddeleteuserfromauth0(system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.HardDeleteUserFromAuth0\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
An [Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError') object indicating success or containing an error message if the operation fails\.