#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services').[OrganizationService](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.OrganizationService')

## OrganizationService\.InviteUser\(OrgUserRequest, ServerCallContext\) Method

Invites a user to an organization based on the provided request\.
This method implements the gRPC OrganizationBase class's definition for the InviteUser operation\.

```csharp
public override System.Threading.Tasks.Task<IdpServiceFacade.OrganizationReply> InviteUser(IdpServiceFacade.OrgUserRequest request, Grpc.Core.ServerCallContext context);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.Services.OrganizationService.InviteUser(IdpServiceFacade.OrgUserRequest,Grpc.Core.ServerCallContext).request'></a>

`request` [OrgUserRequest](../../../../../IdpServiceFacade/OrgUserRequest/index.md 'IdpServiceFacade\.OrgUserRequest')

The request containing the organization's name, and the user's email\.

<a name='Innago.Security.IdpServiceFacade.Services.OrganizationService.InviteUser(IdpServiceFacade.OrgUserRequest,Grpc.Core.ServerCallContext).context'></a>

`context` [Grpc\.Core\.ServerCallContext](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servercallcontext 'Grpc\.Core\.ServerCallContext')

The context of the server call, providing metadata and other information\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[OrganizationReply](../../../../../IdpServiceFacade/OrganizationReply/index.md 'IdpServiceFacade\.OrganizationReply')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. The result contains an OrganizationReply object indicating
the result of the invitation process\.