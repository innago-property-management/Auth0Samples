#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.GetUsersMetadataByNameOrEmailFragment Method

| Overloads | |
| :--- | :--- |
| [GetUsersMetadataByNameOrEmailFragment\(string, string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUsersMetadataByNameOrEmailFragment.md#Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken) 'Abstractions\.IUserService\.GetUsersMetadataByNameOrEmailFragment\(string, string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves metadata for users whose names or email addresses match the specified search term\. |
| [GetUsersMetadataByNameOrEmailFragment\(string, IEnumerable&lt;string&gt;, CancellationToken\)](GetUsersMetadataByNameOrEmailFragment.md#Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken) 'Abstractions\.IUserService\.GetUsersMetadataByNameOrEmailFragment\(string, System\.Collections\.Generic\.IEnumerable\<string\>, System\.Threading\.CancellationToken\)') | Retrieves metadata for users whose name or email matches the given search term\. |

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken)'></a>

## IUserService\.GetUsersMetadataByNameOrEmailFragment\(string, string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves metadata for users whose names or email addresses match the specified search term\.

```csharp
ITask<System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.IReadOnlyDictionary<string,string?>?>?> GetUsersMetadataByNameOrEmailFragment(string searchTerm, string orgUid, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).searchTerm'></a>

`searchTerm` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The search string to match against usernames or email addresses\.

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).orgUid'></a>

`orgUid` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier of the organization to which the users belong\.

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of metadata keys to filter the returned metadata\.

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task containing a dictionary where each key represents a user identifier,
            and the value contains a dictionary of metadata keys and their corresponding values\.

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken)'></a>

## IUserService\.GetUsersMetadataByNameOrEmailFragment\(string, IEnumerable\<string\>, CancellationToken\) Method

Retrieves metadata for users whose name or email matches the given search term\.

```csharp
ITask<System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.IReadOnlyDictionary<string,string?>?>?> GetUsersMetadataByNameOrEmailFragment(string searchTerm, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).searchTerm'></a>

`searchTerm` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The partial name or email fragment to search for matching users\.

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The optional list of metadata keys to retrieve for each user\. If null, all metadata is returned\.

<a name='Abstractions.IUserService.GetUsersMetadataByNameOrEmailFragment(string,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A dictionary where the keys are user identifiers, and the values are dictionaries containing the requested
metadata\. Returns null if no users match the search term\.