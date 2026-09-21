using System.Text.RegularExpressions;
using asERP.SalesChannels;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// What a rejected sales-channel URL tells the caller. The URL is tenant input and this text reaches
/// them: sixteen call sites funnel it into <c>ConnectionTestResult.Message</c>,
/// <c>SyncResult.Failed($"Invalid sales channel URL: {ex.Message}")</c> → <c>ChannelSyncRun.ErrorSummary</c>
/// and, on the export paths, <c>ChannelExportOutbox.LastError</c>. It used to distinguish "does not
/// resolve" from "resolves to nothing" from "resolves to a private or reserved address (10.0.0.7)" —
/// which answers which internal names exist, and handed over the address, for a caller who cannot query
/// the server's resolver. Those three now read alike. Failures decided from the caller's own text stay
/// distinct: they disclose nothing and they are what makes the create wizard usable.
/// </summary>
public class SalesChannelUrlValidatorMessageTests
{
    private static string RejectionFor(string url)
    {
        var ex = Assert.Throws<ArgumentException>(() => SalesChannelUrlValidator.Validate(url));
        return ex.Message;
    }

    private static ArgumentException Rejection(string url)
        => Assert.Throws<ArgumentException>(() => SalesChannelUrlValidator.Validate(url));

    // ".invalid" is reserved by RFC 2606 and never resolves, so this exercises the resolution branch
    // without depending on any particular resolver's view of the world.
    private const string NeverResolves = "https://nx.invalid/shop";

    [Fact]
    public void AHostThatDependsOnResolving_IsRejectedWithoutSayingWhatTheResolverSaw()
    {
        var message = RejectionFor(NeverResolves);

        Assert.DoesNotContain("could not be resolved", message, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("no addresses", message, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("resolves to", message, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Only public addresses are dialled", message, StringComparison.Ordinal);
    }

    [Fact]
    public void ARejectionThatDependedOnResolving_NeverCarriesAnAddress()
    {
        // The core of it: no IPv4 or IPv6 literal may appear in text the caller receives, because the
        // caller did not supply one — the resolver did.
        var message = RejectionFor(NeverResolves);

        Assert.False(Regex.IsMatch(message, @"\d{1,3}(\.\d{1,3}){3}"), $"IPv4 literal leaked: {message}");
        Assert.False(Regex.IsMatch(message, @"[0-9a-fA-F]{0,4}(:[0-9a-fA-F]{0,4}){2,}"), $"IPv6 literal leaked: {message}");
    }

    [Fact]
    public void ARejectionThatDependedOnResolving_IsMarkedSoItsDetailStaysOutOfTheSyncLog()
    {
        // The marker is what makes SalesChannelSyncLogSink drop the line; without it the resolver's
        // own exception text would be persisted to ChannelSyncLog and served by GET sync-logs.
        Assert.True(ChannelTransportException.Describes(Rejection(NeverResolves)));
    }

    // --- what stays distinct, and why that costs nothing --------------------------------------------

    [Theory]
    [InlineData("", "must not be empty")]
    [InlineData("not-a-url", "not a valid absolute URI")]
    [InlineData("ftp://shop.example/x", "http or https")]
    [InlineData("https://localhost/shop", "internal host")]
    [InlineData("https://10.0.0.7/shop", "private or reserved IP address")]
    public void AFailureReadOffTheCallersOwnText_KeepsItsOwnWording(string url, string expected)
    {
        // Every one of these is decided from the string the caller typed, without resolving anything,
        // so it tells them only what they already know — and it is the diagnostic they need to fix the
        // URL. A literal private IP is in this group on purpose: the caller supplied the address.
        Assert.Contains(expected, RejectionFor(url), StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void AFailureReadOffTheCallersOwnText_IsNotMarkedAsATransportFailure()
    {
        // These must keep reaching the sync log: they are the only way a user sees why an import
        // rejected their URL, and they disclose nothing.
        Assert.False(ChannelTransportException.Describes(Rejection("https://10.0.0.7/shop")));
        Assert.False(ChannelTransportException.Describes(Rejection("not-a-url")));
    }

    [Fact]
    public void APublicLiteralAddress_IsAccepted()
    {
        // 203.0.113.0/24 is RFC 5737 documentation space and is never dialled by this test — the point
        // is only that the guard does not reject everything.
        SalesChannelUrlValidator.Validate("https://203.0.113.10/shop");
    }
}
