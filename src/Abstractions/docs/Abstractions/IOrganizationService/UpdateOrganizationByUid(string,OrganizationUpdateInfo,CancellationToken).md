#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IOrganizationService](index.md 'Abstractions\.IOrganizationService')

## IOrganizationService\.UpdateOrganizationByUid\(string, OrganizationUpdateInfo, CancellationToken\) Method

Updates an organization identified by the provided organization\_uid in metadata\.

```csharp
ITask<Abstractions.OkError> UpdateOrganizationByUid(string organizationUid, Abstractions.OrganizationUpdateInfo updateInfo, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IOrganizationService.UpdateOrganizationByUid(string,Abstractions.OrganizationUpdateInfo,System.Threading.CancellationToken).organizationUid'></a>

`organizationUid` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier \(organization\_uid\) stored in the organization's metadata\.

<a name='Abstractions.IOrganizationService.UpdateOrganizationByUid(string,Abstractions.OrganizationUpdateInfo,System.Threading.CancellationToken).updateInfo'></a>

`updateInfo` [OrganizationUpdateInfo](../OrganizationUpdateInfo/index.md 'Abstractions\.OrganizationUpdateInfo')

The information to update for the organization\.

<a name='Abstractions.IOrganizationService.UpdateOrganizationByUid(string,Abstractions.OrganizationUpdateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that represents the asynchronous operation, containing the result of the operation as an
[OkError](../OkError/index.md 'Abstractions\.OkError') object\.