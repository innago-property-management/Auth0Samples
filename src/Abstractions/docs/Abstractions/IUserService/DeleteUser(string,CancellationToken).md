#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.DeleteUser\(string, CancellationToken\) Method

Deletes a user by setting the isDeleted flag in AppMetadata and blocking the user\.

```csharp
ITask<Abstractions.OkError> DeleteUser(string identityId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.DeleteUser(string,System.Threading.CancellationToken).identityId'></a>

`identityId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identity ID of the user to delete\.

<a name='Abstractions.IUserService.DeleteUser(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
An [OkError](../OkError/index.md 'Abstractions\.OkError') object indicating success or containing an error message if the operation fails\.