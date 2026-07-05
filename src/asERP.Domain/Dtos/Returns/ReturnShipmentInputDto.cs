namespace asERP.Domain.Dtos.Returns;

public class ReturnShipmentInputDto
{
    public Guid SalesId { get; set; }

    /// <summary>The outbound parcel the return relates to. When set, all items must come from it.</summary>
    public Guid? OriginalShippingId { get; set; }

    /// <summary>Request a carrier return label immediately after creation.</summary>
    public bool RequestLabel { get; set; }

    /// <summary>Carrier for the return label — required when <see cref="RequestLabel"/> is true.</summary>
    public Guid? ShippingProviderId { get; set; }

    public List<ReturnShipmentItemInputDto> Items { get; set; } = new();

    public string? Note { get; set; }
}
