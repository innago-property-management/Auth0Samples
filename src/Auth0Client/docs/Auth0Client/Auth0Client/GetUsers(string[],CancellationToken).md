### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.GetUsers\(string\[\], CancellationToken\) Method

Gets List of Users per their Ids

```csharp
public System.Threading.Tasks.Task<System.Collections.Generic.List<Auth0.ManagementApi.Models.User>> GetUsers(string[] oruUid, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.GetUsers(string[],System.Threading.CancellationToken).oruUid'></a>

`oruUid` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[\[\]](https://learn.microsoft.com/en-us/dotnet/api/system.array 'System\.Array')

<a name='global__Auth0Client.Auth0Client.GetUsers(string[],System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [GetUsers\(string\[\], CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iauth0client.getusers#abstractions-iauth0client-getusers(system-string[]-system-threading-cancellationtoken) 'Abstractions\.IAuth0Client\.GetUsers\(System\.String\[\],System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
Returns a list of user
