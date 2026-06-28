using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace asToolkit.Analytics.Identity;

/// <summary>
/// Resolves a raw tracking token to its channel/tenant on the anonymous ingest path. Keeps an in-memory
/// map of <c>tokenHash → channel</c> (there are few tracking channels), refreshed at most every 30s, so
/// the hot path does no per-beacon database work. Loaded cross-tenant via the repository, which bypasses
/// the global tenant filter. Singleton — uses a service scope to reach the scoped repository.
/// </summary>
internal sealed class TrackingTokenResolver : ITrackingTokenResolver
{
    private static readonly TimeSpan CacheTtl = TimeSpan.FromSeconds(30);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly SemaphoreSlim _gate = new(1, 1);

    private Dictionary<string, SalesChannelTrackingRef> _byHash = new(StringComparer.OrdinalIgnoreCase);
    private DateTime _loadedAtUtc = DateTime.MinValue;

    public TrackingTokenResolver(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<SalesChannelTrackingRef?> ResolveAsync(string token, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        var hash = TrackingTokenHasher.Hash(token);
        var map = await GetMapAsync(cancellationToken);
        return map.TryGetValue(hash, out var channel) ? channel : null;
    }

    private async Task<Dictionary<string, SalesChannelTrackingRef>> GetMapAsync(CancellationToken cancellationToken)
    {
        if (DateTime.UtcNow - _loadedAtUtc < CacheTtl)
        {
            return _byHash;
        }

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (DateTime.UtcNow - _loadedAtUtc < CacheTtl)
            {
                return _byHash;
            }

            using var scope = _scopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<ISalesChannelRepository>();
            var channels = await repository.GetEnabledTrackingChannelsAsync(cancellationToken);

            // Last-writer-wins on the (vanishingly unlikely) hash collision; keys are unique in practice.
            var map = new Dictionary<string, SalesChannelTrackingRef>(StringComparer.OrdinalIgnoreCase);
            foreach (var channel in channels)
            {
                map[channel.TrackingTokenHash] = channel;
            }

            _byHash = map;
            _loadedAtUtc = DateTime.UtcNow;
            return _byHash;
        }
        finally
        {
            _gate.Release();
        }
    }
}
