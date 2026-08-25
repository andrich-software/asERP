using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>Assignment of a <see cref="Product"/> to a <see cref="Category"/> (many-to-many join).</summary>
public class ProductCategory : BaseEntity, IBaseEntity
{
    // Navigations must NOT be auto-initialized to new() — same phantom-insert trap as documented
    // on ProductSalesChannel. Leave them unset; EF binds via the FK scalars below.
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
