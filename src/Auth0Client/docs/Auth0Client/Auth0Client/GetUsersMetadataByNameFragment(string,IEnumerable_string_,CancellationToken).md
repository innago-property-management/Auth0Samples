### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.GetUsersMetadataByNameFragment\(string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves a dictionary of user metadata for users whose names or identifiers contain the specified search term\.

```csharp
public MorseCode.ITask.ITask<System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.IReadOnlyDictionary<string,string?>?>?> GetUsersMetadataByNameFragment(string searchTerm, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.GetUsersMetadataByNameFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).searchTerm'></a>

`searchTerm` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text fragment to search for in users' names or identifiers\.

<a name='global__Auth0Client.Auth0Client.GetUsersMetadataByNameFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of specific metadata keys to include in the response, or null to include all available keys\.

<a name='global__Auth0Client.Auth0Client.GetUsersMetadataByNameFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

Implements [GetUsersMetadataByNameFragment\(string, IEnumerable&lt;string&gt;, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.getusersmetadatabynamefragment#abstractions-iuserservice-getusersmetadatabynamefragment(system-string-system-collections-generic-ienumerable{system-string}-system-threading-cancellationtoken) 'Abstractions\.IUserService\.GetUsersMetadataByNameFragment\(System\.String,System\.Collections\.Generic\.IEnumerable\{System\.String\},System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that represents the asynchronous operation and returns a dictionary containing user metadata for matching users\.