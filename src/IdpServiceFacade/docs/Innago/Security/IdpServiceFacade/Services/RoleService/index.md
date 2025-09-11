#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services')

## RoleService Class

Provides services for managing roles by interacting with external services
such as Auth0 and facilitates communication over gRPC for role\-related operations\.

```csharp
public class RoleService : IdpServiceFacade.Role.RoleBase
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [RoleBase](../../../../../IdpServiceFacade/Role/RoleBase/index.md 'IdpServiceFacade\.Role\.RoleBase') &#129106; RoleService

| Constructors | |
| :--- | :--- |
| [RoleService\(IRoleService, ILogger&lt;RoleService&gt;\)](RoleService(IRoleService,ILogger_RoleService_).md 'Innago\.Security\.IdpServiceFacade\.Services\.RoleService\.RoleService\(Abstractions\.IRoleService, Microsoft\.Extensions\.Logging\.ILogger\<Innago\.Security\.IdpServiceFacade\.Services\.RoleService\>\)') | Provides services for managing roles by interacting with external services such as Auth0 and facilitates communication over gRPC for role\-related operations\. |

| Methods | |
| :--- | :--- |
| [CreateRole\(CreateRoleRequest, ServerCallContext\)](CreateRole(CreateRoleRequest,ServerCallContext).md 'Innago\.Security\.IdpServiceFacade\.Services\.RoleService\.CreateRole\(IdpServiceFacade\.CreateRoleRequest, Grpc\.Core\.ServerCallContext\)') | Creates a role using the provided role name and description\. |
