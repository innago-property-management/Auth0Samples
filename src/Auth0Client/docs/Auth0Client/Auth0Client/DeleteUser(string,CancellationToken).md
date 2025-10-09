### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.DeleteUser\(string, CancellationToken\) Method

Deletes a user by setting the isDeleted flag in AppMetadata and blocking the user\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> DeleteUser(string identityId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.DeleteUser(string,System.Threading.CancellationToken).identityId'></a>

`identityId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identity ID of the user to delete\.

<a name='global__Auth0Client.Auth0Client.DeleteUser(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

Implements [DeleteUser\(string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.deleteuser#abstractions-iuserservice-deleteuser(system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.DeleteUser\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
An [Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError') object indicating success or containing an error message if the operation fails\.