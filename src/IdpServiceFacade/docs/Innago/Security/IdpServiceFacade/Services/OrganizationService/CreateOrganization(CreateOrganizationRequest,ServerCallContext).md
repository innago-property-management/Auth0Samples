#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services').[OrganizationService](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.OrganizationService')

## OrganizationService\.CreateOrganization\(CreateOrganizationRequest, ServerCallContext\) Method

Handles the creation of a new organization based on the provided request\.
This method implements the gRPC OrganizationBase class's definition for the CreateOrganization operation\.

```csharp
public override System.Threading.Tasks.Task<IdpServiceFacade.CreateOrganizationReply> CreateOrganization(IdpServiceFacade.CreateOrganizationRequest request, Grpc.Core.ServerCallContext context);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.Services.OrganizationService.CreateOrganization(IdpServiceFacade.CreateOrganizationRequest,Grpc.Core.ServerCallContext).request'></a>

`request` [CreateOrganizationRequest](../../../../../IdpServiceFacade/CreateOrganizationRequest/index.md 'IdpServiceFacade\.CreateOrganizationRequest')

The request containing the details for creating a new organization\.

<a name='Innago.Security.IdpServiceFacade.Services.OrganizationService.CreateOrganization(IdpServiceFacade.CreateOrganizationRequest,Grpc.Core.ServerCallContext).context'></a>

`context` [Grpc\.Core\.ServerCallContext](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servercallcontext 'Grpc\.Core\.ServerCallContext')

The context of the server call, providing metadata and other information\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CreateOrganizationReply](../../../../../IdpServiceFacade/CreateOrganizationReply/index.md 'IdpServiceFacade\.CreateOrganizationReply')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation\. The result contains a CreateOrganizationReply object with the
operation result\.