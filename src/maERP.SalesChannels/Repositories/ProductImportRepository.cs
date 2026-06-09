using maERP.Application.Contracts.Persistence;
using maERP.Application.Exceptions;
using maERP.Domain.Entities;
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

    public ProductImportRepository(ILogger<ProductImportRepository> logger, IProductRepository productRepository, ISalesChannelRepository salesChannelRepository, ITaxClassRepository taxClassRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
        _salesChannelRepository = salesChannelRepository;
        _taxClassRepository = taxClassRepository;
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
                        RemoteProductId = importProduct.RemoteProductId.ToString(),
                        Price = importProduct.Price
                    }
                ],
                Description = description,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            };

            await _productRepository.CreateAsync(newProduct);
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
                        RemoteProductId = importProduct.RemoteProductId.ToString(),
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

            if (somethingChanged)
            {
                await _productRepository.UpdateAsync(existingProduct);
                _logger.LogDebug("Product {0} updated", importProduct.Sku);
            }
        }
    }
}