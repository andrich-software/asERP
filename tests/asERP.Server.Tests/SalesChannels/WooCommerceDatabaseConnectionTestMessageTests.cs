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
/// connect outcome now reads the same whatever went wrong, and the detail goes to the server log.
/// Configuration errors stay verbatim: they are computed from the caller's own input and nothing is
/// dialled to produce them.
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
}
