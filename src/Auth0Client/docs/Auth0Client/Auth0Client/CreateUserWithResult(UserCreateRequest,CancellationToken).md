### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CreateUserWithResult\(UserCreateRequest, CancellationToken\) Method

Creates a new user in Auth0 and returns an OkError result\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> CreateUserWithResult(Auth0.ManagementApi.Models.UserCreateRequest userCreateRequest, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CreateUserWithResult(Auth0.ManagementApi.Models.UserCreateRequest,System.Threading.CancellationToken).userCreateRequest'></a>

`userCreateRequest` [Auth0\.ManagementApi\.Models\.UserCreateRequest](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.usercreaterequest 'Auth0\.ManagementApi\.Models\.UserCreateRequest')

The information required to create the user\.

<a name='global__Auth0Client.Auth0Client.CreateUserWithResult(Auth0.ManagementApi.Models.UserCreateRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [CreateUserWithResult\(UserCreateRequest, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.createuserwithresult#abstractions-iuserservice-createuserwithresult(auth0-managementapi-models-usercreaterequest-system-threading-cancellationtoken) 'Abstractions\.IUserService\.CreateUserWithResult\(Auth0\.ManagementApi\.Models\.UserCreateRequest,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing an OkError result\.