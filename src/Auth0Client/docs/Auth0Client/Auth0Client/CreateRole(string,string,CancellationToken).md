### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CreateRole\(string, string, CancellationToken\) Method

Creates a new role in Auth0\.

```csharp
public System.Threading.Tasks.Task<Auth0.ManagementApi.Models.Role> CreateRole(string description, string name, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CreateRole(string,string,System.Threading.CancellationToken).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The description of the role\.

<a name='global__Auth0Client.Auth0Client.CreateRole(string,string,System.Threading.CancellationToken).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the role\.

<a name='global__Auth0Client.Auth0Client.CreateRole(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Auth0\.ManagementApi\.Models\.Role](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.role 'Auth0\.ManagementApi\.Models\.Role')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, containing the created role\.