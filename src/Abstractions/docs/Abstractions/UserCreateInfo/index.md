#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions')

## UserCreateInfo Class

Represents the information required to create a user\.

```csharp
public record UserCreateInfo : System.IEquatable<Abstractions.UserCreateInfo>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') &#129106; UserCreateInfo

Implements [System\.IEquatable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')[UserCreateInfo](index.md 'Abstractions\.UserCreateInfo')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iequatable-1 'System\.IEquatable\`1')

| Constructors | |
| :--- | :--- |
| [UserCreateInfo\(string, string, string, string\)](UserCreateInfo(string,string,string,string).md 'Abstractions\.UserCreateInfo\.UserCreateInfo\(string, string, string, string\)') | Represents the information required to create a user\. |

| Properties | |
| :--- | :--- |
| [Email](Email.md 'Abstractions\.UserCreateInfo\.Email') | The email address of the user\. |
| [FirstName](FirstName.md 'Abstractions\.UserCreateInfo\.FirstName') | The first name of the user\. |
| [LastName](LastName.md 'Abstractions\.UserCreateInfo\.LastName') | The last name of the user\. |
| [Password](Password.md 'Abstractions\.UserCreateInfo\.Password') | The password for the user account\. |
