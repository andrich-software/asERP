using asERP.Domain.Dtos.Category;

namespace asERP.Domain.Services;

/// <summary>
/// Pure helper enforcing tree-consistent channel activation: a category can only be active on a
/// channel when all its ancestors are, so activating a node pulls its ancestors in and
/// deactivating a node pushes its descendants out. Shared by the client (checkbox matrix) and the
/// server-side batch handler (defense in depth against stale/foreign clients).
/// </summary>
public static class CategoryActivationRules
{
    /// <summary>
    /// Expands the requested changes with their implied ancestor/descendant changes. Changes are
    /// processed in order with last-write-wins per (category, channel) cell; implied ancestor
    /// activations come before the triggering cell so exports see parents first.
    /// </summary>
    public static List<CategoryChannelActivationChange> Expand(
        IReadOnlyList<CategoryChannelActivationChange> changes,
        IReadOnlyDictionary<Guid, Guid?> parentByCategoryId)
    {
        var childrenByParent = parentByCategoryId
            .Where(kv => kv.Value.HasValue)
            .GroupBy(kv => kv.Value!.Value)
            .ToDictionary(g => g.Key, g => g.Select(kv => kv.Key).ToList());

        var order = new List<(Guid CategoryId, Guid SalesChannelId)>();
        var state = new Dictionary<(Guid, Guid), bool>();

        void Set(Guid categoryId, Guid channelId, bool isActive)
        {
            var key = (categoryId, channelId);
            if (!state.ContainsKey(key))
            {
                order.Add(key);
            }

            state[key] = isActive;
        }

        foreach (var change in changes)
        {
            if (change.IsActive)
            {
                // Ancestors first (root-most first), then the cell itself. Visited guard breaks cycles.
                var chain = new List<Guid>();
                var visited = new HashSet<Guid> { change.CategoryId };
                var current = parentByCategoryId.GetValueOrDefault(change.CategoryId);
                while (current.HasValue && visited.Add(current.Value))
                {
                    chain.Add(current.Value);
                    current = parentByCategoryId.GetValueOrDefault(current.Value);
                }

                chain.Reverse();
                foreach (var ancestorId in chain)
                {
                    Set(ancestorId, change.SalesChannelId, true);
                }

                Set(change.CategoryId, change.SalesChannelId, true);
            }
            else
            {
                // The cell itself, then every descendant (breadth-first, cycle-guarded).
                Set(change.CategoryId, change.SalesChannelId, false);

                var visited = new HashSet<Guid> { change.CategoryId };
                var queue = new Queue<Guid>();
                queue.Enqueue(change.CategoryId);
                while (queue.Count > 0)
                {
                    var parentId = queue.Dequeue();
                    if (!childrenByParent.TryGetValue(parentId, out var children))
                    {
                        continue;
                    }

                    foreach (var childId in children.Where(visited.Add))
                    {
                        Set(childId, change.SalesChannelId, false);
                        queue.Enqueue(childId);
                    }
                }
            }
        }

        return order
            .Select(key => new CategoryChannelActivationChange
            {
                CategoryId = key.CategoryId,
                SalesChannelId = key.SalesChannelId,
                IsActive = state[key]
            })
            .ToList();
    }
}
