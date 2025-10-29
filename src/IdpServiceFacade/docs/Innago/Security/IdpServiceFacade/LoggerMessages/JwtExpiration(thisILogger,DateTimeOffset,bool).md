#### [Innago\.Security\.IdpServiceFacade](../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade](../index.md 'Innago\.Security\.IdpServiceFacade').[LoggerMessages](index.md 'Innago\.Security\.IdpServiceFacade\.LoggerMessages')

## LoggerMessages\.JwtExpiration\(this ILogger, DateTimeOffset, bool\) Method

Logs "JWT Expiration: \{ExpirationDate\} \(UTC\) \- Expired: \{IsExpired\}" at "Information" level\.

```csharp
internal static void JwtExpiration(this Microsoft.Extensions.Logging.ILogger logger, System.DateTimeOffset expirationDate, bool isExpired);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.JwtExpiration(thisMicrosoft.Extensions.Logging.ILogger,System.DateTimeOffset,bool).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.JwtExpiration(thisMicrosoft.Extensions.Logging.ILogger,System.DateTimeOffset,bool).expirationDate'></a>

`expirationDate` [System\.DateTimeOffset](https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset 'System\.DateTimeOffset')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.JwtExpiration(thisMicrosoft.Extensions.Logging.ILogger,System.DateTimeOffset,bool).isExpired'></a>

`isExpired` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')