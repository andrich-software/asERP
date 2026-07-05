namespace asERP.Domain.Enums;

/// <summary>
/// Fixed catalog of customer return reasons; free text goes into ReturnShipmentItem.ReasonText.
/// </summary>
public enum ReturnReason
{
    Unspecified = 0,
    DoesNotFit = 1,
    NotAsDescribed = 2,
    Defective = 3,
    WrongItemDelivered = 4,
    ArrivedTooLate = 5,
    ChangedMind = 6,
    Other = 99
}
