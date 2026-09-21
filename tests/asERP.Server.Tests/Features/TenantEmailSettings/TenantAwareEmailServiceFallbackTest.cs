using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Models.Email;
using asERP.Domain.Enums;
using asERP.Infrastructure.EmailService;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.Features.TenantEmailSettings;

public class TenantAwareEmailServiceFallbackTest
{
    [Fact]
    public async Task TenantOverride_FillsGapsFromServerDefaults()
    {
        var serverSettings = new EmailSettings
        {
            ProviderType = EmailProviderType.Smtp,
            SmtpHost = "smtp.server",
            SmtpPort = 587,
            SmtpUsername = "server-user",
            SmtpPassword = "server-secret",
            SmtpEnableSsl = true,
            FromAddress = "server@example.com",
            FromName = "Server",
            ReplyToAddress = "noreply@example.com"
        };

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            FromName = "Tenant Override"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        var sent = await service.SendEmailAsync(new EmailMessage
        {
            To = "to@example.com",
            ToName = "To",
            Subject = "Subject",
            Body = "Body"
        }, tenantOverride.TenantId);

        Assert.True(sent);
        Assert.NotNull(smtp.LastSettings);
        Assert.Equal("smtp.server", smtp.LastSettings!.SmtpHost);
        Assert.Equal(587, smtp.LastSettings.SmtpPort);
        Assert.Equal("server-user", smtp.LastSettings.SmtpUsername);
        Assert.Equal("server-secret", smtp.LastSettings.SmtpPassword);
        Assert.Equal("server@example.com", smtp.LastSettings.FromAddress);
        Assert.Equal("Tenant Override", smtp.LastSettings.FromName);
        Assert.Equal("noreply@example.com", smtp.LastSettings.ReplyToAddress);
    }

    [Fact]
    public async Task TenantOverride_WinsWhenSet_AndDispatchesToCorrectProvider()
    {
        var serverSettings = new EmailSettings
        {
            ProviderType = EmailProviderType.Smtp,
            SmtpHost = "smtp.server",
            FromAddress = "server@example.com",
            FromName = "Server"
        };

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Microsoft365,
            IsActive = true,
            M365TenantId = "tid",
            M365ClientId = "cid",
            M365ClientSecret = "secret",
            M365SenderAddress = "tenant@example.com",
            FromAddress = "tenant@example.com",
            FromName = "Tenant"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var m365 = new CapturingProvider(EmailProviderType.Microsoft365);
        var service = BuildService(serverSettings, tenantOverride, smtp, m365);

        var sent = await service.SendEmailAsync(new EmailMessage
        {
            To = "to@example.com",
            Subject = "S",
            Body = "B"
        }, tenantOverride.TenantId);

        Assert.True(sent);
        Assert.Null(smtp.LastSettings);
        Assert.NotNull(m365.LastSettings);
        Assert.Equal("tenant@example.com", m365.LastSettings!.FromAddress);
        Assert.Equal("tid", m365.LastSettings.M365TenantId);
    }

    [Fact]
    public async Task NoTenantOverride_UsesServerSettingsAsIs()
    {
        var serverSettings = new EmailSettings
        {
            ProviderType = EmailProviderType.Smtp,
            SmtpHost = "smtp.server",
            FromAddress = "server@example.com",
            FromName = "Server"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride: null, smtp);

        var sent = await service.SendEmailAsync(new EmailMessage
        {
            To = "to@example.com",
            Subject = "S",
            Body = "B"
        }, Guid.NewGuid());

        Assert.True(sent);
        Assert.Equal("smtp.server", smtp.LastSettings!.SmtpHost);
        Assert.Equal("server@example.com", smtp.LastSettings.FromAddress);
    }

    [Fact]
    public async Task TenantForeignSmtpHost_WithoutOwnCredentials_RefusesSend()
    {
        var serverSettings = ServerSmtpSettings();

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            SmtpHost = "mx.attacker.tld",
            SmtpPort = 25,
            SmtpEnableSsl = false
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        var sent = await service.SendEmailAsync(TestMessage(), tenantOverride.TenantId);

        Assert.False(sent);
        Assert.Null(smtp.LastSettings);
        Assert.Equal(0, smtp.SendCount);
    }

    [Fact]
    public async Task TenantForeignSmtpHost_WithUsernameButNoPassword_RefusesSend()
    {
        var serverSettings = ServerSmtpSettings();

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            SmtpHost = "mx.attacker.tld",
            SmtpPort = 25,
            SmtpUsername = "tenant-user"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        var sent = await service.SendEmailAsync(TestMessage(), tenantOverride.TenantId);

        Assert.False(sent);
        Assert.Equal(0, smtp.SendCount);
    }

    [Fact]
    public async Task TenantForeignSmtpHost_WithOwnCredentials_SendsWithTenantCredentialsOnly()
    {
        var serverSettings = ServerSmtpSettings();

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            SmtpHost = "smtp.tenant.example",
            SmtpPort = 587,
            SmtpUsername = "tenant-user",
            SmtpPassword = "tenant-secret"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        var sent = await service.SendEmailAsync(TestMessage(), tenantOverride.TenantId);

        Assert.True(sent);
        Assert.NotNull(smtp.LastSettings);
        Assert.Equal("smtp.tenant.example", smtp.LastSettings!.SmtpHost);
        Assert.Equal("tenant-user", smtp.LastSettings.SmtpUsername);
        Assert.Equal("tenant-secret", smtp.LastSettings.SmtpPassword);
    }

    [Fact]
    public async Task TenantWithoutSmtpHost_StillInheritsServerCredentials()
    {
        var serverSettings = ServerSmtpSettings();

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            FromName = "Tenant Override"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        var sent = await service.SendEmailAsync(TestMessage(), tenantOverride.TenantId);

        Assert.True(sent);
        Assert.Equal("smtp.server", smtp.LastSettings!.SmtpHost);
        Assert.Equal("server-user", smtp.LastSettings.SmtpUsername);
        Assert.Equal("server-secret", smtp.LastSettings.SmtpPassword);
    }

    [Fact]
    public async Task TenantRepeatsServerSmtpHost_StillInheritsServerCredentials()
    {
        var serverSettings = ServerSmtpSettings();

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            SmtpHost = " SMTP.Server ",
            SmtpPort = 2525
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        var sent = await service.SendEmailAsync(TestMessage(), tenantOverride.TenantId);

        Assert.True(sent);
        Assert.Equal("server-user", smtp.LastSettings!.SmtpUsername);
        Assert.Equal("server-secret", smtp.LastSettings.SmtpPassword);
        Assert.Equal(2525, smtp.LastSettings.SmtpPort);
    }

    [Fact]
    public async Task AnonymousServerRelay_WithoutTenantOverride_StillSends()
    {
        // Mailpit-style local relay: no credentials, no TLS (EMAIL-TESTING.md).
        var serverSettings = new EmailSettings
        {
            ProviderType = EmailProviderType.Smtp,
            SmtpHost = "localhost",
            SmtpPort = 1025,
            SmtpUsername = string.Empty,
            SmtpPassword = string.Empty,
            SmtpEnableSsl = false,
            FromAddress = "server@example.com",
            FromName = "Server"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride: null, smtp);

        var sent = await service.SendEmailAsync(TestMessage(), Guid.NewGuid());

        Assert.True(sent);
        Assert.Equal("localhost", smtp.LastSettings!.SmtpHost);
        Assert.Equal(1025, smtp.LastSettings.SmtpPort);
        Assert.False(smtp.LastSettings.SmtpEnableSsl);
    }

    [Fact]
    public async Task AnonymousServerRelay_WithTenantOverrideKeepingTheHost_StillSends()
    {
        var serverSettings = new EmailSettings
        {
            ProviderType = EmailProviderType.Smtp,
            SmtpHost = "localhost",
            SmtpPort = 1025,
            SmtpEnableSsl = false,
            FromAddress = "server@example.com",
            FromName = "Server"
        };

        var tenantOverride = new Domain.Entities.TenantEmailSettings
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            SmtpEnableSsl = false,
            FromAddress = "tenant@example.com",
            FromName = "Tenant"
        };

        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        var sent = await service.SendEmailAsync(TestMessage(), tenantOverride.TenantId);

        Assert.True(sent);
        Assert.Equal("localhost", smtp.LastSettings!.SmtpHost);
        Assert.Equal("tenant@example.com", smtp.LastSettings.FromAddress);
    }

    [Fact]
    public async Task TenantOverrideWithoutAnEndpoint_KeepsBothHalvesOperatorConfigured()
    {
        var merged = await MergeAsync(LanRelaySettings(), TenantRow());

        Assert.True(merged.SmtpHostIsOperatorConfigured);
        Assert.True(merged.SmtpPortIsOperatorConfigured);
    }

    [Fact]
    public async Task TenantEchoingTheServerEndpoint_KeepsNeitherHalfAndStillInheritsCredentials()
    {
        var merged = await MergeAsync(CredentialedLanRelaySettings(), TenantRow(host: "192.168.10.5", port: 25));

        // Echoing is not provenance: the tenant wrote these values, so neither half is the operator's
        // and both are checked. The server's own host is a guess away on a stock install.
        Assert.False(merged.SmtpHostIsOperatorConfigured);
        Assert.False(merged.SmtpPortIsOperatorConfigured);

        // F3's rule is decided by a different question — would these credentials reach anyone but the
        // server's own relay — and is untouched: an echoed host still inherits them, exactly as
        // TenantRepeatsServerSmtpHost_StillInheritsServerCredentials above pins it.
        Assert.Equal("server-user", merged.SmtpUsername);
        Assert.Equal("server-secret", merged.SmtpPassword);
    }

    [Fact]
    public async Task TenantOverridingOnlyThePort_KeepsTheOperatorHost()
    {
        // The half the tenant did not touch stays the operator's. Coupling the two would re-run the
        // private-address check on the operator's own relay and refuse it.
        var merged = await MergeAsync(LanRelaySettings(), TenantRow(port: 587));

        Assert.True(merged.SmtpHostIsOperatorConfigured);
        Assert.False(merged.SmtpPortIsOperatorConfigured);
    }

    [Fact]
    public async Task TenantOverridingOnlyTheHost_KeepsTheOperatorPort()
    {
        var merged = await MergeAsync(
            LanRelaySettings(),
            TenantRow(host: "smtp.tenant.example", username: "tenant-user", password: "tenant-secret"));

        Assert.False(merged.SmtpHostIsOperatorConfigured);
        Assert.True(merged.SmtpPortIsOperatorConfigured);
        Assert.Equal(25, merged.SmtpPort);
    }

    [Fact]
    public async Task TenantOverridingBothHalves_KeepsNeither()
    {
        var merged = await MergeAsync(
            LanRelaySettings(),
            TenantRow(host: "smtp.tenant.example", port: 587, username: "tenant-user", password: "tenant-secret"));

        Assert.False(merged.SmtpHostIsOperatorConfigured);
        Assert.False(merged.SmtpPortIsOperatorConfigured);
    }

    [Fact]
    public async Task OperatorRelayOnAPrivateNetwork_SurvivesTheOverridesItShould()
    {
        // The merge feeds the guard here, so this pins what an installation actually experiences.
        var guard = new SmtpEndpointGuard(SmtpHostPolicy.Default);

        // A tenant row that names no endpoint: the operator's relay, untouched.
        Assert.Null(await guard.EvaluateAsync(
            await MergeAsync(LanRelaySettings(), TenantRow())));

        // The tenant moves only the port. The host half is still the operator's, so the private
        // address is not re-checked and 587 is a submission port — the case a coupled marker broke.
        Assert.Null(await guard.EvaluateAsync(
            await MergeAsync(LanRelaySettings(), TenantRow(port: 587))));

        // Same host, a port no relay listens on: that half is the tenant's and is checked.
        Assert.NotNull(await guard.EvaluateAsync(
            await MergeAsync(LanRelaySettings(), TenantRow(port: 6379))));

        // The tenant names the host itself — even the operator's own — and is checked on it.
        Assert.NotNull(await guard.EvaluateAsync(
            await MergeAsync(LanRelaySettings(), TenantRow(host: "192.168.10.5"))));

        // The same override against a public relay stays permitted: the address check is what the
        // private one fails, and 587 is a submission port either way.
        Assert.Null(await guard.EvaluateAsync(
            await MergeAsync(PublicRelaySettings(), TenantRow(host: "203.0.113.10", port: 587))));
    }

    [Fact]
    public async Task OperatorLocalRelay_RelaysForTheOperatorButNotForAnEchoingTenant()
    {
        // The local relay of a developer machine: localhost:1025, no credentials, no TLS, FromAddress
        // noreply@aserp.local — the last of which is what makes LoadServerSettingsAsync prefer the
        // Setting row over appsettings. TenantEmailSettings is plain [Authorize] with no role check,
        // so "echo the server's host back" is available to every authenticated user.
        var guard = new SmtpEndpointGuard(SmtpHostPolicy.Default);

        // The operator's own mail, with no tenant row at all: unchanged, and it has to stay so.
        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(LocalMailpitSettings(), tenantOverride: null, smtp);
        Assert.True(await service.SendEmailAsync(TestMessage(), Guid.NewGuid()));
        Assert.Null(await guard.EvaluateAsync(smtp.LastSettings!));

        // Echoing the host: loopback, and that half is the tenant's now.
        Assert.NotNull(await guard.EvaluateAsync(
            await MergeAsync(LocalMailpitSettings(), TenantRow(host: "localhost"))));

        // Echoing the port: the host half is still the operator's, but 1025 is the tenant's choice
        // and is not a submission port — the other half catches it.
        Assert.NotNull(await guard.EvaluateAsync(
            await MergeAsync(LocalMailpitSettings(), TenantRow(port: 1025))));

        // Echoing both.
        Assert.NotNull(await guard.EvaluateAsync(
            await MergeAsync(LocalMailpitSettings(), TenantRow(host: "localhost", port: 1025))));
    }

    [Fact]
    public async Task TenantRow_CannotSelectCleartext_ByAnyRouteThroughTheMerge()
    {
        // The merge is what an installation actually experiences, so F34's flag is pinned here too:
        // SmtpEnableSsl = false reaches the provider unchanged, and selects nothing — a tenant row
        // that sets the field has chosen the transport, and a tenant's choice is encrypted.
        var guard = new SmtpEndpointGuard(SmtpHostPolicy.Default);

        // A relay of the tenant's own, with credentials of its own (F3) and "no SSL".
        Assert.Equal(SecureSocketOptions.StartTls, await guard.ResolveTransportAsync(
            await MergeAsync(
                PublicRelaySettings(),
                TenantRow(host: "203.0.113.20", port: 587, username: "tenant-user",
                          password: "tenant-secret", enableSsl: false))));

        // Echoing the operator's own loopback endpoint back: not provenance here either.
        Assert.Equal(SecureSocketOptions.StartTls, await guard.ResolveTransportAsync(
            await MergeAsync(
                LocalMailpitSettings(), TenantRow(host: "localhost", port: 1025, enableSsl: false))));

        // The operator's LAN relay with the tenant asking for cleartext: off loopback, so encrypted
        // until the operator sets SmtpHostPolicy:AllowInsecureTransport.
        Assert.Equal(SecureSocketOptions.StartTls, await guard.ResolveTransportAsync(
            await MergeAsync(LanRelaySettings(), TenantRow(enableSsl: false))));

        // The operator's Mailpit, with a tenant row that touches the flag at all: the third mark is
        // gone, so even this endpoint is encrypted — and Mailpit offers no STARTTLS, so that tenant's
        // mail fails rather than travelling in the clear.
        Assert.Equal(SecureSocketOptions.StartTls, await guard.ResolveTransportAsync(
            await MergeAsync(LocalMailpitSettings(), TenantRow(enableSsl: false))));

        // A tenant row that leaves the flag alone keeps the operator's answer, and with it the local
        // relay a developer configured — the flow the docs describe.
        Assert.Equal(SecureSocketOptions.None, await guard.ResolveTransportAsync(
            await MergeAsync(LocalMailpitSettings(), TenantRow())));
    }

    [Fact]
    public async Task TransportFlagIsOperatorConfigured_FollowsTheSameProvenanceRuleAsHostAndPort()
    {
        Assert.True((await MergeAsync(LanRelaySettings(), TenantRow())).SmtpEnableSslIsOperatorConfigured);

        // Either value, set by the tenant, is the tenant's choice — including one that echoes the
        // operator's own, exactly as an echoed host is not provenance.
        Assert.False((await MergeAsync(LanRelaySettings(), TenantRow(enableSsl: false)))
            .SmtpEnableSslIsOperatorConfigured);
        Assert.False((await MergeAsync(LanRelaySettings(), TenantRow(enableSsl: true)))
            .SmtpEnableSslIsOperatorConfigured);

        // And the value itself still merges as it always did.
        Assert.True((await MergeAsync(ServerSmtpSettings(), TenantRow())).SmtpEnableSsl);
        Assert.False((await MergeAsync(ServerSmtpSettings(), TenantRow(enableSsl: false))).SmtpEnableSsl);
    }

    private static async Task<EmailSettings> MergeAsync(
        EmailSettings serverSettings, Domain.Entities.TenantEmailSettings tenantOverride)
    {
        var smtp = new CapturingProvider(EmailProviderType.Smtp);
        var service = BuildService(serverSettings, tenantOverride, smtp);

        Assert.True(await service.SendEmailAsync(TestMessage(), tenantOverride.TenantId));
        return smtp.LastSettings!;
    }

    private static Domain.Entities.TenantEmailSettings TenantRow(
        string? host = null, int? port = null, string? username = null, string? password = null,
        bool? enableSsl = null) => new()
        {
            TenantId = Guid.NewGuid(),
            ProviderType = EmailProviderType.Smtp,
            IsActive = true,
            SmtpHost = host,
            SmtpPort = port,
            SmtpUsername = username,
            SmtpPassword = password,
            SmtpEnableSsl = enableSsl,
            FromName = "Tenant Override"
        };

    /// <summary>An installation-wide relay on the LAN, anonymous — the Postfix-style setup.</summary>
    private static EmailSettings LanRelaySettings() => new()
    {
        ProviderType = EmailProviderType.Smtp,
        SmtpHost = "192.168.10.5",
        SmtpPort = 25,
        SmtpEnableSsl = false,
        SmtpHostIsOperatorConfigured = true,
        SmtpPortIsOperatorConfigured = true,
        SmtpEnableSslIsOperatorConfigured = true,
        FromAddress = "server@example.com",
        FromName = "Server"
    };

    /// <summary>The LAN relay with installation-wide credentials, for the F3 cross-check.</summary>
    private static EmailSettings CredentialedLanRelaySettings()
    {
        var settings = LanRelaySettings();
        settings.SmtpUsername = "server-user";
        settings.SmtpPassword = "server-secret";
        return settings;
    }

    /// <summary>
    /// The Mailpit of <c>docker-compose.mail.yml</c> as a developer configures it in the Superadmin
    /// settings: <c>Email.SmtpHost=localhost</c>, <c>Email.SmtpPort=1025</c>,
    /// <c>Email.SmtpEnableSsl=False</c>. Not a default — the migration seeds an empty host, port 587
    /// and <c>true</c> (<c>SettingsSeeder</c>), and <c>SettingsInitializer</c> only fills in keys that
    /// are missing, after <c>Migrate()</c>. A stock installation sends no mail at all.
    /// </summary>
    private static EmailSettings LocalMailpitSettings() => new()
    {
        ProviderType = EmailProviderType.Smtp,
        SmtpHost = "localhost",
        SmtpPort = 1025,
        SmtpEnableSsl = false,
        SmtpHostIsOperatorConfigured = true,
        SmtpPortIsOperatorConfigured = true,
        SmtpEnableSslIsOperatorConfigured = true,
        FromAddress = "noreply@aserp.local",
        FromName = "asERP System"
    };

    /// <summary>The same relay on a public address (RFC 5737 documentation space, never dialled).</summary>
    private static EmailSettings PublicRelaySettings() => new()
    {
        ProviderType = EmailProviderType.Smtp,
        SmtpHost = "203.0.113.10",
        SmtpPort = 25,
        SmtpEnableSsl = false,
        SmtpHostIsOperatorConfigured = true,
        SmtpPortIsOperatorConfigured = true,
        SmtpEnableSslIsOperatorConfigured = true,
        FromAddress = "server@example.com",
        FromName = "Server"
    };

    private static EmailSettings ServerSmtpSettings() => new()
    {
        ProviderType = EmailProviderType.Smtp,
        SmtpHost = "smtp.server",
        SmtpPort = 587,
        SmtpUsername = "server-user",
        SmtpPassword = "server-secret",
        SmtpEnableSsl = true,
        SmtpEnableSslIsOperatorConfigured = true,
        FromAddress = "server@example.com",
        FromName = "Server"
    };

    private static EmailMessage TestMessage() => new()
    {
        To = "to@example.com",
        ToName = "To",
        Subject = "Subject",
        Body = "Body"
    };

    private static TenantAwareEmailService BuildService(
        EmailSettings serverSettings,
        Domain.Entities.TenantEmailSettings? tenantOverride,
        params IEmailProvider[] providers)
    {
        return new TenantAwareEmailService(
            new StubTenantEmailSettingsRepository(tenantOverride),
            new StubTenantContext(),
            new StubTemplateService(),
            new StubSettingsService(serverSettings),
            NullLogger<TenantAwareEmailService>.Instance,
            new ConfigurationBuilder().Build(),
            providers);
    }

    private sealed class CapturingProvider : IEmailProvider
    {
        public CapturingProvider(EmailProviderType type) => ProviderType = type;
        public EmailProviderType ProviderType { get; }
        public EmailSettings? LastSettings { get; private set; }
        public int SendCount { get; private set; }
        public Task<bool> SendAsync(EmailMessage email, EmailSettings settings)
        {
            LastSettings = settings;
            SendCount++;
            return Task.FromResult(true);
        }
    }

    private sealed class StubSettingsService : ISettingsService
    {
        private readonly EmailSettings _email;
        public StubSettingsService(EmailSettings email) => _email = email;
        public Task<asERP.Application.Models.Identity.JwtSettings> GetJwtSettingsAsync() => Task.FromResult(new asERP.Application.Models.Identity.JwtSettings());
        public Task<EmailSettings> GetEmailSettingsAsync() => Task.FromResult(_email);
        public Task<asERP.Application.Models.Telemetry.TelemetrySettings> GetTelemetrySettingsAsync() => Task.FromResult(new asERP.Application.Models.Telemetry.TelemetrySettings());
        public Task<asERP.Application.Models.Grafana.GrafanaSettings> GetGrafanaSettingsAsync() => Task.FromResult(new asERP.Application.Models.Grafana.GrafanaSettings());
        public Task<asERP.Application.Models.Analytics.ClickHouseSettings> GetClickHouseSettingsAsync() => Task.FromResult(new asERP.Application.Models.Analytics.ClickHouseSettings());
        public Task<string> GetSettingValueAsync(string key) => Task.FromResult(string.Empty);
        public Task SetSettingValueAsync(string key, string value) => Task.CompletedTask;
        public Task<string> GetEncryptedSettingValueAsync(string key) => Task.FromResult(string.Empty);
        public Task SetEncryptedSettingValueAsync(string key, string value) => Task.CompletedTask;
    }

    private sealed class StubTenantEmailSettingsRepository : ITenantEmailSettingsRepository
    {
        private readonly Domain.Entities.TenantEmailSettings? _override;
        public StubTenantEmailSettingsRepository(Domain.Entities.TenantEmailSettings? @override) => _override = @override;
        public IQueryable<Domain.Entities.TenantEmailSettings> Entities => throw new NotImplementedException();
        public Task<Domain.Entities.TenantEmailSettings?> GetByTenantIdAsync(Guid tenantId)
            => Task.FromResult(_override != null && _override.TenantId == tenantId ? _override : null);
        public Task<Domain.Entities.TenantEmailSettings?> GetActiveTenantSettingsAsync(Guid tenantId)
            => Task.FromResult(_override != null && _override.TenantId == tenantId && _override.IsActive ? _override : null);
        public Task<Guid> CreateAsync(Domain.Entities.TenantEmailSettings entity) => throw new NotImplementedException();
        public Task<ICollection<Domain.Entities.TenantEmailSettings>> GetAllAsync() => throw new NotImplementedException();
        public Task<Domain.Entities.TenantEmailSettings?> GetByIdAsync(Guid id, bool asNoTracking = false) => throw new NotImplementedException();
        public Task UpdateAsync(Domain.Entities.TenantEmailSettings entity) => throw new NotImplementedException();
        public Task DeleteAsync(Domain.Entities.TenantEmailSettings entity) => throw new NotImplementedException();
        public Task<bool> ExistsAsync(Guid id) => throw new NotImplementedException();
        public Task<bool> ExistsGloballyAsync(Guid id) => throw new NotImplementedException();
        public Task<bool> IsUniqueAsync(Domain.Entities.TenantEmailSettings entity, Guid? id = null) => throw new NotImplementedException();
        public void Attach(Domain.Entities.TenantEmailSettings entity) => throw new NotImplementedException();
        public void AttachRange(IEnumerable<Domain.Entities.TenantEmailSettings> entities) => throw new NotImplementedException();
        public IQueryable<TCt> GetContext<TCt>() where TCt : class => throw new NotImplementedException();
        public Task<Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public Task SaveChangesAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
        public void Add(Domain.Entities.TenantEmailSettings entity) => throw new NotImplementedException();
    }

    private sealed class StubTenantContext : ITenantContext
    {
        public Guid? GetCurrentTenantId() => null;
        public void SetCurrentTenantId(Guid? tenantId) { }
        public bool HasTenant() => false;
        public IReadOnlyCollection<Guid> GetAssignedTenantIds() => Array.Empty<Guid>();
        public void SetAssignedTenantIds(IEnumerable<Guid> tenantIds) { }
        public bool IsAssignedToTenant(Guid tenantId) => false;
    }

    private sealed class StubTemplateService : IEmailTemplateService
    {
        public Task<string> GeneratePasswordResetEmailAsync(string toName, string resetToken, string resetUrl) => Task.FromResult(string.Empty);
        public Task<string> GenerateWelcomeEmailAsync(string toName) => Task.FromResult(string.Empty);
        public Task<string> GenerateEmailConfirmationAsync(string toName, string confirmationToken, string confirmationUrl) => Task.FromResult(string.Empty);
        public Task<string> GenerateShippingNotificationEmailAsync(ShippingNotificationEmailData data) => Task.FromResult(string.Empty);
        public Task<string> GenerateDeliveryNotificationEmailAsync(ShippingNotificationEmailData data) => Task.FromResult(string.Empty);
    }
}
