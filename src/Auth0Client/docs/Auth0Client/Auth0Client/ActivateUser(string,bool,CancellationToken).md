### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.ActivateUser\(string, bool, CancellationToken\) Method

Activates or deactivates a user based on their identity ID\.

```csharp
public MorseCode.ITask.ITask<Abstractions.OkError> ActivateUser(string identityId, bool isActivate, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.ActivateUser(string,bool,System.Threading.CancellationToken).identityId'></a>

`identityId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identity ID of the user to activate/deactivate\.

<a name='global__Auth0Client.Auth0Client.ActivateUser(string,bool,System.Threading.CancellationToken).isActivate'></a>

`isActivate` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

True to activate the user, false to deactivate\.

<a name='global__Auth0Client.Auth0Client.ActivateUser(string,bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

Implements [ActivateUser\(string, bool, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.activateuser#abstractions-iuserservice-activateuser(system-string-system-boolean-system-threading-cancellationtoken) 'Abstractions\.IUserService\.ActivateUser\(System\.String,System\.Boolean,System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
An [Abstractions\.OkError](https://learn.microsoft.com/en-us/dotnet/api/abstractions.okerror 'Abstractions\.OkError') object indicating success or containing an error message if the operation fails\.