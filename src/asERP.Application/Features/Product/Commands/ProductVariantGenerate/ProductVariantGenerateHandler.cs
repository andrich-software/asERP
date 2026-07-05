using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Commands.ProductVariantGenerate;

public class ProductVariantGenerateHandler : IRequestHandler<ProductVariantGenerateCommand, Result<List<Guid>>>
{
    private readonly IAppLogger<ProductVariantGenerateHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly ITenantContext _tenantContext;

    public ProductVariantGenerateHandler(
        IAppLogger<ProductVariantGenerateHandler> logger,
        IProductRepository productRepository,
        ITenantContext tenantContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
    }

    public async Task<Result<List<Guid>>> Handle(ProductVariantGenerateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Generating variants for parent product: {ParentProductId}", request.ParentProductId);

        var validator = new ProductVariantGenerateValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in generate request for {0}: {1}",
                nameof(ProductVariantGenerateCommand), validationErrors);

            return Result<List<Guid>>.Fail(ResultStatusCode.BadRequest, validationErrors);
        }

        try
        {
            var currentTenantId = _tenantContext.GetCurrentTenantId();
            if (!currentTenantId.HasValue)
            {
                return Result<List<Guid>>.Fail(ResultStatusCode.BadRequest,
                    "Tenant context is not set. Cannot generate variants without tenant information.");
            }

            var parent = await _productRepository.GetWithDetailsAsync(request.ParentProductId);
            if (parent == null)
            {
                return Result<List<Guid>>.Fail(ResultStatusCode.NotFound, "Parent product not found.");
            }

            if (parent.ProductType != ProductType.VariantParent)
            {
                return Result<List<Guid>>.Fail(ResultStatusCode.BadRequest, "Parent product is not a variant parent.");
            }

            var axes = parent.VariantAxes.OrderBy(a => a.SortOrder).ToList();
            if (axes.Count == 0)
            {
                return Result<List<Guid>>.Fail(ResultStatusCode.BadRequest, "Parent product has no variant axes defined.");
            }

            // The request must select values for exactly the parent's axes
            var requestedAxisIds = request.Axes.Select(a => a.ProductAttributeId).ToHashSet();
            if (requestedAxisIds.Count != axes.Count || axes.Any(a => !requestedAxisIds.Contains(a.ProductAttributeId)))
            {
                return Result<List<Guid>>.Fail(ResultStatusCode.BadRequest,
                    "The selection must cover exactly the parent's variant axes.");
            }

            // Resolve the selected values per axis in axis order; values must belong to the axis attribute
            var selectionsPerAxis = new List<List<Domain.Entities.ProductAttributeValue>>();
            foreach (var axis in axes)
            {
                var selection = request.Axes.First(a => a.ProductAttributeId == axis.ProductAttributeId);
                var availableValues = (axis.ProductAttribute?.Values ?? []).ToDictionary(v => v.Id);

                var axisValues = new List<Domain.Entities.ProductAttributeValue>();
                foreach (var valueId in selection.ValueIds.Distinct())
                {
                    if (!availableValues.TryGetValue(valueId, out var value))
                    {
                        return Result<List<Guid>>.Fail(ResultStatusCode.BadRequest,
                            $"Value {valueId} does not belong to attribute '{axis.ProductAttribute?.Name}'.");
                    }

                    axisValues.Add(value);
                }

                selectionsPerAxis.Add(axisValues);
            }

            // Cartesian product over all axes
            var combinations = selectionsPerAxis.Aggregate(
                new List<List<Domain.Entities.ProductAttributeValue>> { new() },
                (acc, axisValues) => acc
                    .SelectMany(combo => axisValues.Select(v => combo.Append(v).ToList()))
                    .ToList());

            // Skip combinations that already exist among the parent's variants
            var existingCombinations = parent.Variants
                .Select(v => v.VariantOptions.Select(o => o.ProductAttributeValueId).ToHashSet())
                .ToList();

            var createdIds = new List<Guid>();
            var sortOrder = parent.Variants.Count == 0 ? 0 : parent.Variants.Max(v => v.VariantSortOrder) + 1;
            var skuIndex = parent.Variants.Count;

            foreach (var combination in combinations)
            {
                var combinationIds = combination.Select(v => v.Id).ToHashSet();
                if (existingCombinations.Any(existing => existing.SetEquals(combinationIds)))
                {
                    continue;
                }

                // Find the next free SKU based on the parent SKU
                string sku;
                do
                {
                    skuIndex++;
                    sku = $"{parent.Sku}-{skuIndex}";
                } while (await _productRepository.GetBySkuAsync(sku) != null);

                var variant = new Domain.Entities.Product
                {
                    Sku = sku,
                    Name = $"{parent.Name} - {string.Join(" / ", combination.Select(v => v.Value))}",
                    Ean = null,
                    Description = parent.Description,
                    Price = parent.Price,
                    Msrp = parent.Msrp,
                    Weight = parent.Weight,
                    Width = parent.Width,
                    Height = parent.Height,
                    Depth = parent.Depth,
                    TaxClassId = parent.TaxClassId,
                    ManufacturerId = parent.ManufacturerId,
                    ProductType = ProductType.Variant,
                    ParentProductId = parent.Id,
                    VariantSortOrder = sortOrder++,
                    TenantId = currentTenantId.Value,
                    VariantOptions = combination.Select(v => new Domain.Entities.ProductVariantOption
                    {
                        ProductAttributeValueId = v.Id,
                        TenantId = currentTenantId.Value
                    }).ToList()
                };

                _productRepository.Add(variant);
                createdIds.Add(variant.Id);
            }

            if (createdIds.Count > 0)
            {
                await _productRepository.SaveChangesAsync(cancellationToken);
            }

            _logger.LogInformation("Generated {Count} variants for parent product {ParentProductId}",
                createdIds.Count, parent.Id);

            var result = Result<List<Guid>>.Success(createdIds);
            result.StatusCode = ResultStatusCode.Created;
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating variants");

            return Result<List<Guid>>.Fail(ResultStatusCode.InternalServerError,
                "An error occurred while generating variants.");
        }
    }
}
