#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IAuth0Client](index.md 'Abstractions\.IAuth0Client')

## IAuth0Client\.CreateOrganization\(OrganizationCreateInfo, CancellationToken\) Method

Creates a new organization\.

```csharp
System.Threading.Tasks.Task<Organization> CreateOrganization(Abstractions.OrganizationCreateInfo organizationCreateInfo, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IAuth0Client.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).organizationCreateInfo'></a>

`organizationCreateInfo` [OrganizationCreateInfo](../OrganizationCreateInfo/index.md 'Abstractions\.OrganizationCreateInfo')

The information required to create the organization\.

<a name='Abstractions.IAuth0Client.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Auth0\.ManagementApi\.Models\.Organization](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.organization 'Auth0\.ManagementApi\.Models\.Organization')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, containing the created organization\.