#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.CreateUserWithResult\(UserCreateRequest, CancellationToken\) Method

Creates a new user in Auth0 and returns an OkError result\.

```csharp
ITask<Abstractions.OkError> CreateUserWithResult(UserCreateRequest userCreateRequest, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.CreateUserWithResult(UserCreateRequest,System.Threading.CancellationToken).userCreateRequest'></a>

`userCreateRequest` [Auth0\.ManagementApi\.Models\.UserCreateRequest](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.usercreaterequest 'Auth0\.ManagementApi\.Models\.UserCreateRequest')

The information required to create the user\.

<a name='Abstractions.IUserService.CreateUserWithResult(UserCreateRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that represents the asynchronous operation, containing an OkError result\.