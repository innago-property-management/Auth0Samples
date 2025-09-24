### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.InviteUser\(string, string, CancellationToken\) Method

Sends an invitation to a user to join the specified organization\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> InviteUser(string organizationId, string userEmail, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.InviteUser(string,string,System.Threading.CancellationToken).organizationId'></a>

`organizationId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The auth0 ID of the organization to invite the user to\.

<a name='global__Auth0Client.Auth0Client.InviteUser(string,string,System.Threading.CancellationToken).userEmail'></a>

`userEmail` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user to be invited\.

<a name='global__Auth0Client.Auth0Client.InviteUser(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

Implements [InviteUser\(string, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iorganizationservice.inviteuser#abstractions-iorganizationservice-inviteuser(system-string-system-string-system-threading-cancellationtoken) 'Abstractions\.IOrganizationService\.InviteUser\(System\.String,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing the result of the operation as an
[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError') object\.