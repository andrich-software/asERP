using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

public class TaxClass : BaseEntity, IBaseEntity
{
    public double TaxRate { get; set; }
    public List<Product>? Products { get; set; }
}