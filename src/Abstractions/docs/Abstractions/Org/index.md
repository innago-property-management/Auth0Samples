#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## Org Class

Represents an organization with a unique identifier, name, display name, and associated metadata\.

```csharp
public record Org : System.IEquatable<Abstractions.Org>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; Org

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[Org](index.md 'Abstractions\.Org')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [Org\(string, string, string, IReadOnlyDictionary&lt;string,string&gt;\)](Org(string,string,string,IReadOnlyDictionary_string,string_).md 'Abstractions\.Org\.Org\(string, string, string, System\.Collections\.Generic\.IReadOnlyDictionary\<string,string\>\)') | Represents an organization with a unique identifier, name, display name, and associated metadata\. |

| Properties | |
| :--- | :--- |
| [DisplayName](DisplayName.md 'Abstractions\.Org\.DisplayName') | The display\-friendly name of the organization\. |
| [Id](Id.md 'Abstractions\.Org\.Id') | The unique identifier of the organization\. |
| [Metadata](Metadata.md 'Abstractions\.Org\.Metadata') | A dictionary containing additional metadata associated with the organization\. |
| [Name](Name.md 'Abstractions\.Org\.Name') | The name of the organization\. |
