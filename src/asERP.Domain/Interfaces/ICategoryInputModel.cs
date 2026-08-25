namespace asERP.Domain.Interfaces;

public interface ICategoryInputModel
{
    string Name { get; }
    string Slug { get; }
    string? Description { get; }
    Guid? ParentCategoryId { get; }
    int SortOrder { get; }
}
