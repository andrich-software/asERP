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

        try
        {
            // Get entity from database first
            var taxClassToDelete = await _taxClassRepository.GetByIdAsync(request.Id);

            if (taxClassToDelete == null)
            {
                _logger.LogWarning("TaxClass with ID: {Id} not found for deletion", request.Id);
                return Result<Guid>.NotFound(ErrorCodes.TaxClass.NotFound, "TaxClass not found");
            }

            // Delete from database
            await _taxClassRepository.DeleteAsync(taxClassToDelete);

            _logger.LogInformation("Successfully deleted tax class with ID: {Id}", taxClassToDelete.Id);
            return Result<Guid>.Ok(taxClassToDelete.Id);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            // Handle concurrent deletion - tax class was already deleted by another request

            _logger.LogWarning("TaxClass with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);
            return Result<Guid>.NotFound(ErrorCodes.TaxClass.NotFound, "TaxClass not found");
        }

    }
}
