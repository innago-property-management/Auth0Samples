#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## TokenResponse Struct

Represents a response containing authentication token details\.

```csharp
public record struct TokenResponse : System.IEquatable<Abstractions.TokenResponse>
```

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[TokenResponse](index.md 'Abstractions\.TokenResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [TokenResponse\(string, Nullable&lt;int&gt;, string, string, string\)](TokenResponse(string,Nullable_int_,string,string,string).md 'Abstractions\.TokenResponse\.TokenResponse\(string, System\.Nullable\<int\>, string, string, string\)') | Represents a response containing authentication token details\. |

| Properties | |
| :--- | :--- |
| [AccessToken](AccessToken.md 'Abstractions\.TokenResponse\.AccessToken') | The access token for the authenticated session\. |
| [ExpiresIn](ExpiresIn.md 'Abstractions\.TokenResponse\.ExpiresIn') | The number of seconds until the access token expires\. |
| [RefreshToken](RefreshToken.md 'Abstractions\.TokenResponse\.RefreshToken') | The refresh token used to obtain a new access token\. |
| [Scope](Scope.md 'Abstractions\.TokenResponse\.Scope') | The scope of access granted by the token\. |
| [TokenType](TokenType.md 'Abstractions\.TokenResponse\.TokenType') | The type of the token issued\. |
