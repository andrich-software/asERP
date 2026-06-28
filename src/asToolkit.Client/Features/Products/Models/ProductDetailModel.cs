using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Features.Products.Services;
using asToolkit.Domain.Dtos.Product;

namespace asToolkit.Client.Features.Products.Models;

/// <summary>
/// Model for product detail page using MVUX pattern.
/// Receives product ID from navigation data.
/// </summary>
public partial record ProductDetailModel
{
    private readonly IProductService _productService;
    private readonly INavigator _navigator;
    private readonly Guid _productId;

    public ProductDetailModel(
        IProductService productService,
        INavigator navigator,
        ProductDetailData data)
    {
        _productService = productService;
        _navigator = navigator;
        _productId = data.productId;
    }

    /// <summary>
    /// State for error messages from API operations.
    /// </summary>
    public IState<string> ErrorMessage => State<string>.Value(this, () => string.Empty);

    /// <summary>
    /// Feed that loads the product details.
    /// </summary>
    public IFeed<ProductDetailDto> Product => Feed.Async(async ct =>
    {
        var product = await _productService.GetProductAsync(_productId, ct);
        return product ?? throw new InvalidOperationException($"Product {_productId} not found");
    });

    /// <summary>
    /// Read-only gallery: the product's images with their thumbnail bytes loaded via the
    /// authed client (first in the order is the primary image).
    /// </summary>
    public IListFeed<ProductImageRow> Images => ListFeed.Async(async ct =>
    {
        var images = await _productService.GetProductImagesAsync(_productId, ct);
        var rows = new List<ProductImageRow>();

        foreach (var dto in images.OrderBy(i => i.SortOrder))
        {
            var row = new ProductImageRow
            {
                Id = dto.Id,
                SortOrder = dto.SortOrder,
                AltText = dto.AltText,
                OriginalFileName = dto.OriginalFileName
            };

            try
            {
                row.ThumbnailBytes = await _productService.GetProductImageBytesAsync(_productId, dto.Id, thumbnail: true, ct);
            }
            catch
            {
                // Thumbnail is non-essential; a missing preview must not break the gallery.
            }

            rows.Add(row);
        }

        return (IImmutableList<ProductImageRow>)rows.ToImmutableList();
    });

    /// <summary>
    /// Navigate to edit product page.
    /// </summary>
    public async Task EditProduct()
    {
        await _navigator.NavigateDataAsync(this, new ProductEditData(_productId));
    }

    /// <summary>
    /// Navigate to the detail page of a child variant.
    /// </summary>
    public async Task ViewVariant(ProductVariantListDto variant)
    {
        await _navigator.NavigateDataAsync(this, new ProductDetailData(variant.Id));
    }

    /// <summary>
    /// Clear the error message.
    /// </summary>
    public async Task ClearError(CancellationToken ct)
    {
        await ErrorMessage.Set(string.Empty, ct);
    }

    /// <summary>
    /// Navigate back to product list.
    /// </summary>
    public async Task GoBack()
    {
        await _navigator.NavigateBackAsync(this);
    }
}
