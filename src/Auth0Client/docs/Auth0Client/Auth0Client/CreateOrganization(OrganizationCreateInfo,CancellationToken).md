### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CreateOrganization\(OrganizationCreateInfo, CancellationToken\) Method

Creates a new organization in Auth0\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> CreateOrganization(Abstractions.OrganizationCreateInfo organizationCreateInfo, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).organizationCreateInfo'></a>

`organizationCreateInfo` [Abstractions\.OrganizationCreateInfo](https://learn.microsoft.com/en-us/dotnet/api/abstractions.organizationcreateinfo 'Abstractions\.OrganizationCreateInfo')

The information required to create the organization\.

<a name='global__Auth0Client.Auth0Client.CreateOrganization(Abstractions.OrganizationCreateInfo,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [CreateOrganization\(OrganizationCreateInfo, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iorganizationservice.createorganization#abstractions-iorganizationservice-createorganization(abstractions-organizationcreateinfo-system-threading-cancellationtoken) 'Abstractions\.IOrganizationService\.CreateOrganization\(Abstractions\.OrganizationCreateInfo,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing the created organization\.