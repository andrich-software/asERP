using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;

public class ProductAttributeUpdateHandler : IRequestHandler<ProductAttributeUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductAttributeUpdateHandler> _logger;
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeUpdateHandler(
        IAppLogger<ProductAttributeUpdateHandler> logger,
        IProductAttributeRepository productAttributeRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productAttributeRepository = productAttributeRepository ?? throw new ArgumentNullException(nameof(productAttributeRepository));
    }

    public async Task<Result<Guid>> Handle(ProductAttributeUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating product attribute with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new ProductAttributeUpdateValidator(_productAttributeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(ProductAttributeUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Load the aggregate with values for tracking
            var attributeToUpdate = await _productAttributeRepository.GetWithValuesAsync(request.Id);
            if (attributeToUpdate == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add("ProductAttribute not found or access denied due to tenant isolation.");

                _logger.LogWarning("ProductAttribute with ID {Id} not found or access denied due to tenant isolation", request.Id);
                return result;
            }

            attributeToUpdate.Name = request.Name;
            attributeToUpdate.SortOrder = request.SortOrder;

            // Upsert values: update by id, add new ones, delete missing (explicit cascade per project rule)
            var requestedIds = request.Values.Where(v => v.Id.HasValue).Select(v => v.Id!.Value).ToHashSet();
            var valuesToRemove = attributeToUpdate.Values.Where(v => !requestedIds.Contains(v.Id)).ToList();

            foreach (var valueToRemove in valuesToRemove)
            {
                if (await _productAttributeRepository.IsValueInUseAsync(valueToRemove.Id))
                {
                    result.Succeeded = false;
                    result.StatusCode = ResultStatusCode.BadRequest;
                    result.Messages.Add($"Attribute value '{valueToRemove.Value}' is in use by a variant and cannot be removed.");
                    return result;
                }

                // Delete via the DbSet (the value→attribute FK is Restrict; severing the
                // navigation would throw a "required relationship severed" error).
                _productAttributeRepository.RemoveValue(valueToRemove);
            }

            foreach (var valueInput in request.Values)
            {
                if (valueInput.Id.HasValue)
                {
                    var existingValue = attributeToUpdate.Values.FirstOrDefault(v => v.Id == valueInput.Id.Value);
                    if (existingValue == null)
                    {
                        result.Succeeded = false;
                        result.StatusCode = ResultStatusCode.BadRequest;
                        result.Messages.Add($"Attribute value with ID {valueInput.Id} not found on this attribute.");
                        return result;
                    }

                    existingValue.Value = valueInput.Value;
                    existingValue.SortOrder = valueInput.SortOrder;
                }
                else
                {
                    // Add via the DbSet so the new (pre-keyed) value is tracked as Added, not Modified.
                    _productAttributeRepository.AddValue(new Domain.Entities.ProductAttributeValue
                    {
                        ProductAttributeId = attributeToUpdate.Id,
                        Value = valueInput.Value,
                        SortOrder = valueInput.SortOrder,
                        TenantId = attributeToUpdate.TenantId
                    });
                }
            }

            await _productAttributeRepository.SaveChangesAsync(cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = attributeToUpdate.Id;

            _logger.LogInformation("Successfully updated product attribute with ID: {Id}", attributeToUpdate.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while updating the product attribute: {ex.Message}");

            _logger.LogError("Error updating product attribute: {Message}", ex.Message);
        }

        return result;
    }
}
