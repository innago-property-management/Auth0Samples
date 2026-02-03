#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## IAuthService Interface

Defines operations related to role management\.

```csharp
public interface IAuthService
```

Derived  
&#8627; [IAuth0Client](../IAuth0Client/index.md 'Abstractions\.IAuth0Client')

| Methods | |
| :--- | :--- |
| [GetClientCredentialsToken\(string, string, string, CancellationToken\)](GetClientCredentialsToken(string,string,string,CancellationToken).md 'Abstractions\.IAuthService\.GetClientCredentialsToken\(string, string, string, System\.Threading\.CancellationToken\)') | Retrieves an OAuth2 Client Credentials token as defined in RFC 6749 Section 4\.4\. |
| [GetToken\(string, string, string, CancellationToken\)](GetToken(string,string,string,CancellationToken).md 'Abstractions\.IAuthService\.GetToken\(string, string, string, System\.Threading\.CancellationToken\)') | Generate token based on ClientId and ClientSecret |
