### [IdpServiceFacade](../../index.md 'IdpServiceFacade').[User](../index.md 'IdpServiceFacade\.User').[UserClient](index.md 'IdpServiceFacade\.User\.UserClient')

## UserClient Constructors

| Overloads | |
| :--- | :--- |
| [UserClient\(\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient() 'IdpServiceFacade\.User\.UserClient\.UserClient\(\)') | Protected parameterless constructor to allow creation of test doubles\. |
| [UserClient\(CallInvoker\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient(CallInvoker) 'IdpServiceFacade\.User\.UserClient\.UserClient\(CallInvoker\)') | Creates a new client for User that uses a custom `CallInvoker`\. |
| [UserClient\(ChannelBase\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient(ChannelBase) 'IdpServiceFacade\.User\.UserClient\.UserClient\(ChannelBase\)') | Creates a new client for User |
| [UserClient\(ClientBaseConfiguration\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient(ClientBaseConfiguration) 'IdpServiceFacade\.User\.UserClient\.UserClient\(ClientBaseConfiguration\)') | Protected constructor to allow creation of configured clients\. |

<a name='IdpServiceFacade.User.UserClient.UserClient()'></a>

## UserClient\(\) Constructor

Protected parameterless constructor to allow creation of test doubles\.

```csharp
protected UserClient();
```

<a name='IdpServiceFacade.User.UserClient.UserClient(CallInvoker)'></a>

## UserClient\(CallInvoker\) Constructor

Creates a new client for User that uses a custom `CallInvoker`\.

```csharp
public UserClient(CallInvoker callInvoker);
```
#### Parameters

<a name='IdpServiceFacade.User.UserClient.UserClient(CallInvoker).callInvoker'></a>

`callInvoker` [Grpc\.Core\.CallInvoker](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.callinvoker 'Grpc\.Core\.CallInvoker')

The callInvoker to use to make remote calls\.

<a name='IdpServiceFacade.User.UserClient.UserClient(ChannelBase)'></a>

## UserClient\(ChannelBase\) Constructor

Creates a new client for User

```csharp
public UserClient(ChannelBase channel);
```
#### Parameters

<a name='IdpServiceFacade.User.UserClient.UserClient(ChannelBase).channel'></a>

`channel` [Grpc\.Core\.ChannelBase](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.channelbase 'Grpc\.Core\.ChannelBase')

The channel to use to make remote calls\.

<a name='IdpServiceFacade.User.UserClient.UserClient(ClientBaseConfiguration)'></a>

## UserClient\(ClientBaseConfiguration\) Constructor

Protected constructor to allow creation of configured clients\.

```csharp
protected UserClient(ClientBaseConfiguration configuration);
```
#### Parameters

<a name='IdpServiceFacade.User.UserClient.UserClient(ClientBaseConfiguration).configuration'></a>

`configuration` [Grpc\.Core\.ClientBase\.ClientBaseConfiguration](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.clientbase.clientbaseconfiguration 'Grpc\.Core\.ClientBase\.ClientBaseConfiguration')

The client configuration\.