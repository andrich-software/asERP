using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.ProductAttribute.Commands.ProductAttributeCreate;

public class ProductAttributeCreateHandler : IRequestHandler<ProductAttributeCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductAttributeCreateHandler> _logger;
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeCreateHandler(
        IAppLogger<ProductAttributeCreateHandler> logger,
        IProductAttributeRepository productAttributeRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productAttributeRepository = productAttributeRepository ?? throw new ArgumentNullException(nameof(productAttributeRepository));
    }

    public async Task<Result<Guid>> Handle(ProductAttributeCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new product attribute with name: {Name}", request.Name);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new ProductAttributeCreateValidator(_productAttributeRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(ProductAttributeCreateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Manual mapping to domain entity
            var attributeToCreate = new Domain.Entities.ProductAttribute
            {
                Name = request.Name,
                SortOrder = request.SortOrder,
                Values = request.Values.Select(v => new Domain.Entities.ProductAttributeValue
                {
                    Value = v.Value,
                    SortOrder = v.SortOrder
                }).ToList()
            };

            await _productAttributeRepository.CreateAsync(attributeToCreate);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = attributeToCreate.Id;

            _logger.LogInformation("Successfully created product attribute with ID: {Id}", attributeToCreate.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while creating the product attribute: {ex.Message}");

            _logger.LogError("Error creating product attribute: {Message}", ex.Message);
        }

        return result;
    }
}
