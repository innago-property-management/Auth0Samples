namespace Abstractions;

using JetBrains.Annotations;

[PublicAPI]
public sealed record OkError(bool OK = true, string? Error = null);

