using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;

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

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new ProductAttributeDeleteValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in delete request for {0}: {1}",
                nameof(ProductAttributeDeleteCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            var attributeToDelete = await _productAttributeRepository.GetWithValuesAsync(request.Id);

            if (attributeToDelete == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add("ProductAttribute not found");

                _logger.LogWarning("ProductAttribute with ID: {Id} not found for deletion", request.Id);
                return result;
            }

            if (await _productAttributeRepository.IsInUseAsync(request.Id))
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("ProductAttribute is in use by variant products and cannot be deleted.");

                _logger.LogWarning("ProductAttribute with ID: {Id} is in use and cannot be deleted", request.Id);
                return result;
            }

            // Explicit cascade: delete values then the attribute via the DbSet (the value→attribute
            // FK is Restrict, so clearing the navigation collection would throw).
            await _productAttributeRepository.DeleteWithValuesAsync(attributeToDelete);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = attributeToDelete.Id;

            _logger.LogInformation("Successfully deleted product attribute with ID: {Id}", attributeToDelete.Id);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add("ProductAttribute not found");

            _logger.LogWarning("ProductAttribute with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while deleting the product attribute: {ex.Message}");

            _logger.LogError("Error deleting product attribute: {Message}", ex.Message);
        }

        return result;
    }
}
