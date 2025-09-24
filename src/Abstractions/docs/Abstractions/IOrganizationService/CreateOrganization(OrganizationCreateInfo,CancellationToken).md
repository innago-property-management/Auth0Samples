#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IOrganizationService](index.md 'Abstractions\.IOrganizationService')

## IOrganizationService\.CreateOrganization\(OrganizationCreateInfo, CancellationToken\) Method

Creates a new organization with the provided information\.

```csharp
ITask<Abstractions.OkError> CreateOrganization(Abstractions.OrganizationCreateInfo organizationCreateInfo, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IOrganizationService.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).organizationCreateInfo'></a>

`organizationCreateInfo` [OrganizationCreateInfo](../OrganizationCreateInfo/index.md 'Abstractions\.OrganizationCreateInfo')

The information required for creating the organization\.

<a name='Abstractions.IOrganizationService.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that represents the asynchronous operation, containing the result of the operation as an
[OkError](../OkError/index.md 'Abstractions\.OkError') object\.