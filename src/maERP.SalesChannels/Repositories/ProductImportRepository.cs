using maERP.Application.Contracts.Persistence;
using maERP.Application.Exceptions;
using maERP.Domain.Entities;
using maERP.Domain.Enums;
using maERP.SalesChannels.Contracts;
using maERP.SalesChannels.Models;
using maERP.SalesChannels.Text;
using Microsoft.Extensions.Logging;

namespace maERP.SalesChannels.Repositories;

public class ProductImportRepository : IProductImportRepository
{
    private readonly ILogger<ProductImportRepository> _logger;
    private readonly IProductRepository _productRepository;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly ITaxClassRepository _taxClassRepository;
    private readonly IProductAttributeRepository _productAttributeRepository;
    private readonly IProductSalesChannelRepository _productSalesChannelRepository;
    private readonly IProductImageImportService _productImageImportService;

    public ProductImportRepository(
        ILogger<ProductImportRepository> logger,
        IProductRepository productRepository,
        ISalesChannelRepository salesChannelRepository,
        ITaxClassRepository taxClassRepository,
        IProductAttributeRepository productAttributeRepository,
        IProductSalesChannelRepository productSalesChannelRepository,
        IProductImageImportService productImageImportService)
    {
        _logger = logger;
        _productRepository = productRepository;
        _salesChannelRepository = salesChannelRepository;
        _taxClassRepository = taxClassRepository;
        _productAttributeRepository = productAttributeRepository;
        _productSalesChannelRepository = productSalesChannelRepository;
        _productImageImportService = productImageImportService;
    }

    public async Task ImportOrUpdateFromSalesChannel(Guid salesChannelId, SalesChannelImportProduct importProduct)
    {
        var taxClass = await _taxClassRepository.GetByTaxRateAsync(importProduct.TaxRate);

        if (taxClass == null)
        {
            // Without a matching tax class the product cannot be created. Surface this as a failure
            // (the connector loop counts the throw as a failed item and records it in the sync run's
            // error summary) instead of silently returning, which previously masked the problem by
            // counting the row as "processed" while importing nothing.
            _logger.LogWarning("No matching tax class found for tax rate {TaxRate}; skipping product {Sku}", importProduct.TaxRate, importProduct.Sku);
            throw new InvalidOperationException(
                $"No tax class configured for tax rate {importProduct.TaxRate}; product '{importProduct.Sku}' could not be imported.");
        }

        // Sales channels deliver the description as HTML; store it in a compact Markdown-like form.
        // Done once here so both the create path and the update change-detection compare the same value.
        var description = HtmlToMarkdownConverter.Convert(importProduct.Description);

        var existingProduct = await _productRepository.GetBySkuAsync(importProduct.Sku);
        Guid productId;

        if (existingProduct == null)
        {
            _logger.LogDebug("Product {0} does not exist, creating Product and SalesChannel", importProduct.Sku);

            var newProduct = new Product
            {
                Name = importProduct.Name,
                Ean = importProduct.Ean,
                Price = importProduct.Price,
                Sku = importProduct.Sku,
                TaxClass = taxClass,
                ProductType = importProduct.IsVariantParent ? ProductType.VariantParent : ProductType.Standard,
                // No initial stock row on import. The previous code seeded a ProductStock with a
                // random WarehouseId (Guid.NewGuid()), which has no matching warehouse row and made
                // every insert fail with the FK_product_stock_warehouse_WarehouseId constraint —
                // so no products were ever imported. Real stock is established via warehouses /
                // goods receipts; imported products simply start with zero stock.
                ProductSalesChannels =
                [
                    new ProductSalesChannel
                    {
                        SalesChannel = await _salesChannelRepository.GetByIdAsync(salesChannelId) ?? throw new NotFoundException("SalesChannel {0} not found", salesChannelId),
                        SalesChannelId = salesChannelId,
                        RemoteProductId = importProduct.RemoteProductId,
                        Price = importProduct.Price
                    }
                ],
                Description = description,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _productRepository.CreateAsync(newProduct);
            productId = newProduct.Id;
            _logger.LogDebug("Product {0} created", importProduct.Sku);
        }
        else
        {
            _logger.LogDebug("Product {0} already exists, check for SalesChannel", existingProduct.Sku);
            bool somethingChanged = false;
            bool salesChannelExist = false;

            if (existingProduct.ProductSalesChannels != null)
            {
                salesChannelExist = existingProduct.ProductSalesChannels.Any(s => s.SalesChannelId == salesChannelId);
            }

            // TODO update price when salesChannelExist is true
            if (!salesChannelExist)
            {
                _logger.LogDebug("Creating SalesChannel entry for Product {0}", importProduct.Sku);

                existingProduct.ProductSalesChannels =
                [
                    new ProductSalesChannel
                    {
                        SalesChannel = await _salesChannelRepository.GetByIdAsync(salesChannelId) ?? throw new NotFoundException("SalesChannel {0} not found", salesChannelId),
                        SalesChannelId = salesChannelId,
                        RemoteProductId = importProduct.RemoteProductId,
                        Price = importProduct.Price
                    }
                ];

                somethingChanged = true;
            }

            if (existingProduct.Name != importProduct.Name)
            {
                existingProduct.Name = importProduct.Name;
                somethingChanged = true;
            }

            if (existingProduct.Ean != importProduct.Ean)
            {
                existingProduct.Ean = importProduct.Ean;
                somethingChanged = true;
            }

            if (existingProduct.Price != importProduct.Price)
            {
                existingProduct.Price = importProduct.Price;
                somethingChanged = true;
            }

            if (existingProduct.Sku != importProduct.Sku)
            {
                existingProduct.Sku = importProduct.Sku;
                somethingChanged = true;
            }

            if (existingProduct.Description != description)
            {
                existingProduct.Description = description;
                somethingChanged = true;
            }

            // A previously flat-imported variable product is upgraded to a variant parent so its
            // variations attach below it; a parent never silently degrades back to Standard.
            if (importProduct.IsVariantParent && existingProduct.ProductType == ProductType.Standard)
            {
                existingProduct.ProductType = ProductType.VariantParent;
                somethingChanged = true;
            }

            if (somethingChanged)
            {
                await _productRepository.UpdateAsync(existingProduct);
                _logger.LogDebug("Product {0} updated", importProduct.Sku);
            }

            productId = existingProduct.Id;
        }

        // Photos are synced after the product row exists. The service reconciles this channel's photo
        // set incrementally (add new, drop removed) and is resilient, so this is safe on both the create
        // and update paths and never fails the product import.
        await _productImageImportService.ImportImagesAsync(productId, salesChannelId, importProduct.Images, CancellationToken.None);

        if (importProduct.IsVariantParent && importProduct.Variants.Count > 0)
        {
            await ImportVariantsAsync(salesChannelId, productId, importProduct);
        }
    }

    private async Task ImportVariantsAsync(Guid salesChannelId, Guid parentProductId, SalesChannelImportProduct importProduct)
    {
        // Reload the parent as a tracked aggregate incl. axes and variants with their options
        var parent = await _productRepository.GetWithDetailsAsync(parentProductId)
                     ?? throw new NotFoundException("Parent product {0} not found", parentProductId);

        // Axis names either come explicitly from the channel or are derived from the variant options
        var axisNames = importProduct.VariantAxes.Where(n => !string.IsNullOrWhiteSpace(n)).Distinct().ToList();
        if (axisNames.Count == 0)
        {
            axisNames = importProduct.Variants
                .SelectMany(v => v.Options.Select(o => o.AttributeName))
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct()
                .ToList();
        }

        // Upsert attributes (tenant-scoped, by name) and their values used by the incoming variants
        var attributesByName = new Dictionary<string, ProductAttribute>(StringComparer.OrdinalIgnoreCase);
        foreach (var axisName in axisNames)
        {
            var attribute = await _productAttributeRepository.GetByNameAsync(axisName);
            if (attribute == null)
            {
                attribute = new ProductAttribute { Name = axisName };
                await _productAttributeRepository.CreateAsync(attribute);
            }

            attributesByName[axisName] = attribute;
        }

        var newValues = false;
        foreach (var option in importProduct.Variants.SelectMany(v => v.Options))
        {
            if (string.IsNullOrWhiteSpace(option.Value) || !attributesByName.TryGetValue(option.AttributeName, out var attribute))
            {
                continue;
            }

            if (!attribute.Values.Any(v => string.Equals(v.Value, option.Value, StringComparison.OrdinalIgnoreCase)))
            {
                var value = new ProductAttributeValue
                {
                    ProductAttributeId = attribute.Id,
                    Value = option.Value,
                    TenantId = attribute.TenantId
                };
                // Track as Added via the DbSet; also keep it in the in-memory collection so the
                // dedup check above and the later option resolution see it.
                attribute.Values.Add(value);
                _productAttributeRepository.AddValue(value);
                newValues = true;
            }
        }

        if (newValues)
        {
            await _productAttributeRepository.SaveChangesAsync();
        }

        // Sync the parent's axes: add missing ones, keep existing (axes are never removed on import)
        var axesChanged = false;
        for (var i = 0; i < axisNames.Count; i++)
        {
            var attribute = attributesByName[axisNames[i]];
            if (parent.VariantAxes.All(a => a.ProductAttributeId != attribute.Id))
            {
                var axis = new ProductVariantAxis
                {
                    ParentProductId = parent.Id,
                    ProductAttributeId = attribute.Id,
                    SortOrder = i,
                    TenantId = parent.TenantId
                };
                parent.VariantAxes.Add(axis);
                _productRepository.AddVariantAxis(axis);
                axesChanged = true;
            }
        }

        if (axesChanged)
        {
            await _productRepository.SaveChangesAsync();
        }

        var somethingChanged = false;
        foreach (var importVariant in importProduct.Variants)
        {
            // Stable SKU synthesis for channels that allow SKU-less variations (WooCommerce):
            // the remote variation id never changes, so re-imports resolve to the same SKU.
            var sku = string.IsNullOrWhiteSpace(importVariant.Sku)
                ? $"{parent.Sku}-V{importVariant.RemoteVariantId}"
                : importVariant.Sku!;

            var optionValueIds = ResolveOptionValueIds(importVariant, attributesByName);

            // Matching order: (a) channel link by RemoteProductId — survives shop-side SKU edits,
            // (b) SKU, (c) option combination among the parent's variants.
            var variant = await FindVariantAsync(salesChannelId, parent, importVariant, sku, optionValueIds);

            var effectivePrice = importVariant.Price ?? parent.Price;

            if (variant == null)
            {
                variant = new Product
                {
                    Sku = sku,
                    Name = BuildVariantName(parent.Name, importVariant),
                    Ean = importVariant.Ean,
                    Price = effectivePrice,
                    Description = parent.Description,
                    TaxClassId = parent.TaxClassId,
                    ManufacturerId = parent.ManufacturerId,
                    ProductType = ProductType.Variant,
                    ParentProductId = parent.Id,
                    VariantSortOrder = importVariant.SortOrder,
                    VariantOptions = optionValueIds
                        .Select(valueId => new ProductVariantOption { ProductAttributeValueId = valueId })
                        .ToList(),
                    ProductSalesChannels =
                    [
                        new ProductSalesChannel
                        {
                            SalesChannelId = salesChannelId,
                            RemoteProductId = importVariant.RemoteVariantId,
                            Price = effectivePrice
                        }
                    ]
                };

                _productRepository.Add(variant);
                somethingChanged = true;
                _logger.LogDebug("Variant {Sku} created under parent {ParentSku}", sku, parent.Sku);
                continue;
            }

            // Update an existing variant in place
            if (variant.Sku != sku)
            {
                variant.Sku = sku;
                somethingChanged = true;
            }

            if (!string.IsNullOrEmpty(importVariant.Ean) && variant.Ean != importVariant.Ean)
            {
                variant.Ean = importVariant.Ean;
                somethingChanged = true;
            }

            if (importVariant.Price.HasValue && variant.Price != importVariant.Price.Value)
            {
                variant.Price = importVariant.Price.Value;
                somethingChanged = true;
            }

            if (variant.VariantSortOrder != importVariant.SortOrder)
            {
                variant.VariantSortOrder = importVariant.SortOrder;
                somethingChanged = true;
            }

            // A previously flat-imported product (matched by SKU) becomes a proper variant
            if (variant.ProductType != ProductType.Variant || variant.ParentProductId != parent.Id)
            {
                variant.ProductType = ProductType.Variant;
                variant.ParentProductId = parent.Id;
                somethingChanged = true;
            }

            // Ensure the option set matches the channel's combination
            var existingOptionIds = variant.VariantOptions.Select(o => o.ProductAttributeValueId).ToHashSet();
            foreach (var valueId in optionValueIds.Where(id => !existingOptionIds.Contains(id)))
            {
                var option = new ProductVariantOption
                {
                    ProductId = variant.Id,
                    ProductAttributeValueId = valueId,
                    TenantId = variant.TenantId
                };
                variant.VariantOptions.Add(option);
                _productRepository.AddVariantOption(option);
                somethingChanged = true;
            }

            // Ensure the channel link exists and points at the remote variation id
            var psc = variant.ProductSalesChannels?.FirstOrDefault(p => p.SalesChannelId == salesChannelId);
            if (psc == null)
            {
                // Add via the DbSet (new pre-keyed child on a tracked parent would otherwise be
                // mislabeled Modified). ProductId must be set since it is not graph-inferred here.
                _productSalesChannelRepository.Add(new ProductSalesChannel
                {
                    ProductId = variant.Id,
                    SalesChannelId = salesChannelId,
                    RemoteProductId = importVariant.RemoteVariantId,
                    Price = effectivePrice,
                    TenantId = variant.TenantId
                });
                somethingChanged = true;
            }
            else if (psc.RemoteProductId != importVariant.RemoteVariantId)
            {
                psc.RemoteProductId = importVariant.RemoteVariantId;
                somethingChanged = true;
            }
        }

        if (somethingChanged)
        {
            await _productRepository.SaveChangesAsync();
        }
    }

    private async Task<Product?> FindVariantAsync(
        Guid salesChannelId,
        Product parent,
        SalesChannelImportVariant importVariant,
        string sku,
        HashSet<Guid> optionValueIds)
    {
        // Matching order: (a) channel link by RemoteProductId — survives shop-side SKU edits,
        // (b) SKU, (c) option combination among the parent's variants. Whatever matches is
        // reloaded fully (channel links + options, tracked) so the update path sees a complete graph.
        if (!string.IsNullOrEmpty(importVariant.RemoteVariantId))
        {
            var psc = await _productSalesChannelRepository.GetByRemoteProductIdAsync(importVariant.RemoteVariantId, salesChannelId);
            if (psc != null && psc.ProductId != parent.Id)
            {
                return await _productRepository.GetWithDetailsAsync(psc.ProductId);
            }
        }

        var bySku = await _productRepository.GetBySkuAsync(sku);
        if (bySku != null && bySku.Id != parent.Id)
        {
            return await _productRepository.GetWithDetailsAsync(bySku.Id);
        }

        if (optionValueIds.Count > 0)
        {
            var byCombination = parent.Variants.FirstOrDefault(v =>
                v.VariantOptions.Select(o => o.ProductAttributeValueId).ToHashSet().SetEquals(optionValueIds));

            if (byCombination != null)
            {
                return await _productRepository.GetWithDetailsAsync(byCombination.Id);
            }
        }

        return null;
    }

    private static HashSet<Guid> ResolveOptionValueIds(
        SalesChannelImportVariant importVariant,
        Dictionary<string, ProductAttribute> attributesByName)
    {
        var valueIds = new HashSet<Guid>();
        foreach (var option in importVariant.Options)
        {
            if (string.IsNullOrWhiteSpace(option.Value) || !attributesByName.TryGetValue(option.AttributeName, out var attribute))
            {
                continue;
            }

            var value = attribute.Values.FirstOrDefault(v => string.Equals(v.Value, option.Value, StringComparison.OrdinalIgnoreCase));
            if (value != null)
            {
                valueIds.Add(value.Id);
            }
        }

        return valueIds;
    }

    private static string BuildVariantName(string parentName, SalesChannelImportVariant importVariant)
    {
        var optionPart = string.Join(" / ", importVariant.Options
            .Where(o => !string.IsNullOrWhiteSpace(o.Value))
            .Select(o => o.Value));

        return string.IsNullOrEmpty(optionPart) ? parentName : $"{parentName} - {optionPart}";
    }
}
