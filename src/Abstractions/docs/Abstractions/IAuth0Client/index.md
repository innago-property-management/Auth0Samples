#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## IAuth0Client Interface

Represents a client for interacting with Auth0 authentication services\.

```csharp
public interface IAuth0Client : Abstractions.IUserService, Abstractions.IRoleService, Abstractions.IOrganizationService, Abstractions.IAuthService
```

Implements [IUserService](../IUserService/index.md 'Abstractions\.IUserService'), [IRoleService](../IRoleService/index.md 'Abstractions\.IRoleService'), [IOrganizationService](../IOrganizationService/index.md 'Abstractions\.IOrganizationService'), [IAuthService](../IAuthService/index.md 'Abstractions\.IAuthService')

| Methods | |
| :--- | :--- |
| [GetUser\(string, CancellationToken\)](GetUser(string,CancellationToken).md 'Abstractions\.IAuth0Client\.GetUser\(string, System\.Threading\.CancellationToken\)') | Gets a user by their id\. |
| [GetUsers\(string\[\], CancellationToken\)](GetUsers(string[],CancellationToken).md 'Abstractions\.IAuth0Client\.GetUsers\(string\[\], System\.Threading\.CancellationToken\)') | Get All the Users based on their oru Ids |
| [HealthCheck\(CancellationToken\)](HealthCheck(CancellationToken).md 'Abstractions\.IAuth0Client\.HealthCheck\(System\.Threading\.CancellationToken\)') | Performs a health check on the Auth0 service to verify its availability\. |
