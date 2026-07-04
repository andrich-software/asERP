namespace asERP.Shipping.Abstractions;

/// <summary>
/// Result of a carrier label creation. <see cref="IsPermanentFailure"/> distinguishes validation
/// errors (bad address, bad billing number — retrying is pointless) from transient errors
/// (5xx, timeout, open circuit) that the outbox may retry.
/// </summary>
public sealed record CarrierLabelResult(
    bool Success,
    string? TrackingNumber = null,
    string? CarrierShipmentId = null,
    byte[]? LabelData = null,
    string LabelFormat = "application/pdf",
    string? TrackingUrl = null,
    string? ErrorMessage = null,
    bool IsPermanentFailure = false)
{
    public static CarrierLabelResult Ok(string trackingNumber, string carrierShipmentId, byte[] labelData,
        string labelFormat = "application/pdf", string? trackingUrl = null)
        => new(true, trackingNumber, carrierShipmentId, labelData, labelFormat, trackingUrl);

    public static CarrierLabelResult Permanent(string error) => new(false, ErrorMessage: error, IsPermanentFailure: true);

    public static CarrierLabelResult Transient(string error) => new(false, ErrorMessage: error);
}

public sealed record CarrierTrackingResult(
    bool Success,
    CarrierTrackingStatus Status = CarrierTrackingStatus.Unknown,
    string? StatusDescription = null,
    DateTime? EventTimestampUtc = null,
    string? ErrorMessage = null)
{
    public static CarrierTrackingResult Ok(CarrierTrackingStatus status, string? description = null, DateTime? eventTimestampUtc = null)
        => new(true, status, description, eventTimestampUtc);

    public static CarrierTrackingResult Failed(string error) => new(false, ErrorMessage: error);
}

public sealed record CarrierCancelResult(bool Success, string? ErrorMessage = null)
{
    public static CarrierCancelResult Ok() => new(true);
    public static CarrierCancelResult Failed(string error) => new(false, error);
}

public sealed record CarrierConnectionTestResult(bool Success, string? Message = null);
