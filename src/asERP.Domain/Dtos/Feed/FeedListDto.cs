using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Feed;

public class FeedListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public FeedTemplate Template { get; set; }
    public string Currency { get; set; } = string.Empty;
    public bool IsEnabled { get; set; }

    /// <summary>Name of the linked Shopware6/WooCommerce channel, if any.</summary>
    public string? SalesChannelName { get; set; }

    /// <summary>Timestamp of the most recent public retrieval (max FeedLog.DateCreated), if any.</summary>
    public DateTime? LastAccessedAt { get; set; }

    public DateTime DateCreated { get; set; }
}
