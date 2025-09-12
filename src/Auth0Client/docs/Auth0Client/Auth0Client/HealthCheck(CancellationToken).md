### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.HealthCheck\(CancellationToken\) Method

Performs a health check on the Auth0 service to verify its availability\.

```csharp
public System.Threading.Tasks.Task<bool> HealthCheck(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.HealthCheck(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [HealthCheck\(CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iauth0client.healthcheck#abstractions-iauth0client-healthcheck(system-threading-cancellationtoken) 'Abstractions\.IAuth0Client\.HealthCheck\(System\.Threading\.CancellationToken\)')

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, containing a boolean indicating the health status of the Auth0 service\.