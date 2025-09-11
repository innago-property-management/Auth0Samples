### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.GetTokenAsyncImplementation\(string, string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves a token for the specified user by authenticating with the provided credentials\.

```csharp
public MorseCode.ITask.ITask<global::TokenResponsePayload<Abstractions.TokenResponse>> GetTokenAsyncImplementation(string username, string password, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).username'></a>

`username` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The username of the user attempting authentication\.

<a name='global__Auth0Client.Auth0Client.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).password'></a>

`password` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The password of the user for authentication\.

<a name='global__Auth0Client.Auth0Client.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

Optional additional keys used in the token request\.

<a name='global__Auth0Client.Auth0Client.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A token to cancel the operation\.

Implements [GetTokenAsyncImplementation\(string, string, IEnumerable&lt;string&gt;, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.gettokenasyncimplementation#abstractions-iuserservice-gettokenasyncimplementation(system-string-system-string-system-collections-generic-ienumerable{system-string}-system-threading-cancellationtoken) 'Abstractions\.IUserService\.GetTokenAsyncImplementation\(System\.String,System\.String,System\.Collections\.Generic\.IEnumerable\{System\.String\},System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[TokenResponsePayload&lt;](https://learn.microsoft.com/en-us/dotnet/api/tokenresponsepayload-1 'TokenResponsePayload\`1')[Abstractions\.TokenResponse](https://learn.microsoft.com/en-us/dotnet/api/abstractions.tokenresponse 'Abstractions\.TokenResponse')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/tokenresponsepayload-1 'TokenResponsePayload\`1')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation, containing a [TokenResponsePayload&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/tokenresponsepayload-1 'TokenResponsePayload\`1') instance with the retrieved token information\.