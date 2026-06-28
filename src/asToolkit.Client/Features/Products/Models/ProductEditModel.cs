using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using asToolkit.Client.Core.Abstractions;
using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Core.Models;
using asToolkit.Client.Features.Manufacturers.Services;
using asToolkit.Client.Features.ProductAttributes.Services;
using asToolkit.Client.Features.Products.Services;
using asToolkit.Client.Features.TaxClasses.Services;
using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Dtos.TaxClass;
using asToolkit.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace asToolkit.Client.Features.Products.Models;

/// <summary>
/// Model for product edit/create page.
/// Inherits from AsyncInitializableModel for safe async initialization.
/// </summary>
public class ProductEditModel : AsyncInitializableModel
{
    private readonly IProductService _productService;
    private readonly ITaxClassService _taxClassService;
    private readonly IManufacturerService _manufacturerService;
    private readonly IProductAttributeService _productAttributeService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly Guid? _productId;

    // Product Data - Basic Information
    private string _sku = string.Empty;
    private string _name = string.Empty;
    private string? _nameOptimized;
    private string? _ean;
    private string? _asin;
    private string? _description;
    private string? _descriptionOptimized;
    private bool _useOptimized;

    // Product Data - Pricing
    private decimal _price;
    private decimal _msrp;

    // Product Data - Dimensions
    private decimal _weight;
    private decimal _width;
    private decimal _height;
    private decimal _depth;

    // Product Data - Relationships
    private Guid _taxClassId;
    private Guid? _manufacturerId;

    // Dropdown Data
    private ObservableCollection<TaxClassListDto> _taxClasses = new();
    private ObservableCollection<ManufacturerListDto> _manufacturers = new();

    // Variation data
    private ProductType _productType = ProductType.Standard;
    private Guid? _parentProductId;
    private string _parentName = string.Empty;
    private bool _isGenerating;
    private ObservableCollection<ProductAttributeListDto> _availableAttributes = new();
    private ObservableCollection<ProductAxisRow> _axes = new();
    private ObservableCollection<ProductVariantRow> _variants = new();

    // Images
    private ObservableCollection<ProductImageRow> _images = new();
    private bool _isImageBusy;

    // UI State
    private bool _isSaving;
    private string _errorMessage = string.Empty;

    public ProductEditModel(
        IProductService productService,
        ITaxClassService taxClassService,
        IManufacturerService manufacturerService,
        IProductAttributeService productAttributeService,
        INavigator navigator,
        IStringLocalizer localizer,
        ILogger<ProductEditModel> logger,
        ProductEditData? data = null)
        : base(logger)
    {
        _productService = productService;
        _taxClassService = taxClassService;
        _manufacturerService = manufacturerService;
        _productAttributeService = productAttributeService;
        _navigator = navigator;
        _localizer = localizer;
        _productId = data?.ProductId;

        // Start async initialization with proper error handling
        StartInitialization();
    }

    /// <inheritdoc />
    protected override async Task InitializeCoreAsync(CancellationToken ct)
    {
        await Task.WhenAll(
            LoadTaxClassesAsync(ct),
            LoadManufacturersAsync(ct),
            LoadAttributesAsync(ct)
        );

        if (_productId.HasValue)
        {
            await LoadProductAsync(ct);
            await LoadImagesAsync(ct);
        }
    }

    private async Task LoadAttributesAsync(CancellationToken ct)
    {
        var parameters = new QueryParameters { PageSize = 1000 };
        var response = await _productAttributeService.GetProductAttributesAsync(parameters, ct);
        AvailableAttributes.Clear();
        foreach (var attribute in response.Data)
        {
            AvailableAttributes.Add(attribute);
        }
    }

    private async Task LoadAxisValuesAsync(ProductAxisRow row, Guid attributeId)
    {
        try
        {
            var detail = await _productAttributeService.GetProductAttributeAsync(attributeId);
            row.Values.Clear();
            if (detail == null)
            {
                return;
            }

            foreach (var value in detail.Values.OrderBy(v => v.SortOrder))
            {
                row.Values.Add(new ProductAxisValueRow
                {
                    Id = value.Id,
                    Value = value.Value,
                    SortOrder = value.SortOrder
                });
            }
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
    }

    private async Task LoadTaxClassesAsync(CancellationToken ct)
    {
        var parameters = new QueryParameters { PageSize = 1000 };
        var response = await _taxClassService.GetTaxClassesAsync(parameters, ct);
        TaxClasses.Clear();
        foreach (var taxClass in response.Data)
        {
            TaxClasses.Add(taxClass);
        }
    }

    private async Task LoadManufacturersAsync(CancellationToken ct)
    {
        var parameters = new QueryParameters { PageSize = 1000 };
        var response = await _manufacturerService.GetManufacturersAsync(parameters, ct);
        Manufacturers.Clear();
        foreach (var manufacturer in response.Data)
        {
            Manufacturers.Add(manufacturer);
        }
    }

    public bool IsEditMode => _productId.HasValue;

    public string Title => IsEditMode
        ? _localizer["ProductEditPage.TitleEdit"]
        : _localizer["ProductEditPage.TitleNew"];

    #region Product Data - Basic Information

    public string Sku
    {
        get => _sku;
        set
        {
            if (SetProperty(ref _sku, value))
            {
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

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

    public string? NameOptimized
    {
        get => _nameOptimized;
        set => SetProperty(ref _nameOptimized, value);
    }

    public string? Ean
    {
        get => _ean;
        set => SetProperty(ref _ean, value);
    }

    public string? Asin
    {
        get => _asin;
        set => SetProperty(ref _asin, value);
    }

    public string? Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    public string? DescriptionOptimized
    {
        get => _descriptionOptimized;
        set => SetProperty(ref _descriptionOptimized, value);
    }

    public bool UseOptimized
    {
        get => _useOptimized;
        set => SetProperty(ref _useOptimized, value);
    }

    #endregion

    #region Product Data - Pricing

    public decimal Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public decimal Msrp
    {
        get => _msrp;
        set => SetProperty(ref _msrp, value);
    }

    #endregion

    #region Product Data - Dimensions

    public decimal Weight
    {
        get => _weight;
        set => SetProperty(ref _weight, value);
    }

    public decimal Width
    {
        get => _width;
        set => SetProperty(ref _width, value);
    }

    public decimal Height
    {
        get => _height;
        set => SetProperty(ref _height, value);
    }

    public decimal Depth
    {
        get => _depth;
        set => SetProperty(ref _depth, value);
    }

    #endregion

    #region Product Data - Relationships

    public Guid TaxClassId
    {
        get => _taxClassId;
        set
        {
            if (SetProperty(ref _taxClassId, value))
            {
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    public Guid? ManufacturerId
    {
        get => _manufacturerId;
        set => SetProperty(ref _manufacturerId, value);
    }

    #endregion

    #region Dropdown Data

    public ObservableCollection<TaxClassListDto> TaxClasses
    {
        get => _taxClasses;
        set => SetProperty(ref _taxClasses, value);
    }

    public ObservableCollection<ManufacturerListDto> Manufacturers
    {
        get => _manufacturers;
        set => SetProperty(ref _manufacturers, value);
    }

    #endregion

    #region Variation Data

    /// <summary>
    /// The product type (Standard, VariantParent or Variant).
    /// </summary>
    public ProductType ProductType
    {
        get => _productType;
        set
        {
            if (SetProperty(ref _productType, value))
            {
                OnPropertyChanged(nameof(IsVariantParent));
                OnPropertyChanged(nameof(IsVariant));
                OnPropertyChanged(nameof(IsStandard));
                OnPropertyChanged(nameof(CanGenerateVariants));
                OnPropertyChanged(nameof(CanSave));
            }
        }
    }

    /// <summary>
    /// Type selection helper bound to the type ComboBox SelectedIndex
    /// (0 = Standard, 1 = VariantParent). Hidden for existing variants.
    /// </summary>
    public int ProductTypeIndex
    {
        get => ProductType == ProductType.VariantParent ? 1 : 0;
        set => ProductType = value == 1 ? ProductType.VariantParent : ProductType.Standard;
    }

    public bool IsStandard => ProductType == ProductType.Standard;
    public bool IsVariantParent => ProductType == ProductType.VariantParent;
    public bool IsVariant => ProductType == ProductType.Variant;

    /// <summary>
    /// True when the type selector should be shown (not when editing an existing variant child).
    /// </summary>
    public bool CanEditType => !IsVariant;

    /// <summary>
    /// Display name of the parent product when this product is a variant.
    /// </summary>
    public string ParentName
    {
        get => _parentName;
        private set => SetProperty(ref _parentName, value);
    }

    public ObservableCollection<ProductAttributeListDto> AvailableAttributes
    {
        get => _availableAttributes;
        set => SetProperty(ref _availableAttributes, value);
    }

    public ObservableCollection<ProductAxisRow> Axes
    {
        get => _axes;
        set => SetProperty(ref _axes, value);
    }

    public ObservableCollection<ProductVariantRow> Variants
    {
        get => _variants;
        set => SetProperty(ref _variants, value);
    }

    public bool IsGenerating
    {
        get => _isGenerating;
        private set
        {
            if (SetProperty(ref _isGenerating, value))
            {
                OnPropertyChanged(nameof(CanGenerateVariants));
            }
        }
    }

    /// <summary>
    /// Variant generation is only possible on an already-saved parent that has
    /// at least one axis with at least one selected value.
    /// </summary>
    public bool CanGenerateVariants =>
        IsVariantParent &&
        IsEditMode &&
        !IsGenerating &&
        !IsLoading &&
        Axes.Count > 0 &&
        Axes.All(a => a.ProductAttributeId != Guid.Empty && a.Values.Any(v => v.IsSelected));

    /// <summary>
    /// Hint shown when the parent must be saved before variants can be generated.
    /// </summary>
    public bool ShowSaveFirstHint => IsVariantParent && !IsEditMode;

    public void AddAxis()
    {
        ProductAxisRow row = null!;
        row = new ProductAxisRow(
            AvailableAttributes,
            attributeId => LoadAxisValuesAsync(row, attributeId));
        Axes.Add(row);
        OnPropertyChanged(nameof(CanGenerateVariants));
    }

    public void RemoveAxis(ProductAxisRow row)
    {
        Axes.Remove(row);
        OnPropertyChanged(nameof(CanGenerateVariants));
    }

    public async Task GenerateVariantsAsync(CancellationToken ct = default)
    {
        if (!CanGenerateVariants || !_productId.HasValue)
        {
            return;
        }

        IsGenerating = true;
        ErrorMessage = string.Empty;

        try
        {
            var request = new ProductVariantGenerateDto
            {
                ParentProductId = _productId.Value,
                Axes = Axes
                    .Where(a => a.ProductAttributeId != Guid.Empty)
                    .Select(a => new ProductVariantGenerateAxisDto
                    {
                        ProductAttributeId = a.ProductAttributeId,
                        ValueIds = a.Values.Where(v => v.IsSelected).Select(v => v.Id).ToList()
                    })
                    .ToList()
            };

            await _productService.GenerateVariantsAsync(_productId.Value, request, ct);

            // Reload so the freshly generated variants appear.
            await LoadProductAsync(ct);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["ProductEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsGenerating = false;
        }
    }

    #endregion

    #region Images

    /// <summary>Images of the product, ordered (first = primary). Edit-mode only.</summary>
    public ObservableCollection<ProductImageRow> Images
    {
        get => _images;
        set => SetProperty(ref _images, value);
    }

    /// <summary>True while an image upload/delete/reorder request is in flight.</summary>
    public bool IsImageBusy
    {
        get => _isImageBusy;
        private set
        {
            if (SetProperty(ref _isImageBusy, value))
            {
                OnPropertyChanged(nameof(CanModifyImages));
            }
        }
    }

    /// <summary>Images can only be managed for an already-saved product.</summary>
    public bool CanModifyImages => IsEditMode && !IsImageBusy;

    /// <summary>Hint shown in the images card when the product must be saved first.</summary>
    public bool ShowImageSaveFirstHint => !IsEditMode;

    private async Task LoadImagesAsync(CancellationToken ct)
    {
        if (!_productId.HasValue)
        {
            return;
        }

        try
        {
            var images = await _productService.GetProductImagesAsync(_productId.Value, ct);
            Images.Clear();
            foreach (var dto in images.OrderBy(i => i.SortOrder))
            {
                var row = new ProductImageRow
                {
                    Id = dto.Id,
                    SortOrder = dto.SortOrder,
                    AltText = dto.AltText,
                    OriginalFileName = dto.OriginalFileName
                };
                Images.Add(row);
                await LoadThumbnailAsync(row, ct);
            }
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
    }

    private async Task LoadThumbnailAsync(ProductImageRow row, CancellationToken ct)
    {
        if (!_productId.HasValue)
        {
            return;
        }

        try
        {
            row.ThumbnailBytes = await _productService.GetProductImageBytesAsync(_productId.Value, row.Id, thumbnail: true, ct);
        }
        catch
        {
            // Thumbnail is non-essential; a missing preview must not break the page.
        }
    }

    /// <summary>
    /// Uploads one or more picked files (re-encoded to PNG server-side) and reloads the list.
    /// Each stream is disposed after upload.
    /// </summary>
    public async Task AddImagesAsync(IReadOnlyList<(Stream Stream, string FileName, string ContentType)> files, CancellationToken ct = default)
    {
        if (!_productId.HasValue || files.Count == 0)
        {
            return;
        }

        IsImageBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            foreach (var file in files)
            {
                await using (file.Stream)
                {
                    await _productService.UploadProductImageAsync(_productId.Value, file.Stream, file.FileName, file.ContentType, ct);
                }
            }

            await LoadImagesAsync(ct);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        catch (Exception ex)
        {
            ErrorMessage = string.Format(_localizer["ProductEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsImageBusy = false;
        }
    }

    public async Task DeleteImageAsync(ProductImageRow row, CancellationToken ct = default)
    {
        if (!_productId.HasValue)
        {
            return;
        }

        IsImageBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            await _productService.DeleteProductImageAsync(_productId.Value, row.Id, ct);
            await LoadImagesAsync(ct);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
        }
        finally
        {
            IsImageBusy = false;
        }
    }

    public Task MoveImageUpAsync(ProductImageRow row, CancellationToken ct = default)
    {
        var index = Images.IndexOf(row);
        if (index <= 0)
        {
            return Task.CompletedTask;
        }

        Images.Move(index, index - 1);
        return PersistImageOrderAsync(ct);
    }

    public Task MoveImageDownAsync(ProductImageRow row, CancellationToken ct = default)
    {
        var index = Images.IndexOf(row);
        if (index < 0 || index >= Images.Count - 1)
        {
            return Task.CompletedTask;
        }

        Images.Move(index, index + 1);
        return PersistImageOrderAsync(ct);
    }

    public Task MakeImagePrimaryAsync(ProductImageRow row, CancellationToken ct = default)
    {
        var index = Images.IndexOf(row);
        if (index <= 0)
        {
            return Task.CompletedTask;
        }

        Images.Move(index, 0);
        return PersistImageOrderAsync(ct);
    }

    private async Task PersistImageOrderAsync(CancellationToken ct)
    {
        if (!_productId.HasValue)
        {
            return;
        }

        // Reindex locally so IsPrimary and the order update immediately in the UI.
        for (var i = 0; i < Images.Count; i++)
        {
            Images[i].SortOrder = i;
        }

        IsImageBusy = true;
        ErrorMessage = string.Empty;

        try
        {
            await _productService.ReorderProductImagesAsync(_productId.Value, Images.Select(i => i.Id).ToList(), ct);
        }
        catch (ApiException ex)
        {
            ErrorMessage = ex.CombinedMessage;
            // Re-sync with the server if the reorder was rejected.
            await LoadImagesAsync(ct);
        }
        finally
        {
            IsImageBusy = false;
        }
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
                OnPropertyChanged(nameof(CanGenerateVariants));
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

    public bool CanSave =>
        !string.IsNullOrWhiteSpace(Sku) &&
        !string.IsNullOrWhiteSpace(Name) &&
        TaxClassId != Guid.Empty &&
        !IsLoading;

    #endregion

    private async Task LoadProductAsync(CancellationToken ct)
    {
        if (!_productId.HasValue) return;

        var product = await _productService.GetProductAsync(_productId.Value, ct);
        if (product != null)
        {
            // Basic Information
            Sku = product.Sku;
            Name = product.Name;
            NameOptimized = product.NameOptimized;
            Ean = product.Ean;
            Asin = product.Asin;
            Description = product.Description;
            DescriptionOptimized = product.DescriptionOptimized;
            UseOptimized = product.UseOptimized;

            // Pricing
            Price = product.Price;
            Msrp = product.Msrp;

            // Dimensions
            Weight = product.Weight;
            Width = product.Width;
            Height = product.Height;
            Depth = product.Depth;

            // Relationships
            TaxClassId = product.TaxClassId;
            ManufacturerId = product.Manufacturer?.Id;

            // Variation data
            ProductType = product.ProductType;
            _parentProductId = product.ParentProductId;

            if (product.ProductType == ProductType.Variant)
            {
                // Build a readable "Variante von …" description from the option values.
                ParentName = product.Options.Count > 0
                    ? string.Join(" / ", product.Options.Select(o => $"{o.AttributeName}: {o.Value}"))
                    : string.Empty;
            }

            if (product.ProductType == ProductType.VariantParent)
            {
                LoadAxesFrom(product.VariantAxes);
                LoadVariantsFrom(product.Variants);
            }

            OnPropertyChanged(nameof(CanGenerateVariants));
            OnPropertyChanged(nameof(ShowSaveFirstHint));
        }
    }

    private void LoadAxesFrom(List<ProductVariantAxisDto> variantAxes)
    {
        Axes.Clear();
        foreach (var axis in variantAxes.OrderBy(a => a.SortOrder))
        {
            ProductAxisRow row = null!;
            row = new ProductAxisRow(
                AvailableAttributes,
                attributeId => LoadAxisValuesAsync(row, attributeId));

            // Pre-populate the available values from the DTO so they show without a round-trip.
            foreach (var value in axis.AvailableValues.OrderBy(v => v.SortOrder))
            {
                row.Values.Add(new ProductAxisValueRow
                {
                    Id = value.Id,
                    Value = value.Value,
                    SortOrder = value.SortOrder
                });
            }

            // Setting ProductAttributeId would normally trigger a reload; the values are
            // already present, so assign the backing attribute id without losing them.
            row.ProductAttributeId = axis.ProductAttributeId;
            Axes.Add(row);
        }
    }

    private void LoadVariantsFrom(List<ProductVariantListDto> variants)
    {
        Variants.Clear();
        foreach (var variant in variants.OrderBy(v => v.VariantSortOrder))
        {
            var row = new ProductVariantRow
            {
                Id = variant.Id,
                Name = variant.Name,
                Sku = variant.Sku,
                Ean = variant.Ean,
                Price = variant.Price,
                OptionSummary = string.Join(" / ", variant.Options.Select(o => o.Value)),
                OptionValueIds = variant.Options.Select(o => o.ProductAttributeValueId).ToList()
            };
            row.MarkClean();
            Variants.Add(row);
        }
    }

    public async Task SaveAsync(CancellationToken ct = default)
    {
        if (!CanSave) return;

        IsSaving = true;
        ErrorMessage = string.Empty;

        try
        {
            var input = new ProductInputDto
            {
                Sku = Sku,
                Name = Name,
                NameOptimized = NameOptimized,
                Ean = Ean,
                Asin = Asin,
                Description = Description,
                DescriptionOptimized = DescriptionOptimized,
                UseOptimized = UseOptimized,
                Price = Price,
                Msrp = Msrp,
                Weight = Weight,
                Width = Width,
                Height = Height,
                Depth = Depth,
                TaxClassId = TaxClassId,
                ManufacturerId = ManufacturerId,
                ProductType = ProductType
            };

            if (ProductType == ProductType.Variant)
            {
                // Preserve variant linkage when editing an existing variant child.
                input.ParentProductId = _parentProductId;
            }
            else if (ProductType == ProductType.VariantParent)
            {
                input.VariantAxisAttributeIds = Axes
                    .Where(a => a.ProductAttributeId != Guid.Empty)
                    .Select(a => a.ProductAttributeId)
                    .ToList();
            }

            if (_productId.HasValue)
            {
                input.Id = _productId.Value;
                await _productService.UpdateProductAsync(_productId.Value, input, ct);

                // Persist inline edits to existing variant rows.
                if (ProductType == ProductType.VariantParent)
                {
                    await SaveDirtyVariantsAsync(ct);
                }
            }
            else
            {
                await _productService.CreateProductAsync(input, ct);
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
            ErrorMessage = string.Format(_localizer["ProductEditPage.SaveFailed"], ex.Message);
        }
        finally
        {
            IsSaving = false;
        }
    }

    /// <summary>
    /// Persists inline Sku/Price/Ean edits made to existing variant rows.
    /// Each dirty row is re-fetched in full and updated via the standard product endpoint.
    /// </summary>
    private async Task SaveDirtyVariantsAsync(CancellationToken ct)
    {
        foreach (var row in Variants.Where(v => v.IsDirty).ToList())
        {
            var existing = await _productService.GetProductAsync(row.Id, ct);
            if (existing == null)
            {
                continue;
            }

            var variantInput = new ProductInputDto
            {
                Id = existing.Id,
                Sku = row.Sku,
                Name = existing.Name,
                NameOptimized = existing.NameOptimized,
                Ean = row.Ean,
                Asin = existing.Asin,
                Description = existing.Description,
                DescriptionOptimized = existing.DescriptionOptimized,
                UseOptimized = existing.UseOptimized,
                Price = row.Price,
                Msrp = existing.Msrp,
                Weight = existing.Weight,
                Width = existing.Width,
                Height = existing.Height,
                Depth = existing.Depth,
                TaxClassId = existing.TaxClassId,
                ManufacturerId = existing.Manufacturer?.Id,
                ProductType = ProductType.Variant,
                ParentProductId = existing.ParentProductId ?? _productId,
                VariantSortOrder = existing.VariantSortOrder,
                VariantOptionValueIds = existing.Options.Select(o => o.ProductAttributeValueId).ToList()
            };

            await _productService.UpdateProductAsync(row.Id, variantInput, ct);
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
            base.OnPropertyChanged(nameof(CanGenerateVariants));
            base.OnPropertyChanged(nameof(ShowSaveFirstHint));
            base.OnPropertyChanged(nameof(CanModifyImages));
            base.OnPropertyChanged(nameof(ShowImageSaveFirstHint));
        }
    }
}

/// <summary>
/// Navigation data for product edit page.
/// </summary>
public record ProductEditData(Guid? ProductId);
