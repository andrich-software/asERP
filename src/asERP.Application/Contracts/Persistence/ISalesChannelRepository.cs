using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Dtos.WebAnalytics;
using asERP.Domain.Entities;
using SalesChannelDeletionSummary = asERP.Domain.Dtos.SalesChannel.SalesChannelDeletionSummary;

namespace asERP.Application.Contracts.Persistence;

public interface ISalesChannelRepository : IGenericRepository<SalesChannel>
{
    Task<SalesChannel> GetDetails(Guid id);
    Task<bool> SalesChannelIsUniqueAsync(SalesChannel salesChannel, Guid? id = null);

    /// <summary>
    /// Replaces the channel's carrier translations with the submitted set (diffed, so unchanged rows
    /// keep their ids). Separate from <c>UpdateAsync</c> because assigning the navigation on the
    /// tracked channel would collide with EF identity resolution — the same hazard the warehouse
    /// handling inside <c>UpdateAsync</c> guards against.
    /// </summary>
    Task ReplaceCarrierMappingsAsync(
        Guid salesChannelId,
        IReadOnlyList<SalesChannelCarrierMappingInputDto> mappings);

    /// <summary>
    /// Deletes the channel together with every row that is worthless without it (shop domains,
    /// category/customer/product links, OAuth states, outbox + sync bookkeeping) and clears the
    /// channel reference on rows that survive it (product images, feeds). Explicit cascade — project
    /// rule; the DB-level FK cascades stay as a backstop but do not run under the InMemory provider.
    /// Business records (Sales, StockMovement) are deliberately kept untouched.
    /// </summary>
    Task<SalesChannelDeletionSummary> DeleteWithDependentsAsync(Guid id);

    /// <summary>
    /// Loads all tracking-enabled channels with their token hashes, ACROSS tenants. The web-analytics
    /// ingest path is anonymous (no tenant context), so this deliberately bypasses the global tenant
    /// query filter. Returns no secrets — only the hash + the owning tenant/channel ids.
    /// </summary>
    Task<List<SalesChannelTrackingRef>> GetEnabledTrackingChannelsAsync(CancellationToken cancellationToken = default);
    // Task<SalesChannel> AddWithDetailsAsync(SalesChannel salesChannelCreateDto);
    // Task UpdateWithDetailsAsync(int id, SalesChannel salesChannelUpdateDto);
}
