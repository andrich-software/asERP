namespace asERP.Domain.Dtos.Category;

public class CategoryDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public int SortOrder { get; set; }
    public int ProductCount { get; set; }
    public List<CategoryChannelStateDto> Channels { get; set; } = new();
}
