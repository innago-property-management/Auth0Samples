#### [Innago\.Security\.IdpServiceFacade](../../../../../index.md 'index')
### [Innago\.Security\.IdpServiceFacade\.Services](../index.md 'Innago\.Security\.IdpServiceFacade\.Services').[UserResponseHelpers](index.md 'Innago\.Security\.IdpServiceFacade\.Services\.UserResponseHelpers')

## UserResponseHelpers\.ToGetUserResponse\(this User\) Method

Converts auth0 user to grpc repsonse

```csharp
public static IdpServiceFacade.UserResponse ToGetUserResponse(this Auth0.ManagementApi.Models.User user);
```
#### Parameters

<a name='Innago.Security.IdpServiceFacade.Services.UserResponseHelpers.ToGetUserResponse(thisAuth0.ManagementApi.Models.User).user'></a>

`user` [Auth0\.ManagementApi\.Models\.User](https://learn.microsoft.com/en-us/dotnet/api/auth0.managementapi.models.user 'Auth0\.ManagementApi\.Models\.User')

#### Returns
[UserResponse](../../../../../IdpServiceFacade/UserResponse/index.md 'IdpServiceFacade\.UserResponse')