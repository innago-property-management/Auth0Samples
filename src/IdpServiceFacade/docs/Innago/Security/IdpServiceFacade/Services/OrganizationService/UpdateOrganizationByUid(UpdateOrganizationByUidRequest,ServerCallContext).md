#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services').[OrganizationService](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.OrganizationService')

## OrganizationService\.UpdateOrganizationByUid\(UpdateOrganizationByUidRequest, ServerCallContext\) Method

Updates an organization based on the provided organization\_uid\.
This method implements the gRPC OrganizationBase class's definition for the UpdateOrganizationByUid operation\.

```csharp
public override System.Threading.Tasks.Task<IdpServiceFacade.OrganizationReply> UpdateOrganizationByUid(IdpServiceFacade.UpdateOrganizationByUidRequest request, Grpc.Core.ServerCallContext context);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.Services.OrganizationService.UpdateOrganizationByUid(IdpServiceFacade.UpdateOrganizationByUidRequest,Grpc.Core.ServerCallContext).request'></a>

`request` [UpdateOrganizationByUidRequest](../../../../../IdpServiceFacade/UpdateOrganizationByUidRequest/index.md 'IdpServiceFacade\.UpdateOrganizationByUidRequest')

The request containing the organization UID and update information\.

<a name='Innago.Security.IdpServiceFacade.Services.OrganizationService.UpdateOrganizationByUid(IdpServiceFacade.UpdateOrganizationByUidRequest,Grpc.Core.ServerCallContext).context'></a>

`context` [Grpc\.Core\.ServerCallContext](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servercallcontext 'Grpc\.Core\.ServerCallContext')

The context of the server call, providing metadata and other information\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[OrganizationReply](../../../../../IdpServiceFacade/OrganizationReply/index.md 'IdpServiceFacade\.OrganizationReply')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. The result contains an OrganizationReply object indicating
the result of the update operation\.