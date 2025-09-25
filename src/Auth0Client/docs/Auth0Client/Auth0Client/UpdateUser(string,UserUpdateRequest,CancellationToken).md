### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.UpdateUser\(string, UserUpdateRequest, CancellationToken\) Method

Updates a user with the specified email by setting the provided key\-value pairs\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> UpdateUser(string email, Auth0.ManagementApi.Models.UserUpdateRequest request, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.UpdateUser(string,Auth0.ManagementApi.Models.UserUpdateRequest,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='global__Auth0Client.Auth0Client.UpdateUser(string,Auth0.ManagementApi.Models.UserUpdateRequest,System.Threading.CancellationToken).request'></a>

`request` [Auth0\.ManagementApi\.Models\.UserUpdateRequest](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.userupdaterequest 'Auth0\.ManagementApi\.Models\.UserUpdateRequest')

<a name='global__Auth0Client.Auth0Client.UpdateUser(string,Auth0.ManagementApi.Models.UserUpdateRequest,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

Implements [UpdateUser\(string, UserUpdateRequest, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.updateuser#abstractions-iuserservice-updateuser(system-string-auth0-managementapi-models-userupdaterequest-system-threading-cancellationtoken) 'Abstractions\.IUserService\.UpdateUser\(System\.String,Auth0\.ManagementApi\.Models\.UserUpdateRequest,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')