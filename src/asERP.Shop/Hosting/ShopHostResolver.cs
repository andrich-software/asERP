using asERP.Application.Contracts.Persistence;
using asERP.Domain.Dtos.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.Shop.Hosting;

/// <summary>
/// Resolves request hosts to shop channels on the anonymous storefront path. Keeps an in-memory
/// map of <c>host:port → binding</c> (there are few shop domains), refreshed at most every 30s,
/// so the hot path does no per-request database work. Loaded cross-tenant via the repository,
/// which bypasses the global tenant filter. Singleton — uses a service scope to reach the scoped
/// repository. Mirrors <c>TrackingTokenResolver</c> (asERP.Analytics), plus explicit invalidation
/// driven by <c>ShopDomainChangedNotification</c>.
/// </summary>
internal sealed class ShopHostResolver : IShopHostResolver
{
    private static readonly TimeSpan CacheTtl = TimeSpan.FromSeconds(30);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly SemaphoreSlim _gate = new(1, 1);

    private Maps _maps = Maps.Empty;
    private DateTime _loadedAtUtc = DateTime.MinValue;

    public ShopHostResolver(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<ShopHostBindingRef?> ResolveAsync(string normalizedHost, int port, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(normalizedHost))
        {
            return null;
        }

        var maps = await GetMapsAsync(cancellationToken);

        // Exact-port rows win over the "any port" sentinel row.
        if (maps.ByHostPort.TryGetValue(HostKey(normalizedHost, port), out var binding))
        {
            return binding;
        }

        return maps.ByHostPort.TryGetValue(HostKey(normalizedHost, 0), out var anyPortBinding)
            ? anyPortBinding
            : null;
    }

    public async Task<ShopHostBindingRef?> ResolveByChannelAsync(Guid salesChannelId, CancellationToken cancellationToken = default)
    {
        var maps = await GetMapsAsync(cancellationToken);
        return maps.ByChannel.TryGetValue(salesChannelId, out var binding) ? binding : null;
    }

    public void Invalidate()
    {
        // Next request takes the reload path; no lock needed for a monotonic reset.
        _loadedAtUtc = DateTime.MinValue;
    }

    private static string HostKey(string host, int port) => $"{host}:{port}";

    private async Task<Maps> GetMapsAsync(CancellationToken cancellationToken)
    {
        if (DateTime.UtcNow - _loadedAtUtc < CacheTtl)
        {
            return _maps;
        }

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (DateTime.UtcNow - _loadedAtUtc < CacheTtl)
            {
                return _maps;
            }

            using var scope = _scopeFactory.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IShopDomainRepository>();
            var bindings = await repository.GetActiveBindingsAsync(cancellationToken);

            var byHostPort = new Dictionary<string, ShopHostBindingRef>(StringComparer.Ordinal);
            var byChannel = new Dictionary<Guid, ShopHostBindingRef>();
            foreach (var binding in bindings)
            {
                // Hosts are stored normalized; the unique DB index makes keys unique in practice.
                byHostPort[HostKey(binding.Host, binding.Port)] = binding;

                // Per channel keep the primary binding (fallback: any) for circuit-side lookups.
                if (binding.IsPrimary || !byChannel.ContainsKey(binding.SalesChannelId))
                {
                    byChannel[binding.SalesChannelId] = binding;
                }
            }

            _maps = new Maps(byHostPort, byChannel);
            _loadedAtUtc = DateTime.UtcNow;
            return _maps;
        }
        finally
        {
            _gate.Release();
        }
    }

    private sealed record Maps(
        Dictionary<string, ShopHostBindingRef> ByHostPort,
        Dictionary<Guid, ShopHostBindingRef> ByChannel)
    {
        public static readonly Maps Empty = new([], []);
    }
}
