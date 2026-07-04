using System.ComponentModel.DataAnnotations;
using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

public class ProductStock : BaseEntity, IBaseEntity
{
    [Required]
    public Guid ProductId { get; set; }
    public Guid WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = null!;
    public double Stock { get; set; }
    public double StockMin { get; set; }
    public double StockMax { get; set; }
    public double StorageLocation { get; set; }
}