using System.Net;
using System.Text.Json;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Json;
using asERP.Client.Core.Models;

namespace asERP.Client.Core.Extensions;

/// <summary>
/// Extension methods for HttpResponseMessage to handle API error responses.
/// </summary>
public static class HttpResponseExtensions
{
    /// <summary>
    /// Ensures the response is successful or throws an ApiException with error messages from the server.
    /// This replaces EnsureSuccessStatusCode() to provide detailed error information.
    /// </summary>
    /// <param name="response">The HTTP response to check.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <exception cref="ApiException">Thrown when the response indicates failure, containing server error messages.</exception>
    public static async Task EnsureSuccessOrThrowApiExceptionAsync(
        this HttpResponseMessage response,
        CancellationToken ct = default)
    {
        if (response.IsSuccessStatusCode)
        {
            return;
        }

        var (messages, errors, error) = await ExtractErrorsAsync(response, ct);

        throw new ApiException(response.StatusCode, messages, errors)
        {
            Code = error?.Code,
            ErrorType = error is null ? null : error.Type
        };
    }

    /// <summary>
    /// Extracts error information from a failed HTTP response. The server sends two shapes: the
    /// <c>Result</c> envelope (<c>Messages</c>) for business failures and RFC 9457 problem details
    /// for validation failures and unhandled exceptions — both are parsed here.
    /// </summary>
    /// <returns>
    /// Flat messages for display, the per-field validation dictionary when the response carried
    /// one, and the semantic error (kind + stable code) when the server sent one.
    /// </returns>
    private static async Task<(List<string> Messages, IReadOnlyDictionary<string, string[]>? Errors, ApiError? Error)> ExtractErrorsAsync(
        HttpResponseMessage response,
        CancellationToken ct)
    {
        var messages = new List<string>();
        IReadOnlyDictionary<string, string[]>? fieldErrors = null;
        ApiError? semanticError = null;

        // Infrastructure-level failures: the reverse proxy / gateway is up but the backend
        // (e.g. the cloud server) is down, restarting or unreachable. These responses carry a
        // proxy HTML page, not our JSON error contract, so surface a clear, actionable message
        // instead of leaking a raw "status code 502 (BadGateway)" to the user.
        if (IsServerUnavailable(response.StatusCode))
        {
            messages.Add("The server is currently unavailable. Please try again in a few moments.");
            return (messages, null, null);
        }

        try
        {
            var content = await response.Content.ReadAsStringAsync(ct);
            if (string.IsNullOrWhiteSpace(content))
            {
                messages.Add($"Request failed with status code {(int)response.StatusCode} ({response.StatusCode})");
                return (messages, null, null);
            }

            // Try to parse as standard API error response
            var errorResponse = JsonSerializer.Deserialize(content, AppJsonSerializerContext.Default.ApiErrorResponse);
            semanticError = errorResponse?.Error;

            if (errorResponse?.Messages is { Count: > 0 })
            {
                messages.AddRange(errorResponse.Messages);
            }
            else if (errorResponse?.Errors is { Count: > 0 })
            {
                // RFC 9457 validation problem details. The field names are kept so a form can put
                // each message on its own control; the generic "One or more validation errors
                // occurred." title is dropped because the field messages already say what is wrong.
                fieldErrors = errorResponse.Errors;
                foreach (var error in errorResponse.Errors)
                {
                    messages.AddRange(error.Value);
                }
            }
            else if (!string.IsNullOrWhiteSpace(errorResponse?.Title))
            {
                // RFC 9457 problem details without a field dictionary.
                messages.Add(errorResponse.Title);
            }
            else
            {
                // Fallback: use the raw content if it looks like a simple string
                messages.Add(content.Length > 500 ? content[..500] + "..." : content);
            }
        }
        catch (JsonException)
        {
            // If JSON parsing fails, provide a generic error message
            messages.Add($"Request failed with status code {(int)response.StatusCode} ({response.StatusCode})");
        }
        catch (Exception)
        {
            // For any other exception during error extraction, provide a generic error
            messages.Add($"Request failed with status code {(int)response.StatusCode} ({response.StatusCode})");
        }

        return messages.Count > 0
            ? (messages, fieldErrors, semanticError)
            : (new List<string> { $"Request failed with status code {(int)response.StatusCode} ({response.StatusCode})" }, fieldErrors, semanticError);
    }

    /// <summary>
    /// True for status codes that indicate the backend is unreachable behind a gateway/proxy
    /// (server down, restarting or overloaded) rather than a request the app can correct.
    /// </summary>
    private static bool IsServerUnavailable(HttpStatusCode statusCode) => statusCode is
        HttpStatusCode.BadGateway or          // 502
        HttpStatusCode.ServiceUnavailable or  // 503
        HttpStatusCode.GatewayTimeout;        // 504
}
