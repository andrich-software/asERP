using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Feed;

public class FeedDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public FeedTemplate Template { get; set; }
    public string Currency { get; set; } = string.Empty;
    public bool IsEnabled { get; set; }

    public Guid? SalesChannelId { get; set; }
    public string? SalesChannelName { get; set; }

    public string? DefaultDeliveryTime { get; set; }
    public decimal? DefaultShippingCost { get; set; }

    /// <summary>Absolute public feed URL (/feed/{id}); populated by the controller from the request host.</summary>
    public string PublicUrl { get; set; } = string.Empty;

    /// <summary>Timestamp of the most recent public retrieval (max FeedLog.DateCreated), if any.</summary>
    public DateTime? LastAccessedAt { get; set; }

    /// <summary>Number of products currently included in the feed.</summary>
    public int ProductCount { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}
