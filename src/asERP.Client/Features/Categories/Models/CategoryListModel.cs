using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Models;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Categories.Services;
using asERP.Client.Features.SalesChannels.Services;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Services;

namespace asERP.Client.Features.Categories.Models;

/// <summary>
/// Model for the category matrix page: the full category tree as a flat, indented list with one
/// checkbox column per shop-like sales channel. Checkbox changes are delta-tracked (only genuine
/// diffs from the server state) and saved as one batch; toggling a cell cascades along the tree
/// (activate → ancestors, deactivate → descendants) via <see cref="CategoryActivationRules"/>.
/// </summary>
public class CategoryListModel : AsyncInitializableModel
{
    private readonly ICategoryService _categoryService;
    private readonly ISalesChannelService _salesChannelService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly INotificationService _notifications;

    // Pending activation changes that differ from the server's stored state, keyed by cell.
    // Survives search filtering so pending edits are never lost while narrowing the list.
    private readonly Dictionary<(Guid CategoryId, Guid SalesChannelId), bool> _pendingChanges = new();

    private List<CategoryListDto> _allCategories = new();
    private Dictionary<Guid, Guid?> _parentByCategoryId = new();
    private List<CategoryRow> _allRows = new();
    private Dictionary<(Guid CategoryId, Guid SalesChannelId), CategoryChannelCell> _cellByKey = new();
    private bool _suppressCellCascade;

    private ObservableCollection<CategoryChannelColumn> _channelColumns = new();
    private ObservableCollection<CategoryRow> _rows = new();
    private string _searchText = string.Empty;
    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public CategoryListModel(
        ICategoryService categoryService,
        ISalesChannelService salesChannelService,
        INavigator navigator,
        IStringLocalizer localizer,
        INotificationService notifications,
        ILogger<CategoryListModel> logger)
        : base(logger)
    {
        _categoryService = categoryService;
        _salesChannelService = salesChannelService;
        _navigator = navigator;
        _localizer = localizer;
        _notifications = notifications;

        StartInitialization();
    }

    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        await LoadChannelColumnsAsync(ct);
        await LoadCategoriesAsync(ct);
    }

    public ObservableCollection<CategoryChannelColumn> ChannelColumns
    {
        get => _channelColumns;
        private set
        {
            if (SetProperty(ref _channelColumns, value))
            {
                OnPropertyChanged(nameof(ChannelsWidth));
            }
        }
    }

    /// <summary>
    /// Total width of the header's checkbox area, mirroring <see cref="CategoryRow.CellsWidth"/> so
    /// the column captions always sit above the checkboxes they label.
    /// </summary>
    public double ChannelsWidth => ChannelColumns.Count * CategoryChannelColumns.ColumnWidth;

    public ObservableCollection<CategoryRow> Rows
    {
        get => _rows;
        private set
        {
            if (SetProperty(ref _rows, value))
            {
                OnPropertyChanged(nameof(HasCategories));
            }
        }
    }

    public bool HasCategories => Rows.Count > 0;

    /// <summary>
    /// The "no categories yet" placeholder belongs on screen only once loading finished without
    /// data - not while the spinner runs and not on top of an error banner.
    /// </summary>
    public bool ShowEmptyState => !HasCategories && !IsLoading && string.IsNullOrEmpty(ErrorMessage);

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                ApplyFilter();
            }
        }
    }

    public bool IsSaving
    {
        get => _isSaving;
        private set
        {
            if (SetProperty(ref _isSaving, value))
            {
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsNotLoading));
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    public bool IsLoading => IsInitializing || IsSaving;
    public bool IsNotLoading => !IsLoading;

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool HasPendingChanges => _pendingChanges.Count > 0;

    public bool CanSave => HasPendingChanges && !IsLoading;

    public async Task RefreshAsync()
    {
        ErrorMessage = string.Empty;
        try
        {
            await LoadCategoriesAsync(CancellationToken.None);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    public async Task SaveAsync()
    {
        if (!CanSave)
        {
            return;
        }

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            var update = new CategoryChannelActivationUpdateDto
            {
                Changes = _pendingChanges
                    .Select(kv => new CategoryChannelActivationChange
                    {
                        CategoryId = kv.Key.CategoryId,
                        SalesChannelId = kv.Key.SalesChannelId,
                        IsActive = kv.Value
                    })
                    .ToList()
            };

            await _categoryService.UpdateChannelActivationsAsync(update);
            _pendingChanges.Clear();

            // Reload so the rows reflect the server's authoritative state (it re-applies the
            // tree-consistency rule and may have expanded further).
            await LoadCategoriesAsync(CancellationToken.None);

            _notifications.Show(_localizer["CategoryListPage.ToastSaved"], NotificationSeverity.Success);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["CategoryListPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
            NotifyPendingChanged();
        }
    }

    /// <summary>Reverts every pending checkbox back to the server's stored state.</summary>
    public void DiscardChanges()
    {
        _suppressCellCascade = true;
        try
        {
            foreach (var key in _pendingChanges.Keys.ToList())
            {
                if (_cellByKey.TryGetValue(key, out var cell))
                {
                    cell.IsActive = cell.ServerIsActive;
                }
            }
        }
        finally
        {
            _suppressCellCascade = false;
        }

        _pendingChanges.Clear();
        NotifyPendingChanged();
    }

    public async Task CreateCategoryAsync()
    {
        await _navigator.NavigateViewModelAsync<CategoryEditModel>(this, data: new CategoryEditData());
    }

    public async Task EditCategoryAsync(CategoryRow row)
    {
        await _navigator.NavigateViewModelAsync<CategoryEditModel>(this, data: new CategoryEditData(row.Id));
    }

    private async Task LoadChannelColumnsAsync(CancellationToken ct)
    {
        var response = await _salesChannelService.GetSalesChannelsAsync(
            new QueryParameters { PageSize = 200 }, ct);

        var columns = response.Data
            .Where(c => CategoryChannelColumns.HasColumn(c.SalesChannelType))
            .OrderBy(c => c.Name, StringComparer.OrdinalIgnoreCase)
            .Select(c => new CategoryChannelColumn(c.Id, c.Name, c.SalesChannelType)
            {
                Hint = string.Format(_localizer["CategoryListPage.ChannelHint"], c.Name)
            })
            .ToList();

        ChannelColumns = new ObservableCollection<CategoryChannelColumn>(columns);
    }

    private async Task LoadCategoriesAsync(CancellationToken ct)
    {
        _allCategories = await _categoryService.GetCategoriesAsync(ct);
        _parentByCategoryId = _allCategories.ToDictionary(c => c.Id, c => c.ParentCategoryId);
        RebuildRows();
    }

    /// <summary>Builds the full (unfiltered) row set from the loaded data, re-applying pending edits.</summary>
    private void RebuildRows()
    {
        foreach (var cell in _cellByKey.Values)
        {
            cell.PropertyChanged -= OnCellChanged;
        }

        var flattened = CategoryTreeBuilder.Flatten(_allCategories);
        var rows = new List<CategoryRow>(flattened.Count);
        var cellByKey = new Dictionary<(Guid, Guid), CategoryChannelCell>();

        _suppressCellCascade = true;
        try
        {
            foreach (var node in flattened)
            {
                var serverStates = node.Category.Channels.ToDictionary(c => c.SalesChannelId, c => c.IsActive);
                var cells = new List<CategoryChannelCell>(ChannelColumns.Count);

                foreach (var column in ChannelColumns)
                {
                    var serverIsActive = serverStates.GetValueOrDefault(column.SalesChannelId);
                    var cell = new CategoryChannelCell
                    {
                        CategoryId = node.Category.Id,
                        SalesChannelId = column.SalesChannelId,
                        ServerIsActive = serverIsActive,
                        ActivationHint = string.Format(_localizer["CategoryListPage.ChannelHint"], column.Name),
                        IsActive = _pendingChanges.TryGetValue((node.Category.Id, column.SalesChannelId), out var pending)
                            ? pending
                            : serverIsActive
                    };
                    cell.PropertyChanged += OnCellChanged;
                    cells.Add(cell);
                    cellByKey[(node.Category.Id, column.SalesChannelId)] = cell;
                }

                rows.Add(new CategoryRow
                {
                    Id = node.Category.Id,
                    Name = DisplayName(node),
                    Level = node.Level,
                    ProductCount = node.Category.ProductCount,
                    Cells = cells
                });
            }
        }
        finally
        {
            _suppressCellCascade = false;
        }

        _allRows = rows;
        _cellByKey = cellByKey;

        // Pending entries for cells that vanished server-side (deleted category/channel) are stale.
        foreach (var key in _pendingChanges.Keys.Where(k => !cellByKey.ContainsKey(k)).ToList())
        {
            _pendingChanges.Remove(key);
        }

        ApplyFilter();
        NotifyPendingChanged();
    }

    /// <summary>Applies the search filter (matches + their ancestor chains) to the master row list.</summary>
    private void ApplyFilter()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
        {
            Rows = new ObservableCollection<CategoryRow>(_allRows);
            return;
        }

        var flattened = CategoryTreeBuilder.Flatten(_allCategories);
        var visibleIds = CategoryTreeBuilder.Filter(flattened, SearchText)
            .Select(n => n.Category.Id)
            .ToHashSet();

        Rows = new ObservableCollection<CategoryRow>(_allRows.Where(r => visibleIds.Contains(r.Id)));
    }

    private void OnCellChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (_suppressCellCascade
            || sender is not CategoryChannelCell cell
            || e.PropertyName != nameof(CategoryChannelCell.IsActive))
        {
            return;
        }

        // Cascade along the tree: the rules expand the single toggle into the implied
        // ancestor/descendant changes; apply them to the master cell set (not just visible rows).
        var expanded = CategoryActivationRules.Expand(
            new[]
            {
                new CategoryChannelActivationChange
                {
                    CategoryId = cell.CategoryId,
                    SalesChannelId = cell.SalesChannelId,
                    IsActive = cell.IsActive
                }
            },
            _parentByCategoryId);

        _suppressCellCascade = true;
        try
        {
            foreach (var change in expanded)
            {
                if (_cellByKey.TryGetValue((change.CategoryId, change.SalesChannelId), out var target))
                {
                    target.IsActive = change.IsActive;
                    CategoryChannelDelta.Apply(_pendingChanges, target);
                }
            }
        }
        finally
        {
            _suppressCellCascade = false;
        }

        NotifyPendingChanged();
    }

    private void NotifyPendingChanged()
    {
        OnPropertyChanged(nameof(HasPendingChanges));
        OnPropertyChanged(nameof(CanSave));
    }

    /// <summary>
    /// Falls back to a placeholder for categories the shop imported without a name, so the row is
    /// never an unclickable-looking blank line.
    /// </summary>
    private string DisplayName(CategoryTreeNode node)
    {
        if (!string.IsNullOrWhiteSpace(node.Category.Name))
        {
            return node.Category.Name;
        }

        return _localizer[node.Level == 0 ? "CategoryListPage.RootCategory" : "CategoryListPage.UnnamedCategory"];
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        // Initialization/refresh continuations resume on a background thread, and classic {Binding}
        // updates raised from there are dropped on Desktop/Skia - that is what left the empty state
        // and the channel column headers stuck on their initial (empty) values.
        RunOnUi(() =>
        {
            RaisePropertyChanged(propertyName);

            if (propertyName is nameof(IsInitializing))
            {
                RaisePropertyChanged(nameof(IsLoading));
                RaisePropertyChanged(nameof(IsNotLoading));
                RaisePropertyChanged(nameof(CanSave));
            }

            if (propertyName is nameof(HasCategories) or nameof(IsInitializing)
                or nameof(IsSaving) or nameof(ErrorMessage))
            {
                RaisePropertyChanged(nameof(ShowEmptyState));
            }
        });
    }

    // base.OnPropertyChanged cannot be called from inside a lambda, hence the trampoline.
    private void RaisePropertyChanged(string? propertyName) => base.OnPropertyChanged(propertyName);

    /// <summary>
    /// Runs a UI-affecting action on the UI thread, inline when already there so property changes
    /// raised from user input stay synchronous (two-way checkbox bindings depend on that).
    /// </summary>
    private static void RunOnUi(Action action)
    {
        var dispatcher = App.UiDispatcher;
        if (dispatcher is null || dispatcher.HasThreadAccess)
        {
            action();
        }
        else
        {
            dispatcher.TryEnqueue(() => action());
        }
    }
}
