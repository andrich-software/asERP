using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Entities;

namespace asToolkit.Application.Contracts.Persistence;

public interface ISalesChannelRepository : IGenericRepository<SalesChannel>
{
    Task<SalesChannel> GetDetails(Guid id);
    Task<bool> SalesChannelIsUniqueAsync(SalesChannel salesChannel, Guid? id = null);

    /// <summary>
    /// Loads all tracking-enabled channels with their token hashes, ACROSS tenants. The web-analytics
    /// ingest path is anonymous (no tenant context), so this deliberately bypasses the global tenant
    /// query filter. Returns no secrets — only the hash + the owning tenant/channel ids.
    /// </summary>
    Task<List<SalesChannelTrackingRef>> GetEnabledTrackingChannelsAsync(CancellationToken cancellationToken = default);
    // Task<SalesChannel> AddWithDetailsAsync(SalesChannel salesChannelCreateDto);
    // Task UpdateWithDetailsAsync(int id, SalesChannel salesChannelUpdateDto);
}