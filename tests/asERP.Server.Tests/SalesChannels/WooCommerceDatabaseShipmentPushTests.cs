using System.Net.Http;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.WooCommerceDatabase;
using asERP.SalesChannels.Models.WooCommerce;
using Microsoft.Extensions.Logging;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// The shipment push of the direct-MySQL connector — specifically whether it writes at all.
/// <para>
/// There is no MySQL server in this suite, so the channel points at a loopback port with no listener
/// (the same target the connect-message tests dial). Every write this connector makes goes through the
/// one <c>OpenAsync</c>, so the result alone says on which side of the write the push stopped: a push
/// that reports success cannot have reached the database, and a push that reports a failure and logs a
/// connect attempt got as far as dialling it. No meta row can be written either way, which is what
/// keeps this offline and deterministic.
/// </para>
/// </summary>
public class WooCommerceDatabaseShipmentPushTests
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

    /// <summary>Loopback port 9 has no listener; loopback is allow-listed so the dial is attempted at all.</summary>
    private const string ClosedPort = """{"host":"127.0.0.1","port":9,"database":"wp"}""";

    private static SalesChannelHostPolicy LoopbackPolicy() =>
        new(new SalesChannelHostPolicyOptions { AllowedPrivateNetworks = ["127.0.0.0/8"] });

    private static WooCommerceDatabaseConnector Connector(ILogger<WooCommerceDatabaseConnector> logger) =>
        new(null!, null!, null!, null!, null!, null!, logger, LoopbackPolicy());

    private static SalesChannelContext Context() => new()
    {
        SalesChannel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Type = SalesChannelType.WooCommerceDatabase,
            Name = "shipment-push",
            // RFC 5737 documentation space, never dialled: the shop base URL is validated too, and a
            // DNS name would make the test depend on a resolver.
            Url = "https://203.0.113.10/",
            Username = "woo",
            AdditionalConfigJson = ClosedPort,
        },
        Password = "secret",
        HttpClient = new HttpClient(),
        SyncRun = new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            Operation = ChannelSyncOperation.ImportSaless,
            TriggerSource = ChannelSyncTriggerSource.Event,
            Status = ChannelSyncRunStatus.Running,
            StartedAt = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid(),
        },
        CancellationToken = CancellationToken.None,
    };

    private static ShipmentPushPayload Payload(params string[] trackingNumbers) =>
        new(Guid.NewGuid(), "4711", trackingNumbers, "dhl");

    /// <summary>
    /// The defect: <c>Shipping.TrackingNumber</c> defaults to empty and creating that row is what
    /// enqueues the push, so "no number yet" is the usual state at enqueue time. This transport writes
    /// the meta table itself, so pushing the empty value is an UPDATE that clears the number the shop
    /// already holds under the key — or an INSERT of an empty one where no row existed. The real number
    /// arrives a tick later and the enqueuer resets the finished row to Pending, so waiting loses nothing.
    /// </summary>
    [Fact]
    public async Task ShipmentPush_WithoutATrackingNumber_DoesNotTouchTheDatabase()
    {
        var logger = new CapturingLogger<WooCommerceDatabaseConnector>();

        var result = await Connector(logger).PushShipmentAsync(Context(), Payload());

        // Success against a closed port is only reachable before the connect — no UPDATE, no INSERT.
        Assert.True(result.Success, result.ErrorMessage);
        Assert.Empty(logger.Entries);
    }

    /// <summary>
    /// Why the guard reads the formatted meta value instead of the payload's count: these payloads do
    /// carry a tracking number, so a count-based guard would let them through — and
    /// <c>WooShipmentTracking.FormatNumbers</c> drops whitespace-only entries, so what would be written
    /// is the same empty value that clears the shop's number.
    /// </summary>
    [Theory]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("   \r\n ")]
    public async Task ShipmentPush_WithAWhitespaceOnlyTrackingNumber_DoesNotTouchTheDatabase(string trackingNumber)
    {
        Assert.Equal(string.Empty, WooShipmentTracking.FormatNumbers([trackingNumber]));
        var logger = new CapturingLogger<WooCommerceDatabaseConnector>();

        var result = await Connector(logger).PushShipmentAsync(Context(), Payload(trackingNumber));

        Assert.True(result.Success, result.ErrorMessage);
        Assert.Empty(logger.Entries);
    }

    /// <summary>
    /// The other side of the guard: a real number still takes the write path. It cannot complete without
    /// a MySQL server, so what is pinned here is that the connector got as far as dialling one — the
    /// step the empty pushes above never reach.
    /// </summary>
    [Fact]
    public async Task ShipmentPush_WithATrackingNumber_GoesToTheDatabase()
    {
        var logger = new CapturingLogger<WooCommerceDatabaseConnector>();

        var result = await Connector(logger).PushShipmentAsync(Context(), Payload("00340434666768541089"));

        Assert.False(result.Success);
        var connectEntry = Assert.Single(logger.Entries, e => e.Message.Contains("connect to", StringComparison.Ordinal));
        Assert.Contains("127.0.0.1", connectEntry.Message, StringComparison.Ordinal);
        // The connect verdict, not the provider's — the push reports what every other path reports.
        Assert.NotNull(result.ErrorMessage);
        Assert.False(result.ErrorMessage.Contains("127.0.0.1", StringComparison.Ordinal));
        Assert.False(result.ErrorMessage.Contains("refused", StringComparison.OrdinalIgnoreCase));
    }
}
