#### [Innago\.Security\.IdpServiceFacade](../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade](../index.md 'Innago\.Security\.IdpServiceFacade').[LoggingCertificateHttpClientHandler](index.md 'Innago\.Security\.IdpServiceFacade\.LoggingCertificateHttpClientHandler')

## LoggingCertificateHttpClientHandler\.MyRegex\(\) Method

```csharp
private static System.Text.RegularExpressions.Regex MyRegex();
```

#### Returns
[System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')

### Remarks
Pattern:<br/>

```csharp
"exp":\\s*(\\d+)
```<br/>
Explanation:<br/>

```csharp
○ Match the string "\"exp\":".<br/>
○ Match a whitespace character atomically any number of times.<br/>
○ 1st capture group.<br/>
    ○ Match a Unicode digit atomically at least once.<br/>
```