using asERP.Application.Contracts.Logging;
using asERP.Domain.Wrapper;

namespace asERP.Application.Extensions;

/// <summary>
/// Helpers for turning an unhandled exception into a client-safe <see cref="Result{T}"/>.
/// The raw <see cref="Exception.Message"/> (SQL/provider errors, file paths, token-endpoint
/// errors) is never surfaced to the client; it is logged in full server-side instead.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Records a generic failure on <paramref name="result"/> and logs the full exception.
    /// Mirrors the standard catch block used across handlers so exception text never leaks.
    /// </summary>
    public static void FromException<TData, THandler>(
        this Result<TData> result,
        IAppLogger<THandler> logger,
        Exception exception,
        string userMessage,
        string logMessage,
        params object[] logArgs)
    {
        result.Succeeded = false;
        result.StatusCode = ResultStatusCode.InternalServerError;
        result.Messages.Add(userMessage);

        logger.LogError(exception, logMessage, logArgs);
    }
}
