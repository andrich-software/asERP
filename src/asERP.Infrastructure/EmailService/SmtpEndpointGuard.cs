using System.Net;
using System.Net.Sockets;
using asERP.Application.Models.Email;
using asERP.Application.Services;
using MailKit.Security;

namespace asERP.Infrastructure.EmailService;

/// <summary>
/// Decides whether an SMTP endpoint may be dialled, for the endpoints a tenant chose, and with which
/// transport (<see cref="ResolveTransportAsync"/>).
///
/// <c>TenantEmailSettings.SmtpHost</c>/<c>SmtpPort</c> are written through a plain
/// <c>[Authorize]</c> endpoint and were handed straight to <c>SmtpClient.ConnectAsync</c>, so any
/// authenticated user could aim the server's socket at an internal database, an admin interface or
/// a cloud metadata endpoint and read reachability off the response time. Such an endpoint now has
/// to pass the operator's <see cref="SmtpHostPolicy"/> first: an allowed port, and either a host the
/// operator allow-listed or one that resolves to public addresses only.
///
/// The two halves are judged separately, as the settings carry them
/// (<see cref="EmailSettings.SmtpHostIsOperatorConfigured"/>,
/// <see cref="EmailSettings.SmtpPortIsOperatorConfigured"/>). The operator's own host is never
/// address-checked — a relay on the LAN or on <c>localhost</c> is a normal installation, and whoever
/// configured it is not the caller this guards against — while a port the tenant chose is checked
/// wherever it points, including at that same host. That is what closes the probe without stopping
/// an operator relay at <c>192.168.10.5:25</c> whose tenant is configured for 587.
///
/// Every refusal is a <em>log-only</em> reason string. It never reaches the caller — the provider
/// returns the same <c>false</c> it returns for a refused connection, an unreachable host or a bad
/// password, so the test-send endpoint stays the single generic 500 it was and answers nothing
/// about what is listening where. A transport that fails closed is refused the same way: MailKit
/// throws, the provider logs it and returns that same <c>false</c>.
/// </summary>
public sealed class SmtpEndpointGuard
{
    /// <summary>
    /// The registered implicit-TLS submission port (RFC 8314 <c>submissions</c>): TLS is established
    /// by connecting, so there is no cleartext phase an attacker could keep. Every other port —
    /// 25, 587, 2525, whatever the operator allow-listed — opens in the clear and is upgraded with
    /// STARTTLS, which is why the two cannot share one option.
    /// </summary>
    private const int ImplicitTlsPort = 465;

    private readonly SmtpHostPolicy _policy;

    public SmtpEndpointGuard(SmtpHostPolicy policy)
    {
        ArgumentNullException.ThrowIfNull(policy);
        _policy = policy;
    }

    /// <summary>
    /// Null when the settings may be dialled; otherwise the reason, for the server log only.
    ///
    /// The two dimensions are evaluated independently, because the settings carry them
    /// independently: the operator's host skips the address check even when the tenant moved the
    /// port, and a port the tenant chose is checked even on the operator's own host.
    /// </summary>
    public Task<string?> EvaluateAsync(EmailSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        return EvaluateAsync(
            settings.SmtpHost,
            settings.SmtpPort,
            settings.SmtpHostIsOperatorConfigured,
            settings.SmtpPortIsOperatorConfigured);
    }

    /// <summary>
    /// Null when the tenant-supplied endpoint may be dialled; otherwise the reason, for the server
    /// log only.
    /// </summary>
    public Task<string?> EvaluateAsync(string? host, int? port) =>
        EvaluateAsync(host, port, hostIsOperatorConfigured: false, portIsOperatorConfigured: false);

    /// <summary>
    /// The transport these settings are dialled with. Encryption is mandatory —
    /// <see cref="SecureSocketOptions.SslOnConnect"/> on the implicit-TLS port,
    /// <see cref="SecureSocketOptions.StartTls"/> on every other — unless the operator's policy
    /// leaves cleartext open for this one endpoint.
    ///
    /// <see cref="SecureSocketOptions.Auto"/> is what this replaces, and the reason it had to go is
    /// that it is documented to continue <em>without any encryption</em> when the server does not
    /// advertise STARTTLS: an attacker on the path strips that capability from the EHLO response and
    /// the AUTH exchange and the whole message body — password-reset and confirmation tokens
    /// included — follow in the clear. <c>StartTls</c> makes the same server a hard failure instead,
    /// before any command is sent.
    ///
    /// That is also where F3's second half lands, with one honest exception: authentication cannot
    /// happen over an unencrypted connection because the connection is either encrypted or never
    /// established — except on the two endpoints the operator opened below, where the AUTH exchange
    /// does go out in the clear because that is what the operator asked for. No separate check guards
    /// <c>AuthenticateAsync</c>; adding one would only refuse those same two.
    ///
    /// Cleartext survives for exactly two endpoints, and never because a tenant asked for it:
    /// <list type="bullet">
    /// <item>the operator's own relay <em>on loopback</em> — all three dimensions operator-configured
    /// by provenance (<see cref="EmailSettings.SmtpHostIsOperatorConfigured"/>,
    /// <see cref="EmailSettings.SmtpPortIsOperatorConfigured"/>,
    /// <see cref="EmailSettings.SmtpEnableSslIsOperatorConfigured"/>) and a host that resolves to
    /// loopback and nothing else. That is the Mailpit of <c>docker-compose.mail.yml</c> <em>once a
    /// developer has configured it</em>: <c>Email.SmtpHost=localhost</c>, <c>Email.SmtpPort=1025</c>
    /// and <c>Email.SmtpEnableSsl=False</c> in the Superadmin settings. A fresh install has none of
    /// them — the migration seeds an empty host, port 587 and <c>true</c> (<c>SettingsSeeder</c>), so
    /// a stock installation sends no mail at all until somebody configures a relay. Such a session
    /// never leaves the machine, so the network observer this guards against cannot see it;</item>
    /// <item>whatever <see cref="SmtpHostPolicyOptions.AllowInsecureTransport"/> covers — the
    /// operator's explicit "this installation may relay in the clear", for a LAN relay that offers no
    /// TLS at all.</item>
    /// </list>
    ///
    /// The loopback case earns its complexity for a security reason rather than a convenience one:
    /// without it, the answer for a developer relaying into Mailpit is <c>AllowInsecureTransport</c>,
    /// which is installation-wide and permits cleartext to <em>any</em> host the endpoint guard
    /// admits. The carve-out confines the same convenience to a session that cannot leave the
    /// machine — so it is not dead weight, and removing it would widen what a developer is told to
    /// switch on.
    ///
    /// Both cases need <see cref="EmailSettings.SmtpEnableSsl"/> to be false <em>and</em> that false
    /// to be the operator's own, so the flag can only ever <em>ask</em> for cleartext where the
    /// operator already permits it. A tenant row saying <c>SmtpEnableSsl=false</c> changes nothing
    /// anywhere — on a host of its own, on the operator's, on loopback — which is exactly what made it
    /// a remote downgrade switch before.
    /// </summary>
    public async Task<SecureSocketOptions> ResolveTransportAsync(EmailSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        // Nothing speaks cleartext SMTP on 465 — the port means "TLS first" — so it is decided by the
        // port alone and not by the flag.
        if (settings.SmtpPort == ImplicitTlsPort)
        {
            return SecureSocketOptions.SslOnConnect;
        }

        if (!settings.SmtpEnableSsl && await MaySendInTheClearAsync(settings))
        {
            return SecureSocketOptions.None;
        }

        return SecureSocketOptions.StartTls;
    }

    private async Task<string?> EvaluateAsync(
        string? host, int? port, bool hostIsOperatorConfigured, bool portIsOperatorConfigured)
    {
        // Not trimmed, deliberately: SmtpEmailProvider dials this string as it stands, so trimming
        // here would validate one value and connect to another. A padded host does not resolve —
        // it fails the address check below and is refused, exactly as it failed at the socket before
        // this guard existed. Normalizing what a tenant stored is a product decision of its own.
        var smtpHost = host;

        if (string.IsNullOrWhiteSpace(smtpHost))
        {
            return "the configured SMTP host is empty";
        }

        if (!port.HasValue)
        {
            return $"the configured SMTP host '{smtpHost}' has no port";
        }

        if (!portIsOperatorConfigured && !_policy.IsAllowedPort(port.Value))
        {
            return $"port {port.Value} is not a permitted SMTP port " +
                   $"({SmtpHostPolicyOptions.Section}:{nameof(SmtpHostPolicyOptions.AllowedPorts)}, " +
                   $"default {string.Join(", ", SmtpHostPolicy.DefaultAllowedPorts)})";
        }

        // The operator's own host is not the caller this guards against: no allow-list, no address
        // check. Only the port above applied to it, and only because that half may be the tenant's.
        if (hostIsOperatorConfigured)
        {
            return null;
        }

        // A configured relay list is exclusive and needs no address check: naming a host there is
        // the operator vouching for it, internal or not.
        if (_policy.HasRelayHostAllowList)
        {
            return _policy.IsAllowedRelayHost(smtpHost)
                ? null
                : $"host '{smtpHost}' is not one of the relay hosts the operator allow-listed " +
                  $"({SmtpHostPolicyOptions.Section}:{nameof(SmtpHostPolicyOptions.AllowedRelayHosts)})";
        }

        if (await ResolvesToBlockedAddressAsync(smtpHost))
        {
            // One wording for "private/reserved" and for "does not resolve": in the log that
            // distinction is free, but keeping the two branches identical here means no later
            // caller can turn them into two different outcomes.
            return $"host '{smtpHost}' is not permitted. Only public addresses are dialled; a relay " +
                   "on a private network has to be allow-listed by the server operator " +
                   $"({SmtpHostPolicyOptions.Section}:" +
                   $"{nameof(SmtpHostPolicyOptions.AllowedPrivateNetworks)} or " +
                   $"{nameof(SmtpHostPolicyOptions.AllowedRelayHosts)})";
        }

        return null;
    }

    /// <summary>
    /// True when the host is a private/reserved IP, or a DNS name that resolves to one — the guard
    /// the sales-channel hosts use, applied to the SMTP host. Fails closed: a host that does not
    /// resolve is treated as blocked.
    ///
    /// This is a pre-flight resolution and MailKit then connects by name, so a rebinding name can
    /// answer publicly here and internally at connect time. MailKit takes no connect callback to
    /// close that window, and dialling the validated IP instead of the name would break TLS
    /// certificate validation for every legitimate relay — a far larger hole than the one it fixes.
    /// What is left is a connect to a private address by a hostile resolver, with no response text
    /// and no timing difference reaching the caller.
    /// </summary>
    private async Task<bool> ResolvesToBlockedAddressAsync(string host)
    {
        if (IPAddress.TryParse(host, out var literal))
        {
            return IsBlocked(literal);
        }

        try
        {
            var addresses = await Dns.GetHostAddressesAsync(host);
            return addresses.Length == 0 || addresses.Any(IsBlocked);
        }
        catch (Exception ex) when (ex is SocketException or ArgumentException)
        {
            return true;
        }
    }

    private bool IsBlocked(IPAddress address) =>
        OutboundAddressGuard.IsBlockedAddress(address) && !_policy.IsAllowedPrivateAddress(address);

    /// <summary>
    /// True when this endpoint may carry an unencrypted session: the operator said so
    /// installation-wide, or it is the operator's own relay on loopback, where nothing an observer
    /// could reach is exposed. Either way the answer to "no TLS?" has to be the operator's own.
    /// </summary>
    private async Task<bool> MaySendInTheClearAsync(EmailSettings settings)
    {
        // The flag is a dimension of the endpoint like the host and the port, and provenance decides
        // it the same way: a tenant row that sets SmtpEnableSsl at all has chosen the transport, and
        // a tenant's choice is encrypted. Without this, a tenant could flip even the operator's own
        // loopback relay out of TLS. The marks are set by the operator's settings sources alone
        // (SettingsService, the appsettings fallback), so no request can forge this state.
        if (!settings.SmtpEnableSslIsOperatorConfigured)
        {
            return false;
        }

        if (_policy.AllowInsecureTransport)
        {
            return true;
        }

        return settings.SmtpHostIsOperatorConfigured
               && settings.SmtpPortIsOperatorConfigured
               && await ResolvesToLoopbackOnlyAsync(settings.SmtpHost);
    }

    /// <summary>
    /// True when the host is a loopback literal, or a name every one of whose addresses is loopback.
    /// Fails closed: a host that does not resolve, resolves to nothing, or resolves to one
    /// non-loopback address among others is not loopback, and its session is encrypted.
    ///
    /// The rebinding window <see cref="ResolvesToBlockedAddressAsync"/> describes exists here too —
    /// MailKit connects by name afterwards. Its cost is bounded the same way: a resolver that answers
    /// <c>127.0.0.1</c> here and something routable at connect time is a resolver that could also
    /// have answered a public address, and the operator had to have configured that host in the first
    /// place.
    /// </summary>
    private static async Task<bool> ResolvesToLoopbackOnlyAsync(string? host)
    {
        if (string.IsNullOrWhiteSpace(host))
        {
            return false;
        }

        if (IPAddress.TryParse(host, out var literal))
        {
            return IsLoopback(literal);
        }

        try
        {
            var addresses = await Dns.GetHostAddressesAsync(host);
            return addresses.Length > 0 && addresses.All(IsLoopback);
        }
        catch (Exception ex) when (ex is SocketException or ArgumentException)
        {
            return false;
        }
    }

    private static bool IsLoopback(IPAddress address) =>
        IPAddress.IsLoopback(address.IsIPv4MappedToIPv6 ? address.MapToIPv4() : address);
}
