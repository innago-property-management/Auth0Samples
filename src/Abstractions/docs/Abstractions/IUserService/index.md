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
| [ChangePassword\(string, string, CancellationToken\)](ChangePassword(string,string,CancellationToken).md 'Abstractions\.IUserService\.ChangePassword\(string, string, System\.Threading\.CancellationToken\)') | Changes the password for a user identified by the provided email\. |
| [GetUserMetadata\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUserMetadata(string,IEnumerable_string_,CancellationToken).md 'Abstractions\.IUserService\.GetUserMetadata\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves metadata for a user identified by the provided email\. |
| [MarkUserAsFraud\(string, CancellationToken\)](MarkUserAsFraud(string,CancellationToken).md 'Abstractions\.IUserService\.MarkUserAsFraud\(string, System\.Threading\.CancellationToken\)') | Marks a user as fraudulent based on their email address\. |
| [MarkUserAsSuspicious\(string, CancellationToken\)](MarkUserAsSuspicious(string,CancellationToken).md 'Abstractions\.IUserService\.MarkUserAsSuspicious\(string, System\.Threading\.CancellationToken\)') | Marks a user as suspicious based on their email address\. |
| [ResetPassword\(string, CancellationToken\)](ResetPassword(string,CancellationToken).md 'Abstractions\.IUserService\.ResetPassword\(string, System\.Threading\.CancellationToken\)') | Initiates a password reset process for a user identified by their email address\. |
| [ToggleMFA\(string, bool, CancellationToken\)](ToggleMFA(string,bool,CancellationToken).md 'Abstractions\.IUserService\.ToggleMFA\(string, bool, System\.Threading\.CancellationToken\)') | Enables or disables Multi\-Factor Authentication \(MFA\) for a user\. |
