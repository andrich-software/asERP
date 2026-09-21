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
    /// The direct-MySQL connector's two guard opt-outs. They disabled the private-address check and
    /// the TLS requirement of the very connection they were configuring, so whoever supplied the
    /// host also supplied the permission to dial it. Both moved to the operator-owned
    /// <c>SalesChannelHostPolicy</c> configuration section; they are stripped here so a request
    /// body cannot re-introduce them, and <c>WooCommerceDatabaseChannelConfig</c> no longer binds
    /// them, so a blob stored before this change is inert rather than honoured.
    /// </summary>
    private static readonly string[] OperatorOnlyKeys = ["allowPrivateHost", "allowInsecureTransport"];

    public static ConfigJsonKeyStripper Stripper { get; } = new(OperatorOnlyKeys);
}
