

/// <summary>
///     Represents the payload for the token response in authentication operations.
/// </summary>
public class TokenResponsePayload<T> : IPayload<T>
{
    /// <summary>
    ///     Gets or sets the Error.
    /// </summary>
    public string? Error { get; init; }

    /// <summary>
    ///     Gets or sets the Result.
    /// </summary>
    public T? Result { get; init; }
}


