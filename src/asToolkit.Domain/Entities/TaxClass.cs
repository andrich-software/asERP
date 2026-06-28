using asToolkit.Domain.Entities.Common;

namespace asToolkit.Domain.Entities;

public class TaxClass : BaseEntity, IBaseEntity
{
    public double TaxRate { get; set; }
    public List<Product>? Products { get; set; }
}