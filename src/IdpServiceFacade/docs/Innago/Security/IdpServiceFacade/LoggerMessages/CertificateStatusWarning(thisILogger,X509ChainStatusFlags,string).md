#### [Innago\.Security\.IdpServiceFacade](../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade](../index.md 'Innago\.Security\.IdpServiceFacade').[LoggerMessages](index.md 'Innago\.Security\.IdpServiceFacade\.LoggerMessages')

## LoggerMessages\.CertificateStatusWarning\(this ILogger, X509ChainStatusFlags, string\) Method

Logs "      \- \{Status\}: \{Info\}" at "Warning" level\.

```csharp
internal static void CertificateStatusWarning(this Microsoft.Extensions.Logging.ILogger logger, System.Security.Cryptography.X509Certificates.X509ChainStatusFlags status, string info);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.CertificateStatusWarning(thisMicrosoft.Extensions.Logging.ILogger,System.Security.Cryptography.X509Certificates.X509ChainStatusFlags,string).logger'></a>

`logger` [Microsoft\.Extensions\.Logging\.ILogger](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger 'Microsoft\.Extensions\.Logging\.ILogger')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.CertificateStatusWarning(thisMicrosoft.Extensions.Logging.ILogger,System.Security.Cryptography.X509Certificates.X509ChainStatusFlags,string).status'></a>

`status` [System\.Security\.Cryptography\.X509Certificates\.X509ChainStatusFlags](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509chainstatusflags 'System\.Security\.Cryptography\.X509Certificates\.X509ChainStatusFlags')

<a name='Innago.Security.IdpServiceFacade.LoggerMessages.CertificateStatusWarning(thisMicrosoft.Extensions.Logging.ILogger,System.Security.Cryptography.X509Certificates.X509ChainStatusFlags,string).info'></a>

`info` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')