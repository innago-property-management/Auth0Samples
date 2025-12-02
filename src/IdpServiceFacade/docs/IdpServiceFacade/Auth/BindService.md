#### [Innago\.Security\.IdpServiceFacade](../../index.md 'index')
### [IdpServiceFacade](../index.md 'IdpServiceFacade').[Auth](index.md 'IdpServiceFacade\.Auth')

## Auth\.BindService Method

| Overloads | |
| :--- | :--- |
| [BindService\(ServiceBinderBase, AuthBase\)](BindService.md#IdpServiceFacade.Auth.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Auth.AuthBase) 'IdpServiceFacade\.Auth\.BindService\(Grpc\.Core\.ServiceBinderBase, IdpServiceFacade\.Auth\.AuthBase\)') | Register service method with a service binder with or without implementation\. Useful when customizing the service binding logic\.             Note: this method is part of an experimental API that can change or be removed without any prior notice\. |
| [BindService\(AuthBase\)](BindService.md#IdpServiceFacade.Auth.BindService(IdpServiceFacade.Auth.AuthBase) 'IdpServiceFacade\.Auth\.BindService\(IdpServiceFacade\.Auth\.AuthBase\)') | Creates service definition that can be registered with a server |

<a name='IdpServiceFacade.Auth.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Auth.AuthBase)'></a>

## Auth\.BindService\(ServiceBinderBase, AuthBase\) Method

Register service method with a service binder with or without implementation\. Useful when customizing the service binding logic\.
            Note: this method is part of an experimental API that can change or be removed without any prior notice\.

```csharp
public static void BindService(Grpc.Core.ServiceBinderBase serviceBinder, IdpServiceFacade.Auth.AuthBase serviceImpl);
```
#### Parameters

<a name='IdpServiceFacade.Auth.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Auth.AuthBase).serviceBinder'></a>

`serviceBinder` [Grpc\.Core\.ServiceBinderBase](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servicebinderbase 'Grpc\.Core\.ServiceBinderBase')

Service methods will be bound by calling `AddMethod` on this object\.

<a name='IdpServiceFacade.Auth.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Auth.AuthBase).serviceImpl'></a>

`serviceImpl` [AuthBase](AuthBase/index.md 'IdpServiceFacade\.Auth\.AuthBase')

An object implementing the server\-side handling logic\.

<a name='IdpServiceFacade.Auth.BindService(IdpServiceFacade.Auth.AuthBase)'></a>

## Auth\.BindService\(AuthBase\) Method

Creates service definition that can be registered with a server

```csharp
public static Grpc.Core.ServerServiceDefinition BindService(IdpServiceFacade.Auth.AuthBase serviceImpl);
```
#### Parameters

<a name='IdpServiceFacade.Auth.BindService(IdpServiceFacade.Auth.AuthBase).serviceImpl'></a>

`serviceImpl` [AuthBase](AuthBase/index.md 'IdpServiceFacade\.Auth\.AuthBase')

An object implementing the server\-side handling logic\.

#### Returns
[Grpc\.Core\.ServerServiceDefinition](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.serverservicedefinition 'Grpc\.Core\.ServerServiceDefinition')