#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[ClientCredentialsToken](index.md 'Abstractions\.ClientCredentialsToken')

## ClientCredentialsToken\(string, string, int, string\) Constructor

Represents an OAuth2 Client Credentials token response as defined in RFC 6749 Section 4\.4\.3\.

```csharp
public ClientCredentialsToken(string AccessToken, string TokenType, int ExpiresIn, string? Scope=null);
```
#### Parameters

<a name='Abstractions.ClientCredentialsToken.ClientCredentialsToken(string,string,int,string).AccessToken'></a>

`AccessToken` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The access token issued by the authorization server\.

<a name='Abstractions.ClientCredentialsToken.ClientCredentialsToken(string,string,int,string).TokenType'></a>

`TokenType` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The type of the token issued, typically "Bearer"\.

<a name='Abstractions.ClientCredentialsToken.ClientCredentialsToken(string,string,int,string).ExpiresIn'></a>

`ExpiresIn` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The lifetime in seconds of the access token\.

<a name='Abstractions.ClientCredentialsToken.ClientCredentialsToken(string,string,int,string).Scope'></a>

`Scope` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The scope of the access token, if different from those requested\. Space\-delimited\.