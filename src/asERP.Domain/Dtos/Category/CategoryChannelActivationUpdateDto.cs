namespace asERP.Domain.Dtos.Category;

/// <summary>Batch of per-channel activation changes — only changed cells are sent by the client.</summary>
public class CategoryChannelActivationUpdateDto
{
    public List<CategoryChannelActivationChange> Changes { get; set; } = new();
}

public class CategoryChannelActivationChange
{
    public Guid CategoryId { get; set; }
    public Guid SalesChannelId { get; set; }

    /// <summary>Desired state: true = active on the channel, false = inactive (deleted remotely where supported).</summary>
    public bool IsActive { get; set; }
}
