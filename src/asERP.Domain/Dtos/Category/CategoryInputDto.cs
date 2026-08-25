using System.ComponentModel.DataAnnotations;
using asERP.Domain.Interfaces;

namespace asERP.Domain.Dtos.Category;

public class CategoryInputDto : ICategoryInputModel
{
    public Guid Id { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    /// <summary>Left empty, the server generates a slug from <see cref="Name"/>.</summary>
    [StringLength(255)]
    public string Slug { get; set; } = string.Empty;

    [StringLength(4000)]
    public string? Description { get; set; }

    public Guid? ParentCategoryId { get; set; }

    public int SortOrder { get; set; }
}
