### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CreateUser\(UserCreateInfo, CancellationToken\) Method

Creates a new user in Auth0\.

```csharp
public System.Threading.Tasks.Task<Auth0.ManagementApi.Models.User?> CreateUser(Abstractions.UserCreateInfo userCreateInfo, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CreateUser(Abstractions.UserCreateInfo,System.Threading.CancellationToken).userCreateInfo'></a>

`userCreateInfo` [Abstractions\.UserCreateInfo](https://learn.microsoft.com/en-us/dotnet/api/abstractions.usercreateinfo 'Abstractions\.UserCreateInfo')

The information required to create the user\.

<a name='global__Auth0Client.Auth0Client.CreateUser(Abstractions.UserCreateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [CreateUser\(UserCreateInfo, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.createuser#abstractions-iuserservice-createuser(abstractions-usercreateinfo-system-threading-cancellationtoken) 'Abstractions\.IUserService\.CreateUser\(Abstractions\.UserCreateInfo,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, containing the created user\.