#### [Innago\.Security\.IdpServiceFacade](../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade](../index.md 'Innago\.Security\.IdpServiceFacade').[IdpServiceFacadeTracer](index.md 'Innago\.Security\.IdpServiceFacade\.IdpServiceFacadeTracer')

## IdpServiceFacadeTracer\.Source Field

Represents the [System\.Diagnostics\.ActivitySource](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activitysource 'System\.Diagnostics\.ActivitySource') for tracing operations in the Identity Provider \(IdP\) service facade\.

```csharp
public static readonly ActivitySource Source;
```

#### Field Value
[System\.Diagnostics\.ActivitySource](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activitysource 'System\.Diagnostics\.ActivitySource')

### Remarks
This field is used to create and manage activity spans for distributed tracing, enabling detailed monitoring
and troubleshooting of operations within the IdP service facade\. It is configured to use the fully qualified
name of the [IdpServiceFacadeTracer](index.md 'Innago\.Security\.IdpServiceFacade\.IdpServiceFacadeTracer') class as its source name\.