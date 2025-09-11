#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services').[RoleService](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.RoleService')

## RoleService\.CreateRole\(CreateRoleRequest, ServerCallContext\) Method

Creates a role using the provided role name and description\.

```csharp
public override System.Threading.Tasks.Task<IdpServiceFacade.CreateRoleResponse> CreateRole(IdpServiceFacade.CreateRoleRequest request, Grpc.Core.ServerCallContext context);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.Services.RoleService.CreateRole(IdpServiceFacade.CreateRoleRequest,Grpc.Core.ServerCallContext).request'></a>

`request` [CreateRoleRequest](../../../../../IdpServiceFacade/CreateRoleRequest/index.md 'IdpServiceFacade\.CreateRoleRequest')

The request containing role details such as name and description\.

<a name='Innago.Security.IdpServiceFacade.Services.RoleService.CreateRole(IdpServiceFacade.CreateRoleRequest,Grpc.Core.ServerCallContext).context'></a>

`context` [Grpc\.Core\.ServerCallContext](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servercallcontext 'Grpc\.Core\.ServerCallContext')

The server call context for the gRPC call\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[CreateRoleResponse](../../../../../IdpServiceFacade/CreateRoleResponse/index.md 'IdpServiceFacade\.CreateRoleResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
Returns a [CreateRoleResponse](../../../../../IdpServiceFacade/CreateRoleResponse/index.md 'IdpServiceFacade\.CreateRoleResponse') containing information about the outcome of the create operation\.