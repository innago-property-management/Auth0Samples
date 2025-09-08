### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\(IManagementApiClient, IOptions\<Auth0Settings\>\) Constructor

Provides functionality for interacting with Auth0 authentication services\.

```csharp
public Auth0Client(Auth0.ManagementApi.IManagementApiClient client, Microsoft.Extensions.Options.IOptions<Abstractions.Auth0Settings> settings);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.Auth0Client(Auth0.ManagementApi.IManagementApiClient,Microsoft.Extensions.Options.IOptions_Abstractions.Auth0Settings_).client'></a>

`client` [Auth0\.ManagementApi\.IManagementApiClient](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.imanagementapiclient 'Auth0\.ManagementApi\.IManagementApiClient')

The Auth0 management API client\.

<a name='global__Auth0Client.Auth0Client.Auth0Client(Auth0.ManagementApi.IManagementApiClient,Microsoft.Extensions.Options.IOptions_Abstractions.Auth0Settings_).settings'></a>

`settings` [Microsoft\.Extensions\.Options\.IOptions&lt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')[Abstractions\.Auth0Settings](https://learn.microsoft.com/en-us/dotnet/api/abstractions.auth0settings 'Abstractions\.Auth0Settings')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptions-1 'Microsoft\.Extensions\.Options\.IOptions\`1')

The Auth0 configuration settings\.