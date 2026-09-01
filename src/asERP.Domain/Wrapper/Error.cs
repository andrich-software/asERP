namespace asERP.Domain.Wrapper;

/// <summary>
/// A failure a handler reports: what kind it is, a stable machine-readable code the client can
/// translate or branch on, and a developer-facing message in English.
/// </summary>
/// <param name="Type">Transport-independent kind of failure.</param>
/// <param name="Code">Stable identifier from <see cref="ErrorCodes"/>, e.g. <c>customer.not_found</c>.</param>
/// <param name="Message">
/// Human-readable fallback. Treat it as developer-facing: the client should render the translation
/// belonging to <paramref name="Code"/> and fall back to this text only when it knows no better.
/// </param>
public sealed record Error(ErrorType Type, string Code, string Message);
