#### [Innago\.Security\.IdpServiceFacade](../../index.md 'index')
### [IdpServiceFacade](../index.md 'IdpServiceFacade').[Role](index.md 'IdpServiceFacade\.Role')

## Role\.BindService Method

| Overloads | |
| :--- | :--- |
| [BindService\(ServiceBinderBase, RoleBase\)](BindService.md#IdpServiceFacade.Role.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Role.RoleBase) 'IdpServiceFacade\.Role\.BindService\(Grpc\.Core\.ServiceBinderBase, IdpServiceFacade\.Role\.RoleBase\)') | Register service method with a service binder with or without implementation\. Useful when customizing the service binding logic\.             Note: this method is part of an experimental API that can change or be removed without any prior notice\. |
| [BindService\(RoleBase\)](BindService.md#IdpServiceFacade.Role.BindService(IdpServiceFacade.Role.RoleBase) 'IdpServiceFacade\.Role\.BindService\(IdpServiceFacade\.Role\.RoleBase\)') | Creates service definition that can be registered with a server |

<a name='IdpServiceFacade.Role.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Role.RoleBase)'></a>

## Role\.BindService\(ServiceBinderBase, RoleBase\) Method

Register service method with a service binder with or without implementation\. Useful when customizing the service binding logic\.
            Note: this method is part of an experimental API that can change or be removed without any prior notice\.

```csharp
public static void BindService(Grpc.Core.ServiceBinderBase serviceBinder, IdpServiceFacade.Role.RoleBase serviceImpl);
```
#### Parameters

<a name='IdpServiceFacade.Role.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Role.RoleBase).serviceBinder'></a>

`serviceBinder` [Grpc\.Core\.ServiceBinderBase](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.servicebinderbase 'Grpc\.Core\.ServiceBinderBase')

Service methods will be bound by calling `AddMethod` on this object\.

<a name='IdpServiceFacade.Role.BindService(Grpc.Core.ServiceBinderBase,IdpServiceFacade.Role.RoleBase).serviceImpl'></a>

`serviceImpl` [RoleBase](RoleBase/index.md 'IdpServiceFacade\.Role\.RoleBase')

An object implementing the server\-side handling logic\.

<a name='IdpServiceFacade.Role.BindService(IdpServiceFacade.Role.RoleBase)'></a>

## Role\.BindService\(RoleBase\) Method

Creates service definition that can be registered with a server

```csharp
public static Grpc.Core.ServerServiceDefinition BindService(IdpServiceFacade.Role.RoleBase serviceImpl);
```
#### Parameters

<a name='IdpServiceFacade.Role.BindService(IdpServiceFacade.Role.RoleBase).serviceImpl'></a>

`serviceImpl` [RoleBase](RoleBase/index.md 'IdpServiceFacade\.Role\.RoleBase')

An object implementing the server\-side handling logic\.

#### Returns
[Grpc\.Core\.ServerServiceDefinition](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.serverservicedefinition 'Grpc\.Core\.ServerServiceDefinition')