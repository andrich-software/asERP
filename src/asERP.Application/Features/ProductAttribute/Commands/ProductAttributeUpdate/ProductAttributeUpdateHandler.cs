using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;

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

        // Load the aggregate with values for tracking
        var attributeToUpdate = await _productAttributeRepository.GetWithValuesAsync(request.Id);
        if (attributeToUpdate == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.ProductAttribute.NotFound, "ProductAttribute not found or access denied due to tenant isolation.");

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
                result.Fail(ErrorType.Validation, ErrorCodes.ProductAttribute.Invalid, $"Attribute value '{valueToRemove.Value}' is in use by a variant and cannot be removed.");
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
                    result.Fail(ErrorType.Validation, ErrorCodes.ProductAttribute.Invalid, $"Attribute value with ID {valueInput.Id} not found on this attribute.");
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
        result.Status = ResultStatus.Ok;
        result.Data = attributeToUpdate.Id;

        _logger.LogInformation("Successfully updated product attribute with ID: {Id}", attributeToUpdate.Id);

        return result;
    }
}
