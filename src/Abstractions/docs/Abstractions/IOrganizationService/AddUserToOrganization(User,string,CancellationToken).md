#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IOrganizationService](index.md 'Abstractions\.IOrganizationService')

## IOrganizationService\.AddUserToOrganization\(User, string, CancellationToken\) Method

Adds a user to an organization\.

```csharp
System.Threading.Tasks.Task AddUserToOrganization(User user, string orgId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IOrganizationService.AddUserToOrganization(User,string,System.Threading.CancellationToken).user'></a>

`user` [Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')

The user to add\.

<a name='Abstractions.IOrganizationService.AddUserToOrganization(User,string,System.Threading.CancellationToken).orgId'></a>

`orgId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ID of the organization\.

<a name='Abstractions.IOrganizationService.AddUserToOrganization(User,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task representing the asynchronous operation\.