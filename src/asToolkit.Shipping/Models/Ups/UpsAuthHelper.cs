using System.Collections.Concurrent;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using asToolkit.Shipping.Abstractions;
using Microsoft.Extensions.Logging;

namespace asToolkit.Shipping.Models.Ups;

/// <summary>
/// OAuth2 client_credentials exchange for the UPS API. Tokens (~4h) are cached in memory per
/// provider until 60s before expiry, with per-provider locking to coalesce concurrent refreshes.
/// Mirror of the Shopware6AuthHelper pattern.
/// </summary>
public sealed class UpsAuthHelper
{
    internal const string HttpClientName = "ups-oauth";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<UpsAuthHelper> _logger;
    private readonly ConcurrentDictionary<Guid, CachedToken> _cache = new();
    private readonly ConcurrentDictionary<Guid, SemaphoreSlim> _locks = new();

    public UpsAuthHelper(IHttpClientFactory httpClientFactory, ILogger<UpsAuthHelper> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<string> GetAccessTokenAsync(ShippingCarrierContext context)
    {
        var providerId = context.Provider.Id;

        if (_cache.TryGetValue(providerId, out var cached) && cached.ExpiresAt > DateTime.UtcNow.AddSeconds(60))
        {
            return cached.AccessToken;
        }

        var gate = _locks.GetOrAdd(providerId, _ => new SemaphoreSlim(1, 1));
        await gate.WaitAsync(context.CancellationToken);
        try
        {
            if (_cache.TryGetValue(providerId, out cached) && cached.ExpiresAt > DateTime.UtcNow.AddSeconds(60))
            {
                return cached.AccessToken;
            }

            var baseUrl = context.UseSandbox ? "https://wwwcie.ups.com" : "https://onlinetools.ups.com";
            var http = _httpClientFactory.CreateClient(HttpClientName);

            using var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}/security/v1/oauth/token");
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{context.ApiKey}:{context.ApiSecret}")));
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["grant_type"] = "client_credentials"
            });

            var response = await http.SendAsync(request, context.CancellationToken);
            var payload = await response.Content.ReadAsStringAsync(context.CancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("UPS OAuth token exchange failed: {Status} {Body}", (int)response.StatusCode, payload);
                throw new InvalidOperationException($"UPS OAuth token exchange failed: {(int)response.StatusCode}");
            }

            using var doc = JsonDocument.Parse(payload);
            var accessToken = doc.RootElement.GetProperty("access_token").GetString()
                ?? throw new InvalidOperationException("Empty UPS OAuth token response");
            var expiresIn = doc.RootElement.TryGetProperty("expires_in", out var exp)
                && long.TryParse(exp.GetString() ?? exp.ToString(), out var seconds)
                ? seconds
                : 3600;

            var entry = new CachedToken(accessToken, DateTime.UtcNow.AddSeconds(Math.Max(60, expiresIn)));
            _cache[providerId] = entry;
            return entry.AccessToken;
        }
        finally
        {
            gate.Release();
        }
    }

    private sealed record CachedToken(string AccessToken, DateTime ExpiresAt);
}
