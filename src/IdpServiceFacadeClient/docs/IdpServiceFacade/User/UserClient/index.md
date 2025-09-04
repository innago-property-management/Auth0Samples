### [IdpServiceFacade](../../index.md 'IdpServiceFacade').[User](../index.md 'IdpServiceFacade\.User')

## User\.UserClient Class

Client for User

```csharp
public class User.UserClient
```

Inheritance [Grpc\.Core\.ClientBase](https://learn.microsoft.com/en-us/dotnet/api/grpc.core.clientbase 'Grpc\.Core\.ClientBase') &#129106; UserClient

| Constructors | |
| :--- | :--- |
| [UserClient\(\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient() 'IdpServiceFacade\.User\.UserClient\.UserClient\(\)') | Protected parameterless constructor to allow creation of test doubles\. |
| [UserClient\(CallInvoker\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient(CallInvoker) 'IdpServiceFacade\.User\.UserClient\.UserClient\(CallInvoker\)') | Creates a new client for User that uses a custom `CallInvoker`\. |
| [UserClient\(ChannelBase\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient(ChannelBase) 'IdpServiceFacade\.User\.UserClient\.UserClient\(ChannelBase\)') | Creates a new client for User |
| [UserClient\(ClientBaseConfiguration\)](UserClient.md#IdpServiceFacade.User.UserClient.UserClient(ClientBaseConfiguration) 'IdpServiceFacade\.User\.UserClient\.UserClient\(ClientBaseConfiguration\)') | Protected constructor to allow creation of configured clients\. |

| Methods | |
| :--- | :--- |
| [InitiatePasswordReset\(UserRequest, CallOptions\)](InitiatePasswordReset.md#IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,CallOptions) 'IdpServiceFacade\.User\.UserClient\.InitiatePasswordReset\(IdpServiceFacade\.UserRequest, CallOptions\)') | Initiates a password reset |
| [InitiatePasswordReset\(UserRequest, Metadata, Nullable&lt;DateTime&gt;, CancellationToken\)](InitiatePasswordReset.md#IdpServiceFacade.User.UserClient.InitiatePasswordReset(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken) 'IdpServiceFacade\.User\.UserClient\.InitiatePasswordReset\(IdpServiceFacade\.UserRequest, Metadata, System\.Nullable\<System\.DateTime\>, System\.Threading\.CancellationToken\)') | Initiates a password reset |
| [InitiatePasswordResetAsync\(UserRequest, CallOptions\)](InitiatePasswordResetAsync.md#IdpServiceFacade.User.UserClient.InitiatePasswordResetAsync(IdpServiceFacade.UserRequest,CallOptions) 'IdpServiceFacade\.User\.UserClient\.InitiatePasswordResetAsync\(IdpServiceFacade\.UserRequest, CallOptions\)') | Initiates a password reset |
| [InitiatePasswordResetAsync\(UserRequest, Metadata, Nullable&lt;DateTime&gt;, CancellationToken\)](InitiatePasswordResetAsync.md#IdpServiceFacade.User.UserClient.InitiatePasswordResetAsync(IdpServiceFacade.UserRequest,Metadata,System.Nullable_System.DateTime_,System.Threading.CancellationToken) 'IdpServiceFacade\.User\.UserClient\.InitiatePasswordResetAsync\(IdpServiceFacade\.UserRequest, Metadata, System\.Nullable\<System\.DateTime\>, System\.Threading\.CancellationToken\)') | Initiates a password reset |
| [NewInstance\(ClientBaseConfiguration\)](NewInstance(ClientBaseConfiguration).md 'IdpServiceFacade\.User\.UserClient\.NewInstance\(ClientBaseConfiguration\)') | Creates a new instance of client from given `ClientBaseConfiguration`\. |
