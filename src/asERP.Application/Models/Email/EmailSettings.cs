using asERP.Domain.Enums;

namespace asERP.Application.Models.Email;

/// <summary>
/// Effective email configuration used by <see cref="asERP.Application.Contracts.Infrastructure.IEmailProvider"/>.
/// Resolved by the email service from the tenant override merged onto the server-level defaults.
/// </summary>
public class EmailSettings
{
    public EmailProviderType ProviderType { get; set; } = EmailProviderType.Smtp;

    // SMTP
    public string? SmtpHost { get; set; }
    public int? SmtpPort { get; set; }
    public string? SmtpUsername { get; set; }
    public string? SmtpPassword { get; set; }

    /// <summary>
    /// Whether this endpoint is dialled with TLS. True is what every endpoint gets regardless — the
    /// transport is chosen by <c>SmtpEndpointGuard.ResolveTransportAsync</c> and is mandatory
    /// (<c>SslOnConnect</c> on 465, <c>StartTls</c> elsewhere) unless the operator's
    /// <see cref="SmtpHostPolicy"/> leaves that one endpoint open for cleartext.
    ///
    /// False therefore no longer <em>selects</em> an unencrypted connection, it only asks for one,
    /// and only the operator may ask (<see cref="SmtpEnableSslIsOperatorConfigured"/>): honoured on
    /// the operator's own relay when that relay is on loopback, and where
    /// <see cref="SmtpHostPolicyOptions.AllowInsecureTransport"/> is set, ignored everywhere else. A
    /// tenant row setting it false — on a host of its own, on the operator's, on loopback, anywhere —
    /// is dialled with STARTTLS all the same; it used to be the remote switch that put the SMTP
    /// credentials and the message body, password-reset tokens included, on the wire in the clear.
    ///
    /// The value a fresh installation runs on is <c>true</c>: the migration seeds
    /// <c>Email.SmtpEnableSsl = "true"</c> (<c>SettingsSeeder</c>, <c>InitDb</c>) together with an
    /// <em>empty</em> <c>Email.SmtpHost</c> and port 587, so nothing is sent until an operator
    /// configures the relay. A developer relaying into the Mailpit of <c>docker-compose.mail.yml</c>
    /// has to set this to <c>False</c> along with the host and port — Mailpit offers no STARTTLS.
    /// </summary>
    public bool SmtpEnableSsl { get; set; } = true;

    /// <summary>
    /// True when <see cref="SmtpHost"/> <em>came from</em> operator configuration — the Setting table
    /// (Superadmin-only) or <c>appsettings</c> <c>EmailSettings:*</c> — because the tenant row left it
    /// unset. Such a host is exempt from the private-address check in <c>SmtpHostPolicy</c>: a relay
    /// on the LAN or on <c>localhost</c> is a normal installation and whoever configured it is not the
    /// caller that guard protects against.
    ///
    /// Provenance, never equality: a host a tenant wrote is not marked even when it matches the
    /// server's. The server's own value is not a secret — <c>localhost</c> is what a stock install
    /// seeds — so granting the exemption for matching it would let any authenticated user opt out of
    /// the guard by guessing. What a tenant chose is what a tenant is checked on.
    ///
    /// Tracked separately from <see cref="SmtpPortIsOperatorConfigured"/> because the policy has two
    /// independent dimensions. A tenant that overrides only the port has not chosen the host, and
    /// re-running the address check on the operator's own host because of it would refuse a working
    /// installation — an operator relay at <c>192.168.10.5:25</c> with a tenant on 587, say.
    ///
    /// False is the safe value and therefore the default, so a settings source added later is guarded
    /// until it deliberately says otherwise. Only set it where the value demonstrably comes from
    /// operator configuration — marking a tenant-supplied host would hand the SSRF guard back to the
    /// caller it protects against.
    /// </summary>
    public bool SmtpHostIsOperatorConfigured { get; set; }

    /// <summary>
    /// True when <see cref="SmtpPort"/> came from operator configuration, in the same sense as
    /// <see cref="SmtpHostIsOperatorConfigured"/> — the tenant row supplied no port. Only such a port
    /// is exempt from the allow-list in
    /// <c>SmtpHostPolicy</c>; every port a tenant chose is checked, whichever host it is paired with,
    /// which is what keeps the server from being pointed at 6379 or 3306 on any reachable host.
    /// False by default, for the same fail-closed reason.
    /// </summary>
    public bool SmtpPortIsOperatorConfigured { get; set; }

    /// <summary>
    /// True when <see cref="SmtpEnableSsl"/> came from operator configuration, in the same sense as
    /// <see cref="SmtpHostIsOperatorConfigured"/> — the tenant row left the field null. It is the
    /// third dimension of the same rule: a half of the endpoint is the operator's only while the
    /// tenant supplies nothing for it, and only the operator's own <c>false</c> can ask for a
    /// cleartext session (<c>SmtpEndpointGuard.ResolveTransportAsync</c>).
    ///
    /// Without it the flag stayed a remote switch on one endpoint: on the operator's loopback relay a
    /// tenant row could still flip a TLS session to cleartext. False by default, for the same
    /// fail-closed reason, which is also why a settings source added later has to opt in.
    /// </summary>
    public bool SmtpEnableSslIsOperatorConfigured { get; set; }

    // Microsoft 365 (Graph API, client credentials / app-only)
    public string? M365TenantId { get; set; }
    public string? M365ClientId { get; set; }
    public string? M365ClientSecret { get; set; }
    public string? M365SenderAddress { get; set; }

    // From / Reply-To
    public string FromAddress { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
    public string? ReplyToAddress { get; set; }
    public string? ReplyToName { get; set; }
}
