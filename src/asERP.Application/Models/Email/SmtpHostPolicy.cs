using System.Net;
using asERP.Application.Services;

namespace asERP.Application.Models.Email;

/// <summary>
/// Operator-owned policy for the SMTP endpoints a <em>tenant</em> may point the server at, bound
/// from the <c>"SmtpHostPolicy"</c> configuration section (appsettings, the operator settings
/// overlay or environment variables — like every other section). Everything denies by default, so
/// the section is optional.
///
/// <c>TenantEmailSettings.SmtpHost</c>/<c>SmtpPort</c> are written through a plain
/// <c>[Authorize]</c> endpoint, so the caller who supplies the host is any authenticated tenant
/// user: without a policy the server dials whatever host and port they name and becomes an outbound
/// prober inside its own network.
///
/// What the <em>operator</em> configured (the <c>Setting</c> table, Superadmin-only, or
/// <c>appsettings</c> <c>EmailSettings:*</c>) is exempt — host and port separately, see
/// <see cref="EmailSettings.SmtpHostIsOperatorConfigured"/> and
/// <see cref="EmailSettings.SmtpPortIsOperatorConfigured"/>. An installation-wide relay on a private
/// network or on <c>localhost</c> (a LAN Postfix, the Mailpit setup of
/// <c>docker-compose.mail.yml</c>) therefore keeps working untouched, and keeps working when a tenant
/// moves to another of its ports, because the host half is still the operator's. Only the half the
/// tenant actually chose is judged: a port it picked is checked wherever it points, a host it picked
/// has to pass the address check.
///
/// A refusal is quiet by design — the tenant gets the same generic failure as any other, the reason
/// goes to the server log ("is not permitted", "is not a permitted SMTP port") — so to the operator it
/// looks like mail that simply stopped arriving, and this path carries password-reset and
/// confirmation mail (<c>TenantAwareEmailService.SendPasswordResetEmailAsync</c>). An installation
/// whose tenants relay through a private network or a port outside the default set must set
/// <c>SmtpHostPolicy:AllowedPrivateNetworks</c>, <c>SmtpHostPolicy:AllowedPorts</c> or
/// <c>SmtpHostPolicy:AllowedRelayHosts</c> accordingly — those are the three keys, and the log names
/// the one that refused.
///
/// Deliberately its own section rather than an entry in <c>SalesChannelHostPolicy</c>: an operator
/// who opens the shop database's LAN range to the sales-channel connectors has said nothing about
/// letting every tenant's email settings dial that same range, and the reverse holds too. One
/// section per capability keeps each grant as narrow as it was meant to be. What the two share is
/// the block list itself — <see cref="OutboundAddressGuard"/>, one implementation for both.
/// </summary>
public sealed class SmtpHostPolicyOptions
{
    public const string Section = "SmtpHostPolicy";

    /// <summary>
    /// Relay host names a tenant may configure (<c>"smtp.office365.com"</c>). Entries are trimmed
    /// when the policy is built and matched case-insensitively; the tenant's host itself is compared
    /// as stored, so a padded one matches nothing and is refused.
    ///
    /// Empty by default, and empty means "no host allow-list": a tenant host is then accepted when
    /// it resolves to public addresses only. Making an empty list deny everything would cut off
    /// every tenant that legitimately relays through its own provider today, which is a supported
    /// setup (a tenant-chosen host must bring its own credentials — see
    /// <c>TenantAwareEmailService.MergeWithTenant</c>). Once the list is non-empty it is exclusive:
    /// only these hosts are dialled, and they are dialled without the address check, because naming
    /// a host here is the operator vouching for it — including one on the internal network.
    /// </summary>
    public IList<string> AllowedRelayHosts { get; set; } = [];

    /// <summary>
    /// Private/reserved networks in CIDR notation (<c>"10.4.0.0/16"</c>, <c>"fd12:3456::/32"</c>) a
    /// tenant-configured SMTP host may resolve into although <see cref="OutboundAddressGuard"/>
    /// rejects them — for an installation whose relay sits on the LAN. Empty by default: no private
    /// address is reachable through tenant configuration. An entry that is not valid CIDR is
    /// ignored, so a typo can only ever leave the policy narrower.
    /// </summary>
    public IList<string> AllowedPrivateNetworks { get; set; } = [];

    /// <summary>
    /// TCP ports a tenant may configure. Empty means the built-in set
    /// (<see cref="SmtpHostPolicy.DefaultAllowedPorts"/>: 25, 465, 587, 2525 — SMTP, implicit TLS,
    /// submission and the common alternate submission port); a non-empty list replaces it entirely,
    /// so an operator can both widen it (a relay on 1025) and narrow it (submission only).
    ///
    /// The default lives in <see cref="SmtpHostPolicy"/> and not in this property because
    /// <c>ConfigurationBinder</c> <em>adds</em> to a pre-populated collection instead of replacing
    /// it: a non-empty default here could never be narrowed by configuration. An entry outside
    /// 1..65535 is ignored, which again only narrows.
    /// </summary>
    public IList<int> AllowedPorts { get; set; } = [];
}

/// <summary>
/// The evaluated form of <see cref="SmtpHostPolicyOptions"/>: parses the configured CIDRs, hosts and
/// ports once and answers the three questions the SMTP endpoint guard asks. Registered as a
/// singleton and taken by constructor injection, so the answer can never come from the tenant row
/// being validated.
/// </summary>
public sealed class SmtpHostPolicy
{
    /// <summary>
    /// The submission ports a tenant may use when the operator configured none: 25 (SMTP), 465
    /// (implicit TLS), 587 (submission) and 2525 (the alternate submission port hosters offer where
    /// 25 is filtered). Ports outside this set are where the SSRF value is — 6379, 3306, 80 on the
    /// metadata endpoint — and no mail relay listens there.
    /// </summary>
    public static IReadOnlyList<int> DefaultAllowedPorts { get; } = [25, 465, 587, 2525];

    /// <summary>
    /// No relay allow-list, no private network, the default ports — what an installation without
    /// the configuration section gets, and the policy to use wherever no operator configuration is
    /// in play.
    /// </summary>
    public static SmtpHostPolicy Default { get; } = new(new SmtpHostPolicyOptions());

    private readonly IPNetwork[] _allowedNetworks;
    private readonly HashSet<string> _allowedRelayHosts;
    private readonly HashSet<int> _allowedPorts;

    public SmtpHostPolicy(SmtpHostPolicyOptions options)
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

        _allowedRelayHosts = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var host in options.AllowedRelayHosts ?? [])
        {
            if (!string.IsNullOrWhiteSpace(host))
            {
                _allowedRelayHosts.Add(host.Trim());
            }
        }

        var ports = new HashSet<int>();
        foreach (var port in options.AllowedPorts ?? [])
        {
            if (port is > 0 and <= 65535)
            {
                ports.Add(port);
            }
        }

        _allowedPorts = ports.Count > 0 ? ports : [.. DefaultAllowedPorts];
    }

    /// <summary>True when the operator listed relay hosts, which makes the list exclusive.</summary>
    public bool HasRelayHostAllowList => _allowedRelayHosts.Count > 0;

    /// <inheritdoc cref="SmtpHostPolicyOptions.AllowedRelayHosts"/>
    /// <remarks>
    /// The configured entries are trimmed when this policy is built — that is operator input — but
    /// <paramref name="host"/> is matched as it stands. It is the string the provider dials, and
    /// allow-listing a trimmed form of a value that is never dialled would match one thing and
    /// connect to another.
    /// </remarks>
    public bool IsAllowedRelayHost(string host) =>
        !string.IsNullOrWhiteSpace(host) && _allowedRelayHosts.Contains(host);

    /// <inheritdoc cref="SmtpHostPolicyOptions.AllowedPorts"/>
    public bool IsAllowedPort(int port) => _allowedPorts.Contains(port);

    /// <summary>
    /// True when the operator allow-listed a network containing <paramref name="address"/>. It is
    /// only ever consulted for addresses <see cref="OutboundAddressGuard.IsBlockedAddress"/> already
    /// rejected, so it can widen the guard and never narrow it.
    /// </summary>
    public bool IsAllowedPrivateAddress(IPAddress address)
    {
        ArgumentNullException.ThrowIfNull(address);

        // ::ffff:10.0.0.1 has to be matched against the IPv4 entries, exactly as the block list
        // normalizes it before its own checks.
        if (address.IsIPv4MappedToIPv6)
        {
            address = address.MapToIPv4();
        }

        return Array.Exists(_allowedNetworks, network => network.Contains(address));
    }
}
