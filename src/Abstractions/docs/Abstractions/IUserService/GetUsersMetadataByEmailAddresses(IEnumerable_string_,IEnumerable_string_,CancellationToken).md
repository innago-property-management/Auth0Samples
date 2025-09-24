#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[IUserService](index.md 'Abstractions\.IUserService')

## IUserService\.GetUsersMetadataByEmailAddresses\(IEnumerable\<string\>, IEnumerable\<string\>, CancellationToken\) Method

Retrieves metadata for users based on their email addresses\.

```csharp
ITask<System.Collections.Generic.IReadOnlyDictionary<string,System.Collections.Generic.IReadOnlyDictionary<string,string?>?>?> GetUsersMetadataByEmailAddresses(System.Collections.Generic.IEnumerable<string> emailAddresses, System.Collections.Generic.IEnumerable<string>? keys, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='Abstractions.IUserService.GetUsersMetadataByEmailAddresses(System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).emailAddresses'></a>

`emailAddresses` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The email addresses

<a name='Abstractions.IUserService.GetUsersMetadataByEmailAddresses(System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).keys'></a>

`keys` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of specific metadata keys to retrieve for each user\.
Can be null to retrieve all keys\.

<a name='Abstractions.IUserService.GetUsersMetadataByEmailAddresses(System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.IEnumerable_string_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The token to monitor for cancellation requests\.

#### Returns
[MorseCode\.ITask\.ITask](https://learn.microsoft.com/en-us/dotnet/api/morsecode.itask.itask 'MorseCode\.ITask\.ITask')  
A task containing a read\-only dictionary where the key is the email address,
and the value is another dictionary with user metadata as key\-value pairs,
or null if no metadata is found\.