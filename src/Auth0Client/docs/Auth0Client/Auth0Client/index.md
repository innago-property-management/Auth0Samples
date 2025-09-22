### [Auth0Client](../index.md 'Auth0Client')

## Auth0Client Class

Provides functionality for interacting with Auth0 authentication services\.

```csharp
public class Auth0Client : Abstractions.IAuth0Client, Abstractions.IUserService, Abstractions.IRoleService, Abstractions.IOrganizationService
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; Auth0Client

Implements [Abstractions\.IAuth0Client](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iauth0client 'Abstractions\.IAuth0Client'), [Abstractions\.IUserService](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice 'Abstractions\.IUserService'), [Abstractions\.IRoleService](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iroleservice 'Abstractions\.IRoleService'), [Abstractions\.IOrganizationService](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iorganizationservice 'Abstractions\.IOrganizationService')

| Constructors | |
| :--- | :--- |
| [Auth0Client\(IManagementApiClient, IOptions&lt;Auth0Settings&gt;, ILogger&lt;Auth0Client&gt;, IHttpClientFactory\)](Auth0Client(IManagementApiClient,IOptions_Auth0Settings_,ILogger_Auth0Client_,IHttpClientFactory).md 'global::Auth0Client\.Auth0Client\.Auth0Client\(Auth0\.ManagementApi\.IManagementApiClient, Microsoft\.Extensions\.Options\.IOptions\<Abstractions\.Auth0Settings\>, Microsoft\.Extensions\.Logging\.ILogger\<global::Auth0Client\.Auth0Client\>, System\.Net\.Http\.IHttpClientFactory\)') | Provides functionality for interacting with Auth0 authentication services\. |

| Methods | |
| :--- | :--- |
| [AddUserToOrganization\(string, string, CancellationToken\)](AddUserToOrganization(string,string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.AddUserToOrganization\(string, string, System\.Threading\.CancellationToken\)') | Adds a user to an organization in Auth0\. |
| [Auth0NameCleaner\(\)](Auth0NameCleaner().md 'global::Auth0Client\.Auth0Client\.Auth0NameCleaner\(\)') | |
| [BlockUser\(string, CancellationToken\)](BlockUser(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.BlockUser\(string, System\.Threading\.CancellationToken\)') | Blocks a user by their email address\. |
| [ChangePassword\(string, string, CancellationToken\)](ChangePassword(string,string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.ChangePassword\(string, string, System\.Threading\.CancellationToken\)') | Changes the password for the specified user\. |
| [CreateOrganization\(OrganizationCreateInfo, CancellationToken\)](CreateOrganization(OrganizationCreateInfo,CancellationToken).md 'global::Auth0Client\.Auth0Client\.CreateOrganization\(Abstractions\.OrganizationCreateInfo, System\.Threading\.CancellationToken\)') | Creates a new organization in Auth0\. |
| [CreateRole\(string, string, CancellationToken\)](CreateRole(string,string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.CreateRole\(string, string, System\.Threading\.CancellationToken\)') | Creates a new role in the Auth0 system with the specified name and optional description\. |
| [CreateUser\(UserCreateInfo, CancellationToken\)](CreateUser(UserCreateInfo,CancellationToken).md 'global::Auth0Client\.Auth0Client\.CreateUser\(Abstractions\.UserCreateInfo, System\.Threading\.CancellationToken\)') | Creates a new user in Auth0\. |
| [DisableMfa\(string, CancellationToken\)](DisableMfa(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.DisableMfa\(string, System\.Threading\.CancellationToken\)') | Disables Multi\-Factor Authentication for the specified user\. |
| [EnableMfa\(string, CancellationToken\)](EnableMfa(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.EnableMfa\(string, System\.Threading\.CancellationToken\)') | Enables Multi\-Factor Authentication \(MFA\) for a user |
| [GetRefreshTokenAsyncImplementation\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetRefreshTokenAsyncImplementation(string,IEnumerable_string_,CancellationToken).md 'global::Auth0Client\.Auth0Client\.GetRefreshTokenAsyncImplementation\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves a new token using a refresh token\. |
| [GetTokenAsyncImplementation\(string, string, IEnumerable&lt;string&gt;, CancellationToken\)](GetTokenAsyncImplementation(string,string,IEnumerable_string_,CancellationToken).md 'global::Auth0Client\.Auth0Client\.GetTokenAsyncImplementation\(string, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves a token for the specified user by authenticating with the provided credentials\. |
| [GetUser\(string, CancellationToken\)](GetUser(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.GetUser\(string, System\.Threading\.CancellationToken\)') | Get a user |
| [GetUserMetadata\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUserMetadata(string,IEnumerable_string_,CancellationToken).md 'global::Auth0Client\.Auth0Client\.GetUserMetadata\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves metadata for a user identified by the provided email\. |
| [GetUsers\(string\[\], CancellationToken\)](GetUsers(string[],CancellationToken).md 'global::Auth0Client\.Auth0Client\.GetUsers\(string\[\], System\.Threading\.CancellationToken\)') | Gets List of Users per their Ids |
| [GetUsersMetadataByNameFragment\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUsersMetadataByNameFragment(string,IEnumerable_string_,CancellationToken).md 'global::Auth0Client\.Auth0Client\.GetUsersMetadataByNameFragment\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves a dictionary of user metadata for users whose names or identifiers contain the specified search term\. |
| [GetUsersMetadataByNameOrEmailFragment\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUsersMetadataByNameOrEmailFragment(string,IEnumerable_string_,CancellationToken).md 'global::Auth0Client\.Auth0Client\.GetUsersMetadataByNameOrEmailFragment\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves metadata for users whose name or email matches the given search term\. |
| [HealthCheck\(CancellationToken\)](HealthCheck(CancellationToken).md 'global::Auth0Client\.Auth0Client\.HealthCheck\(System\.Threading\.CancellationToken\)') | Performs a health check on the Auth0 service to verify its availability\. |
| [ListOrganizations\(CancellationToken\)](ListOrganizations(CancellationToken).md 'global::Auth0Client\.Auth0Client\.ListOrganizations\(System\.Threading\.CancellationToken\)') | Retrieves a list of all organizations from Auth0\. |
| [ListUsers\(string, CancellationToken\)](ListUsers(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.ListUsers\(string, System\.Threading\.CancellationToken\)') | Retrieves a list of all users from Auth0\. |
| [MarkUserAsFraud\(string, CancellationToken\)](MarkUserAsFraud(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.MarkUserAsFraud\(string, System\.Threading\.CancellationToken\)') | Marks a user as fraudulent in Auth0\. |
| [MarkUserAsSuspicious\(string, CancellationToken\)](MarkUserAsSuspicious(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.MarkUserAsSuspicious\(string, System\.Threading\.CancellationToken\)') | Marks a user as suspicious in Auth0\. |
| [ResetPassword\(string, CancellationToken\)](ResetPassword(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.ResetPassword\(string, System\.Threading\.CancellationToken\)') | Initiates a password reset for the specified user\. |
| [UnblockUser\(string, CancellationToken\)](UnblockUser(string,CancellationToken).md 'global::Auth0Client\.Auth0Client\.UnblockUser\(string, System\.Threading\.CancellationToken\)') | Unblocks a user in the Auth0 system\. |
