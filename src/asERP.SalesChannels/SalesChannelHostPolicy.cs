using System.Net;

namespace asERP.SalesChannels;

/// <summary>
/// Operator-owned exceptions to the outbound-host guard, bound from the
/// <c>"SalesChannelHostPolicy"</c> configuration section (appsettings, the operator settings
/// overlay or environment variables — like every other section). Everything denies by default, so
/// the section is optional.
///
/// Two of them used to be tenant data — <c>allowPrivateHost</c> and <c>allowInsecureTransport</c>
/// inside <c>SalesChannel.AdditionalConfigJson</c>. That meant the caller who supplied the host
/// also supplied the switch that turned off the guard on it. They are server configuration now:
/// only whoever deploys the server can widen the policy, and it applies installation-wide.
///
/// The direct-MySQL connector's TLS settings belong here for the same reason, and
/// <see cref="SslCaPath"/> for a second one: it is a filesystem path the server opens, so a tenant
/// able to set it would hold a file-probing primitive on the server as well as the choice of trust
/// anchor for their own connection.
/// </summary>
public sealed class SalesChannelHostPolicyOptions
{
    public const string Section = "SalesChannelHostPolicy";

    /// <summary>
    /// Private/reserved networks in CIDR notation (<c>"10.4.0.0/16"</c>, <c>"fd12:3456::/32"</c>)
    /// that connectors may dial although <see cref="SalesChannelUrlValidator.IsBlockedAddress"/>
    /// rejects them — for a self-hosted installation whose shop database sits on the LAN. Empty by
    /// default: no private address is reachable. An entry that is not valid CIDR is ignored, so a
    /// typo can only ever leave the policy narrower.
    /// </summary>
    public IList<string> AllowedPrivateNetworks { get; set; } = [];

    /// <summary>
    /// Path to a PEM file holding the CA certificate(s) that issued the shop database's server
    /// certificate — for a self-hosted MySQL behind a private CA the machine's certificate store
    /// does not know. Mapped to <c>MySqlConnectionStringBuilder.SslCa</c>, which only adds a trust
    /// anchor: verification stays on, so this is the whole answer for a private CA, including one
    /// that publishes no CRL and no OCSP responder — but through this file and only through it:
    /// MySqlConnector clears the chain errors, revocation-unknown among them, once the chain builds
    /// to a certificate in it. Empty by default (the machine store decides alone). Installation-wide,
    /// like every entry here — one path for every direct-MySQL channel.
    ///
    /// The case this does not cover is the mirror image: a publicly trusted certificate whose
    /// CRL/OCSP endpoint this server cannot reach, on an egress-filtered installation. There is no CA
    /// file to recover through, so it fails closed at <c>VerifyFull</c>. Its remedy is the library's
    /// own <c>MySqlConnectionStringBuilder.SkipCertificateRevocationCheck</c>, accepted only at
    /// <c>VerifyFull</c> and leaving both the chain and the host name verified; deliberately not a
    /// fourth switch here. Add it if that installation turns up — neither
    /// <see cref="AllowCertificateHostnameMismatch"/> nor <see cref="AllowInsecureTransport"/> is an
    /// acceptable substitute for it.
    /// </summary>
    public string SslCaPath { get; set; } = string.Empty;

    /// <summary>
    /// Drops the direct-MySQL connector from <c>SslMode.VerifyFull</c> to <c>VerifyCA</c>: the
    /// certificate chain is still verified, the host name in it is no longer checked against the
    /// host that was dialled — for a server whose certificate is issued for an internal name or
    /// for a shared-hosting cluster name, and for nothing else: a certificate from a private CA is
    /// <see cref="SslCaPath"/>, at <c>VerifyFull</c>. Two checks go, not one — <c>VerifyCA</c> runs no
    /// revocation check at all, so a certificate the CA has since revoked is accepted too, and a
    /// stolen server key stays usable against this installation until it expires. That makes this a
    /// way out of a revocation failure as well, and a poor one: it pays with the name binding, which
    /// is the check that keeps a certificate for some other host from passing. Off by default;
    /// reissuing the certificate for the right name is the better fix. This is not the insecure
    /// escape hatch — <see cref="AllowInsecureTransport"/> is, and it stays the only way to a mode
    /// that authenticates the server not at all.
    /// </summary>
    public bool AllowCertificateHostnameMismatch { get; set; }

    /// <summary>
    /// Lets the direct-MySQL connector fall back to <c>SslMode.Preferred</c>, which authenticates
    /// the server not at all (any certificate is accepted) and which an active network attacker can
    /// strip down to a cleartext session. The single escape hatch out of a verifying mode. Off by
    /// default; set it only for an installation whose MySQL link runs on a trusted segment and whose
    /// server has no usable certificate at all — <see cref="SslCaPath"/> and
    /// <see cref="AllowCertificateHostnameMismatch"/> cover the cases that only need a different
    /// trust anchor or a different name.
    /// </summary>
    public bool AllowInsecureTransport { get; set; }
}

/// <summary>
/// The evaluated form of <see cref="SalesChannelHostPolicyOptions"/>: parses the configured CIDRs
/// once and answers the two questions a connector asks. Registered as a singleton and taken by
/// constructor injection, so the answer can never come from the channel row being validated.
/// </summary>
public sealed class SalesChannelHostPolicy
{
    /// <summary>
    /// Deny everything — what an installation without the configuration section gets, and the
    /// policy to use wherever no operator configuration is in play.
    /// </summary>
    public static SalesChannelHostPolicy DenyAll { get; } = new(new SalesChannelHostPolicyOptions());

    private readonly IPNetwork[] _allowedNetworks;

    public SalesChannelHostPolicy(SalesChannelHostPolicyOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        var networks = new List<IPNetwork>();
        foreach (var entry in options.AllowedPrivateNetworks ?? [])
        {
            if (!string.IsNullOrWhiteSpace(entry) && IPNetwork.TryParse(entry.Trim(), out var network))
            {
                networks.Add(network);
            }
        }

        _allowedNetworks = networks.ToArray();
        SslCaPath = string.IsNullOrWhiteSpace(options.SslCaPath) ? null : options.SslCaPath.Trim();
        AllowCertificateHostnameMismatch = options.AllowCertificateHostnameMismatch;
        AllowInsecureTransport = options.AllowInsecureTransport;
    }

    /// <inheritdoc cref="SalesChannelHostPolicyOptions.SslCaPath"/>
    /// <remarks>Null rather than empty when unconfigured, so a caller cannot pass a blank path on.</remarks>
    public string? SslCaPath { get; }

    /// <inheritdoc cref="SalesChannelHostPolicyOptions.AllowCertificateHostnameMismatch"/>
    public bool AllowCertificateHostnameMismatch { get; }

    /// <inheritdoc cref="SalesChannelHostPolicyOptions.AllowInsecureTransport"/>
    public bool AllowInsecureTransport { get; }

    /// <summary>
    /// True when the operator allow-listed a network containing <paramref name="address"/>. It is
    /// only ever consulted for addresses <see cref="SalesChannelUrlValidator.IsBlockedAddress"/>
    /// already rejected, so it can widen the guard and never narrow it.
    /// </summary>
    public bool IsAllowedPrivateAddress(IPAddress address)
    {
        ArgumentNullException.ThrowIfNull(address);

        // ::ffff:10.0.0.1 has to be matched against the IPv4 entries, exactly as the block-list
        // normalizes it before its own checks.
        if (address.IsIPv4MappedToIPv6)
        {
            address = address.MapToIPv4();
        }

        return Array.Exists(_allowedNetworks, network => network.Contains(address));
    }
}
