using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
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

        // Create entity to delete
        var salesToDelete = new Domain.Entities.Sales
        {
            Id = request.Id
        };

        try
        {
            await _salesRepository.DeleteAsync(salesToDelete);
        }
        catch (Exception ex) when (ex is InvalidOperationException or UnauthorizedAccessException)
        {
            // This DELETE is idempotent — SalesController answers 204 whatever comes back — so
            // "row already gone" (InvalidOperationException) and "row belongs to another tenant"
            // (UnauthorizedAccessException) must not surface as an error. Deliberately narrow: a
            // real infrastructure failure still bubbles up to the GlobalExceptionHandler.
            _logger.LogWarning("Sales {Id} was not deletable in this context: {Message}", request.Id, ex.Message);

            result.Fail(ErrorType.NotFound, ErrorCodes.Sales.NotFound, "Sales not found");
            return result;
        }

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = salesToDelete.Id;

        _logger.LogInformation("Successfully deleted sales with ID: {Id}", salesToDelete.Id);

        return result;
    }
}
