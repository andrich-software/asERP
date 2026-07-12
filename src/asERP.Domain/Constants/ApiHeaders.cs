namespace asERP.Domain.Constants;

/// <summary>Custom HTTP header names shared between Server and Client.</summary>
public static class ApiHeaders
{
    /// <summary>
    /// Version of the calling asERP client. Sent only by CI-stamped client builds
    /// (YYYY.MM.DD.run scheme); dev builds and third-party API consumers omit it.
    /// Enforced against the server's minimum client version by ClientVersionMiddleware.
    /// </summary>
    public const string ClientVersion = "X-Client-Version";
}
