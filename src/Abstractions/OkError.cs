namespace Abstractions;

using System;

using Innago.Shared.TryHelpers;

using JetBrains.Annotations;

/// <summary>
/// Represents a result that indicates success or failure with an optional error message.
/// </summary>
/// <param name="OK">Indicates whether the operation was successful. Defaults to true.</param>
/// <param name="Error">The error message if the operation failed. Defaults to null.</param>
[PublicAPI]
public sealed record OkError(bool OK = true, string? Error = null)
{
    /// <summary>
    /// Implicitly converts a Result object to an OkError instance.
    /// </summary>
    /// <param name="result">The Result object to convert.</param>
    /// <returns>An OkError instance representing the Result's status and error message if any.</returns>
    public static implicit operator OkError(Result result)
    {
        return new OkError(result.HasSucceeded, ((Exception?)result)?.Message ?? string.Empty);
    }
}

