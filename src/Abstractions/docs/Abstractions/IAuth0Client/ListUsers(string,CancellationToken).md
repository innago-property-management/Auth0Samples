#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IAuth0Client](index.md 'Abstractions\.IAuth0Client')

## IAuth0Client\.ListUsers\(string, CancellationToken\) Method

Retrieves a list of all users\.

```csharp
System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<User>> ListUsers(string luceneQuery="user_id:*", System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IAuth0Client.ListUsers(string,System.Threading.CancellationToken).luceneQuery'></a>

`luceneQuery` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Abstractions.IAuth0Client.ListUsers(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, containing the list of users\.