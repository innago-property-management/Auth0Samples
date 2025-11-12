### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.UpdateOrganizationByUid\(string, OrganizationUpdateInfo, CancellationToken\) Method

Updates an organization in Auth0 by finding it using the organization\_uid in metadata\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> UpdateOrganizationByUid(string organizationUid, Abstractions.OrganizationUpdateInfo updateInfo, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.UpdateOrganizationByUid(string,Abstractions.OrganizationUpdateInfo,System.Threading.CancellationToken).organizationUid'></a>

`organizationUid` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier stored in the organization's metadata\.

<a name='global__Auth0Client.Auth0Client.UpdateOrganizationByUid(string,Abstractions.OrganizationUpdateInfo,System.Threading.CancellationToken).updateInfo'></a>

`updateInfo` [Abstractions\.OrganizationUpdateInfo](https://learn.microsoft.com/en-us/dotnet/api/abstractions.organizationupdateinfo 'Abstractions\.OrganizationUpdateInfo')

The information to update for the organization\.

<a name='global__Auth0Client.Auth0Client.UpdateOrganizationByUid(string,Abstractions.OrganizationUpdateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [UpdateOrganizationByUid\(string, OrganizationUpdateInfo, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iorganizationservice.updateorganizationbyuid#abstractions-iorganizationservice-updateorganizationbyuid(system-string-abstractions-organizationupdateinfo-system-threading-cancellationtoken) 'Abstractions\.IOrganizationService\.UpdateOrganizationByUid\(System\.String,Abstractions\.OrganizationUpdateInfo,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing the update result\.