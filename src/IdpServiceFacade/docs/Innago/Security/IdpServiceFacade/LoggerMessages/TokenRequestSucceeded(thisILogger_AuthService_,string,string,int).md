#### [Innago\.Security\.IdpServiceFacade](../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade](../index.md 'Innago\.Security\.IdpServiceFacade').[LoggerMessages](index.md 'Innago\.Security\.IdpServiceFacade\.LoggerMessages')

## LoggerMessages\.TokenRequestSucceeded\(this ILogger\<AuthService\>, string, string, int\) Method

Logs "Token request succeeded for client \{ClientId\}, audience \{Audience\}, expires in \{ExpiresIn\}s" at "Information" level\.

```csharp
internal static void TokenRequestSucceeded(this Microsoft.Extensions.Logging.ILogger<Innago.Security.IdpServiceFacade.Services.AuthService> logger, string clientId, string audience, int expiresIn);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestSucceeded(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,int).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')[AuthService](../Services/AuthService/index.md 'Innago\.Security\.IdpServiceFacade\.Services\.AuthService')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger-1 'Microsoft\.Extensions\.Logging\.ILogger\`1')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestSucceeded(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,int).clientId'></a>

`clientId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestSucceeded(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,int).audience'></a>

`audience` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.TokenRequestSucceeded(thisMicrosoft.Extensions.Logging.ILogger_Innago.Security.IdpServiceFacade.Services.AuthService_,string,string,int).expiresIn'></a>

`expiresIn` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')