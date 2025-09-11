### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CreateRole\(string, string, CancellationToken\) Method

Creates a new role in the Auth0 system with the specified name and optional description\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> CreateRole(string roleName, string? description=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CreateRole(string,string,System.Threading.CancellationToken).roleName'></a>

`roleName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the role to be created\. This value is required and must be unique\.

<a name='global__Auth0Client.Auth0Client.CreateRole(string,string,System.Threading.CancellationToken).description'></a>

`description` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional description for the role\. If not provided, an empty string will be used\.

<a name='global__Auth0Client.Auth0Client.CreateRole(string,string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token used to cancel the operation if needed\.

Implements [CreateRole\(string, string, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iroleservice.createrole#abstractions-iroleservice-createrole(system-string-system-string-system-threading-cancellationtoken) 'Abstractions\.IRoleService\.CreateRole\(System\.String,System\.String,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
An instance of [Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError') indicating whether the operation was successful or an error message if
it failed\.