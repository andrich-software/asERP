using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Returns;

public class ReturnShipmentItemDto
{
    public Guid Id { get; set; }
    public Guid SalesItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public ReturnReason Reason { get; set; }
    public string? ReasonText { get; set; }
    public ReturnItemCondition Condition { get; set; }

    /// <summary>Serial numbers recorded as physically returned (at goods receipt).</summary>
    public List<string> SerialNumbers { get; set; } = new();

    /// <summary>Serial numbers of the underlying order line — offered for selection at goods receipt.</summary>
    public List<string> AvailableSerialNumbers { get; set; } = new();
}
