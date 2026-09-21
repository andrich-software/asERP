using System.Net.Http;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.WooCommerceDatabase;
using Microsoft.Extensions.Logging;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// The connection test dials a host and a port the caller typed in, so its failure text used to
/// report open/closed/filtered per target — an internal port scanner with a JSON response. The
/// connect outcome now reads the same whatever went wrong, including a rejected server certificate,
/// and the detail goes to the server log. Configuration errors stay verbatim: they are computed from
/// the caller's own input and nothing is dialled to produce them.
/// </summary>
public class WooCommerceDatabaseConnectionTestMessageTests
{
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

    private static WooCommerceDatabaseConnector Connector(ILogger<WooCommerceDatabaseConnector> logger, SalesChannelHostPolicy policy) =>
        new(null!, null!, null!, null!, null!, null!, logger, policy);

    private static SalesChannelContext Context(string configJson) => new()
    {
        SalesChannel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Type = SalesChannelType.WooCommerceDatabase,
            Name = "connection-test",
            // A public literal address: the shop base URL is validated as well, and a DNS name
            // would make the test depend on a resolver. 203.0.113.0/24 is RFC 5737 documentation
            // space and is never dialled here.
            Url = "https://203.0.113.10/",
            Username = "woo",
            AdditionalConfigJson = configJson,
        },
        Password = "secret",
        HttpClient = new HttpClient(),
        SyncRun = new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            Operation = ChannelSyncOperation.ImportProducts,
            TriggerSource = ChannelSyncTriggerSource.Manual,
            Status = ChannelSyncRunStatus.Success,
            StartedAt = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid(),
        },
        CancellationToken = CancellationToken.None,
    };

    [Fact]
    public async Task ConnectFailure_ReturnsAGenericMessageAndLogsTheDetail()
    {
        var logger = new CapturingLogger<WooCommerceDatabaseConnector>();
        // Loopback is allow-listed so the test reaches the connect phase at all; port 9 has no
        // listener, which is exactly the "closed port" the oracle used to report back.
        var connector = Connector(
            logger,
            new SalesChannelHostPolicy(new SalesChannelHostPolicyOptions
            {
                AllowedPrivateNetworks = ["127.0.0.0/8"],
            }));

        var result = await connector.TestConnectionAsync(
            Context("""{"host":"127.0.0.1","port":9,"database":"wp"}"""));

        Assert.False(result.Success);
        Assert.NotNull(result.Message);
        Assert.False(result.Message.Contains("127.0.0.1", StringComparison.Ordinal),
            "The target must not be echoed — that is what makes the response a port scanner.");
        Assert.False(result.Message.Contains("refused", StringComparison.OrdinalIgnoreCase),
            "Open, closed and filtered must be indistinguishable to the caller.");

        var entry = Assert.Single(logger.Entries);
        Assert.Equal(LogLevel.Warning, entry.Level);
        Assert.NotNull(entry.Exception);
        Assert.Contains("127.0.0.1", entry.Message);
    }

    [Fact]
    public async Task BlockedHost_IsRefusedWithoutDialling_EvenWhenTheBlobAsksForIt()
    {
        var logger = new CapturingLogger<WooCommerceDatabaseConnector>();
        var connector = Connector(logger, SalesChannelHostPolicy.DenyAll);

        var result = await connector.TestConnectionAsync(
            Context("""{"host":"127.0.0.1","port":9,"database":"wp","allowPrivateHost":true}"""));

        Assert.False(result.Success);
        Assert.Contains("not permitted", result.Message);
        Assert.Empty(logger.Entries);
    }

    [Fact]
    public async Task ConfigurationError_StaysVerbatim()
    {
        var logger = new CapturingLogger<WooCommerceDatabaseConnector>();
        var connector = Connector(logger, SalesChannelHostPolicy.DenyAll);

        var result = await connector.TestConnectionAsync(Context("""{"port":3306,"database":"wp"}"""));

        Assert.False(result.Success);
        Assert.Contains("host is missing", result.Message);
        Assert.Empty(logger.Entries);
    }

    // --- TLS verification: diagnosable for the operator, opaque to the caller ----------------------

    /// <summary>
    /// Dials the closed loopback port under the given policy. Loopback is allow-listed so the
    /// attempt reaches the connect phase; no TLS handshake ever happens, which keeps the test
    /// offline and deterministic.
    /// </summary>
    private static async Task<(string Message, CapturingLogger<WooCommerceDatabaseConnector> Logger)>
        FailedConnectAsync(SalesChannelHostPolicyOptions options)
    {
        var logger = new CapturingLogger<WooCommerceDatabaseConnector>();
        options.AllowedPrivateNetworks = ["127.0.0.0/8"];

        var result = await Connector(logger, new SalesChannelHostPolicy(options))
            .TestConnectionAsync(Context("""{"host":"127.0.0.1","port":9,"database":"wp"}"""));

        Assert.False(result.Success);
        Assert.NotNull(result.Message);
        return (result.Message, logger);
    }

    [Fact]
    public async Task ConnectFailure_ReadsTheSameUnderEveryTlsPolicy_AndNamesTheOperatorSwitches()
    {
        // VerifyFull default vs. the insecure escape hatch, same unreachable target: the caller must
        // not be able to tell from the text which mode was attempted or what the server presented.
        var (verifying, _) = await FailedConnectAsync(new SalesChannelHostPolicyOptions());
        var (insecure, _) = await FailedConnectAsync(
            new SalesChannelHostPolicyOptions { AllowInsecureTransport = true });
        var (mismatch, _) = await FailedConnectAsync(
            new SalesChannelHostPolicyOptions { AllowCertificateHostnameMismatch = true });

        Assert.Equal(verifying, insecure);
        Assert.Equal(verifying, mismatch);

        // Naming the switches costs no oracle: the text is a constant and says which knobs exist,
        // never which one this attempt would have needed. Without it a TLS-verification failure
        // reads as "check host, port, database, user and password" and the operator never looks.
        Assert.Contains("SalesChannelHostPolicy:SslCaPath", verifying, StringComparison.Ordinal);
        Assert.Contains("SalesChannelHostPolicy:AllowCertificateHostnameMismatch", verifying, StringComparison.Ordinal);
        Assert.Contains("SalesChannelHostPolicy:AllowInsecureTransport", verifying, StringComparison.Ordinal);
    }

    [Fact]
    public async Task ConnectFailure_LogsTheAttemptedTlsMode()
    {
        // The one place the outcome is allowed to be specific. Without the mode in the log a
        // certificate rejection is indistinguishable from a closed port for the operator too.
        var (_, logger) = await FailedConnectAsync(new SalesChannelHostPolicyOptions());

        var entry = Assert.Single(logger.Entries);
        Assert.Contains("VerifyFull", entry.Message, StringComparison.Ordinal);
    }
}
