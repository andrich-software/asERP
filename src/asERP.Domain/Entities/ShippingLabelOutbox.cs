using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// Fallback queue for label creation: the create handler tries the carrier synchronously and
/// only enqueues here on transient failure. The shipping orchestrator drains rows with
/// exponential backoff; rows exceeding the retry budget land in <see cref="ShippingOutboxStatus.DeadLetter"/>.
/// No payload JSON — the drainer hydrates the request from current DB state.
/// </summary>
public class ShippingLabelOutbox : BaseEntity, IBaseEntity
{
    public Guid ShippingId { get; set; }
    public Shipping? Shipping { get; set; }

    public Guid ShippingProviderId { get; set; }

    /// <summary>"label:{ShippingId:N}" — one active row per shipment; the enqueuer coalesces.</summary>
    public string IdempotencyKey { get; set; } = string.Empty;

    public ShippingOutboxStatus Status { get; set; }

    public int AttemptCount { get; set; }
    public DateTime NextAttemptAt { get; set; }

    /// <summary>Truncated last error message — full stack in logs.</summary>
    public string? LastError { get; set; }

    public DateTime? CompletedAt { get; set; }
}
