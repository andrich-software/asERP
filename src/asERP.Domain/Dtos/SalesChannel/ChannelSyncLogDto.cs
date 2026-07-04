using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.SalesChannel;

/// <summary>
/// Wire-format projection of <c>ChannelSyncLog</c> for the Client UI's per-channel log explorer.
/// Mirrors the entity 1:1 — no field hiding, no aggregation.
/// </summary>
public class ChannelSyncLogDto
{
    public Guid Id { get; set; }
    public Guid SalesChannelId { get; set; }
    public Guid CorrelationId { get; set; }
    public ChannelSyncOperation Operation { get; set; }
    public ChannelSyncLogLevel Level { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Exception { get; set; }
    public DateTime Timestamp { get; set; }
}
