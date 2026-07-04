namespace asERP.Client.Features.Auth.Services;

/// <summary>
/// Normalization helpers for user-entered server URLs. Mirrors the inline logic that
/// previously lived in the Shell login/register handlers so it stays consistent everywhere.
/// </summary>
public static class ServerUrlUtil
{
    /// <summary>
    /// Trims, prepends <c>https://</c> when no scheme is present, and removes any trailing slash.
    /// Returns an empty string for null/whitespace input.
    /// </summary>
    public static string Normalize(string? url)
    {
        var value = url?.Trim();
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        if (!value.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
            !value.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            value = "https://" + value;
        }

        return value.TrimEnd('/');
    }

    /// <summary>True when the value is an absolute http(s) URI with a non-empty host.</summary>
    public static bool IsValid(string? url)
    {
        var value = Normalize(url);
        return Uri.TryCreate(value, UriKind.Absolute, out var uri)
            && !string.IsNullOrWhiteSpace(uri.Host)
            && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}
