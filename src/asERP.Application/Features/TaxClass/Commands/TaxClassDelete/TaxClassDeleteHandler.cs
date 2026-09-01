using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Commands.TaxClassDelete;

public class TaxClassDeleteHandler : IRequestHandler<TaxClassDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<TaxClassDeleteHandler> _logger;
    private readonly ITaxClassRepository _taxClassRepository;


    public TaxClassDeleteHandler(
        IAppLogger<TaxClassDeleteHandler> logger,
        ITaxClassRepository taxClassRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _taxClassRepository = taxClassRepository ?? throw new ArgumentNullException(nameof(taxClassRepository));
    }

    public async Task<Result<Guid>> Handle(TaxClassDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting tax class with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        try
        {
            // Get entity from database first
            var taxClassToDelete = await _taxClassRepository.GetByIdAsync(request.Id);

            if (taxClassToDelete == null)
            {
                result.Fail(ErrorType.NotFound, ErrorCodes.TaxClass.NotFound, "TaxClass not found");

                _logger.LogWarning("TaxClass with ID: {Id} not found for deletion", request.Id);
                return result;
            }

            // Delete from database
            await _taxClassRepository.DeleteAsync(taxClassToDelete);

            result.Succeeded = true;
            result.Status = ResultStatus.Ok;
            result.Data = taxClassToDelete.Id;

            _logger.LogInformation("Successfully deleted tax class with ID: {Id}", taxClassToDelete.Id);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            // Handle concurrent deletion - tax class was already deleted by another request
            result.Fail(ErrorType.NotFound, ErrorCodes.TaxClass.NotFound, "TaxClass not found");

            _logger.LogWarning("TaxClass with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);
        }

        return result;
    }
}
