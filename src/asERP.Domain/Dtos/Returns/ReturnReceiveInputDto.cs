using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Returns;

public class ReturnReceiveInputDto
{
    public List<ReturnReceiveItemInputDto> Items { get; set; } = new();

    /// <summary>Informational in v1 — no payment integration.</summary>
    public decimal? RefundAmount { get; set; }

    public string? Note { get; set; }
}

public class ReturnReceiveItemInputDto
{
    public Guid ReturnShipmentItemId { get; set; }

    public ReturnItemCondition Condition { get; set; } = ReturnItemCondition.Unknown;

    /// <summary>Serial numbers that physically came back; must belong to the returned order line.</summary>
    public List<string> SerialNumbers { get; set; } = new();
}
