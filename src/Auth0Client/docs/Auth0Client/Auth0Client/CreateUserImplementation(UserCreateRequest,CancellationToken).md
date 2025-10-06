### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CreateUserImplementation\(UserCreateRequest, CancellationToken\) Method

Creates a new user in Auth0 using the provided UserCreateRequest\.

```csharp
public System.Threading.Tasks.Task<Auth0.ManagementApi.Models.User> CreateUserImplementation(Auth0.ManagementApi.Models.UserCreateRequest userCreateRequest, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CreateUserImplementation(Auth0.ManagementApi.Models.UserCreateRequest,System.Threading.CancellationToken).userCreateRequest'></a>

`userCreateRequest` [Auth0\.ManagementApi\.Models\.UserCreateRequest](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.usercreaterequest 'Auth0\.ManagementApi\.Models\.UserCreateRequest')

<a name='global__Auth0Client.Auth0Client.CreateUserImplementation(Auth0.ManagementApi.Models.UserCreateRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [CreateUserImplementation\(UserCreateRequest, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.createuserimplementation#abstractions-iuserservice-createuserimplementation(auth0-managementapi-models-usercreaterequest-system-threading-cancellationtoken) 'Abstractions\.IUserService\.CreateUserImplementation\(Auth0\.ManagementApi\.Models\.UserCreateRequest,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')

#### Exceptions

[System\.InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception 'System\.InvalidOperationException')