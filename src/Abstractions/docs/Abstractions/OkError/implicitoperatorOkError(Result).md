#### [Abstractions](../../index.md 'index')
### [Abstractions](../index.md 'Abstractions').[OkError](index.md 'Abstractions\.OkError')

## OkError\.implicit operator OkError\(Result\) Operator

Implicitly converts a Result object to an OkError instance\.

```csharp
public static Abstractions.OkError implicit operator Abstractions.OkError(Result result);
```
#### Parameters

<a name='Abstractions.OkError.op_ImplicitAbstractions.OkError(Result).result'></a>

`result` [Innago\.Shared\.TryHelpers\.Result](https://learn.microsoft.com/en-us/dotnet/api/innago.shared.tryhelpers.result 'Innago\.Shared\.TryHelpers\.Result')

The Result object to convert\.

#### Returns
[OkError](index.md 'Abstractions\.OkError')  
An OkError instance representing the Result's status and error message if any\.