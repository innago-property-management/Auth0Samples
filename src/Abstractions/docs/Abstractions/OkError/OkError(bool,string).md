#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[OkError](index.md 'Abstractions\.OkError')

## OkError\(bool, string\) Constructor

Represents a result that indicates success or failure with an optional error message\.

```csharp
public OkError(bool OK=true, string? Error=null);
```
#### Parameters

<a name='Abstractions.OkError.OkError(bool,string).OK'></a>

`OK` [System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

Indicates whether the operation was successful\. Defaults to true\.

<a name='Abstractions.OkError.OkError(bool,string).Error'></a>

`Error` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The error message if the operation failed\. Defaults to null\.