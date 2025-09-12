#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IRoleService](index.md 'Abstractions\.IRoleService')

## IRoleService\.CreateRole\(string, string, CancellationToken\) Method

Creates a new role with the specified name and description\.

```csharp
ITask<Abstractions.OkError> CreateRole(string roleName, string? description=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Abstractions.IRoleService.CreateRole(string,string,System.Threading.CancellationToken).roleName'></a>

`roleName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the role to create\. This is a required parameter\.

<a name='Abstractions.IRoleService.CreateRole(string,string,System.Threading.CancellationToken).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional description of the role\.

<a name='Abstractions.IRoleService.CreateRole(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
Returns an [OkError](../OkError/index.md 'Abstractions\.OkError') indicating whether the role creation was successful,
            and, if not, the associated error message\.