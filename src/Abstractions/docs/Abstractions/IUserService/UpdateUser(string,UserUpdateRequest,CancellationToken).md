#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.UpdateUser\(string, UserUpdateRequest, CancellationToken\) Method

Updates a user with the specified email by setting the provided key\-value pairs\.

```csharp
ITask<Abstractions.OkError> UpdateUser(string identityId, UserUpdateRequest request, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.UpdateUser(string,UserUpdateRequest,System.Threading.CancellationToken).identityId'></a>

`identityId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IUserService.UpdateUser(string,UserUpdateRequest,System.Threading.CancellationToken).request'></a>

`request` [Auth0\.ManagementApi\.Models\.UserUpdateRequest](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.userupdaterequest 'Auth0\.ManagementApi\.Models\.UserUpdateRequest')

<a name='Abstractions.IUserService.UpdateUser(string,UserUpdateRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')