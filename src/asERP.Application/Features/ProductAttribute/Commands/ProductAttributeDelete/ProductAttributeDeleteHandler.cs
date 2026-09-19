using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;

public class ProductAttributeDeleteHandler : IRequestHandler<ProductAttributeDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductAttributeDeleteHandler> _logger;
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeDeleteHandler(
        IAppLogger<ProductAttributeDeleteHandler> logger,
        IProductAttributeRepository productAttributeRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productAttributeRepository = productAttributeRepository ?? throw new ArgumentNullException(nameof(productAttributeRepository));
    }

    public async Task<Result<Guid>> Handle(ProductAttributeDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting product attribute with ID: {Id}", request.Id);

        try
        {
            var attributeToDelete = await _productAttributeRepository.GetWithValuesAsync(request.Id);

            if (attributeToDelete == null)
            {
                _logger.LogWarning("ProductAttribute with ID: {Id} not found for deletion", request.Id);
                return Result<Guid>.NotFound(ErrorCodes.ProductAttribute.NotFound, "ProductAttribute not found");
            }

            if (await _productAttributeRepository.IsInUseAsync(request.Id))
            {
                _logger.LogWarning("ProductAttribute with ID: {Id} is in use and cannot be deleted", request.Id);
                return Result<Guid>.Invalid(ErrorCodes.ProductAttribute.Invalid, "ProductAttribute is in use by variant products and cannot be deleted.");
            }

            // Explicit cascade: delete values then the attribute via the DbSet (the value→attribute
            // FK is Restrict, so clearing the navigation collection would throw).
            await _productAttributeRepository.DeleteWithValuesAsync(attributeToDelete);

            _logger.LogInformation("Successfully deleted product attribute with ID: {Id}", attributeToDelete.Id);
            return Result<Guid>.Ok(attributeToDelete.Id);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            _logger.LogWarning("ProductAttribute with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);
            return Result<Guid>.NotFound(ErrorCodes.ProductAttribute.NotFound, "ProductAttribute not found");
        }

    }
}
