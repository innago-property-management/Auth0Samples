#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IOrganizationService](index.md 'Abstractions\.IOrganizationService')

## IOrganizationService\.AddUserToOrganizationByUid\(User, string, CancellationToken\) Method

Removes a user from an organization\.

```csharp
System.Threading.Tasks.Task<Abstractions.OkError> AddUserToOrganizationByUid(User user, string organizationUid, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IOrganizationService.AddUserToOrganizationByUid(User,string,System.Threading.CancellationToken).user'></a>

`user` [Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')

The user to remove\.

<a name='Abstractions.IOrganizationService.AddUserToOrganizationByUid(User,string,System.Threading.CancellationToken).organizationUid'></a>

`organizationUid` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the organization\.

<a name='Abstractions.IOrganizationService.AddUserToOrganizationByUid(User,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[OkError](../OkError/index.md 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation with success or error information\.