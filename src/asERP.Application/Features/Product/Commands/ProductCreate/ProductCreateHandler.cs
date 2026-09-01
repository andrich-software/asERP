using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Features.Product.Shared;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Commands.ProductCreate;

/// <summary>
/// Handler for processing product creation commands.
/// Implements IRequestHandler from the custom mediator to handle ProductCreateCommand requests
/// and return the ID of the newly created product wrapped in a Result.
/// </summary>
public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductCreateHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly ITaxClassRepository _taxClassRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IProductAttributeRepository _productAttributeRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITenantContext _tenantContext;

    public ProductCreateHandler(
        IAppLogger<ProductCreateHandler> logger,
        IProductRepository productRepository,
        ITaxClassRepository taxClassRepository,
        IManufacturerRepository manufacturerRepository,
        IProductAttributeRepository productAttributeRepository,
        ICategoryRepository categoryRepository,
        ITenantContext tenantContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _taxClassRepository = taxClassRepository ?? throw new ArgumentNullException(nameof(taxClassRepository));
        _manufacturerRepository = manufacturerRepository ?? throw new ArgumentNullException(nameof(manufacturerRepository));
        _productAttributeRepository = productAttributeRepository ?? throw new ArgumentNullException(nameof(productAttributeRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
    }

    public async Task<Result<Guid>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new product with SKU: {Sku}, Name: {Name}", request.Sku, request.Name);

        // Get current tenant ID for proper data isolation
        var currentTenantId = _tenantContext.GetCurrentTenantId();
        if (!currentTenantId.HasValue)
        {
            _logger.LogError("Attempted to create product without tenant context");
            return Result<Guid>.Invalid(ErrorCodes.Product.Invalid,
                "Tenant context is not set. Cannot create product without tenant information.");
        }

        // Cross-entity variant rules (parent reference, axis coverage, sibling uniqueness)
        Domain.Entities.Product? parentProduct = null;
        if (request.ProductType == ProductType.Variant)
        {
            var (variantError, parent) = await ProductVariantRules.ValidateVariantAsync(request, null, _productRepository);
            if (variantError != null)
            {
                _logger.LogWarning("Variant validation failed in create request: {Error}", variantError);
                return Result<Guid>.Invalid(ErrorCodes.Product.Invalid, variantError);
            }

            parentProduct = parent;
        }
        else if (request.ProductType == ProductType.VariantParent)
        {
            var axisError = await ProductVariantRules.ValidateParentAxesAsync(request, _productAttributeRepository);
            if (axisError != null)
            {
                _logger.LogWarning("Variant axis validation failed in create request: {Error}", axisError);
                return Result<Guid>.Invalid(ErrorCodes.Product.Invalid, axisError);
            }
        }

        // Manual mapping instead of using AutoMapper
        var productToCreate = new Domain.Entities.Product
        {
            Sku = request.Sku,
            Name = request.Name,
            NameOptimized = request.NameOptimized,
            Ean = request.Ean,
            Asin = request.Asin,
            Description = request.Description,
            DescriptionOptimized = request.DescriptionOptimized,
            UseOptimized = request.UseOptimized,
            Price = request.Price,
            Msrp = request.Msrp,
            Weight = request.Weight,
            Width = request.Width,
            Height = request.Height,
            Depth = request.Depth,
            TaxClassId = request.TaxClassId,
            ManufacturerId = request.ManufacturerId,
            ProductType = request.ProductType,
            ParentProductId = request.ProductType == ProductType.Variant ? parentProduct!.Id : null,
            VariantSortOrder = request.VariantSortOrder,
            TenantId = currentTenantId.Value // Explicitly set TenantId for data isolation
        };

        if (request.ProductType == ProductType.VariantParent)
        {
            productToCreate.VariantAxes = request.VariantAxisAttributeIds
                .Select((attributeId, index) => new Domain.Entities.ProductVariantAxis
                {
                    ProductAttributeId = attributeId,
                    SortOrder = index,
                    TenantId = currentTenantId.Value
                }).ToList();
        }
        else if (request.ProductType == ProductType.Variant)
        {
            productToCreate.VariantOptions = request.VariantOptionValueIds.Distinct()
                .Select(valueId => new Domain.Entities.ProductVariantOption
                {
                    ProductAttributeValueId = valueId,
                    TenantId = currentTenantId.Value
                }).ToList();
        }

        // Category assignments: verify the ids and stage the join rows so they insert together
        // with the product in one SaveChanges.
        var categoryIds = request.CategoryIds.Distinct().ToList();
        foreach (var categoryId in categoryIds)
        {
            if (!await _categoryRepository.ExistsAsync(categoryId))
            {
                return Result<Guid>.Invalid(ErrorCodes.Product.Invalid,
                    $"The following category IDs do not exist: {categoryId}");
            }

            _productRepository.AddProductCategory(new Domain.Entities.ProductCategory
            {
                ProductId = productToCreate.Id,
                CategoryId = categoryId,
                TenantId = currentTenantId.Value
            });
        }

        // Add the new product to the database
        await _productRepository.CreateAsync(productToCreate);

        _logger.LogInformation("Successfully created product with ID: {Id}", productToCreate.Id);

        var result = Result<Guid>.Success(productToCreate.Id);
        result.Status = ResultStatus.Created;
        return result;
    }
}
