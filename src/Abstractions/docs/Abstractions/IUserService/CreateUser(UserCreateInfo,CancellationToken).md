#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.CreateUser\(UserCreateInfo, CancellationToken\) Method

Creates a new user\.

```csharp
System.Threading.Tasks.Task<User?> CreateUser(Abstractions.UserCreateInfo userCreateInfo, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.CreateUser(Abstractions.UserCreateInfo,System.Threading.CancellationToken).userCreateInfo'></a>

`userCreateInfo` [UserCreateInfo](../UserCreateInfo/index.md 'Abstractions\.UserCreateInfo')

The information required to create the user\.

<a name='Abstractions.IUserService.CreateUser(Abstractions.UserCreateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, containing the created user\.