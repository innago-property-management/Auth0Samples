### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.CheckPhoneExistsOnAuth0\(string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves metadata for users whose phone number match the provided search term\.

```csharp
public MorseCode.ITask.ITask<System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.IReadOnlyDictionary<string,string?>?>?> CheckPhoneExistsOnAuth0(string searchTerm, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='global__Auth0Client.Auth0Client.CheckPhoneExistsOnAuth0(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).searchTerm'></a>

`searchTerm` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The searchTerm\.

<a name='global__Auth0Client.Auth0Client.CheckPhoneExistsOnAuth0(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of specific metadata keys to include in the result\. If null, all available metadata
will be included\.

<a name='global__Auth0Client.Auth0Client.CheckPhoneExistsOnAuth0(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

Implements [CheckPhoneExistsOnAuth0\(string, IEnumerable&lt;string&gt;, CancellationToken\)](https://learn.microsoft.com/en-us/dotnet/api/abstractions.iuserservice.checkphoneexistsonauth0#abstractions-iuserservice-checkphoneexistsonauth0(system-string-system-collections-generic-ienumerable{system-string}-system-threading-cancellationtoken) 'Abstractions\.IUserService\.CheckPhoneExistsOnAuth0\(System\.String,System\.Collections\.Generic\.IEnumerable\{System\.String\},System\.Threading\.CancellationToken\)')

#### Returns
[MorseCode\.ITask\.ITask&lt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')[System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask-1 'MorseCode\.ITask\.ITask\`1')  
A task that resolves to a dictionary where the keys are user identifiers, and the values are dictionaries of
metadata key\-value pairs, or null if no matches are found\.