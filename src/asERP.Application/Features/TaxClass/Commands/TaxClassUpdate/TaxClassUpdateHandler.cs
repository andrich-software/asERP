using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Commands.TaxClassUpdate;

public class TaxClassUpdateHandler : IRequestHandler<TaxClassUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<TaxClassUpdateHandler> _logger;
    private readonly ITaxClassRepository _taxClassRepository;

    public TaxClassUpdateHandler(
        IAppLogger<TaxClassUpdateHandler> logger,
        ITaxClassRepository taxClassRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _taxClassRepository = taxClassRepository ?? throw new ArgumentNullException(nameof(taxClassRepository));
    }

    public async Task<Result<Guid>> Handle(TaxClassUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating tax class with ID: {Id}", request.Id);

        // Get the tax class for tracking (required for update)
        var taxClassToUpdate = await _taxClassRepository.GetByIdAsync(request.Id, true);
        if (taxClassToUpdate == null)
        {
            _logger.LogWarning("TaxClass with ID {Id} not found or access denied due to tenant isolation", request.Id);
            return Result<Guid>.NotFound(ErrorCodes.TaxClass.NotFound, "TaxClass not found or access denied due to tenant isolation.");
        }

        // Update the existing entity properties
        taxClassToUpdate.TaxRate = request.TaxRate;

        // Update in database
        await _taxClassRepository.UpdateAsync(taxClassToUpdate);

        _logger.LogInformation("Successfully updated tax class with ID: {Id}", taxClassToUpdate.Id);

        return Result<Guid>.Ok(taxClassToUpdate.Id);
    }
}
