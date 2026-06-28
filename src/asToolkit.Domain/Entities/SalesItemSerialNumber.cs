using asToolkit.Domain.Entities.Common;

namespace asToolkit.Domain.Entities;

public class SalesItemSerialNumber : BaseEntity, IBaseEntity
{
    public Guid SalesItemId { get; set; }
    public string SerialNumber { get; set; } = string.Empty;
}