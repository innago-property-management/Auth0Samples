#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IOrganizationService](index.md 'Abstractions\.IOrganizationService')

## IOrganizationService\.ListOrganizations\(CancellationToken\) Method

Retrieves a list of all organizations available in the system\.

```csharp
ITask<System.Collections.Generic.IEnumerable<Abstractions.Org>> ListOrganizations(System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IOrganizationService.ListOrganizations(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that represents the asynchronous operation, containing a collection of [Org](../Org/index.md 'Abstractions\.Org') objects
representing the organizations\.