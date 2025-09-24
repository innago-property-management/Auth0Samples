#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IOrganizationService](index.md 'Abstractions\.IOrganizationService')

## IOrganizationService\.InviteUser\(string, string, CancellationToken\) Method

Sends an invitation to a user to join the specified organization\.

```csharp
ITask<Abstractions.OkError> InviteUser(string organizationId, string userEmail, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IOrganizationService.InviteUser(string,string,System.Threading.CancellationToken).organizationId'></a>

`organizationId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The auth0 ID of the organization to invite the user to\.

<a name='Abstractions.IOrganizationService.InviteUser(string,string,System.Threading.CancellationToken).userEmail'></a>

`userEmail` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user to be invited\.

<a name='Abstractions.IOrganizationService.InviteUser(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that represents the asynchronous operation, containing the result of the operation as an
[OkError](../OkError/index.md 'Abstractions\.OkError') object\.