#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IOrganizationService](index.md 'Abstractions\.IOrganizationService')

## IOrganizationService\.RemoveUserFromOrganizationByUid\(User, string, CancellationToken\) Method

```csharp
System.Threading.Tasks.Task<Abstractions.OkError> RemoveUserFromOrganizationByUid(User user, string organizationUid, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IOrganizationService.RemoveUserFromOrganizationByUid(User,string,System.Threading.CancellationToken).user'></a>

`user` [Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')

<a name='Abstractions.IOrganizationService.RemoveUserFromOrganizationByUid(User,string,System.Threading.CancellationToken).organizationUid'></a>

`organizationUid` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IOrganizationService.RemoveUserFromOrganizationByUid(User,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[OkError](../OkError/index.md 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')