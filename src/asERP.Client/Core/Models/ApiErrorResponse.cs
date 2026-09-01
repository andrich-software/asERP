using asERP.Domain.Wrapper;

namespace asERP.Client.Core.Models;

/// <summary>
/// Model to deserialize API error responses.
/// Supports both the Result envelope and RFC 9457 ProblemDetails.
/// </summary>
internal class ApiErrorResponse
{
    // Result envelope
    public List<string> Messages { get; set; } = new();
    public bool Succeeded { get; set; }

    /// <summary>
    /// Semantic failure description: a stable <see cref="ErrorCodes"/> string plus its kind. Prefer
    /// branching or looking up a translation on <c>Code</c> over matching the message text.
    /// </summary>
    public ApiError? Error { get; set; }

    // RFC 9457 ProblemDetails
    public string? Title { get; set; }
    public string? Detail { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}

/// <summary>
/// The server's <c>Error</c> object as it arrives on the wire.
/// </summary>
internal class ApiError
{
    public ErrorType Type { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
