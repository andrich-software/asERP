using asToolkit.Application.Mediator;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Commands.ShippingUpdate;

/// <summary>
/// Updates mutable shipment fields. A non-null <see cref="Status"/> performs a manual status
/// change (routed through the status updater so it lands in SalesHistory).
/// </summary>
public class ShippingUpdateCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? TrackingNumber { get; set; }
    public string? TrackingUrl { get; set; }
    public decimal? ShippingCost { get; set; }
    public double? TaxRate { get; set; }
    public decimal? WeightKg { get; set; }
    public decimal? LengthCm { get; set; }
    public decimal? WidthCm { get; set; }
    public decimal? HeightCm { get; set; }
    public ShippingStatus? Status { get; set; }
}
