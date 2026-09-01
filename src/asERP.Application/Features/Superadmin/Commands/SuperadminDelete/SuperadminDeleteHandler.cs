using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminDelete;

public class SuperadminDeleteHandler : IRequestHandler<SuperadminDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<SuperadminDeleteHandler> _logger;
    private readonly ITenantRepository _tenantRepository;

    public SuperadminDeleteHandler(
        IAppLogger<SuperadminDeleteHandler> logger,
        ITenantRepository tenantRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _tenantRepository = tenantRepository ?? throw new ArgumentNullException(nameof(tenantRepository));
    }

    public async Task<Result<Guid>> Handle(SuperadminDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting tenant with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        var tenantToDelete = await _tenantRepository.GetByIdAsync(request.Id);

        if (tenantToDelete == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, "Tenant not found.");

            _logger.LogWarning("Tenant with ID {Id} not found for deletion", request.Id);
            return result;
        }

        await _tenantRepository.DeleteAsync(tenantToDelete);

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = tenantToDelete.Id;

        _logger.LogInformation("Successfully deleted tenant with ID: {Id}", tenantToDelete.Id);

        return result;
    }
}
