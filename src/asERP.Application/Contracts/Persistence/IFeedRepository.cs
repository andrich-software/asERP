using asERP.Domain.Dtos.Feed;
using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IFeedRepository : IGenericRepository<Feed>
{
    /// <summary>Loads a feed (tenant-scoped) with its linked sales channel. Throws NotFoundException if absent.</summary>
    Task<Feed> GetDetails(Guid id);

    /// <summary>
    /// Resolves a feed by its public id ACROSS tenants for the anonymous <c>/feed/{id}</c> endpoint
    /// (there is no tenant context yet). Includes the linked sales channel. Returns null if unknown.
    /// </summary>
    Task<Feed?> GetPublicByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>Timestamp of the most recent public retrieval (max FeedLog.DateCreated), or null.</summary>
    Task<DateTime?> GetLastAccessedAtAsync(Guid feedId, CancellationToken cancellationToken = default);

    /// <summary>Number of catalog products currently included in the feed (total minus explicit exclusions).</summary>
    Task<int> GetIncludedProductCountAsync(Guid feedId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Applies a batch of inclusion changes: upserts one <see cref="FeedProduct"/> row per product with the
    /// desired <c>IsActive</c> value. Changes referencing products outside the tenant catalog are ignored.
    /// </summary>
    Task ApplyProductSelectionAsync(Guid feedId, IReadOnlyList<FeedProductSelectionChange> changes, CancellationToken cancellationToken = default);
}
