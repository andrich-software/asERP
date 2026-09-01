using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Commands.TaxClassCreate;

/// <summary>
/// Handler for processing tax class creation commands.
/// Implements IRequestHandler from the custom mediator to handle TaxClassCreateCommand requests
/// and return the ID of the newly created tax class wrapped in a Result.
/// </summary>
public class TaxClassCreateHandler : IRequestHandler<TaxClassCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<TaxClassCreateHandler> _logger;
    private readonly ITaxClassRepository _taxClassRepository;

    public TaxClassCreateHandler(
        IAppLogger<TaxClassCreateHandler> logger,
        ITaxClassRepository taxClassRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _taxClassRepository = taxClassRepository ?? throw new ArgumentNullException(nameof(taxClassRepository));
    }

    public async Task<Result<Guid>> Handle(TaxClassCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new tax class with tax rate: {TaxRate}", request.TaxRate);

        var result = new Result<Guid>();

        // Manual mapping to domain entity
        var taxClassToCreate = new Domain.Entities.TaxClass
        {
            TaxRate = request.TaxRate
        };

        // Add the new tax class to the database
        await _taxClassRepository.CreateAsync(taxClassToCreate);

        // Set successful result with the new tax class ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = taxClassToCreate.Id;

        _logger.LogInformation("Successfully created tax class with ID: {Id}", taxClassToCreate.Id);

        return result;
    }
}
