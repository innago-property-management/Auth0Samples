### [IdpServiceFacade](../index.md 'IdpServiceFacade')

## GetTokenResponse Class

```csharp
public sealed class GetTokenResponse : System.IEquatable<IdpServiceFacade.GetTokenResponse>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; [Google\.Protobuf\.IMessage](https://learn.microsoft.com/en-us/dotnet/api/google.protobuf.imessage 'Google\.Protobuf\.IMessage') &#129106; [Google\.Protobuf\.IMessage](https://learn.microsoft.com/en-us/dotnet/api/google.protobuf.imessage 'Google\.Protobuf\.IMessage') &#129106; [Google\.Protobuf\.IDeepCloneable](https://learn.microsoft.com/en-us/dotnet/api/google.protobuf.ideepcloneable 'Google\.Protobuf\.IDeepCloneable') &#129106; [Google\.Protobuf\.IBufferMessage](https://learn.microsoft.com/en-us/dotnet/api/google.protobuf.ibuffermessage 'Google\.Protobuf\.IBufferMessage') &#129106; GetTokenResponse

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[GetTokenResponse](index.md 'IdpServiceFacade\.GetTokenResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Fields | |
| :--- | :--- |
| [AccessTokenFieldNumber](AccessTokenFieldNumber.md 'IdpServiceFacade\.GetTokenResponse\.AccessTokenFieldNumber') | Field number for the "accessToken" field\. |
| [ErrorDescriptionFieldNumber](ErrorDescriptionFieldNumber.md 'IdpServiceFacade\.GetTokenResponse\.ErrorDescriptionFieldNumber') | Field number for the "errorDescription" field\. |
| [ErrorFieldNumber](ErrorFieldNumber.md 'IdpServiceFacade\.GetTokenResponse\.ErrorFieldNumber') | Field number for the "error" field\. |
| [ExpiresInFieldNumber](ExpiresInFieldNumber.md 'IdpServiceFacade\.GetTokenResponse\.ExpiresInFieldNumber') | Field number for the "expiresIn" field\. |
| [OkFieldNumber](OkFieldNumber.md 'IdpServiceFacade\.GetTokenResponse\.OkFieldNumber') | Field number for the "ok" field\. |
| [ScopeFieldNumber](ScopeFieldNumber.md 'IdpServiceFacade\.GetTokenResponse\.ScopeFieldNumber') | Field number for the "scope" field\. |
| [TokenTypeFieldNumber](TokenTypeFieldNumber.md 'IdpServiceFacade\.GetTokenResponse\.TokenTypeFieldNumber') | Field number for the "tokenType" field\. |

| Properties | |
| :--- | :--- |
| [AccessToken](AccessToken.md 'IdpServiceFacade\.GetTokenResponse\.AccessToken') | KEEP at field 3 for wire compatibility |
| [ErrorDescription](ErrorDescription.md 'IdpServiceFacade\.GetTokenResponse\.ErrorDescription') | Human\-readable error \(no secrets\) |
| [ExpiresIn](ExpiresIn.md 'IdpServiceFacade\.GetTokenResponse\.ExpiresIn') | Seconds until expiration |
| [HasError](HasError.md 'IdpServiceFacade\.GetTokenResponse\.HasError') | Gets whether the "error" field is set |
| [HasErrorDescription](HasErrorDescription.md 'IdpServiceFacade\.GetTokenResponse\.HasErrorDescription') | Gets whether the "errorDescription" field is set |
| [HasScope](HasScope.md 'IdpServiceFacade\.GetTokenResponse\.HasScope') | Gets whether the "scope" field is set |
| [Scope](Scope.md 'IdpServiceFacade\.GetTokenResponse\.Scope') | Granted scopes \(space\-separated\) |
| [TokenType](TokenType.md 'IdpServiceFacade\.GetTokenResponse\.TokenType') | NEW OAuth2 standard fields |

| Methods | |
| :--- | :--- |
| [ClearError\(\)](ClearError().md 'IdpServiceFacade\.GetTokenResponse\.ClearError\(\)') | Clears the value of the "error" field |
| [ClearErrorDescription\(\)](ClearErrorDescription().md 'IdpServiceFacade\.GetTokenResponse\.ClearErrorDescription\(\)') | Clears the value of the "errorDescription" field |
| [ClearScope\(\)](ClearScope().md 'IdpServiceFacade\.GetTokenResponse\.ClearScope\(\)') | Clears the value of the "scope" field |
