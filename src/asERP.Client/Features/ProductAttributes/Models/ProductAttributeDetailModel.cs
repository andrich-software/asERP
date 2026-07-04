using asERP.Client.Features.ProductAttributes.Services;
using asERP.Domain.Dtos.ProductAttribute;

namespace asERP.Client.Features.ProductAttributes.Models;

/// <summary>
/// Model for product attribute detail page using MVUX pattern.
/// Receives product attribute ID from navigation data.
/// </summary>
public partial record ProductAttributeDetailModel
{
    private readonly IProductAttributeService _productAttributeService;
    private readonly INavigator _navigator;
    private readonly Guid _productAttributeId;

    public ProductAttributeDetailModel(
        IProductAttributeService productAttributeService,
        INavigator navigator,
        ProductAttributeDetailData data)
    {
        _productAttributeService = productAttributeService;
        _navigator = navigator;
        _productAttributeId = data.ProductAttributeId;
    }

    /// <summary>
    /// Feed that loads the product attribute details.
    /// </summary>
    public IFeed<ProductAttributeDetailDto> ProductAttribute => Feed.Async(async ct =>
    {
        var productAttribute = await _productAttributeService.GetProductAttributeAsync(_productAttributeId, ct);
        return productAttribute ?? throw new InvalidOperationException($"Product attribute {_productAttributeId} not found");
    });

    /// <summary>
    /// Navigate to edit product attribute page.
    /// </summary>
    public async Task EditProductAttribute()
    {
        await _navigator.NavigateDataAsync(this, new ProductAttributeEditData(_productAttributeId));
    }

    /// <summary>
    /// Navigate back to product attribute list.
    /// </summary>
    public async Task GoBack()
    {
        await _navigator.NavigateBackAsync(this);
    }
}
