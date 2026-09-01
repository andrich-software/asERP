using System.Net;
using asERP.Domain.Wrapper;

namespace asERP.Client.Core.Exceptions;

/// <summary>
/// Exception thrown when an API request fails with error messages from the server.
/// This exception carries the structured error messages from the API response.
/// </summary>
public class ApiException : Exception
{
    /// <summary>
    /// HTTP status code of the failed response.
    /// </summary>
    public HttpStatusCode StatusCode { get; }

    /// <summary>
    /// Error messages returned by the API.
    /// These are typically validation errors or business logic error messages.
    /// </summary>
    public IReadOnlyList<string> Messages { get; }

    /// <summary>
    /// Validation messages keyed by the field they belong to, as sent in the server's RFC 9457
    /// <c>errors</c> dictionary. Empty for failures that are not field-specific. Rules declared on
    /// the request as a whole arrive under the empty key.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    /// <summary>
    /// Stable machine-readable code from the server (<c>asERP.Domain.Wrapper.ErrorCodes</c>), e.g.
    /// <c>customer.not_found</c>. Null when the response carried no semantic error. Branch on this
    /// or look up a translation by it — never on <see cref="Messages"/>, which is developer-facing.
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    /// Kind of failure the server reported; null when the response carried no semantic error.
    /// </summary>
    public ErrorType? ErrorType { get; init; }

    /// <summary>
    /// Creates a new ApiException with status code and error messages.
    /// </summary>
    /// <param name="statusCode">HTTP status code of the response.</param>
    /// <param name="messages">Error messages from the API.</param>
    public ApiException(HttpStatusCode statusCode, IEnumerable<string> messages)
        : this(statusCode, messages, errors: null)
    {
    }

    /// <summary>
    /// Creates a new ApiException with status code, error messages and per-field validation errors.
    /// </summary>
    /// <param name="statusCode">HTTP status code of the response.</param>
    /// <param name="messages">Error messages from the API.</param>
    /// <param name="errors">Validation messages keyed by field name.</param>
    public ApiException(HttpStatusCode statusCode, IEnumerable<string> messages, IReadOnlyDictionary<string, string[]>? errors)
        : base(FormatMessage(statusCode, messages))
    {
        StatusCode = statusCode;
        Messages = messages?.ToList().AsReadOnly() ?? new List<string>().AsReadOnly();
        Errors = errors ?? EmptyErrors;
    }

    /// <summary>
    /// Creates a new ApiException with status code and a single error message.
    /// </summary>
    /// <param name="statusCode">HTTP status code of the response.</param>
    /// <param name="message">Single error message.</param>
    public ApiException(HttpStatusCode statusCode, string message)
        : this(statusCode, new[] { message })
    {
    }

    /// <summary>
    /// Creates a new ApiException from an inner exception.
    /// </summary>
    /// <param name="statusCode">HTTP status code of the response.</param>
    /// <param name="messages">Error messages from the API.</param>
    /// <param name="innerException">Inner exception that caused this exception.</param>
    public ApiException(HttpStatusCode statusCode, IEnumerable<string> messages, Exception innerException)
        : base(FormatMessage(statusCode, messages), innerException)
    {
        StatusCode = statusCode;
        Messages = messages?.ToList().AsReadOnly() ?? new List<string>().AsReadOnly();
        Errors = EmptyErrors;
    }

    private static readonly IReadOnlyDictionary<string, string[]> EmptyErrors =
        new Dictionary<string, string[]>(StringComparer.Ordinal);

    /// <summary>
    /// Gets a combined error message string suitable for display.
    /// Multiple messages are joined with newlines.
    /// </summary>
    public string CombinedMessage => Messages.Count > 0
        ? string.Join(Environment.NewLine, Messages)
        : $"API request failed with status code {(int)StatusCode}";

    private static string FormatMessage(HttpStatusCode statusCode, IEnumerable<string> messages)
    {
        var messageList = messages?.ToList() ?? new List<string>();
        return messageList.Count > 0
            ? string.Join("; ", messageList)
            : $"API request failed with status code {(int)statusCode}";
    }
}
