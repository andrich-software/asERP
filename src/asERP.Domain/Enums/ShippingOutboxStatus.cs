namespace asERP.Domain.Enums;

/// <summary>
/// Lifecycle of a <c>ShippingLabelOutbox</c> row. Separate from <c>ChannelOutboxStatus</c>
/// so the two queues can evolve independently.
/// </summary>
public enum ShippingOutboxStatus
{
    Pending = 1,
    InFlight = 2,
    Done = 3,
    DeadLetter = 4
}
