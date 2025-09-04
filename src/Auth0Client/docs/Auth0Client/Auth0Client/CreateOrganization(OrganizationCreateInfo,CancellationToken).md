### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CreateOrganization\(OrganizationCreateInfo, CancellationToken\) Method

Creates a new organization in Auth0\.

```csharp
public System.Threading.Tasks.Task<Auth0.ManagementApi.Models.Organization> CreateOrganization(Abstractions.OrganizationCreateInfo organizationCreateInfo, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).organizationCreateInfo'></a>

`organizationCreateInfo` [Abstractions\.OrganizationCreateInfo](https://learn.microsoft.com/en-us/dotnet/api/abstractions.organizationcreateinfo 'Abstractions\.OrganizationCreateInfo')

The information required to create the organization\.

<a name='global__Auth0Client.Auth0Client.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [CreateOrganization\(OrganizationCreateInfo, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iauth0client.createorganization#abstractions-iauth0client-createorganization(abstractions-organizationcreateinfo-system-threading-cancellationtoken) 'Abstractions\.IAuth0Client\.CreateOrganization\(Abstractions\.OrganizationCreateInfo,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Auth0\.ManagementApi\.Models\.Organization](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.organization 'Auth0\.ManagementApi\.Models\.Organization')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, containing the created organization\.