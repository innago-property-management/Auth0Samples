### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.ListOrganizations\(CancellationToken\) Method

Retrieves a list of all organizations from Auth0\.

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Auth0.ManagementApi.Models.Organization>> ListOrganizations(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.ListOrganizations(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [ListOrganizations\(CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iauth0client.listorganizations#abstractions-iauth0client-listorganizations(system-threading-cancellationtoken) 'Abstractions\.IAuth0Client\.ListOrganizations\(System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Auth0\.ManagementApi\.Models\.Organization](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.organization 'Auth0\.ManagementApi\.Models\.Organization')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, containing the list of organizations\.