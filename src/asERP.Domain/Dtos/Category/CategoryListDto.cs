namespace asERP.Domain.Dtos.Category;

public class CategoryListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public Guid? ParentCategoryId { get; set; }
    public int SortOrder { get; set; }
    public int ProductCount { get; set; }

    /// <summary>Per-channel activation state; channels without a row are simply absent (inactive).</summary>
    public List<CategoryChannelStateDto> Channels { get; set; } = new();
}

public class CategoryChannelStateDto
{
    public Guid SalesChannelId { get; set; }
    public bool IsActive { get; set; }
}
