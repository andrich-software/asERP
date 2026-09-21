using System.Net;

namespace asERP.SalesChannels;

/// <summary>
/// Operator-owned exceptions to the outbound-host guard, bound from the
/// <c>"SalesChannelHostPolicy"</c> configuration section (appsettings, the operator settings
/// overlay or environment variables — like every other section). Everything denies by default, so
/// the section is optional.
///
/// Both knobs used to be tenant data — <c>allowPrivateHost</c> and <c>allowInsecureTransport</c>
/// inside <c>SalesChannel.AdditionalConfigJson</c>. That meant the caller who supplied the host
/// also supplied the switch that turned off the guard on it. They are server configuration now:
/// only whoever deploys the server can widen the policy, and it applies installation-wide.
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
    /// Lets the direct-MySQL connector fall back to <c>SslMode.Preferred</c>, which an active
    /// network attacker can strip down to a cleartext session. Off by default; set it only for an
    /// installation whose MySQL link runs on a trusted segment without a server certificate.
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
        AllowInsecureTransport = options.AllowInsecureTransport;
    }

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
