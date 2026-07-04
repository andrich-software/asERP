using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

public class SalesItem : BaseEntity, IBaseEntity
{
    public Guid SalesId { get; set; }
    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double TaxRate { get; set; }
    public string MissingProductSku { get; set; } = string.Empty;
    public string MissingProductEan { get; set; } = string.Empty;
    /// <summary>The parcel this line was packed into — enables partial shipments. Null while unassigned.</summary>
    public Guid? ShippingId { get; set; }
    public ICollection<SalesItemSerialNumber> SerialNumbers { get; set; } = new List<SalesItemSerialNumber>();
}
