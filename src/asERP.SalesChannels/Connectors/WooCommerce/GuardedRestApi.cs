#nullable disable
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using WooCommerceNET;

namespace asERP.SalesChannels.Connectors.WooCommerce;

/// <summary>
/// WooCommerceNET's <see cref="RestAPI"/> with its transport replaced by the channel's
/// <see cref="HttpClient"/>, so the WooCommerce REST calls run through the same SSRF connect-time
/// guard as every other channel.
///
/// Why this exists: in WooCommerceNET 0.8.7 every request is issued by <c>WebRequest.Create</c>
/// inside <c>RestAPI.SendHttpClientRequest</c>, i.e. <see cref="HttpWebRequest"/> — there is no
/// handler and no <see cref="HttpClient"/> to inject, and the <c>requestFilter</c> hook only hands
/// out the <see cref="HttpWebRequest"/>. That transport never runs the <c>ConnectCallback</c> which
/// re-validates the dialed IP, so the tenant-controlled shop URL was covered only by the pre-flight
/// DNS check in <see cref="SalesChannelUrlValidator.Validate"/> — a check a short-TTL DNS rebind
/// (or a redirect) defeats between validating and connecting.
///
/// <c>SendHttpClientRequest</c> is virtual and every SDK call funnels through it, so overriding it
/// moves all WooCommerce REST traffic onto the guarded named client without touching what goes on
/// the wire: URL building, authentication and (de)serialization stay the SDK's, this class only
/// swaps the socket for one whose address is validated at connect time.
///
/// One SDK method behaves differently for a subclass: <c>WCItem.UpdateWithNull</c> hand-builds its
/// JSON only when <c>API.GetType().Name == "RestAPI"</c>. This connector never calls it.
///
/// Unchanged by this class and worth knowing: which authentication the SDK uses is decided by the
/// scheme of the stored <c>SalesChannel.Url</c> alone. An <c>http://</c> URL selects OAuth 1.0a, which
/// signs the query, so the consumer key travels in the URL, where no redirect handler strips it. Do
/// not assume a validator prevents that: <see cref="SalesChannelUrlValidator"/> refuses a non-https
/// URL outside Development, but it is only called by the connector's import and connection-test
/// entry points — nothing validates the URL when it is stored, and the single-write export paths
/// (stock, price, cancel, tracking, the category writes) reach this transport without it.
/// </summary>
internal sealed class GuardedRestApi : RestAPI
{
    private readonly HttpClient _httpClient;
    private readonly string _userAgent;

    internal GuardedRestApi(string url, string key, string secret, HttpClient httpClient, string userAgent)
        : base(url, key, secret)
    {
        _httpClient = httpClient;
        _userAgent = userAgent;
    }

    public override async Task<string> SendHttpClientRequest<T>(
        string endpoint, RequestMethod method, T requestBody, Dictionary<string, string> parms = null)
    {
        HttpRequestMessage request;
        try
        {
            request = BuildRequest(endpoint, method, requestBody, parms);
        }
        catch (Exception ex)
        {
            // The SDK assembles the request inside a catch-all that hands the exception message back in
            // place of a response body for everything that is not a WebException — a payload its
            // DataContract serializer cannot handle, for one. Only transport failures were rethrown, and
            // those are still raised below, so callers keep the control flow and the text they had.
            return ex.Message;
        }

        using (request)
        {
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            }
            catch (OperationCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                // HttpClient reports its own timeout as a cancellation, but the callers treat a
                // cancellation as "the host is shutting down" and abort the whole run, while a timeout is
                // the transient failure they retry (GetOrderPageWithRetryAsync). Keep it a timeout. The
                // paged imports hit their own, shorter PageFetchTimeout long before this one.
                throw new TimeoutException($"The WooCommerce request to {request.RequestUri} timed out.", ex);
            }

            using (response)
            {
                // Mirrors the SDK: the body is read with the charset of the response's Content-Type,
                // defaulting to UTF-8.
                var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    // The SDK reports an error status as a WebException whose message is the response
                    // body (the WooCommerce error JSON); connect-test and sync-run messages show that
                    // text, so keep both the exception type and the message as they were.
                    throw new WebException(body, null, WebExceptionStatus.ProtocolError, null);
                }

                return body;
            }
        }
    }

    private HttpRequestMessage BuildRequest<T>(
        string endpoint, RequestMethod method, T requestBody, Dictionary<string, string> parms)
    {
        if (Version is APIVersion.WordPressAPI or APIVersion.WordPressAPIJWT || WCAuthWithJWT)
        {
            // The connector always builds a /wp-json/wc/v3 endpoint (WooCommerceConnector.BuildApiUrl)
            // and never enables JWT, so these SDK flavours are unreachable here. Refusing them is safer
            // than re-implementing a handshake nothing exercises.
            throw new NotSupportedException(
                "The guarded WooCommerce transport supports the WooCommerce REST API only.");
        }

        var overHttps = Url.StartsWith("https", StringComparison.OrdinalIgnoreCase);
        if (overHttps && !AuthorizedHeader)
        {
            // Same fallback the SDK applies: without header auth the credentials travel as query
            // parameters.
            parms ??= new Dictionary<string, string>();
            if (!parms.ContainsKey("consumer_key"))
            {
                parms.Add("consumer_key", wc_key);
            }

            if (!parms.ContainsKey("consumer_secret"))
            {
                parms.Add("consumer_secret", wc_secret);
            }
        }

        // The SDK's own endpoint builder: a plain query string over https, an OAuth 1.0a signed one
        // over http, picked by the scheme of the stored channel URL (see the class doc).
        var relativeUrl = GetOAuthEndPoint(method.ToString(), endpoint, parms);
        // The wp-json branch is the SDK's, reproduced as-is: it rebuilds the origin from the bare host,
        // discarding the configured port, any userinfo and any base path — a shop on a non-default port
        // or a subdirectory install would be addressed on port 443 of the host root, a different origin
        // than the one configured. Unreachable here: this connector only ever passes WooCommerce
        // resource names ("products", "orders/{id}", "products/categories"), never a wp-json-prefixed
        // endpoint, and the tenant controls the URL, not the endpoint. A caller that adds one must
        // revisit this line.
        var requestUri = overHttps && endpoint.StartsWith("wp-json", StringComparison.Ordinal)
            ? new Uri(new Uri("https://" + new Uri(Url).Host), relativeUrl)
            : new Uri(Url + relativeUrl);

        var request = new HttpRequestMessage(new HttpMethod(method.ToString()), requestUri);

        // A browser-like User-Agent, previously set through the SDK's requestFilter.
        request.Headers.TryAddWithoutValidation("User-Agent", _userAgent);

        if (overHttps && AuthorizedHeader)
        {
            request.Headers.TryAddWithoutValidation(
                "Authorization",
                "Basic " + Convert.ToBase64String(
                    Encoding.GetEncoding("ISO-8859-1").GetBytes(wc_key + ":" + wc_secret)));
        }

        request.Content = BuildContent(requestBody);
        return request;
    }

    private HttpContent BuildContent<T>(T requestBody)
    {
        if (requestBody is null)
        {
            return null;
        }

        string json;
        if (requestBody.GetType() != typeof(string))
        {
            json = SerializeJSon(requestBody);
        }
        else
        {
            var raw = requestBody.ToString();
            if (raw.Length == 0)
            {
                return null;
            }

            if (raw == "fileupload")
            {
                // The SDK's WordPress media upload, which this connector never calls.
                throw new NotSupportedException(
                    "File uploads are not supported by the guarded WooCommerce transport.");
            }

            json = raw;
        }

        // The same bytes and the same Content-Type the SDK put on the wire: UTF-8 JSON, no charset
        // parameter.
        var content = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return content;
    }
}
