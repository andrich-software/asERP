using asERP.Domain.Dtos.Category;

namespace asERP.Domain.Services;

/// <summary>A category with its depth in the tree, in display order (parents before children).</summary>
public sealed class CategoryTreeNode
{
    public CategoryTreeNode(CategoryListDto category, int level)
    {
        Category = category;
        Level = level;
    }

    public CategoryListDto Category { get; }

    /// <summary>0 for roots; used for indentation in flat tree views.</summary>
    public int Level { get; }
}

/// <summary>
/// Pure helper that turns the flat category list into a depth-first display order (siblings sorted
/// by SortOrder, then Name). Shared by the client tree views and any server-side rendering.
/// </summary>
public static class CategoryTreeBuilder
{
    /// <summary>
    /// Flattens the categories into display order. Orphans (parent id pointing at a missing
    /// category) are treated as roots; cycles are broken by the visited guard so malformed data
    /// can never hang the UI.
    /// </summary>
    public static List<CategoryTreeNode> Flatten(IEnumerable<CategoryListDto> categories)
    {
        var all = categories.ToList();
        var byId = all.ToDictionary(c => c.Id);

        List<CategoryListDto> ChildrenOf(Guid? parentId) => all
            .Where(c => parentId is null
                ? c.ParentCategoryId is null || !byId.ContainsKey(c.ParentCategoryId.Value)
                : c.ParentCategoryId == parentId)
            .OrderBy(c => c.SortOrder)
            .ThenBy(c => c.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var result = new List<CategoryTreeNode>(all.Count);
        var visited = new HashSet<Guid>();

        void Visit(CategoryListDto node, int level)
        {
            if (!visited.Add(node.Id))
            {
                return;
            }

            result.Add(new CategoryTreeNode(node, level));
            foreach (var child in ChildrenOf(node.Id))
            {
                Visit(child, level + 1);
            }
        }

        foreach (var root in ChildrenOf(null))
        {
            Visit(root, 0);
        }

        // Nodes only reachable through a cycle have no root path; append them flat so no data is hidden.
        foreach (var leftover in all.Where(c => !visited.Contains(c.Id)))
        {
            Visit(leftover, 0);
        }

        return result;
    }

    /// <summary>
    /// Filters a flattened tree down to the nodes matching <paramref name="searchString"/> plus
    /// their ancestor chains, so every match stays visible with its path. Empty search returns the
    /// input unchanged.
    /// </summary>
    public static List<CategoryTreeNode> Filter(List<CategoryTreeNode> flattened, string? searchString)
    {
        if (string.IsNullOrWhiteSpace(searchString))
        {
            return flattened;
        }

        var byId = flattened.ToDictionary(n => n.Category.Id, n => n.Category);
        var keep = new HashSet<Guid>();

        foreach (var node in flattened)
        {
            if (!node.Category.Name.Contains(searchString.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var current = node.Category;
            while (keep.Add(current.Id))
            {
                if (current.ParentCategoryId is null || !byId.TryGetValue(current.ParentCategoryId.Value, out var parent))
                {
                    break;
                }

                current = parent;
            }
        }

        return flattened.Where(n => keep.Contains(n.Category.Id)).ToList();
    }
}
