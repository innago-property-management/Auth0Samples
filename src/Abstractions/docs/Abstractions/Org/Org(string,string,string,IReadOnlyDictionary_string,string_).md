#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[Org](index.md 'Abstractions\.Org')

## Org\(string, string, string, IReadOnlyDictionary\<string,string\>\) Constructor

Represents an organization with a unique identifier, name, display name, and associated metadata\.

```csharp
public Org(string Id, string Name, string DisplayName, System.Collections.Generic.IReadOnlyDictionary<string,string>? Metadata=null);
```
#### Parameters

<a name='Abstractions.Org.Org(string,string,string,System.Collections.Generic.IReadOnlyDictionary_string,string_).Id'></a>

`Id` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier of the organization\.

<a name='Abstractions.Org.Org(string,string,string,System.Collections.Generic.IReadOnlyDictionary_string,string_).Name'></a>

`Name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the organization\.

<a name='Abstractions.Org.Org(string,string,string,System.Collections.Generic.IReadOnlyDictionary_string,string_).DisplayName'></a>

`DisplayName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The display\-friendly name of the organization\.

<a name='Abstractions.Org.Org(string,string,string,System.Collections.Generic.IReadOnlyDictionary_string,string_).Metadata'></a>

`Metadata` [System\.Collections\.Generic\.IReadOnlyDictionary&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[,](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2 'System\.Collections\.Generic\.IReadOnlyDictionary\`2')

A dictionary containing additional metadata associated with the organization\.