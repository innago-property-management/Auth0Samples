#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services')

## OrganizationService Class

The OrganizationService class provides server\-side implementations
for handling organization\-related operations as defined in the gRPC service\.

```csharp
public class OrganizationService : IdpServiceFacade.Organization.OrganizationBase
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [OrganizationBase](../../../../../IdpServiceFacade/Organization/OrganizationBase/index.md 'IdpServiceFacade\.Organization\.OrganizationBase') &#129106; OrganizationService

| Constructors | |
| :--- | :--- |
| [OrganizationService\(IOrganizationService, ILogger&lt;OrganizationService&gt;\)](OrganizationService(IOrganizationService,ILogger_OrganizationService_).md 'Innago\.Security\.IdpServiceFacade\.Services\.OrganizationService\.OrganizationService\(Abstractions\.IOrganizationService, Microsoft\.Extensions\.Logging\.ILogger\<Innago\.Security\.IdpServiceFacade\.Services\.OrganizationService\>\)') | The OrganizationService class provides server\-side implementations for handling organization\-related operations as defined in the gRPC service\. |

| Methods | |
| :--- | :--- |
| [CreateOrganization\(CreateOrganizationRequest, ServerCallContext\)](CreateOrganization(CreateOrganizationRequest,ServerCallContext).md 'Innago\.Security\.IdpServiceFacade\.Services\.OrganizationService\.CreateOrganization\(IdpServiceFacade\.CreateOrganizationRequest, Grpc\.Core\.ServerCallContext\)') | Handles the creation of a new organization based on the provided request\. This method implements the gRPC OrganizationBase class's definition for the CreateOrganization operation\. |
| [InviteUser\(OrgUserRequest, ServerCallContext\)](InviteUser(OrgUserRequest,ServerCallContext).md 'Innago\.Security\.IdpServiceFacade\.Services\.OrganizationService\.InviteUser\(IdpServiceFacade\.OrgUserRequest, Grpc\.Core\.ServerCallContext\)') | Invites a user to an organization based on the provided request\. This method implements the gRPC OrganizationBase class's definition for the InviteUser operation\. |
