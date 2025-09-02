namespace Abstractions;

using System;

using Innago.Shared.TryHelpers;

using JetBrains.Annotations;

[PublicAPI]
public sealed record OkError(bool OK = true, string? Error = null)
{
    public static implicit operator OkError(Result result)
    {
        return new OkError(result.HasSucceeded, ((Exception?)result)?.Message ?? string.Empty);
    }
}

