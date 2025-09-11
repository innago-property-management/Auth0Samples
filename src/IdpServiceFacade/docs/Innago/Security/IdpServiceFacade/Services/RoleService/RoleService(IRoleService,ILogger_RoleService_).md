#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services').[RoleService](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.RoleService')

## RoleService\(IRoleService, ILogger\<RoleService\>\) Constructor

Provides services for managing roles by interacting with external services
such as Auth0 and facilitates communication over gRPC for role\-related operations\.

```csharp
public RoleService(Abstractions.IRoleService externalService, Microsoft.Extensions.Logging.ILogger<Innago.Security.IdpServiceFacade.Services.RoleService> logger);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.Services.RoleService.RoleService(Abstractions.IRoleService,Microsoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.RoleService_).externalService'></a>

`externalService` [Abstractions\.IRoleService](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iroleservice 'Abstractions\.IRoleService')

The external role service implementation\.

<a name='Innago.Security.IdpServiceFacade.Services.RoleService.RoleService(Abstractions.IRoleService,Microsoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.RoleService_).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[RoleService](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.RoleService')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

The logger instance for this service\.