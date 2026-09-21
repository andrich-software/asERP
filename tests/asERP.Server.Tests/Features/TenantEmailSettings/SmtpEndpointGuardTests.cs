using asERP.Application.Models.Email;
using asERP.Domain.Enums;
using asERP.Infrastructure.EmailService;
using asERP.Infrastructure.EmailService.Providers;
using Microsoft.Extensions.Logging;
using Xunit;

namespace asERP.Server.Tests.Features.TenantEmailSettings;

/// <summary>
/// TenantEmailSettings.SmtpHost/SmtpPort are written through a plain [Authorize] endpoint and used
/// to be dialled as given, which made the server an outbound prober for its own network. They are
/// checked against the operator's SmtpHostPolicy now.
///
/// Every address here is a literal — 203.0.113.0/24 is RFC 5737 documentation space and is never
/// actually dialled — so no test depends on a resolver or on being online.
/// </summary>
public class SmtpEndpointGuardTests
{
    private const string PublicHost = "203.0.113.10";

    private static SmtpEndpointGuard Guard(SmtpHostPolicyOptions? options = null) =>
        new(options is null ? SmtpHostPolicy.Default : new SmtpHostPolicy(options));

    private static EmailSettings TenantEndpoint(string host, int port) => new()
    {
        ProviderType = EmailProviderType.Smtp,
        SmtpHost = host,
        SmtpPort = port,
        SmtpUsername = "tenant-user",
        SmtpPassword = "tenant-secret",
        FromAddress = "tenant@example.com",
        FromName = "Tenant"
    };

    private static EmailMessage TestMessage() => new()
    {
        To = "to@example.com",
        ToName = "To",
        Subject = "Subject",
        Body = "Body"
    };

    [Theory]
    [InlineData("127.0.0.1")]         // loopback
    [InlineData("10.0.0.15")]         // RFC 1918 — the finding's own example
    [InlineData("192.168.1.10")]
    [InlineData("172.16.0.1")]
    [InlineData("169.254.169.254")]   // link-local, the cloud metadata endpoint
    [InlineData("0.0.0.0")]
    [InlineData("::1")]               // IPv6 loopback
    [InlineData("fd00::1")]           // unique-local
    [InlineData("fe80::1")]           // IPv6 link-local
    [InlineData("::ffff:10.0.0.15")]  // IPv4-mapped private, the classic normalization miss
    public async Task InternalAddress_IsRefused(string host)
    {
        Assert.NotNull(await Guard().EvaluateAsync(host, 587));
    }

    [Fact]
    public async Task PublicHost_OnASubmissionPort_IsStillAccepted()
    {
        Assert.Null(await Guard().EvaluateAsync(PublicHost, 587));
    }

    [Theory]
    [InlineData(25)]
    [InlineData(465)]
    [InlineData(587)]
    [InlineData(2525)]
    public async Task DefaultSubmissionPorts_AreAccepted(int port)
    {
        Assert.Null(await Guard().EvaluateAsync(PublicHost, port));
    }

    [Theory]
    [InlineData(6379)]   // the finding's exploit port
    [InlineData(3306)]
    [InlineData(80)]
    [InlineData(22)]
    public async Task PortOutsideTheSubmissionSet_IsRefused(int port)
    {
        Assert.NotNull(await Guard().EvaluateAsync(PublicHost, port));
    }

    [Fact]
    public async Task OperatorPortList_ReplacesTheDefaultSet()
    {
        var guard = Guard(new SmtpHostPolicyOptions { AllowedPorts = [1025] });

        Assert.Null(await guard.EvaluateAsync(PublicHost, 1025));
        Assert.NotNull(await guard.EvaluateAsync(PublicHost, 587));
    }

    [Fact]
    public async Task PortEntryOutOfRange_IsIgnored_AndOnlyNarrows()
    {
        var guard = Guard(new SmtpHostPolicyOptions { AllowedPorts = [0, 70000, 587] });

        Assert.Null(await guard.EvaluateAsync(PublicHost, 587));
        Assert.NotNull(await guard.EvaluateAsync(PublicHost, 25));
        Assert.NotNull(await guard.EvaluateAsync(PublicHost, 70000));
    }

    [Fact]
    public async Task OperatorAllowedPrivateNetwork_OpensThatRangeAndNothingElse()
    {
        var guard = Guard(new SmtpHostPolicyOptions { AllowedPrivateNetworks = ["10.0.0.0/8"] });

        Assert.Null(await guard.EvaluateAsync("10.0.0.15", 587));
        Assert.NotNull(await guard.EvaluateAsync("192.168.1.10", 587));
        Assert.NotNull(await guard.EvaluateAsync("127.0.0.1", 587));
    }

    [Fact]
    public async Task InvalidCidrEntry_IsIgnored_SoATypoOnlyNarrows()
    {
        var guard = Guard(new SmtpHostPolicyOptions
        {
            AllowedPrivateNetworks = ["10.0.0.0/8", "not-a-cidr", "  ", "10.0.0.0/99"]
        });

        Assert.Null(await guard.EvaluateAsync("10.0.0.15", 587));
        Assert.NotNull(await guard.EvaluateAsync("192.168.1.10", 587));
    }

    [Fact]
    public async Task RelayHostAllowList_IsExclusiveOnceConfigured()
    {
        // The operator's own entry is trimmed when the policy is built — that half is operator input.
        var guard = Guard(new SmtpHostPolicyOptions { AllowedRelayHosts = [" smtp.relay.example "] });

        // Case-insensitive and matched by name: an allow-listed host is the operator's own decision,
        // so it is not resolved at all.
        Assert.Null(await guard.EvaluateAsync("SMTP.Relay.Example", 587));
        Assert.NotNull(await guard.EvaluateAsync(PublicHost, 587));
    }

    [Fact]
    public async Task PaddedHost_IsNeverNormalized_AndStaysRefused()
    {
        // TenantEmailSettingsUpsertHandler stores SmtpHost verbatim and the validator only checks
        // NotEmpty, so " smtp.example.com " is storable — and it has never worked: the resolver
        // rejects the padding, so such a host failed at the socket before this guard existed. Neither
        // the guard nor the provider trims it, so it keeps failing and does not become a newly
        // accepted input. Normalizing what a tenant stored would be a product change of its own.
        var guard = Guard(new SmtpHostPolicyOptions { AllowedRelayHosts = ["smtp.relay.example"] });

        Assert.NotNull(await guard.EvaluateAsync(" smtp.relay.example ", 587));
        Assert.NotNull(await Guard().EvaluateAsync(" " + PublicHost + " ", 587));
        Assert.NotNull(await Guard().EvaluateAsync(PublicHost + " ", 587));
    }

    [Fact]
    public async Task RelayHostAllowList_DoesNotWaiveThePortSet()
    {
        var guard = Guard(new SmtpHostPolicyOptions { AllowedRelayHosts = ["smtp.relay.example"] });

        Assert.NotNull(await guard.EvaluateAsync("smtp.relay.example", 6379));
    }

    [Fact]
    public async Task EmptyHostOrMissingPort_IsRefused()
    {
        Assert.NotNull(await Guard().EvaluateAsync("   ", 587));
        Assert.NotNull(await Guard().EvaluateAsync(null, 587));
        Assert.NotNull(await Guard().EvaluateAsync(PublicHost, null));
    }

    [Fact]
    public async Task OperatorConfiguredEndpoint_IsNotEvaluatedAtAll()
    {
        // The documented local relay: Mailpit on localhost:1025, no credentials, no TLS
        // (docker-compose.mail.yml), configured by the operator through the Setting table. Loopback
        // and a port outside the submission set — and it has to keep working, because the operator
        // configured both halves and is not the caller this guards against.
        //
        // Only the server settings path produces marks like these: the merge grants a half solely
        // when the tenant row supplies nothing for it, so a tenant cannot reach this state by naming
        // the same endpoint (SeededStockInstall_RelaysForTheOperatorButNotForAnEchoingTenant).
        var mailpit = TenantEndpoint("localhost", 1025);
        mailpit.SmtpHostIsOperatorConfigured = true;
        mailpit.SmtpPortIsOperatorConfigured = true;

        Assert.Null(await Guard().EvaluateAsync(mailpit));
    }

    [Fact]
    public async Task TheSameEndpointWithoutTheOperatorMark_IsRefused()
    {
        Assert.NotNull(await Guard().EvaluateAsync(TenantEndpoint("localhost", 1025)));
    }

    [Fact]
    public async Task OperatorHost_IsNotAddressCheckedWhenTheTenantMovesOnlyThePort()
    {
        // An operator relay at 192.168.10.5:25 with the tenant configured for 587: a working
        // installation. The host half is still the operator's, so the private-address check does not
        // apply to it; only the port the tenant chose is judged, and 587 is a submission port.
        var settings = TenantEndpoint("192.168.10.5", 587);
        settings.SmtpHostIsOperatorConfigured = true;

        Assert.Null(await Guard().EvaluateAsync(settings));
    }

    [Fact]
    public async Task OperatorHost_DoesNotWaiveThePortSet()
    {
        // Same host, and this is the probe the finding describes — the port set alone closes it.
        var settings = TenantEndpoint("192.168.10.5", 6379);
        settings.SmtpHostIsOperatorConfigured = true;

        Assert.NotNull(await Guard().EvaluateAsync(settings));
    }

    [Fact]
    public async Task OperatorPort_DoesNotWaiveTheAddressCheck()
    {
        // The mirror image: the tenant kept the operator's port and picked the host. The host is the
        // half that must pass the address check.
        var settings = TenantEndpoint("10.0.0.15", 1025);
        settings.SmtpPortIsOperatorConfigured = true;

        Assert.NotNull(await Guard().EvaluateAsync(settings));
    }

    [Fact]
    public async Task Provider_RefusesWithoutTellingTheCallerWhy()
    {
        var logger = new CapturingLogger<SmtpEmailProvider>();
        var provider = new SmtpEmailProvider(logger, Guard());

        var internalAddress = await provider.SendAsync(TestMessage(), TenantEndpoint("10.0.0.15", 587));
        var forbiddenPort = await provider.SendAsync(TestMessage(), TenantEndpoint(PublicHost, 6379));

        // Identical outcome for both, and identical to a refused connection or a wrong password:
        // TenantEmailSettingsTestSendHandler turns every false into the same generic 500.
        Assert.False(internalAddress);
        Assert.False(forbiddenPort);

        // The difference exists in the server log and only there.
        Assert.Equal(2, logger.Entries.Count);
        Assert.All(logger.Entries, entry => Assert.Equal(LogLevel.Error, entry.Level));
        Assert.Contains(logger.Entries, entry => entry.Message.Contains("10.0.0.15", StringComparison.Ordinal));
        Assert.Contains(logger.Entries, entry => entry.Message.Contains("6379", StringComparison.Ordinal));
    }

    private sealed class CapturingLogger<T> : ILogger<T>
    {
        public List<(LogLevel Level, string Message, Exception? Exception)> Entries { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
            => Entries.Add((logLevel, formatter(state, exception), exception));
    }
}
