using asERP.Client.Core.Models;
using asERP.Domain.Dtos.Feed;

namespace asERP.Client.Features.Feeds.Services;

/// <summary>
/// Service interface for product-feed API operations.
/// </summary>
public interface IFeedService
{
    /// <summary>
    /// Gets a paginated list of feeds with full pagination metadata.
    /// </summary>
    Task<PaginatedResponse<FeedListDto>> GetFeedsAsync(
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a single feed by ID. The server fills <see cref="FeedDetailDto.PublicUrl"/>.
    /// </summary>
    Task<FeedDetailDto?> GetFeedAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Creates a new feed and returns the id of the newly created feed.
    /// </summary>
    Task<Guid> CreateFeedAsync(FeedInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Updates an existing feed.
    /// </summary>
    Task UpdateFeedAsync(Guid id, FeedInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Deletes a feed.
    /// </summary>
    Task DeleteFeedAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Gets a paginated list of the feed's public-access log entries.
    /// </summary>
    Task<PaginatedResponse<FeedLogDto>> GetFeedLogsAsync(
        Guid id,
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a paginated list of the feed's product selection (catalog metadata + inclusion flag).
    /// </summary>
    Task<PaginatedResponse<FeedProductSelectionDto>> GetFeedProductsAsync(
        Guid id,
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Persists a batch of product-inclusion changes (only changed rows are sent).
    /// </summary>
    Task UpdateFeedProductsAsync(Guid id, FeedProductSelectionUpdateDto changes, CancellationToken ct = default);
}
