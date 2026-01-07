#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## ClientCredentialsToken Class

Represents an OAuth2 Client Credentials token response as defined in RFC 6749 Section 4\.4\.3\.

```csharp
public record ClientCredentialsToken : System.IEquatable<Abstractions.ClientCredentialsToken>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; ClientCredentialsToken

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[ClientCredentialsToken](index.md 'Abstractions\.ClientCredentialsToken')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [ClientCredentialsToken\(string, string, int, string\)](ClientCredentialsToken(string,string,int,string).md 'Abstractions\.ClientCredentialsToken\.ClientCredentialsToken\(string, string, int, string\)') | Represents an OAuth2 Client Credentials token response as defined in RFC 6749 Section 4\.4\.3\. |

| Properties | |
| :--- | :--- |
| [AccessToken](AccessToken.md 'Abstractions\.ClientCredentialsToken\.AccessToken') | The access token issued by the authorization server\. |
| [ExpiresIn](ExpiresIn.md 'Abstractions\.ClientCredentialsToken\.ExpiresIn') | The lifetime in seconds of the access token\. |
| [Scope](Scope.md 'Abstractions\.ClientCredentialsToken\.Scope') | The scope of the access token, if different from those requested\. Space\-delimited\. |
| [TokenType](TokenType.md 'Abstractions\.ClientCredentialsToken\.TokenType') | The type of the token issued, typically "Bearer"\. |
