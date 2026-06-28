using System.ComponentModel.DataAnnotations;

namespace asToolkit.Domain.Dtos.ProductAttribute;

public class ProductAttributeValueInputDto
{
    /// <summary>Null for new values; set for updating an existing value.</summary>
    public Guid? Id { get; set; }

    [StringLength(255)]
    public string Value { get; set; } = string.Empty;

    public int SortOrder { get; set; }
}
