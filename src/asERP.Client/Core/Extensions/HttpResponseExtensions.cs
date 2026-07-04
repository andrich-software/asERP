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

        var messages = await ExtractErrorMessagesAsync(response, ct);
        throw new ApiException(response.StatusCode, messages);
    }

    /// <summary>
    /// Extracts error messages from an HTTP response.
    /// Tries to parse the response body as JSON and extract Messages array.
    /// </summary>
    private static async Task<List<string>> ExtractErrorMessagesAsync(
        HttpResponseMessage response,
        CancellationToken ct)
    {
        var messages = new List<string>();

        // Infrastructure-level failures: the reverse proxy / gateway is up but the backend
        // (e.g. the cloud server) is down, restarting or unreachable. These responses carry a
        // proxy HTML page, not our JSON error contract, so surface a clear, actionable message
        // instead of leaking a raw "status code 502 (BadGateway)" to the user.
        if (IsServerUnavailable(response.StatusCode))
        {
            messages.Add("The server is currently unavailable. Please try again in a few moments.");
            return messages;
        }

        try
        {
            var content = await response.Content.ReadAsStringAsync(ct);
            if (string.IsNullOrWhiteSpace(content))
            {
                messages.Add($"Request failed with status code {(int)response.StatusCode} ({response.StatusCode})");
                return messages;
            }

            // Try to parse as standard API error response
            var errorResponse = JsonSerializer.Deserialize(content, AppJsonSerializerContext.Default.ApiErrorResponse);

            if (errorResponse?.Messages is { Count: > 0 })
            {
                messages.AddRange(errorResponse.Messages);
            }
            else if (!string.IsNullOrWhiteSpace(errorResponse?.Title))
            {
                // RFC 7807 ProblemDetails format
                messages.Add(errorResponse.Title);
                if (errorResponse.Errors is { Count: > 0 })
                {
                    foreach (var error in errorResponse.Errors)
                    {
                        foreach (var errorMessage in error.Value)
                        {
                            messages.Add(errorMessage);
                        }
                    }
                }
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
            ? messages
            : new List<string> { $"Request failed with status code {(int)response.StatusCode} ({response.StatusCode})" };
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
