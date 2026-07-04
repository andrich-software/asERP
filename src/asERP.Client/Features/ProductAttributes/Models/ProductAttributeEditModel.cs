using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using asERP.Client.Core.Abstractions;
using asERP.Client.Core.Exceptions;
using asERP.Client.Features.ProductAttributes.Services;
using asERP.Domain.Dtos.ProductAttribute;
using Microsoft.Extensions.Logging;

namespace asERP.Client.Features.ProductAttributes.Models;

/// <summary>
/// Model for product attribute edit/create page.
/// Inherits from AsyncInitializableModel for safe async initialization.
/// Manages an editable collection of attribute value rows that maps to the input DTO on save.
/// </summary>
public class ProductAttributeEditModel : AsyncInitializableModel
{
    private readonly IProductAttributeService _productAttributeService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly Guid? _productAttributeId;

    // Product Attribute Data
    private string _name = string.Empty;
    private int _sortOrder;

    // UI State
    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public ProductAttributeEditModel(
        IProductAttributeService productAttributeService,
        INavigator navigator,
        IStringLocalizer localizer,
        ILogger<ProductAttributeEditModel> logger,
        ProductAttributeEditData? data = null)
        : base(logger)
    {
        _productAttributeService = productAttributeService;
        _navigator = navigator;
        _localizer = localizer;
        _productAttributeId = data?.ProductAttributeId;

        // Start async initialization with proper error handling
        StartInitialization();
    }

    /// <inheritdoc />
    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        if (_productAttributeId.HasValue)
        {
            await LoadProductAttributeAsync(ct);
        }
    }

    public bool IsEditMode => _productAttributeId.HasValue;

    public string Title => IsEditMode
        ? _localizer["ProductAttributeEditPage.TitleEdit"]
        : _localizer["ProductAttributeEditPage.TitleNew"];

    #region Product Attribute Data

    public string Name
    {
        get => _name;
        set
        {
            if (SetProperty(ref _name, value))
            {
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    public int SortOrder
    {
        get => _sortOrder;
        set => SetProperty(ref _sortOrder, value);
    }

    /// <summary>
    /// Editable rows for the attribute values.
    /// Existing values keep their server-side Id so updates preserve them;
    /// rows without an Id are created server-side, removed rows are deleted.
    /// </summary>
    public ObservableCollection<ProductAttributeValueRow> Values { get; } = new();

    /// <summary>
    /// Adds a new empty value row.
    /// </summary>
    public void AddValue()
    {
        var nextSortOrder = Values.Count > 0 ? Values.Max(v => v.SortOrder) + 1 : 0;
        Values.Add(new ProductAttributeValueRow { SortOrder = nextSortOrder });
    }

    /// <summary>
    /// Removes the given value row.
    /// </summary>
    public void RemoveValue(ProductAttributeValueRow row)
    {
        Values.Remove(row);
    }

    #endregion

    #region UI State

    /// <summary>
    /// Indicates whether a save operation is in progress.
    /// </summary>
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

    /// <summary>
    /// Combined loading state (initializing or saving).
    /// </summary>
    public bool IsLoading => IsInitializing || IsSaving;

    /// <summary>
    /// Inverse of IsLoading for binding convenience.
    /// </summary>
    public bool IsNotLoading => !IsLoading;

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool CanSave => !string.IsNullOrWhiteSpace(Name) && !IsLoading;

    #endregion

    private async Task LoadProductAttributeAsync(CancellationToken ct)
    {
        if (!_productAttributeId.HasValue) return;

        var productAttribute = await _productAttributeService.GetProductAttributeAsync(_productAttributeId.Value, ct);
        if (productAttribute != null)
        {
            Name = productAttribute.Name;
            SortOrder = productAttribute.SortOrder;

            Values.Clear();
            foreach (var value in productAttribute.Values.OrderBy(v => v.SortOrder))
            {
                Values.Add(new ProductAttributeValueRow
                {
                    Id = value.Id,
                    Value = value.Value,
                    SortOrder = value.SortOrder
                });
            }
        }
    }

    public async Task SaveAsync(CancellationToken ct = default)
    {
        if (!CanSave) return;

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            var input = new ProductAttributeInputDto
            {
                Name = Name,
                SortOrder = SortOrder,
                Values = Values
                    .Where(v => !string.IsNullOrWhiteSpace(v.Value))
                    .Select(v => new ProductAttributeValueInputDto
                    {
                        Id = v.Id,
                        Value = v.Value,
                        SortOrder = v.SortOrder
                    })
                    .ToList()
            };

            if (_productAttributeId.HasValue)
            {
                input.Id = _productAttributeId.Value;
                await _productAttributeService.UpdateProductAttributeAsync(_productAttributeId.Value, input, ct);
            }
            else
            {
                await _productAttributeService.CreateProductAttributeAsync(input, ct);
            }

            await _navigator.NavigateBackAsync(this);
        }
        catch (ApiException ex)
        {
            // Display detailed error messages from the API
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["ProductAttributeEditPage.SaveFailed"], ex.Message);
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

    /// <inheritdoc />
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        // Handle IsInitializing changes from base class
        if (propertyName is nameof(IsInitializing))
        {
            base.OnPropertyChanged(nameof(IsLoading));
            base.OnPropertyChanged(nameof(IsNotLoading));
            base.OnPropertyChanged(nameof(CanSave));
        }
    }
}

/// <summary>
/// Editable row for a single product attribute value.
/// Keeps the server-side Id when editing an existing value (null for new rows).
/// </summary>
public class ProductAttributeValueRow : INotifyPropertyChanged
{
    private string _value = string.Empty;
    private int _sortOrder;

    /// <summary>
    /// Server-side value Id. Null for newly added rows.
    /// </summary>
    public Guid? Id { get; set; }

    public string Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }

    public int SortOrder
    {
        get => _sortOrder;
        set
        {
            if (_sortOrder != value)
            {
                _sortOrder = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
