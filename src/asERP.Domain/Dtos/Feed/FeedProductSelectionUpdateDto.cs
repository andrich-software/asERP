namespace asERP.Domain.Dtos.Feed;

/// <summary>Batch of product inclusion changes for a feed — only changed rows are sent by the client.</summary>
public class FeedProductSelectionUpdateDto
{
    public List<FeedProductSelectionChange> Changes { get; set; } = new();
}

public class FeedProductSelectionChange
{
    public Guid ProductId { get; set; }

    /// <summary>Desired inclusion state: true = part of the feed, false = excluded.</summary>
    public bool IsActive { get; set; }
}
