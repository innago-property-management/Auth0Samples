#### [Innago\.Security\.IdpServiceFacade](../../../index.md 'index')
### [IdpServiceFacade](../../index.md 'IdpServiceFacade').[User](../index.md 'IdpServiceFacade\.User').[UserBase](index.md 'IdpServiceFacade\.User\.UserBase')

## User\.UserBase\.InitiatePasswordReset\(UserRequest, ServerCallContext\) Method

Initiates a password reset

```csharp
public virtual System.Threading.Tasks.Task<IdpServiceFacade.InitiatePasswordResetReply> InitiatePasswordReset(IdpServiceFacade.UserRequest request, Grpc.Core.ServerCallContext context);
```
#### Parameters

<a name='IdpServiceFacade.User.UserBase.InitiatePasswordReset(IdpServiceFacade.UserRequest,Grpc.Core.ServerCallContext).request'></a>

`request` [UserRequest](../../UserRequest/index.md 'IdpServiceFacade\.UserRequest')

The request received from the client\.

<a name='IdpServiceFacade.User.UserBase.InitiatePasswordReset(IdpServiceFacade.UserRequest,Grpc.Core.ServerCallContext).context'></a>

`context` [Grpc\.Core\.ServerCallContext](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servercallcontext 'Grpc\.Core\.ServerCallContext')

The context of the server\-side call handler being invoked\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[InitiatePasswordResetReply](../../InitiatePasswordResetReply/index.md 'IdpServiceFacade\.InitiatePasswordResetReply')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
The response to send back to the client \(wrapped by a task\)\.