### [IdpServiceFacade](../../index.md 'IdpServiceFacade').[User](../index.md 'IdpServiceFacade\.User').[UserClient](index.md 'IdpServiceFacade\.User\.UserClient')

## User\.UserClient\.InitiatePasswordReset Method

| Overloads | |
| :--- | :--- |
| [InitiatePasswordReset\(UserRequest, CallOptions\)](InitiatePasswordReset.md#IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,CallOptions) 'IdpServiceFacade\.User\.UserClient\.InitiatePasswordReset\(IdpServiceFacade\.UserRequest, CallOptions\)') | Initiates a password reset |
| [InitiatePasswordReset\(UserRequest, Metadata, Nullable&lt;DateTime&gt;, CancellationToken\)](InitiatePasswordReset.md#IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken) 'IdpServiceFacade\.User\.UserClient\.InitiatePasswordReset\(IdpServiceFacade\.UserRequest, Metadata, System\.Nullable\<System\.DateTime\>, System\.Threading\.CancellationToken\)') | Initiates a password reset |

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,CallOptions)'></a>

## User\.UserClient\.InitiatePasswordReset\(UserRequest, CallOptions\) Method

Initiates a password reset

```csharp
public virtual IdpServiceFacade.InitiatePasswordResetReply InitiatePasswordReset(IdpServiceFacade.UserRequest request, CallOptions options);
```
#### Parameters

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,CallOptions).request'></a>

`request` [UserRequest](../../UserRequest/index.md 'IdpServiceFacade\.UserRequest')

The request to send to the server\.

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,CallOptions).options'></a>

`options` [Grpc\.Core\.CallOptions](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.calloptions 'Grpc\.Core\.CallOptions')

The options for the call\.

#### Returns
[InitiatePasswordResetReply](../../InitiatePasswordResetReply/index.md 'IdpServiceFacade\.InitiatePasswordResetReply')  
The response received from the server\.

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken)'></a>

## User\.UserClient\.InitiatePasswordReset\(UserRequest, Metadata, Nullable\<DateTime\>, CancellationToken\) Method

Initiates a password reset

```csharp
public virtual IdpServiceFacade.InitiatePasswordResetReply InitiatePasswordReset(IdpServiceFacade.UserRequest request, Metadata headers=null, System.Nullable<System.DateTime> deadline=null, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken).request'></a>

`request` [UserRequest](../../UserRequest/index.md 'IdpServiceFacade\.UserRequest')

The request to send to the server\.

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken).headers'></a>

`headers` [Grpc\.Core\.Metadata](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.metadata 'Grpc\.Core\.Metadata')

The initial metadata to send with the call\. This parameter is optional\.

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken).deadline'></a>

`deadline` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional deadline for the call\. The call will be cancelled if deadline is hit\.

<a name='IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

An optional token for canceling the call\.

#### Returns
[InitiatePasswordResetReply](../../InitiatePasswordResetReply/index.md 'IdpServiceFacade\.InitiatePasswordResetReply')  
The response received from the server\.