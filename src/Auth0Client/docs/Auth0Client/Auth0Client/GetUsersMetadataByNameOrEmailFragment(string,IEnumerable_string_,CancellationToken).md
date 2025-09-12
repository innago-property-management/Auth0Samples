### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.GetUsersMetadataByNameOrEmailFragment\(string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves metadata for users whose name or email matches the given search term\.

```csharp
public MorseCode.ITask.ITask<System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.IReadOnlyDictionary<string,string?>?>?> GetUsersMetadataByNameOrEmailFragment(string searchTerm, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).searchTerm'></a>

`searchTerm` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The partial name or email fragment to search for matching users\.

<a name='global__Auth0Client.Auth0Client.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional list of metadata keys to retrieve for each user\. If null, all metadata is returned\.

<a name='global__Auth0Client.Auth0Client.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

Implements [GetUsersMetadataByNameOrEmailFragment\(string, IEnumerable&lt;string&gt;, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.getusersmetadatabynameoremailfragment#abstractions-iuserservice-getusersmetadatabynameoremailfragment(system-string-system-collections-generic-ienumerable{system-string}-system-threading-cancellationtoken) 'Abstractions\.IUserService\.GetUsersMetadataByNameOrEmailFragment\(System\.String,System\.Collections\.Generic\.IEnumerable\{System\.String\},System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A dictionary where the keys are user identifiers, and the values are dictionaries containing the requested metadata\. Returns null if no users match the search term\.