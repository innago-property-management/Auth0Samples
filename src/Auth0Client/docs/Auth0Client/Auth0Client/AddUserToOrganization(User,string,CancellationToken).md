### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.AddUserToOrganization\(User, string, CancellationToken\) Method

Adds a user to an organization in Auth0\.

```csharp
public System.Threading.Tasks.Task AddUserToOrganization(Auth0.ManagementApi.Models.User user, string orgId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.AddUserToOrganization(Auth0.ManagementApi.Models.User,string,System.Threading.CancellationToken).user'></a>

`user` [Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')

The user to add\.

<a name='global__Auth0Client.Auth0Client.AddUserToOrganization(Auth0.ManagementApi.Models.User,string,System.Threading.CancellationToken).orgId'></a>

`orgId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ID of the organization\.

<a name='global__Auth0Client.Auth0Client.AddUserToOrganization(Auth0.ManagementApi.Models.User,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [AddUserToOrganization\(User, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iorganizationservice.addusertoorganization#abstractions-iorganizationservice-addusertoorganization(auth0-managementapi-models-user-system-string-system-threading-cancellationtoken) 'Abstractions\.IOrganizationService\.AddUserToOrganization\(Auth0\.ManagementApi\.Models\.User,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task that represents the asynchronous operation\.