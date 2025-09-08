### [Auth0Client](../index.md 'Auth0Client').[Auth0Client](index.md 'Auth0Client\.Auth0Client')

## Auth0Client\.Auth0NameCleaner\(\) Method

```csharp
private static System.Text.RegularExpressions.Regex Auth0NameCleaner();
```

#### Returns
[System\.Text\.RegularExpressions\.Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex 'System\.Text\.RegularExpressions\.Regex')

### Remarks
Pattern:<br/>

```csharp
[^a-z0-9\\-_]+
```<br/>
Explanation:<br/>

```csharp
○ Match a character in the set [^-0-9_a-z] atomically at least once.<br/>
```