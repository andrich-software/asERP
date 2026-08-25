using System.ComponentModel;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Categories.Models;

/// <summary>One checkbox column on the category matrix — a sales channel of a shop-like type.</summary>
public partial record CategoryChannelColumn(Guid SalesChannelId, string Name, SalesChannelType Type);

/// <summary>
/// One row of the category matrix. Static per data load — only the cells mutate.
/// All mutable members must be touched on the UI thread only.
/// </summary>
public sealed class CategoryRow
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;

    /// <summary>Tree depth (0 = root) — drives the name indentation.</summary>
    public int Level { get; init; }

    public int ProductCount { get; init; }

    public IReadOnlyList<CategoryChannelCell> Cells { get; init; } = [];

    public Thickness NameIndent => new(Level * 20, 0, 0, 0);
}

/// <summary>
/// One checkbox cell (category × channel). <see cref="ServerIsActive"/> is the state as loaded
/// from the server; <see cref="IsActive"/> is the user's (possibly edited) choice.
/// </summary>
public sealed class CategoryChannelCell : INotifyPropertyChanged
{
    private bool _isActive;

    public Guid CategoryId { get; init; }
    public Guid SalesChannelId { get; init; }
    public bool ServerIsActive { get; set; }

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}

/// <summary>
/// Delta bookkeeping for the matrix: only cells that differ from the server's stored state stay
/// in the pending dictionary, so the batch payload contains genuine changes only.
/// </summary>
internal static class CategoryChannelDelta
{
    public static void Apply(Dictionary<(Guid CategoryId, Guid SalesChannelId), bool> pending, CategoryChannelCell cell)
    {
        var key = (cell.CategoryId, cell.SalesChannelId);
        if (cell.IsActive == cell.ServerIsActive)
        {
            pending.Remove(key);
        }
        else
        {
            pending[key] = cell.IsActive;
        }
    }
}
