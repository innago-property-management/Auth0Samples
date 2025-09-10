#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## IAuth0Client Interface

Represents a client for interacting with Auth0 authentication services\.

```csharp
public interface IAuth0Client : Abstractions.IUserService
```

Implements [IUserService](../IUserService/index.md 'Abstractions\.IUserService')

| Methods | |
| :--- | :--- |
| [AddUserToOrganization\(string, string, CancellationToken\)](AddUserToOrganization(string,string,CancellationToken).md 'Abstractions\.IAuth0Client\.AddUserToOrganization\(string, string, System\.Threading\.CancellationToken\)') | Adds a user to an organization\. |
| [CreateOrganization\(OrganizationCreateInfo, CancellationToken\)](CreateOrganization(OrganizationCreateInfo,CancellationToken).md 'Abstractions\.IAuth0Client\.CreateOrganization\(Abstractions\.OrganizationCreateInfo, System\.Threading\.CancellationToken\)') | Creates a new organization\. |
| [CreateUser\(UserCreateInfo, CancellationToken\)](CreateUser(UserCreateInfo,CancellationToken).md 'Abstractions\.IAuth0Client\.CreateUser\(Abstractions\.UserCreateInfo, System\.Threading\.CancellationToken\)') | Creates a new user\. |
| [GetUser\(string, CancellationToken\)](GetUser(string,CancellationToken).md 'Abstractions\.IAuth0Client\.GetUser\(string, System\.Threading\.CancellationToken\)') | Gets a user by their id\. |
| [GetUsers\(string\[\], CancellationToken\)](GetUsers(string[],CancellationToken).md 'Abstractions\.IAuth0Client\.GetUsers\(string\[\], System\.Threading\.CancellationToken\)') | Get All the Users based on their oru Ids |
| [HealthCheck\(CancellationToken\)](HealthCheck(CancellationToken).md 'Abstractions\.IAuth0Client\.HealthCheck\(System\.Threading\.CancellationToken\)') | Performs a health check on the Auth0 service to verify its availability\. |
| [ListOrganizations\(CancellationToken\)](ListOrganizations(CancellationToken).md 'Abstractions\.IAuth0Client\.ListOrganizations\(System\.Threading\.CancellationToken\)') | Retrieves a list of all organizations\. |
| [ListUsers\(string, CancellationToken\)](ListUsers(string,CancellationToken).md 'Abstractions\.IAuth0Client\.ListUsers\(string, System\.Threading\.CancellationToken\)') | Retrieves a list of all users\. |
