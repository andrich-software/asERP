using System.Net;
using System.Net.Http;
using System.Text;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels;
using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Connectors.WooCommerce;
using asERP.SalesChannels.Models.WooCommerce;
using asERP.SalesChannels.Orchestration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// The WooCommerce REST calls are built by the WooCommerceNET SDK but sent over the channel's
/// SSRF-guarded HttpClient (<see cref="GuardedRestApi"/>) instead of the SDK's own HttpWebRequest,
/// which has no connect-time IP check. These tests pin both halves: an ordinary public https shop
/// gets the same request it got before, and a request aimed at an internal address is refused when
/// the socket is opened — the case the pre-flight DNS check cannot see. All HTTP is stubbed or
/// refused before connecting, so the tests stay offline.
/// </summary>
public class WooCommerceRestTransportTests
{
    // TEST-NET-3 literal: a public address the URL validator accepts without a DNS lookup.
    private const string ShopUrl = "https://203.0.113.10/";
    private const string ConsumerKey = "ck_public";
    private const string ConsumerSecret = "cs_secret";

    private static WooCommerceConnector Connector(IHttpClientFactory httpClientFactory) =>
        new(null!, null!, null!, null!, null!, null!, httpClientFactory, NullLogger<WooCommerceConnector>.Instance);

    private static SalesChannelContext Context(string url = ShopUrl, string? additionalConfigJson = null) => new()
    {
        SalesChannel = new SalesChannel
        {
            Id = Guid.NewGuid(),
            Type = SalesChannelType.WooCommerce,
            Name = "woo-rest",
            Url = url,
            AdditionalConfigJson = additionalConfigJson,
            // WooCommerce quirk: consumer key = Username, consumer secret = Password.
            Username = ConsumerKey,
        },
        Password = ConsumerSecret,
        // The context's client is the one SalesChannelContextFactory pins to 60 s; this connector must
        // not send on it, so anything that does fails the test loudly.
        HttpClient = new HttpClient(new UnusableHandler()),
        SyncRun = new ChannelSyncRun
        {
            Id = Guid.NewGuid(),
            Operation = ChannelSyncOperation.ImportProducts,
            TriggerSource = ChannelSyncTriggerSource.Manual,
            Status = ChannelSyncRunStatus.Running,
            StartedAt = DateTime.UtcNow,
            CorrelationId = Guid.NewGuid(),
        },
        CancellationToken = CancellationToken.None,
    };

    // --- The ordinary, correctly-configured shop ---------------------------------------------------

    [Fact]
    public async Task PublicHttpsShop_GetsTheRequestTheSdkAlwaysBuilt()
    {
        var handler = new CapturingHandler("[]");
        var factory = new StubHttpClientFactory(handler);

        var result = await Connector(factory).TestConnectionAsync(Context());

        Assert.True(result.Success);
        // The guarded, 100 s named client — not the context's 60 s instance.
        Assert.Equal("woocommerce", Assert.Single(factory.RequestedNames));
        var request = Assert.Single(handler.Requests);
        Assert.Equal(HttpMethod.Get, request.Method);
        // Same endpoint and query the SDK produced: base URL + /wp-json/wc/v3 + the resource.
        Assert.Equal("https://203.0.113.10/wp-json/wc/v3/products?per_page=1", request.Uri);
        // Header auth over https, exactly as WooCommerceNET builds it.
        Assert.Equal(
            "Basic " + Convert.ToBase64String(
                Encoding.GetEncoding("ISO-8859-1").GetBytes(ConsumerKey + ":" + ConsumerSecret)),
            request.Authorization);
        // The browser-like User-Agent that keeps the shop's WAF from challenging the import.
        Assert.StartsWith("Mozilla/5.0 ", request.UserAgent);
        Assert.Null(request.Body);
    }

    [Fact]
    public async Task ShopUrlAlreadyContainingTheApiPath_IsNotAppendedTwice()
    {
        var handler = new CapturingHandler("[]");

        var result = await Connector(new StubHttpClientFactory(handler))
            .TestConnectionAsync(Context("https://203.0.113.10/wp-json/wc/v3"));

        Assert.True(result.Success);
        Assert.Equal(
            "https://203.0.113.10/wp-json/wc/v3/products?per_page=1",
            Assert.Single(handler.Requests).Uri);
    }

    [Fact]
    public async Task WriteRequest_KeepsTheSdksJsonBodyAndContentType()
    {
        var handler = new CapturingHandler("{}");
        var payload = new StockUpdatePayload(Guid.NewGuid(), Guid.NewGuid(), "SKU-1", 7, "77");

        var result = await Connector(new StubHttpClientFactory(handler)).UpdateStockAsync(Context(), payload);

        Assert.True(result.Success, result.ErrorMessage);
        var request = Assert.Single(handler.Requests);
        // WooCommerce updates are POSTs on the resource; the SDK serialized the partial product as
        // plain UTF-8 JSON, and that is still exactly what goes out.
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("https://203.0.113.10/wp-json/wc/v3/products/77", request.Uri);
        Assert.Equal("application/json", request.ContentType);
        Assert.Contains("\"stock_quantity\":7", request.Body);
        Assert.Contains("\"manage_stock\":true", request.Body);
    }

    [Fact]
    public async Task ShipmentPush_SendsTheTrackingNumbersAsAPartialOrderUpdate()
    {
        // The body the SDK's DataContract serializer could not express (a Dictionary<string, object>
        // carrying an array of dictionaries): it threw, the SDK's transport handed the message back in
        // place of a response, and the push reported success while sending nothing. The connector now
        // serializes the update itself and passes the JSON as a string, which is the one shape
        // WooCommerceNET puts on the wire byte-for-byte instead of re-serializing.
        var handler = new CapturingHandler("{\"id\":42}");
        var payload = new ShipmentPushPayload(
            Guid.NewGuid(), "42", new[] { "00340434666768541089", "CE737758155DE" }, "dhl");

        var result = await Connector(new StubHttpClientFactory(handler)).PushShipmentAsync(Context(), payload);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal("42", result.RemoteId);
        var request = Assert.Single(handler.Requests);
        // A partial order update, which WooCommerce takes as a POST on the item route.
        Assert.Equal(HttpMethod.Post, request.Method);
        Assert.Equal("https://203.0.113.10/wp-json/wc/v3/orders/42", request.Uri);
        Assert.Equal("application/json", request.ContentType);
        // Byte-for-byte what the SDK's own typed Order.Update produces for one meta entry: only
        // meta_data, no "id" on the entry (which is what makes WooCommerce merge it by key), and the
        // numbers rendered by WooShipmentTracking.FormatNumbers so ImportShipments reads them back.
        Assert.Equal(
            "{\"meta_data\":[{\"key\":\"_order_shipment_numbers\","
            + "\"value\":\"00340434666768541089, CE737758155DE\"}]}",
            request.Body);
    }

    [Fact]
    public async Task ShipmentPush_WritesToTheMetaKeyFromTheChannelConfig()
    {
        var handler = new CapturingHandler("{\"id\":42}");
        var context = Context(additionalConfigJson: "{\"shipmentTrackingMetaKey\":\"_wc_shipment_tracking_items\"}");
        var payload = new ShipmentPushPayload(Guid.NewGuid(), "42", new[] { "ABC123" }, null);

        var result = await Connector(new StubHttpClientFactory(handler)).PushShipmentAsync(context, payload);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(
            "{\"meta_data\":[{\"key\":\"_wc_shipment_tracking_items\",\"value\":\"ABC123\"}]}",
            Assert.Single(handler.Requests).Body);
    }

    [Fact]
    public async Task ShipmentPush_RejectedByTheShop_IsReportedAsAFailure()
    {
        // What the replaced test protected: the connector must still hand back a result instead of
        // throwing — the dispatcher's control flow depends on it. What changed is which result a
        // rejected push gets: a genuine failure is now a failure, so the outbox retries it and can
        // eventually dead-letter the row, where it silently completed before.
        const string error = "{\"code\":\"woocommerce_rest_shop_order_invalid_id\",\"message\":\"Invalid ID.\"}";
        var handler = new CapturingHandler(error, HttpStatusCode.BadRequest);
        var payload = new ShipmentPushPayload(Guid.NewGuid(), "42", new[] { "00340434666768541089" }, "dhl");

        var result = await Connector(new StubHttpClientFactory(handler)).PushShipmentAsync(Context(), payload);

        Assert.False(result.Success);
        Assert.Contains("Invalid ID.", result.ErrorMessage);
        Assert.Single(handler.Requests);
    }

    [Fact]
    public async Task ShipmentPush_WithoutATrackingNumber_SendsNothing()
    {
        // A Shipping row exists before its label does, so the order can reach the connector with no
        // number at all. Pushing the empty value would clear the key in the shop; the write that
        // produces the number enqueues its own push.
        var handler = new CapturingHandler("{\"id\":42}");
        var payload = new ShipmentPushPayload(Guid.NewGuid(), "42", Array.Empty<string>(), "dhl");

        var result = await Connector(new StubHttpClientFactory(handler)).PushShipmentAsync(Context(), payload);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.Empty(handler.Requests);
    }

    [Fact]
    public async Task ErrorStatus_StillSurfacesTheShopsOwnErrorText()
    {
        const string error = "{\"code\":\"woocommerce_rest_authentication_error\",\"message\":\"Invalid signature.\"}";
        var handler = new CapturingHandler(error, HttpStatusCode.Unauthorized);

        var result = await Connector(new StubHttpClientFactory(handler)).TestConnectionAsync(Context());

        Assert.False(result.Success);
        Assert.Contains("Invalid signature.", result.Message);
    }

    [Fact]
    public void SingleWrites_KeepTheCeilingTheSdksTransportGaveThem()
    {
        // HttpWebRequest's default is 100 s, and that is what a single write (stock, price, cancel,
        // tracking, category) ran under before the transport swap. SalesChannelContextFactory pins the
        // context's client to 60 s, which is why the connector asks the factory for this one instead —
        // do not quietly drop it back to 60 s: a slow but legitimate write would start failing.
        // Resolved by the same name mapping the connector uses.
        var client = RegisteredClient(SalesChannelContextFactory.HttpClientNameFor(SalesChannelType.WooCommerce));

        Assert.Equal(TimeSpan.FromSeconds(100), client.Timeout);
        // The paged imports stay bounded at 60 s by the connector's own PageFetchTimeout wrapper, well
        // inside this ceiling, which is what keeps a slow page in the retry bucket.
        Assert.True(client.Timeout > TimeSpan.FromSeconds(60));
    }

    // --- The guard ---------------------------------------------------------------------------------

    [Fact]
    public async Task InternalAddress_IsRefusedWhenTheSocketIsOpened()
    {
        // The real registered client, so the ConnectCallback under test is the one production uses.
        // Dialing a private literal stands in for the state after a DNS rebind: the pre-flight check
        // saw a public address, the connect resolves to an internal one.
        var rest = new GuardedRestApi(
            "https://10.0.0.5/wp-json/wc/v3/",
            ConsumerKey,
            ConsumerSecret,
            RegisteredClient("woocommerce"),
            "asERP");

        var ex = await Assert.ThrowsAsync<HttpRequestException>(
            () => rest.GetRestful("products", new Dictionary<string, string> { ["per_page"] = "1" }));

        Assert.Contains("blocked private/reserved address", ex.ToString());

        // ...but only down in the cause, which is where the server log reads it. Message is what the
        // connectors hand on as SyncResult.Failed(ex.Message) into ChannelSyncRun.ErrorSummary, and
        // what ProductImageImportService logs once per image into the tenant-readable sync log, so the
        // guard's finding must not be in it. The target here is a literal, so the address itself is
        // the caller's own input and still appears — what must not is the resolver's verdict on it,
        // which is the only thing a DNS name would have disclosed.
        Assert.DoesNotContain("blocked private/reserved address", ex.Message, StringComparison.Ordinal);
        Assert.True(ChannelTransportException.Describes(ex),
            "the guard's rejection must be marked, or the sync-log sink persists it for the tenant");
    }

    [Fact]
    public void WooCommerceClient_CarriesTheSameConnectGuardAsTheOtherChannels()
    {
        var guarded = PrimaryHandler("woocommerce");

        Assert.NotNull(guarded.ConnectCallback);
        Assert.NotNull(PrimaryHandler("shopware6").ConnectCallback);
        // Redirects stay enabled — a shop's own http→https or canonical-URL hop must keep working.
        // They are safe now: ConnectCallback validates the address of every hop's connection, and
        // HttpClient drops the Authorization header on a redirect to another host.
        Assert.True(guarded.AllowAutoRedirect);
    }

    private static ServiceProvider BuildProvider() =>
        new ServiceCollection().AddSalesChannelServices(includeBackgroundServices: false).BuildServiceProvider();

    private static HttpClient RegisteredClient(string name) =>
        BuildProvider().GetRequiredService<IHttpClientFactory>().CreateClient(name);

    private static SocketsHttpHandler PrimaryHandler(string name)
    {
        HttpMessageHandler handler = BuildProvider()
            .GetRequiredService<IHttpMessageHandlerFactory>()
            .CreateHandler(name);

        while (handler is DelegatingHandler delegating)
        {
            handler = delegating.InnerHandler!;
        }

        return Assert.IsType<SocketsHttpHandler>(handler);
    }

    private sealed record CapturedRequest(
        HttpMethod Method,
        string Uri,
        string? Authorization,
        string? UserAgent,
        string? ContentType,
        string? Body);

    private sealed class CapturingHandler : HttpMessageHandler
    {
        private readonly string _responseBody;
        private readonly HttpStatusCode _status;

        public CapturingHandler(string responseBody, HttpStatusCode status = HttpStatusCode.OK)
        {
            _responseBody = responseBody;
            _status = status;
        }

        public List<CapturedRequest> Requests { get; } = [];

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // NonValidated returns the header exactly as it goes on the wire, without re-parsing the
            // User-Agent into its product tokens.
            Requests.Add(new CapturedRequest(
                request.Method,
                request.RequestUri!.ToString(),
                Header(request, "Authorization"),
                Header(request, "User-Agent"),
                request.Content?.Headers.ContentType?.ToString(),
                request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken)));

            return new HttpResponseMessage(_status)
            {
                Content = new StringContent(_responseBody, Encoding.UTF8, "application/json"),
            };
        }

        private static string? Header(HttpRequestMessage request, string name) =>
            request.Headers.NonValidated.TryGetValues(name, out var values) ? values.ToString() : null;
    }

    /// <summary>Stands in for the named client the connector asks the factory for.</summary>
    private sealed class StubHttpClientFactory : IHttpClientFactory
    {
        private readonly HttpMessageHandler _handler;

        public StubHttpClientFactory(HttpMessageHandler handler) => _handler = handler;

        public List<string> RequestedNames { get; } = [];

        public HttpClient CreateClient(string name)
        {
            RequestedNames.Add(name);
            return new HttpClient(_handler, disposeHandler: false);
        }
    }

    /// <summary>The context's HttpClient: reaching for it instead of the named one is a bug.</summary>
    private sealed class UnusableHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken) =>
            throw new InvalidOperationException(
                "The WooCommerce connector must send on the named client, not on the context's 60 s one.");
    }
}
