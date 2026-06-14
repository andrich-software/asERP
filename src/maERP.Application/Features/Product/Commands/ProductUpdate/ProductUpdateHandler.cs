using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Application.Features.Product.Shared;
using maERP.Application.Notifications;
using maERP.Domain.Enums;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.Product.Commands.ProductUpdate;

public class ProductUpdateHandler : IRequestHandler<ProductUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductUpdateHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly ITaxClassRepository _taxClassRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IProductAttributeRepository _productAttributeRepository;
    private readonly IMediator _mediator;

    public ProductUpdateHandler(
        IAppLogger<ProductUpdateHandler> logger,
        IProductRepository productRepository,
        ITaxClassRepository taxClassRepository,
        IManufacturerRepository manufacturerRepository,
        IProductAttributeRepository productAttributeRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _taxClassRepository = taxClassRepository ?? throw new ArgumentNullException(nameof(taxClassRepository));
        _manufacturerRepository = manufacturerRepository ?? throw new ArgumentNullException(nameof(manufacturerRepository));
        _productAttributeRepository = productAttributeRepository ?? throw new ArgumentNullException(nameof(productAttributeRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating product with ID: {Id}", request.Id);

        // Validate incoming data
        var validator = new ProductUpdateValidator(_productRepository, _taxClassRepository, _manufacturerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            
            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(ProductUpdateCommand), validationErrors);

            // Check if the validation error is about product not found
            if (validationResult.Errors.Any(e => e.ErrorMessage.Contains("Product not found")))
            {
                return Result<Guid>.Fail(ResultStatusCode.NotFound, validationErrors);
            }
            
            return Result<Guid>.Fail(ResultStatusCode.BadRequest, validationErrors);
        }

        try
        {
            // Load existing product incl. variant axes/options for tracking
            var productToUpdate = await _productRepository.GetWithDetailsAsync(request.Id);

            if (productToUpdate == null)
            {
                _logger.LogWarning("Product with ID {Id} not found for update", request.Id);
                return Result<Guid>.Fail(ResultStatusCode.NotFound, "Product not found.");
            }

            // Cross-entity variant rules: type transitions and variant option sets
            var transitionError = ProductVariantRules.ValidateTypeTransition(productToUpdate, request, productToUpdate.Variants.Count);
            if (transitionError != null)
            {
                _logger.LogWarning("Type transition validation failed in update request: {Error}", transitionError);
                return Result<Guid>.Fail(ResultStatusCode.BadRequest, transitionError);
            }

            if (request.ProductType == ProductType.Variant)
            {
                var (variantError, _) = await ProductVariantRules.ValidateVariantAsync(request, productToUpdate.Id, _productRepository);
                if (variantError != null)
                {
                    _logger.LogWarning("Variant validation failed in update request: {Error}", variantError);
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest, variantError);
                }
            }
            else if (request.ProductType == ProductType.VariantParent)
            {
                var axisError = await ProductVariantRules.ValidateParentAxesAsync(request, _productAttributeRepository);
                if (axisError != null)
                {
                    _logger.LogWarning("Variant axis validation failed in update request: {Error}", axisError);
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest, axisError);
                }

                // Removing an axis is only allowed while no variant carries a value of it
                var requestedAxisIds = request.VariantAxisAttributeIds.Distinct().ToList();
                foreach (var axis in productToUpdate.VariantAxes.Where(a => !requestedAxisIds.Contains(a.ProductAttributeId)))
                {
                    var axisInUse = productToUpdate.Variants.Any(v => v.VariantOptions
                        .Any(o => o.ProductAttributeValue?.ProductAttributeId == axis.ProductAttributeId));

                    if (axisInUse)
                    {
                        var message = "A variant axis that is still used by variants cannot be removed.";
                        _logger.LogWarning("Variant axis validation failed in update request: {Error}", message);
                        return Result<Guid>.Fail(ResultStatusCode.BadRequest, message);
                    }
                }
            }

            // Update properties
            productToUpdate.Sku = request.Sku;
            productToUpdate.Name = request.Name;
            productToUpdate.NameOptimized = request.NameOptimized;
            productToUpdate.Ean = request.Ean;
            productToUpdate.Asin = request.Asin;
            productToUpdate.Description = request.Description;
            productToUpdate.DescriptionOptimized = request.DescriptionOptimized;
            productToUpdate.UseOptimized = request.UseOptimized;
            productToUpdate.Price = request.Price;
            productToUpdate.Msrp = request.Msrp;
            productToUpdate.Weight = request.Weight;
            productToUpdate.Width = request.Width;
            productToUpdate.Height = request.Height;
            productToUpdate.Depth = request.Depth;
            productToUpdate.TaxClassId = request.TaxClassId;
            productToUpdate.ManufacturerId = request.ManufacturerId;
            productToUpdate.ProductType = request.ProductType;
            productToUpdate.VariantSortOrder = request.VariantSortOrder;

            if (request.ProductType == ProductType.VariantParent)
            {
                // Sync axes: remove unused (verified above), add new, keep requested order
                var requestedAxisIds = request.VariantAxisAttributeIds.Distinct().ToList();

                foreach (var axisToRemove in productToUpdate.VariantAxes
                             .Where(a => !requestedAxisIds.Contains(a.ProductAttributeId)).ToList())
                {
                    productToUpdate.VariantAxes.Remove(axisToRemove);
                    _productRepository.RemoveVariantAxis(axisToRemove);
                }

                for (var i = 0; i < requestedAxisIds.Count; i++)
                {
                    var existingAxis = productToUpdate.VariantAxes.FirstOrDefault(a => a.ProductAttributeId == requestedAxisIds[i]);
                    if (existingAxis != null)
                    {
                        existingAxis.SortOrder = i;
                    }
                    else
                    {
                        var axis = new Domain.Entities.ProductVariantAxis
                        {
                            ParentProductId = productToUpdate.Id,
                            ProductAttributeId = requestedAxisIds[i],
                            SortOrder = i,
                            TenantId = productToUpdate.TenantId
                        };
                        productToUpdate.VariantAxes.Add(axis);
                        _productRepository.AddVariantAxis(axis);
                    }
                }
            }
            else if (request.ProductType == ProductType.Variant)
            {
                // Sync option set: remove unselected values, add missing ones
                var requestedOptionIds = request.VariantOptionValueIds.Distinct().ToHashSet();

                foreach (var optionToRemove in productToUpdate.VariantOptions
                             .Where(o => !requestedOptionIds.Contains(o.ProductAttributeValueId)).ToList())
                {
                    productToUpdate.VariantOptions.Remove(optionToRemove);
                    _productRepository.RemoveVariantOption(optionToRemove);
                }

                var existingOptionIds = productToUpdate.VariantOptions.Select(o => o.ProductAttributeValueId).ToHashSet();
                foreach (var valueId in requestedOptionIds.Where(id => !existingOptionIds.Contains(id)))
                {
                    var option = new Domain.Entities.ProductVariantOption
                    {
                        ProductId = productToUpdate.Id,
                        ProductAttributeValueId = valueId,
                        TenantId = productToUpdate.TenantId
                    };
                    productToUpdate.VariantOptions.Add(option);
                    _productRepository.AddVariantOption(option);
                }
            }

            // Update in database
            await _productRepository.UpdateAsync(productToUpdate);

            await _mediator.Publish(
                new ProductChangedNotification(productToUpdate.Id, productToUpdate.TenantId, ProductChangeKind.Updated),
                cancellationToken);

            _logger.LogInformation("Successfully updated product with ID: {Id}", productToUpdate.Id);

            return Result<Guid>.Success(productToUpdate.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error updating product: {Message}", ex.Message);
            
            return Result<Guid>.Fail(ResultStatusCode.InternalServerError,
                $"An error occurred while updating the product: {ex.Message}");
        }
    }
}
