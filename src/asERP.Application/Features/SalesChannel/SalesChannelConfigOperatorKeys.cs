using asERP.Application.Services;

namespace asERP.Application.Features.SalesChannel;

/// <summary>
/// Keys of <c>SalesChannel.AdditionalConfigJson</c> that only the server operator may decide, kept
/// in one place so the create, update and draft-connection-test paths cannot disagree. The sibling
/// of <see cref="SalesChannelConfigSecrets"/>: that one hides values the server owns, this one
/// removes switches the caller must not own.
/// </summary>
public static class SalesChannelConfigOperatorKeys
{
    /// <summary>
    /// The direct-MySQL connector's guard opt-outs. The first two disabled the private-address check
    /// and the TLS requirement of the very connection they were configuring, so whoever supplied the
    /// host also supplied the permission to dial it. <c>sslCaPath</c> never was channel data and must
    /// not become it: it is a filesystem path the server would open, and it picks the trust anchor
    /// that the caller's own connection is then verified against. All three live in the operator-owned
    /// <c>SalesChannelHostPolicy</c> configuration section; they are stripped here so a request
    /// body cannot re-introduce them, and <c>WooCommerceDatabaseChannelConfig</c> binds none of
    /// them, so a blob stored before this change is inert rather than honoured.
    /// </summary>
    private static readonly string[] OperatorOnlyKeys =
        ["allowPrivateHost", "allowInsecureTransport", "sslCaPath"];

    public static ConfigJsonKeyStripper Stripper { get; } = new(OperatorOnlyKeys);
}
