#### [Innago\.Security\.IdpServiceFacade](../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade](../index.md 'Innago\.Security\.IdpServiceFacade').[LoggerMessages](index.md 'Innago\.Security\.IdpServiceFacade\.LoggerMessages')

## LoggerMessages\.TokenRequestStarted\(this ILogger\<AuthService\>, string, string\) Method

Logs "Starting token request for client \{ClientId\}, audience \{Audience\}" at "Debug" level\.

```csharp
internal static void TokenRequestStarted(this Microsoft.Extensions.Logging.ILogger<Innago.Security.IdpServiceFacade.Services.AuthService> logger, string clientId, string audience);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestStarted(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[AuthService](../Services/AuthService/index.md 'Innago\.Security\.IdpServiceFacade\.Services\.AuthService')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestStarted(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string).clientId'></a>

`clientId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestStarted(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string).audience'></a>

`audience` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')