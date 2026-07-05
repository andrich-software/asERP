using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// Fallback queue for return-label creation — mirror of <see cref="ShippingLabelOutbox"/>
/// as its own table so the live shipping queue stays untouched. The create handler tries the
/// carrier synchronously and only enqueues here on transient failure; the shipping orchestrator
/// drains rows with exponential backoff.
/// </summary>
public class ReturnLabelOutbox : BaseEntity, IBaseEntity
{
    public Guid ReturnShipmentId { get; set; }
    public ReturnShipment? ReturnShipment { get; set; }

    public Guid ShippingProviderId { get; set; }

    /// <summary>"return-label:{ReturnShipmentId:N}" — one active row per return; the enqueuer coalesces.</summary>
    public string IdempotencyKey { get; set; } = string.Empty;

    public ShippingOutboxStatus Status { get; set; }

    public int AttemptCount { get; set; }
    public DateTime NextAttemptAt { get; set; }

    /// <summary>Truncated last error message — full stack in logs.</summary>
    public string? LastError { get; set; }

    public DateTime? CompletedAt { get; set; }
}
