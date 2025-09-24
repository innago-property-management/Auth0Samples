namespace Auth0Client;

using System;
using System.Threading.Tasks;

using Innago.Shared.TryHelpers;

internal static class ResultExtensions
{
    internal static async Task<Result<T>> MapAsync<T>(this Result result, Func<Task<Result<T>>> onSuccess, Func<Exception?, Task<Result<T>>> onError)
    {
        Task<Result<T>> mapAsync = result.HasSucceeded ? onSuccess() : onError(result);

        Result<T> mappedResult = await mapAsync;

        return mappedResult;
    }
}
