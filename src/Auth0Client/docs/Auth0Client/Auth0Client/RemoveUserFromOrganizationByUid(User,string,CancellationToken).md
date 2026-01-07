### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.RemoveUserFromOrganizationByUid\(User, string, CancellationToken\) Method

Deletes members from an organization in Auth0\.

```csharp
public System.Threading.Tasks.Task<Abstractions.OkError> RemoveUserFromOrganizationByUid(Auth0.ManagementApi.Models.User user, string organizationUid, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.RemoveUserFromOrganizationByUid(Auth0.ManagementApi.Models.User,string,System.Threading.CancellationToken).user'></a>

`user` [Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')

The user to be removed from organization in Auth0\.

<a name='global__Auth0Client.Auth0Client.RemoveUserFromOrganizationByUid(Auth0.ManagementApi.Models.User,string,System.Threading.CancellationToken).organizationUid'></a>

`organizationUid` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ID of the organization\.

<a name='global__Auth0Client.Auth0Client.RemoveUserFromOrganizationByUid(Auth0.ManagementApi.Models.User,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [RemoveUserFromOrganizationByUid\(User, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iorganizationservice.removeuserfromorganizationbyuid#abstractions-iorganizationservice-removeuserfromorganizationbyuid(auth0-managementapi-models-user-system-string-system-threading-cancellationtoken) 'Abstractions\.IOrganizationService\.RemoveUserFromOrganizationByUid\(Auth0\.ManagementApi\.Models\.User,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.