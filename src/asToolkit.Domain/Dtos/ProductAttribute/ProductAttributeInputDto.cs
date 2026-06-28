using System.ComponentModel.DataAnnotations;
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Dtos.ProductAttribute;

public class ProductAttributeInputDto : IProductAttributeInputModel
{
    public Guid Id { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public List<ProductAttributeValueInputDto> Values { get; set; } = new();
}
