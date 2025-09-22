#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## IUserService Interface

Defines a contract for user\-related operations such as password management, user status updates,
and multifactor authentication \(MFA\) toggling\.

```csharp
public interface IUserService
```

Derived  
&#8627; [IAuth0Client](../IAuth0Client/index.md 'Abstractions\.IAuth0Client')

| Methods | |
| :--- | :--- |
| [BlockUser\(string, CancellationToken\)](BlockUser(string,CancellationToken).md 'Abstractions\.IUserService\.BlockUser\(string, System\.Threading\.CancellationToken\)') | Blocks a user based on their email address, preventing them from accessing the system\. |
| [ChangePassword\(string, string, CancellationToken\)](ChangePassword(string,string,CancellationToken).md 'Abstractions\.IUserService\.ChangePassword\(string, string, System\.Threading\.CancellationToken\)') | Changes the password for a user identified by the provided email\. |
| [DisableMfa\(string, CancellationToken\)](DisableMfa(string,CancellationToken).md 'Abstractions\.IUserService\.DisableMfa\(string, System\.Threading\.CancellationToken\)') | Disables Multi\-Factor Authentication \(MFA\) for a user\. |
| [EnableMfa\(string, CancellationToken\)](EnableMfa(string,CancellationToken).md 'Abstractions\.IUserService\.EnableMfa\(string, System\.Threading\.CancellationToken\)') | Disables Multi\-Factor Authentication \(MFA\) for a user for next login |
| [GetRefreshTokenAsyncImplementation\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetRefreshTokenAsyncImplementation(string,IEnumerable_string_,CancellationToken).md 'Abstractions\.IUserService\.GetRefreshTokenAsyncImplementation\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves token for a user identified by the provided username and password\. |
| [GetTokenAsyncImplementation\(string, string, IEnumerable&lt;string&gt;, CancellationToken\)](GetTokenAsyncImplementation(string,string,IEnumerable_string_,CancellationToken).md 'Abstractions\.IUserService\.GetTokenAsyncImplementation\(string, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves token for a user identified by the provided username and password\. |
| [GetUserMetadata\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUserMetadata(string,IEnumerable_string_,CancellationToken).md 'Abstractions\.IUserService\.GetUserMetadata\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves metadata for a user identified by the provided email\. |
| [GetUsersMetadataByNameFragment\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUsersMetadataByNameFragment(string,IEnumerable_string_,CancellationToken).md 'Abstractions\.IUserService\.GetUsersMetadataByNameFragment\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves a dictionary of user metadata for users whose names or identifiers contain the specified search term\. |
| [GetUsersMetadataByNameOrEmailFragment\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUsersMetadataByNameOrEmailFragment(string,IEnumerable_string_,CancellationToken).md 'Abstractions\.IUserService\.GetUsersMetadataByNameOrEmailFragment\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves metadata for users whose name or email matches the given search term\. |
| [MarkUserAsFraud\(string, CancellationToken\)](MarkUserAsFraud(string,CancellationToken).md 'Abstractions\.IUserService\.MarkUserAsFraud\(string, System\.Threading\.CancellationToken\)') | Marks a user as fraudulent based on their email address\. |
| [MarkUserAsSuspicious\(string, CancellationToken\)](MarkUserAsSuspicious(string,CancellationToken).md 'Abstractions\.IUserService\.MarkUserAsSuspicious\(string, System\.Threading\.CancellationToken\)') | Marks a user as suspicious based on their email address\. |
| [ResetPassword\(string, CancellationToken\)](ResetPassword(string,CancellationToken).md 'Abstractions\.IUserService\.ResetPassword\(string, System\.Threading\.CancellationToken\)') | Initiates a password reset process for a user identified by their email address\. |
| [UnblockUser\(string, CancellationToken\)](UnblockUser(string,CancellationToken).md 'Abstractions\.IUserService\.UnblockUser\(string, System\.Threading\.CancellationToken\)') | Unblocks a user based on their email address, restoring their access to the system\. |
