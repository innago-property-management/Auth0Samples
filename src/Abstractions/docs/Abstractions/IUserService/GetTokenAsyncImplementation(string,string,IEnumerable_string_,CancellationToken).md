#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.GetTokenAsyncImplementation\(string, string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves token for a user identified by the provided username and password\.

```csharp
ITask<global::TokenResponsePayload<Abstractions.TokenResponse>> GetTokenAsyncImplementation(string username, string password, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).username'></a>

`username` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The username of the client whose token is to be retrieved\.

<a name='Abstractions.IUserService.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).password'></a>

`password` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The password of the client whose token is to be retrieved\.

<a name='Abstractions.IUserService.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of keys specifying which metadata fields to fetch\. If null, all metadata will be
retrieved\.

<a name='Abstractions.IUserService.GetTokenAsyncImplementation(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that resolves to an [TokenResponsePayload&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/tokenresponsepayload-1 'TokenResponsePayload\`1') containing the response from an
OpenAPI client authentication request\.