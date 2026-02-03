#### [Innago\.Security\.IdpServiceFacade](../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade](../index.md 'Innago\.Security\.IdpServiceFacade').[LoggerMessages](index.md 'Innago\.Security\.IdpServiceFacade\.LoggerMessages')

## LoggerMessages\.TokenRequestFailed\(this ILogger\<AuthService\>, string, string, string\) Method

Logs "Token request failed for client \{ClientId\}, audience \{Audience\}: \{ErrorMessage\}" at "Warning" level\.

```csharp
internal static void TokenRequestFailed(this Microsoft.Extensions.Logging.ILogger<Innago.Security.IdpServiceFacade.Services.AuthService> logger, string clientId, string audience, string? errorMessage);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestFailed(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,string).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[AuthService](../Services/AuthService/index.md 'Innago\.Security\.IdpServiceFacade\.Services\.AuthService')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestFailed(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,string).clientId'></a>

`clientId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestFailed(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,string).audience'></a>

`audience` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestFailed(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,string).errorMessage'></a>

`errorMessage` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')