#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## IOrganizationService Interface

Defines operations for managing organizations\.

```csharp
public interface IOrganizationService
```

Derived  
&#8627; [IAuth0Client](../IAuth0Client/index.md 'Abstractions\.IAuth0Client')

| Methods | |
| :--- | :--- |
| [AddUserToOrganization\(User, string, CancellationToken\)](AddUserToOrganization(User,string,CancellationToken).md 'Abstractions\.IOrganizationService\.AddUserToOrganization\(User, string, System\.Threading\.CancellationToken\)') | Adds a user to an organization\. |
| [CreateOrganization\(OrganizationCreateInfo, CancellationToken\)](CreateOrganization(OrganizationCreateInfo,CancellationToken).md 'Abstractions\.IOrganizationService\.CreateOrganization\(Abstractions\.OrganizationCreateInfo, System\.Threading\.CancellationToken\)') | Creates a new organization with the provided information\. |
| [InviteUser\(string, string, CancellationToken\)](InviteUser(string,string,CancellationToken).md 'Abstractions\.IOrganizationService\.InviteUser\(string, string, System\.Threading\.CancellationToken\)') | Sends an invitation to a user to join the specified organization\. |
| [ListOrganizations\(CancellationToken\)](ListOrganizations(CancellationToken).md 'Abstractions\.IOrganizationService\.ListOrganizations\(System\.Threading\.CancellationToken\)') | Retrieves a list of all organizations available in the system\. |
| [UpdateOrganizationByUid\(string, OrganizationUpdateInfo, CancellationToken\)](UpdateOrganizationByUid(string,OrganizationUpdateInfo,CancellationToken).md 'Abstractions\.IOrganizationService\.UpdateOrganizationByUid\(string, Abstractions\.OrganizationUpdateInfo, System\.Threading\.CancellationToken\)') | Updates an organization identified by the provided organization\_uid in metadata\. |
