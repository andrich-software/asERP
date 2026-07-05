using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesDelete;

public class DeleteSalesHandler : IRequestHandler<DeleteSalesCommand, Result<Guid>>
{
    private readonly IAppLogger<DeleteSalesHandler> _logger;
    private readonly ISalesRepository _salesRepository;


    public DeleteSalesHandler(IAppLogger<DeleteSalesHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
    }

    public async Task<Result<Guid>> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting sales with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new DeleteSalesValidator(_salesRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in delete request for {0}: {1}",
                nameof(DeleteSalesCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Create entity to delete
            var salesToDelete = new Domain.Entities.Sales
            {
                Id = request.Id
            };

            // Delete from database
            await _salesRepository.DeleteAsync(salesToDelete);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = salesToDelete.Id;

            _logger.LogInformation("Successfully deleted sales with ID: {Id}", salesToDelete.Id);
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while deleting the sales.",
                "Error deleting sales.");
        }

        return result;
    }
}
