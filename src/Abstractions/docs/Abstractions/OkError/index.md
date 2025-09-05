#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## OkError Class

Represents a result that indicates success or failure with an optional error message\.

```csharp
public sealed record OkError : System.IEquatable<Abstractions.OkError>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; OkError

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[OkError](index.md 'Abstractions\.OkError')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [OkError\(bool, string\)](OkError(bool,string).md 'Abstractions\.OkError\.OkError\(bool, string\)') | Represents a result that indicates success or failure with an optional error message\. |

| Properties | |
| :--- | :--- |
| [Error](Error.md 'Abstractions\.OkError\.Error') | The error message if the operation failed\. Defaults to null\. |
| [OK](OK.md 'Abstractions\.OkError\.OK') | Indicates whether the operation was successful\. Defaults to true\. |

| Operators | |
| :--- | :--- |
| [implicit operator OkError\(Result\)](implicitoperatorOkError(Result).md 'Abstractions\.OkError\.op\_Implicit Abstractions\.OkError\(Result\)') | Implicitly converts a Result object to an OkError instance\. |
