#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.GetUserMetadata\(string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves metadata for a user identified by the provided email\.

```csharp
ITask<System.Collections.Generic.IReadOnlyDictionary<string,string?>?> GetUserMetadata(string email, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.GetUserMetadata(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).email'></a>

`email` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The email address of the user whose metadata is to be retrieved\.

<a name='Abstractions.IUserService.GetUserMetadata(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of keys specifying which metadata fields to fetch\. If null, all metadata will be
retrieved\.

<a name='Abstractions.IUserService.GetUserMetadata(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task that resolves to an [System\.Collections\.Generic\.IReadOnlyDictionary&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2') containing the user's metadata,
or null if no metadata exists\.