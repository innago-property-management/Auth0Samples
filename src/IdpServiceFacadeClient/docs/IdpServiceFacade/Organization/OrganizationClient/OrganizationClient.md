### [IdpServiceFacade](../../index.md 'IdpServiceFacade').[Organization](../index.md 'IdpServiceFacade\.Organization').[OrganizationClient](index.md 'IdpServiceFacade\.Organization\.OrganizationClient')

## OrganizationClient Constructors

| Overloads | |
| :--- | :--- |
| [OrganizationClient\(\)](OrganizationClient.md#IdpServiceFacade.Organization.OrganizationClient.OrganizationClient() 'IdpServiceFacade\.Organization\.OrganizationClient\.OrganizationClient\(\)') | Protected parameterless constructor to allow creation of test doubles\. |
| [OrganizationClient\(CallInvoker\)](OrganizationClient.md#IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(CallInvoker) 'IdpServiceFacade\.Organization\.OrganizationClient\.OrganizationClient\(CallInvoker\)') | Creates a new client for Organization that uses a custom `CallInvoker`\. |
| [OrganizationClient\(ChannelBase\)](OrganizationClient.md#IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(ChannelBase) 'IdpServiceFacade\.Organization\.OrganizationClient\.OrganizationClient\(ChannelBase\)') | Creates a new client for Organization |
| [OrganizationClient\(ClientBaseConfiguration\)](OrganizationClient.md#IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(ClientBaseConfiguration) 'IdpServiceFacade\.Organization\.OrganizationClient\.OrganizationClient\(ClientBaseConfiguration\)') | Protected constructor to allow creation of configured clients\. |

<a name='IdpServiceFacade.Organization.OrganizationClient.OrganizationClient()'></a>

## OrganizationClient\(\) Constructor

Protected parameterless constructor to allow creation of test doubles\.

```csharp
protected OrganizationClient();
```

<a name='IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(CallInvoker)'></a>

## OrganizationClient\(CallInvoker\) Constructor

Creates a new client for Organization that uses a custom `CallInvoker`\.

```csharp
public OrganizationClient(CallInvoker callInvoker);
```
#### Parameters

<a name='IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(CallInvoker).callInvoker'></a>

`callInvoker` [Grpc\.Core\.CallInvoker](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.callinvoker 'Grpc\.Core\.CallInvoker')

The callInvoker to use to make remote calls\.

<a name='IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(ChannelBase)'></a>

## OrganizationClient\(ChannelBase\) Constructor

Creates a new client for Organization

```csharp
public OrganizationClient(ChannelBase channel);
```
#### Parameters

<a name='IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(ChannelBase).channel'></a>

`channel` [Grpc\.Core\.ChannelBase](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.channelbase 'Grpc\.Core\.ChannelBase')

The channel to use to make remote calls\.

<a name='IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(ClientBaseConfiguration)'></a>

## OrganizationClient\(ClientBaseConfiguration\) Constructor

Protected constructor to allow creation of configured clients\.

```csharp
protected OrganizationClient(ClientBaseConfiguration configuration);
```
#### Parameters

<a name='IdpServiceFacade.Organization.OrganizationClient.OrganizationClient(ClientBaseConfiguration).configuration'></a>

`configuration` [Grpc\.Core\.ClientBase\.ClientBaseConfiguration](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.clientbase.clientbaseconfiguration 'Grpc\.Core\.ClientBase\.ClientBaseConfiguration')

The client configuration\.