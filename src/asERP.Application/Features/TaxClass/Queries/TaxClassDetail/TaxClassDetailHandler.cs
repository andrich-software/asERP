using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Queries.TaxClassDetail;

/// <summary>
/// Handler for processing tax class detail queries.
/// Implements IRequestHandler from the custom mediator to handle TaxClassDetailQuery requests
/// and return detailed tax class information wrapped in a Result.
/// </summary>
public class TaxClassDetailHandler : IRequestHandler<TaxClassDetailQuery, Result<TaxClassDetailDto>>
{
    private readonly IAppLogger<TaxClassDetailHandler> _logger;
    private readonly ITaxClassRepository _taxClassRepository;

    public TaxClassDetailHandler(
        IAppLogger<TaxClassDetailHandler> logger,
        ITaxClassRepository taxClassRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _taxClassRepository = taxClassRepository ?? throw new ArgumentNullException(nameof(taxClassRepository));
    }

    public async Task<Result<TaxClassDetailDto>> Handle(TaxClassDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving tax class details for ID: {Id}", request.Id);

        var result = new Result<TaxClassDetailDto>();

        // Retrieve tax class with all related details from the repository
        var taxClass = await _taxClassRepository.GetByIdAsync(request.Id, true);

        // If tax class not found, return a not found result
        if (taxClass == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.TaxClass.NotFound, $"Tax class with ID {request.Id} not found");

            _logger.LogWarning("Tax class with ID {Id} not found", request.Id);
            return result;
        }

        // Manual mapping from entity to DTO
        var data = new TaxClassDetailDto
        {
            Id = taxClass.Id,
            TaxRate = taxClass.TaxRate
        };

        // Set successful result with the tax class details
        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = data;

        _logger.LogInformation("Tax class with ID {Id} retrieved successfully", request.Id);

        return result;
    }
}
