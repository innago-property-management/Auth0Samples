#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IAuth0Client](index.md 'Abstractions\.IAuth0Client')

## IAuth0Client\.AddUserToOrganization\(string, string, CancellationToken\) Method

Adds a user to an organization\.

```csharp
System.Threading.Tasks.Task AddUserToOrganization(string userId, string orgId, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IAuth0Client.AddUserToOrganization(string,string,System.Threading.CancellationToken).userId'></a>

`userId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ID of the user to add\.

<a name='Abstractions.IAuth0Client.AddUserToOrganization(string,string,System.Threading.CancellationToken).orgId'></a>

`orgId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The ID of the organization\.

<a name='Abstractions.IAuth0Client.AddUserToOrganization(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task 'System\.Threading\.Tasks\.Task')  
A task representing the asynchronous operation\.