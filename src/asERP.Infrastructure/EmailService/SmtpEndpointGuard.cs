using System.Net;
using System.Net.Sockets;
using asERP.Application.Models.Email;
using asERP.Application.Services;

namespace asERP.Infrastructure.EmailService;

/// <summary>
/// Decides whether an SMTP endpoint may be dialled, for the endpoints a tenant chose.
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
/// about what is listening where.
/// </summary>
public sealed class SmtpEndpointGuard
{
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
}
