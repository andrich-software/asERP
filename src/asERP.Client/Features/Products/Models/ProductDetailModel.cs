using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using asERP.Client.Core.Exceptions;
using asERP.Client.Features.Products.Services;
using asERP.Domain.Dtos.Product;

namespace asERP.Client.Features.Products.Models;

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
    /// Gate for the lazy images feed; flipped once when the images tab is first selected.
    /// </summary>
    public IState<bool> ImagesTabRequested => State<bool>.Value(this, () => false);

    /// <summary>
    /// Read-only gallery: the product's images with their thumbnail bytes loaded via the
    /// authed client (first in the order is the primary image). Stays dormant until
    /// <see cref="RequestImagesTab"/> flips the gate (lazy per-tab feed).
    /// </summary>
    public IListFeed<ProductImageRow> Images => ImagesTabRequested
        .Where(requested => requested)
        .SelectAsync(async (_, ct) =>
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
    })
        .AsListFeed();

    /// <summary>
    /// Start loading the images feed; called from the page when the images tab is first selected.
    /// </summary>
    public async ValueTask RequestImagesTab(CancellationToken ct = default)
        => await ImagesTabRequested.UpdateAsync(_ => true, ct);

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
