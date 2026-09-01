using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Manufacturer.Commands.ManufacturerDelete;

public class ManufacturerDeleteHandler : IRequestHandler<ManufacturerDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ManufacturerDeleteHandler> _logger;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IProductRepository _productRepository;

    public ManufacturerDeleteHandler(
        IAppLogger<ManufacturerDeleteHandler> logger,
        IManufacturerRepository manufacturerRepository,
        IProductRepository productRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _manufacturerRepository = manufacturerRepository ?? throw new ArgumentNullException(nameof(manufacturerRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Result<Guid>> Handle(ManufacturerDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting manufacturer with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Get entity from database first
        var manufacturerToDelete = await _manufacturerRepository.GetByIdAsync(request.Id);

        if (manufacturerToDelete == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Manufacturer.NotFound, "Manufacturer not found");

            _logger.LogWarning("Manufacturer with ID: {Id} not found for deletion", request.Id);
            return result;
        }

        // Delete from database
        await _manufacturerRepository.DeleteAsync(manufacturerToDelete);

        result.Succeeded = true;
        result.Status = ResultStatus.NoContent;
        result.Data = manufacturerToDelete.Id;

        _logger.LogInformation("Successfully deleted manufacturer with ID: {Id}", manufacturerToDelete.Id);

        return result;
    }
}
