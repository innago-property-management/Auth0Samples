### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.GetDetailUserByEmail\(string, CancellationToken\) Method

Gets a user by email with detailed information including user metadata\.

```csharp
public System.Threading.Tasks.Task<Auth0.ManagementApi.Models.User?> GetDetailUserByEmail(string email, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.GetDetailUserByEmail(string,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The user's email address\.

<a name='global__Auth0Client.Auth0Client.GetDetailUserByEmail(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [GetDetailUserByEmail\(string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.getdetailuserbyemail#abstractions-iuserservice-getdetailuserbyemail(system-string-system-threading-cancellationtoken) 'Abstractions\.IUserService\.GetDetailUserByEmail\(System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The user with all details including metadata, or null if not found\.