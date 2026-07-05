using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>Serial number that physically came back with a return item.</summary>
public class ReturnShipmentItemSerialNumber : BaseEntity, IBaseEntity
{
    public Guid ReturnShipmentItemId { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
}
