using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Helpers;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Categories.Services;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Services;

namespace asERP.Client.Features.Categories.Models;

/// <summary>
/// Navigation data for CategoryEditModel. A null id means "create".
/// </summary>
public record CategoryEditData(Guid? CategoryId = null);

/// <summary>A parent-category option for the ComboBox — the display name carries the tree indentation.</summary>
public partial record CategoryParentOption(Guid? Id, string Display);

/// <summary>
/// Model for the category edit/create page: name, slug (server-generated when left empty),
/// description, parent (flattened tree, excluding the category's own subtree) and sort order.
/// </summary>
public class CategoryEditModel : AsyncInitializableModel
{
    private readonly ICategoryService _categoryService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly INotificationService _notifications;
    private readonly Guid? _categoryId;

    private string _name = string.Empty;
    private string _slug = string.Empty;
    private string _description = string.Empty;
    private int _sortOrder;
    private List<CategoryParentOption> _parentOptions = new();
    private CategoryParentOption? _selectedParent;

    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public CategoryEditModel(
        ICategoryService categoryService,
        INavigator navigator,
        IStringLocalizer localizer,
        INotificationService notifications,
        ILogger<CategoryEditModel> logger,
        CategoryEditData? data = null)
        : base(logger)
    {
        _categoryService = categoryService;
        _navigator = navigator;
        _localizer = localizer;
        _notifications = notifications;
        _categoryId = data?.CategoryId;

        StartInitialization();
    }

    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        var allCategories = await _categoryService.GetCategoriesAsync(ct);

        // Parent choices: the flattened tree minus the category itself and its whole subtree
        // (re-parenting into the own subtree would create a cycle — the server rejects it too).
        var excluded = _categoryId.HasValue
            ? CollectSubtreeIds(allCategories, _categoryId.Value)
            : new HashSet<Guid>();

        var options = new List<CategoryParentOption>
        {
            new(null, _localizer["CategoryEditPage.NoParent"])
        };
        foreach (var node in CategoryTreeBuilder.Flatten(allCategories).Where(n => !excluded.Contains(n.Category.Id)))
        {
            options.Add(new CategoryParentOption(
                node.Category.Id,
                $"{new string(' ', node.Level * 4)}{node.Category.Name}"));
        }
        ParentOptions = options;
        SelectedParent = options[0];

        if (_categoryId.HasValue)
        {
            var category = await _categoryService.GetCategoryAsync(_categoryId.Value, ct)
                ?? throw new InvalidOperationException($"Category {_categoryId} not found");

            Name = category.Name;
            Slug = category.Slug;
            Description = category.Description ?? string.Empty;
            SortOrder = category.SortOrder;
            SelectedParent = options.FirstOrDefault(o => o.Id == category.ParentCategoryId) ?? options[0];
        }
    }

    private static HashSet<Guid> CollectSubtreeIds(List<CategoryListDto> categories, Guid rootId)
    {
        var childrenByParent = categories
            .Where(c => c.ParentCategoryId.HasValue)
            .GroupBy(c => c.ParentCategoryId!.Value)
            .ToDictionary(g => g.Key, g => g.Select(c => c.Id).ToList());

        var result = new HashSet<Guid> { rootId };
        var queue = new Queue<Guid>();
        queue.Enqueue(rootId);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (!childrenByParent.TryGetValue(current, out var children))
            {
                continue;
            }

            foreach (var child in children.Where(result.Add))
            {
                queue.Enqueue(child);
            }
        }
        return result;
    }

    public bool IsEditMode => _categoryId.HasValue;

    public string Title => IsEditMode
        ? _localizer["CategoryEditPage.TitleEdit"]
        : _localizer["CategoryEditPage.TitleNew"];

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Slug
    {
        get => _slug;
        set => SetProperty(ref _slug, value);
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public int SortOrder
    {
        get => _sortOrder;
        set => SetProperty(ref _sortOrder, value);
    }

    public List<CategoryParentOption> ParentOptions
    {
        get => _parentOptions;
        private set => SetProperty(ref _parentOptions, value);
    }

    public CategoryParentOption? SelectedParent
    {
        get => _selectedParent;
        set => SetProperty(ref _selectedParent, value);
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

    public bool CanSave => !IsLoading && !string.IsNullOrWhiteSpace(Name);

    public async Task SaveAsync(CancellationToken ct = default)
    {
        if (!CanSave)
        {
            return;
        }

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            var input = new CategoryInputDto
            {
                Id = _categoryId ?? Guid.Empty,
                Name = Name.Trim(),
                Slug = Slug.Trim(),
                Description = string.IsNullOrWhiteSpace(Description) ? null : Description.Trim(),
                ParentCategoryId = SelectedParent?.Id,
                SortOrder = SortOrder
            };

            var isNew = !_categoryId.HasValue;
            if (_categoryId.HasValue)
            {
                await _categoryService.UpdateCategoryAsync(_categoryId.Value, input, ct);
            }
            else
            {
                await _categoryService.CreateCategoryAsync(input, ct);
            }

            _notifications.Show(
                string.Format(_localizer[isNew ? "CategoryEditPage.ToastCreated" : "CategoryEditPage.ToastUpdated"], Name),
                NotificationSeverity.Success);

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["CategoryEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task DeleteAsync(XamlRoot xamlRoot)
    {
        if (!_categoryId.HasValue)
        {
            return;
        }

        var confirmed = await ConfirmDialog.ShowAsync(
            xamlRoot,
            "CategoryEditPage.DeleteConfirmTitle",
            "CategoryEditPage.DeleteConfirmMessage");
        if (!confirmed)
        {
            return;
        }

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            await _categoryService.DeleteCategoryAsync(_categoryId.Value);

            _notifications.Show(
                string.Format(_localizer["CategoryEditPage.ToastDeleted"], Name),
                NotificationSeverity.Success);

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["CategoryEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    public async Task CancelAsync()
    {
        await _navigator.NavigateBackAsync(this);
    }

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName is nameof(Name))
        {
            base.OnPropertyChanged(nameof(CanSave));
        }

        if (propertyName is nameof(IsInitializing))
        {
            base.OnPropertyChanged(nameof(IsLoading));
            base.OnPropertyChanged(nameof(IsNotLoading));
            base.OnPropertyChanged(nameof(CanSave));
        }
    }
}
