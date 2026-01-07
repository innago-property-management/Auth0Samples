### [IdpServiceFacade](../../index.md 'IdpServiceFacade').[Auth](../index.md 'IdpServiceFacade\.Auth').[AuthClient](index.md 'IdpServiceFacade\.Auth\.AuthClient')

## AuthClient Constructors

| Overloads | |
| :--- | :--- |
| [AuthClient\(\)](AuthClient.md#IdpServiceFacade.Auth.AuthClient.AuthClient() 'IdpServiceFacade\.Auth\.AuthClient\.AuthClient\(\)') | Protected parameterless constructor to allow creation of test doubles\. |
| [AuthClient\(CallInvoker\)](AuthClient.md#IdpServiceFacade.Auth.AuthClient.AuthClient(CallInvoker) 'IdpServiceFacade\.Auth\.AuthClient\.AuthClient\(CallInvoker\)') | Creates a new client for Auth that uses a custom `CallInvoker`\. |
| [AuthClient\(ChannelBase\)](AuthClient.md#IdpServiceFacade.Auth.AuthClient.AuthClient(ChannelBase) 'IdpServiceFacade\.Auth\.AuthClient\.AuthClient\(ChannelBase\)') | Creates a new client for Auth |
| [AuthClient\(ClientBaseConfiguration\)](AuthClient.md#IdpServiceFacade.Auth.AuthClient.AuthClient(ClientBaseConfiguration) 'IdpServiceFacade\.Auth\.AuthClient\.AuthClient\(ClientBaseConfiguration\)') | Protected constructor to allow creation of configured clients\. |

<a name='IdpServiceFacade.Auth.AuthClient.AuthClient()'></a>

## AuthClient\(\) Constructor

Protected parameterless constructor to allow creation of test doubles\.

```csharp
protected AuthClient();
```

<a name='IdpServiceFacade.Auth.AuthClient.AuthClient(CallInvoker)'></a>

## AuthClient\(CallInvoker\) Constructor

Creates a new client for Auth that uses a custom `CallInvoker`\.

```csharp
public AuthClient(CallInvoker callInvoker);
```
#### Parameters

<a name='IdpServiceFacade.Auth.AuthClient.AuthClient(CallInvoker).callInvoker'></a>

`callInvoker` [Grpc\.Core\.CallInvoker](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.callinvoker 'Grpc\.Core\.CallInvoker')

The callInvoker to use to make remote calls\.

<a name='IdpServiceFacade.Auth.AuthClient.AuthClient(ChannelBase)'></a>

## AuthClient\(ChannelBase\) Constructor

Creates a new client for Auth

```csharp
public AuthClient(ChannelBase channel);
```
#### Parameters

<a name='IdpServiceFacade.Auth.AuthClient.AuthClient(ChannelBase).channel'></a>

`channel` [Grpc\.Core\.ChannelBase](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.channelbase 'Grpc\.Core\.ChannelBase')

The channel to use to make remote calls\.

<a name='IdpServiceFacade.Auth.AuthClient.AuthClient(ClientBaseConfiguration)'></a>

## AuthClient\(ClientBaseConfiguration\) Constructor

Protected constructor to allow creation of configured clients\.

```csharp
protected AuthClient(ClientBaseConfiguration configuration);
```
#### Parameters

<a name='IdpServiceFacade.Auth.AuthClient.AuthClient(ClientBaseConfiguration).configuration'></a>

`configuration` [Grpc\.Core\.ClientBase\.ClientBaseConfiguration](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.clientbase.clientbaseconfiguration 'Grpc\.Core\.ClientBase\.ClientBaseConfiguration')

The client configuration\.