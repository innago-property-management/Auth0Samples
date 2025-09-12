#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[TokenResponse](index.md 'Abstractions\.TokenResponse')

## TokenResponse\(string, Nullable\<int\>, string, string, string\) Constructor

Represents a response containing authentication token details\.

```csharp
public TokenResponse(string? AccessToken, System.Nullable<int> ExpiresIn, string? RefreshToken, string? TokenType, string? Scope);
```
#### Parameters

<a name='Abstractions.TokenResponse.TokenResponse(string,System.Nullable_int_,string,string,string).AccessToken'></a>

`AccessToken` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The access token for the authenticated session\.

<a name='Abstractions.TokenResponse.TokenResponse(string,System.Nullable_int_,string,string,string).ExpiresIn'></a>

`ExpiresIn` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The number of seconds until the access token expires\.

<a name='Abstractions.TokenResponse.TokenResponse(string,System.Nullable_int_,string,string,string).RefreshToken'></a>

`RefreshToken` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The refresh token used to obtain a new access token\.

<a name='Abstractions.TokenResponse.TokenResponse(string,System.Nullable_int_,string,string,string).TokenType'></a>

`TokenType` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The type of the token issued\.

<a name='Abstractions.TokenResponse.TokenResponse(string,System.Nullable_int_,string,string,string).Scope'></a>

`Scope` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The scope of access granted by the token\.